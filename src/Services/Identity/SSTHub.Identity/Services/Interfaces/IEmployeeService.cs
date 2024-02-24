using SSTHub.Identity.Models.Dtos;

namespace SSTHub.Identity.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task CreateAsync(EmployeeCreateDto createDto);
    }
}
