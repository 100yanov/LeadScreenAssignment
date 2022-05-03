namespace LeadScreenAssignment.Core.Models
{
    public class SubAreaModel: BaseModel
    {
        public string Name { get; set; }
        public string PinCode { get; set; }
        public IEnumerable<LeadModel>? Leads { get; set; }
    }
}
