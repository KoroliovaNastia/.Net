using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using System.Web.Helpers;

namespace DAL.EF
{
    public class QuizContext:DbContext
    {
        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Answers> Answers { get; set; }

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
                db.Tests.Add(new Test{Id=1, TestId = 1,
                Title = "Socionic test",
                Category = "Philosophy",
                ShortDescription = "Not found",
                TimeToComplete = TimeSpan.FromMinutes(20),
                DateOfPublication = DateTime.Now,
                Question = new List<Question>()
                {
                    new Question(){Id=1,TestId=1,Formulation = "What is more typical for you in communication with new people?",
                        Answers = new List<Answers>()
                        {
                            new Answers(){Id=1,QuestionId = 1,Text="I don’t watch distance in communication with people well. I try to behave equally with people"},
                            new Answers(){Id=2,QuestionId = 1,Text = "I feel people’s attitude to me well. I know the distance I should communicate with them."},
                            new Answers(){Id=3,QuestionId = 1,Text="Skip this question."}
                        }},
                        new Question(){Id=2,TestId=1,Formulation = "What type of rest do you prefer?",
                        Answers = new List<Answers>()
                        {
                            new Answers(){Id=4,QuestionId = 2,Text="Active (walking, hiking, shoping, sport)."},
                            new Answers(){Id=5,QuestionId = 2,Text = "Passive (reading, watching films, just thinking or dreaming)."},
                            new Answers(){Id=6,QuestionId = 2,Text="Skip this question."}
                        }}
                }});
                

                db.Roles.Add(new Role {Name = "User"});
                db.Roles.Add(new Role {Name = "Administrator" });
               

                db.Users.Add(new User
                {
                    Id=1,
                    Email = "K.Nastia.san@mail.ru",
                    CreationDate = DateTime.Now,
                    Password = Crypto.HashPassword("dhfuytghjql`n"),
                    RoleId = 2
                });
                db.SaveChanges();
            }
        }
    }
}
