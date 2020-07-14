using System;

namespace Exercise02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("{0,-10} {1,-3} {2, 36} {3, 50}\n", "Type", "Byte(s) of memory", "Min", "Max");
            Console.WriteLine("{0,-10} {1,-3} {2, 50} {3, 50}\n", "int", sizeof(int), int.MinValue, int.MaxValue);
            Console.WriteLine("{0,-10} {1,-3} {2, 50} {3, 50}\n", "uint", sizeof(uint), uint.MinValue, uint.MaxValue);
            Console.WriteLine("{0,-10} {1,-3} {2, 50} {3, 50}\n", "sbyte", sizeof(sbyte), sbyte.MinValue, sbyte.MaxValue);
            Console.WriteLine("{0,-10} {1,-3} {2, 50} {3, 50}\n", "byte", sizeof(byte), byte.MinValue, byte.MaxValue);
            Console.WriteLine("{0,-10} {1,-3} {2, 50} {3, 50}\n", "short", sizeof(short), short.MinValue, short.MaxValue);
            Console.WriteLine("{0,-10} {1,-3} {2, 50} {3, 50}\n", "ushort", sizeof(ushort), ushort.MinValue, ushort.MaxValue);            
            Console.WriteLine("{0,-10} {1,-3} {2, 50} {3, 50}\n", "long", sizeof(long), long.MinValue, long.MaxValue);
            Console.WriteLine("{0,-10} {1,-3} {2, 50} {3, 50}\n", "ulong", sizeof(ulong), ulong.MinValue, ulong.MaxValue);
            Console.WriteLine("{0,-10} {1,-3} {2, 50} {3, 50}\n", "float", sizeof(float), float.MinValue, float.MaxValue);
            Console.WriteLine("{0,-10} {1,-3} {2, 50} {3, 50}\n", "double", sizeof(double), double.MinValue, double.MaxValue);
            Console.WriteLine("{0,-10} {1,-3} {2, 50} {3, 50}\n", "decimal", sizeof(decimal), decimal.MinValue, decimal.MaxValue);
        }
    }
}
