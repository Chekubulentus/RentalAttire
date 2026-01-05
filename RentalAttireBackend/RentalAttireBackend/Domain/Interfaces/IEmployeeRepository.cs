using RentalAttireBackend.Application.Common.Models;
using RentalAttireBackend.Application.Employees.EmployeeDTOs;
using RentalAttireBackend.Domain.Entities;
using System.Runtime.InteropServices.Marshalling;

namespace RentalAttireBackend.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        public Task<List<Employee>> GetAllEmployeesAsync(CancellationToken token);
        public Task<Employee?> GetEmployeeByIdAsync(int id, CancellationToken token);
        public Task<bool> CreateEmployeeAsync(Employee request, CancellationToken token);
        public Task<bool> ArchiveEmployeeByIdAsync(int id, CancellationToken token);
        public Task<bool> UpdateEmployeeByIdAsync(EmployeeDTO request, CancellationToken token);
    }
}
