using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dominio;
using Dados.saceDataSetTableAdapters;
using Dados;
using Util;
using System.Data.Common;

namespace Negocio
{
    public class GerenciadorLoja : IGerenciadorLoja
    {
        private static IGerenciadorLoja gLoja;
        private static tb_lojaTableAdapter tb_lojaTA;
        
        public static IGerenciadorLoja getInstace()
        {
            if (gLoja == null)
            {
                gLoja = new GerenciadorLoja();
                tb_lojaTA = new tb_lojaTableAdapter();
            }
            return gLoja;
        }

        public void inserir(Loja loja)
        {
            try
            {
                tb_lojaTA.Insert(loja.Nome, loja.Cnpj, loja.Ie, loja.Endereco, loja.Bairro,
                    loja.Cep, loja.Cidade, loja.Uf, loja.Fone);
            }
            catch (Exception e)
            {
                throw new DadosException("Loja", e.Message, e);
            }
        }

        public void atualizar(Loja loja)
        {
            try
            {
                tb_lojaTA.Update(loja.Nome, loja.Cnpj, loja.Ie, loja.Endereco, loja.Bairro,
                    loja.Cep, loja.Cidade, loja.Uf, loja.Fone, loja.CodLoja);
            }
            catch (Exception e)
            {
                throw new DadosException("Loja", e.Message, e);
            }
        }

        public void remover(Int32 codloja)
        {
            try
            {
                tb_lojaTA.Delete(codloja);
            }
            catch (Exception e)
            {
                throw new DadosException("Loja", e.Message, e);
            }
        }
    }
}
