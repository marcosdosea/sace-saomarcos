using System;
using System.Collections.Generic;
using System.Linq;
using Dados;
using Dominio;
using System.IO;
using Util;
using MySql.Data.MySqlClient;

namespace Negocio
{
    public class GerenciadorCartaoCredito
    {
        private static GerenciadorCartaoCredito gCartaoCredito;

        public static GerenciadorCartaoCredito GetInstance()
        {
            if (gCartaoCredito == null)
            {
                gCartaoCredito = new GerenciadorCartaoCredito();
            }
            return gCartaoCredito;
        }

        /// <summary>
        /// Insere os dados de um cartão de crédito
        /// </summary>
        /// <param name="cartaoCredito"></param>
        /// <returns></returns>
        public Int64 Inserir(CartaoCredito cartaoCredito)
        {
            try
            {
                var repCartaoCredito = new RepositorioGenerico<CartaoCreditoE>();

                CartaoCreditoE _cartaoCredito = new CartaoCreditoE();
                Atribuir(cartaoCredito, _cartaoCredito);

                repCartaoCredito.Inserir(_cartaoCredito);
                repCartaoCredito.SaveChanges();

                return _cartaoCredito.codCartao;
            }
            catch (Exception e)
            {
                throw new DadosException("Cartão de Crédito", e.Message, e);
            }
        }

        /// <summary>
        /// Atualiza os dados de um cartão de crédito
        /// </summary>
        /// <param name="cartaoCredito"></param>
        public void Atualizar(CartaoCredito cartaoCredito)
        {
            try
            {
                var repCartaoCredito = new RepositorioGenerico<CartaoCreditoE>();

                CartaoCreditoE _cartaoCredito = repCartaoCredito.ObterEntidade(cartao => cartao.codCartao == cartaoCredito.CodCartao);
                Atribuir(cartaoCredito, _cartaoCredito);

                repCartaoCredito.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DadosException("Cartão de Crédito", e.Message, e);
            }
        }

        /// <summary>
        /// Remove os dados de um cartão de crédito
        /// </summary>
        /// <param name="codCartaoCredito"></param>
        public void Remover(int codCartaoCredito)
        {
            try
            {
                var repCartaoCredito = new RepositorioGenerico<CartaoCreditoE>();

                if (codCartaoCredito == 1)
                {
                    throw new NegocioException("Esse cartão de crédito não pode ser removido");
                }
                repCartaoCredito.Remover(cartao => cartao.codCartao == codCartaoCredito);
                repCartaoCredito.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DadosException("Cartão de Crédito", e.Message, e);
            }
        }


        /// <summary>
        /// Consulta padrão para retornar dados do cartão de crédito
        /// </summary>
        /// <returns></returns>
        private IQueryable<CartaoCredito> GetQuery()
        {
            var repCartaoCredito = new RepositorioGenerico<CartaoCreditoE>();
            var saceEntities = (SaceEntities)repCartaoCredito.ObterContexto();
            var query = from cartao in saceEntities.CartaoCreditoSet
                        join contaBanco in saceEntities.ContaBancoSet on cartao.codContaBanco equals contaBanco.codContaBanco
                        join pessoa in saceEntities.PessoaSet on cartao.codPessoa equals pessoa.codPessoa

                        select new CartaoCredito
                        {
                            CodCartao = cartao.codCartao,
                            CodContaBanco = cartao.codContaBanco,
                            CodPessoa = (int)cartao.codPessoa,
                            DiaBase = (int)cartao.diaBase,
                            Mapeamento = cartao.mapeamento,
                            Nome = cartao.nome,
                            DescricaoContaBanco = contaBanco.descricao,
                            NomePessoa = pessoa.nomeFantasia,
                            Desconto = cartao.desconto,
                            MapeamentoCappta = cartao.mapeamentoCappta,
                            TipoCartao = cartao.tipoCartao
                        };
            return query;

        }

        /// <summary>
        /// Obtém todos os cartões de crédito cadastrados
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CartaoCredito> ObterTodos()
        {
            return GetQuery().ToList();
        }

