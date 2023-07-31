using System;
namespace UserDataEfCoreNet6.Models.User
{
	public class UserResponseDto
	{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? EmailAddress { get; set; }
        public List<string>? Phones { get; set; }
        public List<string>? CarNames { get; set; }
    }
}

