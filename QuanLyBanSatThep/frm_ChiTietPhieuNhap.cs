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
    public partial class frm_ChiTietPhieuNhap : Form
    {
        public static int id_phieuhd = 0;
        public static int id_phieupn = 0;
        public frm_ChiTietPhieuNhap()
        {
            InitializeComponent();

            LoadChiTiet();
        }
        void LoadChiTiet()
        {
            if(id_phieuhd != 0)
            {
                LoadChiTietHD();
            }
            if(id_phieupn != 0)
            {
                LoadChiTietPN();
            }
        }
        void LoadChiTietHD()
        {
            dgv_ChiTiet.DataSource = DinhMucDAO.Instance.GetDetailOrderByIdPhieu(id_phieuhd);
        }
        void LoadChiTietPN()
        {
            dgv_ChiTiet.DataSource = DinhMucDAO.Instance.GetDetailPhieuNhapByIdPhieu(id_phieupn);
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
