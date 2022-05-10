
using LeadScreenAssignment.Core.Entities;
using LeadScreenAssignment.Persistence.Interfaces;

namespace LeadScreenAssignment.Persistence
{

    public static class DbInitializer
    {
        public static void Seed(IUnitOfWork uow)
        {
            if (!uow.SubAreas.GetAll().Any())
            {
                var subAreas = new List<SubAreaEntity>()
                    {
                    new ()
                        {
                            PinCode="110007",
                            Name="Malka Ganj"
                        },
                    new ()
                        {
                            PinCode="110008",
                            Name="Desh Bandhu Gupta Road"
                        },
                    new ()
                        {
                            PinCode="110008",
                            Name="Patel Nagar"
                        }, 
                    new ()
                        {
                            PinCode="110001",
                            Name="Baroda House"
                        }, 
                    new ()
                        {
                            PinCode="110001",
                            Name="New Delhi Gpo"
                        },
                    new ()
                        {
                            PinCode="110010",
                            Name="Cod"
                        },
                    new ()
                        {
                            PinCode="110009",
                            Name="Dr.mukerjee Nagar"
                        },
                    };
                uow.SubAreas.AddRange(subAreas);
                uow.Complete();
            }
        }
    }
}