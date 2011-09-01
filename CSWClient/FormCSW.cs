using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace ArcMapAddin1
{
    public partial class FormCSW : Form
    {
        public FormCSW()
        {
            InitializeComponent();
        }

        private ServiceOpener cSvcOpener = new ServiceOpener();
        
        private void buttonAddWms_Click(object sender, EventArgs e)
        {            
            cSvcOpener.OpenWMS(txtboxWmsUrl.Text);
        }

        private void buttonAddMapSvr_Click(object sender, EventArgs e)
        {
            cSvcOpener.OpenAGS(txtboxWmsUrl.Text);
        }
    }
}
