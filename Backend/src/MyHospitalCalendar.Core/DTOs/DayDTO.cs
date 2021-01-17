using System;
using System.Collections.Generic;
using System.Text;

namespace MyHospitalCalendar.Core.DTOs
{
    public class DayDTO
    {
        public string DayName { get; set; }
        public bool IsDayOff { get; set; }
        public List<RoutineDTO> Routines { get; set; }
    }
}
