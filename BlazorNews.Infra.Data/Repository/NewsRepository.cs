using BlazorNews.Domain.IRepository;
using BlazorNews.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BlazorNews.Domain.Entities;
using System.Threading.Tasks;

namespace BlazorNews.Infra.Data.Repository
{
    public class NewsRepository : Repository<News>, INewsRepository
    {
        private IRepository<News> _repository;
        private BlazorNewsContext _context;

        public NewsRepository(IRepository<News> repository, BlazorNewsContext context) : base(context)
        {
            _repository = repository;
            _context = context;
        }


        public IAsyncEnumerable<News> GetNewses()
        {
            return _repository.GetAll();
        }

        public IAsyncEnumerable<News> GetNewses(Expression<Func<News, bool>> whereCondition)
        {
            return _repository.GetAll(whereCondition);
        }

        public IAsyncEnumerable<TSelect> GetNewses<TSelect>(Expression<Func<News, bool>> whereCondition, Expression<Func<News, TSelect>> selectCondition)
        {
            return _repository.GetAll(whereCondition, selectCondition);
        }

        public async Task<News> GetNewsByNewsId(object id)
        {
            return await _repository.GetById(id);
        }

        public async Task<News> AddNews(News news)
        {
            return await _repository.Add(news);
        }

        public async Task UpdateNews(News news)
        {
            await _repository.Update(news);
        }

        public async Task DeleteNews(News news)
        {
            await _repository.Delete(news);
        }

        public async Task<bool> ExistNews(Expression<Func<News, bool>> condition)
        {
            return await _repository.Any(condition);
        }
    }
}
