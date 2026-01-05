using AutoMapper;
using MediatR;
using RentalAttireBackend.Application.Common.Models;
using RentalAttireBackend.Application.Employees.EmployeeDTOs;
using RentalAttireBackend.Domain.Interfaces;
using System.Runtime.InteropServices.Marshalling;
using System.Security.Cryptography.X509Certificates;

namespace RentalAttireBackend.Application.Employees.Queries.GetEmployeeById
{
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, Result<EmployeeDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;
        public GetEmployeeByIdQueryHandler(
            IEmployeeRepository employeeRepo,
            IMapper mapper
            )
        {
            _mapper = mapper;
            _employeeRepository = employeeRepo;
        }
        public async Task<Result<EmployeeDTO>> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(request.Id, cancellationToken);
            if (employee is null)
                return Result<EmployeeDTO>.Failure("Employee does not exist.");
            var employeeDto = _mapper.Map<EmployeeDTO>(employee);
            return Result<EmployeeDTO>.Success(employeeDto);
        }
    }
}
