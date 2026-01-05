using RentalAttireBackend.Application.Common.Models;
using RentalAttireBackend.Domain.Entities;
using RentalAttireBackend.Domain.Interfaces;
using RentalAttireBackend.Infrastracture.Persistence.DataContext;

namespace RentalAttireBackend.Infrastracture.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly RentalAttireContext _context;
        public UserRepository
            (
            RentalAttireContext context
            )
        {
            _context = context;
        }

        public async Task<bool> CreateUserAsync(User request, CancellationToken token)
        {
            await _context.Users.AddAsync(request);
            await _context.SaveChangesAsync(token);
            return true;
        }
    }
}
