using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repository
{
    public class EFUnitOfWork:IUnitOfWork
    {
        private QuizContext db;
        private TestRepository testRepository;

        public EFUnitOfWork(string connectionString)
        {
            db=new QuizContext(connectionString);
        }
        public IRepository<Test> Tests
        {
            get
            {
                if(testRepository==null)
                    testRepository=new TestRepository(db);
                return testRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
