using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace ArcMapAddin1
{
    class ParseMetaDataResponse
    {
        private string strServerLink = null;
        private string strServiceType = null;

        public string ServerLink
        {
            get
            { return strServerLink; }
        }

        public string ServiceType
        {
            get
            { return strServiceType; }
        }

        public void ParseMetaDataXml(string strMetaDataXml)
        {
            XmlDocument xMetaData = new XmlDocument();
            xMetaData.LoadXml(strMetaDataXml);

            XmlNamespaceManager xnsManager = new XmlNamespaceManager(xMetaData.NameTable);
            xnsManager.AddNamespace("xlink", "http://www.w3.org/1999/xlink");
            xnsManager.AddNamespace("srv", "http://www.isotc211.org/2005/srv");
            xnsManager.AddNamespace("gmd", "http://www.isotc211.org/2005/gmd");
            xnsManager.AddNamespace("fo", "http://www.w3.org/1999/XSL/Format");
            xnsManager.AddNamespace("gco", "http://www.isotc211.org/2005/gco");
            xnsManager.AddNamespace("exslt", "http://exslt.org/common");
            xnsManager.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");


            XmlNode ndServerLink = xMetaData.SelectSingleNode("//gmd:identificationInfo/srv:SV_ServiceIdentification/srv:containsOperations/srv:SV_OperationMetadata/srv:connectPoint/CI_OnlineResource/linkage/URL", xnsManager);
            XmlNode ndServiceType = xMetaData.SelectSingleNode("//gmd:MD_Metadata/gmd:identificationInfo/srv:SV_ServiceIdentification/srv:serviceType/gco:LocalName", xnsManager);

            if (ndServiceType != null)
            {
                strServerLink = ndServerLink.InnerText;
                strServiceType = ndServiceType.InnerText;
            }
        }
    }
}
