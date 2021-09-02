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
using Microsoft.AspNetCore.Identity;

namespace BlazorNews.Core.Services
{
    public class UserServices : IUserServices
    {
        private IUserRepository _userRepository;

        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task<IdentityUser> GetUserByUserName(string userName)
        {
            return await _userRepository.GetById(o => o.UserName == userName);
        }

        public async Task<IdentityUser> GetUserByEmail(string email)
        {
            return await _userRepository.GetById(o => o.Email == email);
        }

        public async Task AddUser(IdentityUser user)
        {
            await _userRepository.Add(user);
        }

        public async Task RegisterUser(LoginAndRegisterDTO registerDto)
        {
            await AddUser(new IdentityUser()
            {
                UserName = registerDto.UserName,
                PasswordHash = registerDto.GetHashCode().ToString()
            });
        }

        public async Task<bool> ExistUser(Expression<Func<IdentityUser, bool>> condition)
        {
            return await _userRepository.Any(condition);
        }
    }
}
