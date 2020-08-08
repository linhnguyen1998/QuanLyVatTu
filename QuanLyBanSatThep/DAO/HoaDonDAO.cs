using QuanLyBanSatThep.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanSatThep.DAO
{
    public class HoaDonDAO
    {
        private static HoaDonDAO instance;

        
        public HoaDonDAO() { }

        public static HoaDonDAO Instance
        {
            get
            {
                if( instance == null) instance = new HoaDonDAO(); return HoaDonDAO.instance;
            }

            private set
            {
                instance = value;
            }
        }

        public void ThanhToan(string ten, string sdt, double tongcong)
        {
            DataProvider.Instance.ExecuteNonQuery("exec ThanhToanHoaDon @Ten_kh , @Sdt_kh , @TongCong", new object[] { ten, sdt, tongcong });
        }
        public List<HoaDon> loadHoaDon()
        {
            List<HoaDon> hdlist = new List<HoaDon>();
            string query = "select ID_HD, ID_PHIEU, TEN_KH, SDT_KH, NGAYXUATHD, PARSENAME(convert(varchar, convert(money, THANHTIEN), 1), 2) as THANHTIEN from HOADON";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                HoaDon hd = new HoaDon(item);
                hdlist.Add(hd);
            }
            return hdlist;
        }

        public bool Update_HD(int id_hd, string tenkh, string sdt, DateTime date, double tong)
        {
            string query = string.Format("update HOADON set TEN_KH = N'{1}', SDT_KH = N'{2}', NGAYXUATHD = '{3}', THANHTIEN = '{4}' where ID_HD = '{0}'",id_hd, tenkh, sdt, date, tong);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public void Delete_HD(int id_hd, int phieu)
        {
            string query1 = string.Format("delete from HOADON where ID_HD = '{0}' and ID_PHIEU = '{1}'", id_hd, phieu);
            DataProvider.Instance.ExecuteNonQuery(query1);
            string query2 = string.Format("delete from CHITIETHOADON where ID_PHIEU = '{0}'", phieu);
            DataProvider.Instance.ExecuteNonQuery(query2);
        }

        public List<HoaDon> SearchHoaDon(string sdt)
        {
            List<HoaDon> hdlist = new List<HoaDon>();
            string query = string.Format("select ID_HD, ID_PHIEU, TEN_KH, SDT_KH, NGAYXUATHD, PARSENAME(convert(varchar, convert(money, THANHTIEN), 1), 2) as THANHTIEN from HOADON where dbo.fuConvertToUnsign1(SDT_KH) like N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", sdt);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                HoaDon hd = new HoaDon(item);
                hdlist.Add(hd);
            }
            return hdlist;
        }
        public int CountRowHoaDon()
        {
            string query = "select count(*) from HOADON";
            int result = (int)DataProvider.Instance.ExecuteScalar(query);
            return result;
        }
        public List<HoaDon> PagesHoaDon(int pages)
        {
            List<HoaDon> hdlist = new List<HoaDon>();
            string query = string.Format("exec dbo.PhanTrangHoaDon '{0}'", pages);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                HoaDon hd = new HoaDon(item);
                hdlist.Add(hd);
            }
            return hdlist;
        }
    }
}