        /// <summary>
        /// Obtém os dados do cartão pelo código
        /// </summary>
        /// <param name="codCartaoCredito"></param>
        /// <returns>código do cartão</returns>
        public IEnumerable<CartaoCredito> Obter(Int32 codCartaoCredito)
        {
            return GetQuery().Where(cartao => cartao.CodCartao == codCartaoCredito).ToList();
        }


        /// <summary>
        /// Obtém os dados do cartão pelo código
        /// </summary>
        /// <param name="codCartaoCredito"></param>
        /// <returns>código do cartão</returns>
        public IEnumerable<CartaoCredito> ObterPorMapeamentoCappta(String nomeBandeira)
        {
            return GetQuery().Where(cartao => cartao.MapeamentoCappta == nomeBandeira).ToList();
        }

        /// <summary>
        /// Obtém os dados do cartão pelo nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns>nome do cartão</returns>
        public IEnumerable<CartaoCredito> ObterPorNome(string nome)
        {
            return GetQuery().Where(cartao => cartao.Nome.StartsWith(nome)).ToList();
        }


        public Boolean AtualizarRespostaCartoes(string nomeServidor)
        {
            Boolean atualizou = false;
            DirectoryInfo PastaRetorno = new DirectoryInfo("C://");
            DirectoryInfo PastaBackup = new DirectoryInfo("C://");

            string nomeComputador = System.Windows.Forms.SystemInformation.ComputerName;
            if (nomeComputador.Equals(nomeServidor) && PastaRetorno.Exists)
            {
                // Busca automaticamente todos os arquivos em todos os subdiretórios
                FileInfo[] Files = PastaRetorno.GetFiles("*.TEF", SearchOption.TopDirectoryOnly);
                if (Files.Length == 0)
                {
                    atualizou = true;
                }
                else
                {
                    foreach (FileInfo file in Files)
                    {
                        try
                        {
                            CartaoCreditoAutorizacao autorizacao = new CartaoCreditoAutorizacao();
                            StreamReader reader = new StreamReader(file.FullName);
                            String linha = null;
                            String data = null;
                            while ((linha = reader.ReadLine()) != null)
                            {
                                if (linha.StartsWith("000-000"))
                                    autorizacao.Header = linha.Substring(10);
                                else if (linha.StartsWith("001-000"))
                                    autorizacao.CodIndentificacao = Int32.Parse(linha.Substring(10));
                                else if (linha.StartsWith("002-000"))
                                    autorizacao.CupomFiscal = linha.Substring(10);
                                else if (linha.StartsWith("003-000"))
                                    autorizacao.Valor = Decimal.Parse(linha.Substring(10)) / 100;
                                else if (linha.StartsWith("009-000"))
                                    autorizacao.StatusTransacao = linha.Substring(10);
                                else if (linha.StartsWith("011-000"))
                                    autorizacao.TipoTransacao = int.Parse(linha.Substring(10));
                                else if (linha.StartsWith("012-000"))
                                    autorizacao.NsuTransacao = long.Parse(linha.Substring(10));
                                else if (linha.StartsWith("013-000"))
                                    autorizacao.AutorizacaoTransacao = linha.Substring(10);
                                else if (linha.StartsWith("017-000"))
                                    autorizacao.TipoParcelamento = int.Parse(linha.Substring(10));
                                else if (linha.StartsWith("018-000"))
                                    autorizacao.QuantidadeParcelas = int.Parse(linha.Substring(10));
                                else if (linha.StartsWith("022-000"))
                                    data = linha.Substring(10);
                                else if (linha.StartsWith("023-000"))
                                    autorizacao.DataHoraAutorizacao = DateTime.ParseExact((data + linha.Substring(10)), "ddMMyyyyHHmmss", null);
                                else if (linha.StartsWith("040-000"))
                                    autorizacao.NomeBandeiraCartao = linha.Substring(10);
                            }
                            reader.Close();
                            autorizacao.TipoDocumentoFiscal = Saida.TIPO_DOCUMENTO_ECF;
                            if (autorizacao.Header.Equals("CRT") || autorizacao.Header.Equals("CNC"))
                                InserirAutorizacao(autorizacao);
                            if (PastaBackup.Exists)
                            {
                                file.CopyTo("C://" + file.Name, true);
                                file.Delete();
                            }
                        }
                        catch (Exception e)
                        {
                            // Se houver algum impossibilidade de processa a transação ela fica na pasta. 
                        }
                    }
                }
            }
            return atualizou;
        }


