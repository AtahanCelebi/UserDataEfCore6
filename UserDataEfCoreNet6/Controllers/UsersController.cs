using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserDataEfCoreNet6.Data;
using UserDataEfCoreNet6.Models.User;
using UserDataEfCoreNet6.Models.Phone;
using UserDataEfCoreNet6.Models.Email;
using Mapster;
namespace UserDataEfCoreNet6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserDbContext _context;

        public UsersController(UserDbContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            //var user = await _context.Users.FindAsync(id);
            var user = await _context.Users.Include(q => q.Phones) //users dbset'e git phone listesini al ve idler eşleşiyorsa getir
                .Include(q => q.Email)
                .FirstOrDefaultAsync(q => q.Id == id);

            var userDto = new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Phones = user.Phones.Select(q => new PhoneDto
                {
                    PhoneNumber = q.PhoneNumber,
                }).ToList(),
                Email = new EmailDto
                {
                    Id = user.Email.Id,
                    EmailAddress = user.Email.EmailAddress
                }
                
            };
            return userDto 
;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id,UserDto userDto)
        {
            if (id != userDto.Id)
            {
                return BadRequest();
            }

            var user = userDto.Adapt<User>();
            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
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

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
