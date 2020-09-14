using Catalogue.Core.Entities;
using System;
using System.Threading.Tasks;

namespace Catalogue.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> UserRepository { get; }

        IArticleRepository ArticleRepository { get; }

        void SaveChanges();

        Task SaveChangesAsync();
    }
}
