using System;
using Authentication_ApplicationCore.Contract.Repository;
using Authentication_ApplicationCore.Contract.Service;
using Authentication_ApplicationCore.Model;
using Microsoft.AspNetCore.Identity;

namespace Authentication_Infrastructure.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        IAuthenticationRepository authenticationRepo;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthenticationService(IAuthenticationRepository _authenticationRepo, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            authenticationRepo = _authenticationRepo;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> SignUpAsync(SignUpModel model)
        {
            ApplicationUser user = new ApplicationUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email
            };
            return await _userManager.CreateAsync(user, model.Password);
        }

        public async Task<SignInResult> LoginAsync(LoginModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);
            return result;
        }
    }
}

