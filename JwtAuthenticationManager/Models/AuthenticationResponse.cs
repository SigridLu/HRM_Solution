﻿using System;
namespace JwtAuthenticationManager.Models
{
    public class AuthenticationResponse
    {
        public string Username { get; set; }
        public string Token { get; set; }
        public int ExpiresIn { get; set; }
    }
}

