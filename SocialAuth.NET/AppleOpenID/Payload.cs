using Newtonsoft.Json;
using SocialAuth.NET.OpenID;

namespace SocialAuth.NET.AppleOpenID
{
    public class ApplePayload : Payload
    {
        [JsonProperty("email_verified")]
        public bool EmailVerified { get; set; }
        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("nonce_supported")]
        public string NonceSupported { get; set; }

        [JsonProperty("c_hash")]
        public string CHash { get; set; }
    }

    public class User
    {
        [JsonProperty("name")]
        public Name Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }

    public class Name
    {
        [JsonProperty("firstname")]
        public string Firstname { get; set; }

        [JsonProperty("lastname")]
        public string LastName { get; set; }
    }
}
