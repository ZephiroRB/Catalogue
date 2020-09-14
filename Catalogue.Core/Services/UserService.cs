using Catalogue.Core.Entities;
using Catalogue.Core.Interfaces;
using System;
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

        public IEnumerable<User> GetUsers()
        {
            return _unitOfWork.UserRepository.GetAll();
        }

        public async Task addUser(User user)
        {
            char[] padding = { '=' };

            string token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());

            user.Token = token.TrimEnd(padding).Replace('+', '-').Replace('/', '_');

            user.CreatedAt = DateTime.Now;
            user.UpdatedAt = DateTime.Now;

            await _unitOfWork.UserRepository.Add(user);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> deleterUser(long id)
        {
            await _unitOfWork.UserRepository.Delete(id);
            return true;
        }

        public async Task<bool> updateUser(User user)
        {
            user.UpdatedAt = DateTime.Now;
            _unitOfWork.UserRepository.Update(user);
            await  _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
