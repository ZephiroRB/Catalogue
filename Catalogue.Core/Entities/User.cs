using System;
using System.Collections.Generic;

namespace Catalogue.Core.Entities
{
    public partial class User : BaseEntity
    {

        public User()
        {
            Articles = new HashSet<Article>();
        }

        public string Token { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }


        public virtual ICollection<Article> Articles { get; set; }
    }
}
