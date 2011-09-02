using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System.IO;
using System.Net;


namespace ArcMapAddin1
{
    class CSWSearch
    {
        private string strCswUrl;
        private string strPostDa;

        public string CswUrl 
        {
            set 
            {
                strCswUrl = value;
            }
        }

        public string PostData
        {
            set
            {
                strPostDa = value;
            }
        }

        public void CswRequest()
        {
            try
            {
                ///Test
                strCswUrl = "http://catalog.usgin.org/geoportal/csw/discovery?";
                System.IO.StreamReader myFile = new System.IO.StreamReader("K:\\test.xml");
                strPostDa = myFile.ReadToEnd();
                myFile.Close();
                
                ///Send csw request         
                Uri cswUri = new Uri(strCswUrl);
                HttpWebRequest cswRequest = (HttpWebRequest)WebRequest.Create(cswUri);
                cswRequest.AllowAutoRedirect = true;

                cswRequest.Method = "POST";
                cswRequest.ContentType = "text/xml;charset=UTF-8";

                UTF8Encoding encoding = new UTF8Encoding();
                Byte[] byteTemp = encoding.GetBytes(strPostDa);
                cswRequest.ContentLength = byteTemp.Length;

                Stream cswRqStream = cswRequest.GetRequestStream();
                cswRqStream.Write(byteTemp, 0, byteTemp.Length);
                cswRqStream.Close();

                ///Get csw response
                HttpWebResponse cswResponse = (HttpWebResponse)cswRequest.GetResponse();
                Stream cswRpStream = cswResponse.GetResponseStream();
                StreamReader cswRpReader = new StreamReader(cswRpStream);
                string strRpTxt = cswRpReader.ReadToEnd();
                cswRpReader.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            


        }


    }
}
