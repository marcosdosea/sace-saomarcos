using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using Dados;
using Dominio;
using Util;
using System.Transactions;
using Dominio.Consultas;
using System.Windows.Forms;



namespace Negocio
{
    public class GerenciadorSaida
    {
        private static GerenciadorSaida gSaida;
        private static SaceEntities saceContext;
        private static RepositorioGenerico<tb_saida> repSaida;

        public static GerenciadorSaida GetInstance(SaceEntities context)
        {
            if (gSaida == null)
            {
                gSaida = new GerenciadorSaida();
            }
            if (context == null)
            {
                repSaida = new RepositorioGenerico<tb_saida>();
            }
            else
            {
                repSaida = new RepositorioGenerico<tb_saida>(context);
            }
            saceContext = (SaceEntities)repSaida.ObterContexto();
            return gSaida;
        }

        /// <summary>
        /// Insere dados de uma saída (orçamento/pré-venda/venda/saída depósito)
        /// </summary>
        /// <param name="saida"></param>
        /// <returns></returns>
        public Int64 Inserir(Saida saida)
        {
            try
            {
                tb_saida _saidaE = new tb_saida();
                Atribuir(saida, _saidaE);

                var repSaida = new RepositorioGenerico<tb_saida>();

                repSaida.Inserir(_saidaE);
                repSaida.SaveChanges();

                return _saidaE.codSaida;
            }
            catch (Exception e)
            {
                throw new DadosException("Saída", e.Message, e);
            }
        }


        /// <summary>
        /// Atualiza dados de uma saída (orçamento/pré-venda/venda/saída depósito)
        /// </summary>
        /// <param name="saida"></param>
        public void Atualizar(Saida saida)
        {
            try
            {
                var query = from saidaE in saceContext.tb_saida
                            where saidaE.codSaida == saida.CodSaida
                            select saidaE;

                tb_saida _saidaE = query.FirstOrDefault();
                if (_saidaE != null)
                {
                    Atribuir(saida, _saidaE);
                }

                saceContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DadosException("Saída", e.Message, e);
            }
        }

        /// <summary>
        /// Atualizar situação pagamentos de uma saída
        /// </summary>
        /// <param name="codSituacaoPagamentos"></param>
        /// <param name="codSaida"></param>
        public void AtualizarSituacaoPagamentoPorSaida(int codSituacaoPagamentos, long codSaida)
        {
            try
            {
                var query = from saidaE in saceContext.tb_saida
                            where saidaE.codSaida == codSaida
                            select saidaE;

                foreach (tb_saida _saidaE in query)
                {
                    _saidaE.codSituacaoPagamentos = codSituacaoPagamentos;
                }

                repSaida.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DadosException("Saida", e.Message, e);
            }
        }

        /// <summary>
        /// Atualiza o número da nota fiscal gerada a partir do pedido (cupom fiscal) gerado
        /// </summary>
        /// <param name="nfe"></param>
        /// <param name="pedidoGerado"></param>
        public void AtualizarPorPedido(string nfe, string observacao, long codCliente, string pedidoGerado)
        {
            try
            {
                var query = from saidaE in saceContext.tb_saida
                            where saidaE.pedidoGerado.Equals(pedidoGerado)
                            select saidaE;
                foreach (tb_saida _saidaE in query)
                {
                    _saidaE.nfe = nfe;
                    _saidaE.observacao = observacao;
                    _saidaE.codCliente = codCliente;
                }
                repSaida.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DadosException("Saida", e.Message, e);
            }
        }

        /// <summary>
        /// Atualiza o número da nota fiscal gerada num determinado codigo saida
        /// </summary>
        /// <param name="nfe"></param>
        /// <param name="pedidoGerado"></param>
        public void AtualizarNfePorCodSaida(string nfe, string observacao, long codSaida)
        {
            try
            {
                var query = from saidaE in saceContext.tb_saida
                            where saidaE.codSaida == codSaida
                            select saidaE;
                foreach (tb_saida _saidaE in query)
                {
                    _saidaE.nfe = nfe;
                    _saidaE.observacao = observacao;
                }
                repSaida.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DadosException("Saida", e.Message, e);
            }
        }

        /// <summary>
        /// Atualiza o número da nota fiscal gerada a partir do pedido (cupom fiscal) gerado
        /// </summary>
        /// <param name="nfe"></param>
        /// <param name="pedidoGerado"></param>
        public void AtualizarTipoPedidoGeradoPorSaida(int codTipoSaida, string pedidoGerado, decimal totalAVista, long codSaida)
        {
            try
            {
                var query = from saidaE in saceContext.tb_saida
                            where saidaE.codSaida == codSaida
                            select saidaE;
                foreach (tb_saida _saidaE in query)
                {
                    // atualiza o lucro na venda de acordo com o que foi pago
                    if (_saidaE.totalAVista > totalAVista)
                    {
                        _saidaE.totalLucro -= _saidaE.totalAVista - totalAVista;
                    }
                    else
                    {
                        _saidaE.totalLucro += totalAVista - _saidaE.totalAVista;
                    }
                    _saidaE.codTipoSaida = codTipoSaida;
                    if (string.IsNullOrEmpty(_saidaE.pedidoGerado))
                    {
                        _saidaE.pedidoGerado = pedidoGerado;
                        _saidaE.dataEmissaoDocFiscal = DateTime.Now;
                    }
                    //_saidaE.totalAVista = totalAVista;
                    _saidaE.totalPago = totalAVista;
                    if (_saidaE.total > 0)
                    {
                        _saidaE.desconto = Math.Round(Convert.ToDecimal((1 - (_saidaE.totalAVista / _saidaE.total)) * 100), 2);
                    }
                    else
                    {
                        _saidaE.desconto = 0;
                    }
                }
                saceContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DadosException("Saida", e.Message, e);
            }
        }

