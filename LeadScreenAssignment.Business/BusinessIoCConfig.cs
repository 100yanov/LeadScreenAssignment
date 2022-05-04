using LeadScreenAssignment.Core.Entities;
using LeadScreenAssignment.Core.Interfaces;
using LeadScreenAssignment.Core.Models;
using LeadScreenAssignment.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nelibur.ObjectMapper;

namespace LeadScreenAssignment.Business
{
    public class BusinessIoCConfig : IIoCConfig
    {
        private readonly IServiceCollection services;

        public BusinessIoCConfig(IServiceCollection services, IConfiguration configuration)
        {
            //TODO: change the way this is implemented
            PersistenceIoCConfig persConfig = new PersistenceIoCConfig(services, configuration);

            persConfig
                .AddServices();
            persConfig
                .RegisterDependencies();

            this.services = services;
        }

        public void AddServices()
        {
            BindSubAreas();
            BindLeads();
        }

        private static void BindSubAreas()
        {

            TinyMapper.Bind<SubAreaModel, SubAreaEntity>();
            TinyMapper.Bind<SubAreaEntity, SubAreaModel>(config => config.Bind(t => t.Leads, typeof(List<LeadEditModel>)));

            TinyMapper.Bind<SubAreaEditModel, SubAreaEntity>();
            TinyMapper.Bind<SubAreaEntity, SubAreaEditModel>();
        }

        private static void BindLeads()
        {
            TinyMapper.Bind<LeadEditModel, LeadEntity>();
            TinyMapper.Bind<LeadEntity, LeadEditModel>();

            TinyMapper.Bind<LeadModel, LeadEntity>();
            TinyMapper.Bind<LeadEntity, LeadModel>();
         
        }


        public void RegisterDependencies()
        {
            services.AddScoped<IService<SubAreaEntity, SubAreaModel, SubAreaEditModel>, SubareaService>();
            services.AddScoped<IService<LeadEntity, LeadModel, LeadEditModel>, LeadService>();
        }
    }
}
