using System.Collections.Generic;
using angularApp.Models;

namespace angularApp.Repositories
{
    public interface IEmployeeRepo
    {
         IEnumerable<Employee> Employees {get;}
         void SaveEmployee(Employee employee);
         Employee DeleteEmployee(int employeeId);
    }
}