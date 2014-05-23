using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using ESRI.ArcGIS.Geometry;

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
        private ListDataModel selectedItem = null;
        private PostDataCriteria pPostDaCri = new PostDataCriteria();
        private PageSwitchCriteria pPageSwitchCri = new PageSwitchCriteria();

        public ArcGISAddinDWin(object hook)
        {
            InitializeComponent();
            this.Hook = hook;

            cboCatalog.SelectedIndex = 0;
            cCswSearch.CatalogUrl = "http://catalog.usgin.org/geoportal/csw/discovery?";

            cboSearchName.SelectedIndex = 0;
            //cboMaxResults.SelectedIndex = 0;
            tboxAbstract.ReadOnly = true;
            lbPrePage.Cursor = Cursors.Hand;
            lbNxtPage.Cursor = Cursors.Hand;

            lbPrePage.Enabled = false;
            lbNxtPage.Enabled = false;

            btnMetaDoc.Enabled = false;
            btnAdd.Enabled = false;
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
            this.Cursor = Cursors.WaitCursor;
            btnMetaDoc.Enabled = false;
            btnAdd.Enabled = false;

            cCswSearch.CswUrl = tboxSearchText.Text;

            pPageSwitchCri.StartPosition = 1; ///Set the start position for page switcher

            ///Send search request////////////////////////////////////////
            if (tboxSearchText.Text == "") { tboxSearchText.Text = "*"; }
            pPostDaCri.SearchText = tboxSearchText.Text; ///Set search key word
            pPostDaCri.QueryName = cboSearchName.SelectedItem.ToString(); ///Set search name

            // CSW Servers which use pycsw need to have the namespace before the query name and are case sensitive
            if ((cCswSearch.CatalogUrl == "http://catalog.data.gov/csw?") || (cCswSearch.CatalogUrl == "http://geothermaldata.org/csw?"))
            {
                switch(pPostDaCri.QueryName)
                {
                    case "AnyText":
                        pPostDaCri.QueryName = "csw:AnyText";
                        break;
                    case "Title":
                        pPostDaCri.QueryName = "dc:title";
                        break;
                    case "Abstract":
                        pPostDaCri.QueryName = "dct:abstract";
                        break;
                }
            }

            pPostDaCri.StartPosition = pPageSwitchCri.StartPosition.ToString(); ///Set start position for search

            ///Define if the search is only for wms service / live data
            pPostDaCri.IsWmsOnly = IsWmsOnly(cboCatalog.SelectedIndex); ///Define if the search is only for wms service 
            pPostDaCri.IsLiveDataOnly = IsLivedataOnly(cboCatalog.SelectedIndex); ///Define if the search is only for live data

            ///Define if use the current extent
            if (cboxCurrentExtent.Checked == true) {
                pPostDaCri.Envelope = GetCurrentExtent(); 
            }
            else { pPostDaCri.Envelope = null;}

            cCswSearch.CswRequest(pPostDaCri, cboCatalog.SelectedIndex); ///Send request and parse response
            //////////////////////////////////////////////////////////////

            ///Set value for number of records and page switcher/////////////////////////////
            lbNumRecords.Text = "Found " + cCswSearch.NumRecords + " Records";

            int numRecords = Convert.ToInt32(cCswSearch.NumRecords);

            pPageSwitchCri.NumPages = numRecords / 15; ///Set the total number of pages for page switcher
            if (numRecords % 15 != 0) { pPageSwitchCri.NumPages++; }

            if (pPageSwitchCri.NumPages > 0) { lbNxtPage.Enabled = true; } ///Enable the next page function
            
            lbPage.Text = "Page" + "1" + "/" + pPageSwitchCri.NumPages.ToString();

            pPageSwitchCri.CurrentPage = 1; ///Set the current page number for page switcher
            /////////////////////////////////////////////////////////////////////////////////
           
            ///List Results/////////////////////////////////////////////
            rList = cCswSearch.DataList;
            lboxResults.Items.Clear();

            for (int i = 0; i < rList.Count; i++)
            {
                ListDataModel list = rList[i] as ListDataModel;
                lboxResults.Items.Add(list.Title); ///List all services
            }

            ////////////////////////////////////////////////////////////
            this.Cursor = Cursors.Default;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnAdd.Cursor = Cursors.WaitCursor;
            ///Add wms services
            ///
            
            if (selectedItem.SvicType == "WMS_Valid")
            {
                string strServiceLink = selectedItem.SvrUrl;

                cSvcOpener.OpenWMS(strServiceLink);
            }

            //////////////////////////////////////
            ///Add ArcGIS Rest services
            ///cSvcOpener.OpenAGS(strServiceLink);
            //////////////////////////////////////

            btnAdd.Cursor = Cursors.Default;
        }

        private void lboxResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            lboxResults.Cursor = Cursors.WaitCursor;

            ///Get info for the selected item
            selectedItem = rList[lboxResults.SelectedIndex] as ListDataModel;

            ///Add abstract into the text box
            tboxAbstract.Text = selectedItem.Abstract;

            ///Identify if the service can be added into the map
            if (selectedItem.SvicType == null || selectedItem.SvrUrl == null)
            { btnAdd.Enabled = false; }
            else if (selectedItem.SvicType == "WMS")
            {
                if (TestUrl(selectedItem.SvrUrl))
                {
                    btnAdd.Enabled = true;
                    selectedItem.SvicType += "_Valid";
                }
                else
                { 
                    btnAdd.Enabled = false;
                    selectedItem.SvicType = null;
                }         
            }
            else if (selectedItem.SvicType == "WMS_Valid")
            { btnAdd.Enabled = true; }

            ///Identify if the metadata document exists
            if (selectedItem.MetadataId == null)
            { btnMetaDoc.Enabled = false; }
            else
            { btnMetaDoc.Enabled = true; }

            lboxResults.Cursor = Cursors.Default;
        }

        private Boolean TestUrl(string url)
        {
            GetCapabilitiesTest cTest = new GetCapabilitiesTest();
            return cTest.IsWms(url);
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

            cCswSearch.CswRequest(pPostDaCri, cboCatalog.SelectedIndex);

            lbPage.Text = "Page " + currentPage.ToString() + "/" + numPages.ToString();

            rList = cCswSearch.DataList;
            lboxResults.Items.Clear();

            for (int i = 0; i < rList.Count; i++)
            {
                ListDataModel list = rList[i] as ListDataModel;
                lboxResults.Items.Add(list.Title); ///List search results
            }
 
        }

