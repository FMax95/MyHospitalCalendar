using System;
using System.Collections.Generic;
using System.Text;

namespace MyHospitalCalendar.Core.DTOs
{
    public class DayOutputDTO
    {
        public string DayName { get; set; }
        public int DayNumber { get; set; }
        public bool IsDayOff { get; set; }
        public List<RoutineOutputDTO> Routines { get; set; }
    }
}
