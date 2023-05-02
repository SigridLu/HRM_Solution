using System;
using Microsoft.AspNetCore.Identity;

namespace Authentication_ApplicationCore.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

