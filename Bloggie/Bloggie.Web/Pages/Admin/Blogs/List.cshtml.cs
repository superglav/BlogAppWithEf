using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Bloggie.Web.Pages.Admin.Blogs
{
    public class ListModel : PageModel
    {
        private readonly BloggieDbContext bloggieDbContext;

        public List<BlogPost> BlogPosts { get; set; }
        [BindProperty]
        public BlogPost BlogPost { get; set; }
        public ListModel(BloggieDbContext bloggieDbContext)
        {
            this.bloggieDbContext = bloggieDbContext;
        }
        public async Task OnGet()
        {
            BlogPosts = await bloggieDbContext.BlogPosts.ToListAsync();
        }
        public async Task<IActionResult> OnPostDelete()
        {   
            
            var existingBlogPost = bloggieDbContext.BlogPosts.Find(BlogPost.Id);
            if (existingBlogPost != null)
            {
                bloggieDbContext.BlogPosts.Remove(existingBlogPost);
                await bloggieDbContext.SaveChangesAsync();
                return RedirectToPage("/Admin/Blogs/List");
            }
            return Page();
        }
       

}
}
