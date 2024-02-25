namespace SSTHub.Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        IEmployeeRepository EmployeeRepository { get; }
        IHubRepository HubRepository { get; }
        Task SaveChangesAsync();
    }
}
