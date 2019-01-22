namespace code
{
    partial class MainRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public MainRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Report = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.DataSidePanelButton = this.Factory.CreateRibbonButton();
            this.Report.SuspendLayout();
            this.group1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Report
            // 
            this.Report.Groups.Add(this.group1);
            this.Report.Label = "Report";
            this.Report.Name = "Report";
            // 
            // group1
            // 
            this.group1.Items.Add(this.DataSidePanelButton);
            this.group1.Label = "group1";
            this.group1.Name = "group1";
            // 
            // DataSidePanelButton
            // 
            this.DataSidePanelButton.Label = "DateSidePanel";
            this.DataSidePanelButton.Name = "DataSidePanelButton";
            // 
            // MainRibbon
            // 
            this.Name = "MainRibbon";
            this.RibbonType = "Microsoft.Word.Document";
            this.Tabs.Add(this.Report);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.MainRibbon_Load);
            this.Report.ResumeLayout(false);
            this.Report.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab Report;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton DataSidePanelButton;
    }

    partial class ThisRibbonCollection
    {
        internal MainRibbon MainRibbon
        {
            get { return this.GetRibbon<MainRibbon>(); }
        }
    }
}
