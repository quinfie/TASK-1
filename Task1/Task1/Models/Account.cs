using Task1.Models;

namespace Task1.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? RoleEmployee { get; set; }  // RoleEmployee: 0 = User, 1 = Admin

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}