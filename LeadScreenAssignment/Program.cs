using LeadScreenAssignment.Web;
using Microsoft.AspNetCore;

BuildWebHost(args).Run();


static IWebHost BuildWebHost(string[] args) =>
	WebHost.CreateDefaultBuilder(args)
		.ConfigureAppConfiguration((builderContext, config) =>
		{
			var env = builderContext.HostingEnvironment;

			config
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
				.AddEnvironmentVariables()
				.AddCommandLine(args);
		})
	.UseStartup<Startup>()
	.Build();


var builder = WebApplication.CreateBuilder(args);
