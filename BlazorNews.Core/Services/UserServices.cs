using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BlazorNews.Core.DTOs;
using BlazorNews.Core.Interfaces;
using BlazorNews.Domain.Entities;
using BlazorNews.Domain.IRepository;

namespace BlazorNews.Core.Services
{
    public class UserServices : IUserServices
    {
        private IUserRepository _userRepository;

        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task AddUser(User user)
        {
            await _userRepository.Add(user);
        }

        public async Task RegisterUser(LoginAndRegisterDTO registerDto)
        {
            await AddUser(new User()
            {
                UserName = registerDto.UserName,
                Password = registerDto.Password
            });
        }

        public async Task<bool> ExistUser(Expression<Func<User, bool>> condition)
        {
            return await _userRepository.Any(condition);
        }
    }
}
