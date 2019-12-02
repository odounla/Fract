using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fract
{
    
    static class Operation
    {
        const string addition = " + ";
        const string subtraction = " - ";
        const string multiplication = " * ";
        const string division = " / ";


        /// <summary>
        /// Attempts to compute an operation on fractions
        /// </summary>
        /// <param name="input"></param>
        /// <returns>The resulting fraction</returns>
        /// 
        public static Fraction Compute(string input)
        {
            string[] operands = { };
            string[] separators = { addition, subtraction, multiplication, division };
            string operation = null;
            foreach (var op in separators)
            {
                if (input.IndexOf(op, StringComparison.Ordinal) > 0)
                {
                    operation = op;
                    break;
                }
            }

            if (operation == null)
            {
                throw new NullReferenceException("Not valid: only an operation on fraction is accepted");
            }

            string[] sep = { operation };
            operands = input.Split(sep, StringSplitOptions.RemoveEmptyEntries);

            if (operands.Length != 2)
            {
                throw new IndexOutOfRangeException("Not valid: only 2 operands please");
            }

            Fraction frac1 = Fraction.FromString(operands[0]);
            Fraction frac2 = Fraction.FromString(operands[1]);

            Fraction result = null;

            switch (operation)
            {
                case addition:
                    result = frac1 + frac2;
                    break;

                case subtraction:
                    result = frac1 - frac2;
                    break;

                case multiplication:
                    result = frac1 * frac2;
                    break;

                case division:
                    result = frac1 / frac2;
                    break;
            }

            return result;
        }

    }
}
