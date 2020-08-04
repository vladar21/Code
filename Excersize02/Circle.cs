using System;
using static System.Console;

namespace Excersize02
{
    public class Circle : Shape
    {        
        public Circle(double w) : base(w) { }
        public Circle(double w, double h) : base(w, h) { }
        public override void WriteAreaToConsole()
        {
            double r = this.Width;
            double S = Math.PI * r * r / 2;
            WriteLine($"S = {S}");
        }
    }
}