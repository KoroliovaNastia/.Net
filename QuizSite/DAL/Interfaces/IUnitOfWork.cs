using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IRepository<Test> Tests { get; }
        IRepository<Question> Questions { get; }
        IRepository<User> Users { get; }
        IRepository<Role> Roles { get; }
        IRepository<Profile> Profiles { get; }
        IRepository<Answers> Answers { get; }
        void Save();
    }
}
