using System.Collections.Generic;
using APICRUD.Models;
using System;
namespace APICRUD.EmployeeData
{
    public interface IEmployeeData
    {
        List<Employee> GetEmployees();
        Employee GetEmployee(Guid id);
        Employee AddEmployee(Employee employee);
        Employee UpdateEmployee(Employee employee);
        void DeleteEmployee(Employee employee);
    }
}
