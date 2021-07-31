using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BlazorNews.Entities.Domain;

namespace BlazorNews.Domain.IRepository
{
    public interface INewsRepository : IRepository<News>
    {
    }
}
