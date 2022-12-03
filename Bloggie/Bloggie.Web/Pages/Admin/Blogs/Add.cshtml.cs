using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Bloggie.Web.Models.ViewModels;
using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Server.IIS.Core;
using System.Text.Json;

namespace Bloggie.Web.Pages.Admin.Blogs
{
    public class AddModel : PageModel
    {
        public String errorMessage = "";
        private IBlogPostRepository blogPostRepository;

        [BindProperty]
        public string Tags { get; set; }
        [BindProperty]
        public AddBlogPost AddBlogPostRequest { get; set; }
        [BindProperty]
        public IFormFile FeaturedImage { get; set; }
        public AddModel(IBlogPostRepository blogPostRepository)
        {
            this.blogPostRepository = blogPostRepository;
        }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {

            try
            {
                if (AddBlogPostRequest.Heading.Length != 0 || AddBlogPostRequest.PageTitle.Length != 0 || AddBlogPostRequest.Content.Length != 0
                    || AddBlogPostRequest.ShortDescription.Length != 0 || AddBlogPostRequest.FeaturedImageUrl.Length != 0 || AddBlogPostRequest.UrlHandle.Length != 0
                     || AddBlogPostRequest.Author.Length != 0 )
                {
                    var time = AddBlogPostRequest.PublishDate;
                    if (time == null)
                    {
                        time = DateTime.Now;
                    }
                    var blogPost = new BlogPost
                    {
                        Heading = AddBlogPostRequest.Heading,
                        PageTitle = AddBlogPostRequest.PageTitle,
                        Content = AddBlogPostRequest.Content,
                        ShortDescription = AddBlogPostRequest.ShortDescription,
                        FeaturedImageUrl = AddBlogPostRequest.FeaturedImageUrl,
                        UrlHandle = AddBlogPostRequest.UrlHandle,
                        PublishDate = (DateTime)time,
                        Author = AddBlogPostRequest.Author,
                        Visible = AddBlogPostRequest.Visible,
                        Tags = new List<Tag>(Tags.Split(',').Select(x => new Tag() { Name = x.Trim() }))

                    };

                   await blogPostRepository.AddAsync(blogPost);

                    var notification = new Notification
                    {
                        Type = enums.NotificationType.Success,
                        Message = "New Blog Created!"
                    };
                    TempData["Notification"] = JsonSerializer.Serialize(notification);
                }
            }
            catch (Exception)
            {

                errorMessage = "All the fields are required";
                return Page();
            }
                
                    
            return Redirect("/Admin/Blogs/List");
        }
    }
 }
            
            

        
    

