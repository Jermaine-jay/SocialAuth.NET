using Newtonsoft.Json;
using SocialAuth.NET.OpenID;

namespace SocialAuth.NET.MicrosoftOpenID
{
    public class MicrosoftPayload : Payload
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonIgnore]
        public string? _Email;

        [JsonProperty("preferred_username")]
        public string Username
        {
            get => _Email;
            set { _Email = value; Email = value;}
        }

        [JsonProperty("nonce")]
        public string Nonce { get; set; }

        [JsonProperty("oid")]
        public string ObjectId { get; set; }

        [JsonProperty("tid")]
        public string TenantId { get; set; }

        [JsonProperty("aio")]
        public string AIO { get; set; }
    }
}
