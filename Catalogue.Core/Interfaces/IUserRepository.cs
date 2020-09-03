using Catalogue.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Catalogue.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();

        Task<User> GetUser(long id);

        Task addUser(User user);

        Task<bool> updateUser(User user);

        Task<bool> deleterUser(long id);

    }
}
