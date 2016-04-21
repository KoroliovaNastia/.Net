using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NewtonMethod
{
    public static class RootOfNumber
    {
        public static double FindRoot(int pow, double number, double eps)
        {
            if (eps<=0 || eps>1)
                throw new ArgumentOutOfRangeException("eps");
            if (Double.IsNaN(number) || (number < 0 && pow % 2 == 0))
                return Double.NaN;
            if (Math.Abs(number - 1) < eps)
                return 1;
            if ((Math.Abs(number + 1) < eps) && (pow % 2 != 0))
                return -1;

            double x0 =number/2;
            double x1;
            double temp;
            do
            {
                temp = x0;
                x1 = ((Math.Abs(pow) - 1) * x0 + number / Power(x0, Math.Abs(pow) - 1)) / Math.Abs(pow);
                x0=x1;
               
            }
            while (Math.Abs(temp - x1) >= eps);
            if (pow < 0)
                return 1/x1;
            return x1;
        }

        private static double Power(double x, double n)
        {
            double temp=1;
            for (int i = 0; i < n; i++)
            {
                temp *= x;
            }
            return temp;
        }
    }
}
