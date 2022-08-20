using AutoMapper;
using BackEnd.Zahri;
using BackEnd.Zahri.Interface;
using BackEnd_Zahri.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_Zahri.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollment _enrollmentDAL;
        private readonly IMapper _mapper;

        public EnrollmentController(IEnrollment enrollmentDAL, IMapper mapper)
        {
            _enrollmentDAL = enrollmentDAL;
            _mapper = mapper;
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll(int page)
        {
            var result = await _enrollmentDAL.GetAll();
            List<EnrollmentReadDTO> enrollments = new List<EnrollmentReadDTO>();

            foreach (var re in result)
            {
                EnrollmentReadDTO enr = new EnrollmentReadDTO();
                enr.EnrollmentID = re.EnrollmentID;
                enr.Grade = re.Grade;
                enr.CourseID = re.CourseID;
                enr.StudentID = re.StudentID;
                enr.CourseTitle = re.Course.Title;
                enr.StudentName = $"{re.Student.FirstName} {re.Student.LastName}";
                enrollments.Add(enr);
            }

            var enDT = enrollments.Skip((page - 1) * 10).Take(5).ToList();
            if (enDT.Count > 0)
            {
                enDT[0].TotalPage = Math.Ceiling((decimal)result.Count() / (decimal)5);
            }
            return Ok(enDT);
        }

        [HttpPost]
        public async Task<ActionResult> Post(EnrollmentCreateDTO enrollmentCreateDTO)

        {
            try
            {
                var newEn = _mapper.Map<Enrollment>(enrollmentCreateDTO);
                var result = await _enrollmentDAL.Insert(newEn);
                var readDto = _mapper.Map<EnrollmentReadDTO>(result);

                return CreatedAtAction("Get", new { id = result.EnrollmentID }, readDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpGet("{id}")]
        public async Task<EnrollmentReadDTO> Get(int id)
        {
            var result = await _enrollmentDAL.GetById(id);
            if (result == null)
                throw new Exception($"Data dengan id {id} tidak ditemukan");
            var cDT = _mapper.Map<EnrollmentReadDTO>(result);
            return cDT;
        }

        [HttpPut]
        public async Task<ActionResult> Put(EnrollmentReadDTO enrollmentReadDTO)
        {
            try
            {
                var updateEn = new Enrollment
                {
                    EnrollmentID = enrollmentReadDTO.EnrollmentID,
                    CourseID = enrollmentReadDTO.CourseID,
                    StudentID = enrollmentReadDTO.StudentID,
                    Grade = enrollmentReadDTO.Grade,
                };
                var result = await _enrollmentDAL.Update(updateEn);
                return Ok(enrollmentReadDTO);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _enrollmentDAL.DeleteById(id);
                return Ok($"Data enrollment dengan id {id} berhasil dihapus");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
        }
    }
}
