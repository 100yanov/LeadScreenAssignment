namespace LeadScreenAssignment.Data
{
    public interface IDbContext : IDisposable
    {
        IDbSet<T> Set<T>() where T: class;
        void EnsureCreated();
        int SaveChanges();
    }
}
