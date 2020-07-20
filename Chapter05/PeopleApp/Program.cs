﻿using System;
using Packt.CS7;
using static System.Console;

namespace PeopleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var p1 = new Person();
            p1.Name = "Bob Smith";
            p1.DateOfBirth = new System.DateTime(1965, 12, 22);

            WriteLine($"{p1.Name} was born on {p1.DateOfBirth:dddd, d MMMM yyyy}");

            var p2 = new Person
            {
                Name = "Alice Jones",
                DateOfBirth = new DateTime(1998, 3, 17)
            };
            WriteLine($"{p2.Name} was born on {p2.DateOfBirth:d MMMM yy}");

            p1.FavouriteAncientWonder = WondersOfTheAncientWorld.StatueOfZeusAtOlympia;
            WriteLine($"{p1.Name}'s favourite wonder is {p1.FavouriteAncientWonder}");

            p1.BucketList = WondersOfTheAncientWorld.HangingGardensOfBabylon |
WondersOfTheAncientWorld.MausoleumAtHalicarnassus;
            // p1.BucketList = (WondersOfTheAncientWorld)18;
            WriteLine($"{p1.Name}'s bucket list is {p1.BucketList}");

            p1.Children.Add(new Person { Name = "Alfred" });
            p1.Children.Add(new Person { Name = "Zoe" });
            WriteLine($" {p1.Name} has {p1.Children.Count} children:");
            for (int child = 0; child < p1.Children.Count; child++)
            {
                WriteLine($" {p1.Children[child].Name}");
            }

            BankAccount.InterestRate = 0.012M;
            var ba1 = new BankAccount();
            ba1.AccountName = "Mrs. Jones";
            ba1.Balance = 2400;
            WriteLine($"{ba1.AccountName} earned {ba1.Balance * BankAccount.InterestRate:C} interest.");
            var ba2 = new BankAccount();
            ba2.AccountName = "Ms. Gerrier";
            ba2.Balance = 98;
            WriteLine($"{ba2.AccountName} earned {ba2.Balance * BankAccount.InterestRate:C} interest.");

            WriteLine($"{p1.Name} is a {Person.Species}");

            var p3 = new Person();
            WriteLine($"{p3.Name} was instantiated at {p3.Instantiated:hh:mm:ss} on {p3.Instantiated:dddd, d MMMM yyyy}");

            var p4 = new Person("Aziz");
            WriteLine($"{p4.Name} was instantiated at { p4.Instantiated:hh:mm:ss} on { p4.Instantiated:dddd, d MMMM yyyy}");

            p1.WriteToConsole();
            WriteLine(p1.GetOrigin());

            Tuple<string, int> fruit4 = p1.GetFruitCS4();
            WriteLine($"There are {fruit4.Item2} {fruit4.Item1}.");
            (string, int) fruit7 = p1.GetFruitCS7();
            WriteLine($"{fruit7.Item1}, {fruit7.Item2} there are.");

            var fruitNamed = p1.GetNamedFruit();
            WriteLine($"Are there {fruitNamed.Number} {fruitNamed.Name}?");

            // C# 7.0
            var thing1 = ("Neville", 4);
            WriteLine($"{thing1.Item1} has {thing1.Item2} children.");
            var thing2 = (p1.Name, p1.Children.Count);
            WriteLine($"{thing2.Item1} has {thing2.Item2} children.");

            // C# 7.1
            var thing3 = (p1.Name, p1.Children.Count);
            WriteLine($"{thing3.Name} has {thing3.Count} children.");

            // деконструкция кортежей
            (string fruitName, int fruitNumber) = p1.GetFruitCS7();
            WriteLine($"Deconstructed: {fruitName}, {fruitNumber}");
        }
    }
}
