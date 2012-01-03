using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Xml;
using System.Collections;

///This is a sample to use this class
///GetCapabilitiesTest pTest = new GetCapabilitiesTest();
///If(pTest.IsWms(<ServiceUrl>)){...};

namespace ArcMapAddin1
{
    class GetCapabilitiesTest
    {
        public Boolean IsWms(string urlWmsService)
        {
            string urlWmsGetCapabilities = urlWmsService + "service=WMS&request=GetCapabilities";

            return this.IsOk(urlWmsGetCapabilities);
        }

        private Boolean IsOk(string urlGetCapabilities)
        {
            string urlStatusChecker = "http://registry.fgdc.gov/statuschecker/services/rest/index.php?url="
                + urlGetCapabilities + "&type=wms&formattype=xml&requesttype=brief";

            Uri uriStatusChecker = new Uri(urlStatusChecker);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uriStatusChecker);

            request.Method = "GET";
            request.ContentType = "text/xml;charset=UTF-8";
            request.Timeout = 30000;

            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                Stream rpStream = response.GetResponseStream();

                StreamReader rpReader = new StreamReader(rpStream);
                string strResponse = rpReader.ReadToEnd();
                rpReader.Close();

                return parseResponse(strResponse);
            }
            catch (WebException wex)
            {
                return false;
                throw wex;             
            }
        }

        /*
        private Boolean IsOk(string urlGetCapabilities)
        {
            ///Send GetCapabilities request         
            Uri uriGetCapabilities = new Uri(urlGetCapabilities);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uriGetCapabilities);

            request.Method = "GET";
            request.ContentType = "text/xml;charset=UTF-8";
            request.Timeout = 30000;


            try
            {
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                Debug.WriteLine(urlGetCapabilities);
                response.Close();
                return true;
            }
            catch (WebException wex)
            {
                ///Write the log for web exception
                Log cLog = new Log("WebExceptionLog");
                cLog.WriteLog(urlGetCapabilities);
                cLog.WriteLog("Exception Status: " + wex.Status.ToString());
                cLog.CloseLog();

                Debug.WriteLine(urlGetCapabilities);
                Debug.WriteLine(wex.Status.ToString());
                if (wex.Response != null) {
                    HttpWebResponse rps = (HttpWebResponse)wex.Response;
                    Debug.WriteLine(rps.StatusDescription);
                    wex.Response.Close(); 
                }
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(urlGetCapabilities);
                Debug.WriteLine(ex.Message);
                return false;
            }
                       
        }
        */    
    
        private Boolean parseResponse(string strResponse)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(strResponse);
            XmlNamespaceManager xnManager = new XmlNamespaceManager(xDoc.NameTable);

            xnManager.AddNamespace("fgdc", "http://registry.gsdi.org/statuschecker/services/rest/");
            xnManager.AddNamespace("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
            xnManager.AddNamespace("xsi:schemaLocation", "http://registry.gsdi.org/statuschecker/services/rest/responseSchema.xsd");

            XmlNode ndPerformanceScore = xDoc.SelectSingleNode("//fgdc:response/fgdc:service/fgdc:summary/fgdc:scoredTest/fgdc:performance[2]", xnManager);
            if (Convert.ToDouble(ndPerformanceScore.InnerText) > 0) { return true; }
            else { return false; }
        }
    }
}
