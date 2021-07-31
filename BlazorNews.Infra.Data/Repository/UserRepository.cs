using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorNews.Domain.Entities;
using BlazorNews.Domain.IRepository;
using BlazorNews.Infra.Data.Context;

namespace BlazorNews.Infra.Data.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private BlazorNewsContext _context;

        public UserRepository(BlazorNewsContext context) : base(context)
        {
            _context = context;
        }


    }
}
