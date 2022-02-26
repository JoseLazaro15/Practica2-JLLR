using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Practica2_JLLR.Models
{
    public class Instructor
    {
        [Key]
        public int InstructorID { get; set; }
        public String LastName { get; set; }
        public String FirstMidName { get; set; }
        public DateTime HireDate { get; set; }
    }
}
