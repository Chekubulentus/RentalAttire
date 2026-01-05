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

        public Task<bool> ArchiveEmployeeByIdAsync(int id, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CreateEmployeeAsync(Employee request, CancellationToken token)
        {
            await _context.Employees.AddAsync(request);
            await _context.SaveChangesAsync(token);
            return true;
        }

        public async Task<List<Employee>> GetAllEmployeesAsync(CancellationToken cancellationToken)
        {
            return await _context.Employees.AsNoTracking()
                .Include(e => e.Role)
                .ToListAsync(cancellationToken);
        }

        public async Task<Employee?> GetEmployeeByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Employees.FindAsync(id, cancellationToken);
        }

        public Task<bool> UpdateEmployeeByIdAsync(EmployeeDTO request, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
