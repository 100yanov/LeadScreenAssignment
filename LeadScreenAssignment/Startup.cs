using LeadScreenAssignment.Persistence;
using SimpleInjector;

namespace LeadScreenAssignment
{
	public class Startup
	{
		private readonly Container container;

		public Startup(IConfiguration configuration)
		{
			
			container = new Container();
			container.Options.ResolveUnregisteredConcreteTypes = false;
			Configuration = configuration;
		}
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddSimpleInjector(container);
			services.AddControllers();
			services.AddSwaggerGen();
			//services.ConfigureApplication(Configuration);
			//services.ConfigureSimpleInjector(Configuration, container);
			//services.ConfigureAuthentication(Configuration, container);
			//services.ConfigureCors(Configuration, container);

		}

		public IConfiguration Configuration { get; }
		

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseSimpleInjector(container);
			
			this.InitializeContainer(app);

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();				
			});
		}

		private void InitializeContainer(IApplicationBuilder app)
		{
			//TODO:
			//container.Verify();
			//var dbInitializer = new DbInitializer();
			//DbInitializer.Seed();
		}
	}
}
