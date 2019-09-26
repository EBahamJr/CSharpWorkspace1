using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Contracts.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly TodoContext _context;

        public UserController(TodoContext context)
        {
            _context = context;

            if (_context.Users.Count() == 0)
            {
                // Create a new User if collection is empty,
                // which means you can't delete all Users.
                _context.Users.Add(new User
                {
                    UserId = 1,
                    FirstName = "John",
                    LastName = "Wick",
                    Email = "J0nhW1ck100@gmail.com"
                }) ;

                _context.SaveChanges();
            }
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/User/5
        [HttpGet("{userId}")]
        public async Task<ActionResult<User>> GetUser(int userId)
        {
            var Users = await _context.Users.FindAsync(userId);

            if (Users == null)
            {
                return NotFound();
            }

            return Users;
        }

        // POST: api/User
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { userId = user.UserId }, user);
        }

        // PUT: api/User/5
        [HttpPut("{userId}")]
        public async Task<IActionResult> PutTodoItem(int userId, User user)
        {
            if (userId != user.UserId)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Todo/5
        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteTodoItem(int userId)
        {
            var User = await _context.Users.FindAsync(userId);

            if (User == null)
            {
                return NotFound();
            }

            _context.Users.Remove(User);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}