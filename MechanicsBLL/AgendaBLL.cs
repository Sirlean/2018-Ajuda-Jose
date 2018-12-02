using MechanicsDAL;
using MODEL;
using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicsBLL
{
    public class AgendaBLL
    {
        AgendaDAL agendDAL;

        public AgendaBLL()
        {
            this.agendDAL = new AgendaDAL();
        }

        public string ValidaDados(Agenda obj)
        {
            string msg = null;

            //validar nome
            if (obj.Nome1.Length <= 7)
            {
                msg += "N";
            }

            //validar telefone
            if (obj.Tel.Length < 5)
            {
                msg += "T";
            }
            //validar cpf
            //garantir somente os numeros
            string cpf = obj.CPF1.Replace(".", "").Replace(".", "").Replace("-", "");
            obj.CPF1 = cpf;

            //validar para cpfs compostos de numeros repetidos e validar se possui 11 disgitos
            //validar o digito verificar % 11
            if (cpf.Length == 11)
            {
                if (cpf == "11111111111" || cpf == "22222222222" || cpf == "33333333333" ||
                    cpf == "44444444444" || cpf == "55555555555" || cpf == "66666666666" ||
                    cpf == "77777777777" || cpf == "88888888888" || cpf == "99999999999" ||
                    cpf == "00000000000")
                {
                    msg += "C2";
                }
            }
            else
            {
                msg += "C1";
            }
            return msg;

        }
        public static bool ValidaDataHora(string Data1, string Hora1)
        {
            DateTimeFormatInfo brDtfi = new CultureInfo("pt-BR", false).DateTimeFormat;
            try
            {
                DateTime dataehora = Convert.ToDateTime(string.Format("{0} {1}", Data1, Hora1), brDtfi);
                if (dataehora < DateTime.Now)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public string inserir(Agenda obj)
        {
            string situacao = null;

            situacao = ValidaDados(obj);

            if (String.IsNullOrEmpty(situacao))
            {
                try
                {
                    this.agendDAL.abrirConexão();
                    this.agendDAL.create(obj);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    this.agendDAL.fecharConexao();
                }
            }
            return situacao;

        }
        public string alterar(Agenda obj)
        {
            string situacao = null;

            situacao = ValidaDados(obj);

            if (String.IsNullOrEmpty(situacao))
            {
                try
                {
                    this.agendDAL.abrirConexão();
                    this.agendDAL.update(obj);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    this.agendDAL.fecharConexao();
                }
            }
            return situacao;
        }

        public string excluir(Agenda obj)
        {
            string situacao = null;

            if (this.agendDAL.find(obj))
            {
                try
                {
                    this.agendDAL.abrirConexão();
                    this.agendDAL.delete(obj);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    this.agendDAL.fecharConexao();
                }
            }
            else
            {
                situacao = "F";
            }
            return situacao;
        }

        public string listarTabelaHTML()
        {
            string linhas = null;
            try
            {
                List<Agenda> lista = agendDAL.findAll();
                if (lista.Count == 0)
                {
                    linhas = "<tr><td colspan='6'> Não existe agendamento cadastrado</td></tr>";
                }
                else
                {
                    foreach (Agenda objAgen in lista)
                    {
                        linhas += "<tr>";
                        linhas += "<td>" + objAgen.Nome1 + "</td>";
                        linhas += "<td>" + objAgen.Tel + "</td>";
                        linhas += "<td>" + objAgen.CPF1 + "</td>";
                        linhas += "<td>" + objAgen.Data1 + "</td>";
                        linhas += "<td>" + objAgen.Hora1 + "</td>";
                        linhas += "<td><a href=\"/updateAgenda.cshtml?id=" + objAgen.COD_Agenda1 +
                            "\"><img src=\"/assents/imagens/editar.jpg\"></a></td>";
                        linhas += "<td><a href=\"/deleteAgenda.cshtml?id=" + objAgen.COD_Agenda1 +
                            "\"><img src=\"/assents/imagens/excluir.jpg\"></a></td>";
                        linhas += "</tr>";


                    }
                }
            }
            catch (Exception ex)
            {
                linhas = "<tr><td colspan ='6'>" + ex.Message + "</td></tr>";
            }
            return linhas;
        }
    }
}
