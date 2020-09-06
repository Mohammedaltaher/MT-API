using Microsoft.IdentityModel.Tokens;
using System;

namespace  AggriPortal.API.Helper.Security.Tokens
{
    public class SigningConfigurations
    {
        public string SecertKey { get; set; }
        public SecurityKey Key { get; }
        public SigningCredentials SigningCredentials { get; }

        public SigningConfigurations()
        {
            #region Using RsaSecurityKey
            /// Generate key by RsaSecurityKey
            /// Generate RsaSha256Signature
            //using (var provider = new RSACryptoServiceProvider(2048))
            //{
            //    Key = new RsaSecurityKey(provider.ExportParameters(true));
            //}
            ////RsaSha256Signature
            //SigningCredentials = new SigningCredentials(Key, SecurityAlgorithms.RsaSha256Signature);
            #endregion
            SecertKey = "V20B1HSQnWBK5vIfXH+kcrtm2Nsk73EAThgZ5eVrzNc=";
            Key = new SymmetricSecurityKey(Convert.FromBase64String(SecertKey));
            SigningCredentials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);
        }
    }
}
