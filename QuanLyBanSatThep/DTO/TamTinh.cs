using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanSatThep.DTO
{
    public class TamTinh
    {
        private int id_tt;
        private int id_phieu;
        private string tenkh;
        private string sdt_kh;
        private DateTime date;
        private string thanhtien;

        public int Id_tt
        {
            get
            {
                return id_tt;
            }

            set
            {
                id_tt = value;
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

        public string Tenkh
        {
            get
            {
                return tenkh;
            }

            set
            {
                tenkh = value;
            }
        }

        public string Sdt_kh
        {
            get
            {
                return sdt_kh;
            }

            set
            {
                sdt_kh = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
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

        public TamTinh(int id, int id_phieu, string ten, string sdt, DateTime date, string tongcong)
        {
            this.Id_tt = id;
            this.Id_phieu = id_phieu;
            this.Tenkh = ten;
            this.Sdt_kh = sdt;
            this.Date = date;
            this.Thanhtien = tongcong;
        }
        public TamTinh(DataRow row)
        {
            this.Id_tt = (int)row["ID_TT"];
            this.Id_phieu = (int)row["ID_PHIEU"];
            this.Tenkh = row["TEN_KH"].ToString();
            this.Sdt_kh = row["SDT_KH"].ToString();
            this.Date = (DateTime)row["NGAYTAMTINH"];
            this.Thanhtien = row["THANHTIEN"].ToString();
        }
    }
}
