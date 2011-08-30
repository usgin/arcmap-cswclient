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
            this.txtboxWmsUrl = new System.Windows.Forms.TextBox();
            this.buttonAddWms = new System.Windows.Forms.Button();
            this.buttonAddMapSvr = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtboxWmsUrl
            // 
            this.txtboxWmsUrl.Location = new System.Drawing.Point(24, 33);
            this.txtboxWmsUrl.Name = "txtboxWmsUrl";
            this.txtboxWmsUrl.Size = new System.Drawing.Size(238, 20);
            this.txtboxWmsUrl.TabIndex = 0;
            // 
            // buttonAddWms
            // 
            this.buttonAddWms.Location = new System.Drawing.Point(91, 77);
            this.buttonAddWms.Name = "buttonAddWms";
            this.buttonAddWms.Size = new System.Drawing.Size(100, 23);
            this.buttonAddWms.TabIndex = 1;
            this.buttonAddWms.Text = "Add WMS Layer";
            this.buttonAddWms.UseVisualStyleBackColor = true;
            this.buttonAddWms.Click += new System.EventHandler(this.buttonAddWms_Click);
            // 
            // buttonAddMapSvr
            // 
            this.buttonAddMapSvr.Location = new System.Drawing.Point(70, 120);
            this.buttonAddMapSvr.Name = "buttonAddMapSvr";
            this.buttonAddMapSvr.Size = new System.Drawing.Size(148, 24);
            this.buttonAddMapSvr.TabIndex = 2;
            this.buttonAddMapSvr.Text = "Add Layer from MapServer";
            this.buttonAddMapSvr.UseVisualStyleBackColor = true;
            this.buttonAddMapSvr.Click += new System.EventHandler(this.buttonAddMapSvr_Click);
            // 
            // FormCSW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
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
    }
}