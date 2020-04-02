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

                //Burasý ERR_HTTP2_INADEQUATE_TRANSPORT_SECURITY hatasýný çözmek için eklendi 
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    //appsettins.MakineÝsmi olarak json dosyasýný ekliyor. 
                    config.AddJsonFile($"appsettings.{Environment.MachineName}.json", optional: true);
                    config.AddCommandLine(args);
                })
                
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
