using QuanLyBanSatThep.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanSatThep.DAO
{
    public class VatTuDAO
    {
        private static VatTuDAO instance;

        public static VatTuDAO Instance
        {
            get
            {
                if (instance == null) instance = new VatTuDAO(); return VatTuDAO.instance;
            }

            private set
            {
                instance = value;
            }
        }

        private VatTuDAO() { }
        //Load danh sách vật tư trong csdl-------------------------------------
        public List<VatTu> GetListVatTu()
        {
            List<VatTu> vattulist = new List<VatTu>();
            string query = "select * from VATTU";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                VatTu vattu = new VatTu(item);
                vattulist.Add(vattu);
            }
            return vattulist;
        }

        public List<VatTu> LoadListVatTu()
        {
            List<VatTu> vattulist = new List<VatTu>();
            //string s = "MALOAI, TENVATTU, DVT, DONGIA = (PARSENAME(convert(varchar, convert(money, DONGIA), 1), 2)), SOLUONGTON";
            string query = "select ID_VATTU , MALOAI , TENVATTU , DVT , PARSENAME(convert(varchar, convert(money, DONGIA), 1), 2) as DONGIA, SOLUONGTON  from VATTU";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                VatTu vattu = new VatTu(item);
                vattulist.Add(vattu);
            }
            return vattulist;
        }

        public List<VatTu> SearchVatTu(string tenvt)
        {
            List<VatTu> vattulist = new List<VatTu>();
            //string s = "MALOAI, TENVATTU, DVT, DONGIA = (PARSENAME(convert(varchar, convert(money, DONGIA), 1), 2)), SOLUONGTON";
            string query = string.Format("select ID_VATTU , MALOAI , TENVATTU , DVT , PARSENAME(convert(varchar, convert(money, DONGIA), 1), 2) as DONGIA, SOLUONGTON  from VATTU where dbo.fuConvertToUnsign1(TENVATTU) like N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", tenvt);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                VatTu vattu = new VatTu(item);
                vattulist.Add(vattu);
            }
            return vattulist;
        }
        //----------------------------------------------------


        //Tương tác với định mục vật tư khi thực hiện thanh toán----------------

        public void Add_DinhMuc(int id, int soluong)
        {
            DataProvider.Instance.ExecuteNonQuery("exec dbo.Insert_DinhMuc @id_Vattu , @Soluong", new object[] { id, soluong });
        }

        public void Remove_DinhMuc(string ten)
        {
            DataProvider.Instance.ExecuteNonQuery("exec dbo.Remove_VatTu @ten_vattu", new object[] { ten });
        }

        //---------------------------------------------------------------------


        //Thao tác với loại vật tư trong csdl---------------------------------

        public List<LoaiVatTu> LoadLoaiVattu()
        {
            List<LoaiVatTu> loaivattu = new List<LoaiVatTu>();
            //string s = "MALOAI, TENVATTU, DVT, DONGIA = (PARSENAME(convert(varchar, convert(money, DONGIA), 1), 2)), SOLUONGTON";
            string query = "select *  from LOAIVATTU";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                LoaiVatTu vattu = new LoaiVatTu(item);
                loaivattu.Add(vattu);
            }
            return loaivattu;
        }

        public bool InsertLoaiVT(string maloai, string tenloai)
        {
            string query = string.Format("insert into LOAIVATTU values(N'{0}',N'{1}')", maloai, tenloai);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateLoaiVT(string maloai ,string tenloai)
        {
            string query = string.Format("update LOAIVATTU set TENLOAI = N'{1}' where MALOAI = N'{0}' ", maloai,tenloai);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public void DeleteLoaiVT(string maloai)
        {
            string query = string.Format("delete from LOAIVATTU where MALOAI = N'{0}'", maloai);
            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public List<LoaiVatTu> SearchLoaiVattu(string tenl)
        {
            List<LoaiVatTu> loaivattu = new List<LoaiVatTu>();
            //string s = "MALOAI, TENVATTU, DVT, DONGIA = (PARSENAME(convert(varchar, convert(money, DONGIA), 1), 2)), SOLUONGTON";
            string query = string.Format("select *  from LOAIVATTU where dbo.fuConvertToUnsign1(TENLOAI) like N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", tenl);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                LoaiVatTu vattu = new LoaiVatTu(item);
                loaivattu.Add(vattu);
            }
            return loaivattu;
        }
        //---------------------------------------------------------------------

        //Thao tác với vật tư

        public LoaiVatTu GetIDLoaiVattu(string id)
        {
            LoaiVatTu lvt = null;
            string query = "select * from LOAIVATTU where MALOAI = '"+ id +"'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                lvt = new LoaiVatTu(item);
                return lvt;
            }
            return lvt;
        }
        public bool InsertVatTu(string maloai, string tenvt, string dvt, double dongia, int slton)
        {
            string query = string.Format("insert into VATTU values(N'{0}', N'{1}', N'{2}', '{3}', '{4}')", maloai, tenvt, dvt, dongia, slton);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateVatTu(int id,string maloai, string tenvt, string dvt, double dongia, int slton)
        {
            string query = string.Format("update VATTU set MALOAI = N'{1}', TENVATTU = N'{2}', DVT = N'{3}', DONGIA = '{4}', SOLUONGTON = '{5}' where ID_VATTU = '{0}' ", id, maloai, tenvt, dvt, dongia, slton);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public void DeleteVatTu(int id)
        {
            string query = string.Format("delete from VATTU where ID_VATTU = '{0}'", id);
            DataProvider.Instance.ExecuteNonQuery(query);
        }

        //Cập nhật vật tư khi nhập kho-----------------------------------------
        public void UpdateIventory(int id, int sluong, double dongia)
        {
            string query = "update VATTU set SOLUONGTON = SOLUONGTON + '"+ sluong +"', DONGIA = '"+ dongia +"' where ID_VATTU = '"+ id +"'";
            DataProvider.Instance.ExecuteNonQuery(query, new object[] { id, dongia, sluong });
        }

        public object KtraVatTuTonTai(string tenvt)
        {
            string query = "SELECT COUNT(TENVATTU) FROM VATTU WHERE TENVATTU = '"+ tenvt +"'";
            object dem = DataProvider.Instance.ExecuteScalar(query, new object[] { tenvt });
            return dem;
        }

        public void InsertIventory(string ml, string tenvt, string dvt, double dongia, int sl)
        {
            string query = "exec dbo.InsertVatTu @maloai , @tenvt , @dvt , @dongia , @soluong";
            DataProvider.Instance.ExecuteNonQuery(query, new object[] { ml, tenvt, dvt, dongia, sl });
        }

        //-------------------------------------------------------------------------


        //Thao tác với chi tiết phiếu nhập khi nhập kho----------------------------
        public void Update_ChiTietNhap(int idvt, int sl)
        {
            string query = "exec dbo.Update_ChiTietNhap @idvattu , @soluong";
            DataProvider.Instance.ExecuteNonQuery(query, new object[] { idvt, sl });
        }
        public void Add_ChiTietNhap(int sl, double dongia)
        {
            string query = "exec dbo.Add_ChiTietPhieuNhap @dongia , @soluong";
            DataProvider.Instance.ExecuteNonQuery(query, new object[] { sl, dongia }); 
        }


        //--------------------------------------------------------------------------

    }
}
