using MyHospitalCalendar.Core.DTOs;
using MyHospitalCalendar.Core.Services;
using MyHospitalCalendar.Core.Services.Interfaces;
using MyHospitalCalendar.Core.Test.Builders;
using System;
using System.Collections.Generic;
using Xunit;

namespace MyHospitalCalendar.Core.Test
{
    public class CalendarServiceTest
    {
        private ICalendarService _calendarService;

        public CalendarServiceTest()
        {
            _calendarService = new CalendarService();
        }

        [Fact]
        public void CreateCalendar()
        {
            WeekDTO week = new WeekDTOBuilder()
                                    .WithDay(new DayDTOBuilder()
                                                    .WithDayName("Monday")
                                                    .WithIsDayOff(false)
                                                    .WithDayNumber(1)
                                                    .WithRoutine(new RoutineDTOBuilder()
                                                                        .WithDateStart(new DateTime(2021,1,4,0,0,0))
                                                                        .WithDateEnd(new DateTime(2021, 1, 4, 8, 0, 0)))
                                                    .WithRoutine(new RoutineDTOBuilder()
                                                                        .WithDateStart(new DateTime(2021, 1, 4, 8, 0, 0))
                                                                        .WithDateEnd(new DateTime(2021, 1, 4, 16, 0, 0)))
                                                    .WithRoutine(new RoutineDTOBuilder()
                                                                        .WithDateStart(new DateTime(2021, 1, 4, 16, 0, 0))
                                                                        .WithDateEnd(new DateTime(2021, 1, 4, 23, 59 , 59))))
                                    .WithDay(new DayDTOBuilder()
                                                    .WithDayName("Tuesday")
                                                    .WithIsDayOff(false)
                                                    .WithDayNumber(2)
                                                    .WithRoutine(new RoutineDTOBuilder()
                                                                        .WithDateStart(new DateTime(2021, 1, 5, 0, 0, 0))
                                                                        .WithDateEnd(new DateTime(2021, 1, 5, 8, 0, 0)))
                                                    .WithRoutine(new RoutineDTOBuilder()
                                                                        .WithDateStart(new DateTime(2021, 1, 5, 8, 0, 0))
                                                                        .WithDateEnd(new DateTime(2021, 1, 5, 16, 0, 0)))
                                                    .WithRoutine(new RoutineDTOBuilder()
                                                                        .WithDateStart(new DateTime(2021, 1, 5, 16, 0, 0))
                                                                        .WithDateEnd(new DateTime(2021, 1, 5, 23, 59 , 59))))
                                    .WithDay(new DayDTOBuilder()
                                                    .WithDayName("Wednesday")
                                                    .WithIsDayOff(false)
                                                    .WithDayNumber(3)
                                                    .WithRoutine(new RoutineDTOBuilder()
                                                                        .WithDateStart(new DateTime(2021, 1, 6, 0, 0, 0))
                                                                        .WithDateEnd(new DateTime(2021, 1, 6, 8, 0, 0)))
                                                    .WithRoutine(new RoutineDTOBuilder()
                                                                        .WithDateStart(new DateTime(2021, 1, 6, 8, 0, 0))
                                                                        .WithDateEnd(new DateTime(2021, 1, 6, 16, 0, 0)))
                                                    .WithRoutine(new RoutineDTOBuilder()
                                                                        .WithDateStart(new DateTime(2021, 1, 6, 16, 0, 0))
                                                                        .WithDateEnd(new DateTime(2021, 1, 6, 23, 59 , 59))))
                                    .WithDay(new DayDTOBuilder()
                                                    .WithDayName("Thursday")
                                                    .WithIsDayOff(false)
                                                    .WithDayNumber(4)
                                                    .WithRoutine(new RoutineDTOBuilder()
                                                                        .WithDateStart(new DateTime(2021, 1, 7, 0, 0, 0))
                                                                        .WithDateEnd(new DateTime(2021, 1, 7, 8, 0, 0)))
                                                    .WithRoutine(new RoutineDTOBuilder()
                                                                        .WithDateStart(new DateTime(2021, 1, 7, 8, 0, 0))
                                                                        .WithDateEnd(new DateTime(2021, 1, 7, 16, 0, 0)))
                                                    .WithRoutine(new RoutineDTOBuilder()
                                                                        .WithDateStart(new DateTime(2021, 1, 8, 16, 0, 0))
                                                                        .WithDateEnd(new DateTime(2021, 1, 8, 23, 59 , 59))))
                                    .WithDay(new DayDTOBuilder()
                                                    .WithDayName("Friday")
                                                    .WithIsDayOff(false)
                                                    .WithDayNumber(5)
                                                    .WithRoutine(new RoutineDTOBuilder()
                                                                        .WithDateStart(new DateTime(2021, 1, 9, 0, 0, 0))
                                                                        .WithDateEnd(new DateTime(2021, 1, 9, 8, 0, 0)))
                                                    .WithRoutine(new RoutineDTOBuilder()
                                                                        .WithDateStart(new DateTime(2021, 1, 9, 8, 0, 0))
                                                                        .WithDateEnd(new DateTime(2021, 1, 9, 16, 0, 0)))
                                                    .WithRoutine(new RoutineDTOBuilder()
                                                                        .WithDateStart(new DateTime(2021, 1, 9, 16, 0, 0))
                                                                        .WithDateEnd(new DateTime(2021, 1, 9, 23, 59 , 59))))
                                    .WithDay(new DayDTOBuilder()
                                                    .WithDayName("Saturday")
                                                    .WithIsDayOff(false)
                                                    .WithDayNumber(6)
                                                    .WithRoutine(new RoutineDTOBuilder()
                                                                        .WithDateStart(new DateTime(2021, 1, 10, 0, 0, 0))
                                                                        .WithDateEnd(new DateTime(2021, 1, 10, 8, 0, 0)))
                                                    .WithRoutine(new RoutineDTOBuilder()
                                                                        .WithDateStart(new DateTime(2021, 1, 10, 8, 0, 0))
                                                                        .WithDateEnd(new DateTime(2021, 1, 10, 16, 0, 0)))
                                                    .WithRoutine(new RoutineDTOBuilder()
                                                                        .WithDateStart(new DateTime(2021, 1, 10, 16, 0, 0))
                                                                        .WithDateEnd(new DateTime(2021, 1, 10, 23, 59 , 59))))
                                    .WithDay(new DayDTOBuilder()
                                                    .WithDayName("Sunday")
                                                    .WithIsDayOff(false)
                                                    .WithDayNumber(7)
                                                    .WithRoutine(new RoutineDTOBuilder()
                                                                        .WithDateStart(new DateTime(2021, 1, 11, 0, 0, 0))
                                                                        .WithDateEnd(new DateTime(2021, 1, 11, 8, 0, 0)))
                                                    .WithRoutine(new RoutineDTOBuilder()
                                                                        .WithDateStart(new DateTime(2021, 1, 11, 8, 0, 0))
                                                                        .WithDateEnd(new DateTime(2021, 1, 11, 16, 0, 0)))
                                                    .WithRoutine(new RoutineDTOBuilder()
                                                                        .WithDateStart(new DateTime(2021, 1, 11, 16, 0, 0))
                                                                        .WithDateEnd(new DateTime(2021, 1, 11, 23, 59 , 59))));



            List<PersonDTO> doctors = new List<PersonDTO>();
            doctors.Add(new PersonDTOBuilder()
                                .WithName("Paolo")
                                .WithMaxHours(20));
            doctors.Add(new PersonDTOBuilder()
                                .WithName("Gianna")
                                .WithMaxHours(40)
                                .WithNotAvailableDay(new DayDTOBuilder()
                                                            .WithDayName("Monday")
                                                            .WithDayNumber(1)
                                                            .WithRoutine(new RoutineDTOBuilder()
                                                                        .WithDateStart(new DateTime(2021, 1, 4, 8, 0, 0))
                                                                        .WithDateEnd(new DateTime(2021, 1, 4, 16, 0, 0)))));
            doctors.Add(new PersonDTOBuilder()
                                .WithName("Rodolfo")
                                .WithMaxHours(20));
            doctors.Add(new PersonDTOBuilder()
                                .WithName("Simonetta")
                                .WithMaxHours(20));
            doctors.Add(new PersonDTOBuilder()
                                .WithName("Luca")
                                .WithMaxHours(40));
            doctors.Add(new PersonDTOBuilder()
                                .WithName("Jennifer")
                                .WithMaxHours(40));


            _calendarService.CreateCalendar(week, doctors);

            Assert.True(true);
        }
    }
}
