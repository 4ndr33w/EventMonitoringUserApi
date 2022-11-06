using Microsoft.AspNetCore.Mvc;
using System;
using WebSite.Models;

namespace UsersAPI.Controllers
{
    [Route("api/users")]
    public class UserAPI : ControllerBase
    {
        protected ResponseDto _response;
        private IUserRepository _userRepository;

        public UserAPI(IUserRepository repository)
        {
            _userRepository = repository;
            _response = new ResponseDto();
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<UserProfileDto> users = (IEnumerable<UserProfileDto>)await _userRepository.GetUserAsync();
                _response.Result = users;
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { e.ToString() };
            }
            return _response;
        }

        [HttpGet]
        [Route("telegramId")]
        public async Task<object> Get (long telegramId)
        {
            try
            {
                UserProfileDto user = await _userRepository.GetUserByTelegramIdAsync(telegramId);
                _response.Result = user;
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { e.ToString() };
            }
            return _response;
        }

        [HttpPost]
        public async Task<object> Post([FromBody] UserProfileDto userDto )
        {
            try
            {
                UserProfileDto user = await _userRepository.CreateUpdateUser(userDto);
                _response.Result = user;
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { e.ToString() };
            }
            return _response;
        }

        [HttpPut]
        public async Task<object> Put([FromBody] UserProfileDto userDto)
        {
            try
            {
                UserProfileDto user = await _userRepository.CreateUpdateUser(userDto);
                _response.Result = user;
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { e.ToString() };
            }
            return _response;
        }

        [HttpDelete]
        [Route("telegramId")]
        public async Task<object> Delete(long telegramId)
        {
            try
            {
                bool isSuccess = await _userRepository.DeleteUser(telegramId);
                _response.IsSuccess = isSuccess;
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { e.ToString() };
            }
            return _response;
        }

    }
}
