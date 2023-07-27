using System;
using AutoMapper;
using UserDataEfCoreNet6.Data;
using UserDataEfCoreNet6.Models.Email;
using UserDataEfCoreNet6.Models.Phone;
using UserDataEfCoreNet6.Models.User;
namespace UserDataEfCoreNet6.Configuration
{
	public class MapperConfig: Profile
	{
		public MapperConfig()
		{
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Phone, PhoneDto>().ReverseMap();
            CreateMap<Email, EmailDto>().ReverseMap();
        }
	}
}

