using InterviewDemo.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewDemo.Core.Models
{
    public static class ExtensionMethods
    {
        public static string Fullname(this Employee employee)
        {
            return $"{employee.LastName}, {employee.FirstName}";
        }

        public static string FullAddress(this Employee employee)
        {
            return $"{employee.StreetAddress1} {employee.City}, {employee.State} {employee.Zip}";
        }
    }
}
