using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using angularApp.Data;
using angularApp.Models;
using angularApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace angularApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeRepo _repo;
        private IDepartmentRepo _depRepo;
        private AppDbContext _context;

        public EmployeeController(AppDbContext ctx, IEmployeeRepo repo, IDepartmentRepo departmentRepo)
        {
            _repo = repo;
            _depRepo = departmentRepo;
            _context = ctx;
        }

        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(_context.Employess.Include(c => c.Department));
        } 
            

        [HttpPost]
        public JsonResult Post(Employee employee)
        {
            // employee.DepartmentId = _depRepo.Departments
            //     .FirstOrDefault(c => c.Name == employee.Department.Name).Id;
            Console.WriteLine(employee.Name);
            if (employee.Department.Name!=null)
            {
                employee.Department = _context.Departments.FirstOrDefault(c => c.Name == employee.Department.Name);
            } 
            else
            {
                employee.Department = _context.Departments.FirstOrDefault(c => c.Id == employee.DepartmentId);
            }

            _repo.SaveEmployee(employee);
            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(Employee employee)
        {
            Console.WriteLine(employee.Id);
            if (employee.Department.Name!=null)
            {
                employee.Department = _context.Departments.FirstOrDefault(c => c.Name == employee.Department.Name);
            } 
            else
            {
                employee.Department = _context.Departments.FirstOrDefault(c => c.Id == employee.DepartmentId);
            }
            _repo.SaveEmployee(employee);
            return new JsonResult("Modified Successfully");
        }

        [HttpPatch]
        public JsonResult Patch(Employee employee)
        {
            _repo.SaveEmployee(employee);
            return new JsonResult("Modified Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            _repo.DeleteEmployee(id);
            return new JsonResult("Deleted");
        }

        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {                
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = "wwwroot/Photos/" + filename;

                using(var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }
                
                return new JsonResult(filename);

            }
            catch (System.Exception)
            {                
                return new JsonResult("anonymous.png");
            }
        }

        [Route("GetAllDepartmentsName")]
        [HttpGet]
        public JsonResult GetAllDepartmentsName()
        {
            
            return new JsonResult((_context.Departments.Select(c => new {c.Id, c.Name})));
        }
            
    }
}