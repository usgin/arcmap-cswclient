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
        private string strNumRecords;
        private string strCatalogUrl;

        public string CswUrl 
        {
            set 
            { strCswUrl = value; }
        }

        public string PostData
        {
            set
            { strPostDa = value; }
        }

        public string ResponseTxt
        {
            get
            { return strResponseTxt; }
        }

        public ArrayList DataList
        {
            get
            { return rDataList; }
        }

        public string NumRecords
        {
            get
            { return strNumRecords; }
        }

        public string CatalogUrl
        {
            set
            { strCatalogUrl = value; }
        }

        public void CswRequest(PostDataCriteria pPostDaCri, int indexSelectedCatalog)
        {

                ///Get xml data for post request
                ///
                CreatePostData pPostData = new CreatePostData();
                pPostData.CreatXmlDoc(pPostDaCri);
                strPostDa = pPostData.PostData;
                
                ///Send csw request         
                Uri cswUri = new Uri(strCatalogUrl);
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

                try
                {
                    ///Get csw response
                    HttpWebResponse cswResponse = (HttpWebResponse)cswRequest.GetResponse();

                    Stream cswRpStream = cswResponse.GetResponseStream();
                    StreamReader cswRpReader = new StreamReader(cswRpStream);
                    strResponseTxt = cswRpReader.ReadToEnd();
                    cswRpReader.Close();

                    ///Parse csw response
                    ParseCswResponse cPCswRp = new ParseCswResponse();
                    cPCswRp.ResponseTxt = strResponseTxt;
                    cPCswRp.ParseResponse(indexSelectedCatalog);

                    ///List all the services
                    rDataList = cPCswRp.DataList;

                    ///Other values needed in dockable window
                    strNumRecords = cPCswRp.NumRecords;
                }
                catch (WebException wex)
                { throw wex; }
                catch (Exception ex)
                { throw ex; }

        }



    }
}
