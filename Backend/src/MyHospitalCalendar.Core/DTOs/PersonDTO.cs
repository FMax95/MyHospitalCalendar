using System;
using System.Collections.Generic;
using System.Text;

namespace MyHospitalCalendar.Core.DTOs
{
    public class PersonDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal MaxHours { get; set; }
        public decimal EffectiveHours { get; set; }
        public List<DayDTO> NotAvailableDays { get; set; }
        public int OverlappingShiftCounter { get; set; }
    }
}
