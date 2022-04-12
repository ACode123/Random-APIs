using System.Threading.Tasks;
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICRUD.Models
{
    //employee properties
    public class Employee
    {
        //creates a randomly generated ID for the employee and uses it as the key in the database
        [Key]
        public Guid Id { get; set; }   
        [Required]
        [MaxLength(50, ErrorMessage ="Name can only be 50 characters")]
        public string Name { get; set; }
    }
}
