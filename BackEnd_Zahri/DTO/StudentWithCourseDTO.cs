namespace BackEnd_Zahri.DTO
{
    public class StudentWithCourseDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime EnrollmentDate { get; set; }
        public ICollection<EnrollmentCourseDTO> Enrollments { get; set; }

    }
}
