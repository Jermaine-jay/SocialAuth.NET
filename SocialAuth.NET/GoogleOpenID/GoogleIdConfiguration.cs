using SocialAuth.NET.OpenID;

namespace SocialAuth.NET.GoogleOpenID
{
    public class GoogleIdConfiguration : IGoogleIdConfiguration
    {
        private readonly string _baseUrl;
        private readonly string _metadataUtl;
        private readonly OpenIdConfiguration _openId;

        public GoogleIdConfiguration(OpenIdConfiguration openId)
        {
            _openId = openId;
            _baseUrl = "https://accounts.google.com";
            _metadataUtl = _baseUrl + "/.well-known/openid-configuration";
        }

        public string ValidateGoogleToken(string audience)
        {
            return _openId.ValidateToken<GooglePayload>(audience, _baseUrl, _metadataUtl);
        }
    }
}
