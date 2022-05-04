namespace LeadScreenAssignment.Core.Entities
{
    public class SubAreaEntity : BaseEntity
    {
        public SubAreaEntity()
        {
            Leads = new List<LeadEntity>();
        }
        public string Name { get; set; }
        public string PinCode { get; set; }
        public virtual IEnumerable<LeadEntity> Leads { get; set; } 
    }
}