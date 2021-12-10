using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace SecretMadonna.TestPrj.MvcUI
{
    public class Startup
    {
        private ILogger<Startup> _logger;

        public Startup(IConfiguration configuration, IHostEnvironment hostEnvironment, IWebHostEnvironment webHostEnvironment)
        {
            System.Console.WriteLine($"{++Program.Index}.{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType} {System.Reflection.MethodBase.GetCurrentMethod()}");
            Configuration = configuration;
            HostEnvironment = hostEnvironment;
            WebHostEnvironment = webHostEnvironment;

            _logger = Program.ServiceProvider.GetService<ILogger<Startup>>();
        }

        public IConfiguration Configuration { get; }
        public IHostEnvironment HostEnvironment { get; }
        public IWebHostEnvironment WebHostEnvironment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            System.Console.WriteLine($"{++Program.Index}.{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType} {System.Reflection.MethodBase.GetCurrentMethod()}");

            _logger.LogInformation(new EventId(0, "default"), "message");

            services.AddControllersWithViews();
            services.AddHttpContextAccessor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            System.Console.WriteLine($"{++Program.Index}.{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType} {System.Reflection.MethodBase.GetCurrentMethod()}");

            _logger.LogInformation(new EventId(0, "default"), "message");

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
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
