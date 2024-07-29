
using Hangfire;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StackExchange.Redis;
using System.Text;
using YourTimeSheet.Application.Services;
using YourTimeSheet.Core.Contracts;
using YourTimeSheet.Infrastructure.Hangfire;
using YourTimeSheet.Infrastructure.Services;
using YourTimeSheet.Server.Extensions;

namespace YourTimeSheet.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //var key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"]);
            //builder.Services.ConfigureAuthentication(key);
            builder.Services.ConfigureNpgsqlContext(builder.Configuration);
            builder.Services.AddAuthentication();
            builder.Services.ConfigurationIdentity();
            builder.Services.AddControllers();
            builder.Services.AddAuthorization();
            builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(builder.Configuration.GetConnectionString("HangfireRedis")));
            builder.Services.AddHangfireServices(builder.Configuration);
            builder.Services.AddScoped<IBackgroundJobService, BackgroundJobService>();
            builder.Services.AddScoped<IJobTestService, JobTestService>();
            builder.Services.AddScoped<IRecurringJobManager, RecurringJobManager>();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.UseHangfireDashboard();

            app.Run();
        }
    }
}
