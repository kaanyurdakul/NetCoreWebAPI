using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace NetCoreWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)

                //Buras� ERR_HTTP2_INADEQUATE_TRANSPORT_SECURITY hatas�n� ��zmek i�in eklendi 
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    //appsettins.Makine�smi olarak json dosyas�n� ekliyor. 
                    config.AddJsonFile($"appsettings.{Environment.MachineName}.json", optional: true);
                    config.AddCommandLine(args);
                })
                
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