        /// <summary>
        /// Grava autorização e relaciona as saídas
        /// </summary>
        /// <param name="resultadoProcessamento"></param>
        /// <param name="listaSolicitacaoSaida"></param>
        /// <returns></returns>
        private long InserirAutorizacao(CartaoCreditoAutorizacao autorizacao)
        {
            var repAutorizacao = new RepositorioGenerico<tb_autorizacao_cartao>();
            tb_autorizacao_cartao _autorizacao_cartaoE = new tb_autorizacao_cartao();
            try
            {
                _autorizacao_cartaoE.header = autorizacao.Header;
                _autorizacao_cartaoE.codIdentificacao = autorizacao.CodIndentificacao;
                _autorizacao_cartaoE.cupomFiscal = autorizacao.CupomFiscal;
                _autorizacao_cartaoE.tipoDocumentoFiscal = autorizacao.TipoDocumentoFiscal;
                _autorizacao_cartaoE.valor = autorizacao.Valor;
                _autorizacao_cartaoE.nomeBandeiraCartao = autorizacao.NomeBandeiraCartao;
                _autorizacao_cartaoE.statusTransacao = autorizacao.StatusTransacao;
                _autorizacao_cartaoE.tipoTransacao = autorizacao.TipoTransacao;
                _autorizacao_cartaoE.processado = autorizacao.Processado;
                _autorizacao_cartaoE.tipoParcelamento = autorizacao.TipoParcelamento;
                if (autorizacao.StatusTransacao.Equals("0"))
                {
                    _autorizacao_cartaoE.autorizacaoTransacao = autorizacao.AutorizacaoTransacao;
                    _autorizacao_cartaoE.dataHoraAutorizacao = autorizacao.DataHoraAutorizacao;
                    _autorizacao_cartaoE.nsuTransacao = autorizacao.NsuTransacao;
                    _autorizacao_cartaoE.quantidadeParcelas = autorizacao.QuantidadeParcelas == 0 ? 1 : autorizacao.QuantidadeParcelas;
                }
                repAutorizacao.Inserir(_autorizacao_cartaoE);
                repAutorizacao.SaveChanges();

                var saceEntities = (SaceEntities)repAutorizacao.ObterContexto();
                var query = from saida in saceEntities.tb_saida
                            where saida.pedidoGerado.Equals(autorizacao.CupomFiscal)
                            select saida;
                List<tb_saida> listaSaidas = query.ToList();
                foreach (tb_saida saidaE in listaSaidas)
                {
                    _autorizacao_cartaoE.tb_saida.Add(saidaE);
                }
                repAutorizacao.SaveChanges();
            }
            catch (Exception e)
            {
                if (e.InnerException is MySqlException)
                {
                    MySqlException exception = (MySqlException)e.InnerException;
                    if (exception.Number != 1062) // quando a autorização já foi inserida na base não precisa enviar erro.
                        throw new DadosException("Autorização Cartão", e.Message, e);
                }
            }
            return _autorizacao_cartaoE.codAutorizacao;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resultado"></param>
        public void AtualizarPedidosComAutorizacaoCartao()
        {
            var repAutorizacao = new RepositorioGenerico<tb_autorizacao_cartao>();
            var saceEntities = (SaceEntities)repAutorizacao.ObterContexto();
            var query = from autorizacao in saceEntities.tb_autorizacao_cartao
                        where autorizacao.processado.Equals(false)
                        select autorizacao;
            List<tb_autorizacao_cartao> listaAutorizacoes = query.ToList();
            if (listaAutorizacoes.Count > 0)
            {
                List<CartaoCredito> listaCartoes = GerenciadorCartaoCredito.GetInstance().ObterTodos().ToList();
                // Varre todas as transações ainda não processadas
                foreach (tb_autorizacao_cartao autorizacaoCartaoE in listaAutorizacoes)
                {
                    if (!autorizacaoCartaoE.processado)
                    {
                        IEnumerable<tb_autorizacao_cartao> listaAprovadas = listaAutorizacoes.Where(aut => aut.statusTransacao.Equals("0") && aut.cupomFiscal.Equals(autorizacaoCartaoE.cupomFiscal));
                        IEnumerable<tb_autorizacao_cartao> listaNegadas = listaAutorizacoes.Where(aut => !aut.statusTransacao.Equals("0") && aut.cupomFiscal.Equals(autorizacaoCartaoE.cupomFiscal));
                        if (listaAprovadas.Count() > 0)
                        {
                            foreach (tb_autorizacao_cartao autorizacaoAprovada in listaAprovadas)
                            {
                                autorizacaoAprovada.processado = true;
                                List<tb_saida> listaSaidas = null;
                                if (autorizacaoAprovada.tb_saida.Count() == 0)
                                {

                                    var query2 = from saida in saceEntities.tb_saida
                                                 where saida.pedidoGerado.Equals(autorizacaoAprovada.cupomFiscal)
                                                 select saida;
                                    listaSaidas = query2.ToList();
                                    if (listaSaidas.Count == 0)
                                    {
                                        autorizacaoAprovada.processado = false;
                                    }
                                    else
                                    {
                                        foreach (tb_saida saidaE in listaSaidas)
                                        {
                                            autorizacaoAprovada.tb_saida.Add(saidaE);
                                        }
                                    }
                                }
                                repAutorizacao.SaveChanges();


                                foreach (tb_saida saidaE in autorizacaoAprovada.tb_saida)
                                {
                                    String tipoCartaoString = "CREDITO";
                                    if (autorizacaoAprovada.tipoTransacao.Equals(20))
                                        tipoCartaoString = "DEBITO";
                                    if (autorizacaoAprovada.nomeBandeiraCartao == null)
                                        autorizacaoAprovada.nomeBandeiraCartao = "BANESE";
                                    CartaoCredito cartao = listaCartoes.Where(c => c.TipoCartao.Equals(tipoCartaoString) && autorizacaoAprovada.nomeBandeiraCartao.Equals(c.MapeamentoCappta)).ElementAtOrDefault(0);
                                    if (cartao == null)
                                    {
                                        // ajustes nos nomes dos cartões recuperados para que possa ser associado a um cartão cadastrado 
                                        if (autorizacaoAprovada.nomeBandeiraCartao.ToUpper().Equals("HIPER"))
                                            autorizacaoAprovada.nomeBandeiraCartao = "HIPERCARD";
                                        else if (autorizacaoAprovada.nomeBandeiraCartao.ToUpper().Equals("BANESE"))
                                            autorizacaoAprovada.nomeBandeiraCartao = "BANESECARD";
                                        else if (autorizacaoAprovada.nomeBandeiraCartao.ToUpper().Equals("MASTER"))
                                            autorizacaoAprovada.nomeBandeiraCartao = "MASTERCARD";
                                        if (autorizacaoAprovada.nomeBandeiraCartao.ToUpper().Equals("HIPERCARD") && tipoCartaoString.Equals("DEBITO"))
                                            autorizacaoAprovada.nomeBandeiraCartao = "MASTERCARD";

                                        cartao = listaCartoes.Where(c => c.TipoCartao.Equals(tipoCartaoString) && autorizacaoAprovada.nomeBandeiraCartao.Equals(c.MapeamentoCappta)).ElementAtOrDefault(0);
                                        // cartões autorizados não cadastro são processados pela mastercard
                                        if (cartao == null)
                                            cartao = listaCartoes.Where(c => c.TipoCartao.Equals(tipoCartaoString) && c.MapeamentoCappta.Equals("MASTERCARD")).ElementAtOrDefault(0);
                                    }

                                    IEnumerable<SaidaPagamento> listaSaidaPagamento = GerenciadorSaidaPagamento.GetInstance(null).ObterPorSaida(saidaE.codSaida).Where(sp => sp.CodFormaPagamento.Equals(FormaPagamento.CARTAO));
                                    IEnumerable<Conta> listaConta = GerenciadorConta.GetInstance(null).ObterPorSaida(saidaE.codSaida).Where(c => c.FormatoConta.Equals(Conta.FORMATO_CONTA_CARTAO));
                                    if ((listaAprovadas.Count() == 1) && (listaSaidaPagamento.Count() == 1) && (listaConta.Count() == autorizacaoAprovada.quantidadeParcelas))
                                    {
                                        AtualizaFormaPagamentoUnica(autorizacaoAprovada, cartao, listaSaidaPagamento.First(), listaConta);
                                    }
                                    else if (listaAprovadas.Count() == 1)
                                    {
                                        // quando existe mais de uma forma de pagamento associada na saida
                                        AtualizaFormaPagamentoMultipla(autorizacaoAprovada, cartao, listaSaidaPagamento, listaConta);
                                    }
                                }
                                autorizacaoAprovada.processado = true;
                            }
                        }
                        else
                        {
                            if (listaNegadas.Count() > 0)
                            {
                                String cupomFiscal = listaNegadas.First().cupomFiscal;
                                IEnumerable<SaidaPesquisa> listaSaidas = GerenciadorSaida.GetInstance(null).ObterPorCupomFiscal(cupomFiscal);
                                // Cupom Fiscal foi emitido com venda em dinheiro
                                if (listaSaidas.Count() > 0)
                                {
                                    foreach (SaidaPesquisa saidaPesquisa in listaSaidas)
                                    {
                                        Saida saida = GerenciadorSaida.GetInstance(null).Obter(saidaPesquisa.CodSaida);
                                        GerenciadorSaidaPagamento.GetInstance(null).RemoverPorSaida(saida);
                                        SaidaPagamento saidaPagamento = new SaidaPagamento();
                                        saidaPagamento.CodCartaoCredito = Global.CARTAO_LOJA;
                                        saidaPagamento.CodFormaPagamento = FormaPagamento.DINHEIRO;
                                        saidaPagamento.CodSaida = saida.CodSaida;
                                        saidaPagamento.Data = saida.DataSaida;
                                        saidaPagamento.Valor = saida.TotalAVista;
                                        saidaPagamento.CodContaBanco = Global.CAIXA_PADRAO;
                                        saidaPagamento.Parcelas = 1;
                                        List<SaidaPagamento> listaPagamentos = new List<SaidaPagamento>() { saidaPagamento };
                                        GerenciadorSaida.GetInstance(null).RegistrarPagamentosSaida(listaPagamentos, saida);
                                    }

                                }
                                // Cupom Fiscal não foi emitido
                                else
                                {
                                    foreach (SaidaPesquisa saidaPesquisa in listaSaidas)
                                    {
                                        Saida saida = GerenciadorSaida.GetInstance(null).Obter(saidaPesquisa.CodSaida);
                                        if (!saida.TipoSaida.Equals(Saida.TIPO_ORCAMENTO))
                                        {
                                            GerenciadorSaidaPagamento.GetInstance(null).RemoverPorSaida(saida);
                                            GerenciadorSaida.GetInstance(null).RegistrarEstornoEstoque(saida, null);
                                            saida.TipoSaida = Saida.TIPO_ORCAMENTO;
                                            saida.CodSituacaoPagamentos = SituacaoPagamentos.ABERTA;
                                            saida.CupomFiscal = "";
                                            saida.TotalPago = 0;
                                            GerenciadorSaida.GetInstance(null).Atualizar(saida);
                                        }
                                    }
                                }
                            }
                        }
                        foreach (tb_autorizacao_cartao negada in listaNegadas)
                        {
                            negada.processado = true;
                        }
                    }
                    repAutorizacao.SaveChanges();
                }
            }
        }

        private void AtualizaFormaPagamentoUnica(tb_autorizacao_cartao autorizacaoAprovada, CartaoCredito cartao, SaidaPagamento saidaPagamento, IEnumerable<Conta> listaContas)
        {
            saidaPagamento.CodCartaoCredito = cartao.CodCartao;
            saidaPagamento.CodFormaPagamento = FormaPagamento.CARTAO;
            saidaPagamento.Data = (DateTime)autorizacaoAprovada.dataHoraAutorizacao;
            saidaPagamento.NumeroControle = autorizacaoAprovada.nsuTransacao.ToString();
            saidaPagamento.Parcelas = (int)autorizacaoAprovada.quantidadeParcelas;
            saidaPagamento.Valor = autorizacaoAprovada.valor;
            GerenciadorSaidaPagamento.GetInstance(null).Atualizar(saidaPagamento);
            int parcela = 1;
            foreach (Conta conta in listaContas)
            {
                GerenciadorConta.GetInstance(null).Atualizar(cartao.CodPessoa,
                    autorizacaoAprovada.dataHoraAutorizacao.Value.AddDays(cartao.DiaBase * parcela),
                    Conta.FORMATO_CONTA_CARTAO,
                    autorizacaoAprovada.nsuTransacao.ToString(),
                    autorizacaoAprovada.valor, conta.CodConta);
                parcela++;
            }
        }
            
        private void AtualizaFormaPagamentoMultipla(tb_autorizacao_cartao autorizacaoAprovada, CartaoCredito cartao, IEnumerable<SaidaPagamento> pagamentos, IEnumerable<Conta> listaContas)
        {
            SaidaPagamento saidaPagamento = pagamentos.FirstOrDefault(p => p.CodFormaPagamento == FormaPagamento.CARTAO);
            if (saidaPagamento == null)
                saidaPagamento = new SaidaPagamento();
            saidaPagamento.CodCartaoCredito = cartao.CodCartao;
            saidaPagamento.CodFormaPagamento = FormaPagamento.CARTAO;
            saidaPagamento.Data = (DateTime)autorizacaoAprovada.dataHoraAutorizacao;
            saidaPagamento.NumeroControle = autorizacaoAprovada.nsuTransacao.ToString();
            saidaPagamento.Parcelas = (int)autorizacaoAprovada.quantidadeParcelas;
            saidaPagamento.Valor = autorizacaoAprovada.valor;
            
            if (pagamentos.Where(p => p.CodFormaPagamento == FormaPagamento.CARTAO).Count() == 1)
            {
                GerenciadorSaidaPagamento.GetInstance(null).Atualizar(saidaPagamento);
            }

            foreach (Conta conta in listaContas)
            {
                GerenciadorConta.GetInstance(null).Remover(conta.CodConta);
            }
            
            List<SaidaPagamento> listaPagamentos = new List<SaidaPagamento>() { saidaPagamento };
            List<SaidaPesquisa> listaSaidas = GerenciadorSaida.GetInstance(null).ObterPorCupomFiscal(autorizacaoAprovada.cupomFiscal);
            
            foreach (SaidaPesquisa saidaPesquisa in listaSaidas)
            {
                Saida saida = GerenciadorSaida.GetInstance(null).Obter(saidaPesquisa.CodSaida);
                GerenciadorSaidaPagamento.GetInstance(null).RemoverPorSaida(saida);
                GerenciadorSaida.GetInstance(null).RegistrarPagamentosSaida(listaPagamentos, saida);
            }
        }

        private static void RemoverContasSaida(tb_saida saidaE, SaceEntities saceEntities, RepositorioGenerico<ContaE> repConta)
        {
            try
            {
                var query = from contaSet in saceEntities.ContaSet
                            where contaSet.codSaida == saidaE.codSaida
                            select contaSet;

                foreach (ContaE _contaE in query)
                {
                    repConta.Remover(_contaE);
                }
                repConta.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DadosException("Conta", e.Message, e);
            }
        }


        /// <summary>
        /// Atribuição ente entidade e entidade persistente
        /// </summary>
        /// <param name="cartaoCredito"></param>
        /// <param name="_cartaoCredito"></param>
        private void Atribuir(CartaoCredito cartaoCredito, CartaoCreditoE _cartaoCredito)
        {
            _cartaoCredito.codCartao = cartaoCredito.CodCartao;
            _cartaoCredito.codContaBanco = cartaoCredito.CodContaBanco;
            _cartaoCredito.codPessoa = cartaoCredito.CodPessoa;
            _cartaoCredito.diaBase = cartaoCredito.DiaBase;
            _cartaoCredito.mapeamento = cartaoCredito.Mapeamento;
            _cartaoCredito.nome = cartaoCredito.Nome;
            _cartaoCredito.desconto = cartaoCredito.Desconto;
            _cartaoCredito.mapeamentoCappta = cartaoCredito.MapeamentoCappta;
            _cartaoCredito.tipoCartao = cartaoCredito.TipoCartao;
        }

    }
}