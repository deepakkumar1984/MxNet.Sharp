using System;
using System.Diagnostics;
using System.IO;

namespace MxNet
{
    public class Logger : IDisposable
    {
        private string filename = "";
        private string name = "";
        static TextWriterTraceListener trace;

        public static void Log(string message, TraceLevel level = TraceLevel.Verbose)
        {
            if(trace != null)
                trace.Write(Formatter.FormatMessage(message, level));

            Console.ForegroundColor = Formatter.GetColor(level);
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void Warning(string message)
        {
            Log(message, TraceLevel.Warning);
        }

        public static void Info(string message)
        {
            Log(message, TraceLevel.Info);
        }

        public static void Error(string message)
        {
            Log(message, TraceLevel.Error);
        }

        public static void Configure(string filename, string name = "")
        {
            if(!string.IsNullOrWhiteSpace(name))
                trace = new TextWriterTraceListener(filename, name);
            else
                trace = new TextWriterTraceListener(filename);
        }

        public void Dispose()
        {
            trace.Close();
            trace.Dispose();
        }

        public class Formatter
        {
            public static ConsoleColor GetColor(TraceLevel level)
            {
                ConsoleColor color = ConsoleColor.White;

                switch (level)
                {
                    case TraceLevel.Error:
                        color = ConsoleColor.Red;
                        break;
                    case TraceLevel.Warning:
                        color = ConsoleColor.DarkYellow;
                        break;
                    case TraceLevel.Info:
                    case TraceLevel.Verbose:
                        color = ConsoleColor.White;
                        break;
                    default:
                        break;
                }

                return color;
            }

            public static string GetLabel(TraceLevel level)
            {
                switch (level)
                {
                    case TraceLevel.Error:
                        return "ERROR";
                    case TraceLevel.Warning:
                        return "WARNING";
                    case TraceLevel.Info:
                        return "INFO";
                    case TraceLevel.Verbose:
                        return "VERBOSE";
                }

                return "I";
            }

            public static string FormatMessage(string message, TraceLevel level)
            {
                return string.Format("{0}: {1}", GetLabel(level), message);
            }
        }
    }
}
