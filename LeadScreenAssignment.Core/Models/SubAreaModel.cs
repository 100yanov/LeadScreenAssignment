namespace LeadScreenAssignment.Core.Models
{
    public class SubAreaModel: BaseModel
    {
        public string Name { get; set; }
        public string PinCode { get; set; }
        public IEnumerable<LeadEditModel> Leads { get; set; } = new List<LeadEditModel>();
    }
}
