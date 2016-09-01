using System;
using System.Collections.Generic;
using System.Linq;
using Dados;
using Dominio;
using Util;

namespace Negocio
{
    public class GerenciadorPessoa
    {
        private static GerenciadorPessoa gPessoa;
        
        public static GerenciadorPessoa GetInstance()
        {
            if (gPessoa == null)
            {
                gPessoa = new GerenciadorPessoa();
            }
            return gPessoa;
        }

        /// <summary>
        /// Insere uma pessoa no banco de dados
        /// </summary>
        /// <param name="pessoa"></param>
        /// <returns></returns>
        public Int64 Inserir(Pessoa pessoa)
        {
            try
            {
                ValidarCpfCnpj(pessoa);
                var repPessoa = new RepositorioGenerico<PessoaE>();

                if (string.IsNullOrEmpty(pessoa.Nome) || string.IsNullOrEmpty(pessoa.NomeFantasia))
                    throw new NegocioException("O nome e o nome fantasia da pessoa não podem ficar em branco.");
                if (!pessoa.CpfCnpj.Trim().Equals(""))
                {
                    int countPessoasCpfCnpj = GerenciadorPessoa.GetInstance().ObterPorCpfCnpjEquals(pessoa.CpfCnpj).Count();
                    if (countPessoasCpfCnpj > 0)
                        throw new NegocioException("O CPF/CNPJ já está cadastrado na base de dados.");
                }


                PessoaE _pessoa = new PessoaE(); 
                Atribuir(pessoa, _pessoa);
               
                repPessoa.Inserir(_pessoa);
                repPessoa.SaveChanges();
                return _pessoa.codPessoa;
            }
            catch (Exception e)
            {
                throw new DadosException("Pessoa", e.Message, e);
            }
        }

        private static void ValidarCpfCnpj(Pessoa pessoa)
        {
            if (!string.IsNullOrEmpty(pessoa.CpfCnpj))
            {
                bool validouCpfCnpj = false;
                if (pessoa.Tipo.Equals(Pessoa.PESSOA_FISICA))
                    validouCpfCnpj = Validacoes.ValidaCPF(pessoa.CpfCnpj);
                else
                    validouCpfCnpj = Validacoes.ValidaCNPJ(pessoa.CpfCnpj);
                if (!validouCpfCnpj)
                    throw new NegocioException("O cpf/cnpj do cliente está incorreto. Favor verificar numeracao.");
            }
        }

        /// <summary>
        /// Atualiza os dados de um pessoa
        /// </summary>
        /// <param name="pessoa"></param>
        public void Atualizar(Pessoa pessoa)
        {
            ValidarCpfCnpj(pessoa);
            var repPessoa = new RepositorioGenerico<PessoaE>();

            if (pessoa.CodPessoa == Global.CLIENTE_PADRAO)
                throw new NegocioException("Os dados dessa pessoa não podem ser alterados ou removidos");
            if (pessoa.Nome.Trim().Equals("") || pessoa.NomeFantasia.Trim().Equals(""))
                throw new NegocioException("O nome e o nome fantasia da pessoa não podem ficar em branco.");
            try
            {
                PessoaE _pessoa = repPessoa.ObterEntidade(p => p.codPessoa == pessoa.CodPessoa);


                if (!pessoa.CpfCnpj.Trim().Equals(""))
                {
                    IEnumerable<Pessoa> listaPessoas = GerenciadorPessoa.GetInstance().ObterPorCpfCnpjEquals(pessoa.CpfCnpj);
                    foreach(Pessoa p in listaPessoas) {
                        if (p.CodPessoa != pessoa.CodPessoa)
                           throw new NegocioException("O CPF/CNPJ já está cadastrado na base de dados.");
                    }
                }

                
                Atribuir(pessoa, _pessoa);
                repPessoa.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DadosException("Pessoa", e.Message, e);
            }
        }

