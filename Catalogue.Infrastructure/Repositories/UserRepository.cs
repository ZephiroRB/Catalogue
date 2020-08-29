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

        public async Task<User> GetUser(int id)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.Id == id);

            return user;
        }

    }
}
