using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlazorNews.Domain.IRepository
{
    public interface IRepository<TSource> where TSource : class
    {
        IAsyncEnumerable<TSource> GetAll();
        IAsyncEnumerable<TSource> GetAll(Expression<Func<TSource, bool>> whereCondition);
        IAsyncEnumerable<TSelect> GetAll<TSelect>(Expression<Func<TSource, bool>> whereCondition,
            Expression<Func<TSource, TSelect>> selectCondition);
        Task<TSource> GetById(int id);
        Task<TSource> GetById(Expression<Func<TSource, bool>> propertyCondition);
        Task<TSource> Add(TSource entity);
        Task Update(TSource entity);
        Task Delete(TSource entity);
        Task<bool> Any(Expression<Func<TSource, bool>> condition);
        Task<int> Count(Expression<Func<TSource, bool>> condition);
    }
}
