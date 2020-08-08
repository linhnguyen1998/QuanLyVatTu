using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanSatThep.DTO
{
    public class DinhMuc
    {
        private int id_dm;
        private int id_phieu;
        private int id_vattu;
        private string ten_vattu;
        private string dvt;
        private double dongia;
        private int soluong;
        private double thanhtien;
        //private ImageList thaotac ;
        


        public DinhMuc(int id_dm, int id_phieu, int id_vattu, string tenvattu, string dvt, float dongia, int soluong, float thanhtien)
        {
            this.Id_dm = id_dm;
            this.Id_phieu = id_phieu;
            this.Id_vattu = id_vattu;
            this.Ten_vattu = tenvattu;
            this.Dvt = dvt;
            this.Dongia = dongia;
            this.Soluong = soluong;
            this.Thanhtien = thanhtien;
            //this.Thaotac = hinh;
        }

        public int Id_dm
        {
            get
            {
                return id_dm;
            }

            set
            {
                id_dm = value;
            }
        }

        public int Id_phieu
        {
            get
            {
                return id_phieu;
            }

            set
            {
                id_phieu = value;
            }
        }

        public int Soluong
        {
            get
            {
                return soluong;
            }

            set
            {
                soluong = value;
            }
        }

        public double Thanhtien
        {
            get
            {
                return thanhtien;
            }

            set
            {
                thanhtien = value;
            }
        }

        public int Id_vattu
        {
            get
            {
                return id_vattu;
            }

            set
            {
                id_vattu = value;
            }
        }

        public string Ten_vattu
        {
            get
            {
                return ten_vattu;
            }

            set
            {
                ten_vattu = value;
            }
        }

        public string Dvt
        {
            get
            {
                return dvt;
            }

            set
            {
                dvt = value;
            }
        }

        public double Dongia
        {
            get
            {
                return dongia;
            }

            set
            {
                dongia = value;
            }
        }

        

        public DinhMuc(DataRow row)
        {
            //this.Id_vattu = (int)row["ID_VATTU"];
            this.Ten_vattu = row["TENVATTU"].ToString();
            this.Dvt = row["DVT"].ToString();
            this.Dongia = Convert.ToDouble(row["DONGIA"].ToString());
            this.Soluong = (int)row["SO_LUONG"];
            this.Thanhtien = Convert.ToDouble(row["THANH_TIEN"].ToString());
            //this.Thaotac = Thaotac.Images.Add(new Bitmap(Application.StartupPath + "\\Images\\p1.png"));
        }

    }
}
