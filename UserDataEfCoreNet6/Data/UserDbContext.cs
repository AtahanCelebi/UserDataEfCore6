using System;
using Microsoft.EntityFrameworkCore;
namespace UserDataEfCoreNet6.Data
{
	public class UserDbContext: DbContext
	{
		public UserDbContext(DbContextOptions options) : base(options)
		{
		}

        public DbSet<User> Users { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<UserCar> UserCars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserCar>().HasKey(q => new { q.UserId, q.CarId });

            modelBuilder.Entity<UserCar>()
                .HasOne(i => i.User)
                .WithMany(j => j.UserCars)
                .HasForeignKey(k => k.UserId);

            modelBuilder.Entity<UserCar>()
                .HasOne(i => i.Car)
                .WithMany(j => j.UserCars)
                .HasForeignKey(k => k.CarId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Phones)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Ata"
                },
                new User
                {
                    Id = 2,
                    Name = "Cem abi"
                },
                new User
                {
                    Id = 3,
                    Name = "Faruk abi"
                }

                );

            modelBuilder.Entity<Phone>().HasData(
                new Phone
                {
                    Id = 1,
                    PhoneNumber = "555 55 55",
                    UserId = 1
                },
                new Phone
                {
                    Id = 2,
                    PhoneNumber = "512355",
                    UserId = 1
                },
                new Phone
                {
                    Id = 3,
                    PhoneNumber = "33333",
                    UserId = 2
                },
                new Phone
                {
                    Id = 4,
                    PhoneNumber = "4444455",
                    UserId = 2
                },
                new Phone
                {
                    Id = 5,
                    PhoneNumber = "990900",
                    UserId = 3
                }
                );

            modelBuilder.Entity<Email>().HasData(
                new Email
                {
                    Id = 1,
                    EmailAddress = "ata@ata.com",
                    UserId = 1
                },
                new Email
                {
                    Id = 2,
                    EmailAddress = "deneme@outlook.com",
                    UserId = 2
                },
                new Email
                {
                    Id = 3,
                    EmailAddress = "info@gmail.com",
                    UserId = 3
                }
                );
        }

    }
}

