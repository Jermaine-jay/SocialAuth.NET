using Newtonsoft.Json;
using SocialAuth.NET.OpenID;

namespace SocialAuth.NET.GoogleOpenID
{
    public class GooglePayload : Payload
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("picture")]
        public string Picture { get; set; }

        [JsonProperty("given_name")]
        public string Givenname { get; set; }

        [JsonProperty("family_name")]
        public string Familyname { get; set; }
        [JsonProperty("email_verified")]
        public bool EmailVerified { get; set; }

        [JsonProperty("jti")]
        public string JWTID { get; set; }

    }
}