        /// <summary>
        /// Remove os dados de uma pessoa
        /// </summary>
        /// <param name="codpessoa"></param>
        public void Remover(Int64 codpessoa)
        {
            var repPessoa = new RepositorioGenerico<PessoaE>();

            if (codpessoa == Global.CLIENTE_PADRAO)
                throw new NegocioException("Essa pessoa não pode ser removida.");

            try
            {
                repPessoa.Remover(pessoa => pessoa.codPessoa == codpessoa);
                repPessoa.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DadosException("Pessoa", e.Message, e);
            }
        }

        /// <summary>
        /// Associa um contato a uma pessoa
        /// </summary>
        /// <param name="contatoPessoa"></param>
        /// <returns></returns>
        public Int64 InserirContato(ContatoPessoa contatoPessoa)
        {
            try
            {
                var repPessoa = new RepositorioGenerico<PessoaE>();

                PessoaE pessoa = repPessoa.ObterEntidade(p => p.codPessoa == contatoPessoa.CodPessoa);
                pessoa.tb_pessoa2.Add(repPessoa.ObterEntidade(p => p.codPessoa == contatoPessoa.CodPessoaContato));

                repPessoa.Attach(pessoa);
                repPessoa.SaveChanges();
                return 0;
            }
            catch (Exception e)
            {
                throw new DadosException("Contato Pessoa", e.Message, e);
            }
        }

        /// <summary>
        /// Remove contato de uma pessoa
        /// </summary>
        /// <param name="contatoPessoa"></param>
        public void RemoverContato(ContatoPessoa contatoPessoa)
        {
            try
            {
                var repPessoa = new RepositorioGenerico<PessoaE>();

                PessoaE pessoa = repPessoa.ObterEntidade(p => p.codPessoa == contatoPessoa.CodPessoa);
                PessoaE contato = repPessoa.ObterEntidade(p => p.codPessoa == contatoPessoa.CodPessoaContato);

                pessoa.tb_pessoa2.Remove(contato);
                repPessoa.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DadosException("Contato Pessoa", e.Message, e);
            }
        }

        private IQueryable<Pessoa> GetQuery()
        {
            var repPessoa = new RepositorioGenerico<PessoaE>();

            var saceEntities = (SaceEntities)repPessoa.ObterContexto();
            var query = from pessoa in saceEntities.PessoaSet
                        select new Pessoa
                        {
                            Bairro = pessoa.bairro,
                            Cep = pessoa.cep,
                            Cidade = pessoa.cidade,
                            CodPessoa = pessoa.codPessoa,
                            Complemento = pessoa.complemento,
                            CpfCnpj = pessoa.cpf_Cnpj,
                            EhFabricante = pessoa.ehFabricante,
                            Email = pessoa.email,
                            Endereco = pessoa.endereco,
                            Fone1 = pessoa.fone1,
                            Fone2 = pessoa.fone2,
                            Fone3 = pessoa.fone3,
                            Ie = pessoa.ie,
                            IeSubstituto = pessoa.ieSubstituto,
                            ImprimirCF = pessoa.imprimirCF,
                            ImprimirDAV = pessoa.imprimirDAV,
                            LimiteCompra = (decimal) pessoa.limiteCompra,
                            Nome = pessoa.nome,
                            NomeFantasia = pessoa.nomeFantasia,
                            Numero = pessoa.numero,
                            Observacao = pessoa.observacao,
                            Tipo = pessoa.Tipo,
                            Uf = pessoa.uf,
                            ValorComissao = (decimal) pessoa.valorComissao,
                            CodMunicipioIBGE = pessoa.codMunicipiosIBGE,
                            NomeMunicipioIBGE = pessoa.tb_municipios_ibge.municipio,
                            BloquearCrediario = pessoa.bloquearCrediario
                        };
            return query;
        }

