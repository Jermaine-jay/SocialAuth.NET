namespace SocialAuth.NET.GoogleOpenID
{
    public interface IGoogleIdConfiguration
    {
        string ValidateGoogleToken(string audience);
    }
}