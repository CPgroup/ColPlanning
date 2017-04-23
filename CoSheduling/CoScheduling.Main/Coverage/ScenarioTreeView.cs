using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

using AGI.STKObjects;
using AGI.STKesriDisplay;
using AxAGI.STKX;
using AGI.STKUtil;
using AGI.STKX;


namespace CoScheduling.Main.Coverage
{
    public partial class ScenarioTreeView : TreeView
    {
        public const int NOIMAGE = 0;
        #region Member variables
       
        private TreeNode m_RootNode = null;
        private string m_STKIconDir = "";
        #endregion
        #region Event Handlers
        private IAgStkObjectRootEvents_OnStkObjectAddedEventHandler m_OnStkObjectAddedEventHandler;
        private IAgStkObjectRootEvents_OnStkObjectDeletedEventHandler m_OnStkObjectDeletedEventHandler;
        private IAgStkObjectRootEvents_OnStkObjectRenamedEventHandler m_OnStkObjectRenamedEventHandler;
        private IAgStkObjectRootEvents_OnScenarioNewEventHandler m_OnScenarioNewEventHandler;
        private IAgStkObjectRootEvents_OnScenarioCloseEventHandler m_OnScenarioCloseEventHandler;
        #endregion
        #region Set-Up
        //private AgStkObjectRoot stkRootObject = null;
        private AgStkObjectRoot stkRootObject;
        private AGI.STKObjects.AgStkObjectRoot stkRoot
        {
            get
            {
                if (stkRootObject == null)
                {
                    stkRootObject = new AGI.STKObjects.AgStkObjectRootClass();
                }
                return stkRootObject;
            }
        }
        #endregion
        public ScenarioTreeView()
        {
            InitializeComponent();
            this.ImageList = new ImageList();
            base.LineColor = SystemColors.GrayText;

            base.DrawMode = TreeViewDrawMode.OwnerDrawAll;
        }

        //public ScenarioTreeView(IContainer container)
        //{
            //container.Add(this);

