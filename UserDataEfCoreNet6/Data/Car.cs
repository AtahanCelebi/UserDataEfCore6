using System;
using System.Text.Json.Serialization;

namespace UserDataEfCoreNet6.Data
{
	public class Car
	{
		public int Id { get; set; }
		public string? CarName { get; set; }
        [JsonIgnore]
        public List<UserCar>? UserCars { get; set; }
	}
}

