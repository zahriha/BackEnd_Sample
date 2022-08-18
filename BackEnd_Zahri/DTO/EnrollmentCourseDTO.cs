using BackEnd.Zahri;

namespace BackEnd_Zahri.DTO
{
    public class EnrollmentCourseDTO
    {
        public int EnrollmentID { get; set; }
        public Grade Grade { get; set; }
        public CourseReadDTO Course { get; set; }

    }
}
