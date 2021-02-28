using MyHospitalCalendar.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyHospitalCalendar.Core.Test.Builders
{
    public class MonthDTOBuilder
    {
        private int _weekNumber = 1;
        private DateTime _dateStart = new DateTime(2021, 1, 4);
        private DateTime _dateEnd = new DateTime(2021, 1, 10);
        private List<RoutineDTO> _routines = new List<RoutineDTO>();


        public MonthDTOBuilder WithWeekNumber(int val)
        {
            this._weekNumber = val;
            return this;
        }
        public MonthDTOBuilder WithDateStart(DateTime val)
        {
            this._dateStart = val;
            return this;
        }
        public MonthDTOBuilder WithDateEnd(DateTime val)
        {
            this._dateEnd = val;
            return this;
        }
        public MonthDTOBuilder WithRoutine(RoutineDTOBuilder val)
        {
            this._routines.Add(val);
            return this;
        }


        public static implicit operator MonthDTO(MonthDTOBuilder builder)
        {
            if (builder._routines.Any() == false)
                builder._routines.Add(new RoutineDTOBuilder());
            return new MonthDTO()
            {
                MonthNumber = builder._weekNumber,
                DateStart = builder._dateStart,
                DateEnd = builder._dateEnd,
                Routines = builder._routines
            };
        }
    }
}
