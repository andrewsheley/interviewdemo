using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InterviewDemo.Core.Models
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "Max length 15")]
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string StreetAddress1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string PhoneNumber { get; set; }
    }
}
