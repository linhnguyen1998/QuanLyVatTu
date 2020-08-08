using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanSatThep.DTO
{
    public class NhaCungCap
    {
        public NhaCungCap(string id, string name, string sdt, string email)
        {
            this.Id = id;
            this.Name = name;
            this.Sdt_ncc = sdt;
            this.Email = email;
        }

        private string id;
        private string name;
        private string sdt_ncc;
        private string email;

        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Sdt_ncc
        {
            get
            {
                return sdt_ncc;
            }

            set
            {
                sdt_ncc = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }
        
        public NhaCungCap(DataRow row)
        {
            this.Id = row["MA_NCC"].ToString();
            this.Name = row["TENNHACC"].ToString();
            this.Sdt_ncc = row["SDT_NCC"].ToString();
            this.Email = row["EMAIL"].ToString();
        }
    }
}
