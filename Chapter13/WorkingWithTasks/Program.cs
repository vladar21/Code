﻿using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using static System.Console;

namespace WorkingWithTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            var timer = Stopwatch.StartNew();

            //WriteLine("Running methods synchronously on one thread.");
            //MethodA();
            //MethodB();
            //MethodC();            

            /*WriteLine("Running methods asynchronously on multiple threads.");
            Task taskA = new Task(MethodA);
            taskA.Start();
            Task taskB = Task.Factory.StartNew(MethodB);
            Task taskC = Task.Run(new Action(MethodC));

            Task[] tasks = { taskA, taskB, taskC };
            Task.WaitAll(tasks);*/

            WriteLine("Passing the result of one task as an input into another.");
            var taskCallWebServiceAndThenStoredProcedure = 
                Task.Factory.StartNew(CallWebService)
                .ContinueWith(previousTask => CallStoredProcedure(previousTask.Result));
            WriteLine($"{taskCallWebServiceAndThenStoredProcedure.Result}");

            WriteLine($"{timer.ElapsedMilliseconds:#,##0}ms elapsed.");
            WriteLine("Press ENTER to end.");
            ReadLine();

        }

        static void MethodA()
        {
            WriteLine("Starting Method A...");
            Thread.Sleep(3000); // имитация работы в течение трех секунд
            WriteLine("Finished Method A.");
        }

        static void MethodB()
        {
            WriteLine("Starting Method B...");
            Thread.Sleep(2000); // имитация работы в течение двух секунд
            WriteLine("Finished Method B.");
        }

        static void MethodC()
        {
            WriteLine("Starting Method C...");
            Thread.Sleep(1000); // имитация работы в течение одной секунды
            WriteLine("Finished Method C.");
        }

        static decimal CallWebService()
        {
            WriteLine("Starting call to web service...");
            Thread.Sleep((new Random()).Next(2000, 4000));
            WriteLine("Finished call to web service.");
            return 89.99M;
        }
        static string CallStoredProcedure(decimal amount)
        {
            WriteLine("Starting call to stored procedure...");
            Thread.Sleep((new Random()).Next(2000, 4000));
            WriteLine("Finished call to stored procedure.");
            return $"12 products cost more than {amount:C}.";
        }
    }
}
