using Academy_2022.Models;
using Academy_2022.Models.Dto;
using Academy_2022.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Academy_2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<IEnumerable<User>> GetAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] UserDto userDto)
        {
            // INPUT VALIDATION
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userRepository.CreateAsync(userDto);

            return Created("", user);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public ActionResult<User> Put(int id, [FromBody] UserDto userDto)
        {
            // INPUT VALIDATION
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = _userRepository.Update(id, userDto);
            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return _userRepository.Delete(id) ? NoContent() : NotFound();
        }

        [HttpGet("test")]
        public void Test()
        {
            List<string> names = new List<string> { "Maggie", "Mary", "John", "Rick" };

            /*
            IEnumerable<string> namesQuery = from name in names
                                             where name[0] == 'M'
                                             select name;
            */

            var namesQuery = names.Where(name => name[0] == 'M');

            foreach (var name in namesQuery)
            {
                Console.WriteLine(name);
            }
             
            
        }

        /*Szorgalmi*/

        //Jelenleg nem létezik Age//

        /*[HttpGet("szorgalmi")]
        public IEnumerable Szorgalmi()
        {

            var users = _userRepository.GetAll().Where(user => user.Age > 18);

            return users;

        }
        */
    }
}