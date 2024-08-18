﻿namespace Task1.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int RoleEmployee { get; set; }
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }
    }
}
