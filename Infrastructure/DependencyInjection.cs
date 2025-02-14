using Application.Interfaces.RepositoryInterfaces;
using Domain;
using Infrastructure.Database;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddSingleton<FakeDatabase>();

            services.AddDbContext<RealDatabase>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;


            services.AddDbContext<RealDatabase>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            //services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddIdentityCore<User>(); }
        //.AddRoles<IdentityRole>();}
        //.AddEntityFrameworkStores<RealDatabase>();
    
    }
}
