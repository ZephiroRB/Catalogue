
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
    public class ArticleRepository : IArticleRepository
    {
        private readonly CatalogueContext _context;

        public ArticleRepository(CatalogueContext context)
        {
             _context = context;

        }

        public async Task<IEnumerable<Article>> GetArticles()
        {
            var articles = await _context.Article.ToListAsync();

            return articles;
        }

        public async Task<Article> GetArticle(int id)
        {
            var article = await _context.Article.FirstOrDefaultAsync(x => x.Id == id);

            return article;
        }


    }
}
