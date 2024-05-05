using Microsoft.Extensions.Configuration;

namespace Shared.Helpers
{
    //public static class Appsettings
    //{
    //    private static IConfigurationRoot _configuration;
    //    static Appsettings()
    //    {
    //        var builder = new ConfigurationBuilder()
    //            .SetBasePath(Directory.GetCurrentDirectory())
    //            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
    //        _configuration = builder.Build();
    //    }
    //    public static string GetSetting(string key)
    //    {
    //        return _configuration.GetSection(key).Value;
    //    }

    //    public static string GetConnectionString(string key)
    //    {
    //        return _configuration.GetConnectionString(key);
    //    }
    //}

    using Microsoft.Extensions.Configuration;
    using System;
    using System.IO;

    public sealed class AppSettings
    {
        private static readonly object _lock = new object();
        private static volatile AppSettings _instance;

        private readonly string _rabbitMQURL;

        private AppSettings()
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);

            var root = configurationBuilder.Build();

            _rabbitMQURL = root.GetSection("RabbitMQ:URL").Value;
        }

        public static AppSettings Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new AppSettings();
                        }
                    }
                }
                return _instance;
            }
        }

        public string RabbitMQURL { get => _rabbitMQURL; }
    } 



}
