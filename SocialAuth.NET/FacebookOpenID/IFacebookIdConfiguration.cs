using SocialAuth.NET.OpenID;

namespace SocialAuth.NET.FacebookOpenID
{
    public interface IFacebookIdConfiguration
    {
        Payload ValidateFacebookToken(string appId, string appSecret);
    }
}