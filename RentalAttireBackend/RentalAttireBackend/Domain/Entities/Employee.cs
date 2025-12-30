using RentalAttireBackend.Domain.Common;

namespace RentalAttireBackend.Domain.Entities
{
    public class Employee : BaseEntity
    {
        public string EmployeeCode { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string MiddleName { get; set; } = "";
        public string LastName { get; set; } = "";
        public Gender Gender { get; set; }
        public string PhoneNumber { get; set; } = "";
        public string Email { get; set; } = "";
        public int Age { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public string FullName
        {
            get { return $"{LastName}, {FirstName}"; }
        }
        public int RoleId { get; set; }

        //Nav Prop
        public Role Role { get; set; } = null!;
        public User User { get; set; } = null!;
        
    }

    public enum Gender
    {
        Male = 0,
        Female = 1,
        Others = 2
    }

    public enum MaritalStatus
    {
        Single = 0,
        Married = 1,
        Seperated = 2,
        Divorced = 3,
        Widowed = 4,
        Annulled = 5
    }
}
