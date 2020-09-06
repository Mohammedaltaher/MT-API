using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace  AggriPortal.API.Extensions
{
    public static class PrincipleExtension
    {
        /// <summary>
        /// Get ApplicationUserId from Claims.
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public static string GetUserId(this HttpContext httpContext)
        {
            if(httpContext == null)
            {
                return string.Empty;
            }
            return httpContext.User.Claims.SingleOrDefault(s => s.Type == JwtRegisteredClaimNames.Jti)?.Value;
        }

        /// <summary>
        /// Get Application User Email
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public static string GetUserEmail(this HttpContext httpContext)
        {
            if (httpContext == null)
            {
                return string.Empty;
            }
            return httpContext.User.Claims.SingleOrDefault(s => s.Type == JwtRegisteredClaimNames.Sub)?.Value;
        }

        /// <summary>
        /// Get Application User Phone Number from token
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public static string GetUserPhoneNumber(this HttpContext httpContext)
        {
            if (httpContext == null)
            {
                return string.Empty;
            }
            return httpContext.User.Claims.SingleOrDefault(s => s.Type == "tel")?.Value;
        }

    }
} 
 