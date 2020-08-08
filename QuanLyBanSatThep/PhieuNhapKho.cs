using QuanLyBanSatThep.DAO;
using QuanLyBanSatThep.DTO;
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
    public partial class PhieuNhapKho : Form
    {
        public PhieuNhapKho()
        {
            InitializeComponent();
            //cb_VatTu.Items.Add("Chọn");
            LoadVatTu_cb();
            LoadNCC_cb();

        }

        
        void LoadVatTu_cb()
        {

            List<VatTu> listVatTu = VatTuDAO.Instance.LoadListVatTu();
            cb_VatTu.DataSource = listVatTu;

            cb_VatTu.DisplayMember = "Ten_vattu";
            cb_VatTu.ValueMember = "Id_vattu";
            

        }
        void LoadNCC_cb()
        {
            List<NhaCungCap> listVatTu = NhaCungCapDAO.Instance.LoadNhaCCList();
            cb_NCC.DataSource = listVatTu;
            cb_NCC.DisplayMember = "Name";
            cb_NCC.ValueMember = "Id";
        }

        void dafaultValueVattu()
        {
            cb_VatTu.Text = "";
            txt_TenVattu.Text = "";
            txt_Dvt.Text = "";
            txt_DonGia.Text = "";
            txt_Soluongton.Text = "";
            cb_Maloai.Text = "";
        }

        private void btn_TaoPN_Click(object sender, EventArgs e)
        {
            PhieuDAO.Instance.CreatePhieu();
            cb_NCC.SelectedIndex = -1;
            grb_ttvattu.Enabled = true;
            cb_VatTu.Enabled = true;
            btn_TaoPN.Enabled = false;
            btn_LuuPhieu.Enabled = true;
            btn_HuyPN.Enabled = true;
            btn_Them.Enabled = true;
            btn_CapNhat.Enabled = true;
        }

        private void PhieuNhap_Load(object sender, EventArgs e)
        {
            pnl_ttchung.Enabled = false;
            grb_ttvattu.Enabled = false;
            btn_TaoPN.Enabled = true;
            btn_LuuPhieu.Enabled = false;
            btn_HuyPN.Enabled = false;
            btn_Them.Enabled = false;
            btn_CapNhat.Enabled = false;
            btn_ThoatChucNang.Enabled = false;
            btn_LuuVattu.Enabled = false;
            nmSoluongmoi.Visible = false;
            lbl_Soluongmoi.Visible = false;
            cb_VatTu.SelectedIndex = -1;
            cb_NCC.SelectedIndex = -1 ;
        }



        private void btn_Them_Click(object sender, EventArgs e)
        {
            cb_Maloai.DataSource = VatTuDAO.Instance.LoadLoaiVattu();
            cb_Maloai.DisplayMember = "Maloai";
            cb_Maloai.ValueMember = "Maloai";
            pnl_ttchung.Enabled = true;
            dafaultValueVattu();
            btn_CapNhat.Enabled = false;
            btn_LuuVattu.Enabled = true;
            btn_ThoatChucNang.Enabled = true;
        }

        private void btn_HuyPN_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn hủy phiếu nhập này!!!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                PhieuNhapDAO.Instance.Destroy_PhieuNhap();
                MessageBox.Show("Đã hủy phiếu nhập", "Thống báo", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            dafaultValueVattu();

            pnl_ttchung.Enabled = false;
            grb_ttvattu.Enabled = false;
            btn_TaoPN.Enabled = true;
            btn_LuuPhieu.Enabled = false;
            btn_HuyPN.Enabled = false;
            btn_Them.Enabled = false;
            btn_CapNhat.Enabled = false;
            btn_ThoatChucNang.Enabled = false;
            btn_LuuVattu.Enabled = false;
            nmSoluongmoi.Visible = false;
            lbl_Soluongmoi.Visible = false;

        }

        private void btn_CapNhat_Click(object sender, EventArgs e)
        {
            pnl_ttchung.Enabled = true;
            btn_Them.Enabled = false;
            btn_LuuVattu.Enabled = true;
            btn_ThoatChucNang.Enabled = true;
            txt_TenVattu.ReadOnly = true;
            txt_Dvt.ReadOnly = true;
            cb_Maloai.Enabled = false;
            txt_Soluongton.ReadOnly = true;
            lbl_Soluongmoi.Visible = true;
            nmSoluongmoi.Visible = true;
        }

   

        private void btn_LuuVattu_Click(object sender, EventArgs e)
        {
            string tenvt = "";
            string soluongton = "";
            double dongia = 0;
            string dvt = "";
            string maloai = "";
            if (btn_Them.Enabled)
            {
                try
                {
                    if (MessageBox.Show("Xác nhận thêm vật mới vào kho", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        tenvt = txt_TenVattu.Text;
                        soluongton = txt_Soluongton.Text;
                        dongia = Convert.ToDouble(txt_DonGia.Text);
                        dvt = txt_Dvt.Text;
                        maloai = (cb_Maloai.SelectedItem as LoaiVatTu).Maloai;
                        int dem = (int)VatTuDAO.Instance.KtraVatTuTonTai(tenvt);
                        if (dem > 0)
                            MessageBox.Show("Tên vật tư đã tồn tại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                        {
                            if (txt_TenVattu.Text == "" || txt_Soluongton.Text == "" || txt_Dvt.Text == "" || txt_DonGia.Text == "" || maloai == "")
                            {
                                MessageBox.Show("Dường như dữ liệu nhập vào bị trống ở ô nào đó!!! Mời nhập lại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                VatTuDAO.Instance.InsertIventory(maloai, tenvt, dvt, dongia, Convert.ToInt32(soluongton));
                                MessageBox.Show("Thêm thành công" + "\r\n" + "Mã loại(Ký tự): " + maloai + "\r\n" + "Tên vật tư: " + tenvt
                                    + "\r\n" + "Đơn vị tính: " + dvt + "\r\n" +
                                    "Đơn giá: " + dongia + "\r\n" + "Số lượng tồn: " + soluongton, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                VatTuDAO.Instance.Add_ChiTietNhap(Convert.ToInt32(soluongton), dongia);

                                LoadVatTu_cb();
                                pnl_ttchung.Enabled = false;
                                dafaultValueVattu();
                                btn_CapNhat.Enabled = true;
                                btn_LuuVattu.Enabled = false;
                                btn_ThoatChucNang.Enabled = false;
                            }

                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else if (btn_CapNhat.Enabled)
            {
                
                try
                {
                    dongia = Convert.ToDouble(txt_DonGia.Text);
                    soluongton = txt_Soluongton.Text;
                    int soluong = Convert.ToInt32(nmSoluongmoi.Value);
                    int soluongmoi = Convert.ToInt32(soluongton) + soluong;
                    int idvattu = (cb_VatTu.SelectedItem as VatTu).Id_vattu;
                    if (MessageBox.Show("Xác nhận cập nhật kho", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        VatTuDAO.Instance.UpdateIventory(idvattu, soluong, dongia);
                        MessageBox.Show("Cập nhật thành công" + "\r\n" + "Tên vật tư: " + tenvt + "\r\n" + "Số lượng tồn kho cũ: " + soluongton
                            + "\r\n" + "Số lượng vừa nhập: " + soluong + "\r\n" + "---------------------" + "\r\n"
                            + "Số lượng tồn mới: " + soluongmoi + "\r\n" + "Đơn giá: " + dongia, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        VatTuDAO.Instance.Update_ChiTietNhap(idvattu, soluong);
                        LoadVatTu_cb();
                        pnl_ttchung.Enabled = false;
                        dafaultValueVattu();
                        txt_TenVattu.ReadOnly = false;
                        txt_Dvt.ReadOnly = false;
                        cb_Maloai.Enabled = true;
                        txt_Soluongton.ReadOnly = false;
                        lbl_Soluongmoi.Visible = false;
                        nmSoluongmoi.Visible = false;
                        btn_Them.Enabled = true;
                        btn_LuuVattu.Enabled = false;
                        btn_ThoatChucNang.Enabled = false;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }   
            }
        }

        private void btn_ThoatChucNang_Click(object sender, EventArgs e)
        {
            dafaultValueVattu();
            pnl_ttchung.Enabled = false;
            txt_TenVattu.ReadOnly = false;
            txt_Dvt.ReadOnly = false;
            cb_Maloai.Enabled = true;
            txt_Soluongton.ReadOnly = false;
            lbl_Soluongmoi.Visible = false;
            nmSoluongmoi.Visible = false;
            btn_Them.Enabled = true;
            btn_CapNhat.Enabled = true;
            btn_LuuVattu.Enabled = false;
            btn_ThoatChucNang.Enabled = false;
        }

        private void btn_LuuPhieu_Click(object sender, EventArgs e)
        {
            string mancc = "";
            double tonggiatri = 0;
            try
            {
                if (MessageBox.Show("Xác nhận lưu phiếu nhập", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (cb_NCC.Text == "" || txt_Total.Text == "")
                    {
                        MessageBox.Show("Vui lòng điền đầy đủ thông tin. Không được phép bỏ trống", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        mancc = (cb_NCC.SelectedItem as NhaCungCap).Id;
                        tonggiatri = Convert.ToDouble(txt_Total.Text);
                        PhieuNhapDAO.Instance.Insert_PhieuNhap(mancc, tonggiatri);
                        MessageBox.Show("Đã lưu phiếu nhập hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dafaultValueVattu();
                        txt_Total.Clear();
                        cb_NCC.Text = "";
                        pnl_ttchung.Enabled = false;
                        grb_ttvattu.Enabled = false;
                        btn_TaoPN.Enabled = true;
                        btn_LuuPhieu.Enabled = false;
                        btn_HuyPN.Enabled = false;
                        btn_Them.Enabled = false;
                        btn_CapNhat.Enabled = false;
                        btn_ThoatChucNang.Enabled = false;
                        btn_LuuVattu.Enabled = false;
                        nmSoluongmoi.Visible = false;
                        lbl_Soluongmoi.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + "Vui lòng nhập vào đúng định dạng" + "\r\n" + "Ví dụ: Tổng giá trị bắt buộc phải là số","ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }


        bool check = false;
        private void cb_VatTu_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string loaivt = (cb_VatTu.SelectedItem as VatTu).Maloai;
            string tenVattu = (cb_VatTu.SelectedItem as VatTu).Ten_vattu;
            string dvt = (cb_VatTu.SelectedItem as VatTu).Dvt;
            int soluongton = (cb_VatTu.SelectedItem as VatTu).Soluongton;
            string donGia = (cb_VatTu.SelectedItem as VatTu).Dongiatext;
            if (cb_VatTu.SelectedIndex != -1 && check)
            {
                cb_Maloai.DataSource = VatTuDAO.Instance.LoadLoaiVattu();
                cb_Maloai.DisplayMember = "Maloai";
                cb_Maloai.ValueMember = "Maloai";
                cb_Maloai.Text = loaivt.ToString();
                txt_TenVattu.Text = tenVattu.ToString();
                txt_Dvt.Text = dvt.ToString();
                txt_Soluongton.Text = soluongton.ToString();
                txt_DonGia.Text = donGia.ToString();
                //txt_TenVattu.DataBindings.Add("Text", cb_VatTu.DataSource, "Ten_vattu");
                //txt_Dvt.DataBindings.Add("Text", cb_VatTu.DataSource, "Dvt");
                //txt_Soluongton.DataBindings.Add("Text", cb_VatTu.DataSource, "Soluongton");
                //txt_DonGia.DataBindings.Add("Text", cb_VatTu.DataSource, "Dongiatext");
            }

            check = true;

            //MessageBox.Show(cb_VatTu.SelectedText + "\nIndex: " + cb_VatTu.SelectedIndex);
            
        }

        private void btn_LapBaoCao_Click(object sender, EventArgs e)
        {
            
        }

        private void PhieuNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát", "THÔNG BÁO", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (btn_HuyPN.Enabled == false)
                    MessageBox.Show("Đã thoát");
                else
                    PhieuNhapDAO.Instance.Destroy_PhieuNhap();
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
