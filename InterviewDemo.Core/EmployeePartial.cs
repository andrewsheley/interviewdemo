using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewDemo.Core.Models
{
    public partial class Employee
    {
        public string FullName
        {
            get {
                return LastName + ", " + FirstName;
            }
        }

        public string FullAddress
        {
            get {
                return $"{StreetAddress1} {City}, {State} {Zip}";
            }
        }
    }
}