        /// <summary>
        /// Obtém todos as pessoas cadastradas
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Pessoa> ObterTodos()
        {
            return GetQuery().OrderBy(p=> p.CodPessoa).ToList();
        }

       
        /// <summary>
        /// Obter pelo código da pessoa
        /// </summary>
        /// <param name="codPessoa"></param>
        /// <returns></returns>
        public IEnumerable<Pessoa> Obter(Int64 codPessoa)
        {
            return GetQuery().Where(pessoa => pessoa.CodPessoa == codPessoa).ToList();
        }

        /// <summary>
        /// Obter pelo tipo da pessoa
        /// </summary>
        /// <param name="codPessoa"></param>
        /// <returns></returns>
        public IEnumerable<Pessoa> ObterPorTipoPessoa(string tipoPessoa)
        {
            return GetQuery().Where(pessoa => pessoa.Tipo.Equals(tipoPessoa)).OrderBy(p=> p.NomeFantasia).ToList();
        }


        /// <summary>
        /// Obter pelo código da pessoa
        /// </summary>
        /// <param name="codPessoa"></param>
        /// <returns></returns>
        public IEnumerable<Pessoa> ObterPorNome(string nome)
        {
            return GetQuery().Where(pessoa => pessoa.Nome.StartsWith(nome)).OrderBy(p => p.Nome).ToList();
        }

        /// <summary>
        /// Obter pelo código da pessoa
        /// </summary>
        /// <param name="codPessoa"></param>
        /// <returns></returns>
        public IEnumerable<Pessoa> ObterPorNomeFantasia(string nomefantasia)
        {
            return GetQuery().Where(pessoa => pessoa.NomeFantasia.StartsWith(nomefantasia)).OrderBy(p => p.NomeFantasia).ToList();
        }

        /// <summary>
        /// Obter pelo cpf/cnpj da pessoa
        /// </summary>
        /// <param name="codPessoa"></param>
        /// <returns></returns>
        public IEnumerable<Pessoa> ObterPorCpfCnpj(string CpfCnpj)
        {
            return GetQuery().Where(pessoa => pessoa.CpfCnpj.StartsWith(CpfCnpj)).OrderBy(p => p.NomeFantasia).ToList();
        }

        /// <summary>
        /// Obter pelo cpf/cnpj da pessoa
        /// </summary>
        /// <param name="codPessoa"></param>
        /// <returns></returns>
        public IEnumerable<Pessoa> ObterPorCpfCnpjEquals(string CpfCnpj)
        {
            return GetQuery().Where(pessoa => pessoa.CpfCnpj.Equals(CpfCnpj)).ToList();
        }

        /// <summary>
        /// Obter pelo endereco da pessoa
        /// </summary>
        /// <param name="codPessoa"></param>
        /// <returns></returns>
        public IEnumerable<Pessoa> ObterPorEndereco(string endereco)
        {
            return GetQuery().Where(pessoa => pessoa.Endereco.StartsWith(endereco)).OrderBy(p => p.NomeFantasia).ToList();
        }

        /// <summary>
        /// Obter pelo bairro da pessoa
        /// </summary>
        /// <param name="codPessoa"></param>
        /// <returns></returns>
        public IEnumerable<Pessoa> ObterPorBairro(string bairro)
        {
            return GetQuery().Where(pessoa => pessoa.Bairro.StartsWith(bairro)).OrderBy(p => p.NomeFantasia).ToList();
        }

        /// <summary>
        /// Obter pelo bairro da pessoa
        /// </summary>
        /// <param name="codPessoa"></param>
        /// <returns></returns>
        public IEnumerable<Pessoa> ObterPorNomeFantasiaComContas60DiasAtraso(string nomeFantasia)
        {
            var repPessoa = new RepositorioGenerico<PessoaE>();

            var saceEntities = (SaceEntities)repPessoa.ObterContexto();
            var query = from contas in saceEntities.ContaSet
                        where contas.dataVencimento <= DateTime.Now && contas.codSituacao == SituacaoConta.SITUACAO_ABERTA
                        select contas.codPessoa;
            List<long> pessoasEmAtraso = query.Distinct().ToList();

            return GetQuery().Where(pessoa => pessoasEmAtraso.Contains(pessoa.CodPessoa) && pessoa.NomeFantasia.StartsWith(nomeFantasia)).OrderBy(p => p.NomeFantasia).ToList();
        }

