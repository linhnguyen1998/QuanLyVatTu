using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanSatThep.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get
            {
                if (instance == null) instance = new AccountDAO(); return instance;
            }

            set
            {
                instance = value;
            }
        }

        private AccountDAO() { }

         private string enPass(string pass)
        {
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(pass);
            byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);
            string hasPass = "";
            foreach (byte item in hasData)
            {
                hasPass += item;
            }
            return hasPass;
        }

        public bool Login(string userName, string passWord)
        {
            string pass = enPass(passWord);

            string query = "LoginManage @username , @password";

            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { userName, pass });

            return result.Rows.Count > 0;
        }
        public bool CreateAnAccout(string username, string pass, string firstname, string lastname, string phonenumber, string address)
        {
            string query = string.Format("insert ACCOUNT values(N'{0}', N'{1}', N'{2}', N'{3}', '{4}', N'{5}')", username, enPass(pass), firstname, lastname, phonenumber, address);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool KtraTK(string username)
        {
            string query = string.Format("select count(*) from ACCOUNT where Username = N'{0}'", username);
            int result = Convert.ToInt32(DataProvider.Instance.ExecuteScalar(query));
            return result > 0;
        }
        
        public bool ForgetPass(string username, string pass, string sdt)
        {
            string query = string.Format("update ACCOUNT set Password = N'{1}' where Username = N'{0}' and Phone_Number = N'{2}'", username, enPass(pass), sdt);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

    }
}
