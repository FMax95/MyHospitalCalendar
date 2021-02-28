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
        //TODO Flavio min hours during weekend
        //TODO Flavio min hours during night
        public decimal EffectiveHours { get; set; }
        public List<RoutineDTO> NotAvailableRoutines { get; set; }
        public int OverlappingShiftCounter { get; set; }
    }
}
