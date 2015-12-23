using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SB.Logger.Core.Common;
using SB.Logger.Core.Entities;

namespace SB.Logger.Core.Writter
{
    public class TextFileManager : IWriteComponent
    {
        private readonly ConfigInfo _configInfo;


        public TextFileManager()
        {
            var configurationManager = new ConfigurationManager();
            _configInfo = configurationManager.GetCoinfigInfo();

            //Create Directory
            if (!Directory.Exists(_configInfo.LogFolderPath))
                Directory.CreateDirectory(_configInfo.LogFolderPath);

        }


        public void WriteEntry(string message)
        {
            WriteRawData(message);
        }


        private void WriteRawData(string message)
        {
            Found:
            try
            {
                using (var writer = System.IO.File.AppendText(_configInfo.LogFilePath))
                {
                   writer.WriteLine(message);
                }
            }
            catch (Exception)
            {
                goto Found;
            }

        }

        private void GetFileInfo()
        {
            var fileInfo = new System.IO.FileInfo("");
          
        }

    }
}
