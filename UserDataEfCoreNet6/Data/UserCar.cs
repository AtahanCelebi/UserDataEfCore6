using System;
namespace UserDataEfCoreNet6.Data
{
    public class UserCar
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}

