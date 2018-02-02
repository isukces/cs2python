using System;

namespace Lang.Python
{
    /// <summary>
    ///     Built-in complex type
    /// </summary>
    public struct Complex : IEquatable<Complex>
    {
        public Complex(double re, double im)
        {
            Re = re;
            Im = im;
        }

        public static Complex operator +(Complex a, Complex b)
        {
            return new Complex(a.Re + b.Re, a.Im + b.Im);
        }

        public static Complex operator +(Complex a, double b)
        {
            return new Complex(a.Re + b, a.Im);
        }

        public static Complex operator +(double b, Complex a)
        {
            return new Complex(a.Re + b, a.Im);
        }

        public static Complex operator /(Complex a, double b)
        {
            return new Complex(a.Re / b, a.Im / b);
        }

        public static Complex operator /(double a, Complex b)
        {
            return (Complex)a / b;
        }

        public static Complex operator /(Complex a, Complex b)
        {
            var m  = b.GetLengthSquared();
            var re = a.Re * b.Re + a.Im * b.Im;
            var im = a.Im * b.Re - a.Re * b.Im;
            return new Complex(re / m, im / m);
        }

        public static bool operator ==(Complex left, Complex right)
        {
            return left.Equals(right);
        }

        public static explicit operator Complex(double x)
        {
            return new Complex(x, 0);
        }

        public static bool operator !=(Complex left, Complex right)
        {
            return !left.Equals(right);
        }


        public static Complex operator *(Complex a, double b)
        {
            return new Complex(a.Re * b, a.Im * b);
        }

        public static Complex operator *(double b, Complex a)
        {
            return new Complex(a.Re * b, a.Im * b);
        }


        public static Complex operator *(Complex a, Complex b)
        {
            return new Complex(a.Re * b.Re - a.Im * b.Im, a.Re * b.Im + a.Im * b.Re);
        }

        public static Complex operator -(Complex a, Complex b)
        {
            return new Complex(a.Re - b.Re, a.Im - b.Im);
        }


        public static Complex operator -(Complex a, double b)
        {
            return new Complex(a.Re - b, a.Im);
        }

        public static Complex operator -(double a, Complex b)
        {
            return new Complex(a - b.Re, -b.Im);
        }


        public bool Equals(Complex other)
        {
            return Re.Equals(other.Re) && Im.Equals(other.Im);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Complex complex && Equals(complex);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Re.GetHashCode() * 397) ^ Im.GetHashCode();
            }
        }

        private double GetLengthSquared()
        {
            return Re * Re + Im * Im;
        }

        public double Re { get; }
        public double Im { get; }
        public static Complex Zero => new Complex();
    }
}