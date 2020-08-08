using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanSatThep.DAO
{
    public class DataProvider
    {
        public static string conn = "";

        //private string connectionSTR = @"Data Source=" + conn + ";AttachDbFilename=" + Application.StartupPath + @"\QLSatThep.mdf" + ";Integrated Security=True;Connect Timeout=30;User Instance=True; Trusted_Connection=Yes";
        private string connectionSTR = "Data Source =.\\SQLEXPRESS;Initial Catalog = QLSatThep; Integrated Security = True";
        public void KetNot()
        {
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                try
                {
                    MessageBox.Show("Openning Connection ...");

                    connection.Open();

                    MessageBox.Show("Connection successful!");

                    flogin lg = new flogin();
                    ServerConnect sv = new ServerConnect();
                    sv.Hide();
                    lg.Show();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error: " + e.Message);
                }
            }
        }

        private static DataProvider instance;

        public static DataProvider Instance
        {
            get
            {
                if( instance == null ) instance = new DataProvider(); return DataProvider.instance;
            }

            private set
            {
                instance = value;
            }
        }

        private DataProvider() { }

        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if(parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if(item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    } 
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(data);

                connection.Close();
            }
            return data;
        }

        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteNonQuery();

                connection.Close();
            }
            return data;
        }

        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteScalar();

                connection.Close();
            }
            return data;
        }
    }
}
