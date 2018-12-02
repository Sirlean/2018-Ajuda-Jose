using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MODEL;

namespace MechanicsDAL
{
   public  class StatusDAL : SqlHelper<Status>
    {
        private SqlConnection con;
        private SqlCommand comando;

        public StatusDAL()
        {
            this.con = FabricaConexao.getConexao();
        }

        public void abrirConexao()
        {
            if (this.con.State == ConnectionState.Closed)
            {
                this.con.Open();
            }
        }

        public void create(Status obj)
        {
            string create = "INSERT INTO status (nome_stat, placa_stat)" + "Values ('" + obj.Nome1 + "','" + obj.Placa1 + "')";

            try
            {
                this.abrirConexao();
                comando = new SqlCommand(create, this.con);
                comando.ExecuteNonQuery();
            }

            catch (Exception e)

            {
                throw;
            }
            finally
            {
                this.con.Close();
            }
        }

        public void abrirConexão()
        {
            throw new NotImplementedException();
        }

        public void delete(Status obj)
        {
            string create = "DELETE FROM status where cod_status = '" + obj.Placa1 + "'";

            try
            {
                this.abrirConexao();
                comando = new SqlCommand(create, this.con);
                comando.ExecuteNonQuery();
            }

            catch (Exception e)

            {
                throw new Exception();
            }
            finally
            {
                this.con.Close();
            }

        }

        public void fecharConexao()
        {
            throw new NotImplementedException();
        }

        public bool find(Status obj)
        {
            bool temRegistros;
            string find = "SELECT * FROM status where cod_status = '" + obj.Placa1 + "'";
            try
            {
                this.abrirConexao();
                comando = new SqlCommand(find, this.con);
                SqlDataReader reader = comando.ExecuteReader();
                temRegistros = reader.Read();

                if (temRegistros)
                {
                    obj.COD_Os1 = Convert.ToInt32(reader[0].ToString());
                    obj.Nome1 = reader[1].ToString();
                    obj.Tel1 = reader[3].ToString();
                    obj.Placa1 = reader[2].ToString();

                }
                else
                {
                    return false;
                }

            }

            catch (Exception e)

            {
                throw new Exception();
            }
            finally
            {
                this.con.Close();
            }

            return temRegistros;
        }


        public List<Status> FindAll()
        {
            List<Status> listaStat = new List<Status>();
            string findAll = "SELECT * FROM oder by nome_stat";

            try
            {
                this.abrirConexao();
                comando = new SqlCommand(findAll, this.con);
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Status obj = new Status();
                    obj.COD_Os1 = Convert.ToInt32(reader[0].ToString());
                    obj.Nome1 = reader[1].ToString();
                    obj.Tel1 = reader[2].ToString();
                    obj.Placa1 = reader[3].ToString();
                    listaStat.Add(obj);
                }

            }

            catch (Exception e)

            {
                throw;
            }
            finally
            {
                this.con.Close();
            }

            return listaStat;
        }

        public void update(Status obj)
        {
            string create = "UPDATE status SET" + "nome_stat = '" + obj.Nome1 + "tel_stat = '" + obj.Tel1 +
                "placa_stat =" + obj.Tel1 + "where cod_status = '" + obj.COD_Os1 + "'";

            try
            {
                this.abrirConexao();
                comando = new SqlCommand(create, this.con);
                comando.ExecuteNonQuery();
            }

            catch (Exception e)

            {
                throw new Exception();
            }
            finally
            {
                this.con.Close();
            }
        }
    }
}
