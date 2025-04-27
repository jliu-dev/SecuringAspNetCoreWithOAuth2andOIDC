using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ImageGallery.Client.Controllers
{
    public class AuthenticationController : Controller
    {
        [Authorize]
        public async Task Logout()
        {
            //clears the local authentication cookie
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);
            //redirects to the IdentityServer logout endpoint   
            await HttpContext.SignOutAsync(
           OpenIdConnectDefaults.AuthenticationScheme);

        //    await HttpContext.SignOutAsync(
        //        "oidc", // the scheme name for OpenID Connect
        //        new AuthenticationProperties
        //        {
        //            RedirectUri = "/Authentication/LoggedOut" // where to redirect after logout
        //        });

        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
