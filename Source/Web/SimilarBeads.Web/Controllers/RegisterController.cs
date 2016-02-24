namespace SimilarBeads.Web.Controllers
{
    using System.Threading.Tasks;
    using System.Web.Mvc;

    using BaseControllers;
    using Common.Constants;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using ViewModels.Account;

    public class RegisterController : AccountBaseController
    {
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return this.View();
        }

        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var user = new User();
                if (model.IsArtist)
                {
                    user.IsArtist = true;
                }

                user.Name = model.Name;
                user.Email = model.Email;
                user.UserName = model.Email;
                var result = await this.UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    if (model.IsArtist)
                    {
                        this.UserManager.AddToRole(user.Id, GlobalRolesConstants.ArtistRoleName);
                        user.IsArtist = true;
                    }

                    await this.SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");
                    return this.RedirectToAction("Index", "Home");
                }

                this.AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return this.View(model);
        }
    }
}
