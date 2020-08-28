using Catalogue.Core.Entities;
using Catalogue.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Catalogue.Infrastructure.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        public Task<IEnumerable<Article>> GetArticles()
        {
            throw new NotImplementedException();
        }
    }
}
