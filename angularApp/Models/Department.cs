using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace angularApp.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        

        [JsonProperty(PropertyName = "DepartmentName")]
        public string Name { get; set; }


        // public List<Employee> Employees {get; set;}
    }
}