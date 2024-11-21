using SocialAuth.NET.OpenID;

namespace SocialAuth.NET.AppleOpenID
{
    public interface IAppleIdConfiguration
    {
       object ValidateAppleToken(string audience);
    }
}
