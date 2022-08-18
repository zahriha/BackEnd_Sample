namespace BackEnd_Zahri.DTO
{
    public class StudentDetailDTO
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public ICollection<EnrReadDTO> Enrollments { get; set; }
    }
}
