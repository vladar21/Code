using System.Collections.Generic;

namespace Packt.CS7
{
    public class PersonComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            // Сравнение длины полей Name...
            int temp = x.Name.Length.CompareTo(y.Name.Length);
            // ...если они одинаковы...
            if (temp == 0)
            {
                // ...выполнить сортировку по именам...
                return x.Name.CompareTo(y.Name);
            }
            else
            {
                // ...иначе сортировать по длине.
                return temp;
            }
        }
    }
}
