using BlazorNews.Core.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BlazorNews.Domain.Entities;

namespace BlazorNews.Core.Interfaces
{
    public interface INewsServices
    {
        IAsyncEnumerable<News> GetNewses();
        IAsyncEnumerable<News> GetNewses(Expression<Func<News, bool>> whereCondition);
        IAsyncEnumerable<NewsBoxItemDTO> GetNewsBoxItemDto();
        Task<News> GetNewsById(object newsId);
        Task<News> GetNewsById(Expression<Func<News, bool>> condition);
        Task<News> AddNews(News news);
        Task<News> AddNews(NewsBoxItemDTO news);
        Task SaveNewsImage(IFormFile image);
        Task UpdateNews(News news);
        Task DeleteNews(object newsId);
        Task DeleteNews(News news);
        Task<bool> ExistNews(Expression<Func<News, bool>> condition);
    }
}
