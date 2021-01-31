using MyHospitalCalendar.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHospitalCalendar.Core.Services.Interfaces
{
    public interface ICalendarService
    {
        List<ShiftTableDTO> CreateCalendar(WeekDTO week, List<PersonDTO> persons);
    }
}
