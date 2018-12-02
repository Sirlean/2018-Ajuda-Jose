using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MechanicsDAL
{
    class FabricaConexao
    {
        //declarar os objetos da classe
        private static SqlConnection cn;

        // criar a string de conexão com o banco de dados
        //private static string caminho = @"Server=NOTE;Database=ASPnet; HP-PC\SQLEXPRESS";
        private static string caminho = "Data Source=.\\SQLEXPRESS;initial Catalog=Reserva;Integrated Security=True";


        //Método
        public static SqlConnection getConexao()
        {
            try
            {
                cn = new SqlConnection(caminho);
                return cn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
