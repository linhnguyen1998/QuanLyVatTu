using QuanLyBanSatThep.DAO;
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
    public partial class DangKy : Form
    {
        public DangKy()
        {
            InitializeComponent();
        }


        private void btn_Dangky_Click(object sender, EventArgs e)
        {
            if(txt_taikhoan.Text == "" || txt_mk.Text == "")
            {
                MessageBox.Show("Tên tài khoản mật khẩu không được để trống", "Thông báo");
            }
            else
            {
                if(txt_mk.Text != txt_xacnhanmk.Text)
                {
                    MessageBox.Show("Xác nhận mật khẩu chưa đúng", "Thông báo");
                }
                else
                {
                    string tk = txt_taikhoan.Text;
                    string mk = txt_mk.Text;
                    string ho = txt_Ho.Text;
                    string ten = txt_Ten.Text;
                    string sdt = txt_Sdt.Text;
                    string dc = txt_DC.Text;
                    if(AccountDAO.Instance.CreateAnAccout(tk, mk, ho, ten, sdt, dc))
                    {
                        MessageBox.Show("Tạo tài khoản thành công", "Thông báo");
                    }
                    else
                        MessageBox.Show("Không thể tạo tài khoản. Vui long kiểm tra lại", "Thông báo");
                }
            }
        }

        private void txt_taikhoan_KeyPress(object sender, KeyPressEventArgs e)
        {
            string tk = txt_taikhoan.Text.Trim();
            if (AccountDAO.Instance.KtraTK(tk))
            {
                lbl_Taikhoan.Text = "Tài khoản đã tồn tại";
            }
            else
                lbl_Taikhoan.Text = "Tài khoản hợp lệ";
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
