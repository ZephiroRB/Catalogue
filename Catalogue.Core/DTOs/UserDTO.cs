using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogue.Core.DTOs
{
    public class UserDTO
    {
        public long Id { get; set; }
        public string Token { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
