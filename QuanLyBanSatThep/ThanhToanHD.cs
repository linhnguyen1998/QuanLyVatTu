using QuanLyBanSatThep.DAO;
using QuanLyBanSatThep.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyBanSatThep.Properties;

namespace QuanLyBanSatThep
{
    public partial class ThanhToanHD : Form
    {
        public ThanhToanHD()
        {
            InitializeComponent();
            LoadVatTu_cb();
        }

        void LoadVatTu_cb()
        {
            List<VatTu> listVatTu = VatTuDAO.Instance.GetListVatTu();
            cb_VatTu.DataSource = listVatTu;
            cb_VatTu.DisplayMember = "Ten_vattu";
        }
       
        private void cb_VatTu_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void btn_AddVattu_Click(object sender, EventArgs e)
        {
            int idVattu = (cb_VatTu.SelectedItem as VatTu).Id_vattu;
            string tenVattu = (cb_VatTu.SelectedItem as VatTu).Ten_vattu;
            int slton = (cb_VatTu.SelectedItem as VatTu).Soluongton;
            int sluong = (int)nm_Soluong.Value;
            if (slton >= sluong)
            {
                VatTuDAO.Instance.Add_DinhMuc(idVattu, sluong);
                ShowDinhMuc();
            }
            else
            {
                MessageBox.Show("Số lượng tồn không đủ để bán " + "\r\n" + "Tên vật tư: " + tenVattu + "\r\n" + "Số lượng tồn: " + slton, "Thông báo");
            }
        }
            void ShowDinhMuc()
        {
            lsv_DinhMuc.Items.Clear();
            //Đổi định dạng ngôn ngữ
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("vi-VN");
            culture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            culture.DateTimeFormat.DateSeparator = "/";
            Thread.CurrentThread.CurrentCulture = culture;
            //-----------------
            ImageList imglist = new ImageList();
            List<DinhMuc> listDinhMuc = DinhMucDAO.Instance.LoadDinhMucList();
            double TotalPrice = 0;
            
            foreach (DinhMuc item in listDinhMuc)
            {
                ListViewItem lsvItem = new ListViewItem(item.Ten_vattu.ToString());
                lsvItem.SubItems.Add(item.Dvt.ToString());
                lsvItem.SubItems.Add(item.Soluong.ToString());
                lsvItem.SubItems.Add(item.Dongia.ToString("c"));            
                lsvItem.SubItems.Add(item.Thanhtien.ToString("c"));
                TotalPrice += item.Thanhtien;
                lsv_DinhMuc.Items.Add(lsvItem);
                
            }
            
            txt_Total.Text = TotalPrice.ToString("c");
        }
        void Remove()
        {
            string ten = "";
            foreach (ListViewItem item in lsv_DinhMuc.SelectedItems)
            {
                 ten = item.SubItems[0].Text;
            }
            VatTuDAO.Instance.Remove_DinhMuc(ten);
            ShowDinhMuc();
        }
        void ThanhToan()
        {
            string ten = txt_Tenkh.Text;
            string sdt = txt_Sdt.Text;
            List<DinhMuc> listDinhMuc = DinhMucDAO.Instance.LoadDinhMucList();
            double TotalPrice = 0;
            foreach (DinhMuc item in listDinhMuc)
            {
                ListViewItem lsvItem = new ListViewItem(item.Ten_vattu.ToString());
                lsvItem.SubItems.Add(item.Thanhtien.ToString("c"));
                TotalPrice += item.Thanhtien;
            }
            double tongcong = TotalPrice;
            HoaDonDAO.Instance.ThanhToan(ten, sdt, tongcong);
        }

        void ThanhToanTamTinh()
        {
            string ten = txt_Tenkh.Text;
            string sdt = txt_Sdt.Text;
            List<DinhMuc> listDinhMuc = DinhMucDAO.Instance.LoadDinhMucList();
            double TotalPrice = 0;
            foreach (DinhMuc item in listDinhMuc)
            {
                ListViewItem lsvItem = new ListViewItem(item.Ten_vattu.ToString());
                lsvItem.SubItems.Add(item.Thanhtien.ToString("c"));
                TotalPrice += item.Thanhtien;
            }
            double tongcong = TotalPrice;
            TamTinhDAO.Instance.TamTinhHD(ten, sdt, tongcong);
        }

