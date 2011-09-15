using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Collections;

namespace ArcMapAddin1
{
    class MetadataDoc
    {
        private TreeView tXmlView;

        public void GetMetadataDoc(string url, TreeView tView)
        {
            tXmlView = tView;
            HttpWebResponse strResponse = MetaDataRequest(url);
            string metaDataResponseTxt = MetaDataResponseString(strResponse);

            FormatXml(metaDataResponseTxt);
        }
        private HttpWebResponse MetaDataRequest(string strMetaDataUrl)
        {
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

        private string MetaDataResponseString(HttpWebResponse response)
        {
            Stream responseStream = response.GetResponseStream();
            StreamReader responseReader = new StreamReader(responseStream);
            string strResponse = responseReader.ReadToEnd();
            responseReader.Close();

            return strResponse;
        }

        private void FormatXml(string xml)
        {
            tXmlView.Nodes.Clear();

            XmlDocument pXDoc = new XmlDocument();
            pXDoc.LoadXml(xml);

            ConvertXmlNodeToTreeNode(pXDoc, tXmlView.Nodes);

        }

        private void ConvertXmlNodeToTreeNode(XmlNode xmlNode,
          TreeNodeCollection treeNodes)
        {

            TreeNode newTreeNode = treeNodes.Add(xmlNode.Name);

            switch (xmlNode.NodeType)
            {
                case XmlNodeType.ProcessingInstruction:
                case XmlNodeType.XmlDeclaration:
                    newTreeNode.Text = "<?" + xmlNode.Name + " " +
                      xmlNode.Value + "?>";
                    break;
                case XmlNodeType.Element:
                    newTreeNode.Text = "<" + xmlNode.Name + ">";
                    break;
                case XmlNodeType.Attribute:
                    newTreeNode.Text = "ATTRIBUTE: " + xmlNode.Name;
                    break;
                case XmlNodeType.Text:
                case XmlNodeType.CDATA:
                    newTreeNode.Text = xmlNode.Value;
                    break;
                case XmlNodeType.Comment:
                    newTreeNode.Text = "<!--" + xmlNode.Value + "-->";
                    break;
            }

            if (xmlNode.Attributes != null)
            {
                foreach (XmlAttribute attribute in xmlNode.Attributes)
                {
                    ConvertXmlNodeToTreeNode(attribute, newTreeNode.Nodes);
                }
            }
            foreach (XmlNode childNode in xmlNode.ChildNodes)
            {
                ConvertXmlNodeToTreeNode(childNode, newTreeNode.Nodes);
            }
        }
    }
}
