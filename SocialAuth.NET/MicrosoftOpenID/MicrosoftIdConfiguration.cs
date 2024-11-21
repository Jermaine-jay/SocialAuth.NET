using SocialAuth.NET.AppleOpenID;
using SocialAuth.NET.OpenID;

namespace SocialAuth.NET.MicrosoftOpenID
{
    public class MicrosoftIdConfiguration : IMicrosoftIdConfiguration
    {
        private readonly OpenIdConfiguration _openId;
        private readonly string _baseUrl;
        private readonly string _path;
        private readonly string _metadataUrl;

        public MicrosoftIdConfiguration(OpenIdConfiguration openId)
        {
            _openId = openId;
            _baseUrl = "https://login.microsoftonline.com";
            _metadataUrl = "v2.0/.well-known/openid-configuration";
        }

        public object ValidateMicrosoftToken(string audience, string tenant)
        {
            string baseUrl = _baseUrl + $"/{tenant}/v2.0";
            string metadataUrl = $"{_baseUrl}/{tenant}/{_metadataUrl}";

            string result = _openId.ValidateToken<MicrosoftPayload>(audience, baseUrl,metadataUrl);
            //result.Email = result.Username;
 
            return result;
        }
    }
}
