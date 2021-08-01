using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BlazorNews.Core.Interfaces;
using BlazorNews.Core.Services;
using BlazorNews.Domain.IRepository;
using BlazorNews.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorNews.Infra.IoC
{
    public static class RegisterDependencyInjection
    {
        public static void AddRegisterDependencies(this IServiceCollection service)
        {
            //Injections
            service.AddScoped<HttpClient>();
            service.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            service.AddScoped<INewsRepository, NewsRepository>();
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<INewsServices, NewsServices>();
            service.AddScoped<IUserServices, UserServices>();
        }
    }
}
