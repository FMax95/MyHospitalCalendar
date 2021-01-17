using System;
using System.Collections.Generic;
using System.Text;

namespace MyHospitalCalendar.Core.DTOs
{
    public class PersonDTO
    {
        public string Name { get; set; }
        public decimal MaxHours { get; set; }
        public List<DayDTO> NotAvailableDays { get; set; }
    }
}
