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
        private QuestionRepository questionRepository;
        private UserRepository userRepository;
        private RoleRepository roleRepository;
        private ProfileRepository profileRepository;
        private AnswerRepository answerRepository;
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

        public IRepository<Question> Questions
        {
            get
            {
                if (questionRepository == null)
                    questionRepository = new QuestionRepository(db);
                return questionRepository;
            }
        }
        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }
        public IRepository<Role> Roles
        {
            get
            {
                if (roleRepository == null)
                    roleRepository = new RoleRepository(db);
                return roleRepository;
            }
        }

        public IRepository<Profile> Profiles
        {
            get
            {
                if (profileRepository == null)
                    profileRepository = new ProfileRepository(db);
                return profileRepository;
            }
        }
        public IRepository<Answers> Answers
        {
            get
            {
                if (answerRepository == null)
                    answerRepository = new AnswerRepository(db);
                return answerRepository;
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
