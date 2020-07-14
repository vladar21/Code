using System;
using static System.Console;

namespace Variables
{
    class Program
    {
        static void Main(string[] args)
        {
            object height = 1.88; // хранение double в виде объекта
            object name = "Amir"; // хранение string в виде объекта
            //int length1 = name.Length; // выдает ошибку компиляции!
            int length2 = ((string)name).Length; // приведение для доступа к членам
            WriteLine(length2);

            int population = 66_000_000; // 66 миллионов человек в Англии
            double weight = 1.88; // в килограммах
            decimal price = 4.99M; // в фунтах стерлингов
            string fruit = "Apples"; // строки в двойных кавычках
            char letter = 'Z'; // символы в одиночных кавычках
            bool happy = true; // логическое значение — true или false

            WriteLine($"{default(int)}"); // 0
            WriteLine($"{default(bool)}"); // False
            WriteLine($"{default(DateTime)}"); // 1/01/0001 00:00:00

            string authorName = null;
            // если authorName равно null, то вместо вызова исключения вернуть null
            int? howManyLetters = authorName?.Length;
            WriteLine((howManyLetters ?? 0));

            // объявление размера массива
            string[] names = new string[4];
            // хранение элементов с индексами позиций
            names[0] = "Kate";
            names[1] = "Jack";
            names[2] = "Rebecca";
            names[3] = "Tom";
            for (int i = 0; i < names.Length; i++)
            {
                WriteLine(names[i]); // прочитать элемент с данным индексом позиции
            }

            WriteLine($"The UK population is {population}.");
            Write($"The UK population is {population:N0}. ");
            WriteLine($"{weight}kg of {fruit} costs {price:C}.");

            Write("Type your first name and press ENTER: ");
            string firstName = ReadLine();
            Write("Type your age and press ENTER: ");
            string age = ReadLine();
            WriteLine($"Hello {firstName}, you look good for {age}.");
        }
    }
}
