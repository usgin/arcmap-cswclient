namespace ArcMapAddin1
{
    partial class ArcGISAddinDWin
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
            this.cboSearchName = new System.Windows.Forms.ComboBox();
            this.tboxSearchText = new System.Windows.Forms.TextBox();
            this.lboxResults = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tboxAbstract = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lbNumRecords = new System.Windows.Forms.Label();
            this.lbPrePage = new System.Windows.Forms.Label();
            this.lbNxtPage = new System.Windows.Forms.Label();
            this.lbPage = new System.Windows.Forms.Label();
            this.btnMetaDoc = new System.Windows.Forms.Button();
            this.cboxWms = new System.Windows.Forms.CheckBox();
            this.cboxLivedata = new System.Windows.Forms.CheckBox();
            this.cboCatalog = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cboSearchName
            // 
            this.cboSearchName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSearchName.FormattingEnabled = true;
            this.cboSearchName.Items.AddRange(new object[] {
            "AnyText",
            "Title",
            "Subject",
            "Abstract"});
            this.cboSearchName.Location = new System.Drawing.Point(23, 57);
            this.cboSearchName.Name = "cboSearchName";
            this.cboSearchName.Size = new System.Drawing.Size(76, 21);
            this.cboSearchName.TabIndex = 0;
            // 
            // tboxSearchText
            // 
            this.tboxSearchText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tboxSearchText.Location = new System.Drawing.Point(116, 58);
            this.tboxSearchText.Name = "tboxSearchText";
            this.tboxSearchText.Size = new System.Drawing.Size(106, 20);
            this.tboxSearchText.TabIndex = 1;
            // 
            // lboxResults
            // 
            this.lboxResults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lboxResults.FormattingEnabled = true;
            this.lboxResults.Location = new System.Drawing.Point(23, 147);
            this.lboxResults.Name = "lboxResults";
            this.lboxResults.Size = new System.Drawing.Size(270, 199);
            this.lboxResults.TabIndex = 5;
            this.lboxResults.SelectedIndexChanged += new System.EventHandler(this.lboxResults_SelectedIndexChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(216, 506);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tboxAbstract
            // 
            this.tboxAbstract.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tboxAbstract.Location = new System.Drawing.Point(22, 365);
            this.tboxAbstract.Multiline = true;
            this.tboxAbstract.Name = "tboxAbstract";
            this.tboxAbstract.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tboxAbstract.Size = new System.Drawing.Size(270, 123);
            this.tboxAbstract.TabIndex = 7;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(237, 58);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(54, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lbNumRecords
            // 
            this.lbNumRecords.AutoSize = true;
            this.lbNumRecords.Location = new System.Drawing.Point(20, 120);
            this.lbNumRecords.Name = "lbNumRecords";
            this.lbNumRecords.Size = new System.Drawing.Size(89, 13);
            this.lbNumRecords.TabIndex = 8;
            this.lbNumRecords.Text = "Found 0 Records";
            // 
            // lbPrePage
            // 
            this.lbPrePage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbPrePage.AutoSize = true;
            this.lbPrePage.Location = new System.Drawing.Point(188, 120);
            this.lbPrePage.Name = "lbPrePage";
            this.lbPrePage.Size = new System.Drawing.Size(19, 13);
            this.lbPrePage.TabIndex = 9;
            this.lbPrePage.Text = "<<";
            this.lbPrePage.Click += new System.EventHandler(this.lbPrePage_Click);
            // 
            // lbNxtPage
            // 
            this.lbNxtPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbNxtPage.AutoSize = true;
            this.lbNxtPage.Location = new System.Drawing.Point(272, 120);
            this.lbNxtPage.Name = "lbNxtPage";
            this.lbNxtPage.Size = new System.Drawing.Size(19, 13);
            this.lbNxtPage.TabIndex = 10;
            this.lbNxtPage.Text = ">>";
            this.lbNxtPage.Click += new System.EventHandler(this.lbNxtPage_Click);
            // 
            // lbPage
            // 
            this.lbPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbPage.AutoSize = true;
            this.lbPage.Location = new System.Drawing.Point(213, 120);
            this.lbPage.Name = "lbPage";
            this.lbPage.Size = new System.Drawing.Size(52, 13);
            this.lbPage.TabIndex = 11;
            this.lbPage.Text = "Page 0/0";
            // 
            // btnMetaDoc
            // 
            this.btnMetaDoc.Location = new System.Drawing.Point(22, 506);
            this.btnMetaDoc.Name = "btnMetaDoc";
            this.btnMetaDoc.Size = new System.Drawing.Size(75, 23);
            this.btnMetaDoc.TabIndex = 12;
            this.btnMetaDoc.Text = "Metadata ";
            this.btnMetaDoc.UseVisualStyleBackColor = true;
            this.btnMetaDoc.Click += new System.EventHandler(this.btnMetaDoc_Click);
            // 
            // cboxWms
            // 
            this.cboxWms.AutoSize = true;
            this.cboxWms.Checked = true;
            this.cboxWms.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cboxWms.Location = new System.Drawing.Point(23, 91);
            this.cboxWms.Name = "cboxWms";
            this.cboxWms.Size = new System.Drawing.Size(53, 17);
            this.cboxWms.TabIndex = 13;
            this.cboxWms.Text = "WMS";
            this.cboxWms.UseVisualStyleBackColor = true;
            // 
            // cboxLivedata
            // 
            this.cboxLivedata.AutoSize = true;
            this.cboxLivedata.Checked = true;
            this.cboxLivedata.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cboxLivedata.Location = new System.Drawing.Point(96, 91);
            this.cboxLivedata.Name = "cboxLivedata";
            this.cboxLivedata.Size = new System.Drawing.Size(70, 17);
            this.cboxLivedata.TabIndex = 14;
            this.cboxLivedata.Text = "Live data";
            this.cboxLivedata.UseVisualStyleBackColor = true;
            // 
            // cboCatalog
            // 
            this.cboCatalog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCatalog.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCatalog.FormattingEnabled = true;
            this.cboCatalog.Items.AddRange(new object[] {
            "USGIN AASG Geothermal Data Catalog",
            "OneGeology Portal"});
            this.cboCatalog.Location = new System.Drawing.Point(23, 22);
            this.cboCatalog.Name = "cboCatalog";
            this.cboCatalog.Size = new System.Drawing.Size(268, 21);
            this.cboCatalog.TabIndex = 15;
            this.cboCatalog.SelectedIndexChanged += new System.EventHandler(this.cboCatalog_SelectedIndexChanged);
            // 
            // ArcGISAddinDWin
            // 
            this.Controls.Add(this.cboCatalog);
            this.Controls.Add(this.cboxLivedata);
            this.Controls.Add(this.cboxWms);
            this.Controls.Add(this.btnMetaDoc);
            this.Controls.Add(this.lbPage);
            this.Controls.Add(this.lbNxtPage);
            this.Controls.Add(this.lbPrePage);
            this.Controls.Add(this.lbNumRecords);
            this.Controls.Add(this.tboxAbstract);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lboxResults);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.tboxSearchText);
            this.Controls.Add(this.cboSearchName);
            this.Name = "ArcGISAddinDWin";
            this.Size = new System.Drawing.Size(315, 553);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboSearchName;
        private System.Windows.Forms.TextBox tboxSearchText;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListBox lboxResults;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox tboxAbstract;
        private System.Windows.Forms.Label lbNumRecords;
        private System.Windows.Forms.Label lbPrePage;
        private System.Windows.Forms.Label lbNxtPage;
        private System.Windows.Forms.Label lbPage;
        private System.Windows.Forms.Button btnMetaDoc;
        private System.Windows.Forms.CheckBox cboxWms;
        private System.Windows.Forms.CheckBox cboxLivedata;
        private System.Windows.Forms.ComboBox cboCatalog;


    }
}
