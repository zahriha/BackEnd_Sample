using BackEnd.Zahri;

namespace BackEnd_Zahri.DTO
{
    public class EnrollmentStudentDTO
    {
        public int EnrollmentID { get; set; }
        public Grade Grade { get; set; }
        public StudentReadDTO Student { get; set; }
    }
}
