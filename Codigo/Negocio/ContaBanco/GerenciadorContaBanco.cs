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
    public class GerenciadorContaBanco 
    {
        private static GerenciadorContaBanco gContaBanco;
        private static tb_conta_bancoTableAdapter tb_conta_bancoTA;
        
        public static GerenciadorContaBanco getInstace()
        {
            if (gContaBanco == null)
            {
                gContaBanco = new GerenciadorContaBanco();
                tb_conta_bancoTA = new tb_conta_bancoTableAdapter();
            }
            return gContaBanco;
        }

        public Int64 inserir(ContaBanco contaBanco)
        {
            try
            {
                tb_conta_bancoTA.Insert(contaBanco.NumeroConta, contaBanco.Agencia,
                    contaBanco.Descricao, contaBanco.Saldo.ToString(), contaBanco.CodBanco);
                return 0;
            }
            catch (Exception e)
            {
                throw new DadosException("Conta do Banco", e.Message, e);
            }
        }

        public void atualizar(ContaBanco contaBanco)
        {
            try
            {
                tb_conta_bancoTA.Update(contaBanco.NumeroConta, contaBanco.Agencia, contaBanco.Descricao, contaBanco.Saldo,
                    contaBanco.CodBanco, contaBanco.CodContaBanco);
            }
            catch (Exception e)
            {
                throw new DadosException("Conta do Banco", e.Message, e);
            }
        }

        public void remover(Int32 codcontaBanco)
        {
            if (codcontaBanco == 1)
                throw new NegocioException("A conta bancária/Caixa não pode ser excluída.");
            try
            {
                tb_conta_bancoTA.Delete(codcontaBanco);
            }
            catch (Exception e)
            {
                throw new DadosException("Conta do Banco", e.Message, e);
            }
        }

        public void atualizaSaldo(Int32 codContaBanco, Decimal valor)
        {
            try
            {
                tb_conta_bancoTA.UpdateSaldoConta(valor, codContaBanco);
            }
            catch (Exception e)
            {
                throw new DadosException("Conta do Banco", e.Message, e);
            }
        }
    }
}