using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ArcMapAddin1
{
    public partial class XmlVisualizerWin : Form
    {
        private string strUrlMetaDoc;

        public string UrlMetaDoc
        {
            set { strUrlMetaDoc = value; }
            get { return strUrlMetaDoc; }
        }

        public XmlVisualizerWin()
        {
            InitializeComponent();
        }

        public void ListMetaDocXml()
        {
            MetadataDoc cMetadataDoc = new MetadataDoc();
            cMetadataDoc.GetMetadataDoc(strUrlMetaDoc, tviewXml);
        }
    }
}
