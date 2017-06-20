using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace WebApplication3
{
    public class Program
    {
        // dotnet publish -r ubuntu.16.04-x64 -c Release
        public static void Main(string[] args)
        {
            var hostBuilder = new WebHostBuilder();

            var config = Startup.BulidConfiguration(Directory.GetCurrentDirectory(), hostBuilder.GetSetting("environment"));
            var urls = config.GetSection("urls").Value;

            var host=hostBuilder
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseUrls(urls) // 公開設定
                .UseApplicationInsights()
                .Build();

            host.Run();
        }
    }
}
