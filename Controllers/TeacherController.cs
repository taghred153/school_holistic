using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using school_holistic.DTOs;
using school_holistic.Repository.TeacherRepository;

namespace school_holistic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherRepo _reapo;

        public TeacherController(ITeacherRepo repo)
        {
            _reapo = repo;
        }
        [HttpPost("Add")]
        public IActionResult Add(TeacherPost teacherPost)
        {
            try
            {
                _reapo.Add(teacherPost);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
