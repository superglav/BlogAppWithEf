using Bloggie.Web.Models.Domain;

namespace Bloggie.Web.Repositories
{
    public interface IBlogPostRepository
    {
        Task<IEnumerable<BlogPost>> GetAllAsync();
        Task<IEnumerable<BlogPost>> GetAllAsync(string tagName);
        Task<BlogPost> GetAsync(Guid id);
        Task<bool> DeleteAsync(Guid id);
        Task<BlogPost> UpdateAsync(BlogPost blogPost);
        Task<BlogPost> AddAsync(BlogPost blogPost);
        Task<BlogPost> GetAsync(string urlHandle);
    }
}
