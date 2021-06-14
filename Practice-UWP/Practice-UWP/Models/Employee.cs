using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_UWP.Models
{
   
        public class Employee
        {
            public string name { get; set; }
            public string role { get; set; }
            public int birthyear { get; set; }
        }

        public class EmployeeList
        {
            public List<Employee> employee_list { get; set; }
        }
}

