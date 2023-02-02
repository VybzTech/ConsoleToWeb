using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace ConsoleToWeb { 
    class Program{ 
        static void Main(string[] args) {
            Console.WriteLine("Hello, World !");
            CreateHostBuilder(args).Build().Run();
            //Console.ReadLine();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args).
            ConfigureWebHostDefaults(webHost =>
            {
                webHost.UseStartup<Startup>();
            });
            }
    }
}