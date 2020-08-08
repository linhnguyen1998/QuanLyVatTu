using QuanLyBanSatThep.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanSatThep
{
    public partial class flogin : Form
    {
        public flogin()
        {
            InitializeComponent();
            
        }

        bool Login(string userName, string passWord)
        {
            return AccountDAO.Instance.Login(userName, passWord);
        }


        private void flogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn thoát chương trình","THÔNG BÁO", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        
        public void LoginForm()
        {
            string drop = "drop";
            string del = "delete";
            string userName = txt_User.Text;
            string passWord = txt_Pass.Text;
            if (userName == "")
            {
                
                MessageBox.Show("Tên tài khoản không được trống", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(passWord == "")
            {
                MessageBox.Show("Mật khẩu không được trống", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (Login(userName, passWord))
            {
                if(userName.Contains(drop) != true || userName.Contains(del) != true || passWord.Contains(drop) || passWord.Contains(del))
                {
                    frm_Admin f = new frm_Admin();
                    MessageBox.Show("Đăng nhập thành công", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Hide();
                    f.ShowDialog();
                    this.Show();

                }
                else
                {
                    MessageBox.Show("Đăng nhập không thành công");
                }

            }
            else
            {
                MessageBox.Show("Tài khoản không đúng hoặc sai mật khẩu", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            LoginForm();
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       

        private void flogin_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DangKy dk = new DangKy();
            this.Hide();
            dk.ShowDialog();
            this.Show();
        }

        private void linklb_forgetpass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgetPass fg = new ForgetPass();
            this.Hide();
            fg.ShowDialog();
            this.Show();
        }
    }
}