        /// <summary>
        /// Obter contatos de uma pessoa
        /// </summary>
        /// <param name="codPessoa"></param>
        /// <returns></returns>
        public IEnumerable<Pessoa> ObterContatos(long codPessoa)
        {
            var repPessoa = new RepositorioGenerico<PessoaE>();

            var saceEntities = (SaceEntities)repPessoa.ObterContexto();
            PessoaE _pessoa = repPessoa.ObterPrimeiro(p => p.codPessoa == codPessoa);

            if (_pessoa == null)
            {
                return new List<Pessoa>();
            }
            var query = from pessoa in _pessoa.tb_pessoa2
                        orderby pessoa.nomeFantasia
                        select new Pessoa
                        {
                            Bairro = pessoa.bairro,
                            Cep = pessoa.cep,
                            Cidade = pessoa.cidade,
                            CodPessoa = pessoa.codPessoa,
                            Complemento = pessoa.complemento,
                            CpfCnpj = pessoa.cpf_Cnpj,
                            EhFabricante = pessoa.ehFabricante,
                            Email = pessoa.email,
                            Endereco = pessoa.endereco,
                            Fone1 = pessoa.fone1,
                            Fone2 = pessoa.fone2,
                            Fone3 = pessoa.fone3,
                            Ie = pessoa.ie,
                            IeSubstituto = pessoa.ieSubstituto,
                            ImprimirCF = pessoa.imprimirCF,
                            ImprimirDAV = pessoa.imprimirDAV,
                            LimiteCompra = (decimal) pessoa.limiteCompra,
                            Nome = pessoa.nome,
                            NomeFantasia = pessoa.nomeFantasia,
                            Numero = pessoa.numero,
                            Observacao = pessoa.observacao,
                            Tipo = pessoa.Tipo,
                            Uf = pessoa.uf,
                            CodMunicipioIBGE = pessoa.codMunicipiosIBGE,
                            ValorComissao = (decimal) pessoa.valorComissao
                        };
            return query;
        
        }

        /// <summary>
        /// Verifica se um cliente possui limite suficiente para realizar uma nova compra
        /// </summary>
        /// <param name="cliente"></param>
        /// <param name="totalNovaCompra"></param>
        /// <returns></returns>
        public decimal ObterLimiteCompraDisponivel(Pessoa cliente)
        {
            IEnumerable<Conta> listaContasAberto = GerenciadorConta.GetInstance(null).ObterPorSituacaoPessoa(SituacaoConta.SITUACAO_ABERTA, cliente.CodPessoa);
            IEnumerable<long> listaCodContas = listaContasAberto.Select(p =>  p.CodConta );
            IEnumerable<MovimentacaoConta> listaPagamentos = GerenciadorMovimentacaoConta.GetInstance(null).ObterPorContas( new List<long>(listaCodContas));
            decimal totalValorPagar = listaContasAberto.Sum(c => c.ValorPagar);
            decimal totalValorPago = listaPagamentos.Sum(m => m.Valor);

            return cliente.LimiteCompra - totalValorPagar + totalValorPago;
        }

