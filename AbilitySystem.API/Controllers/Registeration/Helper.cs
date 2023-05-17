﻿using AbilitySystem.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AbilitySystem.API.Controllers.Registeration
{
    public  class Helper: IHelper
    {

        private  readonly IConfiguration _configuration;
       

        public  Helper(IConfiguration configuration)
        {
            _configuration = configuration;
      
        }

        //public Helper()
        //{
        //}

        #region Helpers

        public string GenerateToken(IList<Claim> claimsList, DateTime exp)
        {
            var secretKeyString = _configuration.GetValue<string>("SecretKey") ?? string.Empty;
            var secretKeyInBytes = Encoding.ASCII.GetBytes(secretKeyString);
            var securityKey = new SymmetricSecurityKey(secretKeyInBytes);

            var signingCredentials = new SigningCredentials(securityKey,
                SecurityAlgorithms.HmacSha256Signature);


            var jwt = new JwtSecurityToken(
                claims: claimsList,
                expires: exp,
                signingCredentials: signingCredentials);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString = tokenHandler.WriteToken(jwt);

            return tokenString;
        }

        //public static int GetRandomInt(int min, int max)
        //{
        //    Random random = new Random();
        //    return random.Next(min, max + 1);
        //}

        #endregion
    }
}
