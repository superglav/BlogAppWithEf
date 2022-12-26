using Bloggie.Web.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<IdentityUser> userManager;

        [BindProperty]
        public Register RegisterViewModel { get; set; }
        public RegisterModel(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            Notification obj = new Notification();
            obj.Messages = new List<string>();
            var user = new IdentityUser
            {
                UserName = RegisterViewModel.UserName,
                Email = RegisterViewModel.Email,
            };
            var identityResutl = await userManager.CreateAsync(user, RegisterViewModel.Password);

            if (identityResutl.Succeeded)
            {
                ViewData["Notification"] = new Notification
                {
                    Type = enums.NotificationType.Success,
                    Message = "user registered successfully."
                };

                return Page();
            }else
            {
                foreach (var item in identityResutl.Errors)
                {

                   obj.Messages.Add(item.Description);
                }
                ViewData["Notification"] = new Notification
                {

                    Type = enums.NotificationType.Error,
                    Messages = obj.Messages

                };

                return Page();
            }
        }

    }
}
