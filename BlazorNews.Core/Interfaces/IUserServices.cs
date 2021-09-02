using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BlazorNews.Core.DTOs;
using BlazorNews.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace BlazorNews.Core.Interfaces
{
    public interface IUserServices
    {
        Task<IdentityUser> GetUserByUserName(string userName);
        Task<IdentityUser> GetUserByEmail(string email);
        Task AddUser(IdentityUser user);
        Task RegisterUser(LoginAndRegisterDTO registerDto);
        Task<bool> ExistUser(Expression<Func<IdentityUser, bool>> condition);
    }
}
