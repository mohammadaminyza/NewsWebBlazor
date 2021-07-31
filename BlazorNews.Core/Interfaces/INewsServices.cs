using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BlazorNews.Core.DTOs;
using BlazorNews.Entities.Domain;
using Microsoft.AspNetCore.Http;

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
