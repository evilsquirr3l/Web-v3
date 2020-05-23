using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Business.Abstraction;
using Business.Implementation.Configurations;
using Business.Implementation.Validation;
using Business.Models;
using Data.Abstraction;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Microsoft.IdentityModel.Tokens;

namespace Business.Implementation
{
    public class UserService : IUserService
    {
        private readonly JwtSettings _jwtSettings;
        private readonly IUnitOfWork _unit;

        public UserService(IOptions<JwtSettings> jwtSettings, IUnitOfWork unit)
        {
            _unit = unit;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<object> Login(LoginModel model)
        {
            var result = await _unit.SignInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

            if (result.Succeeded)
            {
                var user = await _unit.UserManager.Users.SingleOrDefaultAsync(u => u.Email == model.Email);

                return await GenerateJwtToken(model.Email, user);
            }

            throw new BusinessException("Login failed.");
        }

        public async Task<object> Register(UserRegistrationModel model)
        {
            var user = new User()
            {
                Email = model.Email,
                UserName = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName
            };
            
            var result = await _unit.UserManager.CreateAsync(user, model.Password);
            
            if (result.Succeeded)
            {
                return await GenerateJwtToken(model.Email, user);
            }

            string errors = result.Errors.Aggregate("", (current, identityError) => current + (identityError.Description + "\n"));

            throw new BusinessException(errors);
        }
        
        private async Task<object> GenerateJwtToken(string email, User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.UtcNow.Add(_jwtSettings.Lifetime);

            var token = new JwtSecurityToken(
                _jwtSettings.Issuer,
                _jwtSettings.Audience,
                claims,
                expires: expires,
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}