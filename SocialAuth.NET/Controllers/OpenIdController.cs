using Microsoft.AspNetCore.Mvc;
using SocialAuth.NET.OpenID;

namespace SocialAuth.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenIdController : ControllerBase
    {
        public OpenIdController() { }

        [HttpPost("google-openId-auth")]
        public async Task<IActionResult> GoogleOpenIdAuth(string token)
        {
            OpenIdConfiguration openIdConfiguration = new OpenIdConfiguration(token);
            string googleUser = openIdConfiguration.googleIdConfiguration.ValidateGoogleToken("your-app-audience");
            
            return Ok(googleUser);
        }

        [HttpPost("microsoft-openId-auth")]
        public async Task<IActionResult> MicrosoftOpenIdAuth(string token)
        {
            OpenIdConfiguration openIdConfiguration = new OpenIdConfiguration(token);
            string microsoftUser = openIdConfiguration.microsoftIdConfiguration.ValidateMicrosoftToken("your-app-audience", "your-app-tenantid");

            return Ok(microsoftUser);
        }

        [HttpPost("apple-openId-auth")]
        public async Task<IActionResult> AppleOpenIdAuth(string token)
        {
            OpenIdConfiguration openIdConfiguration = new OpenIdConfiguration(token);
            string appleUser = openIdConfiguration.appleIdConfiguration.ValidateAppleToken("your-app-audience");

            return Ok(appleUser);
        }

        [HttpPost("facebook-openId-auth")]
        public async Task<IActionResult> FacebookOpenIdAuth(string token)
        {
            OpenIdConfiguration openIdConfiguration = new OpenIdConfiguration(token);
            Payload fecebookUser = openIdConfiguration.facebookIdConfiguration.ValidateFacebookToken("your-app-id", "your-app-secet");
            return Ok(fecebookUser);
        }
    }
}
