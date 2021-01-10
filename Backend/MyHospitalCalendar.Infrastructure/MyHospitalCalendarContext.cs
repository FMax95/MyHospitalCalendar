using Microsoft.EntityFrameworkCore;
using MyHospitalCalendar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace MyHospitalCalendar.Infrastructure
{
    public partial class MyHospitalCalendarContext : DbContext
    {
        public MyHospitalCalendarContext()
        {
        }

        public MyHospitalCalendarContext(DbContextOptions<MyHospitalCalendarContext> options)
            : base(options)
        {

        }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().HasData(new List<User>()
            {
                new User()
                { 
                    Id = 1 , 
                    FirstName="Flavio",
                    LastName = "Massimi",
                    Email="massimiflavio95@gmail.com",
                    CreationDate = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    Password =SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes("admin"))
                }
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}