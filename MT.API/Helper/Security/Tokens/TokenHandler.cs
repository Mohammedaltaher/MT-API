using AggriPortal.API.Domain.Models;
using AggriPortal.API.Options;
using AggriPortal.API.Helper.Security.Hashing;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AggriPortal.API.Persistence;
using Microsoft.AspNetCore.Identity;

namespace  AggriPortal.API.Helper.Security.Tokens
{
    public interface ITokenHandler 
    {
       AccessToken CreateAccessToken(ApplicationUser user, List<Claim> claims);
        RefreshToken TakeRefreshToken(string token);
        void RevokeRefreshToken(string token);
    }
    public class TokenHandler : ITokenHandler
    {
        private readonly ISet<RefreshToken> _refreshTokens = new HashSet<RefreshToken>();

        private readonly TokenOption _tokenOptions;
        private readonly IHasher _hasher;
        private readonly SigningConfigurations _signingConfigurations;
        private IUnitOfWork unitOfWork;
        private RoleManager<ApplicationRole> _roleManager;
        private UserManager<ApplicationUser> _userManager;
        public TokenHandler(IOptions<TokenOption> tokenOptionSnapshot, SigningConfigurations signingConfigurations, IHasher hasher, IUnitOfWork unitOfWork, RoleManager<ApplicationRole> roleManger, UserManager<ApplicationUser> userManger)
        {
            _tokenOptions = tokenOptionSnapshot.Value;
            _hasher = hasher;
            this.unitOfWork = unitOfWork;
            _signingConfigurations = signingConfigurations;
            _roleManager = roleManger;
            _userManager = userManger;
        }
        public  AccessToken CreateAccessToken(ApplicationUser user, List<Claim> claims)
        {
            var refreshToken = BuildRefreshToken();
            var accessToken =  BuildAccessToken(user, claims, refreshToken);
            _refreshTokens.Add(refreshToken);

            return  accessToken;
        }

        public void RevokeRefreshToken(string token)
        {
            TakeRefreshToken(token);
        }

        public RefreshToken TakeRefreshToken(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
                return null;

            var refreshToken = _refreshTokens.SingleOrDefault(t => t.Token == token);
            if (refreshToken != null)
                _refreshTokens.Remove(refreshToken);

            return refreshToken;
        }

        private RefreshToken BuildRefreshToken()
        {
            var refreshToken = new RefreshToken
            (
                token: _hasher.Hash(Guid.NewGuid().ToString()),
                expiration: DateTime.Now.AddSeconds(_tokenOptions.RefreshTokenExpiration).Ticks
            );

            return refreshToken;
        }
        private AccessToken BuildAccessToken(ApplicationUser user, List<Claim> claims, RefreshToken refreshToken)
        {
            var accessTokenExpiration = DateTime.Now.AddDays(_tokenOptions.AccessTokenExpiration);

            var securityToken = new JwtSecurityToken
            (
                issuer: _tokenOptions.Issuer,
                audience: _tokenOptions.Audience,
                claims:  claims,
                expires: accessTokenExpiration,
                notBefore: DateTime.UtcNow,
                signingCredentials: _signingConfigurations.SigningCredentials
            );
            var accessToken = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return new AccessToken(accessToken, accessTokenExpiration.Ticks, refreshToken);
        }

        private async Task<List<Claim>> GetClaims(ApplicationUser user, IList<string> roles)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, user.Id),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim("tel", user.PhoneNumber),
                new Claim("lng", string.IsNullOrEmpty(user.DefaultLang)? "ar" : user.DefaultLang)
                // Add your custom claims here 
            };
                if (roles != null)
                {
                    foreach (var role in roles)
                    {
                        var _role = _roleManager.Roles.Where(x => x.Name == role.ToString()).FirstOrDefault();
                        // Add role
                        claims.Add(new Claim(ClaimTypes.Role, _role.Name));
                        if (_role != null)
                        {
                            var roleClaims = await _roleManager.GetClaimsAsync(_role);
                            // Add role claim
                            foreach (Claim roleClaim in roleClaims)
                            {
                                claims.Add(roleClaim);
                            }
                        }
                    }
                }
            return claims;
        }
    
    }
}
