using Bloggie.Web.Models.Domain;
using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Blog
{
    public class DetailsModel : PageModel
    {
        private readonly IBlogPostRepository blogPostRepository;
        [BindProperty]
        public BlogPost BlogPost { get; set; }
        public DetailsModel(IBlogPostRepository blogPostRepository)
        {
            this.blogPostRepository = blogPostRepository;
        }


        public async Task<IActionResult> OnGet(string urlHandle)
        {
           BlogPost =  await blogPostRepository.GetAsync(urlHandle);

            return Page();
        }

        public async Task<IActionResult> OnPost(string Name)
        {
            BlogPost = await blogPostRepository.GetAsync(Name);
            return RedirectToPage("/blog/blogtags/Name");
        }
    }
}
