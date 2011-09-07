﻿namespace ArcMapAddin1
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
            this.txtboxWmsUrl = new System.Windows.Forms.TextBox();
            this.buttonAddWms = new System.Windows.Forms.Button();
            this.buttonAddMapSvr = new System.Windows.Forms.Button();
            this.txtboxSearch = new System.Windows.Forms.TextBox();
            this.lstboxCSW = new System.Windows.Forms.ListBox();
            this.buttonSearchCsw = new System.Windows.Forms.Button();
            this.cboboxQueryType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtboxWmsUrl
            // 
            this.txtboxWmsUrl.Location = new System.Drawing.Point(26, 342);
            this.txtboxWmsUrl.Name = "txtboxWmsUrl";
            this.txtboxWmsUrl.Size = new System.Drawing.Size(268, 20);
            this.txtboxWmsUrl.TabIndex = 0;
            // 
            // buttonAddWms
            // 
            this.buttonAddWms.Location = new System.Drawing.Point(105, 368);
            this.buttonAddWms.Name = "buttonAddWms";
            this.buttonAddWms.Size = new System.Drawing.Size(100, 23);
            this.buttonAddWms.TabIndex = 1;
            this.buttonAddWms.Text = "Add WMS Layer";
            this.buttonAddWms.UseVisualStyleBackColor = true;
            this.buttonAddWms.Click += new System.EventHandler(this.buttonAddWms_Click);
            // 
            // buttonAddMapSvr
            // 
            this.buttonAddMapSvr.Location = new System.Drawing.Point(79, 397);
            this.buttonAddMapSvr.Name = "buttonAddMapSvr";
            this.buttonAddMapSvr.Size = new System.Drawing.Size(148, 24);
            this.buttonAddMapSvr.TabIndex = 2;
            this.buttonAddMapSvr.Text = "Add Layer from MapServer";
            this.buttonAddMapSvr.UseVisualStyleBackColor = true;
            this.buttonAddMapSvr.Click += new System.EventHandler(this.buttonAddMapSvr_Click);
            // 
            // txtboxSearch
            // 
            this.txtboxSearch.Location = new System.Drawing.Point(118, 186);
            this.txtboxSearch.Name = "txtboxSearch";
            this.txtboxSearch.Size = new System.Drawing.Size(109, 20);
            this.txtboxSearch.TabIndex = 3;
            // 
            // lstboxCSW
            // 
            this.lstboxCSW.FormattingEnabled = true;
            this.lstboxCSW.Location = new System.Drawing.Point(26, 215);
            this.lstboxCSW.Name = "lstboxCSW";
            this.lstboxCSW.Size = new System.Drawing.Size(268, 121);
            this.lstboxCSW.TabIndex = 4;
            this.lstboxCSW.SelectedIndexChanged += new System.EventHandler(this.lstboxCSW_SelectedIndexChanged);
            // 
            // buttonSearchCsw
            // 
            this.buttonSearchCsw.Location = new System.Drawing.Point(237, 186);
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
            "Abstract",
            "ServiceType"});
            this.cboboxQueryType.Location = new System.Drawing.Point(26, 185);
            this.cboboxQueryType.Name = "cboboxQueryType";
            this.cboboxQueryType.Size = new System.Drawing.Size(86, 21);
            this.cboboxQueryType.TabIndex = 6;
            // 
            // FormCSW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 443);
            this.Controls.Add(this.cboboxQueryType);
            this.Controls.Add(this.buttonSearchCsw);
            this.Controls.Add(this.lstboxCSW);
            this.Controls.Add(this.txtboxSearch);
            this.Controls.Add(this.buttonAddMapSvr);
            this.Controls.Add(this.buttonAddWms);
            this.Controls.Add(this.txtboxWmsUrl);
            this.Name = "FormCSW";
            this.Text = "CSW Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtboxWmsUrl;
        private System.Windows.Forms.Button buttonAddWms;
        private System.Windows.Forms.Button buttonAddMapSvr;
        private System.Windows.Forms.TextBox txtboxSearch;
        private System.Windows.Forms.ListBox lstboxCSW;
        private System.Windows.Forms.Button buttonSearchCsw;
        private System.Windows.Forms.ComboBox cboboxQueryType;
    }
}