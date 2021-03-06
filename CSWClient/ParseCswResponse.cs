﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Collections;
using System.Diagnostics;

namespace ArcMapAddin1
{
    class ParseCswResponse
    {
        private string strResponseTxt;
        private string strNumRecords;
        private ArrayList rDataList = new ArrayList(); ///Data array for each item in the search listbox

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

        public void ParseResponse(int indexCatalog)
        {
            switch (indexCatalog)
            {
                case 0:
                    ParseGeoportalCatalog(0);
                    break;
                case 1:
                    ParseOnegeologyCatalog(1);
                    break;
                case 2:
                    ParseGeoportalCatalog(2);
                    break;
                case 3:
                    ParseGeoportalCatalog(3);
                    break;
            }
          
        }

/// <summary>
/// Parse the response from Geoportal Catalog
/// </summary>
        private void ParseGeoportalCatalog(int indexCatalog)
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

            ParseSearchResults(ndMDaList, xnManager, indexCatalog);
        }

        private ListDataModel ParseEachGeoportalSearchResult(XmlNode nd, XmlNamespaceManager xnManager)
        {
            ListDataModel lstData = new ListDataModel();

            ///Get record title info
            XmlNode ndTitle = nd.SelectSingleNode("dc:title", xnManager);
            lstData.Title = ndTitle.InnerText;

            ///Get metadata id info
            XmlNodeList ndIdentifierList = nd.SelectNodes("dc:identifier", xnManager);
            for (int i = 0; i < ndIdentifierList.Count; i++)
            {
                XmlNode ndMetaDaId = ndIdentifierList[i];
                for(int j = 0; j < ndMetaDaId.Attributes.Count; j ++)
                {
                    if (ndMetaDaId.Attributes[j].Name == "scheme" && ndMetaDaId.Attributes[j].Value.Contains("DocID"))
                    { lstData.MetadataId = ndMetaDaId.InnerText; break; }
                }
            }
            
            

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
                        if (ndRef.InnerText.Contains("GetCapabilities") || ndRef.InnerText.Contains("getcapabilities") || ndRef.InnerText.Contains("getCapabilities"))
                        {
                            urlCapabilities = ndRef.InnerText;

                            if (urlCapabilities.Contains("=WMS") || urlCapabilities.Contains("=wms"))
                            { lstData.SvicType = "WMS"; } ///Identify the service type
                            else { break; }

                            string[] rUrlCapabilities = urlCapabilities.Split('?');

                            lstData.SvrUrl = rUrlCapabilities[0] + '?';

                            if (rUrlCapabilities[1].Contains("map="))
                            {
                                string[] urlProperties = rUrlCapabilities[1].Split('&');
                                lstData.SvrUrl += urlProperties[0] + '&';
                            }

                            break;
                        }
                        else if (ndRef.InnerText.Contains("Capabilities") || ndRef.InnerText.Contains("capabilities"))
                        {
                            ///Write log for invalid GetCapabilities url
                            Log cLog = new Log("InvalidGetCapabilitiesUrl");
                            cLog.WriteLog(ndTitle.InnerText);
                            cLog.WriteLog(ndRef.InnerText);
                            cLog.CloseLog();
                        }
                    }
                }

            }
            catch (Exception ex)
            { throw ex; }
           

            return lstData;
        }

        /// <summary>
        /// Parse the response from Geoportal catalog, with multi distributions in the response
        /// </summary>
        private ListDataModel ParseEachMultiDistGeoportalSearchResult(XmlNode nd, XmlNamespaceManager xnManager)
        {
            ListDataModel lstData = new ListDataModel();

            ///Get record title info
            XmlNode ndTitle = nd.SelectSingleNode("dc:title", xnManager);
            lstData.Title = ndTitle.InnerText;

            ///Get metadata id info
            XmlNodeList ndIdentifierList = nd.SelectNodes("dc:identifier", xnManager);
            for (int i = 0; i < ndIdentifierList.Count; i++)
            {
                XmlNode ndMetaDaId = ndIdentifierList[i];
                if (ndMetaDaId.InnerText != null)
                {
                    lstData.MetadataId = ndMetaDaId.InnerText;
                }
                for (int j = 0; j < ndMetaDaId.Attributes.Count; j++)
                {
                    if (ndMetaDaId.Attributes[j].Name == "scheme" && ndMetaDaId.Attributes[j].Value.Contains("DocID"))
                    { lstData.MetadataId = ndMetaDaId.InnerText; break; }
                }
            }

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
                        for (int iAttr = 0; iAttr < ndRef.Attributes.Count; iAttr++)
                        {
                            if (ndRef.Attributes[iAttr].Name == "scheme" && ndRef.Attributes[iAttr].Value.Contains("OGC:WMS"))
                            {
                                lstData.SvicType = "WMS";

                                urlCapabilities = ndRef.InnerText;
                                string[] rUrlCapabilities = urlCapabilities.Split('?');

                                lstData.SvrUrl = rUrlCapabilities[0] + '?';
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            { throw ex; }


            return lstData;
        }
/// <summary>
/// Parse the response from OneGeology Catalog
/// </summary>
        private void ParseOnegeologyCatalog(int indexCatalog)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(strResponseTxt);
            XmlNamespaceManager xnManager = new XmlNamespaceManager(xDoc.NameTable);

            xnManager.AddNamespace("csw", "http://www.opengis.net/cat/csw/2.0.2");
            xnManager.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            xnManager.AddNamespace("dc", "http://purl.org/dc/elements/1.1/");
            xnManager.AddNamespace("dct", "http://purl.org/dc/terms/");
            xnManager.AddNamespace("ows", "http://www.opengis.net/ows");
            xnManager.AddNamespace("geonet", "http://www.fao.org/geonetwork");

            XmlNode ndNumRecords = xDoc.SelectSingleNode("/csw:GetRecordsResponse/csw:SearchResults/@numberOfRecordsMatched", xnManager);
            strNumRecords = ndNumRecords.InnerText;

            XmlNodeList ndMDaList = xDoc.SelectNodes("//csw:SearchResults/csw:Record", xnManager);

            ParseSearchResults(ndMDaList, xnManager, indexCatalog);
        }

        private ListDataModel ParseEachOnegeologySearchResult(XmlNode nd, XmlNamespaceManager xnManager)
        {
            ListDataModel lstData = new ListDataModel();

            ///Get record title info
            XmlNode ndTitle = nd.SelectSingleNode("dc:title", xnManager);
            lstData.Title = ndTitle.InnerText;

            ///Get metadata id info
            XmlNode ndIdentifier = nd.SelectSingleNode("dc:identifier", xnManager);
            lstData.MetadataId = ndIdentifier.InnerText;

            ///Get abstract info
            XmlNode ndAbstract = nd.SelectSingleNode("dct:abstract", xnManager);
            lstData.Abstract = ndAbstract.InnerText;

            ///Get the link of service and service type
            XmlNodeList ndRefList = nd.SelectNodes("dc:URI", xnManager);
            try
            {
                if (ndRefList != null)
                {
                    for (int iRef = 0; iRef < ndRefList.Count; iRef++)
                    {
                        XmlNode ndRef = ndRefList[iRef];
                        XmlAttributeCollection ndAttrColl = ndRef.Attributes;
                        for (int iAtt = 0; iAtt < ndAttrColl.Count; iAtt++)
                        {
                            if (ndAttrColl[iAtt].Name == "protocol" && ndRef.Attributes[0].Value.Contains("OGC:WMS")) ///Looking for wms service-
                            { 
                                lstData.SvicType = "WMS"; 
                                if(ndRef.InnerText.Contains('?')) ///When the service url has '&' in the end
                                { 
                                    lstData.SvrUrl = ndRef.InnerText;
                                    break;
                                } 
                                else if (!ndRef.InnerText.Contains('?')) ///When the service url needs '?' in the end
                                { 
                                    lstData.SvrUrl = ndRef.InnerText + '?';
                                    break;
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            { throw ex; }


            return lstData;
        }

/// <summary>
/// Reusable functions
/// </summary>
        private void ParseSearchResults(XmlNodeList ndList, XmlNamespaceManager xnManager, int indexCatalog)
        {
            for (int i = 0; i < ndList.Count; i++)
            {
                XmlNode ndMDa = ndList.Item(i);

                switch (indexCatalog)
                {
                    case 0:
                        ListDataModel aasgModel = ParseEachGeoportalSearchResult(ndMDa, xnManager);
                        Add2DaList(aasgModel);
                        break;
                    case 1:
                        ListDataModel onegeologyModel = ParseEachOnegeologySearchResult(ndMDa, xnManager);
                        Add2DaList(onegeologyModel);
                        break;
                    case 2:
                        ListDataModel geogovModel = ParseEachMultiDistGeoportalSearchResult(ndMDa, xnManager);
                        Add2DaList(geogovModel);
                        break;
                    case 3:
                        ListDataModel usginModel = ParseEachMultiDistGeoportalSearchResult(ndMDa, xnManager);
                        Add2DaList(usginModel);
                        break;
                }          
            }
        }
        
        private void Add2DaList(ListDataModel daModel)
        {
            rDataList.Add(daModel);  
        }
        
    }
}
