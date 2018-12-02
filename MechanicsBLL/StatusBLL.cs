using MechanicsDAL;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicsBLL
{
   public  class StatusBLL
    {
        StatusDAL statDAL;

        public StatusBLL()
        {
            this.statDAL = new StatusDAL();
        }
        public string ValidaDados(Status obj)
        {
            string msg = null;

            //validar nome
            if (obj.Nome1.Length <= 7)
            {
                msg += "N";
            }

            //validar telefone
            if (obj.Tel1.Length < 5)
            {
                msg += "T";
            }

            //validar placa
            if (obj.Placa1.Length < 6)
            {
                msg += "P";
            }
            return msg;
        }

        public string inserir(Status obj)
        {
            string situacao = null;

            situacao = ValidaDados(obj);

            if (String.IsNullOrEmpty(situacao))
            {
                try
                {
                    this.statDAL.abrirConexao();
                    this.statDAL.create(obj);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    this.statDAL.fecharConexao();
                }
            }
            return situacao;
        }

        public string alterar(Status obj)
        {
            string situacao = null;

            situacao = ValidaDados(obj);

            if (String.IsNullOrEmpty(situacao))
            {
                try
                {
                    this.statDAL.abrirConexao();
                    this.statDAL.create(obj);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    this.statDAL.fecharConexao();
                }
            }
            return situacao;
        }

        public string ecxluir(Status obj)
        {
            string situacao = null;

            if (this.statDAL.find(obj))
            {
                try
                {
                    this.statDAL.abrirConexao();
                    this.statDAL.delete(obj);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    this.statDAL.fecharConexao();
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
                List<Status> lista = statDAL.FindAll();
                if (lista.Count == 0)
                {
                    linhas = "<tr><td colspan='6'> Esse carro não esta no  conserto</td></tr>";
                }
                else
                {
                    foreach (Status objStatu in lista)
                    {
                        linhas += "<tr>";
                        linhas += "<td>" + objStatu.Nome1 + "</td>";
                        linhas += "<td>" + objStatu.Tel1 + "</td>";
                        linhas += "<td>" + objStatu.Placa1 + "</td>";
                        linhas += "<td><a href=\"/updateStatus.cshtml?id=" + objStatu.COD_Os1 +
                            "\"><img src=\"/assents/imagens/editar.jpg\"></a></td>";
                        linhas += "<td><a href=\"/deleteStatus.cshtml?id=" + objStatu.COD_Os1 +
                               "\"><img src=\"/assents/imagens/excluir.jpg\"></a></td>";
                        linhas += "</tr>";
                    }
                }
            }
            catch (Exception ex)
            {
                linhas = "<tr><td colspan = '6'>" + ex.Message + "</td></tr>";
            }
            return linhas;
        }
    }

}
