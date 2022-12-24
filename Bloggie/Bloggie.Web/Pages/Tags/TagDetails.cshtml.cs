using Bloggie.Web.Models.Domain;
using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Tags
{
    public class TagDetailsModel : PageModel
    {
        private readonly IBlogPostRepository blogPostRepository;
        public List<BlogPost> Blogs { get; set; }

        public TagDetailsModel(IBlogPostRepository blogPostRepository)
        {
            this.blogPostRepository = blogPostRepository;
        }
        public async Task<IActionResult> OnGet(string tagName)
        {
            Blogs = (await blogPostRepository.GetAllAsync(tagName)).ToList();

            return Page();
        }
    }
}
