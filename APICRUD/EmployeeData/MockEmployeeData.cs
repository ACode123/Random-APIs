using APICRUD.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using APICRUD.EmployeeData;


namespace APICRUD.EmployeeData
{
    public class MockEmployeeData : IEmployeeData
    {
        private List<Employee> employees = new List<Employee>()
        {
            new Employee()
            {
            Id = Guid.NewGuid(),
            Name = "Billy"
            },
            new Employee()
            {
                Id=Guid.NewGuid(),
                Name="Bob"
            }
        };
        public Employee AddEmployee(Employee employee)
        {
            employee.Id = employee.Id; 
            employees.Add(employee);
            return employee;
        }

        public void DeleteEmployee(Employee employee)
        {
            employees.Remove(employee);
        }

        public Employee GetEmployee(Guid id)
        {
            return employees.SingleOrDefault(x =>x.Id == id);
        }

        public List<Employee> GetEmployees()
        {
           return employees;
        }

        public Employee UpdateEmployee(Employee employee)
        {
            var existingemployee=GetEmployee(employee.Id);
            existingemployee.Name = employee.Name;
            return existingemployee;
        }
    }
}
