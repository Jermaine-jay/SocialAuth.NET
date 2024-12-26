using SocialAuth.NET.OpenID;

namespace SocialAuth.NET.AppleOpenID
{
    public interface IAppleIdConfiguration
    {
       string ValidateAppleToken(string audience);
    }
}
