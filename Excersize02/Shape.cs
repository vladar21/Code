using System;
using static System.Console;

namespace Excersize02
{
    public class Shape
    {
        public double Width { get; set; }
        public double? Height { get; set; }
        public double Area { get; set; }

        public Shape (double w, double h){ Width = w; Height = h; }
        public Shape (double w){ Width = w; Height = null; }

        public virtual void WriteAreaToConsole()
        {
            double S = 0;
            if (Height != null)
            {
                S = Width * (double)Height;
            }
            
            WriteLine($"S = {S}");
        }
    }
}