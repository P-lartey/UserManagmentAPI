using Microsoft.AspNetCore.Mvc;
using YourApp.Services; // Adjust this namespace to your actual service
using YourApp.Models;    // Adjust this namespace to your actual model

namespace YourApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/user
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }

        // POST: api/user
        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            if (user == null)
                return BadRequest("User data is required.");

            var newUser = _userService.CreateUser(user);
            return CreatedAtAction(nameof(GetUsers), new { id = newUser.Id }, newUser);
        }

        // PUT: api/user/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User user)
        {
            if (user == null)
                return BadRequest("User data is required.");

            var updatedUser = _userService.UpdateUser(id, user);
            if (updatedUser == null)
                return NotFound("User not found.");
            
            return Ok(updatedUser);
        }

        // DELETE: api/user/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var result = _userService.DeleteUser(id);
            if (!result)
                return NotFound("User not found.");
            
            return NoContent();
        }
    }
}
