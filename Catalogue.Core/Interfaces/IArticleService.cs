using Catalogue.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalogue.Core.Interfaces
{
    public interface IArticleService
    {
        Task addArticle(Article Article);
        IEnumerable<Article> GetArticles();
        Task<Article> GetArticle(long id);
        Task<bool> updateArticle(Article Article);
        Task<bool> deleterArticle(long id);
    }
}
