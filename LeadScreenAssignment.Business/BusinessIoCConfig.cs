using LeadScreenAssignment.Core;
using LeadScreenAssignment.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;

namespace LeadScreenAssignment.Business
{
    public class BusinessIoCConfig
    {

        public BusinessIoCConfig(Container container, IServiceCollection services, IConfiguration configuration)
        {
            //TODO: change the way this is implemented
            PersistenceIoCConfig persConfig = new PersistenceIoCConfig(container, configuration);
            persConfig
                .AddServices(services);
            persConfig
                .RegisterDependencies();
        }

        public void RegisterDependencies()
        {
            //TODO:
        }
    }
}