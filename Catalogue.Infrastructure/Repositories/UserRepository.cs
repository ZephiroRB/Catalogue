using Catalogue.Core.Entities;
using Catalogue.Core.Interfaces;
using Catalogue.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Catalogue.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CatalogueContext _context;

        public UserRepository(CatalogueContext context)
        {
            _context = context;

        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _context.User.ToListAsync();

            return users;
        }

        public async Task<User> GetUser(long id)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.Id == id);

            return user;
        }

        public async Task addUser(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> updateUser(User user)
        {
            var currentUser = await GetUser(user.Id);

            currentUser.Username = user.Username;
            currentUser.Password = user.Password;

            int rowsAffected = await _context.SaveChangesAsync();

            return rowsAffected > 0;
        }

        public async Task<bool> deleterUser(long id)
        {
            var currentUser = await GetUser(id);

            _context.User.Remove(currentUser);

            int rowsAffected = await _context.SaveChangesAsync();

            return rowsAffected > 0;
        }



    }
}
