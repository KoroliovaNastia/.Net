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
    class QuestionRepository:IRepository<Question>
    {
        private QuizContext db;

        public QuestionRepository(QuizContext context)
        {
            db = context;
        }

        public IEnumerable<Question> GetAll()
        {
            return db.Questions;
        }

        public Question Get(int? id)
        {
            return db.Questions.Find(id);
        }

        public IEnumerable<Question> Find(Func<Question, bool> predicate)
        {
            return db.Questions.Where(predicate).ToList();
        }

        public void Create(Question question)
        {
             db.Questions.Add(question);
        }

        public void Update(Question question)
        {
            db.Entry(question).State=EntityState.Modified;
        }

        public void Delete(int id)
        {
            Question question = db.Questions.Find(id);
            if (question != null)
                db.Questions.Remove(question);

        }
    }
}
