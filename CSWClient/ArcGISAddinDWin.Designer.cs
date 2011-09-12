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
            this.lbMaxResults = new System.Windows.Forms.Label();
            this.cboMaxResults = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lboxResults = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tboxAbstract = new System.Windows.Forms.TextBox();
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
            this.cboSearchName.Size = new System.Drawing.Size(97, 21);
            this.cboSearchName.TabIndex = 0;
            // 
            // tboxSearchText
            // 
            this.tboxSearchText.Location = new System.Drawing.Point(134, 22);
            this.tboxSearchText.Name = "tboxSearchText";
            this.tboxSearchText.Size = new System.Drawing.Size(145, 20);
            this.tboxSearchText.TabIndex = 1;
            // 
            // lbMaxResults
            // 
            this.lbMaxResults.AutoSize = true;
            this.lbMaxResults.Location = new System.Drawing.Point(22, 58);
            this.lbMaxResults.Name = "lbMaxResults";
            this.lbMaxResults.Size = new System.Drawing.Size(97, 13);
            this.lbMaxResults.TabIndex = 2;
            this.lbMaxResults.Text = "Max No. of Results";
            // 
            // cboMaxResults
            // 
            this.cboMaxResults.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMaxResults.FormattingEnabled = true;
            this.cboMaxResults.Items.AddRange(new object[] {
            "10",
            "50",
            "100",
            "1000",
            "10000"});
            this.cboMaxResults.Location = new System.Drawing.Point(134, 53);
            this.cboMaxResults.Name = "cboMaxResults";
            this.cboMaxResults.Size = new System.Drawing.Size(64, 21);
            this.cboMaxResults.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(204, 53);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lboxResults
            // 
            this.lboxResults.FormattingEnabled = true;
            this.lboxResults.Location = new System.Drawing.Point(25, 91);
            this.lboxResults.Name = "lboxResults";
            this.lboxResults.Size = new System.Drawing.Size(254, 225);
            this.lboxResults.TabIndex = 5;
            this.lboxResults.SelectedIndexChanged += new System.EventHandler(this.lboxResults_SelectedIndexChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(203, 454);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tboxAbstract
            // 
            this.tboxAbstract.Location = new System.Drawing.Point(25, 335);
            this.tboxAbstract.Multiline = true;
            this.tboxAbstract.Name = "tboxAbstract";
            this.tboxAbstract.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tboxAbstract.Size = new System.Drawing.Size(253, 101);
            this.tboxAbstract.TabIndex = 7;
            // 
            // ArcGISAddinDWin
            // 
            this.Controls.Add(this.tboxAbstract);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lboxResults);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cboMaxResults);
            this.Controls.Add(this.lbMaxResults);
            this.Controls.Add(this.tboxSearchText);
            this.Controls.Add(this.cboSearchName);
            this.Name = "ArcGISAddinDWin";
            this.Size = new System.Drawing.Size(306, 506);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboSearchName;
        private System.Windows.Forms.TextBox tboxSearchText;
        private System.Windows.Forms.Label lbMaxResults;
        private System.Windows.Forms.ComboBox cboMaxResults;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListBox lboxResults;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox tboxAbstract;


    }
}
