using AutoMapper;
using MediatR;
using RentalAttireBackend.Application.Common.Models;
using RentalAttireBackend.Application.Employees.EmployeeDTOs;
using RentalAttireBackend.Domain.Entities;
using RentalAttireBackend.Domain.Interfaces;

namespace RentalAttireBackend.Application.Employees.Queries.GetAllEmployees
{
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, Result<List<EmployeeDTO>>>
    {
        private readonly IEmployeeRepository _employeeRepo;
        private readonly IMapper _mapper;
        
        public GetAllEmployeesQueryHandler(IEmployeeRepository employeeRepo, IMapper mapper)
        {
            _employeeRepo = employeeRepo;
            _mapper = mapper;
        }

        public async Task<Result<List<EmployeeDTO>>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employees = await _employeeRepo.GetAllEmployeesAsync();

            if (!employees.Any() || employees.Count() == 0)
                return Result<List<EmployeeDTO>>.Failure("No employees currently found.");

            var employeeDtos = _mapper.Map<List<EmployeeDTO>>(employees);

            return Result<List<EmployeeDTO>>.Success(employeeDtos);
            
        }
    }
}
