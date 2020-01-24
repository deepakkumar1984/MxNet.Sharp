using System;
using System.Diagnostics;
using System.IO;

namespace MxNetLib
{
    public class Logger
    {
        public static TraceLevel ERROR = TraceLevel.Error;
        public static TraceLevel INFO = TraceLevel.Info;
        public static TraceLevel OFF = TraceLevel.Off;
        public static TraceLevel VERBOSE = TraceLevel.Verbose;
        public static TraceLevel WARNING = TraceLevel.Warning;

        private string filename = "";
        private string name = "";
        private FileMode filemode = FileMode.Append;
        private TraceLevel traceLevel = WARNING;
        TextWriterTraceListener trace;

        public void Log(string message)
        {
            if(trace != null)
                trace.Write(message);

            Console.WriteLine(message);
        }

        public void Warning(string message)
        {
            if (trace != null)
                trace.Write(message);

            Console.WriteLine(message);
        }

        public void Info(string message)
        {
            if (trace != null)
                trace.Write(message);

            Console.WriteLine(message);
        }

        public void Error(string message)
        {
            if (trace != null)
                trace.Write(message);

            Console.WriteLine(message);
        }

        public class _Formatter
        {
            private ConsoleColor GetColor(TraceLevel level)
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

            private string GetLabel(TraceLevel level)
            {
                switch (level)
                {
                    case TraceLevel.Error:
                        return "E";
                    case TraceLevel.Warning:
                        return "W";
                        
                    case TraceLevel.Info:
                        return "I";
                    case TraceLevel.Verbose:
                        return "V";
                }

                return "I";
            }

            public string Format(TraceLevel level)
            {
                throw new NotImplementedException();
            }
        }

        public static Logger GetLogger(string name = null, string filename = null, FileMode fileMode = FileMode.Append,
            TraceLevel level = TraceLevel.Warning)
        {
            throw new NotImplementedException();
        }
    }
}
