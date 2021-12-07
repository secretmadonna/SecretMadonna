using Exceptionless;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace SecretMadonna.TestPrj.MvcUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            ExceptionlessClient.Default.ProcessQueue();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureLogging((hostBuilderContext, loggingBuilder) =>
                {
                    loggingBuilder.ClearProviders();
                    loggingBuilder.AddConfiguration(hostBuilderContext.Configuration.GetSection("Logging"));
                    ExceptionlessClient.Default.Configuration.ReadFromConfiguration(hostBuilderContext.Configuration);
                    loggingBuilder.AddExceptionless(ExceptionlessClient.Default);
                    //loggingBuilder.AddConsole(); // ����̨
                    //loggingBuilder.AddDebug(); // ����
                    //loggingBuilder.AddEventSourceLogger(); // �¼���Դ
                    //loggingBuilder.AddEventLog(); // Windows ʱ����־
                });
    }
}
