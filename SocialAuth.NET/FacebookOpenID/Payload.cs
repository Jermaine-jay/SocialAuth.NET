using Newtonsoft.Json;
using SocialAuth.NET.OpenID;

namespace SocialAuth.NET.FacebookOpenID
{
    public class FacebookPayload : Payload
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("last_name")]
        public string Surname { get; set; }

        [JsonProperty("first_name")]
        public string GivenName { get; set; }
    }

    public class FBUser
    {
        [JsonProperty("data")]
        public Data Data { get; set; }
    }

    public class Data
    {
        [JsonProperty("app_id")]
        public string? AppId { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("application")]
        public string? Application { get; set; }

        [JsonProperty("data_access_expires_at")]
        public long DataAccessExpiresAt { get; set; }

        [JsonProperty("expires_at")]
        public long ExpiresAt { get; set; }

        [JsonProperty("is_valid")]
        public bool IsValid { get; set; }

        [JsonProperty("scopes")]
        public List<string> Scopes { get; set; }

        [JsonProperty("user_id")]
        public string? UserId { get; set; }
    }
}
