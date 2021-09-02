using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorNews.Domain.Entities;
using BlazorNews.Domain.IRepository;
using BlazorNews.Infra.Data.Context;
using Microsoft.AspNetCore.Identity;

namespace BlazorNews.Infra.Data.Repository
{
    public class UserRepository : Repository<IdentityUser>, IUserRepository
    {
        private BlazorNewsContext _context;

        public UserRepository(BlazorNewsContext context) : base(context)
        {
            _context = context;
        }


    }
}
