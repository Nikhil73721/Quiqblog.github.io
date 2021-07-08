using QuiqBlog.Data.Models;

using System.Security.Claims;
using System.Threading.Tasks;

namespace QuiqBlog.Service.Interfaces
{
    public interface IUserService
    {
        ApplicationUser Get(string id);
        Task<ApplicationUser> Update(ApplicationUser applicationUser);
    }
}
