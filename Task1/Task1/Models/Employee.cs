namespace Task1.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }  // Khóa chính
        public string FullName { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }

        public ICollection<Account> Accounts { get; set; } // Mối quan hệ one-to-many với Account
    }

}
