using System;
using System.CodeDom.Compiler;

namespace Polinom
{
    public class CreatePolinom
    {
        #region Fields

        private static readonly double eps;
        private readonly double[] coeff;
        private int degree;

        #endregion

        #region Property
        public int Degree
        {
            get
            {
                if (coeff == null)
                    throw new ArgumentNullException();
                int i = coeff.Length - 1;
                while (Math.Abs(coeff[i]) < eps && i >= 0)
                {
                    i--;
                }
                
                return i;

            }

       

        }
        #endregion

        #region Ctors

        static CreatePolinom()
        {
            eps = 0.0000001;
        }
        public CreatePolinom()
        {
            coeff = default(double[]);
            degree = 0;
        }

        public CreatePolinom(int deg)
        {
            if (deg < 0)
                throw new ArgumentException();
            coeff = new double[deg + 1];
            for (int i = 0; i < deg; i++)
            {
                coeff[i] = 0;
            }
            coeff[deg] = 1;
            degree = deg;
        }

        public CreatePolinom(params  double[] list)
        {
            if (list == null)
                throw new ArgumentNullException();

            coeff = new double[list.Length];
            for (int i = 0; i < list.Length; i++)
            {
                coeff[i] = list[i];
            }
            degree = coeff.Length - 1;
        }
        #endregion

        #region Enumerator
        public double this[int i]
        {
            get
            {
                if (i > Degree || i < 0)
                    throw new ArgumentOutOfRangeException();

                return coeff[i];
            }
            set
            {
                if (i > Degree || i < 0)
                    throw new ArgumentOutOfRangeException();

                coeff[i] = value;
            }
        }
        #endregion

        #region OverrideMethods
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
                return false;
            if (ReferenceEquals(obj, this))
                return true;
            CreatePolinom p = new CreatePolinom();

            if (p.GetType() != obj.GetType())
                return false;
            p = (CreatePolinom)obj;
            return Equals(p);
        }
        public bool Equals(CreatePolinom p)
        {
            if (ReferenceEquals(p, null))
                return false;
            if (ReferenceEquals(p, this))
                return true;
            if (p.degree != degree)
                return false;
            for (int i = 0; i < degree; i++)
            {
                if (Math.Abs(coeff[i] - p[i]) > eps)

                    return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((coeff != null ? coeff.GetHashCode() : 0) * 397) ^ Degree;

            }
        }

        public override string ToString()
        {
            string str = string.Empty;
            str += coeff[0];
            //double[] mass = new double[coef.Length];
            for (int i = 1; i < coeff.Length; i++)
            {
                if (Math.Abs(coeff[i]) > eps)
                    str += coeff[i] >= 0 ? "+" + coeff[i] + "*x^" + i : "" + coeff[i] + "*x^" + i;

            }


            return str;
        }
        #endregion

        #region Operation

        public static explicit operator CreatePolinom(double a)
        {
            return new CreatePolinom(a);
        }

        public double  Colculate( double x)
        {
            if (this == null)
                throw new NullReferenceException();
            double summ = 0;
            for (int i = 0; i < Degree + 1; i++)
            {
                summ += this[i]*Math.Pow(x, i);
            }
            return summ;
        }

        public static CreatePolinom operator +(CreatePolinom p1, CreatePolinom p2)
        {
            if (p1 == null || p2 == null)
                throw new ArgumentNullException();

            CreatePolinom newm = p1.Degree > p2.Degree ? p1 : p2;

            for (int i = 0; i < Math.Min(p1.Degree, p2.Degree) + 1; i++)
            {
                if (newm.Equals(p1))
                {
                    newm.coeff[i] += p2.coeff[i];
                }
                else
                {
                    newm.coeff[i] += p1.coeff[i];
                }
            }
            return newm;
        }

        public static CreatePolinom Add(CreatePolinom lhs, CreatePolinom rhs)
        {
            return lhs + rhs;
        }
        public static CreatePolinom operator *(CreatePolinom p, double a)
        {
            if (p == null)
                throw new ArgumentNullException();

            CreatePolinom polinom = p;

            for (int i = 0; i < p.degree + 1; i++)
            {
                polinom[i] = a * polinom[i];
            }
            return polinom;
        }

        public static CreatePolinom operator *(CreatePolinom p1, CreatePolinom p2)
        {
            if (p1 == null || p2 == null)
                throw new ArgumentNullException();
            return Multiply(p1, p2);
        }

        public static CreatePolinom operator -(CreatePolinom p1, CreatePolinom p2)
        {
            if (p1 == null || p2 == null)
                throw new ArgumentNullException();

            return p1 + p2 * (CreatePolinom)(-1);
        }

        public static CreatePolinom Subtract(CreatePolinom lhs, CreatePolinom rhs)
        {
            return lhs - rhs;
        }

        public static CreatePolinom Multiply(CreatePolinom lhs, CreatePolinom rhs)
        {
            if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
                throw new ArgumentNullException();
            CreatePolinom p2 = new CreatePolinom(rhs.Degree + lhs.Degree);
            for (int i = 0; i < lhs.Degree + 1; i++)
            {
                CreatePolinom p1 = new CreatePolinom(rhs.coeff);
                if (Math.Abs(lhs[i]) > eps)
                {
                    p1 = p1 * lhs[i];

                    for (int k = 0; k < rhs.Degree + 1; k++)
                    {
                        p2[k + i] += p1[k];
                    }
                }
            }
            p2[p2.Degree] -= 1;
            return p2;
        }
        public static CreatePolinom operator /(CreatePolinom lhs, CreatePolinom rhs)
        {
            CreatePolinom quotient;
            CreatePolinom remainder;
            Deconv(lhs, rhs, out quotient, out remainder);
            return quotient;
        }
        public static CreatePolinom operator %(CreatePolinom lhs, CreatePolinom rhs)
        {
            CreatePolinom quotient;
            CreatePolinom remainder;
            Deconv(lhs, rhs, out quotient, out remainder);
            return remainder;
        }

        public static CreatePolinom Divide(CreatePolinom lhs, CreatePolinom rhs)
        {
            return lhs/rhs;
        }
        public static CreatePolinom Mod(CreatePolinom lhs, CreatePolinom rhs)
        {
            return lhs % rhs;
        }
        private static void Deconv(CreatePolinom dividend, CreatePolinom divisor, out CreatePolinom quotient, out CreatePolinom remainder)
        {
            if (ReferenceEquals(dividend, null) || ReferenceEquals(divisor, null))
                throw new ArgumentNullException();
            remainder = dividend;
            quotient = new CreatePolinom(remainder.Degree - divisor.Degree);
            for (int i = 0; i < quotient.Degree+1; i++)
            {
                CreatePolinom coef = (new CreatePolinom(remainder.Degree - divisor.Degree)) * (CreatePolinom)(remainder[remainder.Degree - i] / divisor[divisor.Degree]);
                quotient[quotient.Degree - i] = coef[coef.Degree];
                coef = Multiply(coef, divisor);
                //for (int j = 0; j < divisor.degree + 1; j++)
                //{
                remainder -= coef;
                //}
            }

        }
        public static bool operator ==(CreatePolinom lhs, CreatePolinom rhs)
        {
            if (ReferenceEquals(rhs, lhs))
            {
                return true;
            }
            if (ReferenceEquals(lhs, null))
            {
                return false;
            }
            return lhs.Equals(rhs);
        }

        public static bool operator !=(CreatePolinom lhs, CreatePolinom rhs)
        {
            return !(lhs == rhs);
        }
    }
        #endregion
}
