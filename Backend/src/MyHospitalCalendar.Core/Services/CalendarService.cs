using MyHospitalCalendar.Core.DTOs;
using MyHospitalCalendar.Core.Extensions;
using MyHospitalCalendar.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyHospitalCalendar.Core.Services
{
    public class CalendarService : ICalendarService
    {

        public List<ShiftTableDTO> CreateCalendar(WeekDTO week, List<PersonDTO> persons)
        {
            List<ShiftTableDTO> routines = new List<ShiftTableDTO>();
            WeekOutputDTO output = new WeekOutputDTO();
            foreach (DayDTO day in week.Days)
            {
                foreach (RoutineDTO routine in day.Routines)
                {
                    //As first thing build just the availability table, not considering max hours and so on.

                    List<PersonDTO> availableDocs = persons.Where(p => (p.NotAvailableDays.Any(y => y.DayNumber == day.DayNumber) == false ||
                                                                      (p.NotAvailableDays.Where(u => u.DayNumber == day.DayNumber)
                                                                                         .Any(r =>
                                                                                             r.Routines.Any(x => (x.DateStart < routine.DateEnd &&
                                                                                                                  routine.DateStart < x.DateEnd) == false) == false) == false)))
                                                            .ToList();

                    //Build the availability table
                    routines.Add(new ShiftTableDTO()
                    {
                        IsDayOff = day.IsDayOff,
                        DayName = day.DayName,
                        DayNumber = day.DayNumber,
                        ShiftStart = routine.DateStart,
                        ShiftEnd = routine.DateEnd,
                        AvailablePersons = availableDocs
                    });

                }
            }

            foreach (ShiftTableDTO shift in routines.Where(x=>x.IsDayOff==false).OrderBy(x=>x.ShiftStart))
            {
                var selected = ChoosePerson(shift, routines.Where(x => (x.ChoosenPerson != null || x.NoChoice == false) && 
                                                                 (x.ShiftStart > shift.ShiftStart))
                                                           .ToList());
                if (selected != null)
                {
                    shift.ChoosenPerson = selected;
                    selected.EffectiveHours += (shift.ShiftEnd - shift.ShiftStart).Hours;
                }
                else shift.NoChoice = true;
            }

            var dt = routines.ToDataTable(); //just for tests

            return routines;
        }

        private PersonDTO ChoosePerson(ShiftTableDTO shift, List<ShiftTableDTO> remainingShifts)
        {
            List<PersonOverlapsDTO> personOverlaps = new List<PersonOverlapsDTO>();
            //guardo solo coloro che non supererebbero le max hours
            foreach (var person in shift.AvailablePersons.Where(x => (x.EffectiveHours + (shift.ShiftEnd - shift.ShiftStart).Hours < x.MaxHours)))
            {
                PersonOverlapsDTO personOverlapsDTO = new PersonOverlapsDTO();
                personOverlapsDTO.Person = person;
                //quanti turni sovrapposti ha?
                foreach (var nextShift in remainingShifts)
                {
                    //overlappa?
                    if (nextShift.AvailablePersons.Contains(person))
                    {
                        //con quanti overlappa
                        var counter = nextShift.AvailablePersons.Where(x => x != person).Count();

                        personOverlapsDTO.ShiftOverlapping.Add(new ShiftOverlappingDTO()
                        {
                            Shift = nextShift,
                            WithMany = counter
                        });
                    }
                }
                personOverlaps.Add(personOverlapsDTO);
            }
            PersonOverlapsDTO dto = personOverlaps.OrderByDescending(x => x.ShiftOverlapping.Count())
                                 .ThenByDescending(y => y.ShiftOverlapping.Sum(z => z.WithMany))
                                 .ThenBy(z=>z.Person.EffectiveHours)
                                 .FirstOrDefault();
            return dto != null ? dto.Person : null;
        }
    }
}
