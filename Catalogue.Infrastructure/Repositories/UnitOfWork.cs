using Catalogue.Core.Entities;
using Catalogue.Core.Interfaces;
using Catalogue.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Catalogue.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CatalogueContext _context;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Article> _articleRepository;

        public UnitOfWork(CatalogueContext context)
        {
            _context = context;
        }

        public IRepository<User> UserRepository => _userRepository ?? new BaseRepository<User>(_context);

        public IRepository<Article> ArticleRepository => _articleRepository ?? new BaseRepository<Article>(_context);

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}