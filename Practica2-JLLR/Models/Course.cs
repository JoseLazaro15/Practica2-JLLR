using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Practica2_JLLR.Models
{
    public class Course
    {
        [Key]
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public int DeparmentID { get; set; }
        [ForeignKey("DepartmentID")]

        public virtual Department Department { get; set; }
    }
}
