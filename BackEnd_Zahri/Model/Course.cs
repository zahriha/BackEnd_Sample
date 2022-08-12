using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Zahri
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int CourseID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        public int Credits { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }

    }
}
