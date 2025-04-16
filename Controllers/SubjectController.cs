using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using school_holistic.DTOs;
using school_holistic.Repository.SubjectRepository;

namespace school_holistic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectRepo _repo;

        public SubjectController(ISubjectRepo repo)
        {
            _repo = repo;
        }
        [HttpPost("Add")]
        public IActionResult Add(SubjectPost subjectPost)
        {
            try
            {
                _repo.Add(subjectPost);
                return Ok();
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            try
            {
                var res = _repo.GetById(id);
                return Ok(res);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
