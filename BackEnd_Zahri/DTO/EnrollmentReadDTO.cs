
using BackEnd.Zahri;

namespace BackEnd_Zahri.DTO
{
    public class EnrollmentReadDTO
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public Grade? Grade { get; set; }
        public decimal TotalPage { get; set; }
        public string StudentName { get; set; }
        public string CourseTitle { get; set; }
        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}
