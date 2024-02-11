using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using MovieApp.Frontend.Services;

namespace MovieApp.Frontend
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

            services.AddControllersWithViews();     
            services.AddHttpClient<IMovieApiClient, MovieApiClient>(client =>
            {
                client.BaseAddress = new Uri(Configuration["AppSettings:BaseAddress"]); 
            });

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme; 
            })
            .AddCookie()
            .AddGoogle(options =>
            {
                options.ClientId = Configuration["AppSettings:ClientID"];
                options.ClientSecret = Configuration["AppSettings:ClientSecret"];
            });
            //.AddOpenIdConnect(options =>
            //{
            //    options.SkipUnrecognizedRequests = true;
            //    options.Authority = "https://localhost:5001/";
            //    options.ClientId = "52934744522-8tfln5pkgvitjcv4l2d1pkt07av6lkt7.apps.googleusercontent.com";
            //    options.ClientSecret = "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";
            //    options.ResponseType = OpenIdConnectResponseType.Code;
            //    options.Scope.Add("openid");
            //    options.Scope.Add("profile");
            //    options.CallbackPath = "/signin-google";
            //    options.SaveTokens = true;
            //});
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Index}/{id?}");
            });

        }
    }
}
