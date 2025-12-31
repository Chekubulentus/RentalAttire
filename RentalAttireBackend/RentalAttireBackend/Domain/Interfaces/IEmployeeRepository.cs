using RentalAttireBackend.Application.Common.Models;
using RentalAttireBackend.Application.Employees.EmployeeDTOs;
using RentalAttireBackend.Domain.Entities;
using System.Runtime.InteropServices.Marshalling;

namespace RentalAttireBackend.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        public Task<List<Employee>> GetAllEmployeesAsync();
        public Task<Employee?> GetEmployeeByIdAsync(int id);
        public Task<bool> CreateEmployeeAsync(EmployeeDTO request);
        public Task<bool> ArchiveEmployeeByIdAsync(int id);
        public Task<bool> UpdateEmployeeByIdAsync(EmployeeDTO request);
    }
}
