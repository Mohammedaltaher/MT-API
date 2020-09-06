using AggriPortal.API.Contracts.Response;
using AggriPortal.API.Helper.Security.Hashing;
using AggriPortal.API.Helper.Security.Tokens;
using System.Threading.Tasks;

namespace  AggriPortal.API.Services
{
    public interface IAuthenticationService
    {
        //Task<TokenResponse> CreateAccessTokenAsync(UserLoginRequest request);
        Task<TokenResponse> RefreshTokenAsync(string refreshToken, string userEmail);
        void RevokeRefreshToken(string refreshToken);
    }
    public class AuthenticationService: IAuthenticationService
    {
        private readonly IIdentityService identityService;
        private readonly IHasher hasher;
        private readonly ITokenHandler tokenHandler;

        public AuthenticationService(IIdentityService identityService, IHasher hasher, ITokenHandler tokenHandler)
        {
            this.identityService = identityService;
            this.hasher = hasher;
            this.tokenHandler = tokenHandler;
        }

        public async Task<TokenResponse> RefreshTokenAsync(string refreshToken, string userEmail)
        {
            var token = tokenHandler.TakeRefreshToken(refreshToken);

            if (token == null)
            {
                return new TokenResponse(null,"","",false,498, "Invalid refresh token.");
            }

            if (token.IsExpired())
            {
                return new TokenResponse(null,"","",false,498, "Expired refresh token.");
            }

            var user = await identityService.GetByUserNameAsync(userEmail);
           // var roles = await identityService.roles(user);

            if (user == null)
            {
                return new TokenResponse(null,"","",false,498, "Invalid refresh token.", null);
            }

            var accessToken =  tokenHandler.CreateAccessToken(user , null);
            return new TokenResponse(accessToken, hasher.Encrypt(user.Id), hasher.Encrypt(user.PhoneNumber), true,200,"Token refreshed successfully");
        }

        public void RevokeRefreshToken(string refreshToken)
        {
            tokenHandler.RevokeRefreshToken(refreshToken);
        }
    }
}
