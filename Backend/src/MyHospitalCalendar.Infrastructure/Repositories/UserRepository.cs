using MyHospitalCalendar.Core.Entities;
using MyHospitalCalendar.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyHospitalCalendar.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MyHospitalCalendarContext _dbContext;

        public UserRepository(MyHospitalCalendarContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public User GetUserByKey(int idUser)
        {
            User user = this._dbContext.User
                .SingleOrDefault(user => user.Id == idUser);
            if (user == null)
                throw new ArgumentNullException("user");

            return user;
        }

        public User FindUserByEmail(string email)
        {
            return this._dbContext.User.SingleOrDefault(user => user.Email == email);
        }

        public User Login(string email, byte[] password)
        {
            User user = this._dbContext.User
                .SingleOrDefault(user => user.Email == email && user.Password == password);
            if (user == null)
                throw new ArgumentNullException("user");

            return user;
        }

        public void Add(User user)
        {
            this._dbContext.Add<User>(user);
        }

        public void Update(User user)
        {
            this._dbContext.Update<User>(user);
        }

        public void SaveChanges()
        {
            this._dbContext.SaveChanges();
        }
    }
}
