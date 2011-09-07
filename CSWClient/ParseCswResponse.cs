using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Collections;

namespace ArcMapAddin1
{
    class ParseCswResponse
    {
        private string strResponseTxt;
        private ArrayList rDataList = new ArrayList();

        public string ResponseTxt
        {
            set
            {
                strResponseTxt = value;
            }
        }

        public ArrayList DataList
        {
            get
            {
                return rDataList;
            }
        }

        public void ParseResponse()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(strResponseTxt);
            XmlNamespaceManager xnManager = new XmlNamespaceManager(xDoc.NameTable);

            xnManager.AddNamespace("csw", "http://www.opengis.net/cat/csw/2.0.2");
            xnManager.AddNamespace("dc", "http://purl.org/dc/elements/1.1/");
            xnManager.AddNamespace("dcmiBox", "http://dublincore.org/documents/2000/07/11/dcmi-box/");
            xnManager.AddNamespace("dct", "http://purl.org/dc/terms/");
            xnManager.AddNamespace("gml", "http://www.opengis.net/gml");
            xnManager.AddNamespace("ows", "http://www.opengis.net/ows");
            xnManager.AddNamespace("xsd", "http://www.w3.org/2001/XMLSchema");

            XmlNodeList ndMDaList = xDoc.SelectNodes("//csw:SearchResults/csw:BriefRecord", xnManager);
  
            ParseSearchResults(ndMDaList, xnManager);

            
        }

        private void ParseSearchResults(XmlNodeList ndList, XmlNamespaceManager xnManager)
        {
            for (int i = 0; i < ndList.Count; i++)
            {               
                XmlNode ndMDa = ndList.Item(i);

                ListDataModel daModel = ParseEachSearchResult(ndMDa, xnManager);
                Add2DaList(daModel);
            } 
        }

        private ListDataModel ParseEachSearchResult(XmlNode nd, XmlNamespaceManager xnManager)
        {
            ListDataModel lstData = new ListDataModel();

            XmlNode ndTitle = nd.SelectSingleNode("dc:title", xnManager);
            lstData.Title = ndTitle.InnerText;

            XmlNodeList ndRefList = nd.SelectNodes("dc:identifier", xnManager);
            for (int iRef = ndRefList.Count - 1; iRef >= 0; iRef --)
            {
                XmlNode ndRef = ndRefList.Item(iRef);

                if (ndRef.Attributes.Item(0).InnerText.Contains("Metadata:DocID"))
                {
                    lstData.MetadataUrl = ndRef.InnerText;
                    break;
                }

            }

            return lstData;
        }

        private void Add2DaList(ListDataModel daModel)
        {
            rDataList.Add(daModel);  
        }
        
    }
}
