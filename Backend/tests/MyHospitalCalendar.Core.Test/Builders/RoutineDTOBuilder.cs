using MyHospitalCalendar.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHospitalCalendar.Core.Test.Builders
{
    public class RoutineDTOBuilder
    {
        private TimeSpan _dateStart = new TimeSpan(0, 0, 0);

        private TimeSpan _dateEnd = new TimeSpan(23, 59, 59);

        public RoutineDTOBuilder WithDateStart(TimeSpan val)
        {
            this._dateStart = val;
            return this;
        }
        public RoutineDTOBuilder WithDateEnd(TimeSpan val)
        {
            this._dateEnd = val;
            return this;
        }

        public static implicit operator RoutineDTO(RoutineDTOBuilder builder)
        {
            return new RoutineDTO()
            {
                DateStart = builder._dateStart,
                DateEnd = builder._dateEnd
            };
        }
    }
}
