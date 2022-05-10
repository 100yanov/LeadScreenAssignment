using LeadScreenAssignment.Core.Interfaces;
using LeadScreenAssignment.Data;
using LeadScreenAssignment.Persistence.Interfaces;
using LeadScreenAssignment.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LeadScreenAssignment.Persistence
{
    public class PersistenceIoCConfig : IIoCConfig
    {
        private readonly IServiceCollection services;
        private string connectionString;

        public PersistenceIoCConfig(IServiceCollection services, IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("DefaultConnection");
            this.services = services;
        }

        public void AddServices()
        {
            //Swap these 2 implementations to switch databases:

            //Ef Core DB context:
            this.services
                .AddDbContext<IDbContext, LeadScreenDbContext>(options =>
             {
                 options.UseSqlServer(connectionString);


             }, ServiceLifetime.Singleton, ServiceLifetime.Singleton);

            //Write to file:
            // this.services.AddScoped<IDbContext, LeadScreenFileDbContext>(i => new LeadScreenFileDbContext(@"C:\LeadScreenDatabase"));

        }

        public void RegisterDependencies()
        {

            this.services.AddScoped<IUnitOfWork, UnitOfWork>();
            this.services.AddScoped<ILeadRepository, LeadRepository>();
            this.services.AddScoped<ISubAreaRepository, SubAreaRepository>();            
        }

      
    }
}
