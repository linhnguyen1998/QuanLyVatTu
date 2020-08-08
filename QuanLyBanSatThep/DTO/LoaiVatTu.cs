using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanSatThep.DTO
{
    public class LoaiVatTu
    {
        private string maloai;
        private string tenloai;

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

        public string Tenloai
        {
            get
            {
                return tenloai;
            }

            set
            {
                tenloai = value;
            }
        }
        public LoaiVatTu(string mloai, string tenloai)
        {
            this.Maloai = mloai;
            this.Tenloai = tenloai;
        }
        public LoaiVatTu(DataRow row)
        {
            this.Maloai = row["MALOAI"].ToString();
            this.Tenloai = row["TENLOAI"].ToString();
        }
    }
}
