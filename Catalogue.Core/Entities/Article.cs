using System;
using System.Collections.Generic;

namespace Catalogue.Core.Entities
{
    public partial class Article : BaseEntity
    {
        public long UserId { get; set; }
        public string Token { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
       

        public virtual User User { get; set; }
    }
}
