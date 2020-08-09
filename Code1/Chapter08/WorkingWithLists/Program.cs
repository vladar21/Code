﻿using System;
using System.Collections.Generic;
using static System.Console;
using System.Collections.Immutable;

namespace WorkingWithLists
{
    class Program
    {
        static void Main(string[] args)
        {
            var cities = new List<string>();
            cities.Add("London");
            cities.Add("Paris");
            cities.Add("Milan");
            WriteLine("Initial list");
            foreach (string city in cities)
            {
                WriteLine($" {city}");
            }

            WriteLine($"The first city is {cities[0]}.");
            WriteLine($"The last city is {cities[cities.Count - 1]}.");
            cities.Insert(0, "Sydney");
            WriteLine("After inserting Sydney at index 0");
            foreach (string city in cities)
            {
                WriteLine($" {city}");
            }
            cities.RemoveAt(1);
            cities.Remove("Milan");
            WriteLine("After removing two cities");
            foreach (string city in cities)
            {
                WriteLine($" {city}");
            }

            var immutableCities = cities.ToImmutableList();
            immutableCities.Add("Rio");
            Write("Immutable cities:");
            foreach (string city in immutableCities)
            {
                Write($" {city}");
            }
            WriteLine();
            Write("New cities:");
            foreach (string city in immutableCities)
            {
                Write($" {city}");
            }
            WriteLine();

        }
    }
}