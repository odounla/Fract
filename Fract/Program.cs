using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fract
{
    class Program
    {

        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Please enter the operation you want to compute. Enter 'q' to exit");
                string input = Console.ReadLine();
                if (string.Compare(input, "q", true) == 0)
                    break;

                try
                {
                    Console.WriteLine(Operation.Compute(input));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            } while (true);
        }

    }
}
