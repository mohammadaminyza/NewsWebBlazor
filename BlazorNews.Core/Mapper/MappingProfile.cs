using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BlazorNews.Core.DTOs;
using BlazorNews.Domain.Entities;
using BlazorNews.Entities.Domain;

namespace BlazorNews.Core.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<News, NewsBoxItemDTO>();
            CreateMap<NewsBoxItemDTO, News>();
        }
    }
}
