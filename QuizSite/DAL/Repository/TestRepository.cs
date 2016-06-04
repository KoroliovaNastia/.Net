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
   public  class TestRepository:IRepository<Test>
    {
        private QuizContext db;

        public TestRepository(QuizContext context)
        {
            db = context;
        }

        public IEnumerable<Test> GetAll()
        {
            return db.Tests;
        }

        public Test Get(int id)
        {
            return db.Tests.Find(id);
        }

        public IEnumerable<Test> Find(Func<Test, bool> predicate)
        {
            return db.Tests.Where(predicate).ToList();
        }

        public void Create(Test test)
        {
             db.Tests.Add(test);
        }

        public void Update(Test test)
        {
            db.Entry(test).State=EntityState.Modified;
        }

        public void Delete(int id)
        {
            Test test = db.Tests.Find(id);
            if (test != null)
                db.Tests.Remove(test);

        }
    }
}
