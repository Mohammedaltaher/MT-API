using AggriPortal.API.Helper.Security.Tokens;
using System.Collections.Generic;

namespace  AggriPortal.API.Contracts.Response
{
    public class TokenResponse: BaseResponse
    {
        public string UserId { get; set; }
        public string PhoneNumber { get; set; }
        public AccessToken Token { get; set; }
        public TokenResponse(AccessToken token,string userId,string phoneNumber, bool success, int statusCode, string message, List<ValidationError> errors = null) : base(success,statusCode, message,errors)
        {
            Token = token;
            UserId = userId;
            PhoneNumber = phoneNumber;
        }
    }
}
