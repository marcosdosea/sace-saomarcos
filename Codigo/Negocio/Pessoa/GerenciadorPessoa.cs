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
    public class GerenciadorPessoa : IGerenciadorPessoa
    {
        private static IGerenciadorPessoa gPessoa;
        private static tb_pessoaTableAdapter tb_pessoaTA;
        
        public static IGerenciadorPessoa getInstace()
        {
            if (gPessoa == null)
            {
                gPessoa = new GerenciadorPessoa();
                tb_pessoaTA = new tb_pessoaTableAdapter();
            }
            return gPessoa;
        }

        public void inserir(Pessoa pessoa)
        {
            try
            {
                tb_pessoaTA.Insert(pessoa.Nome, pessoa.CpfCnpj, pessoa.Ie, pessoa.Endereco, pessoa.Cep, pessoa.Bairro,
                    pessoa.Cidade, pessoa.Uf, pessoa.Fone1, pessoa.Fone2, pessoa.Fone3, pessoa.LimiteCompra, 
                    pessoa.ValorComissao, pessoa.Observacao, pessoa.Tipo.ToString());
            }
            catch (Exception e)
            {
                throw new DadosException("Pessoa", e.Message, e);
            }
        }

        public void atualizar(Pessoa pessoa)
        {
            try
            {
                tb_pessoaTA.Update(pessoa.Nome, pessoa.CpfCnpj, pessoa.Ie, pessoa.Endereco, pessoa.Cep, pessoa.Bairro,
                    pessoa.Cidade, pessoa.Uf, pessoa.Fone1, pessoa.Fone2, pessoa.Fone3, pessoa.LimiteCompra, pessoa.ValorComissao,
                    pessoa.Observacao, pessoa.Tipo.ToString(), pessoa.CodPessoa);
            }
            catch (Exception e)
            {
                throw new DadosException("Pessoa", e.Message, e);
            }
        }

        public void remover(Int64 codpessoa)
        {
            try
            {
                tb_pessoaTA.Delete(codpessoa);
            }
            catch (Exception e)
            {
                throw new DadosException("Pessoa", e.Message, e);
            }
        }
    }
}
