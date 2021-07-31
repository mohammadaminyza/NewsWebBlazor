using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BlazorNews.Domain.IRepository;
using BlazorNews.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BlazorNews.Infra.Data.Repository
{
    public class Repository<TSource> : IRepository<TSource> where TSource : class
    {
        private BlazorNewsContext _context;

        public Repository(BlazorNewsContext context)
        {
            _context = context;
        }
        public IAsyncEnumerable<TSource> GetAll()
        {
            return GetAll(null);
        }

        public IAsyncEnumerable<TSource> GetAll(Expression<Func<TSource, bool>> whereCondition)
        {
            var result = GetTable().Result.AsQueryable();

            if (whereCondition != null)
            {
                result = result.Where(whereCondition);
            }

            return result.AsAsyncEnumerable();
        }

        public IAsyncEnumerable<TSelect> GetAll<TSelect>(Expression<Func<TSource, bool>> whereCondition,
            Expression<Func<TSource, TSelect>> selectCondition)
        {
            var result = GetTable().Result.AsQueryable();

            if (selectCondition == null)
            {
                throw new Exception("This Method Need Selection");
            }

            if (whereCondition != null)
            {
                result = result.Where(whereCondition);
            }

            var selection = result.Select(selectCondition);

            return selection.AsAsyncEnumerable();
        }

        public async Task<TSource> GetById(object id)
        {
            var table = await GetTable();

            return await table.FindAsync(id);
        }

        public async Task<TSource> GetById(Expression<Func<TSource, bool>> propertyCondition)
        {
            var table = await GetTable();

            return await table.FirstOrDefaultAsync(propertyCondition);
        }

        public async Task<TSource> Add(TSource entity)
        {
            var added = await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            return added.Entity;
        }

        public async Task Update(TSource entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(TSource entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Any(Expression<Func<TSource, bool>> condition)
        {
            var table = await GetTable();

            return await table.AnyAsync(condition);
        }

        public async Task<int> Count(Expression<Func<TSource, bool>> condition)
        {
            var table = await GetTable();

            return await table.CountAsync(condition);
        }

        private Task<DbSet<TSource>> GetTable()
        {
            return Task.FromResult<DbSet<TSource>>(_context.Set<TSource>());
        }
    }
}
