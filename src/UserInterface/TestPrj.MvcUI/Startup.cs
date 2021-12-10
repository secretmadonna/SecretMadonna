using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace SecretMadonna.TestPrj.MvcUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.ClearProviders();
                loggingBuilder.AddConsole();
                loggingBuilder.AddLog4Net("log4net.config", true);
            });
            services.AddControllersWithViews();
            services.AddHttpContextAccessor();

            services.AddAuthentication(authenticationOptions =>
            {
                authenticationOptions.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, "displayName?", cookieAuthenticationOptions =>
            {
                cookieAuthenticationOptions.Cookie.Name = "TestPrj.Auth";
                cookieAuthenticationOptions.LoginPath = new PathString("/Account/Login");
                cookieAuthenticationOptions.AccessDeniedPath = new PathString("/Account/Login");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            logger.LogInformation(new EventId(0, "default"), "message");

            if (!env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStatusCodePagesWithReExecute("/Home/StatusCode/{0}");
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}").RequireAuthorization();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
