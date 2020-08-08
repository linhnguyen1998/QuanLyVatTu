using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanSatThep.DTO
{
    public class PhieuNhap
    {
        private int id_pn;
        private int id_phieu;
        private string mancc;
        private string tenncc;
        private DateTime date;
        private string tonggiatri;

        public int Id_pn
        {
            get
            {
                return id_pn;
            }

            set
            {
                id_pn = value;
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

        public string Mancc
        {
            get
            {
                return mancc;
            }

            set
            {
                mancc = value;
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

        public string Tonggiatri
        {
            get
            {
                return tonggiatri;
            }

            set
            {
                tonggiatri = value;
            }
        }

        public string Tenncc
        {
            get
            {
                return tenncc;
            }

            set
            {
                tenncc = value;
            }
        }

        public PhieuNhap(int id, string mancc, string tenncc, int id_phieu, DateTime date, string tongcong)
        {
            this.Id_pn = id;
            this.Mancc = mancc;
            this.Tenncc = tenncc;
            this.Id_phieu = id_phieu;
            this.Date = date;
            this.Tonggiatri = tongcong;
        }
        public PhieuNhap(DataRow row)
        {
            this.Id_pn = (int)row["ID_PHIEUNHAP"];
            this.Mancc = row["MA_NCC"].ToString();
            this.Tenncc = row["TENNHACC"].ToString();
            this.Id_phieu = (int)row["ID_PHIEU"];
            this.Date = (DateTime)row["NGAYNHAP"];
            this.Tonggiatri = row["TONGGIATRI"].ToString();
        }
    }
}
