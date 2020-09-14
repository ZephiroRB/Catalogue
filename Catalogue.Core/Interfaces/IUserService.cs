using Catalogue.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalogue.Core.Interfaces
{
    public interface IUserService
    {
        Task addUser(User user);
        IEnumerable<User> GetUsers();
        Task<User> GetUser(long id);
        Task<bool> updateUser(User user);
        Task<bool> deleterUser(long id);

    }
}