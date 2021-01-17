using MyHospitalCalendar.Core.DTOs;
using MyHospitalCalendar.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyHospitalCalendar.Core.Services
{
    public class CalendarService : ICalendarService
    {

        public void CreateCalendar(WeekDTO week, List<PersonDTO> persons)
        {
            foreach (DayDTO day in week.Days)
            {
                foreach (RoutineDTO routine in day.Routines)
                {
                    //(All the persons that has not an availability for the day OR
                    //Has an anavailabilty for the day but it doesn't overlap this routine) AND
                    //Has not reached the maxHours or this routine will cause to reach the max hours
                    //TODO consider also minutes
                    List<PersonDTO> availableDocs = persons.Where(p => //(p.EffectiveHours + (routine.DateEnd.Hours - routine.DateStart.Hours) < p.MaxHours) &&
                                                                      (p.NotAvailableDays.Any(y => y.DayNumber == day.DayNumber) == false ||
                                                                      (p.NotAvailableDays.Where(u => u.DayNumber == day.DayNumber)
                                                                                         .Any(r =>
                                                                                             r.Routines.Any(x => (x.DateStart < routine.DateEnd &&
                                                                                                                  routine.DateStart < x.DateEnd) == false) == false) == false)))
                                                            .ToList();

                    //Build the availability table
                    ShiftTableDTO shiftTable = new ShiftTableDTO()
                    {
                        IsDayOff = day.IsDayOff,
                        DayName = day.DayName,
                        DayNumber = day.DayNumber,
                        ShiftStart = new DateTime(1, 1, day.DayNumber, routine.DateStart.Hours, routine.DateStart.Minutes, 1),
                        ShiftEnd = new DateTime(1, 1, day.DayNumber, routine.DateEnd.Hours, routine.DateEnd.Minutes, 1),
                        AvailablePersons = availableDocs
                    };

                }
            }

        }
    }
}
