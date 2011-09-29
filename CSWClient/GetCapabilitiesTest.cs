using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

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
                Log cLog = new Log("WebException");
                cLog.WriteLog(urlGetCapabilities);
                cLog.WriteLog(wex.Status.ToString());
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
    }
}
