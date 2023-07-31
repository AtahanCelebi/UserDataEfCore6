using System;
using UserDataEfCoreNet6.Models.Email;
using UserDataEfCoreNet6.Models.Phone;
using UserDataEfCoreNet6.Models.Car;

namespace UserDataEfCoreNet6.Models.User
{
	public class UserDto
	{
        public int Id { get; set; }
        public string? Name { get; set; }


        public List<PhoneDto>? Phones { get; set; }
        public EmailDto? Email { get; set; }
        public List<CarDto>? Cars { get; set; }
    }
}

