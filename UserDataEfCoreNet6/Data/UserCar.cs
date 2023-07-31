using System;
using System.Text.Json.Serialization;

namespace UserDataEfCoreNet6.Data
{
    public class UserCar
    {
        public int UserId { get; set; }
        public int CarId { get; set; }

        [JsonIgnore]
        public User User { get; set; }
        public Car Car { get; set; }


    }
}

