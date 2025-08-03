using WebAppTemplate.Api.Models;
using WebAppTemplate.Api.ViewModels;

namespace WebAppTemplate.Api.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserViewModel>> GetAllUsersAsync();
        Task<UserViewModel?> GetUserByIdAsync(int id);
        Task<UserViewModel> CreateUserAsync(CreateUserRequest request);
        Task<UserViewModel?> UpdateUserAsync(int id, UpdateUserRequest request);
        Task<bool> DeleteUserAsync(int id);
    }
}