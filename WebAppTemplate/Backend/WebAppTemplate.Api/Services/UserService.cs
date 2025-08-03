using WebAppTemplate.Api.Models;
using WebAppTemplate.Api.ViewModels;

namespace WebAppTemplate.Api.Services
{
    public class UserService : IUserService
    {
        private static readonly List<User> _users = new()
        {
            new User { Id = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", CreatedAt = DateTime.UtcNow.AddDays(-30), IsActive = true },
            new User { Id = 2, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", CreatedAt = DateTime.UtcNow.AddDays(-15), IsActive = true },
            new User { Id = 3, FirstName = "Bob", LastName = "Johnson", Email = "bob.johnson@example.com", CreatedAt = DateTime.UtcNow.AddDays(-7), IsActive = false }
        };

        public async Task<IEnumerable<UserViewModel>> GetAllUsersAsync()
        {
            await Task.Delay(10); // Simulate async operation
            return _users.Where(u => u.IsActive).Select(MapToViewModel);
        }

        public async Task<UserViewModel?> GetUserByIdAsync(int id)
        {
            await Task.Delay(10); // Simulate async operation
            var user = _users.FirstOrDefault(u => u.Id == id && u.IsActive);
            return user != null ? MapToViewModel(user) : null;
        }

        public async Task<UserViewModel> CreateUserAsync(CreateUserRequest request)
        {
            await Task.Delay(10); // Simulate async operation
            
            var user = new User
            {
                Id = _users.Max(u => u.Id) + 1,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                CreatedAt = DateTime.UtcNow,
                IsActive = true
            };

            _users.Add(user);
            return MapToViewModel(user);
        }

        public async Task<UserViewModel?> UpdateUserAsync(int id, UpdateUserRequest request)
        {
            await Task.Delay(10); // Simulate async operation
            
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null) return null;

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;
            user.IsActive = request.IsActive;
            user.UpdatedAt = DateTime.UtcNow;

            return MapToViewModel(user);
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            await Task.Delay(10); // Simulate async operation
            
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null) return false;

            user.IsActive = false; // Soft delete
            user.UpdatedAt = DateTime.UtcNow;
            return true;
        }

        private static UserViewModel MapToViewModel(User user)
        {
            return new UserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                CreatedAt = user.CreatedAt,
                IsActive = user.IsActive
            };
        }
    }
}