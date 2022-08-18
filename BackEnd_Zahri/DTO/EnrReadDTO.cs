using BackEnd.Zahri;

namespace BackEnd_Zahri.DTO
{
    public class EnrReadDTO
    {
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}
