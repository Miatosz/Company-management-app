using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace angularApp.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfJoin { get; set; }
        public string PhotoFileName { get; set; }
        

        public int DepartmentId { get; set; }
        //[ForeignKey("DepartmentId")]
        public Department Department { get; set; }
    }
}