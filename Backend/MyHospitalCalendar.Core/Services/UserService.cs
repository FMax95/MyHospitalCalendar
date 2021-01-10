using MyHospitalCalendar.Core.Repositories;
using MyHospitalCalendar.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHospitalCalendar.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;


        public UserService(
            IUserRepository userRepository
        )
        {
            _userRepository = userRepository;
        }
        public object GetUserByEmail(string email)
        {
            var user = this._userRepository.FindUserByEmail(email: email);
            if (user == null)
                throw new Exception("User not found");

            return user;
        }

    }
}
