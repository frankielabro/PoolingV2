using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PoolingV2.Models;

namespace PoolingV2.Services
{
    public interface IAuthRepository
    {
        Task<Freelancer> Register(Freelancer freelancer, string password);
        Task<Employer> Register(Employer employer, string password);
        Task<Freelancer> Login(string email, string password);
        Task<Employer> LoginE(string email, string password);
        Task<bool> UserExists(string email);
    }
}
