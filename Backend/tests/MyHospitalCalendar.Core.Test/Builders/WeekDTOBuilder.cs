using MyHospitalCalendar.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyHospitalCalendar.Core.Test.Builders
{
    public class WeekDTOBuilder
    {
        private int _weekNumber = 1;
        private DateTime _dateStart = new DateTime(2021, 1, 4);
        private DateTime _dateEnd = new DateTime(2021, 1, 10);
        private List<DayDTO> _days = new List<DayDTO>();

        public WeekDTOBuilder WithWeekNumber(int val)
        {
            this._weekNumber = val;
            return this;
        }
        public WeekDTOBuilder WithDateStart(DateTime val)
        {
            this._dateStart = val;
            return this;
        }
        public WeekDTOBuilder WithDateEnd(DateTime val)
        {
            this._dateEnd = val;
            return this;
        }
        public WeekDTOBuilder WithDay(DayDTOBuilder val)
        {
            this._days.Add(val);
            return this;
        }

        public static implicit operator WeekDTO(WeekDTOBuilder builder)
        {
            if (builder._days.Any() == false)
                builder._days.Add(new DayDTOBuilder());
            return new WeekDTO()
            {
                WeekNumber = builder._weekNumber,
                DateStart = builder._dateStart,
                DateEnd = builder._dateEnd,
                Days = builder._days
            };
        }
    }
}
