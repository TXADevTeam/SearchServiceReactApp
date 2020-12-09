using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using SearchService.API;
using SearchService.API.Services;
using SearchService.Mock;
using SearchService.Model;

namespace SearchService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public static void ConfigureServices(IServiceCollection services)
        {
            SearchServiceMock mock = new SearchServiceMock();
            services.AddControllers();
            services.AddSingleton((System.Func<System.IServiceProvider, ISearchService>)(options => new SearchServiceRealizer(mock.data)));
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "SearchService",
                    Version = "v1",
                });
            });
            services.AddCors(); // добавляем сервисы CORS
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public static void Configure(IApplicationBuilder app)
        {
            app
                .UseSwagger()
                .UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "SearchService");
                });

            app.UseMiddleware<ExceptionHandlerMiddleware>();
            // подключаем CORS
            app.UseCors(builder => builder
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(origin => true) // allow any origin
                    .AllowCredentials()); // allow credentials

            app.UseRouting();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
