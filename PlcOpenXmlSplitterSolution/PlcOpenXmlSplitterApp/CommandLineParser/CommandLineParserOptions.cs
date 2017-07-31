using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using CommandLine.Text;

namespace PlcOpenXmlSplitter.CommandLineParser
{
    class CommandLineParserOptions
    {
        [Option('f', "file", Required = true, HelpText = "Input plcOpen XML-file to be processed.")]
        public string plcOpenXmlFile { get; set; }

        /*
        [Option('v', "verbose", DefaultValue = true,
          HelpText = "Prints all messages to standard output.")]
        public bool Verbose { get; set; }
        */

        [ParserState]
        public IParserState LastParserState { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this,
              (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
}
