using System.Diagnostics;
using System.IO;

namespace Instrumenting
{
    class Program
    {
        static void Main(string[] args)
        {
            // запись в текстовый файл в папке проекта
            Trace.Listeners.Add(new TextWriterTraceListener(File.CreateText("log.txt")));
            // модуль записи текста буферизован, поэтому данная опция вызывает
            // Flush() для всех прослушивателей после записи
            Trace.AutoFlush = true;

            Debug.WriteLine("Debug says, I am watching!");
            Trace.WriteLine("Trace says, I am watching!");

            var ts = new TraceSwitch("PacktSwitch", "This switch is set via a command line argument.");

            if (args.Length > 0)
            {
                if (System.Enum.TryParse<TraceLevel>(args[0], ignoreCase: true, result: out TraceLevel level))
                {
                    ts.Level = level;
                }
            }
            Trace.WriteLineIf(ts.TraceError, "Trace error");
            Trace.WriteLineIf(ts.TraceWarning, "Trace warning");
            Trace.WriteLineIf(ts.TraceInfo, "Trace information");
            Trace.WriteLineIf(ts.TraceVerbose, "Trace verbose");
        }
    }
}
