using Academy_2022.Models;
using Academy_2022.Models.Dto;
using Academy_2022.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Academy_2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;

        public CoursesController()
        {
            _courseRepository = new CourseRepository();
        }

        // GET: api/<CourseController>
        [HttpGet]
        public IEnumerable<Course> Get()
        {
            return _courseRepository.GetAll();
        }

        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        public ActionResult<Course> Get(int id)
        {
            var course = _courseRepository.GetbyId(id);
            if (course == null)
            {
                return NotFound();
            }

            return course;
        }

        // POST api/<CourseController>
        [HttpPost]
        public ActionResult<Course> Post([FromBody] CourseDto courseDto)
        {
            if (!ModelState.IsValid)
            { 
                return BadRequest(ModelState);
            }


            var course = _courseRepository.Create(courseDto);

            return Created("", course);
        }

        // PUT api/<CourseController>/5
        [HttpPut("{id}")]
        public ActionResult<Course> Put(int id, [FromBody] CourseDto courseDto)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            var course = _courseRepository.Update(id, courseDto);
            if (course == null)
            {
                return NotFound();
            }

            return course;
        }

        // DELETE api/<CourseController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return _courseRepository.Delete(id) ? NoContent() : NotFound();
        }
    }
}
