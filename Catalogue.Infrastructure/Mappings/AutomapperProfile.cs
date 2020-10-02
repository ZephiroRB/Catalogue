using AutoMapper;
using Catalogue.Core.DTOs;
using Catalogue.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogue.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();

            CreateMap<Article, ArticleDTO>();
            CreateMap<ArticleDTO, Article>();

        }
    }
}
