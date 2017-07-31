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
                var xmlFile = File.Open(cmdOptions.plcOpenXmlFile, FileMode.Open);
                Console.WriteLine(xmlFile.CanRead);
                xmlFile.Close();
            }
        }
    }
}
