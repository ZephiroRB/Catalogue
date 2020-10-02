
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Catalogue.Api.Responses;
using Catalogue.Core.DTOs;
using Catalogue.Core.Entities;
using Catalogue.Core.Interfaces;
using Catalogue.Core.QueryFilters;
using Microsoft.AspNetCore.Mvc;

namespace Catalogue.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleService _articleService;
        private readonly IMapper _mapper;

        public ArticlesController(IArticleService articleService, IMapper mapper)
        {
            _articleService = articleService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetArticles([FromQuery] ArticleQueryFilter filters)
        {
            var articles = _articleService.GetArticles(filters);

            var articlesDTO = _mapper.Map<IEnumerable<ArticleDTO>>(articles);

            var response = new ApiResponse<IEnumerable<ArticleDTO>>(articlesDTO);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArticle(long id)
        {
            var article = await _articleService.GetArticle(id);

            var articleDTO = _mapper.Map<ArticleDTO>(article);

            var response = new ApiResponse<ArticleDTO>(articleDTO);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> addArticle(ArticleDTO articleDTO)
        {   
            //Console.WriteLine("Hello World!");

            var article = _mapper.Map<Article>(articleDTO);

            await _articleService.addArticle(article);

            articleDTO = _mapper.Map<ArticleDTO>(article);

            var response = new ApiResponse<ArticleDTO>(articleDTO);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> updateArticle(long id, ArticleDTO articleDTO)
        {
            var article = _mapper.Map<Article>(articleDTO);

            article.Id = id;

            var result = await _articleService.updateArticle(article);

            var response = new ApiResponse<bool>(result);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteArticle(long id)
        {
            var result = await _articleService.deleterArticle(id);

            var response = new ApiResponse<bool>(result);

            return Ok(response);
        }
    }
}
