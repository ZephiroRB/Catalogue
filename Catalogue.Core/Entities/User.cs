using System;
using System.Collections.Generic;

namespace Catalogue.Core.Entities
{
    public partial class User
    {
       
        public User()
        {
            Article = new HashSet<Article>();
        }

        public int Id { get; set; }
        public string Token { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Username { get; set; }
        public string Slug { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Article> Article { get; set; }
    }
}
