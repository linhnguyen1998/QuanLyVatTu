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
    public partial class BaoCaoDoanhThu : Form
    {
        public BaoCaoDoanhThu()
        {
            InitializeComponent();
        }

        private void BaoCaoDoanhThu_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QLSatThepDoanhThu.BaoCaoDoanhThu' table. You can move, or remove it, as needed.
            //this.BaoCaoDoanhThuTableAdapter.Fill(this.QLSatThepDoanhThu.BaoCaoDoanhThu);
            //// TODO: This line of code loads data into the 'QLSatThepDoanhThu.TongDoanhThu' table. You can move, or remove it, as needed.
            //this.tongDoanhThuTableAdapter.Fill(this.QLSatThepDoanhThu.TongDoanhThu);
            //// TODO: This line of code loads data into the 'QLSatThepDoanhThu.DoanhThuChart' table. You can move, or remove it, as needed.
            //this.DoanhThuChartTableAdapter.Fill(this.QLSatThepDoanhThu.DoanhThuChart);
            // TODO: This line of code loads data into the 'QLSatThepDoanhThu.BaoCaoDoanhThu' table. You can move, or remove it, as needed.
            //this.BaoCaoDoanhThuTableAdapter.Fill(this.QLSatThepDoanhThu.BaoCaoDoanhThu);
            // TODO: This line of code loads data into the 'QLSatThepDoanhThu.TongDoanhThu' table. You can move, or remove it, as needed.
            //this.tongDoanhThuTableAdapter.Fill(this.QLSatThepDoanhThu.TongDoanhThu);
            // TODO: This line of code loads data into the 'QLSatThepDoanhThu.DoanhThuChart' table. You can move, or remove it, as needed.
            //this.doanhThuChartTableAdapter.Fill(this.QLSatThepDoanhThu.DoanhThuChart);
            // TODO: This line of code loads data into the 'QLSatThepDoanhThu.BaoCaoDoanhThu' table. You can move, or remove it, as needed.
            //this.BaoCaoDoanhThuTableAdapter.Fill(this.QLSatThepDoanhThu.BaoCaoDoanhThu);
            // TODO: This line of code loads data into the 'QLSatThepDoanhThu.BaoCaoDoanhThu' table. You can move, or remove it, as needed.
            //this.BaoCaoDoanhThuTableAdapter.Fill(this.QLSatThepDoanhThu.BaoCaoDoanhThu);
            // TODO: This line of code loads data into the 'QLSatThepDoanhThu.BaoCaoDoanhThu' table. You can move, or remove it, as needed.

            // TODO: This line of code loads data into the 'QLSatThepDoanhThu.BaoCaoDoanhThu' table. You can move, or remove it, as needed.
            //this.BaoCaoDoanhThuTableAdapter.Fill(this.QLSatThepDoanhThu.BaoCaoDoanhThu);
            // TODO: This line of code loads data into the 'QLSatThepDataSet2.BaoCaoDoanhThu' table. You can move, or remove it, as needed.

        }

        private void btn_ThongKeDoanhThu_Click(object sender, EventArgs e)
        {
            if (cb_Chon.SelectedIndex == -1)
                MessageBox.Show("Vui lòng chọn ngày, tháng hoặc năm để xem báo cáo", "Thông báo");
            else
            {
                int ngay = Convert.ToInt32(dt_XuatDoanhThu.Value.Day.ToString());
                int thang = Convert.ToInt32(dt_XuatDoanhThu.Value.Month.ToString());
                int nam = Convert.ToInt32(dt_XuatDoanhThu.Value.Year.ToString());
                if (cb_Chon.SelectedIndex == 0)
                {
                    this.BaoCaoDoanhThuTableAdapter.Fill(this.QLSatThepDoanhThu.BaoCaoDoanhThu, "Ngày", ngay, thang, nam);
                    this.tongDoanhThuTableAdapter.Fill(this.qLSatThepDoanhThu1.TongDoanhThu, "Ngày", ngay, thang, nam);
                }
                else if (cb_Chon.SelectedIndex == 1)
                {
                    this.BaoCaoDoanhThuTableAdapter.Fill(this.QLSatThepDoanhThu.BaoCaoDoanhThu, "Tháng", ngay, thang, nam);
                    this.tongDoanhThuTableAdapter.Fill(this.qLSatThepDoanhThu1.TongDoanhThu, "Tháng", ngay, thang, nam);
                }
                else if (cb_Chon.SelectedIndex == 2)
                {
                    this.BaoCaoDoanhThuTableAdapter.Fill(this.QLSatThepDoanhThu.BaoCaoDoanhThu, "Năm", ngay, thang, nam);
                    this.tongDoanhThuTableAdapter.Fill(this.qLSatThepDoanhThu1.TongDoanhThu, "Năm", ngay, thang, nam);
                }

                this.DoanhThuChartTableAdapter.Fill(this.QLSatThepDoanhThu.DoanhThuChart, nam);
                this.reportViewer1.RefreshReport();
            }
            
            
        }
    }
}
