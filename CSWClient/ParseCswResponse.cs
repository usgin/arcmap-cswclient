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
        private string strNumRecords;
        private ArrayList rDataList = new ArrayList();

        public string ResponseTxt
        {
            set
            { strResponseTxt = value; }
        }

        public string NumRecords
        {
            get
            { return strNumRecords; }
        }

        public ArrayList DataList
        {
            get
            { return rDataList; }
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

            XmlNode ndNumRecords = xDoc.SelectSingleNode("/csw:GetRecordsResponse/csw:SearchResults/@numberOfRecordsMatched", xnManager);
            strNumRecords = ndNumRecords.InnerText;
            
            XmlNodeList ndMDaList = xDoc.SelectNodes("//csw:SearchResults/csw:Record", xnManager);
  
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

            ///Get record title info
            XmlNode ndTitle = nd.SelectSingleNode("dc:title", xnManager);
            lstData.Title = ndTitle.InnerText;

            ///Get metadata id info
            XmlNodeList ndIdentifierList = nd.SelectNodes("dc:identifier", xnManager);
            XmlNode ndMetaDaId = ndIdentifierList[1] ;
            lstData.MetadataId = ndMetaDaId.InnerText; 

            ///Get abstract info
            XmlNode ndAbstract = nd.SelectSingleNode("dct:abstract", xnManager);
            lstData.Abstract = ndAbstract.InnerText;

            ///Get the link of service and service type
            XmlNodeList ndRefList = nd.SelectNodes("dct:references", xnManager);
            string urlCapabilities;
            try
            {
                if (ndRefList != null)
                {
                    for (int iRef = 0; iRef < ndRefList.Count; iRef++)
                    {
                        XmlNode ndRef = ndRefList[iRef];
                        if (ndRef.InnerText.Contains("GetCapabilities") || ndRef.InnerText.Contains("getcapabilities"))
                        {
                            urlCapabilities = ndRef.InnerText;
                            if (urlCapabilities.Contains("=WMS")) 
                            { lstData.SvicType = "WMS"; } ///Identify the service type

                            string[] rUrlCapabilities = urlCapabilities.Split('?');

                            lstData.SvrUrl = rUrlCapabilities[0] + '?';

                            if (rUrlCapabilities[1].Contains("map="))
                            {
                                string[] urlProperties = rUrlCapabilities[1].Split('&');
                                lstData.SvrUrl += urlProperties[0] + '&';
                            }

                            break;
                        }
                    }
                }

            }
            catch (Exception ex)
            { throw ex; }
           

            return lstData;
        }

        private void Add2DaList(ListDataModel daModel)
        {
            rDataList.Add(daModel);  
        }
        
    }
}
