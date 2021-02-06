using server_manager.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace server_manager
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.LogMessage(Logger.LogLevel.INFO, "Server Manager is starting.");
            Logger.LogMessage(Logger.LogLevel.INFO, "Build: {0}", (
              ThisAssembly.Git.SemVer.Major + "." +
              ThisAssembly.Git.SemVer.Minor + "." +
              ThisAssembly.Git.SemVer.Patch + "-" +
              ThisAssembly.Git.Branch + "+" +
              ThisAssembly.Git.Commit));

            Logger.LogMessage(Logger.LogLevel.INFO, "Starting Webserver.");
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }

    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvcCore();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }

    public class MyEndpoint : Controller
    {
        [Route("")]
        public IActionResult Get()
        {
            return new OkResult();
        }
    }
}
