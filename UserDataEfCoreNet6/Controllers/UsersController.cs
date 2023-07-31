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
using UserDataEfCoreNet6.Models.Car;
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
            var user = await _context.Users
                .Include(q => q.Phones)
                .Include(q => q.Email)
                .Include(q => q.UserCars) // Include the UserCars navigation property
                .ThenInclude(uc => uc.Car) // Include the Car navigation property inside UserCars
                .FirstOrDefaultAsync(q => q.Id == id);

            if (user == null)
            {
                return NotFound();
            }

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
                },
                Cars = user.UserCars.Select(uc => new CarDto
                {
                    CarName = uc.Car.CarName
                }).ToList()
            };

            return userDto;
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

            var user = await _context.Users.FindAsync(id);

            if(user == null)
            {
                return NotFound();
            }

            if(!string.IsNullOrEmpty(userDto.Name))//yanlızca degisen ögeler içn
            {
                user.Name = userDto.Name;
            }

            if(userDto.Phones !=null && userDto.Phones.Any())
            {
                var phoneIds = userDto.Phones.Select(q => q.Id);
                user.Phones.RemoveAll(q => !phoneIds.Contains(q.Id));


                foreach(var phoneDto in userDto.Phones)
                {
                    var phone = user.Phones.FirstOrDefault(q => q.Id == phoneDto.Id);
                    if(phone ==null)
                    {
                        phone = new Phone();
                        user.Phones.Add(phone);
                    }
                    phone.PhoneNumber = phoneDto.PhoneNumber;
                }
            }

            if(userDto.Email !=null)
            {
                if(user.Email==null)
                {
                    user.Email = new Email();
                }
                user.Email.EmailAddress = userDto.Email.EmailAddress;
            }


            await _context.SaveChangesAsync();

            return Ok(new { message = "Kullanıcı başarıyla güncellendi" });
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(UserDto userDto)
        {
            if (userDto == null)
            {
                return BadRequest("User data is missing.");
            }

            var user = new User
            {
                Name = userDto.Name,
                Phones = userDto.Phones?.Select(p => new Phone { PhoneNumber = p.PhoneNumber }).ToList(),
                Email = userDto.Email != null ? new Email { EmailAddress = userDto.Email.EmailAddress } : null,
            };

            if (userDto.Cars != null && userDto.Cars.Any())
            {
                foreach (var carDto in userDto.Cars)
                {
                    var car = new Car { CarName = carDto.CarName };
                    user.UserCars.Add(new UserCar { Car = car });
                }
            }

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