            //InitializeComponent();
        //}
        #region
        public void InitializeTreeView()
        {            
            AGI.STKUtil.AgExecCmdResult execResult = (AGI.STKUtil.AgExecCmdResult)stkRoot.CurrentScenario.Root.ExecuteCommand("GetDirectory / STKHome");
            m_STKIconDir = Path.Combine(execResult[0], @"STKData\Pixmaps");

            m_OnStkObjectAddedEventHandler = OnSTKRootObjectAdded;
            m_OnStkObjectDeletedEventHandler = OnSTKRootStkObjectDeleted;
            m_OnStkObjectRenamedEventHandler = OnSTKRootStkObjectRenamed;
            m_OnScenarioNewEventHandler = OnSTKRootScenarioNew;
            m_OnScenarioCloseEventHandler = OnSTKRootScenarioClose;

            stkRoot.OnStkObjectAdded += m_OnStkObjectAddedEventHandler;
            stkRoot.OnStkObjectDeleted += m_OnStkObjectDeletedEventHandler;
            stkRoot.OnStkObjectRenamed += m_OnStkObjectRenamedEventHandler;
            stkRoot.OnScenarioNew += m_OnScenarioNewEventHandler;
            stkRoot.OnScenarioClose += m_OnScenarioCloseEventHandler;

            UpdateTreeView();
        }
        #endregion
        #region Event Methods
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
        /// Called when STK Scenaro Closes
        /// </summary>
        void OnSTKRootScenarioClose()
        {
            this.Nodes.Clear();
        }
        /// <summary>
        /// Called when a new STK Scenario is loaded.
        /// </summary>
        /// <param name="Path"></param>
        void OnSTKRootScenarioNew(string Path)
        {
            UpdateTreeView();
        }
        /// <summary>
        /// Called when STK Object is renamed
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="OldPath"></param>
        /// <param name="NewPath"></param>
        void OnSTKRootStkObjectRenamed(object Sender, string OldPath, string NewPath)
        {
            UpdateTreeView();
        }
        /// <summary>
        /// Called when an STK Object is deleted
        /// </summary>
        /// <param name="Sender"></param>
        void OnSTKRootStkObjectDeleted(object Sender)
        {
            UpdateTreeView();
        }
        /// <summary>
        /// Called when an STK Object is added
        /// </summary>
        /// <param name="Sender"></param>
        void OnSTKRootObjectAdded(object Sender)
        {
            UpdateTreeView();
        }
        #endregion
        #region Treeview Helper Methods
        /// <summary>
        /// This recursive method will populate the TreeView from a root AgStkObject
        /// </summary>
        /// <param name="obj">The parent STKObect</param>
        /// <param name="parent">The parent TreeNode</param>
        private void PopulateTreeView(IAgStkObject stkObjParent,TreeNode parentTreeNode)
        {
            TreeNode childNode = new TreeNode(stkObjParent.InstanceName);
            string imageName = stkObjParent.ClassType.ToString().Remove(0,1) + ".bmp";
            string imagePath = Path.Combine(m_STKIconDir, imageName);
            if (File.Exists(imagePath))
            {
                if (!this.ImageList.Images.ContainsKey(imagePath))
                {
                    childNode.ImageIndex = this.ImageList.Images.Count;                    
                    ImageList.Images.Add(new Bitmap(imagePath));
                    childNode.SelectedImageIndex = childNode.ImageIndex;
                }
                else
                {
                    childNode.ImageIndex = this.ImageList.Images.IndexOfKey(imagePath);
                    childNode.SelectedImageIndex = childNode.ImageIndex;
                }
            }
            childNode.Tag = stkObjParent;
            parentTreeNode.Nodes.Add(childNode);
            for (int i = 0; i < stkObjParent.Children.Count; ++i)
            {
                PopulateTreeView(stkObjParent.Children[i], childNode);
            }
        }
        /// <summary>
        /// This method updates the TreeView. 
        /// </summary>
        private void UpdateTreeView()
        {
            if (stkRoot.CurrentScenario != null)
            {
                this.BeginUpdate();
                this.Nodes.Clear();
                this.ImageList = new ImageList();
                m_RootNode = new TreeNode(stkRoot.CurrentScenario.InstanceName);
                string imagePath = Path.Combine(m_STKIconDir, "Scenario.bmp");
                if (!this.ImageList.Images.ContainsKey(imagePath))
                {
                    m_RootNode.ImageIndex = this.ImageList.Images.Count;
                    this.ImageList.Images.Add(new Bitmap(imagePath));
                    m_RootNode.SelectedImageIndex = m_RootNode.ImageIndex;
                }
                else
                {
                    m_RootNode.ImageIndex = this.ImageList.Images.IndexOfKey(imagePath);
                    m_RootNode.SelectedImageIndex = m_RootNode.ImageIndex;
                }
                this.Nodes.Add(m_RootNode);

                for (int i = 0; i < stkRoot.CurrentScenario.Children.Count; ++i)
                {
                    PopulateTreeView(stkRoot.CurrentScenario.Children[i], m_RootNode);
                }
                this.EndUpdate();
                ExpandAll();
                this.Refresh();
            }
        }
        #endregion
        #region Clean-Up
        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if ((disposing) && (stkRoot != null))
            {
                stkRoot.OnStkObjectAdded -= m_OnStkObjectAddedEventHandler;
                stkRoot.OnStkObjectDeleted -= m_OnStkObjectDeletedEventHandler;
                stkRoot.OnStkObjectRenamed -= m_OnStkObjectRenamedEventHandler;
                stkRoot.OnScenarioNew -= m_OnScenarioNewEventHandler;
                stkRoot.OnScenarioClose -= m_OnScenarioCloseEventHandler;
            }
            if (disposing && (m_Components != null))
            {
                m_Components.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion
    }
}
