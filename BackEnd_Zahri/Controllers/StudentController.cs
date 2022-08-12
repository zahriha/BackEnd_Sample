using AutoMapper;
using BackEnd.Zahri;
using BackEnd.Zahri.Interface;
using BackEnd_Zahri.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_Zahri.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudent _studentDAL;
        private readonly IMapper _mapper;

        public StudentController(IStudent studentDAL, IMapper mapper)
        {
            _studentDAL = studentDAL;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<StudentReadDTO>> Get()
        {
            var result = await _studentDAL.GetAll();
            var stuDT = _mapper.Map<IEnumerable<StudentReadDTO>>(result);
            return stuDT;
        }

        [HttpPost]
        public async Task<ActionResult> Post(StudentCreateDTO studentCreateDTO)

        {
            try
            {
                var newSword = _mapper.Map<Student>(studentCreateDTO);
                var result = await _studentDAL.Insert(newSword);
                var readDto = _mapper.Map<StudentReadDTO>(result);

                return CreatedAtAction("Get", new { id = result.ID }, readDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpGet("{id}")]
        public async Task<StudentReadDTO> Get(int id)
        {
            var result = await _studentDAL.GetById(id);
            if (result == null)
                throw new Exception($"Data dengan id {id} tidak ditemukan");
            var cDT = _mapper.Map<StudentReadDTO>(result);
            return cDT;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _studentDAL.DeleteById(id);
                return Ok($"Data Student dengan id {id} berhasil dihapus");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
        }

        [HttpPut]
        public async Task<ActionResult> Put(StudentReadDTO studentReadDTO)
        {
            try
            {
                var updateStu = new Student
                {
                    ID = studentReadDTO.ID,
                    FirstName = studentReadDTO.FirstName,
                    LastName = studentReadDTO.LastName,
                    EnrollmentDate = studentReadDTO.EnrollmentDate,
                };
                var result = await _studentDAL.Update(updateStu);
                return Ok(studentReadDTO);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
        }

        [HttpGet("ByName")]
        public async Task<IEnumerable<StudentReadDTO>> GetByName(string name)
        {
            List<StudentReadDTO> studentReadDTOs = new List<StudentReadDTO>();
            var result = await _studentDAL.GetByName(name);
            foreach (var re in result)
            {
                studentReadDTOs.Add(new StudentReadDTO
                {
                    ID = re.ID,
                    FirstName = re.FirstName,
                    LastName = re.LastName,
                    EnrollmentDate = re.EnrollmentDate
                });
            }
            return studentReadDTOs;
        }
    }
}