/*******Get Metadata Info***********************************************************/
        private void btnMetaDoc_Click(object sender, EventArgs e)
        {
            btnMetaDoc.Cursor = Cursors.WaitCursor;
/*
            XmlVisualizerWin pXmlVisualizer = new XmlVisualizerWin();
            switch (cboCatalog.SelectedIndex)
            {
                case 0:
                    string urlMetaUsginDoc = "http://catalog.usgin.org/geoportal/rest/document?id=" + selectedItem.MetadataId;
                    pXmlVisualizer.UrlMetaDoc = urlMetaUsginDoc;
                    break;
                case 1:
                    string urlMetaOnegeologyDoc = "http://onegeology-catalog.brgm.fr/geonetwork/srv/csw?request=GetRecordById&outputSchema=http://www.isotc211.org/2005/gmd&id=" + selectedItem.MetadataId;
                    pXmlVisualizer.UrlMetaDoc = urlMetaOnegeologyDoc;
                    break;
                case 2:
                    string urlMetaGeogovDoc = "http://geo.data.gov/geoportal/rest/document?id=" + selectedItem.MetadataId;
                    pXmlVisualizer.UrlMetaDoc = urlMetaGeogovDoc;
                    break;
            }
           
            pXmlVisualizer.ListMetaDocXml();
            pXmlVisualizer.Text = selectedItem.Title;
            pXmlVisualizer.Show();
*/
            FormViewMetadata pFrmViewMetadata = new FormViewMetadata();
            pFrmViewMetadata.Text = lboxResults.SelectedItem.ToString();
            switch (cboCatalog.SelectedIndex)
            {
                case 0:
                    pFrmViewMetadata.OpenMetadataDoc("http://catalog.usgin.org/geoportal/rest/document?id=" + selectedItem.MetadataId);
                    pFrmViewMetadata.Show();
                    pFrmViewMetadata.Activate();
                    break;
                case 1:
                    pFrmViewMetadata.OpenMetadataDoc("http://onegeology-catalog.brgm.fr/geonetwork/srv/csw?request=GetRecordById&outputSchema=http://www.isotc211.org/2005/gmd&id=" + selectedItem.MetadataId);
                    pFrmViewMetadata.Show();
                    pFrmViewMetadata.Activate();
                    break;
                case 2:
                    pFrmViewMetadata.OpenMetadataDoc("http://geo.data.gov/geoportal/rest/document?id=" + selectedItem.MetadataId);
                    pFrmViewMetadata.Show();
                    pFrmViewMetadata.Activate();
                    break;
                case 3:
                    pFrmViewMetadata.OpenMetadataDoc("http://catalog.stategeothermaldata.org/geoportal/rest/document?id=" + selectedItem.MetadataId);
                    pFrmViewMetadata.Show();
                    pFrmViewMetadata.Activate();
                    break;
            }


            btnMetaDoc.Cursor = Cursors.Default;
        }

