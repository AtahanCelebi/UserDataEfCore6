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
        public async Task<ActionResult<IEnumerable<UserResponseDto>>> GetUsers()
        {
            var users = await _context.Users
                .Include(q => q.Phones)
                .Include(q => q.Email)
                .Include(q => q.UserCars).ThenInclude(i => i.Car)
                .ToListAsync();

            var userDtos = users.Select(user => new UserResponseDto
            {
                Id = user.Id,
                Name = user.Name,
                EmailAddress = user.Email?.EmailAddress,
                Phones = user.Phones?.Select(q => q.PhoneNumber).ToList(),
                CarNames = user.UserCars?.Select(q => q.Car.CarName).ToList()
            }).ToList();

            return userDtos;
        }


        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponseDto>> GetUser(int id)
        {
            var user = await _context.Users.Include(q => q.Phones)
                .Include(q => q.Email)
                .Include(q => q.UserCars).ThenInclude(i => i.Car)
                .FirstOrDefaultAsync(q => q.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            var userResponseDto = new UserResponseDto
            {
                Id = user.Id,
                Name = user.Name,
                EmailAddress = user.Email?.EmailAddress,
                Phones = user.Phones?.Select(q => q.PhoneNumber).ToList(),
                CarNames = user.UserCars?.Select(q => q.Car.CarName).ToList()
            };

            return userResponseDto;

        }
        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UserResponseDto userPutDto)
        {
            if (id != userPutDto.Id)
            {
                return BadRequest();
            }

            var user = await _context.Users
                .Include(q => q.Phones)
                .Include(q => q.Email)
                .Include(q => q.UserCars).ThenInclude(i => i.Car)
                .FirstOrDefaultAsync(j => j.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(userPutDto.Name))
            {
                user.Name = userPutDto.Name;
            }

            if (userPutDto.Phones?.Any() == true)
            {
                // Remove phones that are not in the updated list
                var phoneNumbers = userPutDto.Phones.ToList();
                user.Phones.RemoveAll(q => !phoneNumbers.Contains(q.PhoneNumber));

                // Update existing phones or add new ones
                foreach (var phoneNumber in phoneNumbers)
                {
                    var phone = user.Phones.FirstOrDefault(q => q.PhoneNumber == phoneNumber);
                    if (phone == null)
                    {
                        phone = new Phone { PhoneNumber = phoneNumber };
                        user.Phones.Add(phone);
                    }
                }
            }

            if (userPutDto.EmailAddress != null)
            {
                if (user.Email == null)
                {
                    user.Email = new Email();
                }
                user.Email.EmailAddress = userPutDto.EmailAddress;
            }
            else
            {
                user.Email = null;
            }


            if (userPutDto.CarNames?.Any() == true)
            {
                // Remove cars that are not in the updated list
                var carNames = userPutDto.CarNames.ToList();
                user.UserCars.RemoveAll(q => !carNames.Contains(q.Car.CarName));

                // Update existing cars or add new ones
                foreach (var carName in carNames)
                {
                    var userCar = user.UserCars.FirstOrDefault(q => q.Car.CarName == carName);
                    if (userCar == null)
                    {
                        var car = new Car { CarName = carName };
                        user.UserCars.Add(new UserCar { Car = car });
                    }
                }
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
