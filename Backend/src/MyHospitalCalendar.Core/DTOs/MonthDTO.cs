using System;
using System.Collections.Generic;
using System.Text;

namespace MyHospitalCalendar.Core.DTOs
{
    public class MonthDTO
    {
        public int MonthNumber { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public List<RoutineDTO> Routines { get; set; }
    }
}
