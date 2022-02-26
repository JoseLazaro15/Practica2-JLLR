using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Practica2_JLLR.Models
{
    public class CourseAssigment
    {
        [Key]
        public int CourseAssigmentID { get; set; }
        public int CourseID { get; set; }
        [ForeignKey("CourseID")]
        public virtual Course Course { get; set; }
        public int InstructorID { get; set; }
        [ForeignKey("InstructorID")]
        public virtual Instructor Instructor { get; set; }


    }
}
