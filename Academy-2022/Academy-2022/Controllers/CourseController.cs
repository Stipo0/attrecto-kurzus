using Academy_2022.Models;
using Academy_2022.Models.Dto;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Academy_2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {

        public static List<Course> _courses = new List<Course>()
        {
                new Course()
                {
                    Id = 1,
                    Name = "PHP",
                    Description = "backend",
                },

                new Course()
                {
                    Id = 2,
                    Name = "Angular",
                    Description = "frontend",
                },

                new Course()
                {
                    Id = 3,
                    Name = "React",
                    Description = "frontend",
                }
        };

        // GET: api/<CourseController>
        [HttpGet]
        public IEnumerable<Course> Get()
        {
            return _courses;
        }

        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        public ActionResult<Course> Get(int id)
        {
            foreach (Course course in _courses)
            {
                if (course.Id == id) 
                {
                    return course;
                }
            }

            return NotFound();
        }

        // POST api/<CourseController>
        [HttpPost]
        public ActionResult<Course> Post([FromBody] CourseDto course)
        {
            if (!ModelState.IsValid)
            { 
                return BadRequest(ModelState);
            }

            _courses.Add(new Models.Course
            {
                Id = course.Id,
                Name = course.Name,
                Description = course.Description
            });

            return Created("", course);
        }

        // PUT api/<CourseController>/5
        [HttpPut("{id}")]
        public ActionResult<Course> Put(int id, [FromBody] CourseDto course)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            for (int i = 0; i < _courses.Count; i++)
            {
                if (_courses[i].Id == id)
                {
                    _courses[i].Name = course.Name;
                    _courses[i].Description = course.Description;

                    return Ok(_courses[i]);
                }
            }

            return NotFound();
        }

        // DELETE api/<CourseController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            for (int i = 0; i < _courses.Count; i++)
            {
                if (_courses[i].Id == id)
                {
                    _courses.Remove(_courses[i]);
                    return NoContent();
                }
            }

            return NotFound();
        }
    }
}