        /// <summary>
        /// Remove os dados de uma saída. No caso de vendas e pré-vendas transforma em orçamento.
        /// </summary>
        /// <param name="saida"></param>
        public void Remover(Saida saida)
        {
            DbTransaction transaction = null;
            try
            {
                if (saceContext.Connection.State == System.Data.ConnectionState.Closed)
                    saceContext.Connection.Open();
                transaction = saceContext.Connection.BeginTransaction();

                bool possuiNfeEmitida = GerenciadorNFe.GetInstance().ObterPorSaida(saida.CodSaida).Count() > 0;
                if (possuiNfeEmitida)
                    throw new NegocioException("Não é possível remover saídas / devoluções com NF-e emitidas pelo sistema");

                GerenciadorSaidaPagamento.GetInstance(saceContext).RemoverPorSaida(saida);

                if (saida.TipoSaida.Equals(Saida.TIPO_ORCAMENTO) || saida.TipoSaida.Equals(Saida.TIPO_PRE_DEVOLUCAO_FORNECEDOR) ||
                    saida.TipoSaida.Equals(Saida.TIPO_PRE_DEVOLUCAO_CONSUMIDOR) || saida.TipoSaida.Equals(Saida.TIPO_PRE_REMESSA_DEPOSITO) || 
                    saida.TipoSaida.Equals(Saida.TIPO_PRE_RETORNO_DEPOSITO))
                {
                    var query = from saidaE in saceContext.tb_saida
                                where saidaE.codSaida == saida.CodSaida
                                select saidaE;
                    tb_saida _saidaE = query.FirstOrDefault();
                    saceContext.DeleteObject(_saidaE);
                    saceContext.SaveChanges();
                }
                else if (saida.TipoSaida.Equals(Saida.TIPO_REMESSA_DEPOSITO) || saida.TipoSaida.Equals(Saida.TIPO_DEVOLUCAO_FORNECEDOR)
                    || saida.TipoSaida.Equals(Saida.TIPO_RETORNO_DEPOSITO) || saida.TipoSaida.Equals(Saida.TIPO_REMESSA_CONSERTO))
                {
                    RegistrarEstornoEstoque(saida, null);
                    var query = from saidaE in saceContext.tb_saida
                                where saidaE.codSaida == saida.CodSaida
                                select saidaE;
                    tb_saida _saidaE = query.FirstOrDefault();
                    saceContext.DeleteObject(_saidaE);
                    saceContext.SaveChanges();
                }
                else if (saida.TipoSaida.Equals(Saida.TIPO_DEVOLUCAO_CONSUMIDOR)) 
                {
                    List<SaidaProduto> saidaProdutos = GerenciadorSaidaProduto.GetInstance(null).ObterPorSaida(saida.CodSaida);
                    RegistrarBaixaEstoque(saidaProdutos);
                    var query = from saidaE in saceContext.tb_saida
                                where saidaE.codSaida == saida.CodSaida
                                select saidaE;
                    tb_saida _saidaE = query.FirstOrDefault();
                    saceContext.DeleteObject(_saidaE);
                    saceContext.SaveChanges();
                }
                else if (saida.TipoSaida.Equals(Saida.TIPO_PRE_VENDA) || saida.TipoSaida.Equals(Saida.TIPO_VENDA))
                {
                    RegistrarEstornoEstoque(saida, null);
                    saida.TipoSaida = Saida.TIPO_ORCAMENTO;
                    saida.CupomFiscal = "";
                    Atualizar(saida);
                }
                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw new DadosException("Saída", e.Message, e);
            }
            finally
            {
                saceContext.Connection.Close();
                repSaida.Dispose();
            }
        }
        /// <summary>
        /// Verifica se é possível editar um saída e caso possível tranforma-a em um orçamento
        /// </summary>
        /// <param name="saida"></param>
        public void PrepararEdicaoSaida(Saida saida)
        {
            try
            {
                if (saida.TipoSaida == Saida.TIPO_VENDA)
                    throw new NegocioException("Não é possível editar uma saída cujo Comprovante Fiscal já foi emitido.");

                bool possuiNfeAutorizada = GerenciadorNFe.GetInstance().ObterPorSaida(saida.CodSaida).Where(nfe => nfe.SituacaoNfe.Equals(NfeControle.SITUACAO_AUTORIZADA)).Count() > 0;

                if ((saida.TipoSaida == Saida.TIPO_REMESSA_DEPOSITO) && (possuiNfeAutorizada))
                    throw new NegocioException("Não é possível editar Transferência para Depósito cuja Nota Fiscal já foi emitida e autorizada.");
                if ((saida.TipoSaida == Saida.TIPO_RETORNO_DEPOSITO) && (possuiNfeAutorizada))
                    throw new NegocioException("Não é possível editar um retorno de Depósito cuja Nota Fiscal já foi emitida e autorizada.");
                else if ((saida.TipoSaida == Saida.TIPO_DEVOLUCAO_FORNECEDOR) && (possuiNfeAutorizada))
                    throw new NegocioException("Não é possível editar uma Devolução para Fornecedor cuja Nota Fiscal já foi emitida e autorizada.");
                else if ((saida.TipoSaida == Saida.TIPO_PRE_VENDA) && (saida.CodCliente != Global.CLIENTE_PADRAO))
                {
                    IEnumerable<Conta> contas = GerenciadorConta.GetInstance(null).ObterPorSaida(saida.CodSaida);
                    foreach (Conta conta in contas)
                    {
                        bool possuiMovimentacaoFinanceira = GerenciadorMovimentacaoConta.GetInstance(null).ObterPorConta(conta.CodConta).Count() > 0;
                        if (possuiMovimentacaoFinanceira)
                            throw new NegocioException("Não é possível editar pedidos que já possuem PAGAMENTOS REALIZADOS.");
                    }
                }
                // Se houver documento fiscal aguardando impressão
                if (saida.TipoSaida == Saida.TIPO_PRE_VENDA_NFCE)
                    GerenciadorSolicitacaoDocumento.GetInstance().RemoverSolicitacaoDocumento(saida.CodSaida);
                if (saida.TipoSaida == Saida.TIPO_PRE_VENDA)
                {
                    GerenciadorSolicitacaoDocumento.GetInstance().ExcluirDocumentoFiscal(saida.CodSaida);
                    GerenciadorSolicitacaoDocumento.GetInstance().RemoverSolicitacaoDocumento(saida.CodSaida);
                }

                GerenciadorSaidaPagamento.GetInstance(saceContext).RemoverPorSaida(saida);
                if (saida.TipoSaida.Equals(Saida.TIPO_PRE_VENDA) || saida.TipoSaida.Equals(Saida.TIPO_REMESSA_DEPOSITO) ||
                    saida.TipoSaida.Equals(Saida.TIPO_RETORNO_DEPOSITO) || saida.TipoSaida.Equals(Saida.TIPO_DEVOLUCAO_FORNECEDOR))
                {
                    RegistrarEstornoEstoque(saida, null);
                }
                if (saida.TipoSaida.Equals(Saida.TIPO_DEVOLUCAO_CONSUMIDOR))
                {
                    List<SaidaProduto> saidaProdutos = GerenciadorSaidaProduto.GetInstance(null).ObterPorSaida(saida.CodSaida);
                    RegistrarBaixaEstoque(saidaProdutos);
                }
                if (saida.TipoSaida.Equals(Saida.TIPO_PRE_VENDA) || saida.TipoSaida.Equals(Saida.TIPO_VENDA))
                    saida.TipoSaida = Saida.TIPO_ORCAMENTO;
                else if (saida.TipoSaida.Equals(Saida.TIPO_REMESSA_DEPOSITO))
                    saida.TipoSaida = Saida.TIPO_PRE_REMESSA_DEPOSITO;
                else if (saida.TipoSaida.Equals(Saida.TIPO_DEVOLUCAO_FORNECEDOR))
                    saida.TipoSaida = Saida.TIPO_PRE_DEVOLUCAO_FORNECEDOR;
                else if (saida.TipoSaida.Equals(Saida.TIPO_DEVOLUCAO_CONSUMIDOR))
                    saida.TipoSaida = Saida.TIPO_PRE_DEVOLUCAO_CONSUMIDOR;
                else if (saida.TipoSaida.Equals(Saida.TIPO_RETORNO_DEPOSITO))
                    saida.TipoSaida = Saida.TIPO_PRE_RETORNO_DEPOSITO;
                saida.CodSituacaoPagamentos = SituacaoPagamentos.ABERTA;
                saida.CupomFiscal = "";
                saida.TotalPago = 0;
                Atualizar(saida);
            }
            catch (Exception e)
            {
                throw new DadosException("Saída", e.Message, e);
            }
        }

        /// <summary>
        /// Consulta para retornar dados da entidade
        /// </summary>
        /// <returns></returns>
        private IQueryable<Saida> GetQuery()
        {
            var query = from saida in saceContext.tb_saida
                        select new Saida
                        {
                            BaseCalculoICMS = (decimal)saida.baseCalculoICMS,
                            BaseCalculoICMSSubst = (decimal)saida.baseCalculoICMSSubst,
                            CodCliente = saida.codCliente,
                            CodEmpresaFrete = saida.codEmpresaFrete,
                            CodProfissional = (long)saida.codProfissional,
                            CodEntrada = saida.codEntrada,
                            CodSituacaoPagamentos = saida.codSituacaoPagamentos,
                            CodSaida = saida.codSaida,
                            CpfCnpj = saida.cpf_cnpj,
                            DataSaida = saida.dataSaida,
                            Desconto = (decimal)saida.desconto,
                            DescricaoSituacaoPagamentos = saida.tb_situacao_pagamentos.descricaoSituacaoPagamentos,
                            DescricaoTipoSaida = saida.tb_tipo_saida.descricaoTipoSaida,
                            EntregaRealizada = saida.entregaRealizada,
                            EspecieVolumes = saida.especieVolumes,
                            Marca = saida.marca,
                            Nfe = saida.nfe == null ? "" : saida.nfe,
                            NomeCliente = saida.tb_pessoa.nomeFantasia,// cliente.nomeFantasia,
                            Numero = (decimal)saida.numero,
                            NumeroCartaoVenda = (int)saida.numeroCartaoVenda,
                            OutrasDespesas = (decimal)saida.outrasDespesas,
                            Observacao = saida.observacao,
                            CupomFiscal = saida.pedidoGerado == null ? "" : saida.pedidoGerado,
                            DataEmissaoCupomFiscal = saida.dataEmissaoDocFiscal == null ? saida.dataSaida : (DateTime)saida.dataEmissaoDocFiscal,
                            PesoBruto = (decimal)saida.pesoBruto,
                            PesoLiquido = (decimal)saida.pesoLiquido,
                            QuantidadeVolumes = (decimal)saida.quantidadeVolumes,
                            TipoSaida = saida.codTipoSaida,
                            Total = (decimal)saida.total,
                            TotalAVista = (decimal)saida.totalAVista,
                            TotalLucro = (decimal)saida.totalLucro,
                            TotalNotaFiscal = (decimal)saida.totalNotaFiscal,
                            TotalPago = (decimal)saida.totalPago,
                            Troco = (decimal)saida.troco,
                            ValorFrete = (decimal)saida.valorFrete,
                            ValorICMS = (decimal)saida.valorICMS,
                            ValorICMSSubst = (decimal)saida.valorICMSSubst,
                            ValorIPI = (decimal)saida.valorIPI,
                            ValorSeguro = (decimal)saida.valorSeguro,
                            CodLojaOrigem = saida.codLojaOrigem
                        };
            return query;
        }

        /// <summary>
        /// Consulta para retornar dados da entidade
        /// </summary>
        /// <returns></returns>
        private IQueryable<SaidaPesquisa> GetQueryPesquisa()
        {
            var query = from saida in saceContext.tb_saida
                        select new SaidaPesquisa
                        {
                            CodSaida = saida.codSaida,
                            DataSaida = saida.dataSaida,
                            CodCliente = saida.codCliente,
                            NomeCliente = saida.tb_pessoa.nomeFantasia,// cliente.nomeFantasia,
                            CupomFiscal = saida.pedidoGerado == null ? "" : saida.pedidoGerado,
                            TotalAVista = (decimal)saida.totalAVista,
                            CodSituacaoPagamentos = saida.codSituacaoPagamentos,
                            TipoSaida = saida.codTipoSaida
                        };
            return query;
        }

