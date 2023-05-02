using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Authentication_ApplicationCore.Contract.Repository;
using Authentication_ApplicationCore.Contract.Service;
using Authentication_ApplicationCore.Model;
using Authentication_Infrastructure.Repository;
using Authentication_Infrastructure.Service;
using JwtAuthenticationManager;
using JwtAuthenticationManager.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using IAuthenticationService = Authentication_ApplicationCore.Contract.Service.IAuthenticationService;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Authentication_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JwtTokenHandler _jwtTokenHandler;
        private readonly IAuthenticationService _authenticationService;

        public AccountController(JwtTokenHandler jwtTokenHandler, IAuthenticationService authenticationService)
        {
            _jwtTokenHandler = jwtTokenHandler;
            _authenticationService = authenticationService;
        }

        /* CRUD Methods are no longer needed for Account Controller, instead, LogIn and SignUp APIs are created

        [HttpGet("GetAllAccounts")]
        public async Task<IActionResult> AllAccounts()
        {
            var accounts = await _accountService.GetAllAccounts();
            return Ok(accounts);
        }

        [HttpPost("AddNewAccount")]
        public async Task<IActionResult> InsertAccount(AccountRequestModel account)
        {
            try
            {
                await _accountService.AddAccountAsync(account);
                return Ok(account);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("DeleteAccountById/{id}")]
        public async Task<IActionResult> DeleteAccountById(int id)
        {
            try
            {
                await _accountService.DeleteAccountAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPut("UpdateAccount")]
        public async Task<IActionResult> UpdateAccountInfo(AccountRequestModel account)
        {
            try
            {
                await _accountService.UpdateAccountAsync(account);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound("Cannot found account: " + ex);
            }
        }

        [HttpGet("GetAccountById/{id}")]
        public async Task<IActionResult> GetAccountById(int id)
        {
            var result = await _accountService.GetAccountByIdAsync(id);
            if (result != null)
                return Ok(result);
            else
                return NotFound("Account not Found\n");
        }*/

        // Lecture Example 1: let user login and generate a token to access APIs
        // (APIs in Candidate Controller, and AddNewJobRequirement in JobRequirement Controller.
        // Both Controllers are under Recruiting assembly.)
        /*
        [HttpPost("Login")]
        public async Task<IActionResult> Login(AuthenticationRequest request)
        {
            var response = _jwtTokenHandler.GenerateToken(request);
            if (response == null)
                return Unauthorized();
            return Ok(response);
        }*/
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var result = await _authenticationService.LoginAsync(model);
            if (result.Succeeded)
            {
                AuthenticationRequest request = new AuthenticationRequest()
                {
                    Username = model.Username,
                    Password = model.Password
                };
                var response = _jwtTokenHandler.GenerateToken(request, "admin");
                if (response == null) return Unauthorized();
                return Ok(response);
            }
            return Unauthorized();
        }


        // Lecture Example 2: register an account
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUpModel model)
        {
            var result = await _authenticationService.SignUpAsync(model);
            if (result.Succeeded)
                return Ok("Your account has been created");
            return BadRequest();
        }

    }
}

