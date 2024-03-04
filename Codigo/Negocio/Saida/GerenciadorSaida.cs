using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using Dados;
using Dominio;
using Util;
using System.Transactions;
using System.Windows.Forms;
using Vip.Printer;
using Vip.Printer.Enums;

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
        /// Mudar o tipo do documento fiscal a ser gerado
        /// </summary>
        /// <param name="codSaida"></param>
        /// <param name="tipoDocumento"></param>
        public void AtualizarTipoDocumentoFiscal(long codSaida, string tipoDocumento)
        {
            try
            {
                var query = from saidaE in saceContext.tb_saida
                            where saidaE.codSaida.Equals(codSaida)
                            select saidaE;
                foreach (tb_saida _saidaE in query)
                {
                    _saidaE.tipoDocumentoFiscal = tipoDocumento;
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
        public void AtualizarSaidasPorNfeSituacao(NfeControle nfeControle)
        {
            try
            {
                var query = from nfe in saceContext.tb_nfe
                            where nfe.codNFe == nfeControle.CodNfe
                            select nfe;
                List<tb_nfe> listaNfes = query.ToList();

                if (listaNfes.Count() > 0)
                {
                    tb_nfe nfe = listaNfes.FirstOrDefault();
                    List<tb_saida> saidas = nfe.tb_saida.ToList();
                    foreach (tb_saida saida in saidas)
                    {
                        if (nfeControle.SituacaoNfe.Equals(NfeControle.SITUACAO_AUTORIZADA))
                        {
                            if (nfeControle.Modelo.Equals(NfeControle.MODELO_NFCE))
                            {
                                saida.nfe = "NFCe";
                                saida.pedidoGerado = "C" + nfe.numeroSequenciaNFe;
                                if (saida.codTipoSaida.Equals(Saida.TIPO_PRE_VENDA))
                                    saida.codTipoSaida = Saida.TIPO_VENDA;
                            }
                            else
                            {
                                saida.nfe = "NFe";
                                saida.pedidoGerado = "N" + nfe.numeroSequenciaNFe;
                                if (saida.codTipoSaida.Equals(Saida.TIPO_PRE_VENDA))
                                    saida.codTipoSaida = Saida.TIPO_VENDA;
                            }
                        }
                        else
                        {
                            if (!saida.codTipoSaida.Equals(Saida.TIPO_DEVOLUCAO_CONSUMIDOR) && !saida.codTipoSaida.Equals(Saida.TIPO_DEVOLUCAO_FORNECEDOR))
                                saida.nfe = "";
                            saida.pedidoGerado = "";
                            if (saida.codTipoSaida.Equals(Saida.TIPO_VENDA))
                                saida.codTipoSaida = Saida.TIPO_PRE_VENDA;
                        }

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
        public void AtualizarTipoPedidoGeradoPorSaida(int codTipoSaida, string pedidoGerado, string tipoDocumentoFiscal, decimal totalAVista, long codSaida)
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
                        _saidaE.pedidoGerado = pedidoGerado.ToString();
                        _saidaE.dataEmissaoDocFiscal = DateTime.Now;
                    }
                    _saidaE.totalAVista = totalAVista;
                    _saidaE.totalPago = totalAVista;
                    _saidaE.tipoDocumentoFiscal = tipoDocumentoFiscal;
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

                List<NfeControle> listaNfeControle = GerenciadorNFe.GetInstance().ObterPorSaida(saida.CodSaida).ToList();
                if (listaNfeControle.Where(nfe => nfe.SituacaoNfe.Equals(NfeControle.SITUACAO_AUTORIZADA)).Count() > 0)
                    throw new NegocioException("Não é possível remover saídas / devoluções com NF-e AUTORIZADAS pelo sistema");

                if ((listaNfeControle.Count() > 0) && (saida.TipoSaida.Equals(Saida.TIPO_ORCAMENTO)))
                    throw new NegocioException("Não é possível remover pedidos com NF-e associadas");


                GerenciadorSaidaPagamento.GetInstance(saceContext).RemoverPorSaida(saida);

                if (saida.TipoSaida.Equals(Saida.TIPO_CREDITO))
                {
                    List<Conta> listaContas = GerenciadorConta.GetInstance(null).ObterPorSaida(saida.CodSaida).ToList();
                    GerenciadorSolicitacaoDocumento.GetInstance().RemoverSolicitacaoDocumento(saida.CodSaida);
                    foreach (Conta conta in listaContas)
                    {
                        GerenciadorConta.GetInstance(saceContext).Remover(conta.CodConta);
                    }
                }

                if (saida.TipoSaida.Equals(Saida.TIPO_ORCAMENTO) || saida.TipoSaida.Equals(Saida.TIPO_PRE_DEVOLUCAO_FORNECEDOR) ||
                    saida.TipoSaida.Equals(Saida.TIPO_PRE_DEVOLUCAO_CONSUMIDOR) || saida.TipoSaida.Equals(Saida.TIPO_PRE_REMESSA_DEPOSITO) ||
                    saida.TipoSaida.Equals(Saida.TIPO_PRE_RETORNO_DEPOSITO) || saida.TipoSaida.Equals(Saida.TIPO_PRE_CREDITO))
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
                    GerenciadorSolicitacaoDocumento.GetInstance().RemoverSolicitacaoDocumento(saida.CodSaida);
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
                if (saida.TipoSaida == Saida.TIPO_CREDITO)
                    throw new NegocioException("Não é possível editar créditos. Se necessário, exclua o crédito e lançe um novo.");

                if (saida.TipoSaida == Saida.TIPO_VENDA)
                    throw new NegocioException("Não é possível editar uma saída cujo Comprovante Fiscal já foi emitido.");


                bool possuiNfeAutorizada = GerenciadorNFe.GetInstance().ObterPorSaida(saida.CodSaida).Where(nfe => nfe.SituacaoNfe.Equals(NfeControle.SITUACAO_AUTORIZADA)).Count() > 0;
                if ((saida.TipoSaida == Saida.TIPO_BAIXA_ESTOQUE_PERDA) && (possuiNfeAutorizada))
                    throw new NegocioException("Não é possível editar Baixa de Estoque cuja Nota Fiscal já foi emitida e autorizada.");
                if ((saida.TipoSaida == Saida.TIPO_USO_INTERNO) && (possuiNfeAutorizada))
                    throw new NegocioException("Não é possível editar Uso Interno cuja Nota Fiscal já foi emitida e autorizada.");
                if ((saida.TipoSaida == Saida.TIPO_REMESSA_DEPOSITO) && (possuiNfeAutorizada))
                    throw new NegocioException("Não é possível editar Transferência para Depósito cuja Nota Fiscal já foi emitida e autorizada.");
                if ((saida.TipoSaida == Saida.TIPO_RETORNO_DEPOSITO) && (possuiNfeAutorizada))
                    throw new NegocioException("Não é possível editar um retorno de Depósito cuja Nota Fiscal já foi emitida e autorizada.");
                else if ((saida.TipoSaida == Saida.TIPO_DEVOLUCAO_FORNECEDOR) && (possuiNfeAutorizada))
                    throw new NegocioException("Não é possível editar uma Devolução para Fornecedor cuja Nota Fiscal já foi emitida e autorizada.");
                else if ((saida.TipoSaida == Saida.TIPO_PRE_VENDA) && (saida.CodCliente != Global.CLIENTE_PADRAO))
                {
                    IEnumerable<SaidaPagamento> pagamentos = GerenciadorSaidaPagamento.GetInstance(null).ObterPorSaida(saida.CodSaida);
                    // houve pagamento não realizado em dinheiro
                    if (pagamentos.Where(p => p.CodFormaPagamento.Equals(FormaPagamento.DINHEIRO)).Count() != pagamentos.Count())
                    {
                        IEnumerable<Conta> contas = GerenciadorConta.GetInstance(null).ObterPorSaida(saida.CodSaida);
                        foreach (Conta conta in contas)
                        {
                            bool possuiMovimentacaoFinanceira = GerenciadorMovimentacaoConta.GetInstance(null).ObterPorConta(conta.CodConta).Count() > 0;
                            if (possuiMovimentacaoFinanceira)
                                throw new NegocioException("Não é possível editar pedidos que já possuem PAGAMENTOS REALIZADOS.");
                        }
                    }
                }
                // Se houver documento fiscal aguardando impressão
                if (saida.TipoSaida == Saida.TIPO_PRE_VENDA)
                {
                    GerenciadorSolicitacaoDocumento.GetInstance().RemoverSolicitacaoDocumento(saida.CodSaida);
                }

                GerenciadorSaidaPagamento.GetInstance(saceContext).RemoverPorSaida(saida);
                if (saida.TipoSaida.Equals(Saida.TIPO_PRE_VENDA) || saida.TipoSaida.Equals(Saida.TIPO_REMESSA_DEPOSITO) ||
                    saida.TipoSaida.Equals(Saida.TIPO_RETORNO_DEPOSITO) || saida.TipoSaida.Equals(Saida.TIPO_DEVOLUCAO_FORNECEDOR) ||
                    saida.TipoSaida.Equals(Saida.TIPO_BAIXA_ESTOQUE_PERDA) || saida.TipoSaida.Equals(Saida.TIPO_USO_INTERNO) ||
                    saida.TipoSaida.Equals(Saida.TIPO_RETORNO_FORNECEDOR))
                {
                    RegistrarEstornoEstoque(saida, null);
                }
                if (saida.TipoSaida.Equals(Saida.TIPO_DEVOLUCAO_CONSUMIDOR))
                {
                    List<SaidaProduto> saidaProdutos = GerenciadorSaidaProduto.GetInstance(null).ObterPorSaida(saida.CodSaida);
                    RegistrarBaixaEstoque(saidaProdutos);
                }
                if (saida.TipoSaida.Equals(Saida.TIPO_PRE_VENDA) || saida.TipoSaida.Equals(Saida.TIPO_VENDA) ||
                    saida.TipoSaida.Equals(Saida.TIPO_BAIXA_ESTOQUE_PERDA) || saida.TipoSaida.Equals(Saida.TIPO_USO_INTERNO))
                    saida.TipoSaida = Saida.TIPO_ORCAMENTO;
                else if (saida.TipoSaida.Equals(Saida.TIPO_REMESSA_DEPOSITO))
                    saida.TipoSaida = Saida.TIPO_PRE_REMESSA_DEPOSITO;
                else if (saida.TipoSaida.Equals(Saida.TIPO_DEVOLUCAO_FORNECEDOR))
                    saida.TipoSaida = Saida.TIPO_PRE_DEVOLUCAO_FORNECEDOR;
                else if (saida.TipoSaida.Equals(Saida.TIPO_DEVOLUCAO_CONSUMIDOR))
                    saida.TipoSaida = Saida.TIPO_PRE_DEVOLUCAO_CONSUMIDOR;
                else if (saida.TipoSaida.Equals(Saida.TIPO_RETORNO_DEPOSITO))
                    saida.TipoSaida = Saida.TIPO_PRE_RETORNO_DEPOSITO;
                else if (saida.TipoSaida.Equals(Saida.TIPO_RETORNO_FORNECEDOR))
                    saida.TipoSaida = Saida.TIPO_PRE_RETORNO_FORNECEDOR;
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
                            LoginVendedor = saida.tb_pessoa1.tb_usuario.login,
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
                            CodLojaOrigem = saida.codLojaOrigem,
                            TipoDocumentoFiscal = saida.tipoDocumentoFiscal
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
        /// Obtem saidas pela data do pedido informada
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public object ObterPorDataPedido(string data)
        {
            DateTime dataConvertida = DateTime.Now;
            try
            {
                dataConvertida = Convert.ToDateTime(data);
            }
            catch (Exception)
            {
                // não precisa fazer nada
            }
            return GetQuery().Where(saida => saida.DataSaida >= dataConvertida).OrderBy(s => s.CodSaida).ToList();
        }


        /// <summary>
        /// Obtme todos os dados de uma saída por cupom fiscal
        /// </summary>
        /// <param name="codSaida"></param>
        /// <returns></returns>
        public List<SaidaPesquisa> ObterPorCupomFiscal(String cupomFiscal)
        {
            var query = from saida in saceContext.tb_saida
                        where saida.pedidoGerado.Equals(cupomFiscal)
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
            return query.ToList();
        }

        public List<SaidaPesquisa> ObterSaidaPorNfe(int codNfe)
        {

            var query = from saida in saceContext.tb_saida
                        where saida.tb_nfe.Select(nfe => nfe.codNFe).Contains(codNfe)
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
            return query.ToList();
        }

        /// <summary>
        /// Obtme todos os dados de uma saída
        /// </summary>
        /// <param name="codSaida"></param>
        /// <returns></returns>
        public List<Saida> ObterSaidaConsumidor(long codSaidaInicial)
        {
            List<int> listaCodSaidasExibir = new List<int>();
            listaCodSaidasExibir.AddRange(Saida.LISTA_TIPOS_VENDA);
            listaCodSaidasExibir.Add(Saida.TIPO_BAIXA_ESTOQUE_PERDA);
            listaCodSaidasExibir.Add(Saida.TIPO_USO_INTERNO);

            var query = (from saida in saceContext.tb_saida
                         where (listaCodSaidasExibir.Contains(saida.codTipoSaida) && (saida.codSaida >= codSaidaInicial))
                         orderby saida.codSaida descending
                         select saida.codSaida).Take(20);
            List<long> listaSaidas = query.ToList();
            // adiciona a lista a saída que está sendo buscada
            //if (codSaidaInicial > 0)
            //  listaSaidas.Add(codSaidaInicial);

            return GetQuery().Where(saida => listaCodSaidasExibir.Contains(saida.TipoSaida) && (saida.CodSaida >= listaSaidas.Min() || saida.CodSaida == codSaidaInicial)).OrderBy(s => s.CodSaida).ToList();

        }


        /// <summary>
        /// Obtme todos os dados de uma saída
        /// </summary>
        /// <param name="codSaida"></param>
        /// <returns></returns>
        public List<Saida> ObterSaidaPorAno(int ano)
        {
            return GetQuery().Where(saida => saida.DataSaida.Year == 2017).OrderBy(s => s.CodSaida).ToList();

        }
        /// <summary>
        /// Obter Troco por Período para todos os pagamentos
        /// </summary>
        /// <param name="codSaida"></param>
        /// <returns></returns>
        public decimal ObterTrocoPagamentos(DateTime dataInicial, DateTime dataFinal)
        {
            var query = (from saida in saceContext.tb_saida
                         where (saida.codTipoSaida == Saida.TIPO_PRE_VENDA 
                         || saida.codTipoSaida == Saida.TIPO_VENDA
                         || saida.codTipoSaida == Saida.TIPO_CREDITO)
                               && saida.dataSaida >= dataInicial
                               && saida.dataSaida <= dataFinal
                         select saida.troco);

            return query.Count() > 0 ? (decimal)query.Sum() : 0;
        }

        /// <summary>
        /// Obter Troco por Período apenas para Saidas
        /// </summary>
        /// <param name="codSaida"></param>
        /// <returns></returns>
        public decimal ObterTrocoSaidas(DateTime dataInicial, DateTime dataFinal)
        {
            var query = (from saida in saceContext.tb_saida
                         where (saida.codTipoSaida == Saida.TIPO_PRE_VENDA || saida.codTipoSaida == Saida.TIPO_VENDA)
                               && saida.dataSaida >= dataInicial 
                               && saida.dataSaida <= dataFinal
                         select saida.troco);

            return query.Count() > 0 ? (decimal)query.Sum() : 0;
        }

        /// <summary>
        /// Obtem todos as pré-vendas cujo cupom fiscal não foi emitido
        /// </summary>
        /// <param name="codSaida"></param>
        /// <returns></returns>
        public List<SaidaPesquisa> ObterPorPedido(string pedidoGerado)
        {
            var query = from saida in saceContext.tb_saida
                        where saida.pedidoGerado.StartsWith(pedidoGerado)
                        orderby saida.codSaida
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
            return query.ToList();
        }

        /// <summary>
        /// Obtme todos as pré-vendas cujo cupom fiscal não foi emitido
        /// </summary>
        /// <param name="codSaida"></param>
        /// <returns></returns>
        public List<SaidaPesquisa> ObterPorCodSaidas(List<long> listaCodSaidas)
        {
            var query = from saida in saceContext.tb_saida
                        where listaCodSaidas.Contains(saida.codSaida)
                        orderby saida.codSaida
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
            return query.ToList();
        }


        /// <summary>
        /// Obtme todos as pré-vendas cujo cupom fiscal não foi emitido
        /// </summary>
        /// <param name="codSaida"></param>
        /// <returns></returns>
        public List<SaidaPesquisa> ObterPorSolicitacaoSaida(List<tb_solicitacao_saida> listaSolicitacaoSaida)
        {
            List<long> listaCodSaida = listaSolicitacaoSaida.Select(s => s.codSaida).ToList();
            var query = from saida in saceContext.tb_saida
                        where listaCodSaida.Contains(saida.codSaida)
                        orderby saida.codSaida
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
            return query.ToList();
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
        /// Obtme todos as pré-vendas cujo cupom fiscal não foi emitido
        /// </summary>
        /// <param name="codSaida"></param>
        /// <returns></returns>
        public List<Saida> ObterVendasParticipacaoLucros(DateTime dataInicial, DateTime dataFinal, decimal valorVenda)
        {
            return GetQuery().Where(saida => (saida.TipoSaida == Saida.TIPO_PRE_VENDA || saida.TipoSaida == Saida.TIPO_VENDA || saida.TipoSaida == Saida.TIPO_BAIXA_ESTOQUE_PERDA || saida.TipoSaida == Saida.TIPO_USO_INTERNO) &&
                saida.CodCliente != 1324 &&
                saida.DataSaida >= dataInicial &&
                saida.DataSaida <= dataFinal &&
                saida.TotalAVista >= valorVenda).ToList();
        }

        public NumerosPeriodo ObterVendasMensalComparandoAnoAnterior()
        {
            DateTime dataAtual = DateTime.Now.AddDays(-1);
           
            var query = from saida in saceContext.tb_saida
                        where saida.dataSaida.Year == dataAtual.Year 
                        && saida.dataSaida.Month == dataAtual.Month
                        && saida.dataSaida.Day <= dataAtual.Day
                        && (saida.codTipoSaida == 2 || saida.codTipoSaida == 3)
                        group saida by new
                        {
                            PeriodoAno = saida.dataSaida.Year,

                        } into saidaPeriodoAno
                        select new NumerosPeriodo
                        {
                            NumeroVendas = saidaPeriodoAno.Count(),
                            TotalVendas = (decimal) saidaPeriodoAno.Sum(s => s.totalAVista)
                        };
            NumerosPeriodo numerosPeriodo = query.First();


            var query2 = from saida in saceContext.tb_saida
                        where saida.dataSaida.Year == (dataAtual.Year-1)
                        && saida.dataSaida.Month == dataAtual.Month
                        && saida.dataSaida.Day <= dataAtual.Day
                        && (saida.codTipoSaida == 2 || saida.codTipoSaida == 3)
                        group saida by new
                        {
                            PeriodoAno = saida.dataSaida.Year,

                        } into saidaPeriodoAno
                        select new NumerosPeriodo
                        {
                            NumeroVendas = saidaPeriodoAno.Count(),
                            TotalVendas = (decimal)saidaPeriodoAno.Sum(s => s.totalAVista)
                        };
            NumerosPeriodo numerosPeriodoAnoAnterior = query2.First();

            NumerosPeriodo resultado = new NumerosPeriodo();
            resultado.NumeroVendas = (numerosPeriodo.NumeroVendas / numerosPeriodoAnoAnterior.NumeroVendas - 1) * 100;
            resultado.TotalVendas =  (numerosPeriodo.TotalVendas / numerosPeriodoAnoAnterior.TotalVendas - 1) * 100;
            return resultado;
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
        /// Obtém somatório de vendas por grupo de produtos em um dado período de tempo
        /// </summary>
        /// <param name="codGrupo"></param>
        /// <param name="dataInicial"></param>
        /// <param name="dataFinal"></param>
        /// <returns></returns>
        public List<VendasGrupoProduto> ObterVendasPorGrupo(int codGrupo, DateTime dataInicial, DateTime dataFinal)
        {
            var query = from saidaProduto in saceContext.SaidaProdutoSet
                        where saidaProduto.tb_produto.codGrupo == codGrupo &&
                        saidaProduto.tb_saida.dataSaida >= dataInicial &&
                        saidaProduto.tb_saida.dataSaida <= dataFinal &&
                        (saidaProduto.tb_saida.codTipoSaida == 2 ||
                        saidaProduto.tb_saida.codTipoSaida == 3)
                        group saidaProduto by new
                        {
                            Ano = saidaProduto.tb_saida.dataSaida.Year,
                            Mes = saidaProduto.tb_saida.dataSaida.Month,

                        } into groupSaidaProduto
                        orderby groupSaidaProduto.Key.Ano, groupSaidaProduto.Key.Mes
                        select new VendasGrupoProduto
                        {
                           CodGrupo = codGrupo,
                           MesAno = groupSaidaProduto.Key.Mes + "/" + groupSaidaProduto.Key.Ano,
                           TotalVendas = groupSaidaProduto.Sum(p => p.subtotalAVista)
                        };
            return query.ToList();
        }

        public List<VendasVendedor> ObterVendasPorVendedor(DateTime dataInicial, DateTime dataFinal)
        {
            dataInicial = dataInicial.Date;
            dataFinal = dataFinal.Date.AddDays(1);
            
            var query = from saida in saceContext.tb_saida
                        where saida.dataSaida >= dataInicial &&
                            saida.dataSaida <= dataFinal &&
                            (saida.codTipoSaida == 2 || saida.codTipoSaida == 3)
                        group saida by saida.codProfissional into groupSaidaProduto
                        select new VendasVendedor
                        {
                            CodProfissional = groupSaidaProduto.Key.Value,
                            TotalVendas = groupSaidaProduto.Sum(s => s.totalAVista),
                            TotalLucro = groupSaidaProduto.Sum(s => s.totalLucro)
                        };
            var listaInicial = query.ToList();
            decimal? somaTotalAVista = listaInicial.Sum(s => s.TotalVendas);
            decimal? somaLucro = listaInicial.Sum(s => s.TotalLucro);
            foreach( var item in listaInicial )
            {
                item.PercentualVendas = item.TotalVendas / somaTotalAVista * 100;
                item.PercentualLucro = item.TotalLucro / somaLucro * 100;
                item.Login = saceContext.UsuarioSet.SingleOrDefault(u => u.codPessoa == item.CodProfissional).login; 
            }
            return listaInicial.OrderBy(v => v.Login).ToList();
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
                    else if (saida.TipoSaida.Equals(Saida.TIPO_ORCAMENTO) && (tipo_encerramento.Equals(Saida.TIPO_PRE_VENDA)))
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
                    else if (tipo_encerramento.Equals(Saida.TIPO_BAIXA_ESTOQUE_PERDA) || tipo_encerramento.Equals(Saida.TIPO_USO_INTERNO))
                    {
                        saida.TipoSaida = tipo_encerramento;
                        saida.CodSituacaoPagamentos = SituacaoPagamentos.QUITADA;

                        List<SaidaProduto> saidaProdutos = GerenciadorSaidaProduto.GetInstance(saceContext).ObterPorSaida(saida.CodSaida);
                        Decimal somaPrecosCusto = RegistrarBaixaEstoque(saidaProdutos);
                        saida.TotalLucro = 0;
                        saida.TotalLucro -= somaPrecosCusto;
                        Atualizar(saida);
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
        public void EncerrarDevolucaoConsumidor(Saida saida)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                try
                {
                    saida.TipoSaida = Saida.TIPO_DEVOLUCAO_CONSUMIDOR;
                    //saida.CodCliente = consumidor.CodPessoa;
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
        /// Faz o encerramento de um retorno de mercadorias que o fornecedor não aceitou a devolução
        /// </summary>
        /// <param name="saida"></param>
        /// <param name="consumidor"></param>
        public void EncerrarRetornoFornecedor(Saida saida)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                try
                {
                    saida.TipoSaida = Saida.TIPO_RETORNO_FORNECEDOR;
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
                return saida.TotalAVista + saida.ValorICMSSubst + saida.ValorFrete + saida.ValorSeguro - saida.Desconto + saida.OutrasDespesas + saida.ValorIPI;
            else
                return saida.TotalAVista + saida.ValorICMS + saida.ValorFrete + saida.ValorSeguro - saida.Desconto + saida.OutrasDespesas + saida.ValorIPI;
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

            if (saida.TipoSaida.Equals(Saida.TIPO_PRE_CREDITO))
            {
                // Para cada pagamento é criada uma nova conta
                Conta conta = new Conta();
                conta.CodPessoa = saida.CodCliente;
                conta.CodPlanoConta = PlanoConta.SAIDA_PRODUTOS;
                conta.CodSaida = saida.CodSaida;
                conta.CodEntrada = Global.ENTRADA_PADRAO; // entrada não válida
                conta.CodPessoa = saida.CodCliente;
                conta.CodPagamento = 0; //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXx
                conta.Desconto = 0;
                conta.FormatoConta = Conta.FORMATO_CONTA_CREDITO;
                conta.NumeroDocumento = "";
                conta.CodSituacao = SituacaoConta.SITUACAO_ABERTA.ToString();
                conta.TipoConta = Conta.CONTA_RECEBER.ToString();
                conta.Valor = (decimal)saida.TotalAVista * (-1);

                conta.DataVencimento = saida.DataSaida;
                conta.Desconto = 0;
                conta.CodConta = GerenciadorConta.GetInstance(saceContext).Inserir(conta);
            }


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
                if (pagamento.CodFormaPagamento == FormaPagamento.DINHEIRO || pagamento.CodFormaPagamento == FormaPagamento.DEPOSITO_PIX)
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


                for (int i = 0; i < pagamento.Parcelas; i++)
                {
                    if (pagamento.CodFormaPagamento == FormaPagamento.CARTAO)
                    {
                        CartaoCredito cartaoCredito = GerenciadorCartaoCredito.GetInstance().Obter(pagamento.CodCartaoCredito).ElementAt(0);
                        pagamento.Data = pagamento.Data.AddDays((double)cartaoCredito.DiaBase);
                        conta.DataVencimento = pagamento.Data;
                        conta.Desconto = (pagamento.Valor * cartaoCredito.Desconto / 100) / pagamento.Parcelas;

                    }
                    else if (pagamento.CodFormaPagamento == FormaPagamento.CREDIARIO)
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



                if (pagamento.CodFormaPagamento == FormaPagamento.DINHEIRO || 
                    pagamento.CodFormaPagamento == FormaPagamento.DEPOSITO_PIX)
                {
                    MovimentacaoConta movimentacao = new MovimentacaoConta();
                    movimentacao.CodContaBanco = pagamento.CodContaBanco;
                    movimentacao.CodConta = conta.CodConta;
                    movimentacao.CodResponsavel = saida.CodCliente;
                    movimentacao.DataHora = pagamento.Data;
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
                saidaProduto.Quantidade *= (-1); // inverte sinal da quantidade para fazer o retorno
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
                    custoAtual = Convert.ToDecimal(0.7) * saidaProduto.PrecoVendaVarejo * saidaProduto.Quantidade;
                }
                else if (custoAtual >= (saidaProduto.PrecoVendaVarejo * saidaProduto.Quantidade))
                {
                    custoAtual = saidaProduto.PrecoVendaVarejo * saidaProduto.Quantidade;
                }

                if (custoEstoque <= 0)
                {
                    custoEstoque = Convert.ToDecimal(0.7) * saidaProduto.PrecoVendaVarejo * saidaProduto.Quantidade;
                }
                else if (custoEstoque >= (saidaProduto.PrecoVendaVarejo * saidaProduto.Quantidade))
                {
                    custoEstoque = saidaProduto.PrecoVendaVarejo * saidaProduto.Quantidade;
                }

                if (custoEstoque < custoAtual)
                {
                    somaPrecosCusto += custoEstoque;
                }
                else
                {
                    somaPrecosCusto += custoAtual;
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


        public bool SolicitaImprimirDAV(List<long> listaCodSaidas, decimal total, decimal totalAVista, decimal desconto, Global.Impressora impressora)
        {
            string tipoDocumento = impressora.Equals(Global.Impressora.REDUZIDO1) ? "REDUZIDO1" : "REDUZIDO2";

            if (GerenciadorImprimirDocumento.GetInstance().ObterPorTipoDocumentoCodDocumento(tipoDocumento, listaCodSaidas.Min()).Count() > 0)
                throw new NegocioException("Documento já foi solicitado para impressão. Verifique se impressora ligada.");


            var repImprimirDocumento = new RepositorioGenerico<tb_imprimir_documento>();

            var context = (SaceEntities)repImprimirDocumento.ObterContexto();

            tb_imprimir_documento documento = new tb_imprimir_documento();
            documento.desconto = desconto;
            documento.hostSolicitante = System.Windows.Forms.SystemInformation.ComputerName;
            documento.tipoDocumento = tipoDocumento;
            documento.total = total;
            documento.totalAVista = totalAVista;
            documento.codDocumento = listaCodSaidas.Min();
            repImprimirDocumento.Inserir(documento);

            var query = from saida in context.tb_saida
                        where listaCodSaidas.Contains(saida.codSaida)
                        select saida;

            List<tb_saida> saidas = query.ToList();
            foreach (tb_saida saida in saidas)
            {
                documento.tb_saida.Add(saida);
            }
            repImprimirDocumento.SaveChanges();
            return true;
        }


        public bool ImprimirDAV(Global.Impressora impressora, string portaImpressora)
        {
            string tipoDocumento = impressora.Equals(Global.Impressora.REDUZIDO1) ? "REDUZIDO1" : "REDUZIDO2";

            var repImprimirDocumento = new RepositorioGenerico<tb_imprimir_documento>();

            var saceContext = (SaceEntities)repImprimirDocumento.ObterContexto();

            var query = from documento in saceContext.tb_imprimir_documento
                        where tipoDocumento.Equals(documento.tipoDocumento)
                        select documento;

            List<tb_imprimir_documento> documentos = query.ToList();
            foreach (tb_imprimir_documento documento in documentos)
            {
                List<long> listaCodSaidas = documento.tb_saida.Select(s => s.codSaida).ToList();
                repImprimirDocumento.Remover(documento);
                repImprimirDocumento.SaveChanges();
                List<SaidaPesquisa> saidas = ObterPorCodSaidas(listaCodSaidas).ToList();
                if (impressora.Equals(Global.Impressora.REDUZIDO1))
                    return ImprimirDAVComprimido(saidas, (decimal)documento.total, (decimal)documento.totalAVista, (decimal)documento.desconto, portaImpressora);
                else
                    ImprimirDAVComprimidoVip(saidas, (decimal)documento.total, (decimal)documento.totalAVista, (decimal)documento.desconto, portaImpressora);

            }
            return true;
        }

        private bool ImprimirDAVComprimido(List<SaidaPesquisa> saidas, decimal total, decimal totalAVista, decimal desconto, string portaImpressora)
        {
            try
            {
                ImprimeTexto imp = new ImprimeTexto();
                if (!imp.Inicio(portaImpressora))
                {
                    return false;
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
                foreach (SaidaPesquisa saida in saidas)
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


        private void ImprimirDAVComprimidoVip(List<SaidaPesquisa> saidas, decimal total, decimal totalAVista, decimal desconto, string porta)
        {
            var printer = new Printer(porta, PrinterType.Bematech);

            Loja loja = GerenciadorLoja.GetInstance().Obter(Global.LOJA_PADRAO).ElementAt(0);
            Pessoa pessoaLoja = (Pessoa)GerenciadorPessoa.GetInstance().Obter(loja.CodPessoa).ElementAt(0);

            //chamando a função para impressão do texto
            printer.WriteLine(Global.LINHA_COMPRIMIDA);
            if (saidas[0].TipoSaida == Saida.TIPO_ORCAMENTO)
                printer.WriteLine(StringUtil.PadBoth("DOCUMENTO AUXILIAR DE VENDA - ORCAMENTO", 42));
            else
                printer.WriteLine(StringUtil.PadBoth("DOCUMENTO AUXILIAR DE VENDA - PEDIDO", 42));
            printer.WriteLine(StringUtil.PadBoth("NAO E DOCUMENTO FISCAL - NAO E VALIDO COMO", 42));
            printer.WriteLine(StringUtil.PadBoth("RECIBO E COMO GARANTIA DE MERCADORIA", 42));
            printer.WriteLine(StringUtil.PadBoth("NAO COMPROVA PAGAMENTO", 42));
            printer.WriteLine(Global.LINHA_COMPRIMIDA);

            printer.WriteLine(StringUtil.PadBoth(pessoaLoja.Nome, 42));
            printer.WriteLine(StringUtil.PadBoth(pessoaLoja.Endereco + "  Fone: " + pessoaLoja.Fone1, 42));
            printer.WriteLine(Global.LINHA_COMPRIMIDA);


            Pessoa cliente = (Pessoa)GerenciadorPessoa.GetInstance().Obter(saidas[0].CodCliente).ElementAt(0);

            if (cliente.NomeFantasia.Length > 32)
                printer.WriteLine("Cliente: " + cliente.NomeFantasia.Substring(1, 32));
            else
                printer.WriteLine("Cliente: " + cliente.NomeFantasia);

            if (saidas.Count == 1)
            {
                printer.WriteLine("Pedido: " + saidas[0].CodSaida + "      Data: " + saidas[0].DataSaida.ToShortDateString());
                if (!string.IsNullOrEmpty(saidas[0].CupomFiscal))
                    printer.WriteLine("NFe: " + saidas[0].CupomFiscal);
            }
            printer.WriteLine(Global.LINHA_COMPRIMIDA);
            printer.WriteLine("Cod    Produto");
            printer.WriteLine("       Qtdade   UN  Preco(R$) Subtotal(R$)");
            printer.WriteLine(Global.LINHA_COMPRIMIDA);
            foreach (SaidaPesquisa saida in saidas)
            {
                if (saidas.Count > 1)
                {
                    printer.WriteLine("=> Documento: " + saida.CodSaida + " Data: " + saida.DataSaida.ToShortDateString() + " CF:" + saida.CupomFiscal + "\n");
                }

                List<SaidaProduto> saidaProdutos = GerenciadorSaidaProduto.GetInstance(saceContext).ObterPorSaida(saida.CodSaida);
                foreach (SaidaProduto produto in saidaProdutos)
                {
                    printer.Write(produto.CodProduto.ToString().PadLeft(6));
                    printer.Write(" ");
                    if (produto.Nome.Length > 33)
                        printer.WriteLine(produto.Nome.Substring(1, 33));
                    else
                        printer.WriteLine(produto.Nome.PadRight(33));
                    printer.Write("      ");
                    printer.Write(produto.Quantidade.ToString().PadLeft(9));
                    printer.Write(" ");
                    printer.Write(produto.Unidade);
                    printer.Write(produto.ValorVenda.ToString("N2").PadLeft(12));
                    printer.Write(" ");
                    printer.WriteLine(produto.Subtotal.ToString("N2").PadLeft(11));
                }
            }

            printer.WriteLine(Global.LINHA_COMPRIMIDA);
            printer.WriteLine("Total Venda: " + total + " Desconto: " + desconto.ToString("N2") + "%");
            printer.WriteLine("Total Pagar: " + totalAVista.ToString("N2"));
            printer.WriteLine(Global.LINHA_COMPRIMIDA);
            printer.WriteLine(" E vedada a autenticacao deste documento");
            if (!saidas[0].CupomFiscal.Equals(""))
            {
                printer.WriteLine("  Documento Válido por 3 (tres) dias");
            }
            printer.WriteLine(Global.LINHA_COMPRIMIDA);
            if (!saidas[0].CodCliente.Equals(Global.CLIENTE_PADRAO))
            {
                printer.WriteLine(" ");
                printer.WriteLine("Recebido por:");
                //printer.WriteLine(Global.LINHA_COMPRIMIDA);
            }

            try
            {
                // 2 cópias
                printer.WriteLine(" ");
                printer.WriteLine(" ");
                printer.WriteLine(" ");
                printer.WriteLine(" ");
                printer.WriteLine(" ");
                printer.PartialPaperCut();
                printer.PrintDocument(2);

            }
            catch (Exception e)
            {
                throw new NegocioException("Impressora indisponível. Verificar se ela está ligada e conectada.", e);
            }

        }

        public void ImprimirCreditoPagamento(Saida saidaCredito, string portaImpressora)
        {
            var printer = new Printer(portaImpressora, PrinterType.Bematech);
            Loja loja = GerenciadorLoja.GetInstance().Obter(Global.LOJA_PADRAO).ElementAt(0);
            Pessoa pessoaLoja = (Pessoa)GerenciadorPessoa.GetInstance().Obter(loja.CodPessoa).ElementAt(0);

            printer.WriteLine(Global.LINHA_COMPRIMIDA);

            printer.WriteLine(StringUtil.PadBoth("DOCUMENTO AUXILIAR DE VENDA - CREDITO", 42));
            printer.WriteLine(StringUtil.PadBoth("NAO E DOCUMENTO FISCAL - NAO E VALIDO COMO", 42));
            printer.WriteLine(StringUtil.PadBoth("RECIBO E COMO GARANTIA DE MERCADORIA", 42));
            printer.WriteLine(Global.LINHA_COMPRIMIDA);

            printer.WriteLine(StringUtil.PadBoth(pessoaLoja.Nome, 42));
            printer.WriteLine(StringUtil.PadBoth(pessoaLoja.Endereco + "  Fone: " + pessoaLoja.Fone1, 42));
            printer.WriteLine(Global.LINHA_COMPRIMIDA);
            Pessoa cliente = GerenciadorPessoa.GetInstance().Obter(saidaCredito.CodCliente).ElementAt(0);

            printer.WriteLine("Cliente: " + cliente.NomeFantasia);
            printer.WriteLine("Data/Hora: " + saidaCredito.DataSaida);

            printer.WriteLine(Global.LINHA_COMPRIMIDA);
            printer.WriteLine(" ");
            printer.WriteLine("Foi creditado na conta do cliente R$ " + saidaCredito.TotalAVista);
            printer.WriteLine(" ");

            printer.WriteLine(" ");
            printer.WriteLine(Global.LINHA_COMPRIMIDA);
            printer.WriteLine(" ");
            printer.WriteLine("Recebido por:");
            printer.WriteLine(Global.LINHA_COMPRIMIDA);

            try
            {
                printer.WriteLine(" ");
                printer.WriteLine(" ");
                printer.WriteLine(" ");
                printer.WriteLine(" ");
                printer.PartialPaperCut();
                printer.PrintDocument();

            }
            catch (Exception e)
            {
                throw new NegocioException("Impressora indisponível. Verificar se ela está ligada e conectada.", e);
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
            _saidaE.tipoDocumentoFiscal = saida.TipoDocumentoFiscal;

        }
    }
}