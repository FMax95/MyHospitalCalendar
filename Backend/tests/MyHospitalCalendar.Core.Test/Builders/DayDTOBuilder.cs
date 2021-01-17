using MyHospitalCalendar.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyHospitalCalendar.Core.Test.Builders
{
    public class DayDTOBuilder
    {
        private string _dayName = "Monday";
        private int _dayNumber = 1;

        private bool _isDayOff = false;

        private List<RoutineDTO> _routines = new List<RoutineDTO>();

        public DayDTOBuilder WithDayName(string val)
        {
            this._dayName = val;
            return this;
        }

        public DayDTOBuilder WithDayNumber(int val)
        {
            this._dayNumber = val;
            return this;
        }
        public DayDTOBuilder WithIsDayOff(bool val)
        {
            this._isDayOff = val;
            return this;
        }
        public DayDTOBuilder WithRoutine(RoutineDTOBuilder val)
        {
            this._routines.Add(val);
            return this;
        }

        public static implicit operator DayDTO(DayDTOBuilder builder)
        {
            if (builder._routines.Any() == false)
                builder._routines.Add(new RoutineDTOBuilder());
            return new DayDTO()
            {
                DayNumber = builder._dayNumber,
                DayName = builder._dayName,
                IsDayOff = builder._isDayOff,
                Routines = builder._routines
            };
        }
    }
}
