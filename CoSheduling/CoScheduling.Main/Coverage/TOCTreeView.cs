using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using AGI.STKesriDisplay;

namespace CoScheduling.Main.Coverage
{
    public partial class TOCTreeView : TreeView
    {
        #region enums and constants
        public const int NOIMAGE = 0;
        public enum StateImages : int
        {
            NoCheckBox = -1,
            CheckBoxUnChecked = 0,
            CheckBoxChecked = 1
        };
        #endregion

        #region Member variables
        IAgEsri3dRenderer m_Renderer;
        /// <summary>
        /// Sets the STK Renderer
        /// </summary>
        public IAgEsri3dRenderer Renderer
        {
            set
            {
                m_Renderer = value;
            }
        }
        #endregion
        public TOCTreeView()
        {
            InitializeComponent();
            base.LineColor = SystemColors.GrayText;

            base.DrawMode = TreeViewDrawMode.OwnerDrawAll;

            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            ImageList = new ImageList();

            Bitmap bitmap = new Bitmap(16, 16);
            ImageList.Images.Add(bitmap);

            StateImageList = new ImageList();
            bitmap = new Bitmap(16, 16);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                System.Drawing.Point gp = new System.Drawing.Point(2, 2);
                CheckBoxRenderer.DrawCheckBox(g, gp, CheckBoxState.UncheckedNormal);
            }
            StateImageList.Images.Add(bitmap);
            bitmap = new Bitmap(16, 16);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                System.Drawing.Point gp = new System.Drawing.Point(2, 2);
                CheckBoxRenderer.DrawCheckBox(g, gp, CheckBoxState.CheckedNormal);
            }
            StateImageList.Images.Add(bitmap);
            ImageKey = "";
            SelectedImageKey = "";
        }

       // public TOCTreeView(IContainer container)
        //{
           // container.Add(this);

            //InitializeComponent();
        //}

        #region Events
        /// <summary>
        /// This method is used to draw dashed lines over the TreeNodes that do not have Images
        /// </summary>
        /// <param name="e"></param>
        protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        {
            const int SPACE_IL = 3;  // space between Image and Label

            // we only do additional drawing
            e.DrawDefault = true;

            base.OnDrawNode(e);

            if (base.ShowLines && base.ImageList != null && e.Node.ImageIndex == NOIMAGE)
            {
                // Image size
                int imgW = base.ImageList.ImageSize.Width;
                int imgH = base.ImageList.ImageSize.Height;

                // Image center
                int xPos = e.Node.Bounds.Left - SPACE_IL - imgW / 2;
                int yPos = (e.Node.Bounds.Top + e.Node.Bounds.Bottom) / 2;

                // Image rect
                Rectangle imgRect = new Rectangle(xPos, yPos, 0, 0);
                imgRect.Inflate(imgW / 2, imgH / 2);

                using (Pen p = new Pen(base.LineColor, 1))
                {
                    p.DashStyle = DashStyle.Dot;

                    // account uneven Indent for both lines
                    p.DashOffset = base.Indent % 2;

                    // Horizontal treeline across width of image
                    // account uneven half of delta ItemHeight & ImageHeight
                    int yHor = yPos + ((base.ItemHeight - imgRect.Height) / 2) % 2;

                    e.Graphics.DrawLine(p,
                        (base.ShowRootLines || e.Node.Level > 0) ? imgRect.Left : xPos - (int)p.DashOffset,
                        yHor, imgRect.Right, yHor);


                    if (!base.CheckBoxes && e.Node.IsExpanded)
                    {
                        int yVer = yHor + (int)p.DashOffset;
                        e.Graphics.DrawLine(p, xPos, yVer, xPos, e.Node.Bounds.Bottom);
                    }
                }
            }
        }
        /// <summary>
        /// This method does cleanup of the dashed lines previously drawn.  
        /// </summary>
        /// <param name="e"></param>
        protected override void OnAfterCollapse(TreeViewEventArgs e)
        {
            base.OnAfterCollapse(e);

            if (!base.CheckBoxes && base.ImageList != null && e.Node.ImageIndex == NOIMAGE)
            {
                // DrawNode event not raised: redraw node with collapsed treeline
                base.Invalidate(e.Node.Bounds);
            }
        }
        /// <summary>
        /// This method is called when the user clicks a TreeViewNode
        /// This method handles changing the StateImage to checked or unchecked.
        /// It also handles the right click, allowing the user to remove layers and zoom-to layers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTOCTreeViewNodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                TreeViewHitTestLocations hitResult = this.HitTest(e.Location).Location;
                if (hitResult.Equals(TreeViewHitTestLocations.StateImage))
                {
                    TreeView view = sender as TreeView;
                    if (view != null)
                    {
                        TreeNode node = e.Node;
                        if (node != null)
                        {
                            ILayer layer = node.Tag as ILayer;
                            if (layer != null)
                            {
                                if (node.StateImageIndex == (int)TOCTreeView.StateImages.CheckBoxUnChecked)
                                {
                                    node.StateImageIndex = (int)TOCTreeView.StateImages.CheckBoxChecked;
                                    layer.Visible = true;
                                    this.Refresh();
                                    m_Renderer.Refresh(false);
                                }
                                else if (node.StateImageIndex == (int)TOCTreeView.StateImages.CheckBoxChecked)
                                {
                                    node.StateImageIndex = (int)TOCTreeView.StateImages.CheckBoxUnChecked;
                                    layer.Visible = false;
                                    this.Refresh();
                                    m_Renderer.Refresh(false);
                                }
                            }
                        }

                    }
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                ILayer layer = this.GetNodeAt(e.Location).Tag as ILayer;
                if (layer != null)
                {
                    MenuItem[] menuItems = new MenuItem[2];
                    menuItems[0] = new MenuItem("删除图层", new EventHandler(OnTOCTreeViewDeleteLayer));
                    menuItems[0].Tag = layer;
                    menuItems[1] = new MenuItem("定位图层", new EventHandler(OnTOCTreeViewZoomToLayer));
                    menuItems[1].Tag = layer;
                    System.Windows.Forms.ContextMenu contextMenu = new System.Windows.Forms.ContextMenu(menuItems);
                    contextMenu.Show(this, e.Location);
                }
            }
        }
        /// <summary>
        /// Method is called when the user right clicks the ESRI treeview and chooses to Delete Layer. 
        /// It will delete a layer from the map. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTOCTreeViewDeleteLayer(object sender, EventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            // Begin Map Editing Session
            m_Renderer.StartMapEditing(AgESTKesriCallOptions.eEsri3dBlocking);

            // Delete the Layer
            m_Renderer.MapDocument.ActiveView.FocusMap.DeleteLayer(menuItem.Tag as ILayer);

            // End Map Editing Session
            m_Renderer.StopMapEditing(false);

            System.Runtime.InteropServices.Marshal.ReleaseComObject(menuItem.Tag);
            this.UpdateTreeView(m_Renderer.MapDocument.ActiveView.FocusMap);
        }
        /// <summary>
        /// This method is called when the user right clicks a layer in the ESRI tree view and chooses 
        /// Zoom To Layer.
        /// Method will zoom to the chosen layer. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTOCTreeViewZoomToLayer(object sender, EventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            m_Renderer.ZoomToLayer(menuItem.Tag as ILayer);
        }
        #endregion
        #region Private Helper Methods
        /// <summary>
        /// This recursive method will Populate the treeview. 
        /// </summary>
        /// <param name="layer">The current layer</param>
        /// <param name="parentNode">The parent TreeNode</param>
        private void PopulateTree(ILayer layer, TreeNode parentNode)
        {
            TreeNode node = new TreeNode(layer.Name);
            ILegendInfo legendInfo = layer as ILegendInfo;

            if (legendInfo != null)
            {
                ILegendGroup legendGroup;
                for (int i = 0; i < legendInfo.LegendGroupCount; ++i)
                {

                    ILegendClass legendClass;
                    legendGroup = legendInfo.get_LegendGroup(i);

                    for (int j = 0; j < legendGroup.ClassCount; ++j)
                    {
                        IAgEsri3dSymbolHelper symbolHelper = this.m_Renderer.Context.CreateObject("STKesriDisplay10.AgEsri3dSymbolHelper") as IAgEsri3dSymbolHelper;//new AgEsri3dSymbolHelperClass();

                        symbolHelper.SetUseSymbolSize(true);

                        legendClass = legendGroup.get_Class(j);
                        TreeNode legendClassNode = new TreeNode(legendClass.Label);

                        ISymbol symbol;
                        symbol = legendClass.Symbol;
                        if (symbolHelper != null)
                        {
                            int bmp;
                            bmp = symbolHelper.ToBitmap(symbol);
                            IntPtr bmpPtr = new IntPtr(bmp);
                            legendClassNode.ImageIndex = this.ImageList.Images.Count;
                            legendClassNode.SelectedImageIndex = legendClassNode.ImageIndex;
                            Bitmap bitmap = Bitmap.FromHbitmap(bmpPtr);

                            bitmap.MakeTransparent(Color.FromArgb(85, 85, 85));
                            bitmap.SetResolution(30, 30);
                            this.ImageList.Images.Add(StandardizeBitmap((bitmap)));
                        }

                        node.Nodes.Add(legendClassNode);
                    }
                }
            }
            node.ImageIndex = NOIMAGE;

            parentNode.Nodes.Add(node);
            node.Checked = (layer.Visible && layer.Valid);
            node.Tag = layer;

            ICompositeLayer subLayer = layer as ICompositeLayer;
            if (subLayer != null)
            {
                for (int i = 0; i < subLayer.Count; ++i)
                {
                    PopulateTree(subLayer.get_Layer(i), node);
                }
            }
        }
        /// <summary>
        /// This method will return a bitmap of size 16x16 with the given smaller bitmap at the center.
        /// </summary>
        /// <param name="bitmap">The smaller bitmap</param>
        /// <returns>A 16x16 bitmap with the given bitmap in the center</returns>
        private Bitmap StandardizeBitmap(Bitmap bitmap)
        {
            Bitmap standardBitmap = new Bitmap(16, 16);
            if (((standardBitmap.Width - bitmap.Width) > 0) && ((standardBitmap.Height - bitmap.Height) > 0))
            {

                double startX = (standardBitmap.Width - bitmap.Width) / 2.0;
                double startY = (standardBitmap.Height - bitmap.Height) / 2.0;

                for (int x = (int)Math.Floor(startX); x < standardBitmap.Width - Math.Ceiling(startX); ++x)
                {
                    for (int y = (int)Math.Floor(startY); y < standardBitmap.Height - Math.Ceiling(startY); ++y)
                    {
                        standardBitmap.SetPixel(x, y, bitmap.GetPixel(x - (int)Math.Floor(startX), y - (int)Math.Floor(startY)));
                    }
                }
            }
            else
            {
                standardBitmap = bitmap;
            }
            return standardBitmap;
        }
        /// <summary>
        /// This recursive method will check the check boxes
        /// of each Node in the tree if it's visible and valid
        /// </summary>
        /// <param name="currentNode">The current node to check.</param>
        private void CheckTree(TreeNode currentNode)
        {
            foreach (TreeNode node in currentNode.Nodes)
            {
                ILayer layer = node.Tag as ILayer;
                if (layer != null)
                {
                    if (layer.Visible && layer.Valid)
                    {
                        node.StateImageIndex = (int)StateImages.CheckBoxChecked;
                    }
                    else
                    {
                        node.StateImageIndex = (int)StateImages.CheckBoxUnChecked;
                    }
                }
                else
                {
                    node.StateImageIndex = (int)StateImages.NoCheckBox;
                }
                CheckTree(node);
            }
        }
        #endregion
        #region Public Methods
        /// <summary>
        /// Updates the treeview based on the given IMap document
        /// </summary>
        /// <param name="map">The Map for which to populate the TreeView</param>
        public void UpdateTreeView(IMap map)
        {
            this.BeginUpdate();
            this.Nodes.Clear();
            for (int i = 0; i < map.LayerCount; ++i)
            {
                TreeNode root = new TreeNode();
                ESRI.ArcGIS.Carto.ILayer l = map.get_Layer(i);

                PopulateTree(l, root);

                Nodes.Add(root.FirstNode);

                root.FirstNode.Expand();

                this.Indent = 2;
                //this.CheckBoxes = true;

                CheckTree(root);
            }
            this.EndUpdate();
        }
        /// <summary>
        /// This method will clear the tree and Release all the com objects associated. 
        /// </summary>
        public void Clear()
        {
            foreach (TreeNode tn in this.Nodes)
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(tn.Tag);
                tn.Tag = null;
            }
            Nodes.Clear();
        }
        #endregion
    }
}
