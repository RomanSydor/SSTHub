namespace SSTHub.Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        IEmployeeRepository EmployeeRepository { get; }
        IHubRepository HubRepository { get; }
        IServiceRepository ServiceRepository { get; }
        IEventRepository EventRepository { get; }
        Task SaveChangesAsync();
    }
}
