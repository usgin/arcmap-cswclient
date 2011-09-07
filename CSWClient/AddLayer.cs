using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Collections;

namespace ArcMapAddin1
{
    class AddLayer
    {
        private ListDataModel cListDaModel;
        private string strServerLink;
        private string strServiceType;

        public ListDataModel ListDaModel
        {
            set { cListDaModel = value; }
        }

        public string ServerLink
        {
            get { return strServerLink; }
        }

        public string ServiceType
        {
            get { return strServiceType; }
        }

        public void AddLayer2Map()
        {
            //MessageBox.Show(cListDaModel.MetadataUrl);

            ///Send metadata request and get response string 
            HttpWebResponse metaDataResponse = MetaDataRequest(this.cListDaModel.MetadataUrl);
            string mataDataResponseTxt = MetaDataResponseString(metaDataResponse);

            ///Parse metadata response
            ParseMetaDataResponse pParseMetaDaRp = new ParseMetaDataResponse();
            pParseMetaDaRp.ParseMetaDataXml(mataDataResponseTxt);

            ///Get the link for server
            strServerLink = pParseMetaDaRp.ServerLink;
            ///Get the service type
            strServiceType = pParseMetaDaRp.ServiceType;
        }

        public HttpWebResponse MetaDataRequest(string pDocID)
        {
            string strMetaDataUrl = "http://catalog.usgin.org/geoportal/rest/document?id=" + pDocID;

            Uri metaDataUri = new Uri(strMetaDataUrl);
            HttpWebRequest metaDataRequest = (HttpWebRequest)WebRequest.Create(metaDataUri);
            metaDataRequest.Method = "GET";
            metaDataRequest.ContentType = "text/xml;charset=UTF-8";

            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse)metaDataRequest.GetResponse();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }

        public string MetaDataResponseString(HttpWebResponse response)
        {
            Stream responseStream = response.GetResponseStream();
            StreamReader responseReader = new StreamReader(responseStream);
            string strResponse = responseReader.ReadToEnd();
            responseReader.Close();

            return strResponse;
        }
    }
}
