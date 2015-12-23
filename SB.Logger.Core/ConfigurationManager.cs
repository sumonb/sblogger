using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SB.Logger.Core.Entities;

namespace SB.Logger.Core
{
    public interface IConfigurationManager
    {
        ConfigInfo LoadConfiguration();
        ConfigInfo GetCoinfigInfo();
    }

    public class ConfigurationManager : IConfigurationManager
    {
        public ConfigInfo LoadConfiguration()
        {
            return null;
        }

        public ConfigInfo GetCoinfigInfo()
        {
            return new ConfigInfo();
        }

    }
}
