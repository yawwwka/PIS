using PIS.Models.Enums;
using System;

namespace PIS.Models
{
    public class UserApplication
    {
        public int Id { get; set; }
        public string OwnerEmail { get; set; }
        public string OwnerName { get; set; }
        public string OwnerPassport { get; set; }
        public string Address { get; set; }
        public string MigrantName { get; set; }
        public string MigrantPassport { get; set; }
        public string VisaNumber { get; set; }
        public string MigrationCard { get; set; }
        public ApplicationStatus Status { get; set; } = ApplicationStatus.Pending;
        public DateTime CreateTime { get; set; }
    }
}
