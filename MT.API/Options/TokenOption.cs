﻿namespace  AggriPortal.API.Options
{
    public class TokenOption
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int AccessTokenExpiration { get; set; }
        public int RefreshTokenExpiration { get; set; }
        public string Secret { get; set; }

    }
}
