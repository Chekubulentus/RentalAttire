using AutoMapper;
using MediatR;
using RentalAttireBackend.Application.Common.Models;
using RentalAttireBackend.Domain.Entities;
using RentalAttireBackend.Domain.Interfaces;

namespace RentalAttireBackend.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<bool>>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepo;
        public CreateUserCommandHandler
            (
            IMapper mapper,
            IUserRepository userRepo
            )
        {
            _mapper = mapper;
            _userRepo = userRepo;
        }
        public async Task<Result<bool>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                return Result<bool>.Failure("Fill in the missing requirements.");

            var newUser = _mapper.Map<User>(request);

            var createNewUser = await _userRepo.CreateUserAsync(newUser, cancellationToken);

            if (!createNewUser)
                return Result<bool>.Failure("User cannot be created.");

            return Result<bool>.SuccessWithMessage("User successfully created.");
        }
    }
}
