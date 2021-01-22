using System.Collections.Generic;
using System.Linq;
using angularApp.Data;
using angularApp.Models;

namespace angularApp.Repositories
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private AppDbContext _context;

        public EmployeeRepo(AppDbContext ctx)
        {
            _context = ctx;
        }

        public IEnumerable<Employee> Employees => _context.Employess;

        public Employee DeleteEmployee(int employeeId)
        {
            
            var employee = _context.Employess.Find(employeeId);
            if (employee != null)
            {
                _context.Remove(employee);
                _context.SaveChanges();
            }
                
            return employee;
        }

        public void SaveEmployee(Employee employee)
        {
            if (employee.Id == 0)
            {
                //employee.Department.Name = _context.Departments.FirstOrDefault(c => c.Id == employee.Department.Id).Name;
                _context.Add(employee);
            }
             else
            {
                Employee newEmployee = _context.Employess.FirstOrDefault(c => c.Id == employee.Id);
            
                if (newEmployee != null)
                {
                    newEmployee.Name = employee.Name;
                    newEmployee.PhotoFileName = employee.PhotoFileName;
                    newEmployee.DepartmentId = employee.DepartmentId;
                    newEmployee.Department = employee.Department;
                    newEmployee.DateOfJoin = employee.DateOfJoin;
                }
            }
            _context.SaveChanges();
        }

        
    }
}