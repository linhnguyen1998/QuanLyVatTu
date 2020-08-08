namespace QuanLyBanSatThep
{
    partial class BaoCaoDoanhThu
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaoCaoDoanhThu));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cb_Chon = new System.Windows.Forms.ComboBox();
            this.dt_XuatDoanhThu = new System.Windows.Forms.DateTimePicker();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btn_ThongKeDoanhThu = new System.Windows.Forms.Button();
            this.BaoCaoDoanhThuBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QLSatThepDoanhThu = new QuanLyBanSatThep.QLSatThepDoanhThu();
            this.tongDoanhThuBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qLSatThepDoanhThu1 = new QuanLyBanSatThep.QLSatThepDoanhThu();
            this.DoanhThuChartBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BaoCaoDoanhThuTableAdapter = new QuanLyBanSatThep.QLSatThepDoanhThuTableAdapters.BaoCaoDoanhThuTableAdapter();
            this.tongDoanhThuTableAdapter = new QuanLyBanSatThep.QLSatThepDoanhThuTableAdapters.TongDoanhThuTableAdapter();
            this.DoanhThuChartTableAdapter = new QuanLyBanSatThep.QLSatThepDoanhThuTableAdapters.DoanhThuChartTableAdapter();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BaoCaoDoanhThuBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QLSatThepDoanhThu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tongDoanhThuBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLSatThepDoanhThu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DoanhThuChartBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_ThongKeDoanhThu);
            this.groupBox1.Controls.Add(this.cb_Chon);
            this.groupBox1.Controls.Add(this.dt_XuatDoanhThu);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(788, 53);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thống kê doanh thu";
            // 
            // cb_Chon
            // 
            this.cb_Chon.FormattingEnabled = true;
            this.cb_Chon.Items.AddRange(new object[] {
            "Ngày",
            "Tháng",
            "Năm"});
            this.cb_Chon.Location = new System.Drawing.Point(193, 19);
            this.cb_Chon.Name = "cb_Chon";
            this.cb_Chon.Size = new System.Drawing.Size(96, 25);
            this.cb_Chon.TabIndex = 10;
            // 
            // dt_XuatDoanhThu
            // 
            this.dt_XuatDoanhThu.CustomFormat = "dd/MM/yyyy";
            this.dt_XuatDoanhThu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_XuatDoanhThu.Location = new System.Drawing.Point(295, 20);
            this.dt_XuatDoanhThu.Name = "dt_XuatDoanhThu";
            this.dt_XuatDoanhThu.Size = new System.Drawing.Size(146, 25);
            this.dt_XuatDoanhThu.TabIndex = 11;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.BaoCaoDoanhThuBindingSource;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.tongDoanhThuBindingSource;
            reportDataSource3.Name = "DataSet3";
            reportDataSource3.Value = this.DoanhThuChartBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyBanSatThep.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(13, 71);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(788, 496);
            this.reportViewer1.TabIndex = 15;
            // 
            // btn_ThongKeDoanhThu
            // 
            this.btn_ThongKeDoanhThu.AllowDrop = true;
            this.btn_ThongKeDoanhThu.Image = global::QuanLyBanSatThep.Properties.Resources.icon_magnifier;
            this.btn_ThongKeDoanhThu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ThongKeDoanhThu.Location = new System.Drawing.Point(447, 19);
            this.btn_ThongKeDoanhThu.Name = "btn_ThongKeDoanhThu";
            this.btn_ThongKeDoanhThu.Size = new System.Drawing.Size(122, 28);
            this.btn_ThongKeDoanhThu.TabIndex = 12;
            this.btn_ThongKeDoanhThu.Text = "Xem báo cáo";
            this.btn_ThongKeDoanhThu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_ThongKeDoanhThu.UseVisualStyleBackColor = true;
            this.btn_ThongKeDoanhThu.Click += new System.EventHandler(this.btn_ThongKeDoanhThu_Click);
            // 
            // BaoCaoDoanhThuBindingSource
            // 
            this.BaoCaoDoanhThuBindingSource.DataMember = "BaoCaoDoanhThu";
            this.BaoCaoDoanhThuBindingSource.DataSource = this.QLSatThepDoanhThu;
            // 
            // QLSatThepDoanhThu
            // 
            this.QLSatThepDoanhThu.DataSetName = "QLSatThepDoanhThu";
            this.QLSatThepDoanhThu.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tongDoanhThuBindingSource
            // 
            this.tongDoanhThuBindingSource.DataMember = "TongDoanhThu";
            this.tongDoanhThuBindingSource.DataSource = this.qLSatThepDoanhThu1;
            // 
            // qLSatThepDoanhThu1
            // 
            this.qLSatThepDoanhThu1.DataSetName = "QLSatThepDoanhThu";
            this.qLSatThepDoanhThu1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DoanhThuChartBindingSource
            // 
            this.DoanhThuChartBindingSource.DataMember = "DoanhThuChart";
            this.DoanhThuChartBindingSource.DataSource = this.QLSatThepDoanhThu;
            // 
            // BaoCaoDoanhThuTableAdapter
            // 
            this.BaoCaoDoanhThuTableAdapter.ClearBeforeFill = true;
            // 
            // tongDoanhThuTableAdapter
            // 
            this.tongDoanhThuTableAdapter.ClearBeforeFill = true;
            // 
            // DoanhThuChartTableAdapter
            // 
            this.DoanhThuChartTableAdapter.ClearBeforeFill = true;
            // 
            // BaoCaoDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 581);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.groupBox1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "BaoCaoDoanhThu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "THỐNG KÊ DOANH THU";
            this.Load += new System.EventHandler(this.BaoCaoDoanhThu_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BaoCaoDoanhThuBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QLSatThepDoanhThu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tongDoanhThuBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLSatThepDoanhThu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DoanhThuChartBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_ThongKeDoanhThu;
        private System.Windows.Forms.ComboBox cb_Chon;
        private System.Windows.Forms.DateTimePicker dt_XuatDoanhThu;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource BaoCaoDoanhThuBindingSource;
        private QLSatThepDoanhThu QLSatThepDoanhThu;
        private QLSatThepDoanhThuTableAdapters.BaoCaoDoanhThuTableAdapter BaoCaoDoanhThuTableAdapter;
        private System.Windows.Forms.BindingSource tongDoanhThuBindingSource;
        private QLSatThepDoanhThu qLSatThepDoanhThu1;
        private QLSatThepDoanhThuTableAdapters.TongDoanhThuTableAdapter tongDoanhThuTableAdapter;
        private System.Windows.Forms.BindingSource DoanhThuChartBindingSource;
        private QLSatThepDoanhThuTableAdapters.DoanhThuChartTableAdapter DoanhThuChartTableAdapter;
    }
}