using SocialAuth.NET.AppleOpenID;
using SocialAuth.NET.FacebookOpenID;
using SocialAuth.NET.GoogleOpenID;
using SocialAuth.NET.MicrosoftOpenID;

namespace SocialAuth.NET.OpenID
{
    public class OpenIdConfiguration
    {
        private const string SupportedJwtAlgorithm = "RS256";
        internal const int MaxJwtLength = 10000;
        public IAppleIdConfiguration appleIdConfiguration;
        public IGoogleIdConfiguration googleIdConfiguration;
        public IMicrosoftIdConfiguration microsoftIdConfiguration;
        public IFacebookIdConfiguration facebookIdConfiguration;
        private readonly HttpClient _httpClient;
        public string Token { get; private set; }

        public OpenIdConfiguration(string token)
        {
            Token = token;
            _httpClient = new HttpClient();
            appleIdConfiguration = new AppleIdConfiguration(this);
            googleIdConfiguration = new GoogleIdConfiguration(this);
            microsoftIdConfiguration = new MicrosoftIdConfiguration(this);
            facebookIdConfiguration = new FacebookIdConfiguration(this);
        }

        public string ValidateToken<T>(string audience, string baseUrl, string path) where T : Payload
        {
            if (Token.Split('.').Length != 3)
                throw new SecurityTokenDecryptionFailedException($"JWT must consist of Header, Payload, and Signature");

            if (Token.Length > MaxJwtLength)
                throw new SecurityTokenValidationException($"JWT exceeds maximum allowed length of {MaxJwtLength}");

            string[] parts = Token.Split('.');
            string encodedHeader = parts[0];
            string encodedPayload = parts[1];

            ValidateHeader(encodedHeader, baseUrl, path);

            return JsonConvert.SerializeObject(ValidatePayload<T>(encodedPayload, audience, baseUrl));
        }

        private void ValidateHeader(string encodedHeader, string baseUrl, string metadataUrl)
        {
            Header? header = JsonConvert.DeserializeObject<Header>(Base64UrlToString(encodedHeader));

            string metadataResponse = _httpClient.GetStringAsync(metadataUrl).Result;
            JObject? metadata = JObject.Parse(metadataResponse);

            string jwksUri = metadata["jwks_uri"].ToString();
            string response = _httpClient.GetStringAsync(jwksUri).Result;

            JsonWebKeySet jsonWebKeys = new JsonWebKeySet(response);
            IList<SecurityKey> signingKeys = jsonWebKeys.GetSigningKeys();

            var key = signingKeys.FirstOrDefault(k => k.KeyId == header?.Keys);
            if (key == null)
                throw new SecurityTokenInvalidSignatureException("Invalid token key");

            if (header?.Algorithim != SupportedJwtAlgorithm)
                throw new SecurityTokenInvalidAlgorithmException("Invalid token algorithm");

            if (header.Type != "JWT" && header.Type != null)
                throw new SecurityTokenInvalidTypeException("Invalid token type");
        }

        private T ValidatePayload<T>(string encodedPayload, string audience, string baseUrl) where T : Payload
        {
            var payload = JsonConvert.DeserializeObject<T>(Base64UrlToString(encodedPayload));

            if (payload == null)
                throw new SecurityTokenException("Invalid payload");

            if (payload.Audience != audience)
                throw new SecurityTokenInvalidAudienceException($"Invalid Audience {payload.Audience}");

            if (payload.Issuer != baseUrl.TrimEnd('/'))
                throw new SecurityTokenInvalidIssuerException($"Invalid Issuer {payload.Issuer}");

            DateTime expirationTime = DateTimeOffset.FromUnixTimeSeconds(long.Parse(payload.ExpiredAt)).UtcDateTime;
            if (expirationTime < DateTime.UtcNow)
                throw new SecurityTokenExpiredException("Token expired");

            return payload;
        }

        private string Base64UrlToString(string base64Url)
        {
            return Encoding.UTF8.GetString(Base64UrlDecode(base64Url));
        }

        private byte[] Base64UrlDecode(string base64Url)
        {
            string text = base64Url.Replace('-', '+').Replace('_', '/');
            switch (text.Length % 4)
            {
                case 2: text += "=="; break;
                case 3: text += "="; break;
            }
            return Convert.FromBase64String(text);
        }
    }

}