        private void txt_Total_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void HoaDon_Load(object sender, EventArgs e)
        {
            btn_ThanhToanHD.Enabled = false ;
            btn_TamTinh.Enabled = false;
            btn_HuyHD.Enabled = false;
            btn_AddVattu.Enabled = false;
            btn_Remove.Enabled = false;
            btn_preview.Enabled = false;
            btn_InHD.Enabled = false;

            btn_AddVattu.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void btn_ThanhToanHD_Click(object sender, EventArgs e)
        {
            try
            { 
                if (MessageBox.Show("Xác nhận thanh toán", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ThanhToan();
                    MessageBox.Show("Thanh toán thành công", "THÔNG BÁO");
                    btn_ThanhToanHD.Enabled = false;
                    btn_TamTinh.Enabled = false;
                    btn_HuyHD.Enabled = false;
                    btn_AddVattu.Enabled = false;
                    btn_Remove.Enabled = false;
                    btn_TaoHD.Enabled = true;
                    btn_preview.Enabled = true;
                    btn_InHD.Enabled = true;
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể thanh toán" + "\r\n" + ex.Message, "LỖI");
            }
        }

        private void btn_TaoHD_Click(object sender, EventArgs e)
        {

                PhieuDAO.Instance.CreatePhieu();
                btn_TaoHD.Enabled = false;
                btn_ThanhToanHD.Enabled = true;
                btn_TamTinh.Enabled = true;
                btn_HuyHD.Enabled = true;
                btn_AddVattu.Enabled = true;
                btn_Remove.Enabled = true;
                btn_preview.Enabled = false;
                btn_InHD.Enabled = false;
                txt_Tenkh.Clear();
                txt_Sdt.Clear();
                ShowDinhMuc();
  
        }

        private void btn_HuyHD_Click(object sender, EventArgs e)
        {
           
                if (MessageBox.Show("Thanh toán chưa hoàn tất. Bạn có chắc chắn muốn hủy!!!", "LƯU Ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    PhieuDAO.Instance.DestroyPhieu();
                    btn_TaoHD.Enabled = true;
                    btn_ThanhToanHD.Enabled = false;
                    btn_TamTinh.Enabled = false;
                    btn_HuyHD.Enabled = false;
                    btn_AddVattu.Enabled = false;
                    btn_Remove.Enabled = false;
                    txt_Tenkh.Clear();
                    txt_Sdt.Clear();
                    ShowDinhMuc();
                }
            
        }

        private void lsv_DinhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lsv_DinhMuc_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
           
        }

        private void btn_Remove_Click(object sender, EventArgs e)
        {
                Remove();
        }

        private void btn_TamTinh_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Xác nhận thanh toán tạm tính", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ThanhToanTamTinh();
                    MessageBox.Show("Thanh toán tạm tính thành công", "THÔNG BÁO");
                    btn_ThanhToanHD.Enabled = false;
                    btn_TamTinh.Enabled = false;
                    btn_HuyHD.Enabled = false;
                    btn_AddVattu.Enabled = false;
                    btn_Remove.Enabled = false;
                    btn_TaoHD.Enabled = true;
                    btn_preview.Enabled = true;
                    btn_InHD.Enabled = true;
                    txt_Tenkh.Clear();
                    txt_Sdt.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể thanh toán" + "\r\n" + ex.Message, "LỖI");
            }
        }

        private void btn_InHD_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void ThanhToanHD_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát", "THÔNG BÁO", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (btn_HuyHD.Enabled == false)
                    MessageBox.Show("Đã thoát");
                else
                    PhieuDAO.Instance.DestroyPhieu();
            }
            else
            {
                e.Cancel = true;
            }
                
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Image image = Resources.Nhãn_hiệu;

            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("vi-VN");
            culture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            culture.DateTimeFormat.DateSeparator = "/";
            Thread.CurrentThread.CurrentCulture = culture;

            e.Graphics.DrawImage(image, 50, 0 , image.Width + 300, image.Height + 80);
            e.Graphics.DrawString("HÓA ĐƠN", new Font("Arial", 24, FontStyle.Bold), Brushes.Black, new Point(350, 260));
            e.Graphics.DrawString("Ngày: " + DateTime.Now.ToShortDateString() + ".                       Thời gian: " + DateTime.Now.ToShortTimeString(), new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(25, 310));

            e.Graphics.DrawString("Tên khách hàng: " + txt_Tenkh.Text.Trim(), new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(25, 340));
            e.Graphics.DrawString("Số điện thoại khách hàng: " + txt_Sdt.Text.Trim(), new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(25, 370));
            e.Graphics.DrawString("--------------------------------------------------------------------------------------------------------", new Font("Arial", 16, FontStyle.Regular), Brushes.Black, new Point(25, 390));
            e.Graphics.DrawString("Tên vật tư", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(28, 410));
            e.Graphics.DrawString("ĐVT", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(280, 410));
            e.Graphics.DrawString("Số lượng", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(380, 410));
            e.Graphics.DrawString("Đơn giá", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(540, 410));
            e.Graphics.DrawString("Thành tiền", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(670, 410));
            e.Graphics.DrawString("--------------------------------------------------------------------------------------------------------", new Font("Arial", 16, FontStyle.Regular), Brushes.Black, new Point(25, 430));
            List<DinhMuc> listDinhMuc = DinhMucDAO.Instance.ShowDetail();
            int ypos = 450;
            foreach (var i in listDinhMuc)
            {
                e.Graphics.DrawString(i.Ten_vattu, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(28, ypos));
                e.Graphics.DrawString(i.Dvt, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(280, ypos));
                e.Graphics.DrawString(i.Soluong.ToString(), new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(400, ypos));
                e.Graphics.DrawString(i.Dongia.ToString("c"), new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(495, ypos));
                e.Graphics.DrawString(i.Thanhtien.ToString("c"), new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(670, ypos));

                ypos += 30;
            }
            e.Graphics.DrawString("--------------------------------------------------------------------------------------------------------", new Font("Arial", 16, FontStyle.Regular), Brushes.Black, new Point(25, ypos));
            e.Graphics.DrawString("TỔNG CỘNG: ", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(28, ypos + 30));
            e.Graphics.DrawString(txt_Total.Text.Trim(), new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(640, ypos + 30));
            e.Graphics.DrawString("_________________________________________________________________________________", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, ypos + 50));
            e.Graphics.DrawString("CÁM ƠN QUÝ KHÁCH VÀ HẸN GẶP LẠI!!!", new Font("Arial", 24, FontStyle.Bold), Brushes.Black, new Point(120, ypos + 90));
        }


        private void btn_preview_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }
    }
}
