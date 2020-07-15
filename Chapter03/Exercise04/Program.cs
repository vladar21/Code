using System;
using static System.Console;

namespace Exercise04
{
    class Program
    {
        static void Main(string[] args)
        {
            string ns1;
            string ns2;
            byte nb1;
            byte nb2;

            Write("Please, enter a number one between 0 and 255: ");
            ns1 = ReadLine();
            Write("Please, enter another number between 0 and 255: ");            
            ns2 = ReadLine();

            try
            {
                nb1 = Byte.Parse(ns1);
                nb2 = Byte.Parse(ns2);

                WriteLine($"{nb1} divided by {nb2} is {nb1 / nb2}");
            }
            catch (FormatException)
            {
                WriteLine("Input string was not in a correct format.");
            }
            catch (Exception ex)
            {
                WriteLine($"{ex.GetType()} : {ex.Message}");
            }
            

        }
    }
}
