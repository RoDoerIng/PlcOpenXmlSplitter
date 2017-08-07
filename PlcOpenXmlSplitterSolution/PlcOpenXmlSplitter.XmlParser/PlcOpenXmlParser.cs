using log4net;
using System;
using System.Collections.Generic;
using System.IO;
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
        #region Private Properties

        /// <summary>
        /// log4net logger
        /// </summary>
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// XML reader to parse XML file
        /// </summary>
        private XmlReader reader = null;
        /// <summary>
        /// contains the path of the folder which contains the XML file to be parsed
        /// </summary>
        private string xmlFolder = null;
        /// <summary>
        /// relative or absolute path to the XML file to be parsed
        /// </summary>
        private string fileName = null;

        #endregion

        #region Public Properties

        // filename to parse, initially set by constructor
        public string FileName
        {
            get { return fileName; }
            set
            {
                fileName = new FileInfo(value).FullName;
                xmlFolder = new FileInfo(fileName).DirectoryName;
            }
        }


        #endregion

        #region Constructors

        //public PlcOpenXmlParser() { }

        public PlcOpenXmlParser(string filename)
        {
            this.FileName = filename;
        }

        #endregion

        #region Methods
        public void run()
        {
            this.createReader();

            using (reader)
            {
                while (reader.Read())
                {
                    // check for start element and name attribute not empty
                    if (reader.IsStartElement() && reader.GetAttribute("name") != null)
                    {
                        // holds the value of the 'name' attribute of current xml node 
                        var nodeNameAttribute = reader.GetAttribute("name");
                        var nodeToBeSaved = XElement.Parse(reader.ReadOuterXml());
                        var exportFolder = this.xmlFolder + @"\exported\";

                        log.Debug("checked if export folder already exists");
                        if (Directory.Exists(exportFolder))
                        {
                            log.Debug("export folder already exists, do nothing...");
                        }
                        else 
                        {
                            log.Info("export folder does not exist, lets create it");
                            try
                            {
                                Directory.CreateDirectory(exportFolder);
                            }
                            catch (Exception ex)
                            {
                                log.Error("creating export folder failed", ex);
                                throw ex;
                            }
                        }

                        var fNameToSave =  exportFolder + nodeToBeSaved.Name.LocalName +"_" + nodeNameAttribute + ".xml";
                        nodeToBeSaved.Save(fNameToSave);
                        Console.WriteLine(reader.ReadOuterXml());
                        reader.Skip();
                    }
                }
            }
        }

        /// <summary>
        /// checks the validity of the property FileName and creates a private XML reader with the FileName 
        /// </summary>
        private void createReader()
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
                var ex = new ArgumentNullException("FileName", "No filename set, cannot run XML parser");
                log.Error(ex.Message, ex);
                throw ex;
            }
        }

        /// <summary>
        /// creates the folder structure specified in Readme.md
        /// </summary>
        private void createFolderStructure()
        {
            if (this.xmlFolder != null)
            {
                
            }
            else
            {
                var ex = new ArgumentNullException("xmlFolder", "No root folder specified, cannot create folder structure");
                log.Error(ex.Message, ex);
                throw ex;
            }
        }
        
        #endregion
    }
}
