using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Expantion
{
    /// <summary>
    /// Static class with expantion method
    /// </summary>
    public static class HexFormat
    {
        /// <summary>
        /// Regular expression which correspond the standard form of format string for numbers
        /// </summary>
        private static string regex = @"^[Xx][1-8]?$";
       // private static string regex = @"[X|x]{1}[1-8]{0,1}";
        /// <summary>
        /// Conversion method using a format string for numbers
        /// </summary>
        /// <param name="number">Type of expansion</param>
        /// <returns>A string representation of a hexadecimal number</returns>
        public static string ConvertToHex(this Int32 number)
        {

            return number.ToString("x");

        }
        /// <summary>
        /// Overriding the method 
        /// </summary>
        /// <param name="number"></param>
        /// <param name="str">Standart format string for numbers</param>
        /// <returns></returns>
        public static string ConvertToHex(this Int32 number, string str)
        {
            if (str==null)
            {
                throw new NullReferenceException();
            }
            if (!Regex.IsMatch(str, regex))
            {
                throw new FormatException();
            }
            return number.ToString(str);
        }
    }
}
