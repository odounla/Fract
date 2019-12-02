using System;
using System.Text.RegularExpressions;


namespace Fract
{
    public class Fraction
    {
        public  int Denominator { get; private set; }
        public int Numerator { get; private set; }

        public Fraction(int Numerator, int Denominator)
        {
            if (Denominator == 0)
            {
                throw new Exception("Denominator cannot be zero");
            }


            int gcd = GCD(Numerator, Denominator);

            this.Numerator = Numerator / gcd;
            this.Denominator = Denominator / gcd;

            // Let's take care of negative fractions
            if (this.Denominator < 0)
            {
                this.Denominator *= -1;
                this.Numerator *= -1;
            }

        }
        /// <summary>
        /// Method to find the greatest common denominator of two integers
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int GCD(int a, int b)
        {
            int factor = b;
            while (b != 0)
            {
                factor = b;
                b = a % b;
                a = factor;
            }
            return a;
        }
     
        /// <summary>
        /// Returns a fraction from a string
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public static Fraction FromString(String input)
        {
            var pattern = @"^(\d+/\d+|\d+(_\d+/\d+)?)$"; 
            var denom = 1;

            Match match = Regex.Match(input, pattern, RegexOptions.IgnoreCase);

            if (!match.Success)
            {
                throw new Exception("invalid operation, you entered wrong operands");
            }
            int num;

            // See if we do have a mixed number
            if (input.IndexOf("/", StringComparison.Ordinal) >= 0 && input.IndexOf("_", StringComparison.Ordinal) >= 0)
            {
                int multiplier = 1;
                if (input.StartsWith("-", StringComparison.Ordinal))
                {
                    multiplier = -1;
                    input = input.Substring(1);
                }

                var parts = input.Split('_');
                var intPart = int.Parse(parts[0]);
                var fractParts = parts[1].Split('/');

                var fractPartNum = int.Parse(fractParts[0]);
                denom = int.Parse(fractParts[1]);
                num = multiplier * ((intPart * denom) + fractPartNum);
            }
            // simple fraction
            else if (input.IndexOf("/", StringComparison.Ordinal) >= 0) 
            {
                var parts = input.Split('/');
                num = int.Parse(parts[0]);
                denom = int.Parse(parts[1]);
            }
            else // fallback to integer
            {
                num = int.Parse(input);
            }

            return new Fraction(num, denom);
        }


        /// <summary>
        /// This method return the addition of two fractions
        /// </summary>
        /// <param name="a">Left hand fraction</param>
        /// <param name="b">Right hand fraction</param>
        /// <returns>fraction</returns>

        public static Fraction operator +(Fraction a, Fraction b)
        {
            return new Fraction((a.Numerator * b.Denominator) + (b.Numerator * a.Denominator), a.Denominator * b.Denominator);
        }
        /// <summary>
        /// This Method return the subtraction of two fractions
        /// </summary>
        /// <param name="a">Left hand fraction</param>
        /// <param name="b">Right hand fraction</param>
        /// <returns>fraction</returns>
        /// 
        public static Fraction operator -(Fraction a, Fraction b)
        {
            return new Fraction((a.Numerator * b.Denominator) - (b.Numerator * a.Denominator), a.Denominator * b.Denominator);
        }
        /// <summary>
        /// Returns the product of 2 fractions
        /// </summary>
        /// <param name="a">Left hand fraction</param>
        /// <param name="b">Right hand fraction</param>
        /// <returns>fraction</returns>
        public static Fraction operator *(Fraction a, Fraction b)
        {
            return new Fraction(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
        }

        /// <summary>
        /// Returns the division of 2 fractions
        /// </summary>
        /// <param name="a">Left hand fraction</param>
        /// <param name="b">Right hand fraction</param>
        /// <returns>fraction</returns>
        public static Fraction operator /(Fraction a, Fraction b)
        {
            if (b.Numerator == 0)
            {
                throw new DivideByZeroException();
            }

            return new Fraction(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The string represention of this fraction</returns>
        public override string ToString()
        {

            if (Numerator % Denominator == 0)
            {
                var x = Numerator / Denominator;
                return x.ToString();
            }

            if (Numerator > Denominator)
            {
                var numPart = Numerator / Denominator;
                var y = Numerator % Denominator;

                return String.Format("{0}_{1}/{2}", numPart, y, Denominator);
            }

            return String.Format("{0}/{1}", Numerator, Denominator);

        }
       

    }
}
