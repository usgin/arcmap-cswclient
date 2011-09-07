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
        private AddLayer pAddLayer = new AddLayer();

        public FormCSW()
        {
            InitializeComponent();

            cboboxQueryType.SelectedIndex = 0;
            cboboxMaxResults.SelectedIndex = 0;
        }
   
        private void buttonSearchCsw_Click(object sender, EventArgs e)
        {
            cCswSearch.CswUrl = txtboxSearch.Text;

            ///Create a post data criteria object
            PostDataCriteria pPostDaCri = new PostDataCriteria();


            pPostDaCri.SearchText = txtboxSearch.Text; ///Get search text from search text box

            pPostDaCri.QueryName = cboboxQueryType.SelectedItem.ToString(); ///Get query name from the combo box

            pPostDaCri.MaxRecords = cboboxMaxResults.SelectedItem.ToString(); ///Get max results number from the combo box

            cCswSearch.CswRequest(pPostDaCri);

            rList = cCswSearch.DataList;
            lstboxCSW.Items.Clear();

            for (int i = 0; i < rList.Count; i++)
            {
                ListDataModel list = rList[i] as ListDataModel;
                lstboxCSW.Items.Add(list.Title);
            }
        
        }

        private void buttonAddLayer_Click(object sender, EventArgs e)
        {
            ///Add wms services
            if (pAddLayer.ServiceType == "WMS" || pAddLayer.ServiceType == "wms")
            {
                string strServiceLink = pAddLayer.ServerLink;
                
                if (strServiceLink[strServiceLink .Length -1] != '&')
                {
                    strServiceLink += "?"; 
                }

                cSvcOpener.OpenWMS(strServiceLink);
            }

            //////////////////////////////////////
            ///Add ArcGIS Rest services
            ///cSvcOpener.OpenAGS(strServiceLink);
            //////////////////////////////////////
            
        }

        private void lstboxCSW_SelectedIndexChanged(object sender, EventArgs e)
        {
            ///Read metadata information for the selected item
            ListDataModel selectedItem = rList[lstboxCSW.SelectedIndex] as ListDataModel;
            pAddLayer.ListDaModel = selectedItem;
            pAddLayer.GetLayerInfo();

            ///To identify if the service can be added into the map
            if (pAddLayer.ServiceType == null)
            {
                buttonAddLayer.Enabled = false;
            }
            else
            {
                buttonAddLayer.Enabled = true;
            }
        }


    }
}
