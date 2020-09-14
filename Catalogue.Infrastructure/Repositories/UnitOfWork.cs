using Catalogue.Core.Entities;
using Catalogue.Core.Interfaces;
using Catalogue.Infrastructure.Data;
using System.Threading.Tasks;

namespace Catalogue.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CatalogueContext _context;
        private readonly IRepository<User> _userRepository;
        private readonly IArticleRepository _articleRepository;

        public UnitOfWork(CatalogueContext context)
        {
            _context = context;
        }

        public IArticleRepository ArticleRepository => _articleRepository ?? new ArticleRepository(_context);

        public IRepository<User> UserRepository => _userRepository ?? new BaseRepository<User>(_context);

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