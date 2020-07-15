using System;
using static System.Console;

namespace CheckingForOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                checked
                {
                    int x = int.MaxValue - 1;
                    WriteLine(x);
                    x++;
                    WriteLine(x);
                    x++;
                    WriteLine(x);
                    x++;
                    WriteLine(x);
                }
            }
            catch (OverflowException)
            {
                WriteLine("The code overflowed but I caught the exception");
            }


            unchecked
            {
                int y = int.MaxValue + 1;
                WriteLine(y); // выведет -2147483648
                y--;
                WriteLine(y); // выведет 2147483647
                y--;
                WriteLine(y); // выведет 2147483646
            }

            int z;
            
            checked
            {
                int max = 500;
                for (byte i = 0; i < max; i++)
                {
                    WriteLine(i);
                }
            }

        }
    }
}
