using Bloggie.Web.Models.ViewModels;
using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Admin.Users
{
    [Authorize (Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IUserRepository userRepository;
        public List<User> Users { get; set; }
        [BindProperty]
        public AddUser AddUserrequest { get; set; }
        [BindProperty]
        public Guid SelectedUserId { get; set; }

        public IndexModel(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task<IActionResult> OnGet()
        {
            var users = await userRepository.GetAll();

            Users = new List<User>();
            foreach (var user in users)
            {
                Users.Add(new User()
                {
                    Id = Guid.Parse(user.Id),
                    UseerName = user.UserName,
                    Email = user.Email
                });
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var identityUser = new IdentityUser()
            {
                UserName = AddUserrequest.UserName,
                Email = AddUserrequest.Email
            };

            var roles = new List<string> { "User" };
            if (AddUserrequest.AdminCheckBox)
            {
                roles.Add("Admin");
            }
            var result = await userRepository.Add(identityUser, AddUserrequest.Password, roles);

            if(result)
            {
                return RedirectToPage("/Admin/Users/index");
            }
            return Page();
        }
        public async Task<IActionResult> OnPostDelete()
        {
            await userRepository.Delete(SelectedUserId);
            return RedirectToPage("/Admin/Users/index");
        }
    }
}
