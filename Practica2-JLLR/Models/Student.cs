using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Practica2_JLLR.Models
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }
        public string LastName { get; set; }
        public string FirsMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }

    }
}
