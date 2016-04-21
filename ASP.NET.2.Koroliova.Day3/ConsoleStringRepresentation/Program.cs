using System;
using System.Globalization;
using System.Web;
using StringRepresentation;

namespace ConsoleStringRepresentation
{
    class Program
    {
       
        static void Main(string[] args)
        {
            Customer customer = new Customer("Jeffrey Richter","+1(425)555-0100",1000000);
           
            CultureInfo nl = new CultureInfo("nl-NL");
            NumberFormatInfo f= new NumberFormatInfo();
            f.NumberGroupSeparator = "-";
            Console.WriteLine("Castomer record: "+ customer.ToString("O"));
            Console.WriteLine("Castomer record: "+ customer.ToString("M"));
            Console.WriteLine("Castomer record: "+ customer.ToString("R"));
            Console.WriteLine("Castomer record: " + customer.ToString("G"));
            Console.WriteLine("Castomer record: " + customer.ToString("G", nl));
            Console.WriteLine("{0}", customer.ToString("R",nl));
            Console.ReadKey();
        }
    }
}
