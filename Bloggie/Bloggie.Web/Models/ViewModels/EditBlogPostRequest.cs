using System.ComponentModel.DataAnnotations;

namespace Bloggie.Web.Models.ViewModels
{
    public class EditBlogPostRequest
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Heading { get; set; }
        [Required]
        public string PageTitle { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public string FeaturedImageUrl { get; set; }
        [Required]
        public string ShortDescription { get; set; }
        [Required]
        public string UrlHandle { get; set; }
        [Required]
        public DateTime PublishDate
        {
            get
            {
                return this.publishDate.HasValue
                   ? this.publishDate.Value
                   : DateTime.Now;
            }

            set { this.publishDate = value; }
        }
        [Required]
        private DateTime? publishDate = null;
        [Required]
        public string Author { get; set; }
        public bool Visible { get; set; }
    }
}