        /// <summary>
        /// Obtme todos os dados de uma saída
        /// </summary>
        /// <param name="codSaida"></param>
        /// <returns></returns>
        public Saida Obter(Int64 codSaida)
        {
            List<Saida> saidas = GetQuery().Where(saida => saida.CodSaida == codSaida).ToList();
            if (saidas.Count == 1)
                return saidas[0];
            else
                return null;
        }


        /// <summary>
        /// Obtme todos os dados de uma saída
        /// </summary>
        /// <param name="codSaida"></param>
        /// <returns></returns>
        public List<Saida> ObterPorTipoSaida(List<int> listaTiposSaida)
        {
            return GetQuery().Where(saida => listaTiposSaida.Contains(saida.TipoSaida)).OrderBy(s => s.CodSaida).ToList();
        }

        /// <summary>
        /// Obtme todos os dados de uma saída
        /// </summary>
        /// <param name="codSaida"></param>
        /// <returns></returns>
        public List<Saida> ObterSaidaConsumidor(long codSaidaInicial)
        {
            var query = (from saida in saceContext.tb_saida
                         where Saida.LISTA_TIPOS_VENDA.Contains(saida.codTipoSaida) && (saida.codSaida >= codSaidaInicial) 
                         orderby saida.codSaida descending
                         select saida.codSaida).Take(20);
            List<long> listaSaidas = query.ToList();
            // adiciona a lista a saída que está sendo buscada
            //if (codSaidaInicial > 0)
              //  listaSaidas.Add(codSaidaInicial);

            return GetQuery().Where(saida => Saida.LISTA_TIPOS_VENDA.Contains(saida.TipoSaida) && (saida.CodSaida >= listaSaidas.Min() || saida.CodSaida == codSaidaInicial)).OrderBy(s => s.CodSaida).ToList();

        }

        /// <summary>
        /// Obter Troco por Período
        /// </summary>
        /// <param name="codSaida"></param>
        /// <returns></returns>
        public decimal ObterTrocoPorPeriodo(DateTime dataInicial, DateTime dataFinal)
        {
            var query = (from saida in saceContext.tb_saida
                         where (saida.codTipoSaida == Saida.TIPO_PRE_VENDA || saida.codTipoSaida == Saida.TIPO_VENDA) 
                         && (saida.dataSaida >= dataInicial && saida.dataSaida <= dataFinal)
                         select saida.troco);

            return query.Count() > 0 ? (decimal) query.Sum() : 0; 
        }

        /// <summary>
        /// Obtme todos as pré-vendas cujo cupom fiscal não foi emitido
        /// </summary>
        /// <param name="codSaida"></param>
        /// <returns></returns>
        public List<SaidaPesquisa> ObterPorPedido(string pedidoGerado)
        {
            return GetQueryPesquisa().Where(saida => saida.CupomFiscal.StartsWith(pedidoGerado)).OrderBy(s => s.CodSaida).ToList();
        }

        /// <summary>
        /// Obtme todos as pré-vendas cujo cupom fiscal não foi emitido
        /// </summary>
        /// <param name="codSaida"></param>
        /// <returns></returns>
        public List<SaidaPesquisa> ObterPorNomeCliente(string nomeCliente)
        {
            return GetQueryPesquisa().Where(saida => saida.NomeCliente.StartsWith(nomeCliente)).OrderBy(s => s.CodSaida).ToList();
        }

        /// <summary>
        /// Obtme todos as pré-vendas cujo cupom fiscal não foi emitido
        /// </summary>
        /// <param name="codSaida"></param>
        /// <returns></returns>
        public List<SaidaPesquisa> ObterPreVendasPendentes()
        {
            return GetQueryPesquisa().Where(saida => saida.TipoSaida == Saida.TIPO_PRE_VENDA &&
                saida.CupomFiscal.Trim().Equals("") && saida.CodSituacaoPagamentos == SituacaoPagamentos.QUITADA && saida.CodCliente == Global.CLIENTE_PADRAO).OrderBy(s => s.CodSaida).ToList();
        }

        /// <summary>
        /// Obter cfop padrão de um determinado tipo de saída do sistema
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public int ObterCfopTipoSaida(int codTipoSaida)
        {
            var query = from tipoSaida in saceContext.TipoSaidaSet
                        where tipoSaida.codTipoSaida == codTipoSaida
                        select tipoSaida.cfop;
            return query.ToList().ElementAtOrDefault(0);
        }


