namespace ArcMapAddin1
{
    partial class FormCSW
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
            this.txtboxSearch = new System.Windows.Forms.TextBox();
            this.lstboxCSW = new System.Windows.Forms.ListBox();
            this.buttonSearchCsw = new System.Windows.Forms.Button();
            this.cboboxQueryType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboboxMaxResults = new System.Windows.Forms.ComboBox();
            this.buttonAddLayer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtboxSearch
            // 
            this.txtboxSearch.Location = new System.Drawing.Point(127, 25);
            this.txtboxSearch.Name = "txtboxSearch";
            this.txtboxSearch.Size = new System.Drawing.Size(119, 20);
            this.txtboxSearch.TabIndex = 3;
            // 
            // lstboxCSW
            // 
            this.lstboxCSW.FormattingEnabled = true;
            this.lstboxCSW.Location = new System.Drawing.Point(27, 106);
            this.lstboxCSW.Name = "lstboxCSW";
            this.lstboxCSW.Size = new System.Drawing.Size(219, 160);
            this.lstboxCSW.TabIndex = 4;
            this.lstboxCSW.SelectedIndexChanged += new System.EventHandler(this.lstboxCSW_SelectedIndexChanged);
            // 
            // buttonSearchCsw
            // 
            this.buttonSearchCsw.Location = new System.Drawing.Point(189, 65);
            this.buttonSearchCsw.Name = "buttonSearchCsw";
            this.buttonSearchCsw.Size = new System.Drawing.Size(57, 23);
            this.buttonSearchCsw.TabIndex = 5;
            this.buttonSearchCsw.Text = "Search";
            this.buttonSearchCsw.UseVisualStyleBackColor = true;
            this.buttonSearchCsw.Click += new System.EventHandler(this.buttonSearchCsw_Click);
            // 
            // cboboxQueryType
            // 
            this.cboboxQueryType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboboxQueryType.FormattingEnabled = true;
            this.cboboxQueryType.Items.AddRange(new object[] {
            "AnyText",
            "Title",
            "Subject",
            "Abstract"});
            this.cboboxQueryType.Location = new System.Drawing.Point(26, 24);
            this.cboboxQueryType.Name = "cboboxQueryType";
            this.cboboxQueryType.Size = new System.Drawing.Size(94, 21);
            this.cboboxQueryType.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Max No. of Results";
            // 
            // cboboxMaxResults
            // 
            this.cboboxMaxResults.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboboxMaxResults.FormattingEnabled = true;
            this.cboboxMaxResults.Items.AddRange(new object[] {
            "10",
            "50",
            "100",
            "1000"});
            this.cboboxMaxResults.Location = new System.Drawing.Point(127, 65);
            this.cboboxMaxResults.Name = "cboboxMaxResults";
            this.cboboxMaxResults.Size = new System.Drawing.Size(55, 21);
            this.cboboxMaxResults.TabIndex = 13;
            // 
            // buttonAddLayer
            // 
            this.buttonAddLayer.Location = new System.Drawing.Point(171, 283);
            this.buttonAddLayer.Name = "buttonAddLayer";
            this.buttonAddLayer.Size = new System.Drawing.Size(75, 23);
            this.buttonAddLayer.TabIndex = 14;
            this.buttonAddLayer.Text = "Add";
            this.buttonAddLayer.UseVisualStyleBackColor = true;
            this.buttonAddLayer.Click += new System.EventHandler(this.buttonAddLayer_Click);
            // 
            // FormCSW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 330);
            this.Controls.Add(this.buttonAddLayer);
            this.Controls.Add(this.cboboxMaxResults);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboboxQueryType);
            this.Controls.Add(this.buttonSearchCsw);
            this.Controls.Add(this.lstboxCSW);
            this.Controls.Add(this.txtboxSearch);
            this.Name = "FormCSW";
            this.Text = "CSW Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtboxSearch;
        private System.Windows.Forms.ListBox lstboxCSW;
        private System.Windows.Forms.Button buttonSearchCsw;
        private System.Windows.Forms.ComboBox cboboxQueryType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboboxMaxResults;
        private System.Windows.Forms.Button buttonAddLayer;
    }
}