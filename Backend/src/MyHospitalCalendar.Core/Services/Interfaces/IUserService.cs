using System;
using System.Collections.Generic;
using System.Text;

namespace MyHospitalCalendar.Core.Services.Interfaces
{
    public interface IUserService : IBaseService
    {
        object GetUserByEmail(string email);
    }
}
