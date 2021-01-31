using MyHospitalCalendar.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHospitalCalendar.Core.Test.Builders
{
    public class RoutineDTOBuilder
    {
        private DateTime _dateStart = new DateTime(2021,1,4,0, 0, 0);

        private DateTime _dateEnd = new DateTime(2021, 1, 4, 23, 59, 59);

        public RoutineDTOBuilder WithDateStart(DateTime val)
        {
            this._dateStart = val;
            return this;
        }
        public RoutineDTOBuilder WithDateEnd(DateTime val)
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
