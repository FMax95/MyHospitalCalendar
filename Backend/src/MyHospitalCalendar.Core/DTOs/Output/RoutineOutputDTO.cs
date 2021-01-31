using System;
using System.Collections.Generic;
using System.Text;

namespace MyHospitalCalendar.Core.DTOs
{
    public class RoutineOutputDTO
    {
        public TimeSpan DateStart { get; set; }
        public TimeSpan DateEnd { get; set; }
        public PersonDTO Person { get; set; }
    }
}
