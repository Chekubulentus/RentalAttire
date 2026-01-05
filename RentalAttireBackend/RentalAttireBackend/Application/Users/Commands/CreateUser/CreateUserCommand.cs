using MediatR;
using RentalAttireBackend.Application.Common.Models;

namespace RentalAttireBackend.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<Result<bool>>
    {
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public int EmployeeId { get; set; }
        public string CreatedBy { get; set; } = "";
    }
}
