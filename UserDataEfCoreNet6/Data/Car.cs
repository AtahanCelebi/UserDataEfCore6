﻿using System;
namespace UserDataEfCoreNet6.Data
{
	public class Car
	{
		public int Id { get; set; }
		public string CarName { get; set; }
		public List<User> Users { get; set; }
	}
}
