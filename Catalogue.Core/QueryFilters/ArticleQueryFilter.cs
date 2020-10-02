using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogue.Core.QueryFilters
{
    public class ArticleQueryFilter
    {
        public long? UserId { get; set; }

        public DateTime? CreatedAt { get; set; }

        public string Description { get; set; }
    }
}
