using MyHospitalCalendar.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyHospitalCalendar.Core.Test.Builders
{
    public class PersonDTOBuilder
    {
        private Guid _id = new Guid();
        private string _name = "Nicola";
        private decimal _maxHours = 9999;
        private List<RoutineDTO> _notAvailableRoutines = new List<RoutineDTO>();

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

        public PersonDTOBuilder WithNotAvailableRoutine(RoutineDTOBuilder val)
        {
            this._notAvailableRoutines.Add(val);
            return this;
        }

        public static implicit operator PersonDTO(PersonDTOBuilder builder)
        {
            return new PersonDTO()
            {
                Id = builder._id,
                Name = builder._name,
                MaxHours = builder._maxHours,
                NotAvailableRoutines = builder._notAvailableRoutines
            };
        }
    }
}
