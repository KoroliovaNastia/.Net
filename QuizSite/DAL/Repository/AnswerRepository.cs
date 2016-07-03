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
    class AnswerRepository:IRepository<Answers>
    {
        private QuizContext db;

        public AnswerRepository(QuizContext context)
        {
            db = context;
        }

        public IEnumerable<Answers> GetAll()
        {
            return db.Answers;
        }

        public Answers Get(int? id)
        {
            return db.Answers.Find(id);
        }

        public IEnumerable<Answers> Find(Func<Answers, bool> predicate)
        {
            return db.Answers.Where(predicate).ToList();
        }

        public void Create(Answers answer)
        {
            db.Answers.Add(answer);
        }

        public void Update(Answers answer)
        {
            db.Entry(answer).State=EntityState.Modified;
        }

        public void Delete(int id)
        {
            Answers answer = db.Answers.Find(id);
            if (answer != null)
                db.Answers.Remove(answer);

        }
    }
}
