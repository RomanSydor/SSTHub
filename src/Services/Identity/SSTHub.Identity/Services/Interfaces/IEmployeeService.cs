using SSTHub.Identity.Models.Dtos;

namespace SSTHub.Identity.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<int> CreateAsync(EmployeeCreateDto createDto);
    }
}
