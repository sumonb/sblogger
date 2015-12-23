using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SB.Logger.Core.Common;
using SB.Logger.Core.Entities;
using SB.Logger.Core.Writter;

namespace SB.Logger.Core
{
    public interface ISBLogger
    {
        void Log(string text);
        void LogInfo(string text);
        void LogError(string text);
        void LogError(Exception ex);
    }

    public class SBLogger : ISBLogger
    {
        private static SBLogger _instance;
        private static IWriteComponent _currentWriter;

        public static SBLogger ConfigureForTextFile()
        {
            if (_instance != null) return _instance;

            _currentWriter = new TextFileManager();
            return _instance = new SBLogger();
        }

        public void Log(string text)
        {
            _currentWriter.WriteEntry(text);
        }

        public void LogInfo(string text)
        {
            _currentWriter.WriteEntry(FormatTextWithLogType(Constants.LoggingType.Info, text));
        }

        public void LogError(string text)
        {
            _currentWriter.WriteEntry(FormatTextWithLogType(Constants.LoggingType.Error, text));
        }

        public void LogError(Exception ex)
        {
            LogError(ex.ToString());
        }

        private static string FormatTextWithLogType(string loggingType, string text)
        {
            return string.Format("({0}) [{1}]:- {2}", DateTime.Now, loggingType, text);

        }


        private static string FormatTextWithDebugInfo(string loggingType, string text)
        {
            var stb = new StringBuilder();
            var stackTrace = new StackTrace(true);           // get call stack

            stb.AppendLine(string.Format("({0}) [{1}]:-", DateTime.Now, loggingType));
            for (var i = 2; i < stackTrace.FrameCount; i++)
            {
                var sf = stackTrace.GetFrame(i);
                if (sf.GetFileName() == null) break;

                stb.AppendLine(string.Format("\t(ClassName: {0}, MethodName: {1})", sf.GetMethod().DeclaringType, sf.GetMethod().ToString()));
            }

            stb.AppendLine(text);
            stb.AppendLine("");
            return stb.ToString();

        }





    }
}
