using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace DemoConfigConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(ReadFromAppSettings().Get<AppSettingsModel>().Message);
        }

        public static IConfigurationRoot ReadFromAppSettings()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT")}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();
        }
    }
}
