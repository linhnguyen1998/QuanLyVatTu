namespace QuanLyBanSatThep
{
    partial class ThanhToanHD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThanhToanHD));
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_Total = new System.Windows.Forms.TextBox();
            this.lsv_DinhMuc = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel3 = new System.Windows.Forms.Panel();
            this.txt_Sdt = new System.Windows.Forms.TextBox();
            this.txt_Tenkh = new System.Windows.Forms.TextBox();
            this.nm_Soluong = new System.Windows.Forms.NumericUpDown();
            this.cb_VatTu = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.btn_preview = new System.Windows.Forms.Button();
            this.btn_InHD = new System.Windows.Forms.Button();
            this.btn_TamTinh = new System.Windows.Forms.Button();
            this.btn_HuyHD = new System.Windows.Forms.Button();
            this.btn_TaoHD = new System.Windows.Forms.Button();
            this.btn_ThanhToanHD = new System.Windows.Forms.Button();
            this.btn_Remove = new System.Windows.Forms.Button();
            this.btn_AddVattu = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nm_Soluong)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txt_Total);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(467, 266);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(598, 34);
            this.panel2.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 19);
            this.label6.TabIndex = 0;
            this.label6.Text = "TỔNG CỘNG:";
            // 
            // txt_Total
            // 
            this.txt_Total.Location = new System.Drawing.Point(309, 3);
            this.txt_Total.Name = "txt_Total";
            this.txt_Total.ReadOnly = true;
            this.txt_Total.Size = new System.Drawing.Size(286, 26);
            this.txt_Total.TabIndex = 5;
            this.txt_Total.Text = "0";
            this.txt_Total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_Total.TextChanged += new System.EventHandler(this.txt_Total_TextChanged);
            // 
            // lsv_DinhMuc
            // 
            this.lsv_DinhMuc.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader5,
            this.columnHeader3,
            this.columnHeader4});
            this.lsv_DinhMuc.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsv_DinhMuc.GridLines = true;
            this.lsv_DinhMuc.Location = new System.Drawing.Point(467, 12);
            this.lsv_DinhMuc.Name = "lsv_DinhMuc";
            this.lsv_DinhMuc.Size = new System.Drawing.Size(598, 247);
            this.lsv_DinhMuc.TabIndex = 5;
            this.lsv_DinhMuc.UseCompatibleStateImageBehavior = false;
            this.lsv_DinhMuc.View = System.Windows.Forms.View.Details;
            this.lsv_DinhMuc.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.lsv_DinhMuc_DrawSubItem);
            this.lsv_DinhMuc.SelectedIndexChanged += new System.EventHandler(this.lsv_DinhMuc_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên vật tư";
            this.columnHeader1.Width = 157;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "ĐVT";
            this.columnHeader2.Width = 75;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Số lượng";
            this.columnHeader5.Width = 75;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Đơn giá";
            this.columnHeader3.Width = 140;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Thành tiền";
            this.columnHeader4.Width = 126;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txt_Sdt);
            this.panel3.Controls.Add(this.txt_Tenkh);
            this.panel3.Controls.Add(this.nm_Soluong);
            this.panel3.Controls.Add(this.btn_preview);
            this.panel3.Controls.Add(this.btn_InHD);
            this.panel3.Controls.Add(this.btn_TamTinh);
            this.panel3.Controls.Add(this.btn_HuyHD);
            this.panel3.Controls.Add(this.btn_TaoHD);
            this.panel3.Controls.Add(this.btn_ThanhToanHD);
            this.panel3.Controls.Add(this.btn_Remove);
            this.panel3.Controls.Add(this.btn_AddVattu);
            this.panel3.Controls.Add(this.cb_VatTu);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(12, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(430, 288);
            this.panel3.TabIndex = 4;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // txt_Sdt
            // 
            this.txt_Sdt.Location = new System.Drawing.Point(142, 143);
            this.txt_Sdt.Name = "txt_Sdt";
            this.txt_Sdt.Size = new System.Drawing.Size(279, 26);
            this.txt_Sdt.TabIndex = 5;
            // 
            // txt_Tenkh
            // 
            this.txt_Tenkh.Location = new System.Drawing.Point(142, 111);
            this.txt_Tenkh.Name = "txt_Tenkh";
            this.txt_Tenkh.Size = new System.Drawing.Size(279, 26);
            this.txt_Tenkh.TabIndex = 5;
            // 
            // nm_Soluong
            // 
            this.nm_Soluong.Location = new System.Drawing.Point(285, 61);
            this.nm_Soluong.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nm_Soluong.Name = "nm_Soluong";
            this.nm_Soluong.Size = new System.Drawing.Size(55, 26);
            this.nm_Soluong.TabIndex = 4;
            this.nm_Soluong.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cb_VatTu
            // 
            this.cb_VatTu.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_VatTu.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_VatTu.FormattingEnabled = true;
            this.cb_VatTu.Location = new System.Drawing.Point(61, 61);
            this.cb_VatTu.Name = "cb_VatTu";
            this.cb_VatTu.Size = new System.Drawing.Size(145, 27);
            this.cb_VatTu.TabIndex = 2;
            this.cb_VatTu.SelectedIndexChanged += new System.EventHandler(this.cb_VatTu_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 146);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 19);
            this.label7.TabIndex = 0;
            this.label7.Text = "Số điện thoại:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(212, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 19);
            this.label8.TabIndex = 0;
            this.label8.Text = "Số lượng:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 114);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 19);
            this.label9.TabIndex = 0;
            this.label9.Text = "Tên khách hàng:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(172, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(107, 24);
            this.label10.TabIndex = 0;
            this.label10.Text = "HÓA ĐƠN";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 65);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 19);
            this.label11.TabIndex = 0;
            this.label11.Text = "Vật tư:";
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // btn_preview
            // 
            this.btn_preview.Image = global::QuanLyBanSatThep.Properties.Resources.print_search_512;
            this.btn_preview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_preview.Location = new System.Drawing.Point(154, 192);
            this.btn_preview.Name = "btn_preview";
            this.btn_preview.Size = new System.Drawing.Size(125, 37);
            this.btn_preview.TabIndex = 3;
            this.btn_preview.Text = "Print Preview";
            this.btn_preview.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_preview.UseVisualStyleBackColor = true;
            this.btn_preview.Click += new System.EventHandler(this.btn_preview_Click);
            // 
            // btn_InHD
            // 
            this.btn_InHD.Image = global::QuanLyBanSatThep.Properties.Resources.img_557901;
            this.btn_InHD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_InHD.Location = new System.Drawing.Point(296, 243);
            this.btn_InHD.Name = "btn_InHD";
            this.btn_InHD.Size = new System.Drawing.Size(125, 37);
            this.btn_InHD.TabIndex = 3;
            this.btn_InHD.Text = "In hóa đơn";
            this.btn_InHD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_InHD.UseVisualStyleBackColor = true;
            this.btn_InHD.Click += new System.EventHandler(this.btn_InHD_Click);
            // 
            // btn_TamTinh
            // 
            this.btn_TamTinh.Image = global::QuanLyBanSatThep.Properties.Resources.document_warning;
            this.btn_TamTinh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_TamTinh.Location = new System.Drawing.Point(154, 243);
            this.btn_TamTinh.Name = "btn_TamTinh";
            this.btn_TamTinh.Size = new System.Drawing.Size(125, 37);
            this.btn_TamTinh.TabIndex = 3;
            this.btn_TamTinh.Text = "Tạm tính HD";
            this.btn_TamTinh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_TamTinh.UseVisualStyleBackColor = true;
            this.btn_TamTinh.Click += new System.EventHandler(this.btn_TamTinh_Click);
            // 
            // btn_HuyHD
            // 
            this.btn_HuyHD.Image = global::QuanLyBanSatThep.Properties.Resources.Delete_file_icon;
            this.btn_HuyHD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_HuyHD.Location = new System.Drawing.Point(296, 192);
            this.btn_HuyHD.Name = "btn_HuyHD";
            this.btn_HuyHD.Size = new System.Drawing.Size(125, 37);
            this.btn_HuyHD.TabIndex = 3;
            this.btn_HuyHD.Text = "Hủy hóa đơn";
            this.btn_HuyHD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_HuyHD.UseVisualStyleBackColor = true;
            this.btn_HuyHD.Click += new System.EventHandler(this.btn_HuyHD_Click);
            // 
            // btn_TaoHD
            // 
            this.btn_TaoHD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_TaoHD.Image = global::QuanLyBanSatThep.Properties.Resources.new_document_file_create_5122;
            this.btn_TaoHD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_TaoHD.Location = new System.Drawing.Point(8, 192);
            this.btn_TaoHD.Name = "btn_TaoHD";
            this.btn_TaoHD.Size = new System.Drawing.Size(125, 37);
            this.btn_TaoHD.TabIndex = 3;
            this.btn_TaoHD.Text = "Tạo hóa đơn";
            this.btn_TaoHD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_TaoHD.UseVisualStyleBackColor = true;
            this.btn_TaoHD.Click += new System.EventHandler(this.btn_TaoHD_Click);
            // 
            // btn_ThanhToanHD
            // 
            this.btn_ThanhToanHD.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_ThanhToanHD.Image = global::QuanLyBanSatThep.Properties.Resources.legal_vector_document_6;
            this.btn_ThanhToanHD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ThanhToanHD.Location = new System.Drawing.Point(8, 243);
            this.btn_ThanhToanHD.Name = "btn_ThanhToanHD";
            this.btn_ThanhToanHD.Size = new System.Drawing.Size(125, 37);
            this.btn_ThanhToanHD.TabIndex = 3;
            this.btn_ThanhToanHD.Text = "Thanh toán";
            this.btn_ThanhToanHD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_ThanhToanHD.UseVisualStyleBackColor = true;
            this.btn_ThanhToanHD.Click += new System.EventHandler(this.btn_ThanhToanHD_Click);
            // 
            // btn_Remove
            // 
            this.btn_Remove.Image = global::QuanLyBanSatThep.Properties.Resources.remove_icon_png_15;
            this.btn_Remove.Location = new System.Drawing.Point(390, 61);
            this.btn_Remove.Name = "btn_Remove";
            this.btn_Remove.Size = new System.Drawing.Size(27, 27);
            this.btn_Remove.TabIndex = 3;
            this.btn_Remove.UseVisualStyleBackColor = true;
            this.btn_Remove.Click += new System.EventHandler(this.btn_Remove_Click);
            // 
            // btn_AddVattu
            // 
            this.btn_AddVattu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_AddVattu.Image = global::QuanLyBanSatThep.Properties.Resources.add_button_png_12;
            this.btn_AddVattu.Location = new System.Drawing.Point(353, 61);
            this.btn_AddVattu.Name = "btn_AddVattu";
            this.btn_AddVattu.Size = new System.Drawing.Size(27, 27);
            this.btn_AddVattu.TabIndex = 3;
            this.btn_AddVattu.UseVisualStyleBackColor = true;
            this.btn_AddVattu.Click += new System.EventHandler(this.btn_AddVattu_Click);
            // 
            // ThanhToanHD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 312);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lsv_DinhMuc);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ThanhToanHD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hóa Đơn";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ThanhToanHD_FormClosing);
            this.Load += new System.EventHandler(this.HoaDon_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nm_Soluong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_Total;
        private System.Windows.Forms.ListView lsv_DinhMuc;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txt_Sdt;
        private System.Windows.Forms.TextBox txt_Tenkh;
        private System.Windows.Forms.NumericUpDown nm_Soluong;
        private System.Windows.Forms.Button btn_TamTinh;
        private System.Windows.Forms.Button btn_HuyHD;
        private System.Windows.Forms.Button btn_ThanhToanHD;
        private System.Windows.Forms.Button btn_AddVattu;
        private System.Windows.Forms.ComboBox cb_VatTu;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button btn_TaoHD;
        private System.Windows.Forms.Button btn_InHD;
        private System.Windows.Forms.Button btn_Remove;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Button btn_preview;
    }
}