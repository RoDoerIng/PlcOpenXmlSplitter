using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace PlcOpenXmlSplitter.XmlParser
{
    public class PlcOpenXmlParser : IRunnable
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private XmlReader reader = null;

        public string FileName { get; set; } = null;

        public PlcOpenXmlParser() { }

        public PlcOpenXmlParser(string filename)
        {
            this.FileName = filename;
        }

        public void run()
        {
            //while (this.reader.Read())
            //{
            //    if (reader.Name == "pou")
            //    {
            //        var element = XmlNode();
            //        reader.ReadInnerXml();
            //    }
            //}

            this.createReader();

            var xmlDoc = XElement.Load(this.reader);

            log.Debug("Query xml document for pou elements");
            // TODO
            var root = xmlDoc.Elements();
            var pous = xmlDoc.Element("types");
            var result = from el in root.Descendants("types").Descendants("pous")
                         where el.Name.Equals("pou")
                         select el;

            log.Debug("write each pou element to separate file");
            foreach (var element in result)
            {
                log.Debug(element.BaseUri);
                var elementFileName = @"C:\Users\rdoe\Repositories\PlcOpenXmlSplitter\TestData\" + element.Attribute("name") + ".xml";
                element.Save(elementFileName);
            }
        }

        void createReader()
        {
            if (this.FileName != null)
            {
                try
                {
                    this.reader = XmlReader.Create(this.FileName);
                }
                catch (Exception ex)
                {
                    log.Error("Unable to create XML Reader from specified filename", ex);
                    throw ex;
                }
            }
            else
            {
                throw new ArgumentNullException("FileName", "No filename set, cannot run XML parser");
            }
        }
    }
}
