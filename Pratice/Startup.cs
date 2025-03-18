using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pratice;

namespace DIinCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Registering a singleton service
            services.AddSingleton<ICategoryRepository, CategoryRepository>();

            // Other dependency injections can be added here using AddTransient or AddScoped
             services.AddTransient<ICategoryRepository, CategoryRepository>();
             services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
