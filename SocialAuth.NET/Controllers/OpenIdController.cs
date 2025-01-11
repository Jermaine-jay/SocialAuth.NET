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
            string microsoftUser = res.microsoftIdConfiguration.ValidateMicrosoftToken("a62fb4cf-b78f-4fcd-9b0c-05944747f732", "9188040d-6c67-4c5b-b112-36a304b66dad");

            //string googleUser = res.googleIdConfiguration.ValidateGoogleToken("286600713169-1frq8hfoq4hsl1qm760f9v17u1bvh9fe.apps.googleusercontent.com");
            //string appleUser = res.appleIdConfiguration.ValidateAppleToken("your-app-audience");
            //string fecebookUser = res.facebookIdConfiguration.ValidateFacebookToken("your-app-id", "your-app-secet");
            return Ok(microsoftUser);
        }
    }
}
