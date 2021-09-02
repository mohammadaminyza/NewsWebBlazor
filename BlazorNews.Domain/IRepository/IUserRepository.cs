using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorNews.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace BlazorNews.Domain.IRepository
{
    public interface IUserRepository : IRepository<IdentityUser>
    {
    }
}
