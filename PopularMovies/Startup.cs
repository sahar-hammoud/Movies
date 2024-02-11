using Microsoft.EntityFrameworkCore;
using MovieApi.Service;
using MovieApp.Backend.DataAccess;
using MovieApp.Backend.Models;
using MovieApp.Backend.Service;

namespace MovieApp.Backend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            var builder = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.AddRouting(); 
            services.AddControllers();

            services.AddHttpClient();
            services.AddControllersWithViews();
            services.AddMemoryCache();
        
            // Add DbContext
            services.AddDbContext<MovieDbContext>();

            // Register MovieService and CacheService
            services.AddScoped<MovieService>();
            services.AddScoped<CacheService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
             
                app.UseHsts();
            }

           app.UseHttpsRedirection();
           app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute(
                name: "api",
                pattern: "api/{controller=Movies}/{action=GetPopularMoviesList}/{id?}");
             });
   
        }
    }
}