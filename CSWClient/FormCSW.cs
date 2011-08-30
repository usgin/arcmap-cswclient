using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.GISClient;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase;

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

            try
            {
                ///Create an WMSMapLayer Instance - this will be added to the map later 
                IWMSGroupLayer pWMSMapLayer = new WMSMapLayerClass() as IWMSGroupLayer;

                ///Create and configure wms connection name, this is used to store the connection properties
                IWMSConnectionName pConnName = new WMSConnectionNameClass();
                IPropertySet pPropSet = new PropertySetClass();
                pPropSet.SetProperty("URL", txtboxWmsUrl.Text);
                pConnName.ConnectionProperties = pPropSet;

                ///Use the name information to connect to the service
                IDataLayer pDataLayer = pWMSMapLayer as IDataLayer;
                IName pName = pConnName as IName;
                pDataLayer.Connect(pName);

                ///Get service description, which includes the categories of wms layers
                IWMSServiceDescription pServiceDesc = pWMSMapLayer.WMSServiceDescription;

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
            catch (System.Runtime.InteropServices.COMException cEx)
            {
                ///Catch comexception handler
                MessageBox.Show("The wms url is invalid!\r\rError message:\r" + cEx.Message);
            }
            catch (Exception ex)
            { 
                ///Catch general exception handler
                MessageBox.Show(ex.StackTrace);
            }
            


        }

        private void buttonAddMapSvr_Click(object sender, EventArgs e)
        {
            try
            {
                /*
                IMapServerGroupLayer pGrpLayer = new MapServerLayerClass() as IMapServerGroupLayer;

                IAGSServerConnectionName pConnName = new AGSServerConnectionNameClass();
                IPropertySet pPropSet = new PropertySetClass();
                pPropSet.SetProperty("URL", "http://services.azgs.az.gov/ArcGIS/services/aasggeothermal/ALBoreholeTemperatures/MapServer");
                pConnName.ConnectionProperties = pPropSet;

                IName pName = pConnName as IName;
                IAGSServerConnection pAGSSConn = pName.Open() as IAGSServerConnection;

                IAGSEnumServerObjectName pAGSEnumSOName = pAGSSConn.ServerObjectNames;
                IAGSServerObjectName pSOName = pAGSEnumSOName.Next();

                IMapServerLayer pMSLayer = new MapServerLayerClass();
                pMSLayer.ServerConnect(pSOName, "TEST");


                ///Add layer to Map
                IMxDocument pMxDoc = ArcMap.Document;
                pMxDoc.FocusMap.AddLayer(pMSLayer as ILayer);

                ///Refresh
                IActiveView pActiveView = pMxDoc.FocusMap as IActiveView;
                pActiveView.Refresh();
                */

                IAGSServerConnectionFactory pAGSSvrConnFactory = new AGSServerConnectionFactoryClass();
                IPropertySet pPropSet = new PropertySetClass();
                pPropSet.SetProperty("URL", "http://services.azgs.az.gov/ArcGIS/services");
                IAGSServerConnection pAGSSvrConn = pAGSSvrConnFactory.Open(pPropSet, 0);

                IAGSEnumServerObjectName pEnumSOName = pAGSSvrConn.ServerObjectNames;
                IAGSServerObjectName pAGSSOName = pEnumSOName.Next();

                IName pName = pAGSSOName as IName;
                IMapServer pMapSvr = pName.Open() as IMapServer;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }


        }
    }
}
