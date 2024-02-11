using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MovieAppFrontend.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        public IActionResult Index()            
        {
            return View();
        }

        public IActionResult SignInWithGoogle()
        {
            var properties = new AuthenticationProperties
            {
                RedirectUri = Url.Action(nameof(GoogleResponse), "Account")
            };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

    
        public async Task<IActionResult> GoogleResponse() 
        {
            var authResult = await HttpContext.AuthenticateAsync();

            if (authResult.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Error", "Account");
            }
        }

        public IActionResult Error()
        {
            return View();
        }

    }
}
