using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using GraphQLSampleAuthenticationAPI.Data.Entities;
using GraphQLSampleAuthenticationAPI.Models;
using HotChocolate;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace GraphQLSampleAuthenticationAPI.GraphQL.CoreSchemas
{
    public class Mutation
    {
        private List<User> users = new List<User>{
            new User{Id = 1, Email= "gokberk@gokberk.com", FirstName = "Gokberk", LastName = "Yildirim", Password = "1234", PhoneNumber = "555555"},
            new User{Id = 2, Email= "gizem@gokberk.com", FirstName = "Gizem", LastName = "Guner", Password = "56789", PhoneNumber = "444444"}
        };

        public string UserLogin([Service] IOptions<TokenSettings> tokenSettings, LoginInput loginInput)
        {
            var currentUser = users.FirstOrDefault(x => x.Email.ToLower() == loginInput.Email.ToLower() && x.Password == loginInput.Password);
            if (currentUser != null)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSettings.Value.Key));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var jwtToken = new JwtSecurityToken(
                    issuer: tokenSettings.Value.Issuer,
                    audience: tokenSettings.Value.Audience,
                    expires: DateTime.Now.AddMinutes(20),
                    signingCredentials: credentials
                );

                return new JwtSecurityTokenHandler().WriteToken(jwtToken);
            }
            return "User Not Found";
        }
    }
}