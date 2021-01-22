using System;
using angularApp.Data;
using angularApp.Models;
using angularApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace angularApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private IDepartmentRepo _repo;
        private AppDbContext _context;

        public DepartmentController(AppDbContext ctx, IDepartmentRepo repo)
        {
            _repo = repo;
            _context = ctx;
        }

        [HttpGet]
        public JsonResult Get() =>  
            new JsonResult(_context.Departments);

        [HttpPost]
        public JsonResult Post(Department department)
        {
            _repo.SaveDepartment(department);
            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(Department department)
        {
            _repo.SaveDepartment(department);
            return new JsonResult("Modified Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            _repo.DeleteDepartment(id);
            return new JsonResult("Deleted");
        }
        
    }
}