using HotChocolate.AspNetCore.Authorization;
using System;
using System.ComponentModel.DataAnnotations;

namespace GraphQLSampleAuthenticationAPI.Data.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        //[Authorize] Restricts password property being shown in the api call coming from unauthorized request
        public string Password { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiration { get; set; }
    }
}