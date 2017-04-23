namespace CoScheduling.Main.Coverage
{
    partial class CoverageMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CoverageMain));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.scTimeButton = new System.Windows.Forms.ToolStripButton();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.resetAnimButton = new System.Windows.Forms.ToolStripButton();
            this.stepRevAnimButton = new System.Windows.Forms.ToolStripButton();
            this.startRevAnimButton = new System.Windows.Forms.ToolStripButton();
            this.pauseAnimButton = new System.Windows.Forms.ToolStripButton();
            this.startFwdAnimButton = new System.Windows.Forms.ToolStripButton();
            this.stepFwdAnimButton = new System.Windows.Forms.ToolStripButton();
            this.decTimeStepAnimButton = new System.Windows.Forms.ToolStripButton();
            this.incTimeStepAnimButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.viewFromButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.homeViewButton = new System.Windows.Forms.ToolStripButton();
            this.orientNorthButton = new System.Windows.Forms.ToolStripButton();
            this.orientTopButton = new System.Windows.Forms.ToolStripButton();
            this.zoomInVO = new System.Windows.Forms.ToolStripButton();
            this.zoomOutVO = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.Scenario = new System.Windows.Forms.ToolStripSplitButton();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeScenarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Map = new System.Windows.Forms.ToolStripSplitButton();
            this.openMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonPosition = new System.Windows.Forms.ToolStripButton();
            this.m_StatusBar = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControlSatCompute = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.axAgUiAxVOCntrl1 = new AxAGI.STKX.AxAgUiAxVOCntrl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.axAgUiAx2DCntrl1 = new AxAGI.STKX.AxAgUiAx2DCntrl();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.m_StatusBar.SuspendLayout();
            this.tabControlSatCompute.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axAgUiAxVOCntrl1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axAgUiAx2DCntrl1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            this.toolStripContainer1.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(597, 1);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(597, 26);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip2);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip3);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.scTimeButton});
            this.toolStrip2.Location = new System.Drawing.Point(3, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(134, 25);
            this.toolStrip2.TabIndex = 5;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(68, 22);
            this.toolStripLabel1.Text = "场景时间：";
            // 
            // scTimeButton
            // 
            this.scTimeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.scTimeButton.Image = ((System.Drawing.Image)(resources.GetObject("scTimeButton.Image")));
            this.scTimeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.scTimeButton.Name = "scTimeButton";
            this.scTimeButton.Size = new System.Drawing.Size(23, 22);
            this.scTimeButton.Text = "跳转";
            this.scTimeButton.Click += new System.EventHandler(this.scTimeButton_Click);
            // 
            // toolStrip3
            // 
            this.toolStrip3.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetAnimButton,
            this.stepRevAnimButton,
            this.startRevAnimButton,
            this.pauseAnimButton,
            this.startFwdAnimButton,
            this.stepFwdAnimButton,
            this.decTimeStepAnimButton,
            this.incTimeStepAnimButton,
            this.toolStripSeparator1,
            this.viewFromButton,
            this.homeViewButton,
            this.orientNorthButton,
            this.orientTopButton,
            this.zoomInVO,
            this.zoomOutVO,
            this.toolStripSeparator2,
            this.Scenario,
            this.Map,
            this.toolStripSeparator3,
            this.buttonPosition});
            this.toolStrip3.Location = new System.Drawing.Point(137, 0);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(445, 25);
            this.toolStrip3.TabIndex = 6;
            // 
            // resetAnimButton
            // 
            this.resetAnimButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.resetAnimButton.Image = ((System.Drawing.Image)(resources.GetObject("resetAnimButton.Image")));
            this.resetAnimButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.resetAnimButton.Name = "resetAnimButton";
            this.resetAnimButton.Size = new System.Drawing.Size(23, 22);
            this.resetAnimButton.Text = "Reset";
            this.resetAnimButton.Click += new System.EventHandler(this.resetAnimButton_Click);
            // 
            // stepRevAnimButton
            // 
            this.stepRevAnimButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stepRevAnimButton.Image = ((System.Drawing.Image)(resources.GetObject("stepRevAnimButton.Image")));
            this.stepRevAnimButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stepRevAnimButton.Name = "stepRevAnimButton";
            this.stepRevAnimButton.Size = new System.Drawing.Size(23, 22);
            this.stepRevAnimButton.Text = "Steps in Reverse";
            this.stepRevAnimButton.Click += new System.EventHandler(this.stepRevAnimButton_Click);
            // 
            // startRevAnimButton
            // 
            this.startRevAnimButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.startRevAnimButton.Image = ((System.Drawing.Image)(resources.GetObject("startRevAnimButton.Image")));
            this.startRevAnimButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.startRevAnimButton.Name = "startRevAnimButton";
            this.startRevAnimButton.Size = new System.Drawing.Size(23, 22);
            this.startRevAnimButton.Text = "Reverse";
            this.startRevAnimButton.Click += new System.EventHandler(this.startRevAnimButton_Click);
            // 
            // pauseAnimButton
            // 
            this.pauseAnimButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pauseAnimButton.Image = ((System.Drawing.Image)(resources.GetObject("pauseAnimButton.Image")));
            this.pauseAnimButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pauseAnimButton.Name = "pauseAnimButton";
            this.pauseAnimButton.Size = new System.Drawing.Size(23, 22);
            this.pauseAnimButton.Text = "Pause";
            this.pauseAnimButton.Click += new System.EventHandler(this.pauseAnimButton_Click);
            // 
            // startFwdAnimButton
            // 
            this.startFwdAnimButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.startFwdAnimButton.Image = ((System.Drawing.Image)(resources.GetObject("startFwdAnimButton.Image")));
            this.startFwdAnimButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.startFwdAnimButton.Name = "startFwdAnimButton";
            this.startFwdAnimButton.Size = new System.Drawing.Size(23, 22);
            this.startFwdAnimButton.Text = "Start";
            this.startFwdAnimButton.Click += new System.EventHandler(this.startFwdAnimButton_Click);
            // 
            // stepFwdAnimButton
            // 
            this.stepFwdAnimButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stepFwdAnimButton.Image = ((System.Drawing.Image)(resources.GetObject("stepFwdAnimButton.Image")));
            this.stepFwdAnimButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stepFwdAnimButton.Name = "stepFwdAnimButton";
            this.stepFwdAnimButton.Size = new System.Drawing.Size(23, 22);
            this.stepFwdAnimButton.Text = "Step Forward";
            this.stepFwdAnimButton.Click += new System.EventHandler(this.stepFwdAnimButton_Click);
            // 
            // decTimeStepAnimButton
            // 
            this.decTimeStepAnimButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.decTimeStepAnimButton.Image = ((System.Drawing.Image)(resources.GetObject("decTimeStepAnimButton.Image")));
            this.decTimeStepAnimButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.decTimeStepAnimButton.Name = "decTimeStepAnimButton";
            this.decTimeStepAnimButton.Size = new System.Drawing.Size(23, 22);
            this.decTimeStepAnimButton.Text = "Decrease Time Step";
            this.decTimeStepAnimButton.Click += new System.EventHandler(this.decTimeStepAnimButton_Click);
            // 
            // incTimeStepAnimButton
            // 
            this.incTimeStepAnimButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.incTimeStepAnimButton.Image = ((System.Drawing.Image)(resources.GetObject("incTimeStepAnimButton.Image")));
            this.incTimeStepAnimButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.incTimeStepAnimButton.Name = "incTimeStepAnimButton";
            this.incTimeStepAnimButton.Size = new System.Drawing.Size(23, 22);
            this.incTimeStepAnimButton.Text = "Increase Time Step";
            this.incTimeStepAnimButton.Click += new System.EventHandler(this.incTimeStepAnimButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // viewFromButton
            // 
            this.viewFromButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.viewFromButton.Image = ((System.Drawing.Image)(resources.GetObject("viewFromButton.Image")));
            this.viewFromButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.viewFromButton.Name = "viewFromButton";
            this.viewFromButton.Size = new System.Drawing.Size(29, 22);
            this.viewFromButton.Text = "View From/To";
            this.viewFromButton.Click += new System.EventHandler(this.viewFromButton_Click);
            // 
            // homeViewButton
            // 
            this.homeViewButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.homeViewButton.Image = ((System.Drawing.Image)(resources.GetObject("homeViewButton.Image")));
            this.homeViewButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.homeViewButton.Name = "homeViewButton";
            this.homeViewButton.Size = new System.Drawing.Size(23, 22);
            this.homeViewButton.Text = "Home View";
            this.homeViewButton.Click += new System.EventHandler(this.homeViewButton_Click);
            // 
            // orientNorthButton
            // 
            this.orientNorthButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.orientNorthButton.Image = ((System.Drawing.Image)(resources.GetObject("orientNorthButton.Image")));
            this.orientNorthButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.orientNorthButton.Name = "orientNorthButton";
            this.orientNorthButton.Size = new System.Drawing.Size(23, 22);
            this.orientNorthButton.Text = "Orient North";
            this.orientNorthButton.Click += new System.EventHandler(this.orientNorthButton_Click);
            // 
            // orientTopButton
            // 
            this.orientTopButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.orientTopButton.Image = ((System.Drawing.Image)(resources.GetObject("orientTopButton.Image")));
            this.orientTopButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.orientTopButton.Name = "orientTopButton";
            this.orientTopButton.Size = new System.Drawing.Size(23, 22);
            this.orientTopButton.Text = "Orient from Top";
            this.orientTopButton.Click += new System.EventHandler(this.orientTopButton_Click);
            // 
            // zoomInVO
            // 
            this.zoomInVO.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoomInVO.Image = ((System.Drawing.Image)(resources.GetObject("zoomInVO.Image")));
            this.zoomInVO.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomInVO.Name = "zoomInVO";
            this.zoomInVO.Size = new System.Drawing.Size(23, 22);
            this.zoomInVO.Text = "Zoom In";
            this.zoomInVO.Click += new System.EventHandler(this.zoomInVO_Click);
            // 
            // zoomOutVO
            // 
            this.zoomOutVO.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoomOutVO.Image = ((System.Drawing.Image)(resources.GetObject("zoomOutVO.Image")));
            this.zoomOutVO.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomOutVO.Name = "zoomOutVO";
            this.zoomOutVO.Size = new System.Drawing.Size(23, 22);
            this.zoomOutVO.Text = "Zoom Out";
            this.zoomOutVO.Click += new System.EventHandler(this.zoomOutVO_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // Scenario
            // 
            this.Scenario.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Scenario.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.closeScenarioToolStripMenuItem});
            this.Scenario.Image = ((System.Drawing.Image)(resources.GetObject("Scenario.Image")));
            this.Scenario.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Scenario.Name = "Scenario";
            this.Scenario.Size = new System.Drawing.Size(32, 22);
            this.Scenario.Text = "Scenario";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.openToolStripMenuItem.Text = "Open Scenario";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // closeScenarioToolStripMenuItem
            // 
            this.closeScenarioToolStripMenuItem.Name = "closeScenarioToolStripMenuItem";
            this.closeScenarioToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.closeScenarioToolStripMenuItem.Text = "Close Scenario";
            this.closeScenarioToolStripMenuItem.Click += new System.EventHandler(this.closeScenarioToolStripMenuItem_Click);
            // 
            // Map
            // 
            this.Map.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Map.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openMapToolStripMenuItem,
            this.closeMapToolStripMenuItem});
            this.Map.Image = ((System.Drawing.Image)(resources.GetObject("Map.Image")));
            this.Map.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Map.Name = "Map";
            this.Map.Size = new System.Drawing.Size(32, 22);
            this.Map.Text = "Map";
            // 
            // openMapToolStripMenuItem
            // 
            this.openMapToolStripMenuItem.Name = "openMapToolStripMenuItem";
            this.openMapToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.openMapToolStripMenuItem.Text = "Open Map";
            this.openMapToolStripMenuItem.Click += new System.EventHandler(this.openMapToolStripMenuItem_Click);
            // 
            // closeMapToolStripMenuItem
            // 
            this.closeMapToolStripMenuItem.Name = "closeMapToolStripMenuItem";
            this.closeMapToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.closeMapToolStripMenuItem.Text = "Close Map";
            this.closeMapToolStripMenuItem.Click += new System.EventHandler(this.closeMapToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // buttonPosition
            // 
            this.buttonPosition.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonPosition.Image = ((System.Drawing.Image)(resources.GetObject("buttonPosition.Image")));
            this.buttonPosition.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonPosition.Name = "buttonPosition";
            this.buttonPosition.Size = new System.Drawing.Size(23, 22);
            this.buttonPosition.Text = "获取卫星轨道";
            this.buttonPosition.Click += new System.EventHandler(this.buttonPosition_Click);
            // 
            // m_StatusBar
            // 
            this.m_StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.m_StatusBar.Location = new System.Drawing.Point(0, 322);
            this.m_StatusBar.Name = "m_StatusBar";
            this.m_StatusBar.Size = new System.Drawing.Size(597, 22);
            this.m_StatusBar.TabIndex = 1;
            this.m_StatusBar.Text = "覆盖分析系统";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(80, 17);
            this.toolStripStatusLabel1.Text = "覆盖分析系统";
            // 
            // tabControlSatCompute
            // 
            this.tabControlSatCompute.Controls.Add(this.tabPage1);
            this.tabControlSatCompute.Controls.Add(this.tabPage2);
            this.tabControlSatCompute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSatCompute.Location = new System.Drawing.Point(0, 26);
            this.tabControlSatCompute.Name = "tabControlSatCompute";
            this.tabControlSatCompute.SelectedIndex = 0;
            this.tabControlSatCompute.Size = new System.Drawing.Size(597, 296);
            this.tabControlSatCompute.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.axAgUiAxVOCntrl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(589, 270);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "三维场景";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // axAgUiAxVOCntrl1
            // 
            this.axAgUiAxVOCntrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axAgUiAxVOCntrl1.Enabled = true;
            this.axAgUiAxVOCntrl1.Location = new System.Drawing.Point(3, 3);
            this.axAgUiAxVOCntrl1.Name = "axAgUiAxVOCntrl1";
            this.axAgUiAxVOCntrl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAgUiAxVOCntrl1.OcxState")));
            this.axAgUiAxVOCntrl1.Size = new System.Drawing.Size(583, 264);
            this.axAgUiAxVOCntrl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.axAgUiAx2DCntrl1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(589, 270);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "二维场景";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // axAgUiAx2DCntrl1
            // 
            this.axAgUiAx2DCntrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axAgUiAx2DCntrl1.Enabled = true;
            this.axAgUiAx2DCntrl1.Location = new System.Drawing.Point(3, 3);
            this.axAgUiAx2DCntrl1.Name = "axAgUiAx2DCntrl1";
            this.axAgUiAx2DCntrl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAgUiAx2DCntrl1.OcxState")));
            this.axAgUiAx2DCntrl1.Size = new System.Drawing.Size(583, 264);
            this.axAgUiAx2DCntrl1.TabIndex = 0;
            // 
            // CoverageMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 344);
            this.Controls.Add(this.tabControlSatCompute);
            this.Controls.Add(this.m_StatusBar);
            this.Controls.Add(this.toolStripContainer1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "CoverageMain";
            this.Text = "CoverageMain";
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.m_StatusBar.ResumeLayout(false);
            this.m_StatusBar.PerformLayout();
            this.tabControlSatCompute.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axAgUiAxVOCntrl1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axAgUiAx2DCntrl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton resetAnimButton;
        private System.Windows.Forms.ToolStripButton stepRevAnimButton;
        private System.Windows.Forms.ToolStripButton startRevAnimButton;
        private System.Windows.Forms.ToolStripButton pauseAnimButton;
        private System.Windows.Forms.ToolStripButton startFwdAnimButton;
        private System.Windows.Forms.ToolStripButton stepFwdAnimButton;
        private System.Windows.Forms.ToolStripButton decTimeStepAnimButton;
        private System.Windows.Forms.ToolStripButton incTimeStepAnimButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton homeViewButton;
        private System.Windows.Forms.ToolStripButton orientNorthButton;
        private System.Windows.Forms.ToolStripButton orientTopButton;
        private System.Windows.Forms.ToolStripButton zoomInVO;
        private System.Windows.Forms.ToolStripButton zoomOutVO;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton scTimeButton;
        private System.Windows.Forms.StatusStrip m_StatusBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TabControl tabControlSatCompute;
        private System.Windows.Forms.TabPage tabPage1;
        private AxAGI.STKX.AxAgUiAxVOCntrl axAgUiAxVOCntrl1;
        private System.Windows.Forms.TabPage tabPage2;
        private AxAGI.STKX.AxAgUiAx2DCntrl axAgUiAx2DCntrl1;
        private System.Windows.Forms.ToolStripSplitButton Scenario;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeScenarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripSplitButton Map;
        private System.Windows.Forms.ToolStripMenuItem openMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        public System.Windows.Forms.ToolStripButton buttonPosition;
        public System.Windows.Forms.ToolStripDropDownButton viewFromButton;
        public System.Windows.Forms.ToolStrip toolStrip2;
    }
}