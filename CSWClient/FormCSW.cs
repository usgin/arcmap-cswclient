using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections;

namespace ArcMapAddin1
{
    public partial class FormCSW : Form
    {
        public FormCSW()
        {
            InitializeComponent();
        }

        private ServiceOpener cSvcOpener = new ServiceOpener();
        private CSWSearch cCswSearch = new CSWSearch();
        
        private void buttonAddWms_Click(object sender, EventArgs e)
        {            
            cSvcOpener.OpenWMS(txtboxWmsUrl.Text);
        }

        private void buttonAddMapSvr_Click(object sender, EventArgs e)
        {
            cSvcOpener.OpenAGS(txtboxWmsUrl.Text);
        }


        private void buttonSearchCsw_Click(object sender, EventArgs e)
        {
            cCswSearch.CswUrl = txtboxCswUrl.Text;
            cCswSearch.CswRequest();

            ArrayList rList = cCswSearch.DataList;

            for (int i = 0; i < rList.Count; i++)
            {
                ListDataModel list = rList[i] as ListDataModel;
                lstboxCSW.Items.Add(list.Title);
            }

            
        }

    }
}
