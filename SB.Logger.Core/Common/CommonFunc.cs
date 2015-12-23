using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SB.Logger.Core.Common
{
    public class CommonFunc
    {
        public static string GetApplicationPath()
        {
            //var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            //var uri = new UriBuilder(codeBase);
            //var path = Uri.UnescapeDataString(uri.Path);
            //return Path.GetDirectoryName(path);
            return AppDomain.CurrentDomain.BaseDirectory;
        }
    }
}
