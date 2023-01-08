using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Bloggie.Web.Models.ViewModels;
using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace Bloggie.Web.Pages.Admin.Blogs
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly IBlogPostRepository blogPostRepository;
        public EditModel(IBlogPostRepository blogPostRepository)
        {
            this.blogPostRepository = blogPostRepository;
        }

        [BindProperty]
        public IFormFile? FeaturedImage { get; set; }

        [BindProperty]
        [Required]
        public string Tags { get; set; }

        [BindProperty]
        public EditBlogPostRequest BlogPost { get; set; }
        
        public async Task OnGet(Guid id)
        {
           var blogPostDomainModel =  await blogPostRepository.GetAsync(id);
            if( blogPostDomainModel != null && blogPostDomainModel.Tags != null)
            {
                BlogPost = new EditBlogPostRequest
                {
                    Id = blogPostDomainModel.Id,
                    Heading = blogPostDomainModel.Heading,
                    PageTitle = blogPostDomainModel.PageTitle,
                    Content = blogPostDomainModel.Content,
                    ShortDescription = blogPostDomainModel.ShortDescription,
                    FeaturedImageUrl = blogPostDomainModel.FeaturedImageUrl,
                    UrlHandle = blogPostDomainModel.UrlHandle,
                    PublishDate = blogPostDomainModel.PublishDate,
                    Author = blogPostDomainModel.Author,
                    Visible = blogPostDomainModel.Visible

                };
                Tags = String.Join(',', blogPostDomainModel.Tags.Select(x => x.Name));
            }
            
        }


        public async Task<IActionResult> OnPostEdit()
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var blogPostDomainModel = new BlogPost
                    {
                        Id = BlogPost.Id,
                        Heading = BlogPost.Heading,
                        PageTitle = BlogPost.PageTitle,
                        Content = BlogPost.Content,
                        ShortDescription = BlogPost.ShortDescription,
                        FeaturedImageUrl = BlogPost.FeaturedImageUrl,
                        UrlHandle = BlogPost.UrlHandle,
                        PublishDate = BlogPost.PublishDate,
                        Author = BlogPost.Author,
                        Visible = BlogPost.Visible,
                        Tags = new List<Tag>(Tags.Split(',').Select(x => new Tag() { Name = x.Trim() }))
                    };

                    await blogPostRepository.UpdateAsync(blogPostDomainModel);

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
            return Page();

            
            
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
