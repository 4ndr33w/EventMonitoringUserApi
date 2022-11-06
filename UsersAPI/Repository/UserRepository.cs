using WebSite.Models;

namespace UsersAPI.Models.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly RunDbContext _runDbContext; // new ();
        private IMapper _mapper;
        public UserRepository(AppDbContext dbContext, IMapper mapper, RunDbContext runDbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _runDbContext = runDbContext;
        }
        public async Task<UserProfileDto> CreateUpdateUser(UserProfileDto userDto)
        {
            UserProfile user = _mapper.Map<UserProfileDto, UserProfile>(userDto);
            if (user.Id > 0)
            {
                _dbContext.Users.Update(user);
            }
            else
            {
                _dbContext.Users.Add(user);
            }
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<UserProfile, UserProfileDto>(user);
        }

        public async Task<bool> DeleteUser(long telegramId)
        {
            try
            {
                UserProfile user = await _dbContext.Users.FirstOrDefaultAsync(u => u.TelegramId == telegramId);

                if (user == default) return false;
                if (_dbContext.Users.Remove(user).State == EntityState.Deleted)
                {
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<UserProfileDto>> GetUserAsync()
        {
            List<UserProfile> users = await _dbContext.Users.ToListAsync();
            //GetRunBackups();

            return _mapper.Map<List<UserProfileDto>>(users);
        }

        public async Task<UserProfileDto> GetUserByTelegramIdAsync(long telegramId)
        {
            UserProfile user = await _dbContext.Users.Where(u => u.TelegramId == telegramId).FirstOrDefaultAsync();
            return _mapper.Map<UserProfileDto>(user);
        }

        //public async void /*Task<IEnumerable<BackupResults>>*/ GetRunBackups()
        //{
        //    //if (_runDbContext.BackupResults.ToListAsync() != null)
        //    //{
        //    List<BackupResults> _runResults = new List<BackupResults>();
        //    _runResults =  _runDbContext.BackupResults.ToList(); // == null? default : await _runDbContext.BackupResults.ToListAsync();
        //    List<UserProfile> users = new List<UserProfile>();
        //    foreach (var item in _runResults)
        //    {
        //        UserProfile _user = new UserProfile();
        //        _user.TelegramId = item.Id;
        //        _user.Name = item.Name;
        //        _user.Region = "";
        //        _user.City = item.City;
        //        _user.Company = item.Company;
        //        _user.Age = item.Age;
        //        _user.Gender = item.Gender;
        //        _user.TotalResult = item.Result;
        //        _user.LastAddedResult = 0;
        //        _user.CreatedAt = item.CreatedAt;
        //        _user.UpdatedAt = item.UpdatedAt;


        //        _dbContext.Users.Add(new UserProfile(_user));
        //    }

        //     _dbContext.SaveChanges();
        //    //}

        //    //return
        //}
    }
}
