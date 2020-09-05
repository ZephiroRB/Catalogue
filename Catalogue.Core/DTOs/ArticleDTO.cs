using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogue.Core.DTOs
{
    public class ArticleDTO
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Token { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
