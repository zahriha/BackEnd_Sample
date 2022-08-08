using BackEnd.Domain;

namespace BackEnd_Zahri.DTO
{
    public class EnrollmentReadDTO
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public Grade? Grade { get; set; }
    }
}
