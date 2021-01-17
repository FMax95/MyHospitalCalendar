using System;
using System.Collections.Generic;
using System.Text;

namespace MyHospitalCalendar.Core.DTOs
{
    public class ShiftTableDTO
    {
        public string DayName { get; set; }
        public int DayNumber { get; set; }
        public bool IsDayOff { get; set; }
        public DateTime ShiftStart { get; set; }
        public DateTime ShiftEnd { get; set; }
        public List<PersonDTO> AvailablePersons { get; set; }
        public object ChoosenPerson { get; set; }
    }
}
