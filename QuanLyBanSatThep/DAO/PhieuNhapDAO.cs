using QuanLyBanSatThep.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanSatThep.DAO
{
    public class PhieuNhapDAO
    {
        private static PhieuNhapDAO instance;


        public PhieuNhapDAO() { }

        public static PhieuNhapDAO Instance
        {
            get
            {
                if (instance == null) instance = new PhieuNhapDAO(); return PhieuNhapDAO.instance;
            }

            private set
            {
                instance = value;
            }
        }

        public void Insert_PhieuNhap(string mancc, double tonggiatri)
        {
            string idphieu = "SELECT top 1 * FROM PHIEU order by ID_PHIEU desc";
            int id_phieu = (int)DataProvider.Instance.ExecuteScalar(idphieu);
            string query = "insert into PHIEUNHAP values('"+ mancc +"','"+ id_phieu +"',getdate(),'"+ tonggiatri +"')";
            DataProvider.Instance.ExecuteNonQuery(query, new object[] { mancc, tonggiatri });
        }
        public void Destroy_PhieuNhap()
        {
            string query1 = "delete from CHITIETPHIEUNHAP where ID_PHIEU = (SELECT top 1 * FROM PHIEU order by ID_PHIEU desc)";
            DataProvider.Instance.ExecuteNonQuery(query1);
            string query = "delete from PHIEU where ID_PHIEU = (SELECT top 1 * FROM PHIEU order by ID_PHIEU desc)";
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        public List<PhieuNhap> loadPhieuNhap()
        {
            List<PhieuNhap> pnlist = new List<PhieuNhap>();
            string query = "select ID_PHIEUNHAP, pn.MA_NCC, ncc.TENNHACC, ID_PHIEU, NGAYNHAP, PARSENAME(convert(varchar, convert(money, TONGGIATRI), 1), 2) as TONGGIATRI from PHIEUNHAP as pn, NHACUNGCAP as ncc where pn.MA_NCC = ncc.MA_NCC";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                PhieuNhap pn = new PhieuNhap(item);
                pnlist.Add(pn);
            }
            return pnlist;
        }
        public bool Update_PN(int id_pn, string mancc, DateTime date, double tong)
        {
            string query = string.Format("update PHIEUNHAP set MA_NCC = N'{1}', NGAYNHAP = '{2}', TONGGIATRI = '{3}' where ID_PHIEUNHAP = '{0}'", id_pn, mancc, date, tong);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public void Delete_PN(int id_pn, int phieu)
        {
            string query1 = string.Format("delete from PHIEUNHAP where ID_PHIEUNHAP = '{0}' and ID_PHIEU = '{1}'", id_pn, phieu);
            DataProvider.Instance.ExecuteNonQuery(query1);
            string query2 = string.Format("delete from CHITIETPHIEUNHAP where ID_PHIEU = '{0}'", phieu);
            DataProvider.Instance.ExecuteNonQuery(query2);
        }
        public List<PhieuNhap> SearchPhieuNhap(DateTime ngay)
        {
            List<PhieuNhap> pnlist = new List<PhieuNhap>();
            string query = string.Format("select ID_PHIEUNHAP, pn.MA_NCC, ncc.TENNHACC, ID_PHIEU, NGAYNHAP, PARSENAME(convert(varchar, convert(money, TONGGIATRI), 1), 2) as TONGGIATRI from PHIEUNHAP as pn, NHACUNGCAP as ncc where pn.MA_NCC = ncc.MA_NCC and NGAYNHAP = '{0}'", ngay);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                PhieuNhap pn = new PhieuNhap(item);
                pnlist.Add(pn);
            }
            return pnlist;
        }
        public int CountRowPN()
        {
            string query = "select count(*) from PHIEUNHAP";
            int result = (int)DataProvider.Instance.ExecuteScalar(query);
            return result;
        }
        public List<PhieuNhap> PagesPhieuNhap(int pages)
        {
            List<PhieuNhap> hdlist = new List<PhieuNhap>();
            string query = string.Format("exec dbo.PhanTrangPhieuNhap '{0}'", pages);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                PhieuNhap hd = new PhieuNhap(item);
                hdlist.Add(hd);
            }
            return hdlist;
        }



    }
}
