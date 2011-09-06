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
using System.Collections;



namespace ArcMapAddin1
{
    class CSWSearch
    {
        private string strCswUrl;
        private string strPostDa;
        private string strResponseTxt;
        private ArrayList rDataList;

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

        public string ResponseTxt
        {
            get
            {
                return strResponseTxt;
            }
        }

        public ArrayList DataList
        {
            get
            {
                return rDataList;
            }
        }

        public void CswRequest()
        {
            try
            {
               
                strCswUrl = "http://catalog.usgin.org/geoportal/csw/discovery?";

                ///Get xml data for post request
                CreatePostData pPostData = new CreatePostData();
                pPostData.CreatXmlDoc();
                strPostDa = pPostData.PostData;
                
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
                strResponseTxt = cswRpReader.ReadToEnd();
                cswRpReader.Close();

                ///Test
                ParseCswResponse cPCswRp = new ParseCswResponse();
                cPCswRp.ResponseTxt = strResponseTxt;
                cPCswRp.ParseResponse();

                ///List all the services
                rDataList = cPCswRp.DataList;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



    }
}
