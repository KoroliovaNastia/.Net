using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Electives;

namespace ElectivesConsole
{
    class Program
    {
        static void Main(string[] args)
        {

          //  ILector lector;
            Professor professor=new Professor("Ivan Ivanovich");
            ICourse cours = professor.CreateCourse("ASP.NET.MVC");
            AllCourses electives = new AllCourses();
            electives.AddCourse(cours);
            Student student = new Student("Petya");
            student.Subscribe(cours);
            cours.StartCours();
            cours.FinishedCours();
            Console.ReadKey();
        }
    }
}
