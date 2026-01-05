namespace RentalAttireBackend.Application.Users.UserDTOs
{
    public class UserDTO
    {
        public string Username { get; set; } = "";
        public string HashedPassword { get; set; } = "";
        public int EmployeeId { get; set; } 
    }
}
