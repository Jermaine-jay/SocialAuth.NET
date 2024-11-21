using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialAuth.NET.GoogleOpenID;
using SocialAuth.NET.OpenID;

namespace SocialAuth.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenIdController : ControllerBase
    {
        public OpenIdController() { }

        [HttpPost("microsoft-login")]
        public async Task<IActionResult> MicrosoftAuth(string token)
        {
            OpenIdConfiguration res = new OpenIdConfiguration(token);
            //var result = res.googleIdConfiguration.ValidateGoogleToken("b");
            //var result = res.appleIdConfiguration.ValidateAppleToken("a");
            var result = res.microsoftIdConfiguration.ValidateMicrosoftToken("c", "d");
            return Ok(result);
        }
    }
}
