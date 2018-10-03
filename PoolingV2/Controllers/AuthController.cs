using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PoolingV2.EntityFramework;
using PoolingV2.Models;
using PoolingV2.ViewModels;
using PoolingV2.Services;
using System;
using System.Threading.Tasks;
using AutoMapper;

namespace PoolingV2.Controllers
{
    public class AuthController : Controller
    {
        
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;
        private readonly IMapper _map;
        

        public AuthController(IAuthRepository repo, IConfiguration config, IMapper map)
        {
            _repo = repo;
            _config = config;
            _map = map;
        }

        

        [HttpPost("Registration")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationViewModel registerVM)
        {
            try
            {
                if (await _repo.UserExists(registerVM.Email)) 
                {
                    ModelState.AddModelError("Email", "This email is not available.");
                }

                if (!ModelState.IsValid)
                {
                    return Json(BadRequest(ModelState));
                }

                //Clean the registerVM here
                registerVM.Email = registerVM.Email.ToLower();

                //Freelancer
                if (registerVM.UserType == 0)
                {
                    var user = _map.Map<Freelancer>(registerVM); //stopped here
                    await _repo.Register(user, registerVM.Password);
                }
                //Employer
                else if (registerVM.UserType == 1)
                {
                    var user = _map.Map<Employer>(registerVM);
                    await _repo.Register(user, registerVM.Password);
                }
                else
                {
                    return Json(BadRequest("Invalid UserType"));
                }
                
                return Json(StatusCode(201));
            }
            catch (Exception ex)
            {
                return Json(BadRequest(ex));
            }           
        } 
        
        /*
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AdminLoginViewModel loginVM)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(StatusCode(400));
                    
                }
                var adminFromRepo = await _repo.Login(loginVM.Username, loginVM.Password);

                if(adminFromRepo == null)
                {
                    return Json(StatusCode(401));
                }
                var tokenHandler = new JwtSecurityTokenHandler();

                var key = Encoding.ASCII.GetBytes(_config.GetSection("AppSettings:Token").Value); 
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, adminFromRepo.AdminId.ToString()),
                        new Claim(ClaimTypes.Name, adminFromRepo.Username)
                    }),
                    Expires = DateTime.Now.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha512Signature)   
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);
                
                return Json(StatusCode(201, tokenString));
            }
            catch (Exception)
            {
                throw;
            }
        }

    
        */
    }
}