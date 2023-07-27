using System;
using UserDataEfCoreNet6.Models.User;

namespace UserDataEfCoreNet6.Models.Email
{
	public class EmailDto
	{
        public int Id { get; set; }
        public string? EmailAddress { get; set; }

        public UserDto? User { get; set; }
    }
}

