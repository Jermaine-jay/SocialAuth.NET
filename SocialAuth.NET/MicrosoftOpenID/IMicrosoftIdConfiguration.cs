using SocialAuth.NET.OpenID;

namespace SocialAuth.NET.MicrosoftOpenID
{
    public interface IMicrosoftIdConfiguration
    {
        object ValidateMicrosoftToken(string audience, string tenant);
    }
}