        /// <summary>
        /// Encerra uma saída fazendo movimentações de estoque e lançamentos no contas a pagar/receber
        /// </summary>
        /// <param name="saida"></param>
        /// <param name="tipo_encerramento"></param>
        public void Encerrar(Saida saida, int tipo_encerramento, List<SaidaPagamento> saidaPagamentos, Pessoa cliente)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                try
                {
                    if (saida.TipoSaida.Equals(Saida.TIPO_ORCAMENTO) && tipo_encerramento.Equals(Saida.TIPO_ORCAMENTO))
                    {
                        saida.TipoSaida = Saida.TIPO_ORCAMENTO;
                        Atualizar(saida);
                    }
                    else if (saida.TipoSaida.Equals(Saida.TIPO_ORCAMENTO) && (tipo_encerramento.Equals(Saida.TIPO_PRE_VENDA) || tipo_encerramento.Equals(Saida.TIPO_PRE_VENDA_NFCE)))
                    {

                        if (cliente.BloquearCrediario)
                        {
                            foreach (SaidaPagamento sp in saidaPagamentos)
                            {
                                if (sp.CodFormaPagamento == FormaPagamento.CREDIARIO)
                                    throw new NegocioException("CREDIÁRIO BLOQUEADO. Autorização da Gerência é necessária.");
                            }
                        }
                        saida.TipoSaida = tipo_encerramento;
                        saida.CodSituacaoPagamentos = SituacaoPagamentos.LANCADOS;

                        List<SaidaProduto> saidaProdutos = GerenciadorSaidaProduto.GetInstance(saceContext).ObterPorSaida(saida.CodSaida);
                        Decimal somaPrecosCusto = RegistrarBaixaEstoque(saidaProdutos);

                        saida.TotalLucro = saida.TotalAVista - somaPrecosCusto;
                        Atualizar(saida);

                        RegistrarPagamentosSaida(saidaPagamentos, saida);
                    }
                    else if (tipo_encerramento.Equals(Saida.TIPO_REMESSA_DEPOSITO))
                    {
                        saida.TipoSaida = Saida.TIPO_REMESSA_DEPOSITO;

                        Loja lojaDestino = GerenciadorLoja.GetInstance().ObterPorPessoa(saida.CodCliente).ElementAt(0);
                        if (lojaDestino.CodLoja.Equals(saida.CodLojaOrigem))
                        {
                            throw new NegocioException("Não pode ser feita transferência de produtos para a mesma loja.");
                        }

                        List<SaidaProduto> saidaProdutos = GerenciadorSaidaProduto.GetInstance(saceContext).ObterPorSaida(saida.CodSaida);
                        Atualizar(saida);
                        RegistrarTransferenciaEstoque(saidaProdutos, Global.LOJA_PADRAO, lojaDestino.CodLoja);
                    }
                    else if (tipo_encerramento.Equals(Saida.TIPO_RETORNO_DEPOSITO))
                    {
                        saida.TipoSaida = Saida.TIPO_RETORNO_DEPOSITO;
                        if (saida.CodLojaOrigem.Equals(Global.LOJA_PADRAO))
                        {
                            throw new NegocioException("Não pode ser feita transferência de produtos para a mesma loja.");
                        }
                        Atualizar(saida);
                        List<SaidaProduto> saidaProdutos = GerenciadorSaidaProduto.GetInstance(saceContext).ObterPorSaida(saida.CodSaida);
                        RegistrarTransferenciaEstoque(saidaProdutos, saida.CodLojaOrigem, Global.LOJA_PADRAO);
                    }
                    else if (tipo_encerramento.Equals(Saida.TIPO_DEVOLUCAO_FORNECEDOR))
                    {
                        saida.TipoSaida = Saida.TIPO_DEVOLUCAO_FORNECEDOR;
                        Atualizar(saida);
                        List<SaidaProduto> saidaProdutos = GerenciadorSaidaProduto.GetInstance(saceContext).ObterPorSaida(saida.CodSaida);
                        RegistrarBaixaEstoque(saidaProdutos);
                        AtualizarCfopProdutosDevolucao(saidaProdutos, saida);
                    }
                    else if (tipo_encerramento.Equals(Saida.TIPO_REMESSA_CONSERTO))
                    {
                        saida.TipoSaida = Saida.TIPO_REMESSA_CONSERTO;
                        Atualizar(saida);
                        List<SaidaProduto> saidaProdutos = GerenciadorSaidaProduto.GetInstance(saceContext).ObterPorSaida(saida.CodSaida);
                        RegistrarBaixaEstoque(saidaProdutos);
                        //AtualizarCfopProdutosDevolucao(saidaProdutos, saida);
                    }
                    transaction.Complete();
                }
                catch (NegocioException ne)
                {
                    throw ne;
                }
                catch (DadosException de)
                {
                    throw de;
                }
                catch (Exception e)
                {
                    throw new DadosException("Problemas no encerramento da saída. Favor contactar o administrador.", e);
                }

            }
        }

        /// <summary>
        /// Faz o encerramento de um devolução de produtos pelo consumidor
        /// </summary>
        /// <param name="saida"></param>
        /// <param name="consumidor"></param>
        public void EncerrarDevolucaoConsumidor(Saida saida, Pessoa consumidor)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                try
                {
                    if (consumidor.CodPessoa == Global.CLIENTE_PADRAO)
                    {
                        throw new NegocioException("O cliente padrão não pode ser utilizado. Referencie o mesmo cliente que consta no Cupom Fiscal. Se o cliente não constar no cupom, deve-se cadastrar o cliente ou usar um cliente existente na base de dados.");
                    }
                    else if ((consumidor.CodPessoa != saida.CodCliente) && (saida.CodCliente != Global.CLIENTE_PADRAO))
                    {
                        throw new NegocioException("O consumidor referenciado deve ser o mesmo que consta no cupom fiscal de devolução.");
                    }
                    saida.TipoSaida = Saida.TIPO_DEVOLUCAO_CONSUMIDOR;
                    saida.CodCliente = consumidor.CodPessoa;
                    Atualizar(saida);
                    List<SaidaProduto> saidaProdutos = GerenciadorSaidaProduto.GetInstance(saceContext).ObterPorSaida(saida.CodSaida);
                    RegistrarEstornoEstoque(saida, saidaProdutos);
                    AtualizarCfopProdutosDevolucao(saidaProdutos, saida);
                    transaction.Complete();
                }
                catch (NegocioException ne)
                {
                    throw ne;
                }
                catch (DadosException de)
                {
                    throw de;
                }
                catch (Exception e)
                {
                    throw new DadosException("Problemas no encerramento da saída. Favor contactar o administrador.", e);
                }

            }
        }

        /// <summary>
        /// Atualiza os cfops de produtos de acordo com os dados de devolução na NF-e
        /// </summary>
        /// <param name="saidaProdutos"></param>
        /// <param name="_saidaE"></param>
        private void AtualizarCfopProdutosDevolucao(List<SaidaProduto> saidaProdutos, Saida saida)
        {
            Pessoa fornecedor = GerenciadorPessoa.GetInstance().Obter(saida.CodCliente).ElementAtOrDefault(0);
            Loja loja = GerenciadorLoja.GetInstance().Obter(Global.LOJA_PADRAO).ElementAtOrDefault(0);
            Pessoa pessoaLoja = GerenciadorPessoa.GetInstance().Obter(loja.CodPessoa).ElementAtOrDefault(0);

            bool ehMesmoUF = false;
            if (pessoaLoja != null && fornecedor != null)
            {
                ehMesmoUF = pessoaLoja.Uf.Equals(fornecedor.Uf);
            }
            foreach (SaidaProduto saidaProduto in saidaProdutos)
            {
                if (saida.TipoSaida.Equals(Saida.TIPO_DEVOLUCAO_CONSUMIDOR))
                {
                    if (saidaProduto.EhTributacaoIntegral)
                    {
                        saidaProduto.CodCfop = Cfop.DEVOLUCAO_CONSUMIDOR_NORMAL;
                    }
                    else if (!saidaProduto.EhTributacaoIntegral)
                    {
                        saidaProduto.CodCfop = Cfop.DEVOLUCAO_CONSUMIDOR_ST;
                    }
                }
                else
                {
                    if (saidaProduto.EhTributacaoIntegral)
                    {
                        saidaProduto.CodCfop = (ehMesmoUF) ? Cfop.DEVOLUCAO_NORMAL_ESTADO : Cfop.DEVOLUCAO_NORMAL_FORA_ESTADO;
                    }
                    else 
                    {
                        saidaProduto.CodCfop = (ehMesmoUF) ? Cfop.DEVOUCAO_ST_ESTADO : Cfop.DEVOUCAO_ST_FORA_ESTADO;
                    }
                }
                GerenciadorSaidaProduto.GetInstance(null).AtualizarCFOP(saidaProduto.CodSaidaProduto, saidaProduto.CodCfop);
            }
        }
        /// <summary>
        /// Calculo do toatal da nota de acordo com a existência de substituição tributária
        /// </summary>
        /// <param name="saida"></param>
        /// <returns></returns>
        public decimal ObterTotalNotaFiscal(Saida saida)
        {
            if (saida.BaseCalculoICMSSubst > 0)
                return saida.Total + saida.ValorICMSSubst + saida.ValorFrete + saida.ValorSeguro - saida.Desconto + saida.OutrasDespesas + saida.ValorIPI;
            else
                return saida.Total + saida.ValorICMS + saida.ValorFrete + saida.ValorSeguro - saida.Desconto + saida.OutrasDespesas + saida.ValorIPI;
        }

        /// <summary>
        /// Verifica na saída se produto tem data de vencimento aceitável.
        /// </summary>
        /// <param name="produto"></param>
        /// <param name="dataVencimento"></param>
        /// <returns></returns>
        public Boolean DataVencimentoProdutoAceitavel(ProdutoPesquisa produto, DateTime dataVencimento)
        {
            if (produto.TemVencimento)
            {
                DateTime dataMaisAntigo = GerenciadorEntradaProduto.GetInstance(null).GetDataProdutoMaisAntigoEstoque(produto);
                return (dataMaisAntigo >= dataVencimento);
            }
            return true;
        }

        /// <summary>
        /// Regista formas de pagamentos de uma saída
        /// </summary>
        /// <param name="pagamentos"></param>
        /// <param name="saida"></param>
        public void RegistrarPagamentosSaida(List<SaidaPagamento> pagamentos, Saida saida)
        {
            decimal totalRegistrado = 0;

            foreach (SaidaPagamento pagamento in pagamentos)
            {

                List<Conta> contas = GerenciadorConta.GetInstance(saceContext).ObterPorSaidaPagamento(saida.CodSaida, pagamento.CodSaidaPagamento).ToList();

                if (contas.Count > 0)
                {
                    totalRegistrado += pagamento.Valor;
                    continue;
                }
                // Para cada pagamento é criada uma nova conta
                Conta conta = new Conta();
                conta.CodPessoa = saida.CodCliente;
                conta.CodPlanoConta = PlanoConta.SAIDA_PRODUTOS;
                conta.CodSaida = saida.CodSaida;
                conta.CodEntrada = Global.ENTRADA_PADRAO; // entrada não válida
                conta.CodPessoa = saida.CodCliente;
                conta.CodPagamento = pagamento.CodSaidaPagamento;
                conta.Desconto = 0;
                conta.FormatoConta = Conta.FORMATO_CONTA_FICHA;
                conta.NumeroDocumento = "";

                // Quando o pagamento é realizado em dinheiro a conta já é inserida quitada
                if (pagamento.CodFormaPagamento == FormaPagamento.DINHEIRO)
                    conta.CodSituacao = SituacaoConta.SITUACAO_QUITADA.ToString();
                else
                    conta.CodSituacao = SituacaoConta.SITUACAO_ABERTA.ToString();

                if (pagamento.CodFormaPagamento == FormaPagamento.CARTAO)
                {
                    conta.CodPessoa = GerenciadorCartaoCredito.GetInstance().Obter(pagamento.CodCartaoCredito).ElementAt(0).CodPessoa;
                    conta.FormatoConta = Conta.FORMATO_CONTA_CARTAO;
                }

                conta.TipoConta = Conta.CONTA_RECEBER.ToString();

                if (((totalRegistrado + pagamento.Valor) >= saida.TotalAVista) && (pagamento.CodFormaPagamento == FormaPagamento.DINHEIRO))
                {
                    conta.Valor = ((decimal)saida.TotalAVista - totalRegistrado) / pagamento.Parcelas;
                }
                else if (pagamento.CodFormaPagamento == FormaPagamento.CREDIARIO)
                {
                    if (pagamento.Valor == saida.TotalAVista)
                    {
                        conta.Valor = ((decimal)saida.Total / pagamento.Parcelas);
                        conta.Desconto = ((decimal)saida.Total - (decimal)saida.TotalAVista) / pagamento.Parcelas;
                    }
                    else
                    {
                        conta.Valor = ((pagamento.Valor * saida.Total) / saida.TotalAVista) / pagamento.Parcelas;
                        conta.Desconto = (conta.Valor - pagamento.Valor) / pagamento.Parcelas;
                    }
                }
                else if (pagamento.CodFormaPagamento == FormaPagamento.CARTAO)
                {
                    conta.Valor = pagamento.Valor / pagamento.Parcelas;
                }

                //Int64 codConta = -1;

                for (int i = 0; i < pagamento.Parcelas; i++)
                {
                    if (pagamento.CodFormaPagamento == (FormaPagamento.CARTAO))
                    {
                        CartaoCredito cartaoCredito = GerenciadorCartaoCredito.GetInstance().Obter(pagamento.CodCartaoCredito).ElementAt(0);
                        pagamento.Data = pagamento.Data.AddDays((double)cartaoCredito.DiaBase);
                        conta.DataVencimento = pagamento.Data;
                        conta.Desconto = (pagamento.Valor * cartaoCredito.Desconto / 100) / pagamento.Parcelas;

                    }
                    else if ((pagamento.CodFormaPagamento == FormaPagamento.BOLETO) || (pagamento.CodFormaPagamento == FormaPagamento.CHEQUE))
                    {
                        //DocumentoPagamento documento = GerenciadorDocumentoPagamento.getInstace().obterDocumentoPagamento(pagamento.CodDocumentoPagamento);
                        //conta.DataVencimento = documento.DataVencimento;
                        //conta.Valor = documento.Valor;
                    }
                    else if ((pagamento.CodFormaPagamento == FormaPagamento.CREDIARIO) || (pagamento.CodFormaPagamento == FormaPagamento.DEPOSITO) ||
                      (pagamento.CodFormaPagamento == FormaPagamento.PROMISSORIA))
                    {
                        conta.DataVencimento = saida.DataSaida.AddDays(pagamento.IntervaloDias);
                    }
                    else
                    {
                        conta.DataVencimento = pagamento.Data;
                    }

                    conta.CodConta = GerenciadorConta.GetInstance(saceContext).Inserir(conta);
                }

                totalRegistrado += pagamento.Valor;



                if (pagamento.CodFormaPagamento == FormaPagamento.DINHEIRO)
                {
                    MovimentacaoConta movimentacao = new MovimentacaoConta();
                    movimentacao.CodContaBanco = pagamento.CodContaBanco;
                    movimentacao.CodConta = conta.CodConta;
                    movimentacao.CodResponsavel = saida.CodCliente;
                    movimentacao.DataHora = DateTime.Now;
                    if (totalRegistrado > saida.TotalAVista)
                    {
                        movimentacao.Valor = pagamento.Valor - (decimal)saida.Troco;
                    }
                    else
                    {
                        movimentacao.Valor = pagamento.Valor;
                    }

                    movimentacao.CodTipoMovimentacao = (movimentacao.Valor > 0) ? MovimentacaoConta.RECEBIMENTO_CLIENTE : MovimentacaoConta.DEVOLUCAO_CLIENTE;

                    GerenciadorMovimentacaoConta.GetInstance(saceContext).Inserir(movimentacao);
                }
            }
        }

        /// <summary>
        /// Registra estorno de estoque no caso de devolução ou exclusão da saída
        /// No caso de devolução do consumidor o estoque é incrementado.
        /// </summary>
        /// <param name="saidaProdutos"></param>
        public void RegistrarEstornoEstoque(Saida saida, List<SaidaProduto> saidaProdutos)
        {
            if (saidaProdutos == null)
                saidaProdutos = GerenciadorSaidaProduto.GetInstance(saceContext).ObterPorSaida(saida.CodSaida);
            
            foreach (SaidaProduto saidaProduto in saidaProdutos)
            {
                if (saidaProduto.CodCST != Cst.ST_OUTRAS)
                {
                    GerenciadorProdutoLoja.GetInstance(saceContext).AdicionaQuantidade(saidaProduto.Quantidade, 0, Global.LOJA_PADRAO, saidaProduto.CodProduto);
                }
                else
                {
                    GerenciadorProdutoLoja.GetInstance(saceContext).AdicionaQuantidade(0, saidaProduto.Quantidade, Global.LOJA_PADRAO, saidaProduto.CodProduto);
                }

                GerenciadorEntradaProduto.GetInstance(saceContext).BaixarItensVendidosEstoque(saidaProduto);
            }
            saceContext.SaveChanges();
        }

        /// <summary>
        /// Decrementa a quantidade de produtos na loja matriz e atualiza o lote de
        /// entrada determinando que produtos foram vendidos de um determinado lote.
        /// </summary>
        /// <param name="saidaProdutos"></param>
        /// <returns> A soma dos preços de custo dos produtos baixados para determinar o lucro</returns>
        private Decimal RegistrarBaixaEstoque(List<SaidaProduto> saidaProdutos)
        {
            Decimal somaPrecosCusto = 0;
            foreach (SaidaProduto saidaProduto in saidaProdutos)
            {
                Produto produto = GerenciadorProduto.GetInstance().Obter(new ProdutoPesquisa() { CodProduto = saidaProduto.CodProduto });

                // Baixa sempre o estoque da loja matriz
                if (saidaProduto.CodCST != Cst.ST_OUTRAS)
                {
                    GerenciadorProdutoLoja.GetInstance(saceContext).AdicionaQuantidade(saidaProduto.Quantidade * (-1), 0, Global.LOJA_PADRAO, saidaProduto.CodProduto);
                }
                else
                {
                    GerenciadorProdutoLoja.GetInstance(saceContext).AdicionaQuantidade(0, saidaProduto.Quantidade * (-1), Global.LOJA_PADRAO, saidaProduto.CodProduto);
                }

                decimal custoAtual = produto.PrecoCusto * saidaProduto.Quantidade;
                decimal custoEstoque = GerenciadorEntradaProduto.GetInstance(saceContext).BaixarItensVendidosEstoque(saidaProduto);
                // Se não houver preço de custo do produto
                if (custoAtual <= 0)
                {
                    custoAtual = Convert.ToDecimal(0.8) * saidaProduto.PrecoVendaVarejo * saidaProduto.Quantidade;
                }
                else if (custoAtual >= (saidaProduto.PrecoVendaVarejo * saidaProduto.Quantidade))
                {
                    custoAtual = saidaProduto.PrecoVendaVarejo * saidaProduto.Quantidade;
                }

                if (custoEstoque <= 0)
                {
                    custoEstoque = Convert.ToDecimal(0.8) * saidaProduto.PrecoVendaVarejo * saidaProduto.Quantidade;
                }
                else if (custoEstoque >= (saidaProduto.PrecoVendaVarejo * saidaProduto.Quantidade))
                {
                    custoEstoque = saidaProduto.PrecoVendaVarejo * saidaProduto.Quantidade;
                }

                if ((Convert.ToDecimal(0.8) * custoAtual) > custoEstoque)
                {
                    somaPrecosCusto += custoAtual;
                }
                else
                {
                    somaPrecosCusto += custoEstoque;
                }
            }
            return somaPrecosCusto;
        }

        /// <summary>
        /// Registra transferência de estoque entre lojas
        /// </summary>
        /// <param name="saidaProdutos"></param>
        /// <param name="lojaOrigem"></param>
        /// <param name="lojaDestino"></param>
        private void RegistrarTransferenciaEstoque(List<SaidaProduto> saidaProdutos, int lojaOrigem, int lojaDestino)
        {
            foreach (SaidaProduto saidaProduto in saidaProdutos)
            {
                ProdutoPesquisa produto = GerenciadorProduto.GetInstance().Obter(saidaProduto.CodProduto).ElementAt(0);

                GerenciadorProdutoLoja.GetInstance(saceContext).AdicionaQuantidade(saidaProduto.Quantidade * (-1), 0, lojaOrigem, saidaProduto.CodProduto);

                GerenciadorProdutoLoja.GetInstance(saceContext).AdicionaQuantidade(saidaProduto.Quantidade, 0, lojaDestino, saidaProduto.CodProduto);
            }
        }

        public List<SaidaProduto> ExcluirProdutosDevolvidosMesmoPreco(List<SaidaProduto> saidaProdutos)
        {
            List<SaidaProduto> listaSemDevolucoes = new List<SaidaProduto>();
            List<SaidaProduto> listaDevolucoes = new List<SaidaProduto>();
            List<SaidaProduto> listaNaoConseguiuDevolver = new List<SaidaProduto>();

            foreach (SaidaProduto saidaProduto in saidaProdutos)
            {
                if (saidaProduto.Quantidade > 0)
                {
                    listaSemDevolucoes.Add(saidaProduto);
                }
                else
                {
                    listaDevolucoes.Add(saidaProduto);
                }
            }

            if (listaDevolucoes.Count > 0)
            {
                foreach (SaidaProduto devolvido in listaDevolucoes)
                {
                    decimal quantidadeDevolvida = Math.Abs(devolvido.Quantidade);
                    foreach (SaidaProduto naoDevolvido in listaSemDevolucoes)
                    {
                        if ((naoDevolvido.CodProduto == devolvido.CodProduto) && (naoDevolvido.ValorVenda == devolvido.ValorVenda))
                        {
                            if (quantidadeDevolvida < naoDevolvido.Quantidade)
                            {
                                naoDevolvido.Quantidade -= quantidadeDevolvida;
                                quantidadeDevolvida = 0;
                                break;
                            }
                            else
                            {
                                quantidadeDevolvida -= naoDevolvido.Quantidade;
                                devolvido.Quantidade += naoDevolvido.Quantidade;
                                naoDevolvido.Quantidade = 0;
                                //listaSemDevolucoes.Remove(naoDevolvido);
                            }
                        }
                    }
                    if (quantidadeDevolvida > 0)
                    {
                        listaNaoConseguiuDevolver.Add(devolvido);
                    }
                }
                if (listaNaoConseguiuDevolver.Count > 0)
                {
                    listaSemDevolucoes.AddRange(listaNaoConseguiuDevolver);
                }
            }
            return listaSemDevolucoes;
        }

        public bool ImprimirCreditoPagamento(MovimentacaoConta movimentacaoConta)
        {
            try
            {
                ImprimeTexto imp = new ImprimeTexto();
                if (!imp.Inicio(Global.PORTA_IMPRESSORA_REDUZIDA2))
                {
                    return false;
                }
                Loja loja = GerenciadorLoja.GetInstance().Obter(Global.LOJA_PADRAO).ElementAt(0);
                Pessoa pessoaLoja = (Pessoa)GerenciadorPessoa.GetInstance().Obter(loja.CodPessoa).ElementAt(0);

                imp.Imp(imp.Comprimido);
                imp.ImpLF(Global.LINHA_COMPRIMIDA);
                imp.ImpColLFCentralizado(0, 59, "DOCUMENTO AUXILIAR DE VENDA - PEDIDO");
                imp.Pula(1);
                imp.ImpColLFCentralizado(0, 59, "NAO E DOCUMENTO FISCAL - NAO E VALIDO COMO RECIBO ");
                imp.ImpColLFCentralizado(0, 59, "E COMO GARANTIA DE MERCADORIA - NAO COMPROVA PAGAMENTO");
                imp.ImpLF(Global.LINHA_COMPRIMIDA);
                imp.ImpColLFCentralizado(0, 59, imp.NegritoOn + pessoaLoja.Nome + imp.NegritoOff);
                imp.ImpColLFCentralizado(0, 59, pessoaLoja.Endereco + "  Fone: " + pessoaLoja.Fone1);
                imp.ImpLF(Global.LINHA_COMPRIMIDA);

                Pessoa cliente = GerenciadorPessoa.GetInstance().Obter(movimentacaoConta.CodResponsavel).ElementAt(0);

                imp.ImpLF("Cliente: " + cliente.NomeFantasia);
                imp.ImpLF("Data/Hora: " + movimentacaoConta.DataHora);

                imp.ImpLF(Global.LINHA_COMPRIMIDA);

                imp.Pula(1);
                imp.ImpLF("Foi creditado na conta do cliente R$ " + movimentacaoConta.Valor);
                imp.Pula(1);

                imp.ImpLF(Global.LINHA_COMPRIMIDA);
                imp.Pula(1);
                imp.ImpColLF(0, "Recebido por:");
                imp.ImpLF(Global.LINHA_COMPRIMIDA);

                imp.Pula(8);
                imp.Imp(imp.Normal);
                imp.Fim();
                return true;
            }
            catch (Exception)
            {
                throw new NegocioException("Não foi possível realizar a impressão. Por Favor Verifique se a impressora MATRICIAL está LIGADA.");
            }
        }

        public bool ImprimirDAV(List<Saida> saidas, decimal total, decimal totalAVista, decimal desconto, Global.Impressora impressora)
        {
            if (impressora.Equals(Global.Impressora.NORMAL))
                return ImprimirDAVNormalTexto(saidas, total, totalAVista, desconto);
            else
                return ImprimirDAVComprimido(saidas, total, totalAVista, desconto, impressora);                
        }

        public bool EhPossivelImprimirDAV(Global.Impressora impressora) {
            return true;
        }

        private bool ImprimirDAVComprimido(List<Saida> saidas, decimal total, decimal totalAVista, decimal desconto, Global.Impressora impressora)
        {
            try
            {
                ImprimeTexto imp = new ImprimeTexto();
                if (impressora.Equals(Global.Impressora.DARUMA))
                {
                    if (!imp.Inicio(Global.PORTA_IMPRESSORA_REDUZIDA))
                    {
                        return false;
                    }
                }
                else if (impressora.Equals(Global.Impressora.BEMATECH))
                {
                    if (!imp.Inicio(Global.PORTA_IMPRESSORA_REDUZIDA2))
                    {
                        return false;
                    }
                }
                else
                {
                    ImprimirDAVComprimidoBematech(saidas, total, totalAVista, desconto);
                }

                Loja loja = GerenciadorLoja.GetInstance().Obter(Global.LOJA_PADRAO).ElementAt(0);
                Pessoa pessoaLoja = (Pessoa)GerenciadorPessoa.GetInstance().Obter(loja.CodPessoa).ElementAt(0);

                imp.Imp(imp.Comprimido);
                imp.ImpLF(Global.LINHA_COMPRIMIDA);
                if (saidas[0].TipoSaida == Saida.TIPO_ORCAMENTO)
                {
                    imp.ImpColLFCentralizado(0, 59, "DOCUMENTO AUXILIAR DE VENDA - ORCAMENTO");
                }
                else
                {
                    imp.ImpColLFCentralizado(0, 59, "DOCUMENTO AUXILIAR DE VENDA - PEDIDO");
                }
                imp.Pula(1);
                imp.ImpColLFCentralizado(0, 59, "NAO E DOCUMENTO FISCAL - NAO E VALIDO COMO RECIBO ");
                imp.ImpColLFCentralizado(0, 59, "E COMO GARANTIA DE MERCADORIA - NAO COMPROVA PAGAMENTO");
                imp.ImpLF(Global.LINHA_COMPRIMIDA);
                imp.ImpColLFCentralizado(0, 59, imp.NegritoOn + pessoaLoja.Nome + imp.NegritoOff);
                imp.ImpColLFCentralizado(0, 59, pessoaLoja.Endereco + "  Fone: " + pessoaLoja.Fone1);
                imp.ImpLF(Global.LINHA_COMPRIMIDA);

                Pessoa cliente = (Pessoa)GerenciadorPessoa.GetInstance().Obter(saidas[0].CodCliente).ElementAt(0);
                imp.ImpLF("Cliente: " + cliente.NomeFantasia);
                //imp.ImpColLF(39, "CPF/CNPJ: " + cliente.CpfCnpj);
                if (saidas.Count == 1)
                {
                    imp.Imp("No do Documento: " + saidas[0].CodSaida);
                    imp.ImpColLF(30, "No do Documento Fiscal: " + saidas[0].CupomFiscal);
                    imp.ImpLF("Data: " + saidas[0].DataSaida.ToShortDateString());
                }
                imp.ImpLF(Global.LINHA_COMPRIMIDA);
                imp.ImpLF("Cod  Produto                                   Qtdade    UN ");
                imp.ImpLF("                                      Preco(R$) Subtotal(R$)");
                foreach (Saida saida in saidas)
                {
                    if (saidas.Count > 1)
                    {
                        imp.ImpLF("==> Documento: " + saida.CodSaida + "    Data: " + saida.DataSaida.ToShortDateString() + "     CF: " + saida.CupomFiscal);
                    }

                    List<SaidaProduto> saidaProdutos = GerenciadorSaidaProduto.GetInstance(saceContext).ObterPorSaida(saida.CodSaida);
                    foreach (SaidaProduto produto in saidaProdutos)
                    {
                        imp.ImpColDireita(0, 4, produto.CodProduto.ToString());

                        if (produto.Nome.Length > 39)
                        {
                            imp.ImpCol(6, produto.Nome.Substring(1, 39));
                        }
                        else
                        {
                            imp.ImpCol(6, produto.Nome);
                        }

                        imp.ImpColDireita(46, 54, produto.Quantidade.ToString());
                        imp.ImpColLFDireita(57, 58, produto.Unidade);
                        imp.ImpColDireita(38, 46, produto.ValorVenda.ToString("N2"));
                        imp.ImpColLFDireita(48, 59, produto.Subtotal.ToString("N2"));
                    }
                }

                imp.ImpLF(Global.LINHA_COMPRIMIDA);
                imp.ImpLF("Total Venda: " + total + "     Desconto: " + desconto.ToString("N2") + "%");
                imp.ImpColLFDireita(0, 32, imp.Expandido + imp.NegritoOn + "Total Pagar:" + totalAVista.ToString("N2") + imp.Comprimido + imp.NegritoOff);
                imp.ImpLF(Global.LINHA_COMPRIMIDA);
                imp.ImpColLFCentralizado(0, 59, "E vedada a autenticacao deste documento");
                if (!saidas[0].CupomFiscal.Equals(""))
                {
                    imp.ImpColLFCentralizado(0, 59, "Documento Válido por 3 (tres) dias");
                }
                imp.ImpLF(Global.LINHA_COMPRIMIDA);
                if (!saidas[0].CodCliente.Equals(Global.CLIENTE_PADRAO))
                {
                    imp.Pula(1);
                    imp.ImpColLF(0, "Recebido por:");
                    imp.ImpLF(Global.LINHA_COMPRIMIDA);
                }



                imp.Pula(8);
                imp.Imp(imp.Normal);
                imp.Fim();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private int FormataTX(string texto)
        {
            int tLetra = 1;
            int italico = 0;
            int sublinhado = 0;
            int expandido = 0;
            int enfatizado = 0;
            return MP2032.FormataTX(texto, tLetra, italico, sublinhado, expandido, enfatizado);
        }

        private void ImprimirDAVComprimidoBematech(List<Saida> saidas, decimal total, decimal totalAVista, decimal desconto)
        {
            int iRetorno = 0; //Variável para retorno das chamadas
            iRetorno = MP2032.ConfiguraModeloImpressora(1); // "MP 20 MI"

            iRetorno = MP2032.IniciaPorta(Global.PORTA_IMPRESSORA_REDUZIDA2);

            if (iRetorno <= 0) //testa se a conexão da porta foi bem sucedido
            {
                MessageBox.Show("Não foi possível conectar com a impressora!!!");
            }

            Loja loja = GerenciadorLoja.GetInstance().Obter(Global.LOJA_PADRAO).ElementAt(0);
            Pessoa pessoaLoja = (Pessoa)GerenciadorPessoa.GetInstance().Obter(loja.CodPessoa).ElementAt(0);

            //chamando a função para impressão do texto
            // \n - quebra de linha e \r retorno de impressão (comandos da impressora)
            iRetorno = FormataTX(Global.LINHA_COMPRIMIDA + "\n");
            if (saidas[0].TipoSaida == Saida.TIPO_ORCAMENTO)
                FormataTX(StringUtil.PadBoth("DOCUMENTO AUXILIAR DE VENDA - ORCAMENTO" + "\n",60));
            else
                FormataTX(StringUtil.PadBoth("DOCUMENTO AUXILIAR DE VENDA - PEDIDO"+"\n",60));

            FormataTX(StringUtil.PadBoth("NAO E DOCUMENTO FISCAL - NAO E VALIDO COMO RECIBO" + "\n", 60));
            FormataTX(StringUtil.PadBoth("\n", 60));
            FormataTX(StringUtil.PadBoth("E COMO GARANTIA DE MERCADORIA - NAO COMPROVA PAGAMENTO"+"\n", 60));
            FormataTX(Global.LINHA_COMPRIMIDA + "\n");
            
            
            FormataTX(StringUtil.PadBoth(pessoaLoja.Nome, 60));
            FormataTX(StringUtil.PadBoth(pessoaLoja.Endereco + "  Fone: " + pessoaLoja.Fone1 + "\n", 60));
            FormataTX(Global.LINHA_COMPRIMIDA + "\n");
            
            Pessoa cliente = (Pessoa)GerenciadorPessoa.GetInstance().Obter(saidas[0].CodCliente).ElementAt(0);


            FormataTX("Cliente: " + cliente.NomeFantasia+"  CPF/CNPJ: " + cliente.CpfCnpj + "\n");

            if (saidas.Count == 1)
            {
                FormataTX("No do Documento: " + saidas[0].CodSaida + "   No do Documento Fiscal: " + saidas[0].CupomFiscal + "\n");
                FormataTX("Data: " + saidas[0].DataSaida.ToShortDateString() + "\n");
            }
            FormataTX(Global.LINHA_COMPRIMIDA + "\n");
            FormataTX("Cod  Produto                                   Qtdade    UN " + "\n");
            FormataTX("                                      Preco(R$) Subtotal(R$)" + "\n");
            foreach (Saida saida in saidas)
            {
                if (saidas.Count > 1)
                {
                    FormataTX("==> Documento: " + saida.CodSaida + "    Data: " + saida.DataSaida.ToShortDateString() + "     CF: " + saida.CupomFiscal+ "\n");
                }

                List<SaidaProduto> saidaProdutos = GerenciadorSaidaProduto.GetInstance(saceContext).ObterPorSaida(saida.CodSaida);
                foreach (SaidaProduto produto in saidaProdutos)
                {
                }
            }

            FormataTX(Global.LINHA_COMPRIMIDA + "\n");
            FormataTX(Global.LINHA_COMPRIMIDA + "\n");
            FormataTX(Global.LINHA_COMPRIMIDA + "\n");
            if (!saidas[0].CodCliente.Equals(Global.CLIENTE_PADRAO))
            {
                FormataTX("\n");
                FormataTX("Recebido por:"+"\n");
                FormataTX(Global.LINHA_COMPRIMIDA + "\n");
            }
        }

        private bool ImprimirDAVNormal(List<Saida> saidas, decimal total, decimal totalAVista, decimal desconto)
        {
            try
            {
                ImprimeTexto imp = new ImprimeTexto();

                if (!imp.Inicio(Global.PORTA_IMPRESSORA_NORMAL))
                {
                    return false;
                }

                Loja loja = GerenciadorLoja.GetInstance().Obter(Global.LOJA_PADRAO).ElementAt(0);
                Pessoa pessoaLoja = (Pessoa)GerenciadorPessoa.GetInstance().Obter(loja.CodPessoa).ElementAt(0);


                imp.ImpLF(Global.LINHA);
                if (saidas[0].TipoSaida == Saida.TIPO_ORCAMENTO)
                {
                    imp.ImpColLFCentralizado(0, 79, "DOCUMENTO AUXILIAR DE VENDA - ORCAMENTO");
                }
                else
                {
                    imp.ImpColLFCentralizado(0, 79, "DOCUMENTO AUXILIAR DE VENDA - PEDIDO");
                }
                imp.Pula(1);
                imp.ImpColLFCentralizado(0, 79, "NAO E DOCUMENTO FISCAL - NAO E VALIDO COMO RECIBO E COMO GARANTIA DE MERCADORIA");
                imp.ImpColLFCentralizado(0, 79, "- NAO COMPROVA PAGAMENTO");
                imp.ImpLF(Global.LINHA);
                imp.ImpColLFCentralizado(0, 79, imp.NegritoOn + pessoaLoja.Nome + imp.NegritoOff);
                imp.ImpColLFCentralizado(0, 79, pessoaLoja.Endereco + "                                     Fone: " + pessoaLoja.Fone1);
                imp.ImpLF(Global.LINHA);

                Pessoa cliente = (Pessoa)GerenciadorPessoa.GetInstance().Obter(saidas[0].CodCliente).ElementAt(0);
                imp.Imp("Cliente: " + cliente.NomeFantasia);
                imp.ImpColLF(50, "CPF/CNPJ: " + cliente.CpfCnpj);
                if (saidas.Count == 1)
                {
                    imp.ImpLF("Data : " + saidas[0].DataSaida.ToShortDateString());
                    imp.Imp("No do Documento: " + saidas[0].CodSaida);
                    imp.ImpColLF(50, "No do Documento Fiscal: " + saidas[0].CupomFiscal);
                }
                imp.ImpLF(Global.LINHA);
                imp.ImpLF("Cod  Produto                                   Qtdade  UN Preco(R$) Subtotal(R$)");

                foreach (Saida saida in saidas)
                {
                    if (saidas.Count > 1)
                    {
                        imp.ImpLF("==> Documento: " + saida.CodSaida + "    Data: " + saida.DataSaida.ToShortDateString() + "     CF: " + saida.CupomFiscal);
                    }

                    List<SaidaProduto> saidaProdutos = GerenciadorSaidaProduto.GetInstance(saceContext).ObterPorSaida(saida.CodSaida);
                    foreach (SaidaProduto produto in saidaProdutos)
                    {
                        imp.ImpColDireita(0, 3, produto.CodProduto.ToString());

                        if (produto.Nome.Length > 40)
                        {
                            imp.ImpCol(5, produto.Nome.Substring(1, 40));
                        }
                        else
                        {
                            imp.ImpCol(5, produto.Nome);
                        }

                        imp.ImpColDireita(46, 52, produto.Quantidade.ToString());
                        imp.ImpColDireita(55, 56, produto.Unidade);
                        imp.ImpColDireita(58, 66, produto.ValorVenda.ToString("N2"));
                        imp.ImpColLFDireita(68, 79, produto.Subtotal.ToString("N2"));
                    }

                }
                imp.ImpLF(Global.LINHA);
                imp.Imp("Total Venda: " + total + "            Desconto: " + desconto.ToString("N2") + "%");
                imp.ImpColLFDireita(55, 80, imp.NegritoOn + "Total Pagar:" + totalAVista.ToString("N2") + imp.NegritoOff);
                imp.ImpLF(Global.LINHA);
                imp.ImpColLFCentralizado(0, 79, "E vedada a autenticacao deste documento");
                imp.ImpLF(Global.LINHA);

                imp.Pula(2);

                imp.Fim();
                return true;
            }
            catch (Exception)
            {
                throw new NegocioException("Não foi possível realizar a impressão. Por Favor Verifique se a impressora MATRICIAL está LIGADA.");
            }
        }

        private bool ImprimirDAVNormalTexto(List<Saida> saidas, decimal total, decimal totalAVista, decimal desconto)
        {
            try
            {
                StringBuilderImprimir sbImprimir = new StringBuilderImprimir();


                Loja loja = GerenciadorLoja.GetInstance().Obter(Global.LOJA_PADRAO).ElementAt(0);
                Pessoa pessoaLoja = (Pessoa)GerenciadorPessoa.GetInstance().Obter(loja.CodPessoa).ElementAt(0);

                sbImprimir.AppendLine(Global.LINHA);
                if (saidas[0].TipoSaida == Saida.TIPO_ORCAMENTO)
                {
                    sbImprimir.AppendLineCenter(80, "DOCUMENTO AUXILIAR DE VENDA - ORCAMENTO");
                }
                else
                {
                    sbImprimir.AppendLineCenter(80, "DOCUMENTO AUXILIAR DE VENDA - PEDIDO");
                }
                sbImprimir.AppendLine("");
                sbImprimir.AppendLineCenter(80, "NAO E DOCUMENTO FISCAL - NAO E VALIDO COMO RECIBO E COMO GARANTIA DE MERCADORIA");
                sbImprimir.AppendLineCenter(80, "- NAO COMPROVA PAGAMENTO");
                sbImprimir.AppendLine(Global.LINHA);
                sbImprimir.AppendLineCenter(80, pessoaLoja.Nome);
                sbImprimir.AppendLineCenter(80, pessoaLoja.Endereco + "                                     Fone: " + pessoaLoja.Fone1);
                sbImprimir.AppendLine(Global.LINHA);

                Pessoa cliente = (Pessoa)GerenciadorPessoa.GetInstance().Obter(saidas[0].CodCliente).ElementAt(0);
                if (cliente.NomeFantasia.Length <= 40)
                    sbImprimir.Append("Cliente: " + cliente.NomeFantasia);
                else
                    sbImprimir.Append("Cliente: " + cliente.NomeFantasia.Substring(0, 40));

                sbImprimir.AppendLineEsquerda(50, "CPF/CNPJ: " + cliente.CpfCnpj);
                if (saidas.Count == 1)
                {
                    sbImprimir.AppendLine("Data : " + saidas[0].DataSaida.ToShortDateString());
                    sbImprimir.Append("No do Documento: " + saidas[0].CodSaida);
                    sbImprimir.AppendLineEsquerda(50, "No do Documento Fiscal: " + saidas[0].CupomFiscal);
                }
                sbImprimir.AppendLine(Global.LINHA);
                sbImprimir.AppendLine("Cod  Produto                                   Qtdade  UN Preco(R$) Subtotal(R$)");

                foreach (Saida saida in saidas)
                {
                    if (saidas.Count > 1)
                    {
                        sbImprimir.AppendLine("");
                        sbImprimir.AppendLine("==> Documento: " + saida.CodSaida + "    Data: " + saida.DataSaida.ToShortDateString() + "     CF: " + saida.CupomFiscal);
                    }

                    List<SaidaProduto> saidaProdutos = GerenciadorSaidaProduto.GetInstance(saceContext).ObterPorSaida(saida.CodSaida);
                    foreach (SaidaProduto produto in saidaProdutos)
                    {
                        sbImprimir.AppendDireita(0, 3, produto.CodProduto.ToString());

                        if (produto.Nome.Length > 40)
                        {
                            sbImprimir.AppendEsquerda(5, produto.Nome.Substring(0, 40));
                        }
                        else
                        {
                            sbImprimir.AppendEsquerda(5, produto.Nome);
                        }

                        sbImprimir.AppendDireita(46, 52, produto.Quantidade.ToString());
                        sbImprimir.AppendDireita(55, 56, produto.Unidade);
                        sbImprimir.AppendDireita(58, 66, produto.ValorVenda.ToString("N2"));
                        sbImprimir.AppendDireita(68, 79, produto.Subtotal.ToString("N2"));
                        sbImprimir.AppendLine("");
                    }

                }
                sbImprimir.AppendLine(Global.LINHA);
                sbImprimir.Append("Total Venda: " + total + "            Desconto: " + desconto.ToString("N2") + "%");
                sbImprimir.AppendLineDireita(55, 80, "Total Pagar:" + totalAVista.ToString("N2"));
                sbImprimir.AppendLine(Global.LINHA);
                sbImprimir.AppendLineCenter(80, "E vedada a autenticacao deste documento");
                sbImprimir.AppendLine(Global.LINHA);

                sbImprimir.AppendLine("");
                sbImprimir.AppendLine("");

                GerenciadorImprimir.GetInstance().Imprimir(sbImprimir.ToString());
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public void GerarCupomFiscal(Saida saida)
        {

            if (saida.TipoSaida == Saida.TIPO_ORCAMENTO)
            {
                throw new NegocioException("O Documento Fiscal não pode ser impresso a partir de um ORÇAMENTO. É necessário transformá-lo numa PRÉ-VENDA.");
            }

            try
            {
                if (saida.TipoSaida.Equals(Saida.TIPO_PRE_VENDA) || saida.TipoSaida.Equals(Saida.TIPO_PRE_VENDA_NFCE))
                {
                    List<SaidaPedido> listaSaidaPedido = new List<SaidaPedido>() {
                        new SaidaPedido()
                            {
                                CodSaida=saida.CodSaida, 
                                TotalAVista=saida.TotalAVista, 
                                CodPedido=saida.CodSaida
                            }
                    };
                    
                    List<SaidaPagamento> listaSaidaPagamentos = GerenciadorSaidaPagamento.GetInstance(null).ObterPorSaida(saida.CodSaida);
                    if (saida.TipoSaida.Equals(Saida.TIPO_PRE_VENDA))
                        GerenciadorSolicitacaoDocumento.GetInstance().InserirSolicitacaoDocumento(listaSaidaPedido, listaSaidaPagamentos, DocumentoFiscal.TipoSolicitacao.ECF, false, false);
                }
            }
            catch (Exception e)
            {
                if (e is NegocioException)
                    throw e;
                else
                    throw new NegocioException("Não foi possível enviar cupom fiscal. Por Favor verifique conexões de REDE.");
            }
        }


        /// <summary>
        /// Atribui entidade para entidade persistente
        /// </summary>
        /// <param name="saida"></param>
        /// <param name="_saidaE"></param>
        private static void Atribuir(Saida saida, tb_saida _saidaE)
        {
            _saidaE.baseCalculoICMS = saida.BaseCalculoICMS;
            _saidaE.baseCalculoICMSSubst = saida.BaseCalculoICMSSubst;
            _saidaE.codCliente = saida.CodCliente;
            _saidaE.codEmpresaFrete = saida.CodEmpresaFrete;
            _saidaE.codProfissional = saida.CodProfissional;
            _saidaE.codSituacaoPagamentos = saida.CodSituacaoPagamentos;
            _saidaE.codTipoSaida = saida.TipoSaida;
            _saidaE.cpf_cnpj = saida.CpfCnpj;
            _saidaE.dataSaida = saida.DataSaida;
            _saidaE.desconto = saida.Desconto;
            _saidaE.entregaRealizada = saida.EntregaRealizada;
            _saidaE.especieVolumes = saida.EspecieVolumes;
            _saidaE.marca = saida.Marca;
            _saidaE.nfe = saida.Nfe;
            _saidaE.numero = saida.Numero;
            _saidaE.numeroCartaoVenda = saida.NumeroCartaoVenda;
            _saidaE.outrasDespesas = saida.OutrasDespesas;
            _saidaE.pedidoGerado = saida.CupomFiscal;
            _saidaE.dataEmissaoDocFiscal = saida.DataEmissaoCupomFiscal;
            _saidaE.pesoBruto = saida.PesoBruto;
            _saidaE.pesoLiquido = saida.PesoLiquido;
            _saidaE.quantidadeVolumes = saida.QuantidadeVolumes;
            _saidaE.total = saida.Total;
            _saidaE.totalAVista = saida.TotalAVista;
            _saidaE.totalLucro = saida.TotalLucro;
            _saidaE.totalNotaFiscal = saida.TotalNotaFiscal;
            _saidaE.totalPago = saida.TotalPago;
            _saidaE.troco = saida.Troco;
            _saidaE.valorFrete = saida.ValorFrete;
            _saidaE.valorICMS = saida.ValorICMS;
            _saidaE.valorICMSSubst = saida.ValorICMSSubst;
            _saidaE.valorIPI = saida.ValorIPI;
            _saidaE.valorSeguro = saida.ValorSeguro;
            _saidaE.observacao = saida.Observacao;
            _saidaE.codEntrada = saida.CodEntrada;
            _saidaE.codLojaOrigem = saida.CodLojaOrigem;
        }
    }
}