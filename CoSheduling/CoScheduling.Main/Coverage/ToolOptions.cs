using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using ESRI.ArcGIS.Display;
using AGI.STKesriDisplay;

namespace CoScheduling.Main.Coverage
{
    public class ToolOptions
    {
        #region Member Variables
        public bool ShowLatLonBox = false;
        public bool FillPolygons = false;
        public double MapScaleFactor = 1.0;
        public double PixelDistFactor = 3.0;
        public Color FlashColor = Color.Green;
        public double FlashWidth = 2.0;
        #endregion
        #region Public Methods
        /// <summary>
        /// Method will apply the current values of the class to the AgEsri3dRenderer's Config.
        /// </summary>
        /// <param name="pEsri3dRenderer"></param>
        public void ApplyTo(IAgEsri3dRenderer pEsri3dRenderer)
        {
            pEsri3dRenderer.Config.FillPolygons = FillPolygons;
            pEsri3dRenderer.Config.DisplayLatLonBox = ShowLatLonBox;
            pEsri3dRenderer.Config.MapScaleFactor = MapScaleFactor;
            //IRgbColor esriColor = new RgbColorClass();
            //esriColor.Red = FlashColor.R;
            //esriColor.Green = FlashColor.G;
            //esriColor.Blue = FlashColor.B;
            //pEsri3dRenderer.Config.FlashColor = esriColor;
            pEsri3dRenderer.Config.FlashWidth = FlashWidth;
        }
        #endregion

    }
}
