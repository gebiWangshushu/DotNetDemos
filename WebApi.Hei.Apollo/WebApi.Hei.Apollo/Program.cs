using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Com.Ctrip.Framework.Apollo;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace WebApi.Hei.Apollo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Run();
        }

        public static IWebHost CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, builder) =>
                {
                    builder
                    .AddApollo(builder.Build().GetSection("apollo"))
                    .AddDefault() //默认的application Namespace
                    .AddNamespace("TEST2.Hei.Global")
                    .AddNamespace("TEST1.Hei.Public") //public 类型的Namespace
                    .AddNamespace("Hei.Private");//private 类型的Namespace
                })
                .UseStartup<Startup>()
                .Build();
    }
}
