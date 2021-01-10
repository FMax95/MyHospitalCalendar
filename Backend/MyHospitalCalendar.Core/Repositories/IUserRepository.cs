using MyHospitalCalendar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHospitalCalendar.Core.Repositories
{
    public interface IUserRepository: IBaseRepository<User>
    {
        void Add(User user);
        User FindUserByEmail(string email);
        User GetUserByKey(int idUser);
        User Login(string email, byte[] password);
        void SaveChanges();
        void Update(User user);
    }
}
