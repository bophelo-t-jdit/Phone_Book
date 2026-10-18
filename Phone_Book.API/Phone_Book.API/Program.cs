using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using DotNetEnv;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using Phone_Book.API.Data;

namespace Phone_Book.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Env.Load();

            var connectionString = Environment.GetEnvironmentVariable("PHONE_BOOK_CONNECT")
                ?? throw new InvalidOperationException("Connection string 'PHONE_BOOK_CONNECT' is not found. DB Connection not configured.");

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<PhoneBookDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Register the API versioning services
            builder.Services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                // Report the supported API versions in the response headers
                options.ReportApiVersions = true;
            }).AddApiExplorer(options =>
                {
                    options.GroupNameFormat = "'v'VVV";
                    options.SubstituteApiVersionInUrl = true;
                });
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
