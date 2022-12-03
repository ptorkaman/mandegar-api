using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Principal;
using System.Text;

namespace Mandegar.Utilities.ActionFilters
{
    public class SecurityAuthorize : Attribute, IAuthorizationFilter
    {

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var token = context.HttpContext.Session.GetString("User");
            var currentUerId = context.HttpContext.Items["UserId"];
            bool isValidToken = false;

            if (string.IsNullOrWhiteSpace(token))
            {
                token = context.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            }

            if (string.IsNullOrWhiteSpace(token) == false)
            {
                isValidToken = ValidateToken(token);
            }


            if (currentUerId == null && !isValidToken)
            {
                var path = context.HttpContext.Request.Path;
                context.Result = new RedirectResult($"/auth/login?ReturnUrl={path}");
            }
        }

        #region Methods

        private bool ValidateToken(string authToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = GetValidationParameters();

            SecurityToken validatedToken;
            IPrincipal principal = tokenHandler.ValidateToken(authToken, validationParameters, out validatedToken);
            return true;
        }

        private TokenValidationParameters GetValidationParameters()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json")
              .Build();

            var key = configuration.GetSection("JwtConfig").GetSection("Secret").Value;

            return new TokenValidationParameters()
            {
                ValidateLifetime = false,
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidIssuer = "Sample",
                ValidAudience = "Sample",
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)) // The same key as the one that generate the token
            };
        }

        #endregion

    }
}
