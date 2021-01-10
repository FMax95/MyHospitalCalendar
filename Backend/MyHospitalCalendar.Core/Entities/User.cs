using System;
using System.Collections.Generic;

namespace MyHospitalCalendar.Core.Entities
{
    public partial class User
    {
        public User()
        {

        }

        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreationDate { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }
    }
}