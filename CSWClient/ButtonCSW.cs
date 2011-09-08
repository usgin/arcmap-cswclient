using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.esriSystem;

namespace ArcMapAddin1
{
    public class ButtonCSW : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        public ButtonCSW()
        {
        }

        protected override void OnClick()
        {
            //
            //  TODO: Sample code showing how to access button host
            //
            //FormCSW fCSW = new FormCSW();
            //fCSW.Show();

            try
            { 
                IDockableWindow dWin = this.GetDockableWindow(ArcMap.Application, "Microsoft_ArcMapAddin1_ArcGISAddinDWin");
                dWin.Show(!dWin.IsVisible());            
            }
            catch (Exception ex)
            { throw ex; }
       
            


            ArcMap.Application.CurrentTool = null;
        }
        protected override void OnUpdate()
        {
            Enabled = ArcMap.Application != null;
        }

        public IDockableWindow GetDockableWindow(IApplication app, string winName)
        {
            IDockableWindowManager dWinManager = app as IDockableWindowManager;
            UID winID = new UIDClass();
            winID.Value = winName;
            return dWinManager.GetDockableWindow(winID);
        }
    }

}
