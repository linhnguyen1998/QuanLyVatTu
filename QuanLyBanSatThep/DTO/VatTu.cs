using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanSatThep.DTO
{
    public class VatTu
    {
        public VatTu(int id, string maloai, string tenvattu, string dvt, double dongia, string dongiatext, int slton)
        {
            this.Id_vattu = id;
            this.Maloai = maloai;
            this.Ten_vattu = tenvattu;
            this.Dvt = dvt;
            this.Dongia = dongia;
            this.Dongiatext = dongiatext;
            this.Soluongton = slton;
        }

        private int id_vattu;
        private string maloai;
        private string ten_vattu;
        private string dvt;
        private double dongia;
        private string dongiatext;
        private int soluongton;

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

        public string Maloai
        {
            get
            {
                return maloai;
            }

            set
            {
                maloai = value;
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

        public int Soluongton
        {
            get
            {
                return soluongton;
            }

            set
            {
                soluongton = value;
            }
        }

        public string Dongiatext
        {
            get
            {
                return dongiatext;
            }

            set
            {
                dongiatext = value;
            }
        }

        System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("vi-VN");
        public VatTu(DataRow row)
        {
            this.Id_vattu = (int)row["ID_VATTU"];
            this.Maloai = row["MALOAI"].ToString();
            this.Ten_vattu = row["TENVATTU"].ToString();
            this.Dvt = row["DVT"].ToString();
            //this.Dongia = Convert.ToDouble(row["DONGIA"].ToString());
            this.Dongiatext = row["DONGIA"].ToString();
            this.Soluongton = (int)row["SOLUONGTON"];

        }
    }
}
