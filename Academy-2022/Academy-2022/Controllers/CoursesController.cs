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

        public CoursesController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        // GET: api/<CourseController>
        [HttpGet]
        public async Task<IEnumerable<Course>> GetAsync()
        {
            return await _courseRepository.GetAllAsync();
        }

        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetAsync(int id)
        {
            var course = await _courseRepository.GetbyIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            return course;
        }

        // POST api/<CourseController>
        [HttpPost]
        public async Task<ActionResult<Course>> Post([FromBody] CourseDto courseDto)
        {
            if (!ModelState.IsValid)
            { 
                return BadRequest(ModelState);
            }


            var course = await _courseRepository.CreateAsync(courseDto);

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
