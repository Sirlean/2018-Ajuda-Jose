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
    public class AgendaDAL : SqlHelper<Agenda>
    {
        private SqlConnection con;
        private SqlCommand comando;

        public AgendaDAL()
        {
            this.con = FabricaConexao.getConexao();
        }

        public void abrirConexão()
        {
            if (this.con.State == ConnectionState.Closed)
            {
                this.con.Open();
            }
        }

        public void create(Agenda obj)
        {
            string create = "INSERT INTO agendamento (nome_agend,tel_agend,cpf_agend,hora_agend,data_agend,box_agend)" +
                "Values('" + obj.Nome1 + "','" + obj.Tel + "','" + obj.CPF1 +
                "','" + obj.Hora1 + "','" + obj.Data1 + "','" + obj.Box1 + "' )";
            try
            {
                this.abrirConexão();
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

        public void delete(Agenda obj)
        {
            string create = "DELETE FROM agendamento where cod_agend ='" + obj.COD_Agenda1 + "'";
            try
            {
                this.abrirConexão();
                comando = new SqlCommand(create, this.con);
                comando.ExecuteNonQuery();
            }

            catch (Exception ex)

            {
                throw new Exception();
            }
            finally
            {
                this.con.Close();
            }
        }

        public bool find(Agenda obj)
        {
            bool temRegistros;
            string find = "SELECT * FROM agendamento where cod_agend = '" + obj.COD_Agenda1 + "' ";
            try
            {
                this.abrirConexão();
                comando = new SqlCommand(find, this.con);
                SqlDataReader reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.COD_Agenda1 = Convert.ToInt32(reader[0].ToString());
                    obj.Nome1 = reader[1].ToString();
                    obj.Tel = reader[2].ToString();
                    obj.CPF1 = reader[3].ToString();
                    obj.Hora1 = reader[4].ToString();
                    obj.Data1 = reader[5].ToString();
                    obj.Box1 = reader[6].ToString();
                }
                else
                {
                    return false;
                }
            }

            catch (Exception ex)

            {
                throw new Exception();
            }
            finally
            {
                this.con.Close();
            }

            return temRegistros;
        }

        public void fecharConexao()
        {
            this.con.Dispose();
        }

        public List<Agenda> findAll()
        {
            List<Agenda> listaAgend = new List<Agenda>();
            string findAll = "SELECT * FROM agendamento order by nome_agend";

            try
            {
                this.abrirConexão();
                comando = new SqlCommand(findAll, this.con);
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Agenda obj = new Agenda();
                    obj.COD_Agenda1 = Convert.ToInt32(reader[0].ToString());
                    obj.Nome1 = reader[1].ToString();
                    obj.Tel = reader[2].ToString();
                    obj.CPF1 = reader[3].ToString();
                    obj.Hora1 = reader[4].ToString();
                    obj.Data1 = reader[5].ToString();
                    obj.Box1 = reader[6].ToString();
                    listaAgend.Add(obj);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                this.con.Close();
            }

            return listaAgend;

        }

        public List<Agenda> FindAll()
        {
            throw new NotImplementedException();
        }

        public void update(Agenda obj)
        {
            string create = "UPDATE agendamento SET nome_agend = '" + obj.Nome1 + "', tel_agend = '" + obj.Tel + 
                "', cpf_agend = '" + obj.CPF1 + "', hora_agend = '" + obj.Hora1 + "', data_agend = '" + obj.Data1 +
               "', box_agend = '" + obj.Box1 + "' where cod_agend = '" + obj.COD_Agenda1 + "'";

            try
            {
                this.abrirConexão();
                comando = new SqlCommand(create, this.con);
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
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
