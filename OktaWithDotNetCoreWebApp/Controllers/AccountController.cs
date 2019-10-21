namespace OktaWithDotNetCoreWebApp.Controllers
{
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Mvc;

    using Okta.AspNetCore;

    /// <summary>
    /// The account controller.
    /// </summary>
    public class AccountController : Controller
    {
        /// <summary>
        /// The login.
        /// </summary>
        /// <returns>
        /// The <see cref="IActionResult"/>.
        /// </returns>
        public IActionResult Login()
        {
            if (!this.HttpContext.User.Identity.IsAuthenticated)
            {
                return this.Challenge(OktaDefaults.MvcAuthenticationScheme);
            }

            return this.RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// The logout.
        /// </summary>
        /// <returns>
        /// The <see cref="IActionResult"/>.
        /// </returns>
        [HttpPost]
        public IActionResult Logout()
        {
            return new SignOutResult(
                new[]
                    {
                        OktaDefaults.MvcAuthenticationScheme,
                                             CookieAuthenticationDefaults.AuthenticationScheme
                                         },
            new AuthenticationProperties { RedirectUri = "/Home/" });
        }
    }
}