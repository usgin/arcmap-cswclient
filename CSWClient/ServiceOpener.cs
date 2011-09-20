using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.GISClient;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Desktop.AddIns;

namespace ArcMapAddin1
{
    public class ServiceOpener
    {
    /// <summary>
    /// Add a new layer to the current map
    /// </summary>
    /// <param name="pLayer"></param>
        private void AddLayer(ILayer pLayer)
        {
            VisibleSubLayers(pLayer);
            ///Add layer to Map
            IMxDocument pMxDoc = ArcMap.Document;
            pMxDoc.FocusMap.AddLayer(pLayer);
            
            ///Refresh
            IActiveView pActiveView = pMxDoc.FocusMap as IActiveView;
            pActiveView.Refresh();
        }

        private void VisibleSubLayers(ILayer pSvicLayer)
        {
            ICompositeLayer2 pSubLayer = pSvicLayer as ICompositeLayer2;

            if (pSubLayer != null)
            {
                for (int i = 0; i < pSubLayer.Count; i ++)
                {
                    VisibleSubLayers(pSubLayer.get_Layer(i));
                }
            }

            pSvicLayer.Visible = true;
 
        }

    /// <summary>
    /// Parse WMS Service
    /// </summary>
    /// <param name="urlWMS"></param>
        public void OpenWMS(string urlWMS)
        {
            try
            {
                ///Create an WMSMapLayer Instance - this will be added to the map later 
                IWMSGroupLayer pWMSMapLayer = new WMSMapLayerClass() as IWMSGroupLayer;

                ///Create and configure wms connection name, this is used to store the connection properties
                IWMSConnectionName pConnName = new WMSConnectionNameClass();
                IPropertySet pPropSet = new PropertySetClass();
                pPropSet.SetProperty("URL", urlWMS);
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
                AddLayer(pLayer);
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
    /// <summary>
    /// Parse ArcGIS MapServer Service
    /// </summary>
    /// <param name="urlAGS"></param>
        public void OpenAGS(string urlAGS)
        {
            try
            {
                ///Parse the url for MapServer -- get the service url and the service name 
                string strUrl = urlAGS;
                string[] strUrlParts = strUrl.Split('/');
                string strUrlSvr = null;
                string strSvrName = null;

                for (int i = 0; i < strUrlParts.Length; i++)
                {
                    if (strUrlParts[i] == "services")
                    {
                        strUrlSvr = string.Join("/", strUrlParts.Take(i + 1).ToArray());

                        for (int j = i + 1; j < strUrlParts.Length - 1; j++)
                        {
                            if (strSvrName != null)
                                strSvrName += "/";
                            strSvrName += strUrlParts[j];
                        }
                        break;
                    }
                }


                ///Set up ArcGIS Service connection factory, which includes the list of services
                IAGSServerConnectionFactory pAGSSvrConnFactory = new AGSServerConnectionFactoryClass();
                IPropertySet pPropSet = new PropertySetClass();
                pPropSet.SetProperty("URL", strUrlSvr);
                IAGSServerConnection pAGSSvrConn = pAGSSvrConnFactory.Open(pPropSet, 0);

                ///Get the list of services
                IAGSEnumServerObjectName pEnumSOName = pAGSSvrConn.ServerObjectNames;
                IAGSServerObjectName pAGSSOName = pEnumSOName.Next();

                ///Get the specific service with the service name
                while (pAGSSOName != null)
                {
                    Debug.WriteLine(pAGSSOName.Name + ":" + pAGSSOName.Type);

                    if (pAGSSOName.Name == strSvrName && pAGSSOName.Type == "MapServer")
                    {
                        break;
                    }

                    pAGSSOName = pEnumSOName.Next();
                }

                ///Open the specific service
                IName pName = pAGSSOName as IName;
                IMapServer pMapServer = pName.Open() as IMapServer;

                IMapServerLayer pMapSvrLayer = new MapServerLayerClass();
                pMapSvrLayer.ServerConnect(pAGSSOName, pMapServer.DefaultMapName);

                ///Configure the layer before adding it to the map
                ILayer pLayer = pMapSvrLayer as ILayer;
                AddLayer(pLayer);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
    }
}
