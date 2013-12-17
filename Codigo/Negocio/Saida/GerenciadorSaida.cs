using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using Dados;
using Dominio;
using Util;


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
                
                foreach (tb_saida _saidaE in query)
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
        public void AtualizarNfePorPedidoGerado(string nfe, string observacao, string pedidoGerado)
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
                    _saidaE.totalAVista = totalAVista;
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
                
                if (saida.TipoSaida.Equals(Saida.TIPO_ORCAMENTO) || saida.TipoSaida.Equals(Saida.TIPO_PRE_DEVOLUCAO) ||
                    saida.TipoSaida.Equals(Saida.TIPO_PRE_REMESSA) || saida.TipoSaida.Equals(Saida.TIPO_PRE_RETORNO_DEPOSITO))
                {
                    repSaida.Remover(s => s.codSaida == saida.CodSaida);
                    saceContext.SaveChanges();
                }
                else if (saida.TipoSaida.Equals(Saida.TIPO_REMESSA_DEPOSITO) || saida.TipoSaida.Equals(Saida.TIPO_DEVOLUCAO_FORNECEDOR)
                    || saida.TipoSaida.Equals(Saida.TIPO_RETORNO_DEPOSITO))
                {
                    RegistrarEstornoEstoque(saida);
                    repSaida.Remover(s => s.codSaida == saida.CodSaida);
                    repSaida.SaveChanges();
                }
                
                else if (saida.TipoSaida.Equals(Saida.TIPO_PRE_VENDA) || saida.TipoSaida.Equals(Saida.TIPO_VENDA))
                {
                    RegistrarEstornoEstoque(saida);
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
                ExcluirDocumentoFiscal(saida.CodSaida);
                GerenciadorSaidaPagamento.GetInstance(saceContext).RemoverPorSaida(saida);
                if (saida.TipoSaida.Equals(Saida.TIPO_PRE_VENDA) || saida.TipoSaida.Equals(Saida.TIPO_REMESSA_DEPOSITO) ||
                    saida.TipoSaida.Equals(Saida.TIPO_RETORNO_DEPOSITO) || saida.TipoSaida.Equals(Saida.TIPO_DEVOLUCAO_FORNECEDOR))
                {
                    RegistrarEstornoEstoque(saida);
                }
                if (saida.TipoSaida.Equals(Saida.TIPO_PRE_VENDA) || saida.TipoSaida.Equals(Saida.TIPO_VENDA))
                    saida.TipoSaida = Saida.TIPO_ORCAMENTO;
                else if (saida.TipoSaida.Equals(Saida.TIPO_REMESSA_DEPOSITO)) 
                    saida.TipoSaida = Saida.TIPO_PRE_REMESSA;
                else if (saida.TipoSaida.Equals(Saida.TIPO_DEVOLUCAO_FORNECEDOR))
                    saida.TipoSaida = Saida.TIPO_PRE_DEVOLUCAO;
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
                            BaseCalculoICMSSubst = (decimal) saida.baseCalculoICMSSubst,
                            CodCliente = saida.codCliente,
                            CodEmpresaFrete = saida.codEmpresaFrete,
                            CodProfissional = (long) saida.codProfissional,
                            CodEntrada = saida.codEntrada,
                            CodSituacaoPagamentos = saida.codSituacaoPagamentos,
                            CodSaida = saida.codSaida,
                            CpfCnpj = saida.cpf_cnpj,
                            DataSaida = saida.dataSaida,
                            Desconto = (decimal) saida.desconto ,
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
                            DataEmissaoCupomFiscal = saida.dataEmissaoDocFiscal == null ? saida.dataSaida : (DateTime) saida.dataEmissaoDocFiscal,
                            PesoBruto =  (decimal)saida.pesoBruto,
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
            if (codSaidaInicial <= 0) 
                return GetQuery().Where(saida => saida.TipoSaida == Saida.TIPO_ORCAMENTO ||
                    saida.TipoSaida == Saida.TIPO_PRE_VENDA || saida.TipoSaida == Saida.TIPO_VENDA).OrderByDescending(s => s.CodSaida).Take(20).OrderBy(s => s.CodSaida).ToList();
            else
                return GetQuery().Where(saida => saida.TipoSaida == Saida.TIPO_ORCAMENTO ||
                    saida.TipoSaida == Saida.TIPO_PRE_VENDA || saida.TipoSaida == Saida.TIPO_VENDA && saida.CodSaida >= codSaidaInicial).OrderBy(s => s.CodSaida).ToList();
        }

        /// <summary>
        /// Obtme todos as pré-vendas cujo cupom fiscal não foi emitido
        /// </summary>
        /// <param name="codSaida"></param>
        /// <returns></returns>
        public List<Saida> ObterPorPedido(string pedidoGerado)
        {
            return GetQuery().Where(saida => saida.CupomFiscal.StartsWith(pedidoGerado)).OrderBy(s => s.CodSaida).ToList();
        }

        /// <summary>
        /// Obtme todos as pré-vendas cujo cupom fiscal não foi emitido
        /// </summary>
        /// <param name="codSaida"></param>
        /// <returns></returns>
        public List<Saida> ObterPorNomeCliente(string nomeCliente)
        {
            return GetQuery().Where(saida => saida.NomeCliente.StartsWith(nomeCliente)).OrderBy(s => s.CodSaida).ToList();
        }

        /// <summary>
        /// Obtme todos as pré-vendas cujo cupom fiscal não foi emitido
        /// </summary>
        /// <param name="codSaida"></param>
        /// <returns></returns>
        public List<Saida> ObterPreVendasPendentes()
        {
            return GetQuery().Where(saida => saida.TipoSaida == Saida.TIPO_PRE_VENDA &&
                saida.CupomFiscal.Trim().Equals("") && saida.CodSituacaoPagamentos == SituacaoPagamentos.QUITADA && saida.CodCliente==Global.CLIENTE_PADRAO).OrderBy(s => s.CodSaida).ToList();
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
        public void Encerrar(long codSaida, int tipo_encerramento, List<SaidaPagamento> saidaPagamentos)
        {
            DbTransaction transaction = null;
            try
            {
                if (saceContext.Connection.State == System.Data.ConnectionState.Closed)
                    saceContext.Connection.Open();
                transaction = saceContext.Connection.BeginTransaction();
                var query = from saidaE in saceContext.tb_saida
                            where saidaE.codSaida == codSaida
                            select saidaE;
                tb_saida _saidaE = query.ToList().ElementAtOrDefault(0);
                if (_saidaE != null)
                {

                    if (_saidaE.codTipoSaida.Equals(Saida.TIPO_ORCAMENTO) && tipo_encerramento.Equals(Saida.TIPO_ORCAMENTO))
                    {
                        _saidaE.codTipoSaida = Saida.TIPO_ORCAMENTO;
                        saceContext.SaveChanges();
                    }
                    else if (_saidaE.codTipoSaida.Equals(Saida.TIPO_ORCAMENTO) && tipo_encerramento.Equals(Saida.TIPO_PRE_VENDA))
                    {
                        _saidaE.codTipoSaida = Saida.TIPO_PRE_VENDA;
                        _saidaE.codSituacaoPagamentos = SituacaoPagamentos.LANCADOS;

                        List<SaidaProduto> saidaProdutos = GerenciadorSaidaProduto.GetInstance(saceContext).ObterPorSaida(codSaida);
                        Decimal somaPrecosCusto = RegistrarBaixaEstoque(saidaProdutos);

                        _saidaE.totalLucro = _saidaE.totalAVista - somaPrecosCusto;
                        saceContext.SaveChanges();

                        RegistrarPagamentosSaida(saidaPagamentos, _saidaE);
                    }
                    else if (tipo_encerramento.Equals(Saida.TIPO_REMESSA_DEPOSITO))
                    {
                        _saidaE.codTipoSaida = Saida.TIPO_REMESSA_DEPOSITO;
                        if (!string.IsNullOrEmpty(_saidaE.nfe))
                        {
                            throw new NegocioException("Não é possível finalizar uma saída para Depósito cuja nota fiscal já foi emitida.");
                        }

                        Loja lojaDestino = GerenciadorLoja.GetInstance().ObterPorPessoa(_saidaE.codCliente).ElementAt(0);
                        if (lojaDestino.CodLoja.Equals(_saidaE.codLojaOrigem))
                        {
                            throw new NegocioException("Não pode ser feita transferência de produtos para a mesma loja.");
                        }

                        List<SaidaProduto> saidaProdutos = GerenciadorSaidaProduto.GetInstance(saceContext).ObterPorSaida(_saidaE.codSaida);
                        saceContext.SaveChanges();
                        RegistrarTransferenciaEstoque(saidaProdutos, Global.LOJA_PADRAO, lojaDestino.CodLoja);
                    }
                    else if (tipo_encerramento.Equals(Saida.TIPO_RETORNO_DEPOSITO))
                    {
                        _saidaE.codTipoSaida = Saida.TIPO_RETORNO_DEPOSITO;
                        if (!string.IsNullOrEmpty(_saidaE.nfe))
                        {
                            throw new NegocioException("Não é possível finalizar uma saída para Depósito cuja nota fiscal já foi emitida.");
                        }


                        //Loja depositoOrigem = GerenciadorLoja.GetInstance().ObterPorPessoa(_saidaE.codLojaOrigem).ElementAt(0);
                        if (_saidaE.codLojaOrigem.Equals(Global.LOJA_PADRAO))
                        {
                            throw new NegocioException("Não pode ser feita transferência de produtos para a mesma loja.");
                        }

                        List<SaidaProduto> saidaProdutos = GerenciadorSaidaProduto.GetInstance(saceContext).ObterPorSaida(_saidaE.codSaida);
                        saceContext.SaveChanges();
                        RegistrarTransferenciaEstoque(saidaProdutos, _saidaE.codLojaOrigem, Global.LOJA_PADRAO);
                    }
                    else if (tipo_encerramento.Equals(Saida.TIPO_DEVOLUCAO_FORNECEDOR))
                    {
                        _saidaE.codTipoSaida = Saida.TIPO_DEVOLUCAO_FORNECEDOR;
                        if (string.IsNullOrEmpty(_saidaE.nfe))
                        {
                            saceContext.SaveChanges();
                            List<SaidaProduto> saidaProdutos = GerenciadorSaidaProduto.GetInstance(saceContext).ObterPorSaida(_saidaE.codSaida);
                            RegistrarBaixaEstoque(saidaProdutos);
                        }
                    }
                }
                transaction.Commit();
            }
            catch (NegocioException ne)
            {
                transaction.Rollback();
                throw ne;
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw new DadosException("Problemas no encerramento da saída. Favor contactar o administrador.", e);
            }
            finally
            {
                saceContext.Connection.Close();
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
        public void RegistrarPagamentosSaida(List<SaidaPagamento> pagamentos, tb_saida saidaE)
        {
            decimal totalRegistrado = 0;

            foreach (SaidaPagamento pagamento in pagamentos)
            {

                List<Conta> contas = GerenciadorConta.GetInstance(saceContext).ObterPorSaidaPagamento(saidaE.codSaida, pagamento.CodSaidaPagamento).ToList();

                if (contas.Count > 0)
                {
                    totalRegistrado += pagamento.Valor;
                    continue;
                }
                // Para cada pagamento é criada uma nova conta
                Conta conta = new Conta();
                conta.CodPessoa = saidaE.codCliente;
                conta.CodPlanoConta = PlanoConta.SAIDA_PRODUTOS;
                conta.CodSaida = saidaE.codSaida;
                conta.CodEntrada = Global.ENTRADA_PADRAO; // entrada não válida
                conta.CodPessoa = saidaE.codCliente;
                conta.CodPagamento = pagamento.CodSaidaPagamento;
                conta.Desconto = 0;

                // Quando o pagamento é realizado em dinheiro a conta já é inserida quitada
                if (pagamento.CodFormaPagamento == FormaPagamento.DINHEIRO)
                    conta.CodSituacao = SituacaoConta.SITUACAO_QUITADA.ToString();
                else
                    conta.CodSituacao = SituacaoConta.SITUACAO_ABERTA.ToString();

                if (pagamento.CodFormaPagamento == FormaPagamento.CARTAO)
                {
                    conta.CodPessoa = GerenciadorCartaoCredito.GetInstance().Obter(pagamento.CodCartaoCredito).ElementAt(0).CodPessoa;
                }

                conta.TipoConta = Conta.CONTA_RECEBER.ToString();

                if (((totalRegistrado + pagamento.Valor) >= saidaE.totalAVista) && (pagamento.CodFormaPagamento == FormaPagamento.DINHEIRO))
                {
                    conta.Valor = ((decimal)saidaE.totalAVista - totalRegistrado) / pagamento.Parcelas;
                }
                else if (pagamento.CodFormaPagamento == FormaPagamento.CREDIARIO)
                {
                    conta.Valor = ((decimal)saidaE.total / pagamento.Parcelas);
                    conta.Desconto = ((decimal)saidaE.total - (decimal)saidaE.totalAVista) / pagamento.Parcelas;
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
                        conta.DataVencimento = saidaE.dataSaida.AddDays(pagamento.IntervaloDias);
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
                    movimentacao.CodResponsavel = saidaE.codCliente;
                    movimentacao.DataHora = DateTime.Now;
                    if (totalRegistrado > saidaE.totalAVista)
                    {
                        movimentacao.Valor = pagamento.Valor - (decimal) saidaE.troco;
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
        /// </summary>
        /// <param name="saidaProdutos"></param>
        public void RegistrarEstornoEstoque(Saida saida)
        {
            List<SaidaProduto> saidaProdutos = GerenciadorSaidaProduto.GetInstance(saceContext).ObterPorSaida(saida.CodSaida);
            foreach (SaidaProduto saidaProduto in saidaProdutos)
            {
                ProdutoPesquisa produto = GerenciadorProduto.GetInstance().Obter(saidaProduto.CodProduto).ElementAt(0);

                if (produto.CodCST != Cst.ST_OUTRAS)
                {
                    GerenciadorProdutoLoja.GetInstance(saceContext).AdicionaQuantidade(saidaProduto.Quantidade, 0, Global.LOJA_PADRAO, saidaProduto.CodProduto);
                }
                else
                {
                    GerenciadorProdutoLoja.GetInstance(saceContext).AdicionaQuantidade(0, saidaProduto.Quantidade, Global.LOJA_PADRAO, saidaProduto.CodProduto);
                }

                GerenciadorEntradaProduto.GetInstance(saceContext).BaixarItensVendidosEstoque(produto, saidaProduto.DataValidade, saidaProduto.Quantidade);
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
                decimal custoAtual = produto.PrecoCusto * saidaProduto.Quantidade;

                // Baixa sempre o estoque da loja matriz
                if (produto.CodCST != Cst.ST_OUTRAS)
                {
                    GerenciadorProdutoLoja.GetInstance(saceContext).AdicionaQuantidade(saidaProduto.Quantidade * (-1), 0, Global.LOJA_PADRAO, saidaProduto.CodProduto);
                }
                else
                {
                    GerenciadorProdutoLoja.GetInstance(saceContext).AdicionaQuantidade(0, saidaProduto.Quantidade * (-1), Global.LOJA_PADRAO, saidaProduto.CodProduto);
                }

                decimal custoEstoque = GerenciadorEntradaProduto.GetInstance(saceContext).BaixarItensVendidosEstoque(produto, saidaProduto.DataValidade, saidaProduto.Quantidade);
                // Se não houver preço de custo do produto
                if (custoAtual <= 0)
                {
                    custoAtual = Convert.ToDecimal(0.8) * produto.PrecoVendaVarejo * saidaProduto.Quantidade;
                }
                else if (custoAtual >= (produto.PrecoVendaVarejo * saidaProduto.Quantidade))
                {
                    custoAtual = produto.PrecoVendaVarejo * saidaProduto.Quantidade;
                }

                if (custoEstoque <= 0)
                {
                    custoEstoque = Convert.ToDecimal(0.8) * produto.PrecoVendaVarejo * saidaProduto.Quantidade;
                }
                else if (custoEstoque >= (produto.PrecoVendaVarejo * saidaProduto.Quantidade))
                {
                    custoEstoque = produto.PrecoVendaVarejo * saidaProduto.Quantidade;
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

        /// <summary>
        /// Gera o cupom fiscal a partir das saídas e valores a vista de cada saía
        /// </summary>
        /// <param name="saidaValorComDesconto"> Contém a saída e o valor com desconto de cada saída</param>
        /// <param name="saidaPagamentos"></param>
        public void GerarDocumentoFiscal(SortedList<long, decimal> saidaValorComDesconto, List<SaidaPagamento> saidaPagamentos)
        {
             //DbTransaction transaction = null;
            try
            {
                //if (saceContext.Connection.State == System.Data.ConnectionState.Closed)
                //    saceContext.Connection.Open();
                //transaction = saceContext.Connection.BeginTransaction();

                List<Saida> saidas = new List<Saida>();
                foreach (long codSaida in saidaValorComDesconto.Keys)
                {
                    Saida saida = Obter(codSaida);
                    if (saida.TipoSaida == Saida.TIPO_VENDA)
                    {
                        throw new NegocioException("Cupom Fiscal referente a essa pré-venda já foi impresso.");
                    }
                    saidas.Add(saida);
                }

                if (saidas.Count > 0)
                {
                    DirectoryInfo pastaECF = new DirectoryInfo(Global.PASTA_COMUNICACAO_FRENTE_LOJA);

                    if (pastaECF.Exists)
                    {
                        // nome do arquivo é igual ao primeiro da lista
                        String nomeArquivo = Global.PASTA_COMUNICACAO_FRENTE_LOJA + saidas[0].CodSaida + ".txt";
                        StreamWriter arquivo = new StreamWriter(nomeArquivo, false, Encoding.ASCII);

                        // imprime dados do cliente no cupom fiscal
                        if (!saidas[0].CpfCnpj.Trim().Equals(""))
                            arquivo.WriteLine("<CPF>" + saidas[0].CpfCnpj);
                        decimal precoTotalProdutosVendidos = 0;

                        // imprime produtos dos cupons fiscais
                        List<SaidaProduto> listaSaidaProdutos = new List<SaidaProduto>();
                        Pessoa cliente = (Pessoa)GerenciadorPessoa.GetInstance().Obter(saidas[0].CodCliente).ElementAt(0);
                        foreach (Saida saida in saidas)
                        {
                            List<SaidaProduto> saidaProdutos = new List<SaidaProduto>();
                            if (cliente.ImprimirCF)
                                saidaProdutos = GerenciadorSaidaProduto.GetInstance(saceContext).ObterPorSaida(saida.CodSaida);
                            else
                                saidaProdutos = GerenciadorSaidaProduto.GetInstance(saceContext).ObterPorSaidaSemCST(saida.CodSaida, Cst.ST_OUTRAS);

                            if (saidaProdutos.Count > 0)
                            {
                                // associa as saídas ao pedido que foi gerado para emissão do cupom fiscal
                                //GerenciadorSaidaPedido.GetInstance().RemoverPorSaida(saida.CodSaida, saceContext);
                                decimal totalAVista = 0;
                                saidaValorComDesconto.TryGetValue(saida.CodSaida, out totalAVista);
                                if (GerenciadorSaidaPedido.GetInstance().ObterPorSaida(saida.CodSaida).Count == 0)
                                {
                                    GerenciadorSaidaPedido.GetInstance().Inserir(new SaidaPedido() { CodSaida = saida.CodSaida, CodPedido = saidas[0].CodSaida, TotalAVista = totalAVista });
                                }
                                //else
                                //{
                                //    throw new NegocioException("Cupom fiscal já foi enviado para impressão. Favor aguardar a impressora fiscal");
                                //}
                                listaSaidaProdutos.AddRange(saidaProdutos);
                            }
                            else
                            {
                                decimal totalAVista;
                                saidaValorComDesconto.TryGetValue(saida.CodSaida, out totalAVista);
                                AtualizarTipoPedidoGeradoPorSaida(Saida.TIPO_VENDA, "", totalAVista, saida.CodSaida);
                            }
                        }

                        int quantidadeProdutosImpressos = ImprimirProdutosCupomFiscal(arquivo, ref precoTotalProdutosVendidos, listaSaidaProdutos);

                        if (quantidadeProdutosImpressos > 0)
                        {
                            // imprime detalhes do cliente
                            if (!saidas[0].CodCliente.Equals(Global.CLIENTE_PADRAO))
                            {
                                arquivo.WriteLine("<NOME> Cliente: " + saidas[0].NomeCliente);
                                arquivo.WriteLine("<CPF> CPF/CNPJ: " + saidas[0].CpfCnpj);
                            }

                            // Buscar pagamentos quando não foram passados por parâmetro
                            if ((saidaPagamentos == null) || (saidaPagamentos.Count == 0))
                            {
                                saidaPagamentos = (List<SaidaPagamento>)GerenciadorSaidaPagamento.GetInstance(saceContext).ObterPorSaidas(saidaValorComDesconto.Keys.ToList());
                            }

                            
                            // imprime desconto
                            decimal desconto = (precoTotalProdutosVendidos - saidaValorComDesconto.Values.Sum());
                            if (desconto >= 0)
                            {
                                arquivo.WriteLine("<DESCONTO>" + desconto.ToString("N2"));
                            }
                            //arquivo.WriteLine("<OBS> Total de Impostos pagos:" + saida.
                            foreach (SaidaPagamento saidaPagamento in saidaPagamentos)
                            {
                                if (saidaPagamento.CodFormaPagamento != FormaPagamento.CARTAO)
                                {
                                    arquivo.Write("<PGTO>" + saidaPagamento.MapeamentoFormaPagamento + ";");
                                    arquivo.Write(saidaPagamento.DescricaoFormaPagamento + ";");
                                    arquivo.Write(saidaPagamento.Valor + ";");
                                    arquivo.WriteLine("N;"); //N ou V
                                }
                                else
                                {
                                    arquivo.Write("<PGTO>" + saidaPagamento.MapeamentoCartao + ";");
                                    arquivo.Write(saidaPagamento.NomeCartaoCredito + ";");
                                    arquivo.Write(saidaPagamento.Valor + ";");
                                    arquivo.WriteLine("V;"); //N ou V vinculado ao TEF
                                }
                            }

                            arquivo.Close();
                        }
                        else
                        {
                            arquivo.Close();
                            ExcluirDocumentoFiscal(saidas[0].CodSaida);
                        }
                    }
                }
                //transaction.Commit();
            }
            catch (Exception e)
            {
                //transaction.Rollback();
                if (e is NegocioException)
                {
                    throw e;
                }
                //TODO: definir mecanismo para lançar exceção de processo background
            }
            //finally
            //{
            //    saceContext.Connection.Close();
            //}

        }



        private int ImprimirProdutosCupomFiscal(StreamWriter arquivo, ref decimal precoTotalProdutosVendidos, List<SaidaProduto> saidaProdutos)
        {
            int quantidadeProdutosImpressos = 0;
            saidaProdutos = ExcluirProdutosDevolvidosMesmoPreco(saidaProdutos);
            foreach (SaidaProduto saidaProduto in saidaProdutos)
            {
                if ((saidaProduto.Quantidade > 0) && (saidaProduto.ValorVenda > 0))
                {
                    Produto produto = new Produto();
                    produto.CodProduto = saidaProduto.CodProduto;
                    produto.CodCST = saidaProduto.CodCST;
                    String situacaoFiscal = produto.EhTributacaoIntegral ? "01" : "FF";

                    arquivo.Write(saidaProduto.CodProduto + ";");
                    arquivo.Write(saidaProduto.Nome + ";");
                    arquivo.Write(saidaProduto.Quantidade.ToString() + ";");
                    arquivo.Write(saidaProduto.ValorVenda.ToString() + ";");
                    arquivo.Write(situacaoFiscal + ";");
                    arquivo.Write("0;");
                    arquivo.Write(saidaProduto.ValorVenda + ";");
                    arquivo.WriteLine(saidaProduto.Unidade + ";");

                    precoTotalProdutosVendidos += saidaProduto.Subtotal;
                    quantidadeProdutosImpressos++;
                }
            }

            return quantidadeProdutosImpressos;
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


        public void ExcluirDocumentoFiscal(long codPedido)
        {
            try
            {
                String arquivo = Global.PASTA_COMUNICACAO_FRENTE_LOJA + codPedido + ".txt";

                DirectoryInfo pastaECF = new DirectoryInfo(Global.PASTA_COMUNICACAO_FRENTE_LOJA);
                if (pastaECF.Exists)
                {
                    FileInfo cupomFiscal = new FileInfo(arquivo);

                    if (cupomFiscal.Exists)
                    {
                        cupomFiscal.Delete();
                        GerenciadorSaidaPedido.GetInstance().RemoverPorPedido(codPedido, saceContext);
                    }
                }
            }
            catch (Exception)
            {
                throw new NegocioException("Não é possível editar essa Pré-Venda. É provável que o Cupom Fiscal esteja sendo impresso.");
            }
        }


        public Boolean AtualizarPedidosComDocumentosFiscais()
        {
            Boolean atualizou = false;
            try
            {
                DirectoryInfo Dir = new DirectoryInfo(Global.PASTA_COMUNICACAO_FRENTE_LOJA_RETORNO);
                string nomeComputador = System.Windows.Forms.SystemInformation.ComputerName;
                if (Dir.Exists && nomeComputador.Equals(Global.NOME_SERVIDOR))
                {
                    // Busca automaticamente todos os arquivos em todos os subdiretórios
                    FileInfo[] Files = Dir.GetFiles("*", SearchOption.TopDirectoryOnly);
                    if (Files.Length == 0)
                    {
                        atualizou = true;
                    }
                    else
                    {
                        foreach (FileInfo file in Files)
                        {
                            bool sucesso = false;
                            String numeroCF = null;
                            String linha = null;
                            StreamReader reader = new StreamReader(file.FullName);

                            // sucesso = true quando cupum fiscal foi impresso
                            if ((linha = reader.ReadLine()) != null)
                            {
                                sucesso = linha.Equals("OK");
                                if (sucesso && ((linha = reader.ReadLine()) != null))
                                {
                                    numeroCF = linha;
                                }
                            }
                            reader.Close();

                            // quando cupom fiscal impresso com sucesso atualiza saidas
                            long codPedido = Convert.ToInt64(file.Name.Replace(".TXT", ""));
                            List<SaidaPedido> _listaSaidaPedido = GerenciadorSaidaPedido.GetInstance().ObterPorPedido(codPedido);
                            if (sucesso)
                            {
                                foreach (SaidaPedido saidaPedido in _listaSaidaPedido)
                                {
                                    AtualizarTipoPedidoGeradoPorSaida(Saida.TIPO_VENDA, numeroCF, saidaPedido.TotalAVista, saidaPedido.CodSaida);
                                    GerenciadorCupom.GetInstace().RemoverSolicitacaoCupom(saidaPedido.CodSaida);
                                    atualizou = true;
                                }
                            }
                            else
                            {
                                foreach (SaidaPedido saidaPedido in _listaSaidaPedido)
                                {
                                    bool temPagamentoCrediario = GerenciadorSaidaPagamento.GetInstance(saceContext).ObterPorSaidaFormaPagamento(saidaPedido.CodSaida, FormaPagamento.CREDIARIO).ToList().Count > 0;
                                    if (!temPagamentoCrediario)
                                    {
                                        Saida saida = Obter(saidaPedido.CodSaida);
                                        if (saida != null)
                                        {
                                            saida.TipoSaida = Saida.TIPO_PRE_VENDA;
                                            PrepararEdicaoSaida(saida);
                                        }
                                    }
                                }
                            }
                            GerenciadorSaidaPedido.GetInstance().RemoverPorPedido(codPedido, saceContext);
                            //transaction.Commit();
                            file.CopyTo(Global.PASTA_COMUNICACAO_FRENTE_LOJA_BACKUP + file.Name, true);
                            file.Delete();
                        }
                    }
                }
            }
            catch (Exception)
            {
                //transaction.Rollback();
                // Essa exceção não precisa ser tratada. Apenas os cupons fiscais não são recuperados.
                //throw new NegocioException("Ocorreram problemas na recuperação dos dados dos cupons fiscais. Favor contactar o administrador informando o erro " + e.Message);
            }
            return atualizou;
        }

        public void EmitirCupomFiscalPreVendasPendentes()
        {
            string nomeComputador = System.Windows.Forms.SystemInformation.ComputerName;
            if (nomeComputador.Equals("SONY-VAIO")) {
                List<Saida> listaPreVendasPendentes = ObterPreVendasPendentes();
                foreach(Saida saidaPendente in listaPreVendasPendentes) {
                    
                }
                //GerarDocumentoFiscal(
            }

        }


        public bool ImprimirCreditoPagamento(MovimentacaoConta movimentacaoConta)
        {
            try
            {
                ImprimeTexto imp = new ImprimeTexto();
                if (!imp.Inicio(Global.PORTA_IMPRESSORA_REDUZIDA))
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

        public void ImprimirDAV(List<Saida> saidas, decimal total, decimal totalAVista, decimal desconto, bool comprimido)
        {

            if (comprimido)
                ImprimirDAVComprimido(saidas, total, totalAVista, desconto);
            else
                ImprimirDAVNormalTexto(saidas, total, totalAVista, desconto);
        }

        
        private bool ImprimirDAVComprimido(List<Saida> saidas, decimal total, decimal totalAVista, decimal desconto)
        {
            try
            {
                ImprimeTexto imp = new ImprimeTexto();
                if (!imp.Inicio(Global.PORTA_IMPRESSORA_REDUZIDA))
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
                        imp.ImpColLFDireita(57, 58, produto.Unidade);
                        imp.ImpColDireita(38, 46, produto.ValorVenda.ToString("N2"));
                        imp.ImpColLFDireita(48, 59, produto.Subtotal.ToString("N2"));
                    }
                }

                imp.ImpLF(Global.LINHA_COMPRIMIDA);
                imp.ImpLF("Total Venda: " + total + "     Desconto: " + desconto.ToString("N2") + "%");
                imp.ImpColLFDireita(30, 59, imp.NegritoOn + "Total Pagar:" + totalAVista.ToString("N2") + imp.NegritoOff);
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
                throw new NegocioException("Não foi possível realizar a impressão. Por Favor Verifique se a impressora MATRICIAL está LIGADA.", e);
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

        private void ImprimirDAVNormalTexto(List<Saida> saidas, decimal total, decimal totalAVista, decimal desconto)
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
            }
            catch (Exception e)
            {
                throw new NegocioException("Não foi possível realizar a impressão. Por Favor Verifique se a impressora MATRICIAL está LIGADA.", e);
            }
        }

        public void ImprimirNotaFiscal(Saida saida)
        {

            if (saida.TipoSaida == Saida.TIPO_ORCAMENTO)
            {
                throw new NegocioException("O Documento Fiscal não pode ser impresso a partir de um ORÇAMENTO. É necessário transformá-lo numa PRÉ-VENDA.");
            }

            try
            {
                if (saida.TipoSaida == Saida.TIPO_PRE_VENDA)
                {
                    GerenciadorCupom.GetInstace().InserirSolicitacaoCupom(saida.CodSaida, saida.TotalAVista);
                    //SortedList<long, decimal> saidaTotalAVista = new SortedList<long, decimal>();
                    //saidaTotalAVista.Add(saida.CodSaida, saida.TotalAVista);
                    //GerarDocumentoFiscal(saidaTotalAVista, null);
                }
            }
            catch (Exception e)
            {
                if (e is NegocioException)
                    throw e;
                else
                    throw new NegocioException("Não foi possível realizar a impressão. Por Favor Verifique se a impressora MATRICIAL está LIGADA.");
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