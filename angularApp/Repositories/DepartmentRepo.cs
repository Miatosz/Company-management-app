using System.Collections.Generic;
using System.Linq;
using angularApp.Data;
using angularApp.Models;

namespace angularApp.Repositories
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private AppDbContext _context;

        public DepartmentRepo(AppDbContext ctx)
        {
            _context = ctx;
        }

        public IEnumerable<Department> Departments => _context.Departments;


        public Department DeleteDepartment(int departmentId)
        {
            var dep = _context.Departments.Find(departmentId);
            if (dep != null)
            {
                _context.Remove(dep);
                _context.SaveChanges();
            }
                
            return dep;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void SaveDepartment(Department department)
        {
            if (department.Id == 0)
            {
                _context.Add(department);
            }
             else
            {
                Department newDepartment = _context.Departments.FirstOrDefault(c => c.Id == department.Id);
            
                if (newDepartment != null)
                {
                    newDepartment.Name = department.Name;
                }
            }
            _context.SaveChanges();
        }
    }
}