using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RentalAttireBackend.Application.Common.Models;
using RentalAttireBackend.Application.Employees.Commands.CreateEmployee;
using RentalAttireBackend.Domain.Entities;
using RentalAttireBackend.Domain.Interfaces;
using RentalAttireBackend.Infrastracture.Persistence.DataContext;

namespace RentalAttireBackend.Application.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Result<bool>>
    {
        private readonly IEmployeeRepository _employeeRepo;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private RentalAttireContext _context;
        public CreateEmployeeCommandHandler
            (
            IEmployeeRepository employeeRepo,
            IMapper mapper,
            IMediator mediator,
            RentalAttireContext context
            )
        {
            _employeeRepo = employeeRepo;
            _mapper = mapper;
            _mediator = mediator;
            _context = context;
        }
        public async Task<Result<bool>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                return Result<bool>.Failure("Fill in the missing requirements.");

            var transaction = await _context.Database.BeginTransactionAsync(cancellationToken); 

            var roleId = Enum.Parse<RolePosition>(request.RolePosition, true);

            var role = await _context.Roles
                .FirstOrDefaultAsync(r => r.RolePosition == roleId, cancellationToken);

            if (role == null)
                return Result<bool>.Failure("Role position does not exist.");

            var newEmployee = _mapper.Map<Employee>(request);
            newEmployee.RoleId = role.Id;

            var createEmployee = await _employeeRepo.CreateEmployeeAsync(newEmployee, cancellationToken);

            if (!createEmployee)
                return Result<bool>.Failure("Employee cannot be created.");

            request.CreateUserCommand.EmployeeId = newEmployee.Id;
            request.CreateUserCommand.CreatedBy = newEmployee.CreatedBy;

            var createUser = await _mediator.Send(request.CreateUserCommand, cancellationToken);

            if (!createUser.IsSuccess)
            {
                await transaction.RollbackAsync();
                return Result<bool>.Failure("User cannot be created.");
            }

            await transaction.CommitAsync(cancellationToken);
            return Result<bool>.SuccessWithMessage("Employee successfully created.");
        }
    }
}
