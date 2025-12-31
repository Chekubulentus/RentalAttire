using MediatR;
using RentalAttireBackend.Application.Common.Models;
using RentalAttireBackend.Application.Employees.EmployeeDTOs;
using RentalAttireBackend.Domain.Entities;

namespace RentalAttireBackend.Application.Employees.Queries.GetAllEmployees
{
    public class GetAllEmployeesQuery : IRequest<Result<List<EmployeeDTO>>>
    {

    }
}
