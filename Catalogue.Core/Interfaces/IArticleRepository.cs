using Catalogue.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Catalogue.Core.Interfaces
{
    public interface IArticleRepository
    {
        Task<IEnumerable<Article>> GetArticles();
    }
}
