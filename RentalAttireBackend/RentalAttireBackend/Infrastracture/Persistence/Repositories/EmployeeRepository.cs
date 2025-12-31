using Microsoft.EntityFrameworkCore;
using RentalAttireBackend.Application.Employees.EmployeeDTOs;
using RentalAttireBackend.Domain.Entities;
using RentalAttireBackend.Domain.Interfaces;
using RentalAttireBackend.Infrastracture.Persistence.DataContext;

namespace RentalAttireBackend.Infrastracture.Persistence.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly RentalAttireContext _context;

        public EmployeeRepository(RentalAttireContext context)
        {
            _context = context;
        }

        public Task<bool> ArchiveEmployeeByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateEmployeeAsync(EmployeeDTO request)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await _context.Employees.AsNoTracking()
                .ToListAsync();
        }

        public async Task<Employee?> GetEmployeeByIdAsync(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public Task<bool> UpdateEmployeeByIdAsync(EmployeeDTO request)
        {
            throw new NotImplementedException();
        }
    }
}
