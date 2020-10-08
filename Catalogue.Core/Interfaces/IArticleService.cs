using Catalogue.Core.CustomEntities;
using Catalogue.Core.Entities;
using Catalogue.Core.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalogue.Core.Interfaces
{
    public interface IArticleService
    {
        Task addArticle(Article article);
        PagedList<Article> GetArticles(ArticleQueryFilter filters);
        Task<Article> GetArticle(long id);
        Task<bool> updateArticle(Article article);
        Task<bool> deleterArticle(long id);
    }
}
