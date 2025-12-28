using SocialNetwork.Data.Factories;
using SocialNetwork.Data.Repositories;
using SocialNetwork.Data.Services;
using SocialNetwork.Domain.Repositories;
using SocialNetwork.Domain.Services;

namespace SocialNetwork.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container
            builder.Services.AddControllers();
            builder.Services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.MapControllers();

            app.Run();
        }
    }
}
