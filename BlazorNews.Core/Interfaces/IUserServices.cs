using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BlazorNews.Core.DTOs;
using BlazorNews.Domain.Entities;

namespace BlazorNews.Core.Interfaces
{
    public interface IUserServices
    {
        Task AddUser(User user);
        Task RegisterUser(LoginAndRegisterDTO registerDto);
        Task<bool> ExistUser(Expression<Func<User, bool>> condition);
    }
}
