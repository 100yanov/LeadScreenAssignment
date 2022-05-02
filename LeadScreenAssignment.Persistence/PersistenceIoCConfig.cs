using LeadScreenAssignment.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;

namespace LeadScreenAssignment.Persistence
{
    public class PersistenceIoCConfig : IIoCConfig
    {        
        private string connectionString;

        public PersistenceIoCConfig(Container container,IConfiguration configuration )
		{
			this.connectionString = configuration.GetConnectionString("DefaultConnection");
		}

		public void AddServices(IServiceCollection services)
		{			
            services
                .AddDbContext<LeadScreenDbContext>(options =>
                {
                    options.UseSqlServer(connectionString);
                    
                }, ServiceLifetime.Scoped);
			services.AddScoped<DbContext, LeadScreenDbContext>();
        }

        public void RegisterDependencies()
        {
            //TODO: register unit of work
			//todo: register repositories
        }
    }
}
