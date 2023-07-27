using System;
namespace UserDataEfCoreNet6.Models.Phone
{
	public class PhoneDto
	{
        public int Id { get; set; }
        public string? PhoneNumber { get; set; }

        public int? UserId { get; set; }
    }
}

