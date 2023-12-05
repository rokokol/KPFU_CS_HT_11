using System;

namespace MathTools
{
    public class ComplexNumber
    {
        public decimal Re { get; set; }
        public decimal Im { get; set; }

        public ComplexNumber Add(ComplexNumber a)
        {
            return new ComplexNumber(Re + a.Re, Im + a.Im);
        }

        public ComplexNumber Minus(ComplexNumber a)
        {
            return new ComplexNumber(Re - a.Re, Im - a.Im);
        }

        public ComplexNumber Multiply(ComplexNumber a)
        {
            return new ComplexNumber(Re * a.Re - Im * a.Im, Re * a.Re - Im * a.Im);
        }

        public ComplexNumber Divide(ComplexNumber a)
        {
            return new ComplexNumber((Re * a.Re + Im * a.Im) / (a.Re * a.Re + a.Im * a.Im),
                (Im * a.Re - Re * a.Im) / (a.Re * a.Re + a.Im * a.Im));
        }
        
        protected bool Equals(ComplexNumber other)
        {
            return Re == other.Re && Im == other.Im;
        }

        public override string ToString()
        {
            return $"{Re} {(Im < 0 ? '-' : '+')} {Math.Abs(Im)}i";
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ComplexNumber)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Re.GetHashCode() * 397) ^ Im.GetHashCode();
            }
        }

        public ComplexNumber(decimal re, decimal im)
        {
            Re = re;
            Im = im;
        }

        public static ComplexNumber operator +(ComplexNumber a, ComplexNumber b)
        {
            return a.Add(b);
        }
        
        
        public static ComplexNumber operator -(ComplexNumber a, ComplexNumber b)
        {
            return a.Minus(b);
        }
        
        public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b)
        {
            return a.Multiply(b);
        }
        
        public static ComplexNumber operator /(ComplexNumber a, ComplexNumber b)
        {
            return a.Divide(b);
        }
        
        public static bool operator ==(ComplexNumber a, ComplexNumber b)
        {
            return a.Equals(b);
        }
        
        public static bool operator !=(ComplexNumber a, ComplexNumber b)
        {
            return !a.Equals(b);
        }
    }
}