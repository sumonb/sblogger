using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SB.Logger.Core.Common;

namespace SB.Logger.Core.Entities
{
    public class ConfigInfo
    {
    

        private string _logFolderPath;
        public string LogFolderPath
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_logFolderPath))
                {
                    _logFolderPath = Path.Combine(CommonFunc.GetApplicationPath(), "Log"); 
                }
                return _logFolderPath;
            }
            set { _logFolderPath = value; }
        }

        private string _logFilePath;
        public string LogFilePath
        {
            get
            {
                _logFilePath = Path.Combine(LogFolderPath, FileNamePattern);

                return _logFilePath;
            }
            set { _logFilePath = value; }
        }


        public string FileCreationSchedule { get; set; } //every day/ certen size -- apllicable to physical file only.

        private string _fileNamePattern;
        public string FileNamePattern
        {
            get
            {
                var currentDt = DateTime.Now;

                if (string.IsNullOrWhiteSpace(_fileNamePattern) || EveryDayNewFile.ToUpper() == "TRUE")
                {
                    _fileNamePattern = string.Format("SB.Log-{0}-{1}-{2}.log", currentDt.Year, currentDt.Month, currentDt.Day);
                }
                
                return _fileNamePattern;
            }
            set { _fileNamePattern = value; }
        }

        private string _everyDayNewFile;
        public string EveryDayNewFile
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(_everyDayNewFile)) return _everyDayNewFile;

                _everyDayNewFile = "true";
                return _fileNamePattern;
            }
            set { _fileNamePattern = value; }
        }

    }
}
