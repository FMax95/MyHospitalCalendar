﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MyHospitalCalendar.Core.DTOs
{
    public class WeekDTO
    {
        public int WeekNumber { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }    
        public List<DayDTO> Days { get; set; }
    }
}
