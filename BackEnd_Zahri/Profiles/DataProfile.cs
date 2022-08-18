using AutoMapper;
using BackEnd.Zahri;
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

            CreateMap<Student, StudentDetailDTO>();

   
            CreateMap<Student, StudentWithCourseDTO>();

            //Course
            CreateMap<Course, CourseReadDTO>();
            CreateMap<CourseReadDTO, Course> ();

            CreateMap<Course, CourseWithStudentDTO>();

            
            //Enrollment
            CreateMap<Enrollment, EnrollmentReadDTO>();
            CreateMap<EnrollmentCreateDTO, Enrollment>();

            //di enr
            CreateMap<Enrollment, StudentTakeCourseDTO>();

            CreateMap<Enrollment, EnrReadDTO>();
            CreateMap<Enrollment, EnrollmentStudentDTO>();

            //di students
            CreateMap<Enrollment, EnrollmentCourseDTO>();


            
        }

    }
}
