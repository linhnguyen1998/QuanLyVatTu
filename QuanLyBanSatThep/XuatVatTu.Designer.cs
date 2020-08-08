namespace QuanLyBanSatThep
{
    partial class XuatVatTu
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.QLSatThepDoanhThu = new QuanLyBanSatThep.QLSatThepDoanhThu();
            this.VATTUBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.VATTUTableAdapter = new QuanLyBanSatThep.QLSatThepDoanhThuTableAdapters.VATTUTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.QLSatThepDoanhThu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VATTUBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.VATTUBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyBanSatThep.rpt_XuatVatTu.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(13, 13);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(677, 457);
            this.reportViewer1.TabIndex = 0;
            // 
            // QLSatThepDoanhThu
            // 
            this.QLSatThepDoanhThu.DataSetName = "QLSatThepDoanhThu";
            this.QLSatThepDoanhThu.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // VATTUBindingSource
            // 
            this.VATTUBindingSource.DataMember = "VATTU";
            this.VATTUBindingSource.DataSource = this.QLSatThepDoanhThu;
            // 
            // VATTUTableAdapter
            // 
            this.VATTUTableAdapter.ClearBeforeFill = true;
            // 
            // XuatVatTu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 482);
            this.Controls.Add(this.reportViewer1);
            this.Name = "XuatVatTu";
            this.Text = "XuatVatTu";
            this.Load += new System.EventHandler(this.XuatVatTu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.QLSatThepDoanhThu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VATTUBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource VATTUBindingSource;
        private QLSatThepDoanhThu QLSatThepDoanhThu;
        private QLSatThepDoanhThuTableAdapters.VATTUTableAdapter VATTUTableAdapter;
    }
}