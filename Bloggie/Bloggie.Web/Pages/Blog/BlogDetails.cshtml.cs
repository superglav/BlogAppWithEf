using Bloggie.Web.Models.Domain;
using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Blog
{
    public class BlogDetailsModel : PageModel
    {
        private readonly IBlogPostRepository blogPostRepository;
        private readonly IBlogPostLikeRepository blogPostLikeRepository;

        [BindProperty]
        public BlogPost BlogPost { get; set; }
        public int TotalLikes { get; set; }
        public BlogDetailsModel(IBlogPostRepository blogPostRepository,IBlogPostLikeRepository blogPostLikeRepository)
        {
            this.blogPostRepository = blogPostRepository;
            this.blogPostLikeRepository = blogPostLikeRepository;
        }


        public async Task<IActionResult> OnGet(string urlHandle)
        {
           BlogPost =  await blogPostRepository.GetAsync(urlHandle);
           if(BlogPost != null)
            {
                TotalLikes =  await blogPostLikeRepository.GetTotalLikesForBlog(BlogPost.Id);
            }
            return Page();
        }

        public async Task<IActionResult> OnPost(string Name)
        {
            BlogPost = await blogPostRepository.GetAsync(Name);
            return RedirectToPage("/blog/blogtags/Name");
        }
    }
}
