using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.GISClient;
using ESRI.ArcGIS.esriSystem;

namespace ArcMapAddin1
{
    public partial class FormCSW : Form
    {
        public FormCSW()
        {
            InitializeComponent();
        }

        private void buttonAddWms_Click(object sender, EventArgs e)
        {
            ///Create an WMSMapLayer Instance - this will be added to the map later 
            IWMSGroupLayer pWMSMapLayer = new WMSMapLayer() as IWMSGroupLayer;

            ///Create and configure wms connection name, this is used to store the connection properties
            IWMSConnectionName pConnName = new WMSConnectionName();
            IPropertySet pPropSet = new PropertySet();
            pPropSet.SetProperty("URL", txtboxWmsUrl.Text);
            pConnName.ConnectionProperties = pPropSet;

            ///Use the name information to connect to the service
            IDataLayer pDataLayer = pWMSMapLayer as IDataLayer;
            IName pName = pConnName as IName;
            pDataLayer.Connect(pName);

            ///Get service description, which includes the categories of wms layers
            IWMSServiceDescription pServiceDesc = pWMSMapLayer.WMSServiceDescription;

            for (int i = 0; i < pServiceDesc.LayerDescriptionCount; i++)
            {
                IWMSLayerDescription pLayerDesc = pServiceDesc.get_LayerDescription(i);

                if (pLayerDesc.LayerDescriptionCount == 1) ///When this category only has one layer
                {
                    IWMSLayer pNewWMSLayer = pWMSMapLayer.CreateWMSLayer(pLayerDesc);
                }
                else ///When this category has two layers or more
                {
                    IWMSGroupLayer pGrpLayer = pWMSMapLayer.CreateWMSGroupLayers(pLayerDesc);
                }

            }

            ///Configure the layer before adding it to the map
            ILayer pLayer = pWMSMapLayer as ILayer;
            pLayer.Name = pServiceDesc.WMSTitle;

            ///Add layer to Map
            IMxDocument pMxDoc = ArcMap.Document;
            pMxDoc.FocusMap.AddLayer(pLayer);

            ///Refresh
            IActiveView pActiveView = pMxDoc.FocusMap as IActiveView;
            pActiveView.Refresh();
        }
    }
}
