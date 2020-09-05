
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

        public async Task<Article> GetArticle(long id)
        {
            var article = await _context.Article.FirstOrDefaultAsync(x => x.Id == id);

            return article;
        }

        public async Task addArticle(Article article)
        {
            _context.Article.Add(article);
            await _context.SaveChangesAsync();
        }


        public async Task<bool> updateArticle(Article article)
        {
            var currentArticle = await GetArticle(article.Id);

            currentArticle.Title = article.Title;
            currentArticle.Description = article.Description;
            currentArticle.UserId = article.UserId;


            int rowsAffected = await _context.SaveChangesAsync();

            return rowsAffected > 0;
        }

        public async Task<bool> deleterArticle(long id)
        {
            var currentArticle = await GetArticle(id);

            _context.Article.Remove(currentArticle);

            int rowsAffected = await _context.SaveChangesAsync();

            return rowsAffected > 0;
        }
    }
}
