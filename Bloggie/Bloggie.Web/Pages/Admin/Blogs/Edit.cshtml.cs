using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Admin.Blogs
{
    public class EditModel : PageModel
    {
        private readonly BloggieDbContext bloggieDbContext;
        [BindProperty]
        public BlogPost? BlogPost { get; set; }
        public EditModel(BloggieDbContext bloggieDbContext)
        {
            this.bloggieDbContext = bloggieDbContext;
        }
        public async Task OnGet(Guid id)
        {
           BlogPost =  await bloggieDbContext.BlogPosts.FindAsync(id);
            
        }


        public async Task<IActionResult> OnPostEdit()
        {
            var existingBlogPost = await bloggieDbContext.BlogPosts.FindAsync(BlogPost.Id);

            if (existingBlogPost != null)
            {
                existingBlogPost.Heading = BlogPost.Heading;
                existingBlogPost.PageTitle = BlogPost.PageTitle;
                existingBlogPost.Content = BlogPost.Content;
                existingBlogPost.ShortDescription = BlogPost.ShortDescription;
                existingBlogPost.FeaturedImageUrl = BlogPost.FeaturedImageUrl;
                existingBlogPost.UrlHandle = BlogPost.UrlHandle;
                existingBlogPost.PublishDate = BlogPost.PublishDate;
                existingBlogPost.Author = BlogPost.Author;
                existingBlogPost.Visible = BlogPost.Visible;
            }
            
            
            await bloggieDbContext.SaveChangesAsync();

            return RedirectToPage("/Admin/Blogs/List");
        }


        public async Task<IActionResult> OnPostDelete()
        {
            var existingBlogPost = bloggieDbContext.BlogPosts.Find(BlogPost.Id);

            if (existingBlogPost != null)
            {
                bloggieDbContext.BlogPosts.Remove(existingBlogPost);
                await bloggieDbContext.SaveChangesAsync();

            return RedirectToPage("Admin/Blogs/List");
            }
            return Page();
        }
    }
}
