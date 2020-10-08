using Catalogue.Core.Entities;
using Catalogue.Core.Exceptions;
using Catalogue.Core.Interfaces;
using Catalogue.Core.QueryFilters;
using Catalogue.Core.CustomEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogue.Core.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ArticleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Article> GetArticle(long id)
        {
            return await _unitOfWork.ArticleRepository.GetById(id);
        }
        public PagedList<Article> GetArticles(ArticleQueryFilter filters)
        {
            var articles = _unitOfWork.ArticleRepository.GetAll();

            if (filters.UserId != null)
            {
                articles = articles.Where(x => x.UserId == filters.UserId);
            }

            if (filters.CreatedAt != null)
            {
                articles = articles.Where(x => x.CreatedAt.ToShortDateString() == filters.CreatedAt?.ToShortDateString());
            }

            if (filters.Description != null)
            {
                articles = articles.Where(x => x.Description.ToLower().Contains(filters.Description.ToLower()));
            }
            
            var pagedArticles = PagedList<Article>.Create(articles, filters.PageNumber, filters.PageSize);

            return pagedArticles;
        }

        public async Task addArticle(Article article)
        {
            /*var user = await _unitOfWork.UserRepository.GetById(article.UserId);

            if (user == null)
            {
                throw new BusinessException("User doesn't  exist");
            }

            var userArticles = await _unitOfWork.ArticleRepository.GetArticlesByUser(article.UserId);

            if (userArticles.Count() < 10 && userArticles.Count() > 0)
            {
                var lastArticle = userArticles.OrderByDescending(x=> x.CreatedAt).LastOrDefault();

                if ((DateTime.Now - lastArticle.CreatedAt).TotalDays < 7)
                {
                    throw new BusinessException("You are not able to publish the post");
                }
            }

            if (article.Description.Contains("Sexo"))
            {
                throw new BusinessException("Content not allowed");
            }*/

            char[] padding = { '=' };

            string token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());

            article.Token = token.TrimEnd(padding).Replace('+', '-').Replace('/', '_');

            article.CreatedAt = DateTime.Now;
            article.UpdatedAt = DateTime.Now;

            await _unitOfWork.ArticleRepository.Add(article);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> deleterArticle(long id)
        {
            await _unitOfWork.ArticleRepository.Delete(id);
            return true;
        }

        public async Task<bool> updateArticle(Article article)
        {
            article.UpdatedAt = DateTime.Now;
            _unitOfWork.ArticleRepository.Update(article);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
