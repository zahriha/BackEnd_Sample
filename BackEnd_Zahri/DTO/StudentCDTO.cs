namespace BackEnd_Zahri.DTO
{
    public class StudentCDTO
    {
        public int StudentID { get; set; }
        public ICollection<EnrollmentCourseDTO> Enrollments { get; set; }

    }

}
