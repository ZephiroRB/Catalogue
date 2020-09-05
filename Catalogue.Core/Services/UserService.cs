using Catalogue.Core.Entities;
using Catalogue.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalogue.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task addUser(User user)
        {
            await _userRepository.addUser(user);
        }

        public async Task<bool> deleterUser(long id)
        {
            return await _userRepository.deleterUser(id);
        }

        public async Task<User> GetUser(long id)
        {
            return await _userRepository.GetUser(id);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _userRepository.GetUsers();
        }

        public async Task<bool> updateUser(User user)
        {
            return await _userRepository.updateUser(user);
        }
    }
}
