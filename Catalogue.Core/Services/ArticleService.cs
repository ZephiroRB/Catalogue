using Catalogue.Core.Entities;
using Catalogue.Core.Interfaces;
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

        public IEnumerable<Article> GetArticles()
        {
            return _unitOfWork.ArticleRepository.GetAll();
        }

        public async Task addArticle(Article article)
        {
            var user = _unitOfWork.UserRepository.GetById(article.UserId);

            if (user == null)
            {
                throw new Exception("User doesn't  exist");
            }

            var userArticles = await _unitOfWork.ArticleRepository.GetArticlesByUser(article.UserId);

            if (userArticles.Count() < 10)
            {
                var lastArticle = userArticles.LastOrDefault();

                if ((lastArticle.CreatedAt - DateTime.Now).TotalDays < 7)
                {
                    throw new Exception("You are not able to publish the post");
                }
            }

            if (article.Description.Contains("Sexo"))
            {
                throw new Exception("Content not allowed");
            }

            await _unitOfWork.ArticleRepository.Add(article);
        }

        public async Task<bool> deleterArticle(long id)
        {
            await _unitOfWork.ArticleRepository.Delete(id);
            return true;
        }

        public async Task<bool> updateArticle(Article article)
        {
            _unitOfWork.ArticleRepository.Update(article);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
