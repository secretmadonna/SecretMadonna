using Exceptionless;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.InteropServices;
using System;

namespace SecretMadonna.TestPrj.MvcUI
{
    public class Program
    {
        public static int Index = 0;
        public static IServiceProvider ServiceProvider;
        private static ILogger<Program> _logger;

        public static void Main(string[] args)
        {
            var hostBuilder = CreateHostBuilder(args);
            var host = hostBuilder.Build();
            host.Run();
            //ExceptionlessClient.Default.ProcessQueue();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var hostBuilder = Host.CreateDefaultBuilder(args);
            hostBuilder
                .ConfigureWebHostDefaults(webHostBuilder =>
                {
                    System.Console.WriteLine($"{++Program.Index}.{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType} {System.Reflection.MethodBase.GetCurrentMethod()}");

                    webHostBuilder
                    .ConfigureLogging((hostBuilderContext, loggingBuilder) =>
                    {
                        System.Console.WriteLine($"{++Program.Index}.{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType} {System.Reflection.MethodBase.GetCurrentMethod()}");

                        //֮�����ʹ����־������
                        loggingBuilder.ClearProviders();
                        loggingBuilder.AddConfiguration(hostBuilderContext.Configuration.GetSection("Logging"));
                        //ExceptionlessClient.Default.Configuration.ReadFromConfiguration(hostBuilderContext.Configuration);
                        //loggingBuilder.AddExceptionless(ExceptionlessClient.Default);
                        loggingBuilder.AddLog4Net("log4net.config", true);
                        loggingBuilder.AddConsole(); // ����̨
                        //loggingBuilder.AddDebug(); // ����
                        //loggingBuilder.AddEventSourceLogger(); // �¼���Դ
                        //if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                        //{
                        //    loggingBuilder.AddEventLog(); // Windows ʱ����־
                        //}

                        //����д��־�����д���ӿڼ�ʵ���Ѿ�ע��������ͨ��������ȡ���������ȫ�ֱ�¶���Ƿ���Ҫȫ�ֱ�¶��
                        ServiceProvider = loggingBuilder.Services.BuildServiceProvider();
                        _logger = ServiceProvider.GetService<ILogger<Program>>();
                        _logger.LogInformation(new EventId(0, "default"), "message");
                    })
                    .ConfigureServices((webHostBuilderContext, serviceCollection) =>
                    {
                        System.Console.WriteLine($"{++Program.Index}.{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType} {System.Reflection.MethodBase.GetCurrentMethod()}");

                        //����д��־
                        _logger.LogInformation(new EventId(0, "default"), "message");
                    })
                    .UseStartup<Startup>();
                });
            return hostBuilder;
            #region ִ��˳���о�
            //Host.CreateDefaultBuilder(args)
            //    .ConfigureWebHost(webHostBuilder =>
            //    {
            //        System.Console.WriteLine($"{++Program.Index}.{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType} {System.Reflection.MethodBase.GetCurrentMethod()}");
            //    })
            //    .ConfigureWebHostDefaults(webHostBuilder =>
            //    {
            //        System.Console.WriteLine($"{++Program.Index}.{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType} {System.Reflection.MethodBase.GetCurrentMethod()}");
            //        webHostBuilder
            //        .ConfigureAppConfiguration(configureBuilder =>
            //        {
            //            System.Console.WriteLine($"{++Program.Index}.{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType} {System.Reflection.MethodBase.GetCurrentMethod()}");
            //        })
            //        .ConfigureLogging((hostBuilderContext, loggingBuilder) =>
            //        {
            //            System.Console.WriteLine($"{++Program.Index}.{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType} {System.Reflection.MethodBase.GetCurrentMethod()}");

            //            //֮�����ʹ����־������
            //            loggingBuilder.ClearProviders();
            //            loggingBuilder.AddConfiguration(hostBuilderContext.Configuration.GetSection("Logging"));
            //            //ExceptionlessClient.Default.Configuration.ReadFromConfiguration(hostBuilderContext.Configuration);
            //            //loggingBuilder.AddExceptionless(ExceptionlessClient.Default);
            //            loggingBuilder.AddLog4Net("log4net.config", true);
            //            loggingBuilder.AddConsole(); // ����̨
            //            //loggingBuilder.AddDebug(); // ����
            //            //loggingBuilder.AddEventSourceLogger(); // �¼���Դ
            //            //if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            //            //{
            //            //    loggingBuilder.AddEventLog(); // Windows ʱ����־
            //            //}

            //            //����д��־
            //            //var serviceProvider = serviceCollection.BuildServiceProvider();
            //            //var logger = serviceProvider.GetService<ILogger<Program>>();
            //            //logger.LogInformation(new EventId(0, "default"), "message");
            //        })
            //        .ConfigureServices(serviceCollection =>
            //        {
            //            System.Console.WriteLine($"{++Program.Index}.{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType} {System.Reflection.MethodBase.GetCurrentMethod()}");
            //        })
            //        .ConfigureServices((webHostBuilderContext, serviceCollection) =>
            //        {
            //            System.Console.WriteLine($"{++Program.Index}.{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType} {System.Reflection.MethodBase.GetCurrentMethod()}");

            //            //serviceCollection.AddLogging(loggingBuilder =>
            //            //{
            //            //    //֮�����ʹ����־������
            //            //    loggingBuilder.ClearProviders();
            //            //    loggingBuilder.AddConfiguration(webHostBuilderContext.Configuration.GetSection("Logging"));
            //            //    //ExceptionlessClient.Default.Configuration.ReadFromConfiguration(webHostBuilderContext.Configuration);
            //            //    //loggingBuilder.AddExceptionless(ExceptionlessClient.Default);
            //            //    loggingBuilder.AddLog4Net("log4net.config", true);
            //            //    loggingBuilder.AddConsole(); // ����̨
            //            //    //loggingBuilder.AddDebug(); // ����
            //            //    //loggingBuilder.AddEventSourceLogger(); // �¼���Դ
            //            //    //if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            //            //    //{
            //            //    //    loggingBuilder.AddEventLog(); // Windows ʱ����־
            //            //    //}

            //            //    //����д��־
            //            //    //var serviceProvider = serviceCollection.BuildServiceProvider();
            //            //    //var logger = serviceProvider.GetService<ILogger<Program>>();
            //            //    //logger.LogInformation(new EventId(0, "default"), "message");
            //            //});
            //        })
            //        .UseStartup<Startup>()
            //        .UseDefaultServiceProvider((hostBuilderContext, serviceProviderOptions) =>
            //        {
            //            System.Console.WriteLine($"{++Program.Index}.{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType} {System.Reflection.MethodBase.GetCurrentMethod()}");
            //        })
            //        .ConfigureKestrel((webHostBuilderContext, kestrelServerOptions) =>
            //        {
            //            System.Console.WriteLine($"{++Program.Index}.{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType} {System.Reflection.MethodBase.GetCurrentMethod()}");
            //        });
            //    })
            //    .ConfigureHostConfiguration(configureBuilder =>
            //    {
            //        System.Console.WriteLine($"{++Program.Index}.{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType} {System.Reflection.MethodBase.GetCurrentMethod()}");
            //    })
            //    .ConfigureAppConfiguration(configureBuilder =>
            //    {
            //        System.Console.WriteLine($"{++Program.Index}.{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType} {System.Reflection.MethodBase.GetCurrentMethod()}");
            //    })
            //    .ConfigureLogging((hostBuilderContext, loggingBuilder) =>
            //    {
            //        System.Console.WriteLine($"{++Program.Index}.{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType} {System.Reflection.MethodBase.GetCurrentMethod()}");
            //    })
            //    .ConfigureServices(serviceCollection =>
            //    {
            //        System.Console.WriteLine($"{++Program.Index}.{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType} {System.Reflection.MethodBase.GetCurrentMethod()}");
            //    })
            //    .UseDefaultServiceProvider((hostBuilderContext, serviceProviderOptions) =>
            //    {
            //        System.Console.WriteLine($"{++Program.Index}.{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType} {System.Reflection.MethodBase.GetCurrentMethod()}");
            //    });
            #endregion
        }
    }
}
