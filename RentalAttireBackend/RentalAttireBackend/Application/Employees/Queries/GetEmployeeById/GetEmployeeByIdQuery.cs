using MediatR;
using RentalAttireBackend.Application.Common.Models;
using RentalAttireBackend.Application.Employees.EmployeeDTOs;

namespace RentalAttireBackend.Application.Employees.Queries.GetEmployeeById
{
    public class GetEmployeeByIdQuery : IRequest<Result<EmployeeDTO>>
    {
        public int Id { get; set;  }
    }
}
