using RentalAttireBackend.Domain.Entities;

namespace RentalAttireBackend.Application.Employees.EmployeeDTOs
{
    public class EmployeeDTO
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
        public string FullName { get; set; } = "";
    }
}
