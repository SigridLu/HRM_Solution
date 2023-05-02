using System;
using Authentication_ApplicationCore.Model;
using Microsoft.AspNetCore.Identity;

namespace Authentication_ApplicationCore.Contract.Service
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> SignUpAsync(SignUpModel model);
        Task<SignInResult> LoginAsync(LoginModel model);
    }
}

