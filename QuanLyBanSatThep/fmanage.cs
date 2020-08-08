using QuanLyBanSatThep.DAO;
using QuanLyBanSatThep.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanSatThep
{
    public partial class fmanage : Form
    {
        BindingSource ncclist = new BindingSource();
        BindingSource loaivtlist = new BindingSource();
        BindingSource vattulist = new BindingSource();
        BindingSource hdlist = new BindingSource();
        BindingSource pnlist = new BindingSource();
        BindingSource ttlist = new BindingSource();
        public fmanage()
        {
            InitializeComponent();

            load();

            defaultvalueText();
        }
        void load()
        {
            

            dgv_NCC1.DataSource = ncclist;
            dgv_LoaiVT.DataSource = loaivtlist;
            dgv_Vattu1.DataSource = vattulist;
            dgv_HoaDon1.DataSource = hdlist;
            dgv_PhieuNhap.DataSource = pnlist;
            dgv_TamTinh.DataSource = ttlist;

            LoadLoaiVattu();
            LoadNhaCungCap();
            LoadVatTu();
            LoadPhieuNhap();
            LoadHoaDon();
            LoadTamTinh();

            AddBindingNCC();
            AddBindingLoaiVT();
            AddBindingVatTu();
            AddBindingHoaDon();
            AddBindingPhieuNhap();
            AddBindingTamTinh();

            LoadComboxMaNccInPhieuNhap(cb_TenNCC);
            LoadComboxLoaiVatTuInVaTTu(cb_maloai);

            
        }
        void defaultvalueText()
        {
            //Nhà cung cấp
            txt_mancc.Text = "";
            txt_tenncc.Text = "";
            txt_sdtncc.Text = "";
            txt_email.Text = "";

            //Loại vật tư
            txt_MaLoaivt.Text = "";
            txt_TenLoaivt.Text = "";

            //Vật tư
            txt_IdVattu.Text = "";
            txt_Tenvt.Text = "";
            txt_Dvt.Text = "";
            txt_Dongia.Text = "";
            nm_Soluongton.Text = "0";
            cb_maloai.SelectedIndex = -1;

            //Phiếu nhập
            txt_IdPhieuNhap.Text = "";
            txt_IdPhieuNhapVT.Text = "";
            txt_Tonggiatri.Text = "";
            cb_TenNCC.SelectedIndex = -1;

            //Hóa đơn
            txt_Idphieu.Text = "";
            txt_IdHD.Text = "";
            txt_Tenkh.Text = "";
            txt_sdt_kh.Text = "";
            txt_ThanhTienHD.Text = "";

            //Tạm tính
            txt_IdTamTinh.Text = "";
            txt_IdPhieuTT.Text = "";
            txt_TenkhTT.Text = "";
            txt_SdtKhTT.Text = "";
            txt_TongTienTT.Text = "";

        }
        #region Method
        //Nhà cung cấp------------------------------
        void LoadNhaCungCap()
        {         
            ncclist.DataSource = NhaCungCapDAO.Instance.LoadNhaCCList();       
        }
        void AddBindingNCC()
        {
            txt_mancc.DataBindings.Add(new Binding("Text", dgv_NCC1.DataSource, "Id", true, DataSourceUpdateMode.Never));
            txt_tenncc.DataBindings.Add(new Binding("Text", dgv_NCC1.DataSource, "Name", true, DataSourceUpdateMode.Never));
            txt_sdtncc.DataBindings.Add(new Binding("Text", dgv_NCC1.DataSource, "Sdt_ncc", true, DataSourceUpdateMode.Never));
            txt_email.DataBindings.Add(new Binding("Text", dgv_NCC1.DataSource, "Email", true, DataSourceUpdateMode.Never));
        }

        //Loại vật tư-------------------------------
        void LoadLoaiVattu()
        {
            loaivtlist.DataSource = VatTuDAO.Instance.LoadLoaiVattu();
        }
        void AddBindingLoaiVT()
        {
            txt_MaLoaivt.DataBindings.Add(new Binding("Text", dgv_LoaiVT.DataSource, "Maloai", true, DataSourceUpdateMode.Never));
            txt_TenLoaivt.DataBindings.Add(new Binding("Text", dgv_LoaiVT.DataSource, "Tenloai", true, DataSourceUpdateMode.Never));
        }

        //Vật tư-------------------------------------
        void LoadVatTu()
        {
               vattulist.DataSource = VatTuDAO.Instance.LoadListVatTu();
            
        }
        void AddBindingVatTu()
        {
            txt_IdVattu.DataBindings.Add(new Binding("Text", dgv_Vattu1.DataSource, "Id_vattu", true, DataSourceUpdateMode.Never));
            txt_Tenvt.DataBindings.Add(new Binding("Text", dgv_Vattu1.DataSource, "Ten_vattu", true, DataSourceUpdateMode.Never));
            txt_Dvt.DataBindings.Add(new Binding("Text", dgv_Vattu1.DataSource, "Dvt", true, DataSourceUpdateMode.Never));
            nm_Soluongton.DataBindings.Add(new Binding("Value", dgv_Vattu1.DataSource, "Soluongton", true, DataSourceUpdateMode.Never));
            txt_Dongia.DataBindings.Add(new Binding("Text", dgv_Vattu1.DataSource, "Dongiatext", true, DataSourceUpdateMode.Never));
        }
        void LoadComboxLoaiVatTuInVaTTu(ComboBox cb)
        {
            cb.DataSource = VatTuDAO.Instance.LoadLoaiVattu();
            cb.DisplayMember = "Maloai";
            cb.ValueMember = "Maloai";
        }

        //Phiếu nhập----------------------------------
        void LoadPhieuNhap()
        {
            pnlist.DataSource = PhieuNhapDAO.Instance.PagesPhieuNhap(LastPagesPN());
        }
        void AddBindingPhieuNhap()
        {
            txt_IdPhieuNhapVT.DataBindings.Add(new Binding("Text", dgv_PhieuNhap.DataSource, "Id_pn", true, DataSourceUpdateMode.Never));
            txt_IdPhieuNhap.DataBindings.Add(new Binding("Text", dgv_PhieuNhap.DataSource, "Id_phieu", true, DataSourceUpdateMode.Never));
            dt_NgayNhapHang.DataBindings.Add(new Binding("Value", dgv_PhieuNhap.DataSource, "Date", true, DataSourceUpdateMode.Never));
            txt_Tonggiatri.DataBindings.Add(new Binding("Text", dgv_PhieuNhap.DataSource, "Tonggiatri", true, DataSourceUpdateMode.Never));
        }
        void LoadComboxMaNccInPhieuNhap(ComboBox cb)
        {
            cb.DataSource = NhaCungCapDAO.Instance.LoadNhaCCList();
            cb.DisplayMember = "Name";
            cb.ValueMember = "Id";
        }
        //Hóa đơn
        void LoadHoaDon()
        {
            hdlist.DataSource = HoaDonDAO.Instance.PagesHoaDon(LastPages());
        }
        void AddBindingHoaDon()
        {
            txt_IdHD.DataBindings.Add(new Binding("Text", dgv_HoaDon1.DataSource, "Id_hd", true, DataSourceUpdateMode.Never));
            txt_Idphieu.DataBindings.Add(new Binding("Text", dgv_HoaDon1.DataSource, "Id_phieu", true, DataSourceUpdateMode.Never));
            txt_Tenkh.DataBindings.Add(new Binding("Text", dgv_HoaDon1.DataSource, "Tenkh", true, DataSourceUpdateMode.Never));
            txt_sdt_kh.DataBindings.Add(new Binding("Text", dgv_HoaDon1.DataSource, "Sdt_kh", true, DataSourceUpdateMode.Never));
            dt_NgayXuatHD.DataBindings.Add(new Binding("Value", dgv_HoaDon1.DataSource, "Date", true, DataSourceUpdateMode.Never));
            txt_ThanhTienHD.DataBindings.Add(new Binding("Text", dgv_HoaDon1.DataSource, "Thanhtien", true, DataSourceUpdateMode.Never));
        }
        //Tạm tính
        void LoadTamTinh()
        {
            ttlist.DataSource = TamTinhDAO.Instance.loadTamTinh();
        }
        void AddBindingTamTinh()
        {
            txt_IdTamTinh.DataBindings.Add(new Binding("Text", dgv_TamTinh.DataSource, "Id_tt", true, DataSourceUpdateMode.Never));
            txt_IdPhieuTT.DataBindings.Add(new Binding("Text", dgv_TamTinh.DataSource, "Id_phieu", true, DataSourceUpdateMode.Never));
            txt_TenkhTT.DataBindings.Add(new Binding("Text", dgv_TamTinh.DataSource, "Tenkh", true, DataSourceUpdateMode.Never));
            txt_SdtKhTT.DataBindings.Add(new Binding("Text", dgv_TamTinh.DataSource, "Sdt_kh", true, DataSourceUpdateMode.Never));
            dt_NgayXuatTT.DataBindings.Add(new Binding("Value", dgv_TamTinh.DataSource, "Date", true, DataSourceUpdateMode.Never));
            txt_TongTienTT.DataBindings.Add(new Binding("Text", dgv_TamTinh.DataSource, "Thanhtien", true, DataSourceUpdateMode.Never));
        }
        #endregion

        #region Events
        #endregion

        public int LastPages()
        {
            int dem = HoaDonDAO.Instance.CountRowHoaDon();
            int currentPages = dem / 11;
            if (dem % 11 != 0)
                currentPages++;
            return currentPages;
        }
        public int LastPagesPN()
        {
            int dem = PhieuNhapDAO.Instance.CountRowPN();
            int currentPages = dem / 11;
            if (dem % 11 != 0)
                currentPages++;
            return currentPages;
        }
        private void fmanage_Load(object sender, EventArgs e)
        {
            defaultvalueText();
           
            btn_LuuNCC.Enabled = false;
            btn_ThoatcnNCC.Enabled = false;

            btn_LuuLoaivt.Enabled = false;
            btn_ThoatcnLoaivt.Enabled = false;

            btn_LuuVattu.Enabled = false;
            btn_ThoatcnVattu.Enabled = false;

            //Trang Hóa đơn
            txt_pages.Text = LastPages().ToString();
            if (txt_pages.Text == LastPages().ToString())
            {
                btn_next.Enabled = false;
                btn_Last.Enabled = false;
            }
            //Trang Phiếu nhập
            txt_pagesPN.Text = LastPagesPN().ToString();
            
        }
        
        private void tab_NCC_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void dgv_Vattu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_NCC1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void txt_mancc_TextChanged(object sender, EventArgs e)
        {

        }
        //Event Nhà cung cấp
        private void btn_ThemNCC_Click(object sender, EventArgs e)
        {
            txt_mancc.ReadOnly = false;
            btn_SuaNCC.Enabled = false;
            btn_XoaNCC.Enabled = false;
            btn_LuuNCC.Enabled = true;
            btn_ThoatcnNCC.Enabled = true;
            defaultvalueText();
        }

        private void btn_SuaNCC_Click(object sender, EventArgs e)
        {
            btn_ThemNCC.Enabled = false;
            btn_XoaNCC.Enabled = false;
            btn_LuuNCC.Enabled = true;
            btn_ThoatcnNCC.Enabled = true;

        }
        string mncc;
        private void btn_XoaNCC_Click(object sender, EventArgs e)
        {
            mncc = txt_mancc.Text.Trim();
            try
            {
                if (mncc != "")
                {
                    if (MessageBox.Show("Bạn có muốn xóa bản ghi này không???", "Lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        NhaCungCapDAO.Instance.DeleteNcc(mncc);
                        MessageBox.Show("Xóa thành công", "Thông báo");
                        LoadNhaCungCap();
                    }
                }
                else
                    MessageBox.Show("Vui lòng chọn nhà cung cấp");
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Không thể xóa bản ghi này. Vì có thể bảng khác đang sử dụng???", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        string mancc = "";
        string tenncc = "";
        string sdt = "";
        string email = "";
        private void btn_LuuNCC_Click(object sender, EventArgs e)
        {

            mancc = txt_mancc.Text.Trim();
            tenncc = txt_tenncc.Text.Trim();
            sdt = txt_sdtncc.Text.Trim();
            email = txt_email.Text.Trim();
            if (btn_ThemNCC.Enabled)
            {

                try
                {
                    if (mancc != "" && tenncc != "" && sdt != "" && email != "")
                    {
                        if (NhaCungCapDAO.Instance.InsertNcc(mancc, tenncc, sdt, email))
                        {
                            MessageBox.Show("Thêm nhà cung cấp thành công", "Thông báo");
                            LoadNhaCungCap();
                            txt_mancc.ReadOnly = true;
                            btn_SuaNCC.Enabled = true;
                            btn_XoaNCC.Enabled = true;
                            btn_LuuNCC.Enabled = false;
                            btn_ThoatcnNCC.Enabled = false;

                        }
                        else
                        {
                            MessageBox.Show("Có lỗi xảy ra khi thêm", "Thông báo");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Dữ liệu nhập có thể bị trống!!! Xin mời nhập lại");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Mã nhà cung cấp có thể đang bị trùng!!! Mời nhập lại" + "\r\n" + "- Lỗi:" + "\r\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                
                
                               
            }
            else if(btn_SuaNCC.Enabled)
            {
                try
                {
                    if (tenncc != "" && sdt != "" && email != "")
                    {
                        if (NhaCungCapDAO.Instance.UpdateNcc(mancc, tenncc, sdt, email))
                        {
                            MessageBox.Show("Cập nhật nhà cung cấp thành công", "Thông báo");
                            LoadNhaCungCap();
                            btn_ThemNCC.Enabled = true;
                            btn_XoaNCC.Enabled = true;
                            btn_LuuNCC.Enabled = false;
                            btn_ThoatcnNCC.Enabled = false;

                        }
                        else
                        {
                            MessageBox.Show("Có lỗi xảy ra khi cập nhật", "Thông báo");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Dữ liệu nhập có thể bị trống!!! Xin mời nhập lại");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Mã nhà cung cấp có thể đang bị trùng!!! Mời nhập lại" + "\r\n" + "- Lỗi:" + "\r\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            
        }

        private void btn_ThoatcnNCC_Click(object sender, EventArgs e)
        {
            if (btn_ThemNCC.Enabled)
            {
                txt_mancc.ReadOnly = true;
                btn_SuaNCC.Enabled = true;
                btn_XoaNCC.Enabled = true;
                btn_LuuNCC.Enabled = false;
                btn_ThoatcnNCC.Enabled = false;
            }
            else if (btn_SuaNCC.Enabled)
            {
                btn_ThemNCC.Enabled = true;
                btn_XoaNCC.Enabled = true;
                btn_LuuNCC.Enabled = false;
                btn_ThoatcnNCC.Enabled = false;
            }
        }

        //Event Loại vật tư
        private void btn_ThemLoaivt_Click(object sender, EventArgs e)
        {
            btn_LuuLoaivt.Enabled = true;
            btn_ThoatcnLoaivt.Enabled = true;
            btn_SuaLoaivt.Enabled = false;
            btn_XoaLoaivt.Enabled = false;
            txt_MaLoaivt.ReadOnly = false;
            txt_TenLoaivt.Clear();
            txt_MaLoaivt.Clear();
        }

        private void btn_SuaLoaivt_Click(object sender, EventArgs e)
        {
            btn_LuuLoaivt.Enabled = true;
            btn_ThoatcnLoaivt.Enabled = true;
            btn_ThemLoaivt.Enabled = false;
            btn_XoaLoaivt.Enabled = false;
        }
        string mal = "";
        string tloai = "";
        private void btn_XoaLoaivt_Click(object sender, EventArgs e)
        {
            string mal = txt_MaLoaivt.Text.Trim();
            try
            {
                if(mal != "")
                {
                    if (MessageBox.Show("Bạn có muốn xóa???", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        VatTuDAO.Instance.DeleteLoaiVT(mal);
                        LoadLoaiVattu();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn loại vật tư", "Thông báo");
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Không thể xóa bản ghi này. Vì có thể bảng khác đang sử dụng???", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btn_LuuLoaivt_Click(object sender, EventArgs e)
        {
            mal = txt_MaLoaivt.Text.Trim();
            tloai = txt_TenLoaivt.Text.Trim();
            if(btn_ThemLoaivt.Enabled)
            {
                try
                {
                    if (mal != "" && tloai != "")
                    {
                        if (VatTuDAO.Instance.InsertLoaiVT(mal, tloai))
                        {
                            MessageBox.Show("Thêm thành công", "Thông báo");
                            LoadLoaiVattu();
                            btn_LuuLoaivt.Enabled = false;
                            btn_ThoatcnLoaivt.Enabled = false;
                            btn_SuaLoaivt.Enabled = true;
                            btn_XoaLoaivt.Enabled = true;
                            txt_MaLoaivt.ReadOnly = true;
                        }
                        else
                        {
                            MessageBox.Show("Đã xảy lỗi khi thêm", "Thông báo");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Dữ liệu nhập vào không được trống", "Thông báo");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Mã loại đã tồn tại!!! Vui lòng thử lại" + "\r\n" + "- Lỗi:" + "\r\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            else if(btn_SuaLoaivt.Enabled)
            {
                try
                {
                    if (mal != "" && tloai != "")
                    {
                        if (VatTuDAO.Instance.UpdateLoaiVT(mal, tloai))
                        {
                            MessageBox.Show("Cập nhật thành công", "Thông báo");
                            LoadLoaiVattu();
                            btn_LuuLoaivt.Enabled = false;
                            btn_ThoatcnLoaivt.Enabled = false;
                            btn_ThemLoaivt.Enabled = true;
                            btn_XoaLoaivt.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Đã xảy lỗi khi cập nhật", "Thông báo");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Dữ liệu nhập vào không được trống", "Thông báo");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Vui lòng thử lại" + "\r\n" + "- Lỗi:" + "\r\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btn_ThoatcnLoaivt_Click(object sender, EventArgs e)
        {
            if (btn_ThemLoaivt.Enabled)
            {
                btn_LuuLoaivt.Enabled = false;
                btn_ThoatcnLoaivt.Enabled = false;
                btn_SuaLoaivt.Enabled = true;
                btn_XoaLoaivt.Enabled = true;
                txt_MaLoaivt.ReadOnly = true;
            }
            else if (btn_SuaLoaivt.Enabled)
            {
                btn_LuuLoaivt.Enabled = false;
                btn_ThoatcnLoaivt.Enabled = false;
                btn_ThemLoaivt.Enabled = true;
                btn_XoaLoaivt.Enabled = true;
            }
        }

        //Event Vật tư
        private void txt_IdVattu_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgv_Vattu1.SelectedCells.Count > 0)
                {
                    string ml = (dgv_Vattu1.SelectedCells[0].OwningRow.Cells["Maloai"].Value).ToString().Trim();
                    LoaiVatTu lvt = VatTuDAO.Instance.GetIDLoaiVattu(ml);
                    cb_maloai.SelectedItem = lvt;
                    int index = -1;
                    int i = 0;
                    foreach (LoaiVatTu item in cb_maloai.Items)
                    {
                        if (item.Maloai == lvt.Maloai)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }
                    cb_maloai.SelectedIndex = index;
                }
            }
            catch { }
            
        }

        private void btn_ThemVattu_Click(object sender, EventArgs e)
        {
            btn_XoaVattu.Enabled = false;
            btn_SuaVattu.Enabled = false;
            btn_LuuVattu.Enabled = true;
            btn_ThoatcnVattu.Enabled = true;
            txt_IdVattu.Clear();
            txt_Tenvt.Clear();
            txt_Dvt.Clear();
            nm_Soluongton.Value = 0;
            txt_Dongia.Clear();
            cb_maloai.SelectedIndex = -1;
        }

        private void btn_SuaVattu_Click(object sender, EventArgs e)
        {
            btn_XoaVattu.Enabled = false;
            btn_ThemVattu.Enabled = false;
            btn_LuuVattu.Enabled = true;
            btn_ThoatcnVattu.Enabled = true;
        }

        private void btn_LuuVattu_Click(object sender, EventArgs e)
        {
            string ml = "";
            string tenvt = "";
            string dvt = "";
            string dongia = "";
            int soluong = 0;
            if(btn_ThemVattu.Enabled)
            {
                try
                {
                    ml = (cb_maloai.SelectedItem as LoaiVatTu).Maloai;
                    tenvt = txt_Tenvt.Text.Trim();
                    dvt = txt_Dvt.Text.Trim();
                    dongia = txt_Dongia.Text.Trim();
                    soluong = (int)nm_Soluongton.Value;
                    if (ml != "" && tenvt != "" && dvt != "" && dongia != "" && soluong != 0)
                    {
                        if (VatTuDAO.Instance.InsertVatTu(ml, tenvt, dvt, Convert.ToDouble(dongia), soluong))
                        {
                            MessageBox.Show("Thêm thành công", "Thông báo");
                            LoadVatTu();
                            defaultvalueText();
                            btn_XoaVattu.Enabled = true;
                            btn_SuaVattu.Enabled = true;
                            btn_LuuVattu.Enabled = false;
                            btn_ThoatcnVattu.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("Đã có lỗi xảy ra khi thêm", "Thông báo");
                        }
                    }
                    else
                            MessageBox.Show("Dữ liệu nhập vào không được trống", "Thông báo");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if(btn_SuaVattu.Enabled)
            {
                
                try
                {
                    int id = Convert.ToInt32(txt_IdVattu.Text);
                    ml = (cb_maloai.SelectedItem as LoaiVatTu).Maloai;
                    tenvt = txt_Tenvt.Text.Trim();
                    dvt = txt_Dvt.Text.Trim();
                    dongia = txt_Dongia.Text.Trim();
                    soluong = (int)nm_Soluongton.Value;
                    if (ml != "" && tenvt != "" && dvt != "" && dongia != "" && soluong != 0)
                    {
                        if (VatTuDAO.Instance.UpdateVatTu(id, ml, tenvt, dvt, Convert.ToDouble(dongia), soluong))
                        {
                            MessageBox.Show("Cập nhật thành công", "Thông báo");
                            LoadVatTu();
                            defaultvalueText();
                            btn_XoaVattu.Enabled = true;
                            btn_ThemVattu.Enabled = true;
                            btn_LuuVattu.Enabled = false;
                            btn_ThoatcnVattu.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("Đã có lỗi xảy ra khi cập nhật", "Thông báo");
                        }
                    }
                    else
                        MessageBox.Show("Dữ liệu nhập vào không được trống", "Thông báo");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }

        private void btn_ThoatcnVattu_Click(object sender, EventArgs e)
        {
            if (btn_ThemVattu.Enabled)
            {
                defaultvalueText();
                btn_XoaVattu.Enabled = true;
                btn_SuaVattu.Enabled = true;
                btn_LuuVattu.Enabled = false;
                btn_ThoatcnVattu.Enabled = false;
            }
            else if (btn_SuaVattu.Enabled)
            {
                btn_XoaVattu.Enabled = true;
                btn_ThemVattu.Enabled = true;
                btn_LuuVattu.Enabled = false;
                btn_ThoatcnVattu.Enabled = false;
            }
        }
        string id_vt = "";
        private void btn_XoaVattu_Click(object sender, EventArgs e)
        {
            id_vt = txt_IdVattu.Text.Trim();
            try
            {
                if(id_vt != "")
                {
                    if (MessageBox.Show("Bạn có muốn xóa bản ghi này không???", "Lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        VatTuDAO.Instance.DeleteVatTu(Convert.ToInt32(id_vt));
                        MessageBox.Show("Xóa thành công", "Thông báo");
                        LoadVatTu();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn vật tư", "Thông báo");
                }
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể xóa bản ghi này. Vì có thể bảng khác đang sử dụng???", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Event Hóa đơn
        int id_phieufrm_Xemct = 0;
        private void btn_XemCTHD_Click(object sender, EventArgs e)
        {
            try
            {
                id_phieufrm_Xemct = Convert.ToInt32(txt_Idphieu.Text.Trim());
                if (id_phieufrm_Xemct == 0)
                {
                    MessageBox.Show("Bạn chưa chọn hóa đơn cần xem", "Thông báo");
                }
                else
                {
                    frm_ChiTietPhieuNhap.id_phieuhd = id_phieufrm_Xemct;
                    frm_ChiTietPhieuNhap.id_phieupn = 0;
                    frm_ChiTietPhieuNhap ct = new frm_ChiTietPhieuNhap();
                    ct.ShowDialog();
                }
            }
            catch { }
        }
        string tenkh_hd = "";
        string sdtkh_hd = "";
        string tongtien_hd = "";
        private void btn_SuaHD_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txt_IdHD.Text.Trim());
            int idphieu = Convert.ToInt32(txt_Idphieu.Text.Trim());
            tenkh_hd = txt_Tenkh.Text.Trim();
            sdtkh_hd = txt_sdt_kh.Text.Trim();
            tongtien_hd = txt_ThanhTienHD.Text.Trim();
            if(tenkh_hd != "" && sdtkh_hd != "" && tongtien_hd != "")
            {
                if(HoaDonDAO.Instance.Update_HD(id, tenkh_hd, sdtkh_hd, dt_NgayXuatHD.Value, Convert.ToDouble(tongtien_hd)))
                {
                    MessageBox.Show("Cập nhật thành công", "Thông báo");
                    LoadHoaDon();
                }
                
            }
            else
            {
                MessageBox.Show("Dữ liệu nhập vào không được để trống", "Thông báo");
            }
        }
        int id_hd = 0;
        int id_phieu_hd = 0;
        private void btn_XoaHD_Click(object sender, EventArgs e)
        {
            id_hd = Convert.ToInt32(txt_IdHD.Text.Trim());
            id_phieu_hd = Convert.ToInt32(txt_Idphieu.Text.Trim());
            if (id_hd != 0 && id_phieu_hd != 0)
            {

                if (MessageBox.Show("Bạn có muốn xóa bản ghi này", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    HoaDonDAO.Instance.Delete_HD(id_hd, id_phieu_hd);
                    MessageBox.Show("Xóa thành công", "Thông báo");
                    txt_pages.Text = LastPages().ToString();
                    LoadHoaDon();
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn hóa đơn nào", "Thông báo");
            }
            
        }
        //Event Phiếu nhập
        private void txt_IdPhieuNhapVT_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgv_PhieuNhap.SelectedCells.Count > 0)
                {
                    string mancc = (dgv_PhieuNhap.SelectedCells[0].OwningRow.Cells["Mancc"].Value).ToString().Trim();
                    NhaCungCap lvt = NhaCungCapDAO.Instance.GetIDNhaCC(mancc);
                    cb_TenNCC.SelectedItem = lvt;
                    int index = -1;
                    int i = 0;
                    foreach (NhaCungCap item in cb_TenNCC.Items)
                    {
                        if (item.Id == lvt.Id)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }
                    cb_TenNCC.SelectedIndex = index;
                }
            }
            catch
            {

            }
            
        }

        private void btn_XemCTPN_Click(object sender, EventArgs e)
        {
            try
            {
                id_phieufrm_Xemct = Convert.ToInt32(txt_IdPhieuNhap.Text.Trim());
                if (id_phieufrm_Xemct == 0)
                {
                    MessageBox.Show("Bạn chưa chọn hóa đơn cần xem", "Thông báo");
                }
                else
                {
                    frm_ChiTietPhieuNhap.id_phieupn = id_phieufrm_Xemct;
                    frm_ChiTietPhieuNhap.id_phieuhd = 0;
                    frm_ChiTietPhieuNhap ct = new frm_ChiTietPhieuNhap();
                    ct.ShowDialog();
                }
            }
            catch
            { }
            
        }
        string tonggiatri = "";
        private void btn_SuaPN_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txt_IdPhieuNhapVT.Text);
            int idphieu = Convert.ToInt32(txt_IdPhieuNhap.Text);
            string mncc = (cb_TenNCC.SelectedItem as NhaCungCap).Id;
            DateTime ngaynhap = dt_NgayNhapHang.Value;
            tonggiatri = txt_Tonggiatri.Text;
            if (cb_TenNCC.SelectedIndex != -1 && tonggiatri != "")
            {
                if (PhieuNhapDAO.Instance.Update_PN(id, mncc, ngaynhap, Convert.ToDouble(tonggiatri)))
                {
                    MessageBox.Show("Cập nhật thành công", "Thông báo");
                    LoadPhieuNhap();
                }

            }
            else
            {
                MessageBox.Show("Dữ liệu nhập vào không được để trống", "Thông báo");
            }
        }

        int id_pn = 0;
        int id_phieu_pn = 0;
        private void btn_XoaPN_Click(object sender, EventArgs e)
        {
            id_pn = Convert.ToInt32(txt_IdPhieuNhapVT.Text.Trim());
            id_phieu_pn = Convert.ToInt32(txt_IdPhieuNhap.Text.Trim());
            if (id_pn != 0 && id_phieu_pn != 0)
            {

                if (MessageBox.Show("Bạn có muốn xóa bản ghi này", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    PhieuNhapDAO.Instance.Delete_PN(id_pn, id_phieu_pn);
                    MessageBox.Show("Xóa thành công", "Thông báo");
                    txt_pagesPN.Text = LastPagesPN().ToString();
                    LoadPhieuNhap();
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn hóa đơn nào", "Thông báo");
            }
        }
        string tenkh_tt = "";
        string sdtkh_tt = "";
        string tongtien_tt = "";
        private void txt_SuaTT_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txt_IdTamTinh.Text.Trim());
            int idphieu = Convert.ToInt32(txt_IdPhieuTT.Text.Trim());
            tenkh_tt = txt_TenkhTT.Text.Trim();
            sdtkh_tt = txt_SdtKhTT.Text.Trim();
            tongtien_tt = txt_TongTienTT.Text.Trim();
            if (tenkh_tt != "" && sdtkh_tt != "" && tongtien_tt != "")
            {
                if (TamTinhDAO.Instance.Update_TT(id, tenkh_tt, sdtkh_tt, dt_NgayXuatTT.Value, Convert.ToDouble(tongtien_tt)))
                {
                    MessageBox.Show("Cập nhật thành công", "Thông báo");
                    LoadTamTinh();
                }

            }
            else
            {
                MessageBox.Show("Dữ liệu nhập vào không được để trống", "Thông báo");
            }
        }
        int id_tt = 0;
        int id_phieu_tt = 0;

        private void txt_XoaTT_Click(object sender, EventArgs e)
        {
            try
            {
                id_tt = Convert.ToInt32(txt_IdTamTinh.Text.Trim());
                id_phieu_tt = Convert.ToInt32(txt_IdPhieuTT.Text.Trim());
                if (id_tt != 0 && id_phieu_tt != 0)
                {

                    if (MessageBox.Show("Bạn có muốn xóa bản ghi này", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        TamTinhDAO.Instance.Delete_TT(id_tt, id_phieu_tt);
                        MessageBox.Show("Xóa thành công", "Thông báo");
                        LoadTamTinh();
                    }
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn hóa đơn nào", "Thông báo");
                }
            }
            catch
            {
                MessageBox.Show("Không có phiếu tạm tính nào để xóa");
            }
            
        }

        private void btn_XemChiTietTT_Click(object sender, EventArgs e)
        {
            try
            {
                int id_phieufrm_Xemct = Convert.ToInt32(txt_IdPhieuTT.Text.Trim());
                if (id_phieufrm_Xemct == 0)
                {
                    MessageBox.Show("Bạn chưa chọn hóa đơn cần xem", "Thông báo");
                }
                else
                {
                    frm_ChiTietPhieuNhap.id_phieuhd = id_phieufrm_Xemct;
                    frm_ChiTietPhieuNhap.id_phieupn = 0;
                    frm_ChiTietPhieuNhap ct = new frm_ChiTietPhieuNhap();
                    ct.ShowDialog();
                }
            }
            catch
            {
                MessageBox.Show("Không có phiếu tạm tính nào để xem");
            }
            
        }

        private void btn_ThanhToanTT_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txt_IdTamTinh.Text.Trim());
                int id_phieu = Convert.ToInt32(txt_IdPhieuTT.Text.Trim());
                if (MessageBox.Show("Xác nhận thanh toán???", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (TamTinhDAO.Instance.ThanhToanTT(id, id_phieu))
                    {
                        MessageBox.Show("Thanh toán thành công");
                        LoadHoaDon();
                        LoadTamTinh();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi thanh toán");
                    }
                }
            }
            catch {
                MessageBox.Show("Không có tạm tính nào để thanh toán");
            }
        }

        private void btn_XuatBaoCaoVT_Click(object sender, EventArgs e)
        {
            XuatVatTu vt = new XuatVatTu();
            vt.ShowDialog();
        }

        private void btn_FindNCC_Click(object sender, EventArgs e)
        {
            
        }

        private void txt_FindNCC_KeyPress(object sender, KeyPressEventArgs e)
        {
            string ncc = txt_FindNCC.Text.Trim();
            ncclist.DataSource = NhaCungCapDAO.Instance.SearchNCC(ncc);
        }

        private void btn_FindPhieuNhap_Click(object sender, EventArgs e)
        {
            LoadPhieuNhap();
        }

        private void dt_FindPhieuNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            DateTime pn = dt_FindPhieuNhap.Value;
            pnlist.DataSource = PhieuNhapDAO.Instance.SearchPhieuNhap(pn);
        }

        private void txt_FindLoaiVT_KeyPress(object sender, KeyPressEventArgs e)
        {
            string tenl = txt_FindLoaiVT.Text.Trim();
            loaivtlist.DataSource = VatTuDAO.Instance.SearchLoaiVattu(tenl);
        }

        private void txt_FindVatTu_KeyPress(object sender, KeyPressEventArgs e)
        {
            string tenvt = txt_FindVatTu.Text.Trim();
            vattulist.DataSource = VatTuDAO.Instance.SearchVatTu(tenvt);
        }

        private void txt_FindHD_KeyPress(object sender, KeyPressEventArgs e)
        {
            string sdt = txt_FindHD.Text.Trim();
            hdlist.DataSource = HoaDonDAO.Instance.SearchHoaDon(sdt);
        }

        private void txt_FindTamTinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                string sdt = txt_FindTamTinh.Text.Trim();
                ttlist.DataSource = TamTinhDAO.Instance.SearchTamTinh(sdt);
            }
            catch { }
        }

        private void btn_previous_Click(object sender, EventArgs e)
        {
            try
            {
                int prev = Convert.ToInt32(txt_pages.Text) - 1;
                if (prev == 1)
                {
                    btn_First.Enabled = false;
                    btn_previous.Enabled = false;
                }
                if (prev < LastPages())
                {
                    btn_Last.Enabled = true;
                    btn_next.Enabled = true;
                    txt_pages.Text = prev.ToString();
                }
                if (prev == 0)
                {
                    btn_First.Enabled = false;
                    btn_previous.Enabled = false;
                    txt_pages.Text = (prev + 1).ToString();
                }

                hdlist.DataSource = HoaDonDAO.Instance.PagesHoaDon(prev);
            }
            catch
            {

            }
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            int next = Convert.ToInt32(txt_pages.Text) + 1;
            if (next == LastPages())
            {
                btn_next.Enabled = false;
                btn_Last.Enabled = false;
            }
            if (next > LastPages())
            {
                btn_previous.Enabled = true;
                btn_First.Enabled = true;
                btn_next.Enabled = false;
                btn_Last.Enabled = false;
                txt_pages.Text = (next - 1).ToString();
                hdlist.DataSource = HoaDonDAO.Instance.PagesHoaDon(next - 1);
            }
            else if (next <= LastPages())
            {
                btn_previous.Enabled = true;
                btn_First.Enabled = true;
                txt_pages.Text = next.ToString();
                hdlist.DataSource = HoaDonDAO.Instance.PagesHoaDon(next);
            }
        }

        private void btn_First_Click(object sender, EventArgs e)
        {
            int first = 1;
            txt_pages.Text = first.ToString();
            hdlist.DataSource = HoaDonDAO.Instance.PagesHoaDon(first);
            btn_First.Enabled = false;
            btn_previous.Enabled = false;
            btn_Last.Enabled = true;
            btn_next.Enabled = true;


        }

        private void btn_Last_Click(object sender, EventArgs e)
        {
            hdlist.DataSource = HoaDonDAO.Instance.PagesHoaDon(LastPages());
            txt_pages.Text = LastPages().ToString();
            btn_next.Enabled = false;
            btn_Last.Enabled = false;

            btn_previous.Enabled = true;
            btn_First.Enabled = true;
            
        }

        private void btn_previousPN_Click(object sender, EventArgs e)
        {
            try
            {
                int prev = Convert.ToInt32(txt_pagesPN.Text) - 1;
                if (prev == 1)
                {
                    btn_FirstPN.Enabled = false;
                    btn_previousPN.Enabled = false;
                }
                if (prev < LastPagesPN())
                {
                    btn_LastPN.Enabled = true;
                    btn_nextPN.Enabled = true;
                    txt_pagesPN.Text = prev.ToString();
                }
                if(prev == 0)
                {
                    btn_FirstPN.Enabled = false;
                    btn_previousPN.Enabled = false;
                    txt_pagesPN.Text = (prev+1).ToString();
                }
                
                pnlist.DataSource = PhieuNhapDAO.Instance.PagesPhieuNhap(prev);
            }
            catch
            {

            }
            
        }

        private void btn_FirstPN_Click(object sender, EventArgs e)
        {
            try
            {
                int first = 1;
                txt_pagesPN.Text = first.ToString();
                pnlist.DataSource = PhieuNhapDAO.Instance.PagesPhieuNhap(first);
                btn_FirstPN.Enabled = false;
                btn_previousPN.Enabled = false;
                btn_LastPN.Enabled = true;
                btn_nextPN.Enabled = true;
            }
            catch
            {

            }
            
        }

        private void btn_nextPN_Click(object sender, EventArgs e)
        {
            int next = Convert.ToInt32(txt_pagesPN.Text) + 1;
            if (next == LastPagesPN())
            {
                btn_nextPN.Enabled = false;
                btn_LastPN.Enabled = false;
            }
            if(next > LastPagesPN())
            {
                btn_previousPN.Enabled = true;
                btn_FirstPN.Enabled = true;
                btn_nextPN.Enabled = false;
                btn_LastPN.Enabled = false;
                txt_pagesPN.Text = (next - 1).ToString();
                pnlist.DataSource = PhieuNhapDAO.Instance.PagesPhieuNhap(next -1);
            }
            else if (next <= LastPagesPN())
            {
                btn_previousPN.Enabled = true;
                btn_FirstPN.Enabled = true;
                txt_pagesPN.Text = next.ToString();
                pnlist.DataSource = PhieuNhapDAO.Instance.PagesPhieuNhap(next);
            }
                    
            
        }

        private void btn_LastPN_Click(object sender, EventArgs e)
        {
            pnlist.DataSource = PhieuNhapDAO.Instance.PagesPhieuNhap(LastPagesPN());
            txt_pagesPN.Text = LastPagesPN().ToString();
            btn_nextPN.Enabled = false;
            btn_LastPN.Enabled = false;

            btn_previousPN.Enabled = true;
            btn_FirstPN.Enabled = true;

        }

        private void dt_XuatDoanhThu_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
