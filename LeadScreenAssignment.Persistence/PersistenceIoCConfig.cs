using LeadScreenAssignment.Persistence.Interfaces;
using LeadScreenAssignment.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;

namespace LeadScreenAssignment.Persistence
{
    public class PersistenceIoCConfig
    {
        private readonly Container container;
        private string connectionString;

        public PersistenceIoCConfig(Container container,IConfiguration configuration )
		{
            this.container = container;

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
            container.Register<ILeadRepository, LeadRepository>(Lifestyle.Scoped);
            container.Register<ISubAreaRepository, SubAreaRepository>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
			
        }
    }
}
