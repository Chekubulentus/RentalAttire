using MediatR;
using RentalAttireBackend.Application.Common.Models;
using RentalAttireBackend.Application.Users.Commands.CreateUser;
using RentalAttireBackend.Domain.Common;

namespace RentalAttireBackend.Application.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommand : IRequest<Result<bool>>
    {
        public string EmployeeCode { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string MiddleName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Gender { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public string Email { get; set; } = "";
        public int Age { get; set; }
        public string MaritalStatus { get; set; } = "";
        public string RolePosition { get; set; } = "";
        public string CreatedBy { get; set; } = "";
        public CreateUserCommand CreateUserCommand { get; set; } = null!;
    }
}
