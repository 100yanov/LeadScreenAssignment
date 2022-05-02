namespace LeadScreenAssignment.Core.Entities
{
    public class SubAreaEntity : BaseEntity
    {
        public string Name { get; set; }
        public Guid PinCodeId { get; set; }
        public PinCodeEntity PinCode { get; set; }
        public ICollection<LeadEntity> Leads { get; set; }
    }
}
