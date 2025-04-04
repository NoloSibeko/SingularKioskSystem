using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SingularKioskSystem.Data;
using SingularKioskSystem.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SingularKioskSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.Include(u => u.Wallet).ToListAsync();
        }

        // GET:User
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.Include(u => u.Wallet).FirstOrDefaultAsync(u => u.UserID == id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // POST:User
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(User user)
        {
            // input validation
            if (_context.Users.Any(u => u.Username == user.Username)) 
                return BadRequest("User already exists!");

            user.PasswordHash = HashPassword(user.PasswordHash);
            
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new {message = "User registered successfully."});
        }

        // POST:User
        [HttpPost("login")]
        public IActionResult Login ([FromBody] User loginRequest)
        {
            var user = _context.Users.SingleOrDefault(u => u.Username == loginRequest.Username);

            // input validation
           if (user == null || user.PasswordHash != HashPassword(loginRequest.PasswordHash))
                return Unauthorized("Invalid username or password.");

            return Ok(new { message = "Welcome Back!." });
        }

        private string HashPassword(string password) 
        { 
            // password hashing
                using var sha256 = SHA256.Create();
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }

        // PUT:User
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, User user)
        {
            if (id != user.UserID)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Users.Any(e => e.UserID == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE:User
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
