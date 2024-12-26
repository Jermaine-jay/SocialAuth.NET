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

        [HttpPost("openId-auth")]
        public async Task<IActionResult> OpenIdAuth(string token)
        {
            OpenIdConfiguration res = new OpenIdConfiguration(token);
            string googleUser = res.googleIdConfiguration.ValidateGoogleToken("your app-audience");
            string appleUser = res.appleIdConfiguration.ValidateAppleToken("your-app-audience");
            string microsoftUser = res.microsoftIdConfiguration.ValidateMicrosoftToken("your-app-audience", "your-app-tenantid");
            return Ok();
        }
    }
}