/*********************************************************************************/

        private void cboCatalog_SelectedIndexChanged(object sender, EventArgs e)
        {
            lboxResults.Items.Clear();
            tboxAbstract.Clear();
            btnAdd.Enabled = false;
            btnMetaDoc.Enabled = false;

            switch (cboCatalog.SelectedIndex)
            {
                case 0:
                    cCswSearch.CatalogUrl = "http://catalog.usgin.org/geoportal/csw/discovery?";
                    cboxWms.Enabled = true;
                    cboxLivedata.Enabled = true;
                    break;
                case 1:
                    cCswSearch.CatalogUrl = "http://onegeology-catalog.brgm.fr/geonetwork/srv/csw?";
                    cboxWms.Enabled = true;
                    cboxLivedata.Enabled = false;
                    break;
                case 2:
                    cCswSearch.CatalogUrl = "http://catalog.data.gov/csw?";
                    cboxWms.Enabled = true;
                    cboxLivedata.Enabled = false;
                    break;
                case 3:
                    cCswSearch.CatalogUrl = "http://geothermaldata.org/csw?";
                    cboxWms.Enabled = true;
                    cboxLivedata.Enabled = false;
                    break;
            }
        }

/*********************************************************************************/
        /// <summary>
        /// Identify if wms parameter is needed for service type in post data
        /// </summary>
        /// <param name="index">which catalog selected</param>
        /// <returns>Need/not need wms parameter</returns>
        private Boolean IsWmsOnly(int index)
        {
            switch (index)
            {
                case 0:
                    return cboxWms.Checked;
                case 1:
                    return cboxWms.Checked;
                case 2:
                    return cboxWms.Checked;
                case 3:
                    return cboxWms.Checked;
                default:
                    return true;
            }
        }

        /// <summary>
        /// Identify if livedata parameter is needed for type in post data
        /// </summary>
        /// <param name="index">which catalog selected</param>
        /// <returns>Need/not need livedata parameter</returns>
        private Boolean IsLivedataOnly(int index)
        {
            Boolean isLivedata = true;

            switch (index)
            {
                case 0:
                    isLivedata = cboxLivedata.Checked;
                    break;
                case 1:
                    isLivedata = false;
                    break;
                case 2:
                    isLivedata = false;
                    break;
                case 3:
                    isLivedata = false;
                    break;
            }

            return isLivedata;
        }

        private Envelope GetCurrentExtent()
        {
            Envelope currentExtent;

            IEnvelope extent = ArcMap.Document.ActiveView.Extent;
            if (extent == null) return null;

            ISpatialReference CurrentMapSpatialReference = extent.SpatialReference;
            if (CurrentMapSpatialReference == null)
            {
                //MessageBox.Show("Spatial Reference is Not Defined");
                currentExtent = null;
            }
            if (CurrentMapSpatialReference is IUnknownCoordinateSystem)
            {
                // unknown cooridnate system
                MessageBox.Show("Unknown Coordinate System\n\nNo extent will be used for search");
                currentExtent = null;
            }
            else if (CurrentMapSpatialReference is IGeographicCoordinateSystem)
            {
                // already in geographical coordinate system, reuse coordinate values
                currentExtent = new Envelope(extent.XMin, extent.YMin, extent.XMax, extent.YMax);
            }
            else if (CurrentMapSpatialReference is IProjectedCoordinateSystem)
            {
                // project to geographical coordinate system
                ISpatialReferenceFactory srFactory = new SpatialReferenceEnvironmentClass();
                IGeographicCoordinateSystem gcs = srFactory.CreateGeographicCoordinateSystem((int)esriSRGeoCSType.esriSRGeoCS_WGS1984);
                gcs.SetFalseOriginAndUnits(-180, -90, 1000000);
                extent.Project(gcs);
                currentExtent = new Envelope(extent.XMin, extent.YMin, extent.XMax, extent.YMax);
            }
            else
            {
                MessageBox.Show("Unsupported Coordinate System\n\nNo extent will be used for search");
                currentExtent = null;
            }

            return currentExtent;
        }

        private void tboxSearchText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') { btnSearch_Click(sender, e); }
        }
    }
}
