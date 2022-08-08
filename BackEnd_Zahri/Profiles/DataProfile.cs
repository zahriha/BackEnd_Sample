using AutoMapper;
using BackEnd.Domain;
using BackEnd_Zahri.DTO;

namespace BackEnd_Zahri.Profiles
{
    public class DataProfile :Profile
    {
        public DataProfile()
        {
            //student
            CreateMap<Student, StudentReadDTO>();
            CreateMap<StudentCreateDTO, Student>();


            //Course
            CreateMap<Course, CourseReadDTO>();
            CreateMap<CourseReadDTO, Course> ();


            //Enrollment
            CreateMap<Enrollment, EnrollmentReadDTO>();
            CreateMap<EnrollmentCreateDTO, Enrollment>();

        }

    }
}
