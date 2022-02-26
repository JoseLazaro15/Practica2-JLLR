using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Practica2_JLLR.Models
{
    public class OfficeAssignment
    {
        [Key]
        public int OfficeAssignmentID { get; set; }
        public int InstructorID { get; set; }
        [ForeignKey("InstructorID")]
        public string Location { get; set; }

        public virtual Instructor Instructor { get; set; }
    }
}
