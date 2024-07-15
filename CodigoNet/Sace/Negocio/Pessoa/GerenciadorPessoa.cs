using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;
using Util;

namespace Negocio
{
    public static class GerenciadorPessoa
    {
        /// <summary>
        /// Insere uma pessoa no banco de dados
        /// </summary>
        /// <param name="pessoa"></param>
        /// <returns></returns>
        public static long Inserir(Pessoa pessoa)
        {
            try
            {
                ValidarCpfCnpj(pessoa);

                if (string.IsNullOrEmpty(pessoa.Nome) || string.IsNullOrEmpty(pessoa.NomeFantasia))
                    throw new NegocioException("O nome e o nome fantasia da pessoa não podem ficar em branco.");
                if (!pessoa.CpfCnpj.Trim().Equals(""))
                {
                    int countPessoasCpfCnpj = ObterPorCpfCnpjEquals(pessoa.CpfCnpj).Count();
                    if (countPessoasCpfCnpj > 0)
                        throw new NegocioException("O CPF/CNPJ já está cadastrado na base de dados.");
                }

                using (var context = new SaceContext())
                {
                    var _pessoa = new TbPessoa();
                    Atribuir(pessoa, _pessoa);
                    context.Add(_pessoa);
                    context.SaveChanges();
                    return _pessoa.CodPessoa;
                }
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
        public static void Atualizar(Pessoa pessoa)
        {
            ValidarCpfCnpj(pessoa);

            if (pessoa.CodPessoa == UtilConfig.Default.CLIENTE_PADRAO)
                throw new NegocioException("Os dados dessa pessoa não podem ser alterados ou removidos");
            if (pessoa.Nome.Trim().Equals("") || pessoa.NomeFantasia.Trim().Equals(""))
                throw new NegocioException("O nome e o nome fantasia da pessoa não podem ficar em branco.");

            try
            {
                using (var context = new SaceContext())
                {
                    var _pessoa = context.TbPessoas.FirstOrDefault(p => p.CodPessoa == pessoa.CodPessoa);
                    if (_pessoa != null)
                    {
                        if (!pessoa.CpfCnpj.Trim().Equals(""))
                        {
                            IEnumerable<Pessoa> listaPessoas = ObterPorCpfCnpjEquals(pessoa.CpfCnpj);
                            foreach (Pessoa p in listaPessoas)
                            {
                                if (p.CodPessoa != pessoa.CodPessoa)
                                    throw new NegocioException("O CPF/CNPJ já está cadastrado na base de dados.");
                            }
                        }

                        Atribuir(pessoa, _pessoa);
                        context.Update(_pessoa);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new NegocioException("Não foi possível encontrar a pessoa para atualização dos dados.");
                    }
                }
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
        public static void Remover(long codPessoa)
        {
            if (codPessoa == UtilConfig.Default.CLIENTE_PADRAO)
                throw new NegocioException("Essa pessoa não pode ser removida.");

            try
            {
                using (var context = new SaceContext())
                {
                    var _pessoa = context.TbPessoas.FirstOrDefault(p => p.CodPessoa == codPessoa);
                    if (_pessoa != null)
                    {
                        context.Remove(_pessoa);
                        context.SaveChanges();
                    }
                }
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
        public static void InserirContato(ContatoPessoa contatoPessoa)
        {
            try
            {
                using (var context = new SaceContext())
                {
                    var pessoa = context.TbPessoas.FirstOrDefault(p => p.CodPessoa == contatoPessoa.CodPessoa);

                    if (pessoa != null)
                    {
                        var contato = new TbPessoa();
                        contato.CodPessoa = contatoPessoa.CodPessoaContato;
                        contato = context.TbPessoas.Find(contato);

                        if (contato != null)
                        {
                            pessoa.CodPessoas.Add(contato);
                            context.Attach(contato);
                            context.SaveChanges();
                        }
                    }
                }
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
        public static void RemoverContato(ContatoPessoa contatoPessoa)
        {
            try
            {
                using (var context = new SaceContext())
                {
                    var pessoa = context.TbPessoas.FirstOrDefault(p => p.CodPessoa == contatoPessoa.CodPessoa);

                    if (pessoa != null)
                    {
                        var contato = context.TbPessoas.FirstOrDefault(c => c.CodPessoa == contatoPessoa.CodPessoaContato);
                        if (contato != null)
                        {
                            pessoa.CodPessoas.Remove(contato);
                            context.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new DadosException("Contato Pessoa", e.Message, e);
            }
        }

        private static IQueryable<Pessoa> GetQuery()
        {
            using (var context = new SaceContext())
            {
                var query = from pessoa in context.TbPessoas
                            select new Pessoa
                            {
                                Bairro = pessoa.Bairro,
                                Cep = pessoa.Cep,
                                Cidade = pessoa.Cidade,
                                CodPessoa = pessoa.CodPessoa,
                                Complemento = pessoa.Complemento,
                                CpfCnpj = pessoa.CpfCnpj,
                                EhFabricante = pessoa.EhFabricante,
                                Email = pessoa.Email,
                                Endereco = pessoa.Endereco,
                                Fone1 = pessoa.Fone1,
                                Fone2 = pessoa.Fone2,
                                Fone3 = pessoa.Fone3,
                                Ie = pessoa.Ie,
                                IeSubstituto = pessoa.IeSubstituto,
                                ImprimirCF = pessoa.ImprimirCf,
                                ImprimirDAV = (bool)pessoa.ImprimirDav,
                                LimiteCompra = (decimal)pessoa.LimiteCompra,
                                Nome = pessoa.Nome,
                                NomeFantasia = pessoa.NomeFantasia,
                                Numero = pessoa.Numero,
                                Observacao = pessoa.Observacao,
                                Tipo = pessoa.Tipo,
                                Uf = pessoa.Uf,
                                ValorComissao = (decimal)pessoa.ValorComissao,
                                CodMunicipioIBGE = pessoa.CodMunicipiosIbge,
                                NomeMunicipioIBGE = pessoa.CodMunicipiosIbgeNavigation.Municipio,
                                BloquearCrediario = pessoa.BloquearCrediario
                            };
                return query.AsNoTracking();
            }
        }

        /// <summary>
        /// Obtém todos as pessoas cadastradas
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Pessoa> ObterTodos()
        {
            return GetQuery().OrderBy(p => p.CodPessoa).ToList();
        }


        /// <summary>
        /// Obter pelo código da pessoa
        /// </summary>
        /// <param name="codPessoa"></param>
        /// <returns></returns>
        public static IEnumerable<Pessoa> Obter(long codPessoa)
        {
            return GetQuery().Where(pessoa => pessoa.CodPessoa == codPessoa).ToList();
        }

        /// <summary>
        /// Obter pelo tipo da pessoa
        /// </summary>
        /// <param name="codPessoa"></param>
        /// <returns></returns>
        public static IEnumerable<Pessoa> ObterPorTipoPessoa(string tipoPessoa)
        {
            return GetQuery().Where(pessoa => pessoa.Tipo.Equals(tipoPessoa)).OrderBy(p => p.NomeFantasia).ToList();
        }


        /// <summary>
        /// Obter pelo código da pessoa
        /// </summary>
        /// <param name="codPessoa"></param>
        /// <returns></returns>
        public static IEnumerable<Pessoa> ObterPorNome(string nome)
        {
            return GetQuery().Where(pessoa => pessoa.Nome.StartsWith(nome)).OrderBy(p => p.Nome).ToList();
        }

        /// <summary>
        /// Obter pelo código da pessoa
        /// </summary>
        /// <param name="codPessoa"></param>
        /// <returns></returns>
        public static IEnumerable<Pessoa> ObterPorNomeFantasia(string nomefantasia)
        {
            return GetQuery().Where(pessoa => pessoa.NomeFantasia.StartsWith(nomefantasia)).OrderBy(p => p.NomeFantasia).ToList();
        }

        /// <summary>
        /// Obter pelo cpf/cnpj da pessoa
        /// </summary>
        /// <param name="codPessoa"></param>
        /// <returns></returns>
        public static IEnumerable<Pessoa> ObterPorCpfCnpj(string CpfCnpj)
        {
            return GetQuery().Where(pessoa => pessoa.CpfCnpj.StartsWith(CpfCnpj)).OrderBy(p => p.NomeFantasia).ToList();
        }

        /// <summary>
        /// Obter pelo cpf/cnpj da pessoa
        /// </summary>
        /// <param name="codPessoa"></param>
        /// <returns></returns>
        public static IEnumerable<Pessoa> ObterPorCpfCnpjEquals(string CpfCnpj)
        {
            return GetQuery().Where(pessoa => pessoa.CpfCnpj.Equals(CpfCnpj)).ToList();
        }

        /// <summary>
        /// Obter pelo endereco da pessoa
        /// </summary>
        /// <param name="codPessoa"></param>
        /// <returns></returns>
        public static IEnumerable<Pessoa> ObterPorEndereco(string endereco)
        {
            return GetQuery().Where(pessoa => pessoa.Endereco.StartsWith(endereco)).OrderBy(p => p.NomeFantasia).ToList();
        }

        /// <summary>
        /// Obter pelo bairro da pessoa
        /// </summary>
        /// <param name="codPessoa"></param>
        /// <returns></returns>
        public static IEnumerable<Pessoa> ObterPorBairro(string bairro)
        {
            return GetQuery().Where(pessoa => pessoa.Bairro.StartsWith(bairro)).OrderBy(p => p.NomeFantasia).ToList();
        }

        /// <summary>
        /// Obter pelo bairro da pessoa
        /// </summary>
        /// <param name="codPessoa"></param>
        /// <returns></returns>
        public static IEnumerable<Pessoa> ObterPorNomeFantasiaComContas60DiasAtraso(string nomeFantasia)
        {
            using (var context = new SaceContext())
            {
                DateTime dataHojeMenos30 = DateTime.Now.AddDays(-30);
                var query = from contas in context.TbConta
                            where contas.DataVencimento <= dataHojeMenos30 && contas.CodSituacao == SituacaoConta.SITUACAO_ABERTA
                            select contas.CodPessoa;
                List<long> pessoasEmAtraso = query.Distinct().ToList();

                return GetQuery().Where(pessoa => pessoasEmAtraso.Contains(pessoa.CodPessoa) && pessoa.NomeFantasia.StartsWith(nomeFantasia)).OrderBy(p => p.NomeFantasia).ToList();
            }
        }

        /// <summary>
        /// Obter contatos de uma pessoa
        /// </summary>
        /// <param name="codPessoa"></param>
        /// <returns></returns>
        public static IEnumerable<Pessoa> ObterContatos(long codPessoa)
        {
            using (var context = new SaceContext())
            {
                var _pessoa = new TbPessoa();
                _pessoa.CodPessoa = codPessoa;
                _pessoa = context.TbPessoas.Find(_pessoa);

                if (_pessoa == null)
                {
                    return new List<Pessoa>();
                }
                var query = from pessoa in _pessoa.CodPessoas
                            orderby pessoa.NomeFantasia
                            select new Pessoa
                            {
                                Bairro = pessoa.Bairro,
                                Cep = pessoa.Cep,
                                Cidade = pessoa.Cidade,
                                CodPessoa = pessoa.CodPessoa,
                                Complemento = pessoa.Complemento,
                                CpfCnpj = pessoa.CpfCnpj,
                                EhFabricante = pessoa.EhFabricante,
                                Email = pessoa.Email,
                                Endereco = pessoa.Endereco,
                                Fone1 = pessoa.Fone1,
                                Fone2 = pessoa.Fone2,
                                Fone3 = pessoa.Fone3,
                                Ie = pessoa.Ie,
                                IeSubstituto = pessoa.IeSubstituto,
                                ImprimirCF = pessoa.ImprimirCf,
                                ImprimirDAV = (bool)pessoa.ImprimirDav,
                                LimiteCompra = (decimal)pessoa.LimiteCompra,
                                Nome = pessoa.Nome,
                                NomeFantasia = pessoa.NomeFantasia,
                                Numero = pessoa.Numero,
                                Observacao = pessoa.Observacao,
                                Tipo = pessoa.Tipo,
                                Uf = pessoa.Uf,
                                CodMunicipioIBGE = pessoa.CodMunicipiosIbge,
                                ValorComissao = (decimal)pessoa.ValorComissao
                            };
                return query;
            }
        }

        /// <summary>
        /// Verifica se um cliente possui limite suficiente para realizar uma nova compra
        /// </summary>
        /// <param name="cliente"></param>
        /// <param name="totalNovaCompra"></param>
        /// <returns></returns>
        public static decimal ObterLimiteCompraDisponivel(Pessoa cliente)
        {
            using (var context = new SaceContext())
            {
                IEnumerable<TbContum> listaContasAberto = context.TbConta.Where(conta => conta.CodSituacao.Equals(SituacaoConta.SITUACAO_ABERTA) && conta.CodPessoa == cliente.CodPessoa).ToList();
                List<long> listaCodContas = listaContasAberto.Select(p => p.CodConta).ToList();
                if (listaCodContas != null)
                {
                    IEnumerable<MovimentacaoConta> listaPagamentos = (IEnumerable<MovimentacaoConta>)context.TbMovimentacaoConta.Where(m => listaCodContas.Contains((long)m.CodConta)).ToList();
                    decimal totalValorPagar = listaContasAberto.Sum(c => c.Valor);
                    decimal totalValorPago = listaPagamentos.Sum(m => m.Valor);
                    return cliente.LimiteCompra - totalValorPagar + totalValorPago;
                }
            }
            return 0;
        }

        /// <summary>
        /// Atribui os dados de pessoa à entidade Pessoa
        /// </summary>
        /// <param name="pessoa"></param>
        /// <param name="_pessoa"></param>
        /// <returns></returns>
        private static TbPessoa Atribuir(Pessoa pessoa, TbPessoa _pessoa)
        {
            _pessoa.Bairro = pessoa.Bairro;
            _pessoa.Cep = pessoa.Cep;
            _pessoa.Cidade = pessoa.Cidade;
            _pessoa.CodMunicipiosIbge = pessoa.CodMunicipioIBGE;
            _pessoa.Complemento = pessoa.Complemento;
            _pessoa.CpfCnpj = pessoa.CpfCnpj;
            _pessoa.EhFabricante = pessoa.EhFabricante;
            _pessoa.Email = pessoa.Email;
            _pessoa.Endereco = pessoa.Endereco;
            _pessoa.Fone1 = pessoa.Fone1;
            _pessoa.Fone2 = pessoa.Fone2;
            _pessoa.Fone3 = pessoa.Fone3;
            _pessoa.Ie = pessoa.Ie;
            _pessoa.IeSubstituto = pessoa.IeSubstituto;
            _pessoa.ImprimirCf = pessoa.ImprimirCF;
            _pessoa.ImprimirDav = pessoa.ImprimirDAV;
            _pessoa.LimiteCompra = pessoa.LimiteCompra;
            _pessoa.Nome = pessoa.Nome;
            _pessoa.NomeFantasia = pessoa.NomeFantasia;
            _pessoa.Numero = pessoa.Numero;
            _pessoa.Observacao = pessoa.Observacao;
            _pessoa.Tipo = pessoa.Tipo;
            _pessoa.Uf = pessoa.Uf;
            _pessoa.ValorComissao = pessoa.ValorComissao;
            _pessoa.BloquearCrediario = pessoa.BloquearCrediario;
            return _pessoa;
        }

        public static void SubstituirPessoa(long codPessoaExcluir, long codPessoaManter)
        {
            using (var context = new SaceContext())
            {
                var transaction = context.Database.BeginTransaction();
                try
                {
                    // substitui todas as saídas
                    var queryProduto = from produto in context.TbProdutos
                                       where (produto.CodFabricante == codPessoaExcluir)
                                       select produto;
                    foreach (TbProduto _produto in queryProduto)
                    {
                        _produto.CodFabricante = codPessoaManter;
                        context.Update(_produto);
                    }

                    context.SaveChanges();


                    // substitui todas as saídas
                    var querySaidas = from saida in context.TbSaida
                                      where (saida.CodCliente == codPessoaExcluir ||
                                            saida.CodEmpresaFrete == codPessoaExcluir || saida.CodProfissional == codPessoaExcluir)
                                      select saida;
                    foreach (TbSaidum _saida in querySaidas)
                    {
                        _saida.CodCliente = codPessoaManter;
                        _saida.CodEmpresaFrete = codPessoaManter;
                        _saida.CodProfissional = codPessoaManter;
                        context.Update(_saida);
                    }
                    context.SaveChanges();

                    // Substituti todas as entradas
                    var queryEntrada = from entrada in context.TbEntrada
                                       where entrada.CodEmpresaFrete == codPessoaExcluir ||
                                            entrada.CodFornecedor == codPessoaExcluir
                                       select entrada;
                    foreach (TbEntradum _entrada in queryEntrada)
                    {
                        _entrada.CodEmpresaFrete = codPessoaManter;
                        _entrada.CodFornecedor = codPessoaManter;
                        context.Update(_entrada);
                    }
                    context.SaveChanges();

                    // Substituti todas as contas dessa pessoa
                    var queryConta = from conta in context.TbConta
                                     where conta.CodPessoa == codPessoaExcluir
                                     select conta;
                    foreach (TbContum _conta in queryConta)
                    {
                        _conta.CodPessoa = codPessoaManter;
                        context.Update(_conta);
                    }
                    context.SaveChanges();

                    // Substituti todas as contas dessa pessoa
                    var queryMovimentacaoConta = from movimentacaoConta in context.TbMovimentacaoConta
                                                 where movimentacaoConta.CodResponsavel == codPessoaExcluir
                                                 select movimentacaoConta;
                    foreach (TbMovimentacaoContum _movimentacaoConta in queryMovimentacaoConta)
                    {
                        _movimentacaoConta.CodResponsavel = codPessoaManter;
                        context.Update(_movimentacaoConta);
                    }

                    context.SaveChanges();

                    // Exclui Pessoa
                    Remover(codPessoaExcluir);

                    transaction.Commit();

                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new DadosException("Pessoa", e.Message, e);
                }
            }
        }
    }
}
