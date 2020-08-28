using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalogue.Core.Interfaces;
using Catalogue.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalogue.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleController(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;

        }

        [HttpGet]
        public async Task<IActionResult> GetArticles()
        {
            var artilces = await _articleRepository.GetArticles();

            return Ok(artilces);
        }


    }
}
