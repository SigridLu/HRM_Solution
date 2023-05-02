using System;
namespace JwtAuthenticationManager.Models
{
    public class UserAccount
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } // check if the user has access to the service based on the role
    }
}

