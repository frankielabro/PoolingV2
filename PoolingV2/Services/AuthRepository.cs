using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PoolingV2.EntityFramework;
using PoolingV2.Models;
using Microsoft.AspNetCore.Mvc;

namespace PoolingV2.Services
{
    /*This AuthRepository is for the authentication of Admins*/
    public class AuthRepository : IAuthRepository
    {
        

        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Freelancer> Register(Freelancer freelancer, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            freelancer.PasswordHash = passwordHash;
            freelancer.PasswordSalt = passwordSalt;
            freelancer.DateCreated = DateTime.Now;

            await _context.Freelancer.AddAsync(freelancer); //Add a row in the "Admins" table with the value "admin"
            await _context.SaveChangesAsync(); //Save changes in the database

            return freelancer;
        }

        public async Task<Employer> Register(Employer employer, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            employer.PasswordHash = passwordHash;
            employer.PasswordSalt = passwordSalt;
            employer.DateCreated = DateTime.Now;

            await _context.Employer.AddAsync(employer); //Add a row in the "Admins" table with the value "admin"
            await _context.SaveChangesAsync(); //Save changes in the database

            return employer;
        }

        //I modidifed this one from async Task<T> to Task 
        
        public async Task<Freelancer> Login(string email, string password)
        {
            var freelancer = await _context.Freelancer.FirstOrDefaultAsync(a => a.Email == email);
            if (freelancer == null)
            {
                return null;
            }

            if (!VerifyPasswordHash(password, freelancer.PasswordHash, freelancer.PasswordSalt))
            {
                return null;
            }

            return freelancer;
        }

        public async Task<Employer> LoginE(string email, string password)
        {
            var employer = await _context.Employer.FirstOrDefaultAsync(a => a.Email == email);
            if (employer == null)
            {
                return null;
            }

            if (!VerifyPasswordHash(password, employer.PasswordHash, employer.PasswordSalt))
            {
                return null;
            }

            return employer;
        }



        public async Task<bool> UserExists(string email)
        {
            if (await _context.Freelancer.AnyAsync(a => a.Email == email))
            {
                return true;
            }
            else if (await _context.Employer.AnyAsync(a => a.Email == email))
            {
                return true;
            }
            return false;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
                return true;
            }
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        /*=========NEW METHODS HERE=========*/
        /*Authentication methods made for Client Login/Registration here*/

       

        
    }
}
