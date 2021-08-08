using GraphQLSampleAuthenticationAPI.Data;
using GraphQLSampleAuthenticationAPI.Data.Entities;
using GraphQLSampleAuthenticationAPI.InputTypes;
using GraphQLSampleAuthenticationAPI.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GraphQLSampleAuthenticationAPI.Logics
{
    public class AuthLogic : IAuthLogic
    {
        private readonly AuthContext _authContext;
        private readonly TokenSettings tokenSettings;

        public AuthLogic(AuthContext authContext, IOptions<TokenSettings> tokenSettings)
        {
            _authContext = authContext;
            this.tokenSettings = tokenSettings.Value;
        }

        private string RegisterValidations(RegisterInputType registerInput)
        {
            if (string.IsNullOrEmpty(registerInput.EmailAddress))
            {
                return $"{nameof(registerInput.EmailAddress)} cannot be empty";
            }

            if (string.IsNullOrEmpty(registerInput.Password) || string.IsNullOrEmpty(registerInput.ConfirmPassword))
            {
                return $"{nameof(registerInput.Password)} or {nameof(registerInput.ConfirmPassword)} cannot be empty";
            }

            return string.Empty;
        }

        private string PasswordHash(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 1000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            return Convert.ToBase64String(hashBytes);
        }

        private bool ValidatePasswordHash(string password, string dbPassword)
        {
            byte[] hashBytes = Convert.FromBase64String(dbPassword);
            byte[] salt = new byte[16];

            Array.Copy(hashBytes, 0, salt, 0, 16);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 1000);
            byte[] hash = pbkdf2.GetBytes(20);

            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                    return false;
            }

            return true;
        }

        private string GetAuthToken(User user, List<UserRoles> userRoles)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSettings.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>();
            claims.Add(new Claim("LastName", user.LastName));
            claims.Add(new Claim("Email", user.EmailAddress));

            if ((userRoles?.Count ?? 0) > 0)
            {
                foreach (var role in userRoles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role.Name));
                }
            }

            var token = new JwtSecurityToken(
                issuer: tokenSettings.Issuer,
                audience: tokenSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(20),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string Register(RegisterInputType registerInput)
        {
            string errorMessage = RegisterValidations(registerInput);

            if (!string.IsNullOrEmpty(errorMessage))
            {
                return errorMessage;
            }

            User user = new User
            {
                EmailAddress = registerInput.EmailAddress,
                FirstName = registerInput.FirstName,
                LastName = registerInput.LastName,
                Password = PasswordHash(registerInput.Password)
            };

            _authContext.Users.Add(user);
            _authContext.SaveChanges();

            UserRoles userRoles = new UserRoles
            {
                Name = "admin",
                UserId = user.UserId
            };

            _authContext.UserRoles.Add(userRoles);
            _authContext.SaveChanges();

            return "Registration successful!";
        }

        public string Login(LoginInputType loginInput)
        {
            if (string.IsNullOrEmpty(loginInput.Email) || string.IsNullOrEmpty(loginInput.Password))
                return "Invalid Credentials";

            var user = _authContext.Users.Where(_ => _.EmailAddress == loginInput.Email).FirstOrDefault();
            if (user == null)
                return "User Not Found";

            if (!ValidatePasswordHash(loginInput.Password, user.Password))
                return "Invalid Credentials";

            var userRoles = _authContext.UserRoles.Where(_ => _.UserId == user.UserId).ToList();
            return GetAuthToken(user, userRoles);

        }
    }
}
