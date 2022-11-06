using WebSite.Models;

namespace UsersAPI.Models.Repository
{
    public interface IUserRepository
    {
        public Task<IEnumerable<UserProfileDto>> GetUserAsync();
        public Task<UserProfileDto> GetUserByTelegramIdAsync(long telegramId);
        public Task<UserProfileDto> CreateUpdateUser(UserProfileDto userDto);
        public Task<bool> DeleteUser(long telegramId);
    }
}
