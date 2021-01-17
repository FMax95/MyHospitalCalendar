using MyHospitalCalendar.Core.Services;
using MyHospitalCalendar.Core.Services.Interfaces;
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

            Assert.True(true);
        }
    }
}
