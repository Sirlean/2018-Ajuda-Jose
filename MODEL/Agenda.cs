using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MODEL
{
    public class Agenda
    {
        int COD_Agenda;
        string Nome;
        string tel;
        string CPF;
        string Hora;
        string Data;
        string Box;

        public int COD_Agenda1
        {
            get
            {
                return COD_Agenda;
            }

            set
            {
                COD_Agenda = value;
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

        public string Tel
        {
            get
            {
                return tel;
            }

            set
            {
                tel = value;
            }
        }

        public string CPF1
        {
            get
            {
                return CPF;
            }

            set
            {
                CPF = value;
            }
        }

        public string Hora1
        {
            get
            {
                return Hora;
            }

            set
            {
                Hora = value;
            }
        }

        public string Data1
        {
            get
            {
                return Data;
            }

            set
            {
                Data = value;
            }
        }

        public string Box1
        {
            get
            {
                return Box;
            }

            set
            {
                Box = value;
            }
        }

        public Agenda()
        {
        }


        public Agenda(int COD_Agenda, string Nome, string tel, string CPF, string Hora, string Data, string vaga1)
        {
            this.COD_Agenda1 = COD_Agenda;
            this.Nome1 = Nome;
            this.Tel = tel;
            this.CPF1 = CPF;
            this.Hora1 = Hora;
            this.Data1 = Data;
            this.Box1 = Box1;
        }
    }
 }

