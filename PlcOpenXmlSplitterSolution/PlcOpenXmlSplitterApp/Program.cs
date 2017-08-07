using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using System.Reflection;
using PlcOpenXmlSplitter.CommandLineParser;
using System.IO;
using PlcOpenXmlSplitter.XmlParser;

namespace PlcOpenXmlSplitter
{
    class Program
    {

        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            var cmdOptions = new CommandLineParserOptions();

            if (CommandLine.Parser.Default.ParseArguments(args, cmdOptions))
            {
                log.Debug("commandline arguments successfully parsed");
                IRunnable parser = new PlcOpenXmlParser(cmdOptions.plcOpenXmlFile);
                parser.run();
            }
        }
    }
}
