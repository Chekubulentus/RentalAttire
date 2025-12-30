using RentalAttireBackend.Domain.Common;

namespace RentalAttireBackend.Domain.Entities
{
    public class Role : BaseEntity
    {
        public string RoleCode { get; set; } = "";
        public RolePosition RolePosition { get; set; }

        //Nav Prop
        public List<Employee> Employees { get; set; } = new();
    }

    public enum RolePosition
    {
        Administrator = 0,
        ClothesManager = 1,
        Cashier = 2
    }
}
