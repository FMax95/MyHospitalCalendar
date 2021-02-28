using System;
using System.Collections.Generic;
using System.Text;

namespace MyHospitalCalendar.Core.DTOs
{
    public class ShiftTableDTO
    {
        public ShiftTableDTO() 
        {
            //this.NoChoice = true;
        }
        public DateTime Date { get; set; }
        public DateTime ShiftStart { get; set; }
        public DateTime ShiftEnd { get; set; }
        public List<PersonDTO> AvailablePersons { get; set; }
        public string ChoosenPerson { get; set; }
        public bool NoChoice { get; set; }
    }
}
