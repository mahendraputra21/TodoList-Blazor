using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TodoList.Server.TodoList.Models;

namespace TodoList.Server.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AccountController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("facebook-signin")]
        public IActionResult FacebookSignin()
        {

            var redirectUri = _configuration["FBRedirectUrl"];
            if (string.IsNullOrEmpty(redirectUri))
                return BadRequest("Facebook redirect URL is not configured.");

            var properties = new AuthenticationProperties { RedirectUri = redirectUri };
            return Challenge(properties, FacebookDefaults.AuthenticationScheme);
        }

        [HttpGet("facebook-response")]
        public async Task<IActionResult> FacebookResponse()
        {
            var result = await HttpContext.AuthenticateAsync(FacebookDefaults.AuthenticationScheme);

            if (!result.Succeeded)
                return BadRequest("Facebook authentication failed");

            var facebookId = result.Principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var email = result.Principal.FindFirst(ClaimTypes.Email)?.Value;
            var name = result.Principal.FindFirst(ClaimTypes.Name)?.Value;

            var response = new FacebookResponse(
               "Authentication successful",
               facebookId ?? "",
               email ?? "",
               name ?? ""
           );

            return Ok(response);
        }
    }
}
