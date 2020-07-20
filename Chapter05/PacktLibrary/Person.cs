using System;
using System.Collections.Generic;
using static System.Console;

namespace Packt.CS7
{
    public class Person : object
    {
        public string Name;
        public DateTime DateOfBirth;
        public WondersOfTheAncientWorld FavouriteAncientWonder;
        public WondersOfTheAncientWorld BucketList;

        public List<Person> Children = new List<Person>();
        public const string Species = "Homo Sapien";

        // поля только для чтения
        public readonly string HomePlanet = "Earth";
        public readonly DateTime Instantiated;
        // конструкторы
        public Person()
        {
            // установка дефолтных значений полей,
            // включая поля только для чтения
            Name = "Unknown";
            Instantiated = DateTime.Now;
        }

        public Person(string initialName)
        {
            Name = initialName;
            Instantiated = DateTime.Now;
        }

        // методы
        public void WriteToConsole()
        {
            WriteLine($"{Name} was born on {DateOfBirth:dddd, d MMMM yyyy}");
        }
        public string GetOrigin()
        {
            return $"{Name} was born on {HomePlanet}";
        }

        // старый синтаксис C# 4 и тип .NET 4.0 System.Tuple
        public Tuple<string, int> GetFruitCS4()
        {
            return Tuple.Create("Apples", 5);
        }
        // новый синтаксис C# 7 и новый тип System.ValueTuple
        public (string, int) GetFruitCS7()
        {
            return ("Apples", 5);
        }

        public (string Name, int Number) GetNamedFruit()
        {
            return (Name: "Apples", Number: 5);
        }
    }
}
