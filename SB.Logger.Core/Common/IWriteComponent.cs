using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SB.Logger.Core.Common
{
    public interface IWriteComponent
    {
        void WriteEntry(string message);
    }
}
