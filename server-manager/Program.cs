using server_manager.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
            try
            {
                CreateWebHostBuilder(args).Build().Run();
            }
            catch (System.Exception ex)
            {
                Logger.LogMessage(Logger.LogLevel.ERROR, ex.Message);
                Logger.LogMessage(Logger.LogLevel.ERROR, ex.StackTrace);
                
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
