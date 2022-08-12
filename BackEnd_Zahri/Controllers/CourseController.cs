using AutoMapper;
using BackEnd.Zahri;
using BackEnd.Zahri.Interface;
using BackEnd_Zahri.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_Zahri.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourse _courseDAL;
        private readonly IMapper _mapper;

        public CourseController(ICourse courseDAL, IMapper mapper)
        {
            _courseDAL = courseDAL;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<CourseReadDTO>> Get()
        {
            var result = await _courseDAL.GetAll();
            var cDT = _mapper.Map<IEnumerable<CourseReadDTO>>(result);
            return cDT;
        }

        [HttpPost]
        public async Task<ActionResult> Post(CourseReadDTO courseCreate)

        {
            try
            {
                var newSword = _mapper.Map<Course>(courseCreate);
                var result = await _courseDAL.Insert(newSword);
                var readDto = _mapper.Map<CourseReadDTO>(result);

                return CreatedAtAction("Get", new { id = result.CourseID }, readDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpGet("{id}")]
        public async Task<CourseReadDTO> Get(int id)
        {
            var result = await _courseDAL.GetById(id);
            if (result == null)
                throw new Exception($"Data dengan id {id} tidak ditemukan");
            var cDT = _mapper.Map<CourseReadDTO>(result);
            return cDT;
        }

        [HttpPut]
        public async Task<ActionResult> Put(CourseReadDTO courseReadDTO)
        {
            try
            {
                var updateC = new Course
                {
                    CourseID = courseReadDTO.CourseID,
                    Title = courseReadDTO.Title,
                    Credits = courseReadDTO.Credits,
                };
                var result = await _courseDAL.Update(updateC);
                return Ok(courseReadDTO);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
        }

        [HttpGet("ByName")]
        public async Task<IEnumerable<CourseReadDTO>> GetByName(string name)
        {
            List<CourseReadDTO> cReadDTOs = new List<CourseReadDTO>();
            var result = await _courseDAL.GetByName(name);
            foreach (var re in result)
            {
                cReadDTOs.Add(new CourseReadDTO
                {
                    CourseID = re.CourseID,
                    Title = re.Title,
                    Credits = re.Credits
                    
                });
            }
            return cReadDTOs;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _courseDAL.DeleteById(id);
                return Ok($"Data Course dengan id {id} berhasil dihapus");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
        }

    }
}
