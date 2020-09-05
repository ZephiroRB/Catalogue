using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Catalogue.Core.DTOs;
using Catalogue.Core.Entities;
using Catalogue.Core.Interfaces;
using Catalogue.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalogue.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleRepository _ArticleRepository;
        private readonly IMapper _mapper;

        public ArticlesController(IArticleRepository ArticleRepository, IMapper mapper)
        {
            _ArticleRepository = ArticleRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetArticles()
        {
            var Articles = await _ArticleRepository.GetArticles();

            /* With AutoMapper*/
            var ArticlesDTO = _mapper.Map<IEnumerable<ArticleDTO>>(Articles);

            /*
            without AutoMapper
            var ArticlesDTO = Articles.Select(a => new ArticleDTO
            {
                Id = a.Id,
                Articlename = a.Title,
                Token = u.Token,
                Description = u.Description
            });*/

            return Ok(ArticlesDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArticle(long id)
        {
            var Article = await _ArticleRepository.GetArticle(id);

            /* With AutoMapper*/
            var ArticleDTO = _mapper.Map<ArticleDTO>(Article);

            /*
            without AutoMapper
            var ArticleDTO = new ArticleDTO
            {
                Id = a.Id,
                Articlename = a.Title,
                Token = u.Token,
                Description = u.Description
            };*/

            return Ok(ArticleDTO);
        }

        [HttpPost]
        public async Task<IActionResult> addArticle(ArticleDTO ArticleDTO)
        {
            /* With AutoMapper*/
            var Article = _mapper.Map<Article>(ArticleDTO);

            /*
            without AutoMapper
            var Article = new Article
            {
                Id = a.Id,
                Articlename = a.Title,
                Token = u.Token,
                Description = u.Description
            };*/

            await _ArticleRepository.addArticle(Article);
            return Ok(Article);
        }


        [HttpPut]
        public async Task<IActionResult> updateArticle(long id, ArticleDTO ArticleDTO)
        {
            /* With AutoMapper*/
            var Article = _mapper.Map<Article>(ArticleDTO);
            Article.Id = id;
            /*
            without AutoMapper
            var Article = new Article
            {
                Id = a.Id,
                Articlename = a.Title,
                Token = u.Token,
                Description = u.Description
            };*/

            await _ArticleRepository.updateArticle(Article);
            return Ok(Article);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteArticle(long id)
        {
            var result = await _ArticleRepository.deleterArticle(id);
            return Ok(result);
        }

    }
}
