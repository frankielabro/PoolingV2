﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolingV2.ViewModels
{
    public class UserRegistrationViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleInitial { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } //ignore
        public string ContactNumber { get; set; }
        public string Country { get; set; }
        public int UserType { get; set; } //ignore

    }
}
