using System; // DateTime
using System.Collections.Generic; // List<T>, HashSet<T>
using System.Xml.Serialization; // XmlSerializer
using System.IO; // FileStream
using Packt.CS7; // Person
using static System.Console;
using static System.Environment;
using static System.IO.Path;
using Newtonsoft.Json;


namespace WorkingWithSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            // создание графа объектов
            var people = new List<Person>
            {
                new Person(30000M) { FirstName = "Alice", LastName = "Smith", DateOfBirth = new DateTime(1974, 3, 14) },
                new Person(40000M) { FirstName = "Bob", LastName = "Jones", DateOfBirth = new DateTime(1969, 11, 23) },
                new Person(20000M) 
                { 
                    FirstName = "Charlie", 
                    LastName = "Rose", 
                    DateOfBirth = new DateTime(1964, 5, 4),
                    Children = new HashSet<Person>
                    { 
                        new Person(0M) 
                        { 
                            FirstName = "Sally", 
                            LastName = "Rose", 
                            DateOfBirth = new DateTime(1990, 7, 12) 
                        } 
                    } 
                }
            };
            // создание файла для записи
            string path = Combine(CurrentDirectory, "people.xml");
            FileStream stream = File.Create(path);
            // создание объекта, который будет отформатирован в виде
            // списка людей в формате XML
            var xs = new XmlSerializer(typeof(List<Person>));
            // сериализация графа объектов в поток
            xs.Serialize(stream, people);
            // необходимо закрыть поток, чтобы разблокировать файл
            stream.Close();
            WriteLine($"Written {new FileInfo(path).Length} bytes of XML to {path}");
            WriteLine();
            // отображение сериализованного графа объектов
            WriteLine(File.ReadAllText(path));

            FileStream xmlLoad = File.Open(path, FileMode.Open);
            // десериализация и приведение графа объектов к списку людей
            var loadedPeople = (List<Person>)xs.Deserialize(xmlLoad);
            foreach (var item in loadedPeople)
            {
                WriteLine($"{item.LastName} has {item.Children.Count} children.");
            }
            xmlLoad.Close();

            // создание файла для записи
            string jsonPath = Combine(CurrentDirectory, "people.json");
            StreamWriter jsonStream = File.CreateText(jsonPath);
            // создание объекта для форматирования в JSON
            var jss = new JsonSerializer();
            // сериализация графа объектов в строку
            jss.Serialize(jsonStream, people);
            jsonStream.Close(); // разблокировать файл
            WriteLine();
            WriteLine($"Written {new FileInfo(jsonPath).Length} bytes of JSON to: { jsonPath}");
            // отображение сериализованного графа объектов
            WriteLine(File.ReadAllText(jsonPath));
        }
    }
}
