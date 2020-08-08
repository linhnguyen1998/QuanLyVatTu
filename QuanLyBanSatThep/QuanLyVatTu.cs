using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanSatThep
{
    public partial class frm_Admin : Form
    {
        private ToolStripMenuItem adminToolStripMenuItem;
        private ToolStripMenuItem Support_ToolStripMenuItem;
        private ToolStripMenuItem ThongKe_ToolStripMenuItem;
        private ToolStripMenuItem PhieuNhap_ToolStripMenuItem;
        private ToolStripMenuItem hoadonToolStripMenuItem;
        private ToolStripMenuItem guide_ToolStripMenuItem;
        private ToolStripMenuItem tacgia_StripMenuItem;
        private ToolStripMenuItem qlvattu_ToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private PictureBox pbx_PhieuNhap;
        private PictureBox pbx_HoaDon;
        private PictureBox pbx_QLVT;
        private PictureBox pbx_Thoat;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private MenuStrip menuStrip1;

        public frm_Admin()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Admin));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PhieuNhap_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hoadonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qlvattu_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ThongKe_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Support_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guide_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tacgia_StripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pbx_Thoat = new System.Windows.Forms.PictureBox();
            this.pbx_QLVT = new System.Windows.Forms.PictureBox();
            this.pbx_HoaDon = new System.Windows.Forms.PictureBox();
            this.pbx_PhieuNhap = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_Thoat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_QLVT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_HoaDon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_PhieuNhap)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminToolStripMenuItem,
            this.ThongKe_ToolStripMenuItem,
            this.Support_ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(755, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PhieuNhap_ToolStripMenuItem,
            this.hoadonToolStripMenuItem,
            this.qlvattu_ToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.adminToolStripMenuItem.Text = "Admin";
            // 
            // PhieuNhap_ToolStripMenuItem
            // 
            this.PhieuNhap_ToolStripMenuItem.Name = "PhieuNhap_ToolStripMenuItem";
            this.PhieuNhap_ToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.PhieuNhap_ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.PhieuNhap_ToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.PhieuNhap_ToolStripMenuItem.Text = "Phiếu nhập";
            this.PhieuNhap_ToolStripMenuItem.Click += new System.EventHandler(this.PhieuNhap_ToolStripMenuItem_Click);
            // 
            // hoadonToolStripMenuItem
            // 
            this.hoadonToolStripMenuItem.Name = "hoadonToolStripMenuItem";
            this.hoadonToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.hoadonToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.hoadonToolStripMenuItem.Text = "Hóa đơn";
            this.hoadonToolStripMenuItem.Click += new System.EventHandler(this.hoadonToolStripMenuItem_Click);
            // 
            // qlvattu_ToolStripMenuItem
            // 
            this.qlvattu_ToolStripMenuItem.Name = "qlvattu_ToolStripMenuItem";
            this.qlvattu_ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.qlvattu_ToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.qlvattu_ToolStripMenuItem.Text = "Quản lý vật tư";
            this.qlvattu_ToolStripMenuItem.Click += new System.EventHandler(this.qlvattu_ToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.exitToolStripMenuItem.Text = "Thoát";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // ThongKe_ToolStripMenuItem
            // 
            this.ThongKe_ToolStripMenuItem.Name = "ThongKe_ToolStripMenuItem";
            this.ThongKe_ToolStripMenuItem.Size = new System.Drawing.Size(127, 20);
            this.ThongKe_ToolStripMenuItem.Text = "Thống kê doanh thu";
            this.ThongKe_ToolStripMenuItem.Click += new System.EventHandler(this.ThongKe_ToolStripMenuItem_Click);
            // 
            // Support_ToolStripMenuItem
            // 
            this.Support_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.guide_ToolStripMenuItem,
            this.tacgia_StripMenuItem});
            this.Support_ToolStripMenuItem.Name = "Support_ToolStripMenuItem";
            this.Support_ToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.Support_ToolStripMenuItem.Text = "Hỗ Trợ";
            // 
            // guide_ToolStripMenuItem
            // 
            this.guide_ToolStripMenuItem.Name = "guide_ToolStripMenuItem";
            this.guide_ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.guide_ToolStripMenuItem.Text = "Hướng dẫn sử dụng";
            // 
            // tacgia_StripMenuItem
            // 
            this.tacgia_StripMenuItem.Name = "tacgia_StripMenuItem";
            this.tacgia_StripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.tacgia_StripMenuItem.Text = "Tác giả";
            this.tacgia_StripMenuItem.Click += new System.EventHandler(this.tacgia_StripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("VNI-Souvir", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(38, 239);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "PHIEÁU NHAÄP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("VNI-Souvir", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gold;
            this.label2.Location = new System.Drawing.Point(233, 239);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "HOÙA ÑÔN";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("VNI-Souvir", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gold;
            this.label3.Location = new System.Drawing.Point(387, 239);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "QUAÛN LYÙ VAÄT TÖ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("VNI-Souvir", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gold;
            this.label4.Location = new System.Drawing.Point(602, 239);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "ÑAÊNG XUAÁT";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("VNI-Korin", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.IndianRed;
            this.label5.Location = new System.Drawing.Point(200, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(349, 30);
            this.label5.TabIndex = 2;
            this.label5.Text = "CÖÛA HAØNG SAÉT THEÙP PHÖÔNG";
            // 
            // pbx_Thoat
            // 
            this.pbx_Thoat.BackColor = System.Drawing.Color.Transparent;
            this.pbx_Thoat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbx_Thoat.Image = global::QuanLyBanSatThep.Properties.Resources.fermer_la_porte_clipart_12s1;
            this.pbx_Thoat.Location = new System.Drawing.Point(596, 96);
            this.pbx_Thoat.Name = "pbx_Thoat";
            this.pbx_Thoat.Size = new System.Drawing.Size(122, 122);
            this.pbx_Thoat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbx_Thoat.TabIndex = 1;
            this.pbx_Thoat.TabStop = false;
            this.pbx_Thoat.Click += new System.EventHandler(this.pbx_Thoat_Click);
            this.pbx_Thoat.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbx_Thoat_MouseDown);
            this.pbx_Thoat.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbx_Thoat_MouseUp);
            // 
            // pbx_QLVT
            // 
            this.pbx_QLVT.BackColor = System.Drawing.Color.Transparent;
            this.pbx_QLVT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbx_QLVT.Image = global::QuanLyBanSatThep.Properties.Resources.approved_clipart_purchase_request_1;
            this.pbx_QLVT.Location = new System.Drawing.Point(409, 96);
            this.pbx_QLVT.Name = "pbx_QLVT";
            this.pbx_QLVT.Size = new System.Drawing.Size(122, 122);
            this.pbx_QLVT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbx_QLVT.TabIndex = 1;
            this.pbx_QLVT.TabStop = false;
            this.pbx_QLVT.Click += new System.EventHandler(this.pbx_QLVT_Click);
            this.pbx_QLVT.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbx_QLVT_MouseDown);
            this.pbx_QLVT.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbx_QLVT_MouseUp);
            // 
            // pbx_HoaDon
            // 
            this.pbx_HoaDon.BackColor = System.Drawing.Color.Transparent;
            this.pbx_HoaDon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbx_HoaDon.Image = global::QuanLyBanSatThep.Properties.Resources.pict__sales_orders_sales_workflow_vector_stencils_library1;
            this.pbx_HoaDon.Location = new System.Drawing.Point(221, 96);
            this.pbx_HoaDon.Name = "pbx_HoaDon";
            this.pbx_HoaDon.Size = new System.Drawing.Size(122, 122);
            this.pbx_HoaDon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbx_HoaDon.TabIndex = 1;
            this.pbx_HoaDon.TabStop = false;
            this.pbx_HoaDon.Click += new System.EventHandler(this.pbx_HoaDon_Click);
            this.pbx_HoaDon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbx_HoaDon_MouseDown);
            this.pbx_HoaDon.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbx_HoaDon_MouseUp);
            // 
            // pbx_PhieuNhap
            // 
            this.pbx_PhieuNhap.BackColor = System.Drawing.Color.Transparent;
            this.pbx_PhieuNhap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbx_PhieuNhap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbx_PhieuNhap.Image = global::QuanLyBanSatThep.Properties.Resources.order_clipart_order1;
            this.pbx_PhieuNhap.Location = new System.Drawing.Point(36, 96);
            this.pbx_PhieuNhap.Name = "pbx_PhieuNhap";
            this.pbx_PhieuNhap.Size = new System.Drawing.Size(122, 122);
            this.pbx_PhieuNhap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbx_PhieuNhap.TabIndex = 1;
            this.pbx_PhieuNhap.TabStop = false;
            this.pbx_PhieuNhap.Click += new System.EventHandler(this.pbx_PhieuNhap_Click);
            this.pbx_PhieuNhap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbx_PhieuNhap_MouseDown);
            this.pbx_PhieuNhap.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbx_PhieuNhap_MouseUp);
            // 
            // frm_Admin
            // 
            this.BackgroundImage = global::QuanLyBanSatThep.Properties.Resources.mau_background_don_gian_01_1024x640;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(755, 328);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbx_Thoat);
            this.Controls.Add(this.pbx_QLVT);
            this.Controls.Add(this.pbx_HoaDon);
            this.Controls.Add(this.pbx_PhieuNhap);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frm_Admin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bảng Điều Khiển";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_Thoat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_QLVT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_HoaDon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_PhieuNhap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        private void hoadonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pbx_HoaDon_Click(this, new EventArgs());
            ThanhToanHD hd = new ThanhToanHD();
            this.Hide();
            hd.ShowDialog();
            this.Show();
        }

        private void qlvattu_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pbx_QLVT_Click(this, new EventArgs());
            fmanage ql = new fmanage();
            this.Hide();
            ql.ShowDialog();
            this.Show();
        }

        private void PhieuNhap_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pbx_PhieuNhap_Click(this, new EventArgs());
            PhieuNhapKho pn = new PhieuNhapKho();
            this.Hide();
            pn.ShowDialog();
            this.Show();
        }

        private void ThongKe_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BaoCaoDoanhThu frm = new BaoCaoDoanhThu();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void tacgia_StripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tác giả: Nguyễn Vân Khánh Linh" + "\r\n" + "Email: linhnvk1998@gmail.com" + "\r\n" + "Sdt: +84 374 451 155" + "\r\n" + "Phiên bản: v1.0", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pbx_PhieuNhap_Click(object sender, EventArgs e)
        {

            PhieuNhapKho pn = new PhieuNhapKho();
            this.Hide();
            pn.ShowDialog();
            this.Show();
        }

        private void pbx_PhieuNhap_MouseDown(object sender, MouseEventArgs e)
        {
            pbx_PhieuNhap.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pbx_PhieuNhap_MouseUp(object sender, MouseEventArgs e)
        {
            pbx_PhieuNhap.BorderStyle = BorderStyle.FixedSingle;
        }

        private void pbx_HoaDon_MouseDown(object sender, MouseEventArgs e)
        {
            pbx_HoaDon.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pbx_HoaDon_MouseUp(object sender, MouseEventArgs e)
        {
            pbx_HoaDon.BorderStyle = BorderStyle.FixedSingle;
        }

        private void pbx_QLVT_MouseDown(object sender, MouseEventArgs e)
        {
            pbx_QLVT.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pbx_QLVT_MouseUp(object sender, MouseEventArgs e)
        {
            pbx_QLVT.BorderStyle = BorderStyle.FixedSingle;
        }

        private void pbx_Thoat_MouseDown(object sender, MouseEventArgs e)
        {
            pbx_Thoat.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pbx_Thoat_MouseUp(object sender, MouseEventArgs e)
        {
            pbx_Thoat.BorderStyle = BorderStyle.FixedSingle;
        }

        private void pbx_HoaDon_Click(object sender, EventArgs e)
        {
            ThanhToanHD hd = new ThanhToanHD();
            this.Hide();
            hd.ShowDialog();
            this.Show();
        }

        private void pbx_QLVT_Click(object sender, EventArgs e)
        {
            fmanage mn = new fmanage();
            this.Hide();
            mn.ShowDialog();
            this.Show();
        }

        private void pbx_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pbx_Thoat_Click(this, new EventArgs());
        }
    }
}
