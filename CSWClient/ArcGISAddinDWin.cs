﻿using System;
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
        private PostDataCriteria pPostDaCri = new PostDataCriteria();
        private PageSwitchCriteria pPageSwitchCri = new PageSwitchCriteria();

        public ArcGISAddinDWin(object hook)
        {
            InitializeComponent();
            this.Hook = hook;

            cboSearchName.SelectedIndex = 0;
            //cboMaxResults.SelectedIndex = 0;
            tboxAbstract.ReadOnly = true;
            lbPrePage.Cursor = Cursors.Hand;
            lbNxtPage.Cursor = Cursors.Hand;

            lbPrePage.Enabled = false;
            lbNxtPage.Enabled = false;
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

            pPageSwitchCri.StartPosition = 1; ///Set the start position for page switcher

            ///Send search request////////////////////////////////////////
            pPostDaCri.SearchText = tboxSearchText.Text; ///Set search key word
            pPostDaCri.QueryName = cboSearchName.SelectedItem.ToString(); ///Set search name
            pPostDaCri.StartPosition = pPageSwitchCri.StartPosition.ToString(); ///Set start position for search
            cCswSearch.CswRequest(pPostDaCri);
            //////////////////////////////////////////////////////////////

            lbNumRecords.Text = "Found " + cCswSearch.NumRecords + " Records";

            int numRecords = Convert.ToInt32(cCswSearch.NumRecords);

            pPageSwitchCri.NumPages = numRecords / 15; ///Set the total number of pages for page switcher

            if (pPageSwitchCri.NumPages > 0) { lbNxtPage.Enabled = true; } ///Enable the next page function
            
            lbPage.Text = "Page" + "1" + "/" + pPageSwitchCri.NumPages.ToString();

            pPageSwitchCri.CurrentPage = 1; ///Set the current page number for page switcher
                       
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



/******* Page switch functions****************************************************/


        /// Previouse page//////////////////////////////////////
        private void lbPrePage_Click(object sender, EventArgs e)
        {
            lbPrePage.Cursor = Cursors.WaitCursor;

            ///Set new start position
            if (pPageSwitchCri.CurrentPage > 1)
            {
                pPageSwitchCri.CurrentPage -= 1; ///Set current page number
                pPageSwitchCri.StartPosition -= 15; ///Set request start position 

                RefreshSearchResults(pPageSwitchCri.CurrentPage, pPageSwitchCri.StartPosition, pPageSwitchCri.NumPages);

                if (pPageSwitchCri.CurrentPage < pPageSwitchCri.NumPages) ///Enable the next page function if this is not the last page
                { lbNxtPage.Enabled = true; }

                if (pPageSwitchCri.CurrentPage == 1) ///Disable the next page function if this is the first page
                { lbPrePage.Enabled = false; }

            }
            else
            {
                lbPrePage.Enabled = false;
                return;
            }

            lbPrePage.Cursor = Cursors.Hand;
        }

        /// Next page///////////////////////////////////////////
        private void lbNxtPage_Click(object sender, EventArgs e)
        {
            lbNxtPage.Cursor = Cursors.WaitCursor;

            ///Set new start position
            if (pPageSwitchCri.CurrentPage < pPageSwitchCri.NumPages)
            {
                pPageSwitchCri.CurrentPage += 1; ///Set current page number
                pPageSwitchCri.StartPosition += 15; ///Set request start position 

                RefreshSearchResults(pPageSwitchCri.CurrentPage, pPageSwitchCri.StartPosition, pPageSwitchCri.NumPages);

                if (pPageSwitchCri.CurrentPage > 1) ///Enable the previous page function if this is not the first page
                { lbPrePage.Enabled = true; }

                if (pPageSwitchCri.CurrentPage == pPageSwitchCri.NumPages) ///Disable the next page function if this is the last page
                { lbNxtPage.Enabled = false; }

            }
            else
            {
                lbNxtPage.Enabled = false;
                return;
            }

            lbNxtPage.Cursor = Cursors.Hand;
        }

        private void RefreshSearchResults(int currentPage, int startPosition, int numPages)
        {
            pPostDaCri.StartPosition = startPosition.ToString(); ///Set start position for the post data of request          

            cCswSearch.CswRequest(pPostDaCri);

            lbPage.Text = "Page " + currentPage.ToString() + "/" + numPages.ToString();

            rList = cCswSearch.DataList;
            lboxResults.Items.Clear();

            for (int i = 0; i < rList.Count; i++)
            {
                ListDataModel list = rList[i] as ListDataModel;
                lboxResults.Items.Add(list.Title); ///List search results
            }
 
        }


    }
}