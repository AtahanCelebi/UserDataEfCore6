using System;
using UserDataEfCoreNet6.Models.Email;
using UserDataEfCoreNet6.Models.Phone;

namespace UserDataEfCoreNet6.Models.User
{
	public class UserDto
	{
        public int Id { get; set; }
        public string? Name { get; set; }


        public List<PhoneDto>? Phones { get; set; }
        public EmailDto? Email { get; set; }
    }
}

