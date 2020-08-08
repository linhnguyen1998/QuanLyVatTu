using QuanLyBanSatThep.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanSatThep.DAO
{
    public class TamTinhDAO
    {
        private static TamTinhDAO instance;

        public TamTinhDAO() { }

        public static TamTinhDAO Instance
        {
            get
            {
                if( instance == null ) instance = new TamTinhDAO(); return TamTinhDAO.instance;
            }

            private set
            {
                instance = value;
            }
        }
        public void TamTinhHD(string ten, string sdt, double tongcong)
        {
            DataProvider.Instance.ExecuteNonQuery("exec ThanhToanTamTinh @Ten_kh , @Sdt_kh , @TongCong", new object[] { ten, sdt, tongcong });
        }
        public List<TamTinh> loadTamTinh()
        {
            List<TamTinh> hdlist = new List<TamTinh>();
            string query = "select ID_TT, ID_PHIEU, TEN_KH, SDT_KH, NGAYTAMTINH, PARSENAME(convert(varchar, convert(money, THANHTIEN), 1), 2) as THANHTIEN from TAMTINH";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                TamTinh hd = new TamTinh(item);
                hdlist.Add(hd);
            }
            return hdlist;
        }
        public bool Update_TT(int id_tt, string tenkh, string sdt, DateTime date, double tong)
        {
            string query = string.Format("update TAMTINH set TEN_KH = N'{1}', SDT_KH = N'{2}', NGAYTAMTINH = '{3}', THANHTIEN = '{4}' where ID_TT = '{0}'", id_tt, tenkh, sdt, date, tong);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public void Delete_TT(int id_tt, int phieu)
        {
            string query1 = string.Format("delete from TAMTINH where ID_TT = '{0}' and ID_PHIEU = '{1}'", id_tt, phieu);
            DataProvider.Instance.ExecuteNonQuery(query1);
            string query2 = string.Format("delete from CHITIETHOADON where ID_PHIEU = '{0}'", phieu);
            DataProvider.Instance.ExecuteNonQuery(query2);
        }
        public bool ThanhToanTT(int id, int id_phieu)
        {
            string query = string.Format("insert into HOADON (ID_PHIEU, TEN_KH, SDT_KH, NGAYXUATHD, THANHTIEN) select ID_PHIEU, TEN_KH, SDT_KH, NGAYTAMTINH, THANHTIEN from TAMTINH where ID_PHIEU = '{0}'", id_phieu);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            string query1 = string.Format("delete from TAMTINH where ID_TT = '{0}'", id);
            DataProvider.Instance.ExecuteNonQuery(query1);
            return result > 0;
        }
        public List<TamTinh> SearchTamTinh(string sdt)
        {
            List<TamTinh> hdlist = new List<TamTinh>();
            string query = string.Format("select ID_TT, ID_PHIEU, TEN_KH, SDT_KH, NGAYTAMTINH, PARSENAME(convert(varchar, convert(money, THANHTIEN), 1), 2) as THANHTIEN from TAMTINH where dbo.fuConvertToUnsign1(TENNHACC) like N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", sdt);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                TamTinh hd = new TamTinh(item);
                hdlist.Add(hd);
            }
            return hdlist;
        }
    }
    

}
