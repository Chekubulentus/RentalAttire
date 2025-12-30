using RentalAttireBackend.Domain.Common;

namespace RentalAttireBackend.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; } = "";
        public string HashedPassword { get; set; } = "";
        public int EmployeeId { get; set; }

        //Nav Prop
        public Employee Employee { get; set; } = null!;

    }
}
