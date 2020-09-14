using Catalogue.Core.Entities;
using Catalogue.Core.Interfaces;
using Catalogue.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalogue.Infrastructure.Repositories
{
    public class ArticleRepository : BaseRepository<Article>, IArticleRepository
    {
        public ArticleRepository(CatalogueContext context): base(context) { }

        public async Task<IEnumerable<Article>> GetArticlesByUser(long UserId)
        {
            return await _entities.Where(x => x.UserId == UserId).ToListAsync();
        }
    }
}
