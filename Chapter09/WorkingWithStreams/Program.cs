﻿using System;
using System.IO;
using System.Xml;
using static System.Console;
using static System.Environment;
using static System.IO.Path;
using System.IO.Compression;


namespace WorkingWithStreams
{
    class Program
    {
        // определение массива позывных пилота Viper
        static string[] callsigns = new string[] {"Husker", "Starbuck", "Apollo", "Boomer", "Bulldog", "Athena", "Helo", "Racetrack" };
        static void WorkWithText()
        {
            // определение файла для записи
            string textFile = Combine(CurrentDirectory, "streams.txt");
            // создание текстового файла и возвращение помощника записи
            StreamWriter text = File.CreateText(textFile);
            // перечисление строк с записью каждой из них в поток в отдельной строке
            foreach (string item in callsigns)
            {
                text.WriteLine(item);
            }
            text.Close(); // release resources
                          // вывод содержимого файла в консоль
            WriteLine($"{textFile} contains {new FileInfo(textFile).Length} bytes.");
            WriteLine(File.ReadAllText(textFile));
            WriteLine(CurrentDirectory.ToString());
        }

        static void WorkWithXml()
        {
            FileStream xmlFileStream = null;
            XmlWriter xml = null;
            try
            {
                // определение файла для записи
                string xmlFile = Combine(CurrentDirectory, "streams.xml");
                // создание файловых потоков
                xmlFileStream = File.Create(xmlFile);
                // оборачивание файлового потока в помощник записи XML
                // и автоматическое добавление отступов для вложенных элементов
                xml = XmlWriter.Create(xmlFileStream,
                new XmlWriterSettings { Indent = true });
                // запись объявления XML
                xml.WriteStartDocument();
                // запись корневого элемента
                xml.WriteStartElement("callsigns");
                // перечисление строк и запись каждой в поток
                foreach (string item in callsigns)
                {
                    xml.WriteElementString("callsign", item);
                }
                // запись закрывающего корневого элемента
                xml.WriteEndElement();
                // закрытие помощника и потока
                xml.Close();
                xmlFileStream.Close();
                // вывод содержимого файла в консоль
                WriteLine($"{xmlFile} contains {new FileInfo(xmlFile).Length} bytes.");
                WriteLine(File.ReadAllText(xmlFile));
            }
            catch (Exception ex)
            {
                // если путь не существует, то исключение будет перехвачено
                WriteLine($"{ex.GetType()} says {ex.Message}");
            }
            finally
            {
                if (xml != null)
                {
                    xml.Dispose();
                    WriteLine("The XML writer's unmanaged resources have been disposed.");
                }
                if (xmlFileStream != null)
                {
                    xmlFileStream.Dispose();
                    WriteLine("The file stream's unmanaged resources have been disposed.");
                }
            }
        }

        static void WorkWithCompression()
        {
            // сжатие XML-вывода
            string gzipFilePath = Combine(CurrentDirectory, "streams.gzip");
            FileStream gzipFile = File.Create(gzipFilePath);
            using (GZipStream compressor =
            new GZipStream(gzipFile, CompressionMode.Compress))
            {
                using (XmlWriter xmlGzip = XmlWriter.Create(compressor))
                {
                    xmlGzip.WriteStartDocument();
                    xmlGzip.WriteStartElement("callsigns");
                    foreach (string item in callsigns)
                    {
                        xmlGzip.WriteElementString("callsign", item);
                    }
                }
            } // также закрывает базовый поток
              // выводит все содержимое сжатого файла в консоль
            WriteLine($"{gzipFilePath} contains {new FileInfo(gzipFilePath).Length} bytes.");
            WriteLine(File.ReadAllText(gzipFilePath));
            // чтение сжатого файла
            WriteLine("Reading the compressed XML file:");
            gzipFile = File.Open(gzipFilePath, FileMode.Open);
            using (GZipStream decompressor = new GZipStream(gzipFile, CompressionMode.Decompress))
            {
                using (XmlReader reader = XmlReader.Create(decompressor))
                {
                    while (reader.Read())
                    {
                        // проверка, находимся ли мы в данный момент на узле
                        // элемента с именем callsign
                        if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "callsign"))
                        {
                            reader.Read(); // переход к текстовому узлу внутри элемента
                            WriteLine($"{reader.Value}"); // считывание значения
                        }
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            //WorkWithText();
            WorkWithXml();
            WorkWithCompression();
        }
    }
}
