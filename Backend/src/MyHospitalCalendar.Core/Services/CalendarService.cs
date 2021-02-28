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

        public List<ShiftTableDTO> CreateCalendar(MonthDTO month, List<PersonDTO> persons)
        {
            List<ShiftTableDTO> routines = new List<ShiftTableDTO>();
            WeekOutputDTO output = new WeekOutputDTO();
            foreach (RoutineDTO routine in month.Routines)
            {
                //As first thing build just the availability table, not considering max hours and so on.

                List<PersonDTO> availableDocs = persons.Where(p => p.NotAvailableRoutines.Any(r => (r.DateStart < routine.DateEnd &&
                                                                                                routine.DateStart < r.DateEnd)) == false)
                                                        .ToList();

                //Build the availability table
                routines.Add(new ShiftTableDTO()
                {
                    Date = routine.DateStart.Date,
                    ShiftStart = routine.DateStart,
                    ShiftEnd = routine.DateEnd,
                    AvailablePersons = availableDocs
                });

            }

            List<ShiftTableDTO> startingPoint = routines;
            int recursivityLevel = -1;
            while ((routines.Where(x => x.NoChoice).Count() > 0 && recursivityLevel < 10) || recursivityLevel == -1)
            {
                recursivityLevel++;
                routines = startingPoint;
                PersonDTO selected = null;
                foreach (ShiftTableDTO shift in routines.OrderBy(x => x.ShiftStart))
                {
                    selected = ChoosePerson(shift: shift,
                                                remainingShifts: routines.Where(x => (x.ChoosenPerson != null || x.NoChoice == false) &&
                                                                         (x.ShiftStart > shift.ShiftStart))
                                                                                       .ToList(),
                                                personPreviousShift:selected,
                                                recursiveLap: recursivityLevel);
                    if (selected != null)
                    {
                        shift.ChoosenPerson = selected.Name;
                        selected.EffectiveHours += (shift.ShiftEnd - shift.ShiftStart).Hours;
                        shift.NoChoice = false;
                    }
                    else shift.NoChoice = true;
                }
            }
            var dt = routines.ToDataTable(); //just for tests

            return routines;
        }

        private PersonDTO ChoosePerson(ShiftTableDTO shift, List<ShiftTableDTO> remainingShifts, PersonDTO personPreviousShift, int recursiveLap)
        {
            List<PersonOverlapsDTO> personOverlaps = new List<PersonOverlapsDTO>();
            //guardo solo coloro che non supererebbero le max hours
            foreach (var person in shift.AvailablePersons.Where(x => x != personPreviousShift && (x.EffectiveHours + (shift.ShiftEnd - shift.ShiftStart).Hours <= x.MaxHours)))
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
            //TODO flavio dovresti creare un rank dato dall'overlapping dei turni, ed a parità di rank ordinare per effective hours
            var choosablePersons = personOverlaps.OrderBy(x=>x.Person.EffectiveHours)
                                    .ThenByDescending(x => x.ShiftOverlapping.Count())
                                 .ThenByDescending(y => y.ShiftOverlapping.Sum(z => z.WithMany))
                                 .ToList();
            PersonOverlapsDTO dto = null;
            if (choosablePersons.Any())
            {
                if (recursiveLap == 0)
                    dto = choosablePersons.FirstOrDefault();
                else if (recursiveLap > choosablePersons.Count())
                    dto = choosablePersons.ElementAt(recursiveLap);
                else dto = choosablePersons.ElementAt(new Random().Next(0, choosablePersons.Count()));
            }
            return dto != null ? dto.Person : null;
        }
    }
}
