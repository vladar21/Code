using System;
using System.Collections.Generic;
using static System.Console;
namespace Packt.CS7
{
    public partial class Person
    {
        // поля
        public string Name;
        public DateTime DateOfBirth;
        public List<Person> Children = new List<Person>();
        // методы
        public void WriteToConsole()
        {
            WriteLine($"{Name} was born on {DateOfBirth:dddd, d MMMM yyyy}");         
        }

        // методы "размножения"
        public static Person Procreate(Person p1, Person p2)
        {
            var baby = new Person
            {
                Name = $"Baby of {p1.Name} and {p2.Name}"
            };
            p1.Children.Add(baby);
            p2.Children.Add(baby);
            return baby;
        }
        public Person ProcreateWith(Person partner)
        {
            return Procreate(this, partner);
        }
    }
}