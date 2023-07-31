using System;
using UserDataEfCoreNet6.Models.User;
namespace UserDataEfCoreNet6.Models.Car
{
	public class CarDto
	{
        public int Id { get; set; }
        public string? CarName { get; set; }

        public List<UserDto>? Users { get; set; }
    }
}


