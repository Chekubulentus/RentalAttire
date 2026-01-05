using RentalAttireBackend.Application.Common.Models;
using RentalAttireBackend.Domain.Entities;

namespace RentalAttireBackend.Domain.Interfaces
{
    public interface IUserRepository
    {
        public Task<bool> CreateUserAsync(User request, CancellationToken token);
    }
}
