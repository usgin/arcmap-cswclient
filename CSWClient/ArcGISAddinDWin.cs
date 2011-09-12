using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace ArcMapAddin1
{
    /// <summary>
    /// Designer class of the dockable window add-in. It contains user interfaces that
    /// make up the dockable window.
    /// </summary>
    public partial class ArcGISAddinDWin : UserControl
    {
        private ServiceOpener cSvcOpener = new ServiceOpener();
        private CSWSearch cCswSearch = new CSWSearch();
        private ArrayList rList = new ArrayList();
        private AddLayer pAddLayer = new AddLayer();
        private ListDataModel selectedItem = null;

        public ArcGISAddinDWin(object hook)
        {
            InitializeComponent();
            this.Hook = hook;

            cboSearchName.SelectedIndex = 0;
            cboMaxResults.SelectedIndex = 0;
            tboxAbstract.ReadOnly = true;
        }

        /// <summary>
        /// Host object of the dockable window
        /// </summary>
        private object Hook
        {
            get;
            set;
        }

        /// <summary>
        /// Implementation class of the dockable window add-in. It is responsible for 
        /// creating and disposing the user interface class of the dockable window.
        /// </summary>
        public class AddinImpl : ESRI.ArcGIS.Desktop.AddIns.DockableWindow
        {
            private ArcGISAddinDWin m_windowUI;

            public AddinImpl()
            {
            }

            protected override IntPtr OnCreateChild()
            {
                m_windowUI = new ArcGISAddinDWin(this.Hook);
                return m_windowUI.Handle;
            }

            protected override void Dispose(bool disposing)
            {
                if (m_windowUI != null)
                    m_windowUI.Dispose(disposing);

                base.Dispose(disposing);
            }


        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            btnSearch.Cursor = Cursors.WaitCursor;

            cCswSearch.CswUrl = tboxSearchText.Text;

            PostDataCriteria pPostDaCri = new PostDataCriteria();

            ///Send search request////////////////////////////////////////
            pPostDaCri.SearchText = tboxSearchText.Text; ///Set search key word
            pPostDaCri.QueryName = cboSearchName.SelectedItem.ToString(); ///Set search name
            pPostDaCri.MaxRecords = cboMaxResults.SelectedItem.ToString(); ///Set max number of results for search
            cCswSearch.CswRequest(pPostDaCri);
            //////////////////////////////////////////////////////////////
            
            rList = cCswSearch.DataList;
            lboxResults.Items.Clear();

            for (int i = 0; i < rList.Count; i++)
            {
                ListDataModel list = rList[i] as ListDataModel;
                lboxResults.Items.Add(list.Title); ///List search results
            }

            btnSearch.Cursor = Cursors.Default;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ///Add wms services
            ///
            
            if (selectedItem.SvicType == "WMS")
            {
                string strServiceLink = selectedItem.SvrUrl;

                cSvcOpener.OpenWMS(strServiceLink);
            }

            //////////////////////////////////////
            ///Add ArcGIS Rest services
            ///cSvcOpener.OpenAGS(strServiceLink);
            //////////////////////////////////////
        }

        private void lboxResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            lboxResults.Cursor = Cursors.WaitCursor;

            ///Get info for the selected item
            selectedItem = rList[lboxResults.SelectedIndex] as ListDataModel;

            ///Add abstract into the text box
            tboxAbstract.Text = selectedItem.Abstract;

            ///To identify if the service can be added into the map
            if (selectedItem.SvicType == null)
            {
                btnAdd.Enabled = false;
            }
            else
            {
                btnAdd.Enabled = true;
            }

            lboxResults.Cursor = Cursors.Default;
        }



    }
}
