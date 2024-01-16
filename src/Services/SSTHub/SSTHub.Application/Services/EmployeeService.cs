using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SSTHub.Domain.Interfaces;
using SSTHub.Domain.ViewModels.Employee;
using SSTHub.Infrastucture.Contexts;

namespace SSTHub.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly SSTHubDbContext _sSTHubDbContext;
        private readonly IMapper _mapper;

        public EmployeeService(SSTHubDbContext sSTHubDbContext, IMapper mapper)
        {
            _sSTHubDbContext = sSTHubDbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeListItemViewModel>> GetAsync(int amount, int page)
        {
            var employees = await _sSTHubDbContext
                .Employees
                .Skip(amount * page)
                .Take(amount)
                .ToListAsync();

            return _mapper.Map<IEnumerable<EmployeeListItemViewModel>>(employees);
        }
    }
}
