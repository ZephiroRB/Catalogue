using Catalogue.Core.Entities;
using Catalogue.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalogue.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> GetUser(long id)
        {
            return await _unitOfWork.UserRepository.GetById(id);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _unitOfWork.UserRepository.GetAll();
        }

        public async Task addUser(User user)
        {
            await _unitOfWork.UserRepository.Add(user);
        }

        public async Task<bool> deleterUser(long id)
        {
            await _unitOfWork.UserRepository.Delete(id);
            return true;
        }

        public async Task<bool> updateUser(User user)
        {
            await _unitOfWork.UserRepository.Update(user);
            return true;
        }
    }
}
