using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PoolingV2.Services
{
    public interface ILogWriter
    {
        void LogWrite(string logMessage);
        void Log(string logMessage, TextWriter txtWriter);
    }
}
