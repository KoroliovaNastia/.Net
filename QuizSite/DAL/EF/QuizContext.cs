using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.EF
{
    public class QuizContext:DbContext
    {
        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Profile> Profiles { get; set; }

        static QuizContext()
        {
            Database.SetInitializer<QuizContext>(new StoreDbInitializer());
        }

        public  QuizContext(string connectionStr="dbQuiz"):base(connectionStr)
        {
           
        }
        public class StoreDbInitializer : CreateDatabaseIfNotExists<QuizContext>
        {
            protected override void Seed(QuizContext db)
            {
                db.Tests.Add(new Test{Title = "Socionic test",
                Category = "Philosophy",
                ShortDescription = "Not found",
                TimeToComplete = TimeSpan.FromMinutes(20),
                DateOfPublication = DateTime.Now,
                Question = new List<Question>()});
                db.SaveChanges();
            }
        }
    }
}
