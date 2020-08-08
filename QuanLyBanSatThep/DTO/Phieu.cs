using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanSatThep.DAO
{
    public class Phieu
    {
        private int id_phieu;

        public int Id_phieu
        {
            get
            {
                return id_phieu;
            }

            set
            {
                id_phieu = value;
            }
        }
        public Phieu(int id)
        {
            this.Id_phieu = id;
        }
        public Phieu(DataRow row)
        {
            this.Id_phieu = (int)row["ID_PHIEU"];
        }
    }
}
