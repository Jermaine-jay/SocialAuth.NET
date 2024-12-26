using SocialAuth.NET.OpenID;

namespace SocialAuth.NET.MicrosoftOpenID
{
    public interface IMicrosoftIdConfiguration
    {
        string ValidateMicrosoftToken(string audience, string tenant);
    }
}
