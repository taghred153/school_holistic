using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using school_holistic.DTOs;
using school_holistic.Repository.StudentRepository;

namespace school_holistic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepo _repo;

        public StudentController(IStudentRepo repo)
        {
            _repo = repo;
        }
        [HttpPost("Add")]
        public IActionResult Add(StudentPost studentPost)
        {
            try
            {
                _repo.Add(studentPost);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
       [HttpGet("GetAll")]
       public IActionResult GetAll()
        {
            try
            {
                var res = _repo.GetAll();
                return Ok(res);
            }
            catch
            {
                return NotFound();
            }
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            try
            {
                _repo.Delete(id);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }
        [HttpPut("Update")]
        public IActionResult Update(StudentUpdate studentUpdate, int id)
        {
            try
            {
                _repo.Update(studentUpdate, id);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
