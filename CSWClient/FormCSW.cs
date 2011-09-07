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
        private ServiceOpener cSvcOpener = new ServiceOpener();
        private CSWSearch cCswSearch = new CSWSearch();
        private ArrayList rList = new ArrayList();

        public FormCSW()
        {
            InitializeComponent();

            cboboxQueryType.SelectedIndex = 0;
            cboboxMaxResults.SelectedIndex = 0;
        }
   
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
            cCswSearch.CswUrl = txtboxSearch.Text;

            ///Create a post data criteria object
            PostDataCriteria pPostDaCri = new PostDataCriteria();

            ///Get search text from search text box
            pPostDaCri.SearchText = txtboxSearch.Text;
            ///Get query name from the combo box
            pPostDaCri.QueryName = cboboxQueryType.SelectedItem.ToString();
            ///Get max results number from the combo box
            pPostDaCri.MaxRecords = cboboxMaxResults.SelectedItem.ToString();

            cCswSearch.CswRequest(pPostDaCri);

            rList = cCswSearch.DataList;
            lstboxCSW.Items.Clear();

            for (int i = 0; i < rList.Count; i++)
            {
                ListDataModel list = rList[i] as ListDataModel;
                lstboxCSW.Items.Add(list.Title);
            }
        
        }


    }
}
