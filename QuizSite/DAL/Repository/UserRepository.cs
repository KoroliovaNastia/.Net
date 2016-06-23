using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repository
{
    public class UserRepository:IRepository<User>
    {
        private readonly QuizContext db;

        public UserRepository(QuizContext context)
        {
            db = context;
        }
        public void Create(User user)
        {
            if (user.Id == 0)
            {
                db.Users.Add(user);
            }
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users;
        }

        public User Get(int? id)
        {
            return db.Users.Find(id);
        }

         public User GetUserByEmail(string email)
        {
            var user = (from u in db.Users
                        where u.Email == email
                        select u).FirstOrDefault();
            return user;
        }

        public IEnumerable<User> Find(Func<User, bool> predicate)
        {
            return db.Users.Where(predicate).ToList();
        }
        public void Update(User user)
        {
            db.Entry(user).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            User user = db.Users.Find(id);
            if (user != null)
                db.Users.Remove(user);

        }
    }
}
