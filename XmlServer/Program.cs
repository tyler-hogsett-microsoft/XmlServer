using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace XmlServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .Configure(app => app.Map(string.Empty, Handler))
                .Build();

            host.Run();
        }

        private static void Handler(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                var xmlContents = File.ReadAllText("./idp_metadata.xml");
                await context.Response.WriteAsync(xmlContents);
            });
        }
    }
}
