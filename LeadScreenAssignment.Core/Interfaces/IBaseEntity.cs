namespace LeadScreenAssignment.Core.Interfaces
{
    public interface IBaseEntity<T> where T : struct
    {
        T Id { get; set; }
    }
}