namespace SocialAuth.NET.GoogleOpenID
{
    public interface IGoogleIdConfiguration
    {
        object ValidateGoogleToken(string audience);
    }
}