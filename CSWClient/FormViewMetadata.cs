using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Xml;

namespace ArcMapAddin1
{
    public partial class FormViewMetadata : Form
    {
        public FormViewMetadata()
        {
            InitializeComponent();
        }

        public void OpenMetadataDoc(string urlMetadataDoc)
        {
            webBrowserMetadata.Navigate(urlMetadataDoc);
        }

    }
}
