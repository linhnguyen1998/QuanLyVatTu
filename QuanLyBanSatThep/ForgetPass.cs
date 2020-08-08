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
    public partial class ForgetPass : Form
    {
        public ForgetPass()
        {
            InitializeComponent();
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Confrim_Click(object sender, EventArgs e)
        {
            if (txt_taikhoan.Text == "" || txt_mk.Text == "" || txt_xacnhanmk.Text == "" || txt_Sdt.Text == "")
                MessageBox.Show("Muốn lấy lại pass cần phải nhập dữ liệu. Vui lòng kiểm tra lại", "Thông báo");
            else
            {
                string tk = txt_taikhoan.Text;
                string mk = txt_mk.Text;
                string xnmk = txt_xacnhanmk.Text;
                string sdt = txt_Sdt.Text;
                if(mk != xnmk)
                {
                    MessageBox.Show("Vui lòng kiểm tra lại mật khẩu", "Thông báo");
                }
                else
                {
                    if (AccountDAO.Instance.ForgetPass(tk, mk, sdt))
                        MessageBox.Show("Đã đổi mật khẩu thành công", "Thông báo");
                    else
                        MessageBox.Show("Vui lòng kiểm tra lại.", "Thông báo");
                }
            }
        }
    }
}
