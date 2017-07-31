using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using System.Reflection;

namespace PlcOpenXmlSplitterApp
{
    class Program
    {

        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            log.Debug("Debug message");
            log.Info("Info message");
            log.Warn("Warning message");
            log.Error("Error message");
            log.Fatal("Fatal message");
        }
    }
}
