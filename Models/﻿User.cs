using PIS.Models.Enums;
using System;

namespace PIS.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; } = UserRole.Landlord;
        public bool Online { get; set; }
        public DateTime LastActivity { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}