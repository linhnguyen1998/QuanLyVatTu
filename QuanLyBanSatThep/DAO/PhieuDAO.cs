using QuanLyBanSatThep.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanSatThep.DTO
{
    public class PhieuDAO
    {
        private static PhieuDAO instance;

        public static PhieuDAO Instance
        {
            get
            {
                if( instance == null) instance = new PhieuDAO(); return PhieuDAO.instance;
            }

            private set
            {
                instance = value;
            }
        }
        public PhieuDAO() { }
        public void CreatePhieu()
        {
            string query = "insert into PHIEU default values";
            DataProvider.Instance.ExecuteQuery(query);
        }

        public void DestroyPhieu()
        {
            string query1 = "delete from DINHMUCVATTU where ID_PHIEU = (SELECT top 1 * FROM PHIEU order by ID_PHIEU desc)";
            DataProvider.Instance.ExecuteNonQuery(query1);
            string query2 = "delete from CHITIETHOADON where ID_PHIEU = (SELECT top 1 * FROM PHIEU order by ID_PHIEU desc)";
            DataProvider.Instance.ExecuteNonQuery(query2);
            string query = "delete from PHIEU where ID_PHIEU = (SELECT top 1 * FROM PHIEU order by ID_PHIEU desc)";
            DataProvider.Instance.ExecuteNonQuery(query);
            
        }
    }
}
