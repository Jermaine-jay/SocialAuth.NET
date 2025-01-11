using SocialAuth.NET.OpenID;

namespace SocialAuth.NET.FacebookOpenID
{
    public class FacebookIdConfiguration : IFacebookIdConfiguration
    {
        protected readonly OpenIdConfiguration _openId;
        private readonly string _userUrl;
        private readonly string _tokenUrl;
        private readonly string _baseUrl;

        public FacebookIdConfiguration(OpenIdConfiguration openId)
        {
            _openId = openId;
            _baseUrl = "https://graph.facebook.com";
            _userUrl = "/me?fields=first_name,last_name,email,id&access_token=";
            _tokenUrl = "/debug_token?input_token=";
        }

        public Payload ValidateFacebookToken(string appId, string appSecret)
        {
            string url = $"{_tokenUrl}{_openId.Token}&access_token={appId}|{appSecret}";
            using var client = new HttpClient();

            client.BaseAddress = new Uri(_baseUrl);
            HttpResponseMessage? debugTokenResponse = client.GetAsync(url).Result;

            string stringThing = debugTokenResponse.Content.ReadAsStringAsync().Result;
            FBUser? userOBJK = JsonConvert.DeserializeObject<FBUser>(stringThing);

            if (userOBJK?.Data.IsValid == false)
                throw new SecurityTokenValidationException("Unauthorized user");

            string userUrl = _userUrl + _openId.Token;
            HttpResponseMessage meResponse = client.GetAsync(userUrl).Result;
            string? userContent = meResponse.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<FacebookPayload>(userContent);
        }
    }
}
