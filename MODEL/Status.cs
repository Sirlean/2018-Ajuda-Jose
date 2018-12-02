using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MODEL
{
    public class Status
    {
        int COD_Os;
        string Nome;
        string Tel;
        string Placa;

        public int COD_Os1
        {
            get
            {
                return COD_Os;
            }

            set
            {
                COD_Os = value;
            }
        }

        public string Nome1
        {
            get
            {
                return Nome;
            }

            set
            {
                Nome = value;
            }
        }

        public string Tel1
        {
            get
            {
                return Tel;
            }

            set
            {
                Tel = value;
            }
        }

        public string Placa1
        {
            get
            {
                return Placa;
            }

            set
            {
                Placa = value;
            }
        }
        public Status()
        {
        }

        public Status(int COD_Os, string Nome, string Tel, string Placa)
        {
            this.COD_Os1 = COD_Os;
            this.Nome1 = Nome;
            this.Tel1 = Tel;
            this.Placa1 = Placa;
        }
    }
}
