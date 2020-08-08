using QuanLyBanSatThep.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanSatThep.DAO
{
    public class NhaCungCapDAO
    {
        private static NhaCungCapDAO instance;
        //private object dgv_NCC;

        public static NhaCungCapDAO Instance
        {
            get
            {
                if( instance == null) instance = new NhaCungCapDAO(); return NhaCungCapDAO.instance;
            }

            private set
            {
                instance = value;
            }
        }

        public NhaCungCapDAO() { }

        public List<NhaCungCap> LoadNhaCCList()
        {
            List<NhaCungCap> nccList = new List<NhaCungCap>();

            string query = "select * from NHACUNGCAP";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                NhaCungCap ncc = new NhaCungCap(item);
                nccList.Add(ncc);
            }

            return nccList;
            
        }

        public bool InsertNcc(string mancc, string tenncc, string sdt, string email)
        {
            string query = string.Format("insert dbo.NHACUNGCAP ( MA_NCC, TENNHACC, SDT_NCC, EMAIL ) values(N'{0}',N'{1}',N'{2}',N'{3}')", mancc, tenncc, sdt, email);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateNcc(string mancc, string tenncc, string sdt, string email)
        {
            string query = string.Format("update dbo.NHACUNGCAP set TENNHACC = N'{1}', SDT_NCC = N'{2}', EMAIL = N'{3}' where MA_NCC = N'{0}' ", mancc,tenncc, sdt, email);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public void DeleteNcc(string mancc)
        {
            string query = string.Format("delete from dbo.NHACUNGCAP where MA_NCC = N'{0}' ", mancc);
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        public NhaCungCap GetIDNhaCC(string id)
        {
            NhaCungCap lvt = null;
            string query = "select * from NHACUNGCAP where MA_NCC = '" + id + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                lvt = new NhaCungCap(item);
                return lvt;
            }
            return lvt;
        }
        public List<NhaCungCap> SearchNCC(string tenncc)
        {
            List<NhaCungCap> nccList = new List<NhaCungCap>();

            string query = string.Format("select * from NHACUNGCAP where dbo.fuConvertToUnsign1(TENNHACC) like N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", tenncc);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                NhaCungCap ncc = new NhaCungCap(item);
                nccList.Add(ncc);
            }

            return nccList;

        }

    }
}
