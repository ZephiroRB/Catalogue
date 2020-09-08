using Catalogue.Core.Entities;
using Catalogue.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalogue.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _repository;

        public UserService(IRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task addUser(User user)
        {
            await _repository.Add(user);
        }

        public async Task<bool> deleterUser(long id)
        {
            await _repository.Delete(id);

            return true;
        }

        public async Task<User> GetUser(long id)
        {
            return await _repository.GetById(id);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _repository.GetAll();
        }

        public async Task<bool> updateUser(User user)
        {
            await _repository.Update(user);
            return true;
        }
    }
}
