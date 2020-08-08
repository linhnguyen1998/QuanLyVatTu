using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanSatThep.DTO
{
    public class ChiTiet
    {
        private int id_cthd;
        private int id_phieu;
        private int id_vattu;
        private string ten_vattu;
        private string dvt;
        private string dongia;
        private int soluong;
        private string thanhtien;
        //private ImageList thaotac ;



        public ChiTiet(int id_ct, int id_phieu, int id_vattu, string tenvattu, string dvt, string dongia, int soluong, string thanhtien)
        {
            this.Id_cthd = id_ct;
            this.Id_phieu = id_phieu;
            this.Id_vattu = id_vattu;
            this.Ten_vattu = tenvattu;
            this.Dvt = dvt;
            this.Dongia = dongia;
            this.Soluong = soluong;
            this.Thanhtien = thanhtien;
            //this.Thaotac = hinh;
        }

        public int Id_cthd
        {
            get
            {
                return id_cthd;
            }

            set
            {
                id_cthd = value;
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

        public string Thanhtien
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

        public string Dongia
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



        public ChiTiet(DataRow row)
        {
            //this.Id_vattu = (int)row["ID_VATTU"];
            this.Ten_vattu = row["TENVATTU"].ToString();
            this.Dvt = row["DVT"].ToString();
            this.Dongia = row["DONGIA"].ToString();
            this.Soluong = (int)row["SO_LUONG"];
            this.Thanhtien = row["THANH_TIEN"].ToString();
            //this.Thaotac = Thaotac.Images.Add(new Bitmap(Application.StartupPath + "\\Images\\p1.png"));
        }
    }
}
