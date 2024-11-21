﻿using Newtonsoft.Json;
using SocialAuth.NET.OpenID;

namespace SocialAuth.NET.AppleOpenID
{
    public class AppleIdConfiguration : IAppleIdConfiguration
    {
        private readonly OpenIdConfiguration _openId;
        private readonly string _baseUrl;
        private readonly string _metadataUrl;
        public AppleIdConfiguration(OpenIdConfiguration openId)
        {
            _openId = openId;
            _baseUrl = "https://appleid.apple.com";
            _metadataUrl = _baseUrl + "/.well-known/openid-configuration";
        }

        public object ValidateAppleToken(string audience)
        {
            audience = "com.activEight.activEight";
            return _openId.ValidateToken<ApplePayload>(audience, _baseUrl, _metadataUrl);
        }
    }
}
