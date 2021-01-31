using System;
using System.Collections.Generic;
using System.Text;

namespace MyHospitalCalendar.Core.DTOs
{
    public class PersonOverlapsDTO
    {
        public PersonOverlapsDTO()
        {
            this.ShiftOverlapping = new List<ShiftOverlappingDTO>();
        }
        public PersonDTO Person { get; set; }
        public List<ShiftOverlappingDTO> ShiftOverlapping {get;set;}
    }

    public class ShiftOverlappingDTO
    {
        public ShiftTableDTO Shift { get; set; }
        public int WithMany { get; set; }
    }
}
