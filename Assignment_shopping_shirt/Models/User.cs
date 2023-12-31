﻿namespace Assignment_shopping_shirt.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public Guid RoleId { get; set; }
        public string Password { get; set; }
        public int Status { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public virtual Role Role { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual List<Bill> Bills { get; set; }
    }
}
