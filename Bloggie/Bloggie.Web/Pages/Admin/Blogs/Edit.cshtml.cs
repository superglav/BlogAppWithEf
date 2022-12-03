using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Bloggie.Web.Models.ViewModels;
using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace Bloggie.Web.Pages.Admin.Blogs
{
    public class EditModel : PageModel
    {
        private readonly IBlogPostRepository blogPostRepository;
        [BindProperty]
        public string Tags { get; set; }

        [BindProperty]
        public BlogPost? BlogPost { get; set; }
        [BindProperty]
        public IFormFile FeaturedImage { get; set; }
        public EditModel(IBlogPostRepository blogPostRepository)
        {
            this.blogPostRepository = blogPostRepository;
        }
        public async Task OnGet(Guid id)
        {
           BlogPost =  await blogPostRepository.GetAsync(id);
            if (BlogPost != null && BlogPost.Tags != null)
            {
                Tags = string.Join(',', BlogPost.Tags.Select(x=> x.Name));
            }
            
        }


        public async Task<IActionResult> OnPostEdit()
        {
           
            try
            {
                BlogPost.Tags = new List<Tag>(Tags.Split(',').Select(x => new Tag() { Name = x.Trim() }));
                await blogPostRepository.UpdateAsync(BlogPost);

                var notification = new Notification
                {
                    Type = enums.NotificationType.Success,
                    Message = "Record updated successfully!"
                };
                TempData["Notification"] = JsonSerializer.Serialize(notification);

            }
            catch (Exception ex)
            {
                ViewData["Notification"] = new Notification
                {
                    Message = "There was an error",
                    Type = enums.NotificationType.Error
                };
                return Page();
            }
            
            return RedirectToPage("/Admin/Blogs/List");

            
            
        }

        
        public async Task<IActionResult> OnPostDelete()
        {
           var deleted =  await blogPostRepository.DeleteAsync(BlogPost.Id);
            if (deleted)
            {
                var notification = new Notification
                {
                    Type = enums.NotificationType.Success,
                    Message = "the blogpost has been deleted!"
                };
                TempData["Notification"] = JsonSerializer.Serialize(notification);

                return RedirectToPage("/Admin/Blogs/List");
            }
            
            return Page();
        }
    }
}
