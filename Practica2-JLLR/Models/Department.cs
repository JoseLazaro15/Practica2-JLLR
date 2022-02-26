using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Practica2_JLLR.Models
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }
        public string Name { get; set; }
        public float Budget { get; set; }
        public DateTime StartDate { get; set; }
        public int InstructorID { get; set; }
        [ForeignKey("InstructorID")]

        public virtual Instructor Instructor { get; set; }

    }
}
