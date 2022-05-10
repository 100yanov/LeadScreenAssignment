using FileDatabase;
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
            this.services
                .AddDbContext<IDbContext, LeadScreenDbContext>(options =>
             {
                 options.UseSqlServer(connectionString);

             }, ServiceLifetime.Transient);

            //this.services.AddScoped<IDbContext, LeadScreenFileDbContext>(i => new LeadScreenFileDbContext(@"C:\Test Folder"));
        }

        public void RegisterDependencies()
        {

            this.services.AddScoped<IUnitOfWork, UnitOfWork>();
            this.services.AddScoped<ILeadRepository, LeadRepository>();
            this.services.AddScoped<ISubAreaRepository, SubAreaRepository>();
        }
    }
}
