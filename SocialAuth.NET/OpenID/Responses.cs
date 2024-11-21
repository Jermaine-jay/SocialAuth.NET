using Newtonsoft.Json;

namespace SocialAuth.NET.OpenID
{
    public class Responses
    {
    }
    public class Header
    {
        [JsonProperty("alg")]
        public string Algorithim { get; set; }
        [JsonProperty("typ")]
        public string Type { get; set; }
        [JsonProperty("kid")]
        public string Keys { get; set; }
    }

    public class Payload
    {
        [JsonProperty("iss")]
        public string Issuer { get; set; }
        [JsonProperty("aud")]
        public string Audience { get; set; }
        [JsonProperty("exp")]
        public string ExpiredAt { get; set; }
        [JsonProperty("iat")]
        public string IssuedAt { get; set; }
        [JsonProperty("sub")]
        public string Subject { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
