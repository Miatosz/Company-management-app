using System.Collections.Generic;
using angularApp.Models;

namespace angularApp.Repositories
{
    public interface IDepartmentRepo
    {
         IEnumerable<Department> Departments {get;}
         void SaveDepartment(Department department);
         Department DeleteDepartment(int departmentId);
         void SaveChanges();

    }
}