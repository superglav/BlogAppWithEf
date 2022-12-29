using Bloggie.Web.Data;
using Bloggie.Web.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.Pages
{
    public class loginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly AuthDbContext authDbContext;

        [BindProperty]
        public Login LoginViewModel { get; set; }

        public loginModel(SignInManager<IdentityUser> signInManager, AuthDbContext authDbContext)
        {
            this.signInManager = signInManager;
            this.authDbContext = authDbContext;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(string ReturnUrl)
        {
            //IdentityUser retrievedUser = await authDbContext.Users.FirstOrDefaultAsync(u => u.UserName == "Superadmin@bloggie.com");
            //PasswordHasher <IdentityUser> passwordHasher = new PasswordHasher<IdentityUser>();
            //string enteredPassword = "superAdmin123";
            //// Verify the entered password
            //PasswordVerificationResult result = passwordHasher.VerifyHashedPassword(retrievedUser, retrievedUser.PasswordHash, enteredPassword);

            var signInResult = await signInManager.PasswordSignInAsync
                (LoginViewModel.UserName, LoginViewModel.Password, false, true);

            if (signInResult.Succeeded)
            {
                if (!string.IsNullOrEmpty(ReturnUrl))
                {
                    return RedirectToPage(ReturnUrl);
                }
                return RedirectToPage("Index");
            }
            else
            {
                ViewData["Notification"] = new Notification
                {
                    Type = enums.NotificationType.Error,
                    Message = "Unable to log in"
                };

                return Page();
            }
        }
    }
}
