using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SB.Logger.Core;
using SB.Logger.Core.Writter;

namespace SB.Logger.Console
{
    class Program
    {
        private static readonly ISBLogger Logger = SBLogger.ConfigureForTextFile();

        static void Main(string[] args)
        {
            Logit();
        }

        private static void Logit()
        {
            for (int i = 0; i < 100000; i++)
            {
                try
                {
                    Logger.LogInfo("starting");
                    int a = 1;
                    int b = 1;
                    int c = a/b;
                   
                }
                catch (Exception ex)
                {
                   Logger.LogError(ex);
                }
                
            }
        }
    }
}
