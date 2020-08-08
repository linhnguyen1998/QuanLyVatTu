using QuanLyBanSatThep.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanSatThep.DAO
{
    public class DinhMucDAO
    {
        private static DinhMucDAO instance;

        public static DinhMucDAO Instance
        {
            get
            {
                if (instance == null) instance = new DinhMucDAO(); return DinhMucDAO.instance; 
            }

            private set
            {
                instance = value;
            }
        }
        public DinhMucDAO() { }

        public List<DinhMuc> LoadDinhMucList()
        {
            List<DinhMuc> dinhmuclist = new List<DinhMuc>();
            DataTable data = DataProvider.Instance.ExecuteQuery("exec dbo.Show_DinhMuc");
            foreach (DataRow item in data.Rows)
            {
                DinhMuc dinhmuc = new DinhMuc(item);
                dinhmuclist.Add(dinhmuc);
            } 
            return dinhmuclist;
        }

        public List<DinhMuc> ShowDetail()
        {
            List<DinhMuc> cthdlist = new List<DinhMuc>();
            DataTable data = DataProvider.Instance.ExecuteQuery("exec dbo.ShowOrderDetail");
            foreach (DataRow item in data.Rows)
            {
                DinhMuc cthd = new DinhMuc(item);
                cthdlist.Add(cthd);
            }
            return cthdlist;
        }
        public List<ChiTiet> GetDetailOrderByIdPhieu(int id)
        {
            List<ChiTiet> cthdlist = new List<ChiTiet>();
            string query = "select TENVATTU, DVT, SO_LUONG, PARSENAME(convert(varchar,convert(money,DONGIA),1),2 ) as DONGIA, PARSENAME(convert(varchar,convert(money,THANH_TIEN),1),2 ) as THANH_TIEN from VATTU ,CHITIETHOADON where VATTU.ID_VATTU = CHITIETHOADON.ID_VATTU and  ID_PHIEU = '" + id +"'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { id });
            foreach (DataRow item in data.Rows)
            {
                ChiTiet cthd = new ChiTiet(item);
                cthdlist.Add(cthd);
            }
            return cthdlist;
        }
        public List<ChiTiet> GetDetailPhieuNhapByIdPhieu(int id)
        {
            List<ChiTiet> cthdlist = new List<ChiTiet>();
            string query = "select TENVATTU, DVT, SO_LUONG, PARSENAME(convert(varchar,convert(money,DONGIA),1),2 ) as DONGIA, PARSENAME(convert(varchar,convert(money,THANH_TIEN),1),2 ) as THANH_TIEN from VATTU ,CHITIETPHIEUNHAP where VATTU.ID_VATTU = CHITIETPHIEUNHAP.ID_VATTU and  ID_PHIEU = '" + id + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { id });
            foreach (DataRow item in data.Rows)
            {
                ChiTiet cthd = new ChiTiet(item);
                cthdlist.Add(cthd);
            }
            return cthdlist;
        }
        

    }
}
