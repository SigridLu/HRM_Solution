using System;
using Authentication_ApplicationCore.Contract.Repository;
using Authentication_ApplicationCore.Model;
using Authentication_Infrastructure.Data;
using Microsoft.AspNetCore.Identity;

namespace Authentication_Infrastructure.Repository
{
    // Only Admin would be able to call the methods
    public class AuthenticationRepository : IAuthenticationRepository
    {
        /*protected readonly AuthenticationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthenticationRepository(AuthenticationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IdentityResult> SignUpAsync(SignUpModel model)
        {
            return await _userManager.CreateAsync();
        }*/
    }
}

