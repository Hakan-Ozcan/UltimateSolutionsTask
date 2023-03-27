using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Employee
    {
        [Key]
        public short Id { get; set; }


        [Required, MinLength(1, ErrorMessage = "{0} must be at least 1 characters"),
           MaxLength(20, ErrorMessage = "{0} must be a maximum of 20 characters")] 
        public string? Name { get; set; }


        [Required, MinLength(1, ErrorMessage = "{0} must be at least 1 characters"),
          MaxLength(20, ErrorMessage = "{0} must be a maximum of 20 characters")]   
        public string? Surname { get; set; }

      
        [DataType(DataType.Date)]
        [Required]
        public DateTime Birthday { get; set; } = DateTime.Now.Date;


        [Required]
        public short Age { get; set; }


        [Required]
        [StringLength(200)]
        public string? Adress { get; set; }
    }
}
