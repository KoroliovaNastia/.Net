using System;
using System.Globalization;


namespace StringRepresentation
{
    public class Customer : IFormattable
    {
        private string Name { get; set; }
        private string ContactPhone { get; set; }
        private decimal Revenue { get; set; }

        public Customer(string name, string contactPhone, decimal revenue)
        {
            if(name==null || contactPhone==null)
                throw new NullReferenceException();
            Name = name;
            ContactPhone = contactPhone;
            Revenue = revenue;
        }
        
        public  string ToString(string format)
        {
            if (format == null)
               throw new NullReferenceException();
            return ToString(format, CultureInfo.CurrentCulture);
        }

        /// <param name="format">Format.Can be: M-return Name, R-return Revenue, C-return ContactPhone, G and O - return Name+Revenue+ContactPhone</param>
     /// <param name="formatProvider">Some class with implementation of IFormatProvider</param>
    
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (formatProvider == null) formatProvider = CultureInfo.CurrentCulture;
            if (String.IsNullOrEmpty(format)) format = "G";
            if (!(format == "M" || format == "R" || format == "R" || format=="C" || format=="G" || format=="O"))
                try
                {
                    return HandleOtherFormats(format, this);
                }
                catch (FormatException e)
                {
                    throw new FormatException(String.Format("The format of '{0}' is invalid.", format), e);
                }
            switch (format.ToUpperInvariant())
            {
                case "M": return Name;

                case "R":
                    return Revenue.ToString("N", formatProvider);
                case "C": return ContactPhone.ToString(formatProvider);
                case "G":
                case "O": return Name.ToString(formatProvider) + ", " + ContactPhone.ToString(formatProvider) + ", " + Revenue.ToString("N", formatProvider);
                default:
                    throw new FormatException(String.Format("The {0} format string is not supported.", format));
            } 
        }
        private string HandleOtherFormats(string format, object arg)
        {
            if (arg is IFormattable)
                return ((IFormattable)arg).ToString(format, CultureInfo.CurrentCulture);
            if (arg != null)
                return arg.ToString();
            
                return String.Empty;
        }
    }
}
