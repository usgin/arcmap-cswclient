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
            this.cboSearchName.Location = new System.Drawing.Point(22, 22);
            this.cboSearchName.Name = "cboSearchName";
            this.cboSearchName.Size = new System.Drawing.Size(76, 21);
            this.cboSearchName.TabIndex = 0;
            // 
            // tboxSearchText
            // 
            this.tboxSearchText.Location = new System.Drawing.Point(115, 23);
            this.tboxSearchText.Name = "tboxSearchText";
            this.tboxSearchText.Size = new System.Drawing.Size(104, 20);
            this.tboxSearchText.TabIndex = 1;
            // 
            // lboxResults
            // 
            this.lboxResults.FormattingEnabled = true;
            this.lboxResults.Location = new System.Drawing.Point(22, 95);
            this.lboxResults.Name = "lboxResults";
            this.lboxResults.Size = new System.Drawing.Size(268, 199);
            this.lboxResults.TabIndex = 5;
            this.lboxResults.SelectedIndexChanged += new System.EventHandler(this.lboxResults_SelectedIndexChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(216, 451);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tboxAbstract
            // 
            this.tboxAbstract.Location = new System.Drawing.Point(22, 313);
            this.tboxAbstract.Multiline = true;
            this.tboxAbstract.Name = "tboxAbstract";
            this.tboxAbstract.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tboxAbstract.Size = new System.Drawing.Size(268, 123);
            this.tboxAbstract.TabIndex = 7;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(236, 20);
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
            this.lbNumRecords.Location = new System.Drawing.Point(22, 64);
            this.lbNumRecords.Name = "lbNumRecords";
            this.lbNumRecords.Size = new System.Drawing.Size(89, 13);
            this.lbNumRecords.TabIndex = 8;
            this.lbNumRecords.Text = "Found 0 Records";
            // 
            // lbPrePage
            // 
            this.lbPrePage.AutoSize = true;
            this.lbPrePage.Location = new System.Drawing.Point(184, 64);
            this.lbPrePage.Name = "lbPrePage";
            this.lbPrePage.Size = new System.Drawing.Size(19, 13);
            this.lbPrePage.TabIndex = 9;
            this.lbPrePage.Text = "<<";
            this.lbPrePage.Click += new System.EventHandler(this.lbPrePage_Click);
            // 
            // lbNxtPage
            // 
            this.lbNxtPage.AutoSize = true;
            this.lbNxtPage.Location = new System.Drawing.Point(271, 64);
            this.lbNxtPage.Name = "lbNxtPage";
            this.lbNxtPage.Size = new System.Drawing.Size(19, 13);
            this.lbNxtPage.TabIndex = 10;
            this.lbNxtPage.Text = ">>";
            this.lbNxtPage.Click += new System.EventHandler(this.lbNxtPage_Click);
            // 
            // lbPage
            // 
            this.lbPage.AutoSize = true;
            this.lbPage.Location = new System.Drawing.Point(213, 64);
            this.lbPage.Name = "lbPage";
            this.lbPage.Size = new System.Drawing.Size(52, 13);
            this.lbPage.TabIndex = 11;
            this.lbPage.Text = "Page 0/0";
            // 
            // ArcGISAddinDWin
            // 
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
            this.Size = new System.Drawing.Size(313, 496);
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


    }
}
