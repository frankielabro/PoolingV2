using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolingV2.Models
{
    public class Employer
    {
        public int EmployerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleInitial { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string ContactNumber { get; set; }
        public string Country { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public int IsVerified { get; set; }
        public string Photo { get; set; }
        public string Title { get; set; }
    }
}