        /// <summary>
        /// Atribui os dados de pessoa à entidade Pessoa
        /// </summary>
        /// <param name="pessoa"></param>
        /// <param name="_pessoa"></param>
        /// <returns></returns>
        private PessoaE Atribuir(Pessoa pessoa, PessoaE _pessoa)
        {
            _pessoa.bairro = pessoa.Bairro;
            _pessoa.cep = pessoa.Cep;
            _pessoa.cidade = pessoa.Cidade;
            _pessoa.codMunicipiosIBGE = pessoa.CodMunicipioIBGE;
            _pessoa.complemento = pessoa.Complemento;
            _pessoa.cpf_Cnpj = pessoa.CpfCnpj;
            _pessoa.ehFabricante = pessoa.EhFabricante;
            _pessoa.email = pessoa.Email;
            _pessoa.endereco = pessoa.Endereco;
            _pessoa.fone1 = pessoa.Fone1;
            _pessoa.fone2 = pessoa.Fone2;
            _pessoa.fone3 = pessoa.Fone3;
            _pessoa.ie = pessoa.Ie;
            _pessoa.ieSubstituto = pessoa.IeSubstituto;
            _pessoa.imprimirCF = pessoa.ImprimirCF;
            _pessoa.imprimirDAV = pessoa.ImprimirDAV;
            _pessoa.limiteCompra = pessoa.LimiteCompra;
            _pessoa.nome = pessoa.Nome;
            _pessoa.nomeFantasia = pessoa.NomeFantasia;
            _pessoa.numero = pessoa.Numero;
            _pessoa.observacao = pessoa.Observacao;
            _pessoa.Tipo = pessoa.Tipo;
            _pessoa.uf = pessoa.Uf;
            _pessoa.valorComissao = pessoa.ValorComissao;
            _pessoa.bloquearCrediario = pessoa.BloquearCrediario;
            return _pessoa;
        }

        public void SubstituirPessoa(long codPessoaExcluir, long codPessoaManter)
        {
            try
            {
                var repPessoa = new RepositorioGenerico<PessoaE>();
                var saceEntities = (SaceEntities)repPessoa.ObterContexto();

                // substitui todas as saídas
                var querySaidas = from saida in saceEntities.tb_saida
                                  where (saida.codCliente == codPessoaExcluir ||
                                        saida.codEmpresaFrete == codPessoaExcluir || saida.codProfissional == codPessoaExcluir)
                                  select saida;
                foreach (tb_saida _saida in querySaidas)
                {
                    _saida.codCliente = codPessoaManter;
                    _saida.codEmpresaFrete = codPessoaManter;
                    _saida.codProfissional = codPessoaManter;
                }
                repPessoa.SaveChanges();

                // Substituti todas as entradas
                var queryEntrada = from entrada in saceEntities.EntradaSet
                                   where entrada.codEmpresaFrete == codPessoaExcluir || 
                                        entrada.codFornecedor == codPessoaExcluir
                                   select entrada;
                foreach (EntradaE _entrada in queryEntrada)
                {
                    _entrada.codEmpresaFrete = codPessoaManter;
                    _entrada.codFornecedor = codPessoaManter;
                }
                repPessoa.SaveChanges();

                // Substituti todas as contas dessa pessoa
                var queryConta = from conta in saceEntities.ContaSet
                                   where conta.codPessoa == codPessoaExcluir 
                                   select conta;
                foreach (ContaE _conta in queryConta)
                {
                    _conta.codPessoa = codPessoaManter;
                }
                repPessoa.SaveChanges();

                // Substituti todas as contas dessa pessoa
                var queryMovimentacaoConta = from movimentacaoConta in saceEntities.MovimentacaoContaSet
                                 where movimentacaoConta.codResponsavel == codPessoaExcluir
                                 select movimentacaoConta;
                foreach (MovimentacaoContaE _movimentacaoConta in queryMovimentacaoConta)
                {
                    _movimentacaoConta.codResponsavel = codPessoaManter;
                }
                repPessoa.SaveChanges();

                // Exclui Pessoa
                Remover(codPessoaExcluir);

            }
            catch (Exception e)
            {
                throw new DadosException("Pessoa", e.Message, e);
            }
        }
    }
}
