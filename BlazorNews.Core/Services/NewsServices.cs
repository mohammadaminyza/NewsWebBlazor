using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BlazorNews.Core.DTOs;
using BlazorNews.Core.Generators;
using BlazorNews.Core.Interfaces;
using BlazorNews.Core.Security;
using BlazorNews.Domain.IRepository;
using BlazorNews.Domain.Entities;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;

namespace BlazorNews.Core.Services
{
    public class NewsServices : INewsServices
    {
        private readonly INewsRepository _newsRepository;
        private readonly IRepository<Comment> _commentRepository;
        private IMapper _mapper;

        public NewsServices(INewsRepository newsRepository, IRepository<Comment> commentRepository, IMapper mapper)
        {
            _newsRepository = newsRepository;
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public IAsyncEnumerable<News> GetNewses()
        {
            return _newsRepository.GetAll();
        }

        public IAsyncEnumerable<News> GetNewses(Expression<Func<News, bool>> whereCondition)
        {
            return _newsRepository.GetAll(whereCondition);
        }

        public IAsyncEnumerable<NewsBoxItemDTO> GetNewsBoxItemDto()
        {
            return _newsRepository.GetAll<NewsBoxItemDTO>(null, p => new NewsBoxItemDTO()
            {
                NewsId = p.NewsId,
                NewsTitle = p.NewsTitle,
                ImageName = p.ImageName,
                IsActive = p.IsActive,
                NewsShortDescription = p.NewsShortDescription,
                NewsDescription = p.NewsDescription,
                CreateDate = p.CreateDate
            });
        }

        public async Task<News> GetNewsById(int newsId)
        {
            return await _newsRepository.GetById(newsId);
        }

        public async Task<News> GetNewsById(Expression<Func<News, bool>> condition)
        {
            return await _newsRepository.GetById(condition);
        }

        public async Task<News> AddNews(News news)
        {
            return await _newsRepository.Add(news);
        }

        public async Task<News> AddNews(NewsBoxItemDTO news)
        {
            var mapNews = _mapper.Map<NewsBoxItemDTO, News>(news);
            return await AddNews(mapNews);
        }

        public async Task<string> SaveNewsImage(IBrowserFile image)
        {
            string fileFormat = Path.GetExtension(image.Name);
            string imageNewName = GuidGenerate.GuidGenerator() + fileFormat;

            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/NewsImage/" + imageNewName);

            var memoryStream = new MemoryStream();
            await image.OpenReadStream().CopyToAsync(memoryStream);

            await using var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write);

            memoryStream.WriteTo(stream);

            return imageNewName;
        }

        public async Task UpdateNews(News news)
        {
            await _newsRepository.Update(news);
        }

        public async Task DeleteNews(int newsId)
        {
            await DeleteNews(await GetNewsById(newsId));
        }

        public async Task DeleteNews(News news)
        {
            await _newsRepository.Delete(news);
        }

        public async Task<bool> ExistNews(Expression<Func<News, bool>> condition)
        {
            return await _newsRepository.Any(condition);
        }

        public IAsyncEnumerable<Comment> GetNewsComments(int newsId)
        {
            return _commentRepository.GetAll(p => p.NewsId == newsId);
        }

        public async Task AddNewsComment(Comment comment)
        {
            await _commentRepository.Add(comment);
        }
    }
}
