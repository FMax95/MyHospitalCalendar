using MyHospitalCalendar.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyHospitalCalendar.Core.Test.Builders
{
    public class PersonDTOBuilder
    {
        private Guid _id = new Guid("1");
        private string _name = "Nicola";
        private decimal _maxHours = 18;
        private List<DayDTO> _notAvailableDays = new List<DayDTO>();

        public PersonDTOBuilder WithName(string val)
        {
            this._name = val;
            return this;
        }
        public PersonDTOBuilder WithMaxHours(decimal val)
        {
            this._maxHours = val;
            return this;
        }

        public PersonDTOBuilder WithNotAvailableDay(DayDTOBuilder val)
        {
            this._notAvailableDays.Add(val);
            return this;
        }

        public static implicit operator PersonDTO(PersonDTOBuilder builder)
        {
            return new PersonDTO()
            {
                Id = builder._id,
                Name = builder._name,
                MaxHours = builder._maxHours,
                NotAvailableDays = builder._notAvailableDays
            };
        }
    }
}
