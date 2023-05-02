using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JwtAuthenticationManager.Models;
using Microsoft.IdentityModel.Tokens;

namespace JwtAuthenticationManager
{
    public class JwtTokenHandler
    {
        public const string JWT_Secret_Key = "&F)J@NcRfUjXn2r4u7x!A%D*G-KaPdSgVkYp3s6v8y/B?E(H+MbQeThWmZq4t7w!";
        private const int JWT_Token_Validity_Min = 20; // set the token valid time as 20 mins

        public AuthenticationResponse GenerateToken(AuthenticationRequest request, string role)
        {
            // start working on jwt token
            var tokenExpiryTime = DateTime.UtcNow.AddMinutes(JWT_Token_Validity_Min); // ExpiryTime will be in DateTime type
            var tokenKey = Encoding.ASCII.GetBytes(JWT_Secret_Key); // convert to byte for SigningCredentials security key 

            // Add claims to send additional data in the future req-uests
            var claimsIdentity = new ClaimsIdentity(new List<Claim> {
                new Claim(JwtRegisteredClaimNames.Name, request.Username),
                new Claim(ClaimTypes.Role, role)
            });

            // Details for token encrytion: SigningCredentials ([security Key], [algorithm])
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature
            );

            // Details for token creation: SecurityTokenDescriptor
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = tokenExpiryTime,
                SigningCredentials = signingCredentials
            };

            // Create token
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(securityToken);

            return new AuthenticationResponse {
                Token = token,
                ExpiresIn = (int)tokenExpiryTime.Subtract(DateTime.UtcNow).TotalSeconds,
                Username = request.Username };
        }
    }
}

