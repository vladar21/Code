using System;
using static System.Console;
using System.IO;

namespace Chapter03
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                WriteLine("There are no arguments.");
            }
            else
            {
                WriteLine("There is at least one argument.");
            }

            // is in if
            object o = 3;
            int j = 4;
            if (o is int i)
            {
                WriteLine($"{i} x {j} = {i * j}");
            }
            else
            {
                WriteLine("o is not an int so it cannot multiply!");
            }

        // switch
        A_label:
            var number = (new Random()).Next(1, 7);
            WriteLine($"My random number is {number}");
            switch (number)
            {
                case 1:
                    WriteLine("One");
                    break; // переход в конец инструкции switch
                case 2:
                    WriteLine("Two");
                    goto case 1;
                case 3:
                case 4:
                    WriteLine("Three or four");
                    goto case 1;
                case 5:
                    // заснуть на полсекунды
                    System.Threading.Thread.Sleep(500);
                    goto A_label;
                default:
                    WriteLine("Default");
                    break;
            } // конец инструкции switch

            // шаблоны + switch
            string path = @"C:\Users\Admin\Downloads\Code\Chapter03"; // Windows
            Stream s = File.Open(
            Path.Combine(path, "file1.txt"),
            FileMode.OpenOrCreate);
            switch (s)
            {
                case FileStream writeableFile when s.CanWrite:
                    WriteLine("The stream is to a file that I can write to.");
                    break;
                case FileStream readOnlyFile:
                    WriteLine("The stream is to a read-only file.");
                    break;
                case MemoryStream ms:
                    WriteLine("The stream is to a memory address.");
                    break;
                default: // всегда оценивается последним,
                         // несмотря на его текущее положение
                    WriteLine("The stream is some other type.");
                    break;
                case null:
                    WriteLine("The stream is null.");
                    break;
            }
        }
    }
}
