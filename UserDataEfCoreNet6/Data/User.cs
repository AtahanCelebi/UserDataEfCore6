using System;
namespace UserDataEfCoreNet6.Data
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public virtual List<Phone>? Phones { get; set; }
        public virtual Email? Email { get; set; }
        public List<UserCar>? UserCars { get; set; } = new List<UserCar>(); // Burada UserCars özelliğini başlatıyoruz
    }
}
