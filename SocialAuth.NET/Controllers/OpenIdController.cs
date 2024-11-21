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
        public async Task<IActionResult> MicrosoftAuth(string credential)
        {
            OpenIdConfiguration res = new OpenIdConfiguration(credential);
            //var result = res.googleIdConfiguration.ValidateGoogleToken("286600713169-1frq8hfoq4hsl1qm760f9v17u1bvh9fe.apps.googleusercontent.com");
            //var result = res.appleIdConfiguration.ValidateAppleToken("a");
            var result = res.microsoftIdConfiguration.ValidateMicrosoftToken("a62fb4cf-b78f-4fcd-9b0c-05944747f732", "9188040d-6c67-4c5b-b112-36a304b66dad");
            return Ok(result);
        }
    }
}
