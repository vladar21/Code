using System;

namespace Excersize02
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle sh1 = new Circle(5);
            sh1.WriteAreaToConsole();
            Circle h = new Circle(5, 5);
            Shape sh2 = (Shape)h;
            sh2.WriteAreaToConsole();
        }
    }
}
