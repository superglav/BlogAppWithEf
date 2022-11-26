using Bloggie.Web.Models.Domain;
using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Blog
{
    public class DetailsModel : PageModel
    {
        private readonly IBlogPostRepository blogPostRepository;
        public BlogPost BlogpPost { get; set; }
        public DetailsModel(IBlogPostRepository blogPostRepository)
        {
            this.blogPostRepository = blogPostRepository;
        }


        public async Task<IActionResult> OnGet(string urlHandle)
        {
           BlogpPost =  await blogPostRepository.GetAsync(urlHandle);

            return Page();
        }
    }
}
