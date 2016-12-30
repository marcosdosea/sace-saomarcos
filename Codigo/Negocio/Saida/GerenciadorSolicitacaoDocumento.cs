using System;
using System.Collections.Generic;
using System.Linq;
using Dados;
using Dominio;
using Util;
using System.IO;
using System.Threading;
using System.Text;
using System.Transactions;


namespace Negocio
{
    public class GerenciadorSolicitacaoDocumento
    {
        private static GerenciadorSolicitacaoDocumento gCupom;

        public static GerenciadorSolicitacaoDocumento GetInstance()
        {
            if (gCupom == null)
            {
                gCupom = new GerenciadorSolicitacaoDocumento();
            }
            return gCupom;
        }

        /// <summary>
        /// Insere dados do cupom
        /// </summary>
        /// <param name="cupom"></param>
        /// <returns></returns>
        public long InserirSolicitacaoDocumento(List<SaidaPedido> listaSaidaPedido, List<SaidaPagamento> listaSaidaPagamento, DocumentoFiscal.TipoSolicitacao tipoSolicitacao, bool ehComplementar, bool ehEspelho)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                EhPossivelEnviarSolicitacao(listaSaidaPedido, tipoSolicitacao, ehComplementar);

                var repSolicitacaoDocumento = new RepositorioGenerico<tb_solicitacao_documento>();
                tb_solicitacao_documento _solicitacao_documentoE = new tb_solicitacao_documento();
                try
                {
                    _solicitacao_documentoE.dataSolicitacao = DateTime.Now;
                    _solicitacao_documentoE.haPagamentoCartao = listaSaidaPagamento.Where(sp => sp.CodFormaPagamento.Equals(FormaPagamento.CARTAO)).Count() > 0;
                    _solicitacao_documentoE.cartaoProcessado = false;
                    _solicitacao_documentoE.cartaoAutorizado = false;
                    _solicitacao_documentoE.ehComplementar = ehComplementar;
                    _solicitacao_documentoE.ehEspelho = ehEspelho;
                    _solicitacao_documentoE.motivoCartaoNegado = "";
                    _solicitacao_documentoE.tipoSolicitacao = tipoSolicitacao.ToString();
                    repSolicitacaoDocumento.Inserir(_solicitacao_documentoE);

                    repSolicitacaoDocumento.SaveChanges();

                    var repSolicitacaoSaida = new RepositorioGenerico<tb_solicitacao_saida>();
                    foreach (SaidaPedido _saidaPedido in listaSaidaPedido)
                    {
                        tb_solicitacao_saida _solicitacao_saida = new tb_solicitacao_saida();
                        _solicitacao_saida.codSaida = _saidaPedido.CodSaida;
                        _solicitacao_saida.codSolicitacao = _solicitacao_documentoE.codSolicitacao;
                        _solicitacao_saida.valorTotal = _saidaPedido.TotalAVista;
                        repSolicitacaoSaida.Inserir(_solicitacao_saida);
                    }
                    repSolicitacaoSaida.SaveChanges();

                    var repSolicitacaoPagamento = new RepositorioGenerico<tb_solicitacao_pagamento>();
                    foreach (SaidaPagamento _solicitacaoPagamento in listaSaidaPagamento)
                    {

                        tb_solicitacao_pagamento pagamento = new tb_solicitacao_pagamento();
                        pagamento.codCartao = _solicitacaoPagamento.CodCartaoCredito;
                        pagamento.codFormaPagamento = _solicitacaoPagamento.CodFormaPagamento;
                        pagamento.parcelas = _solicitacaoPagamento.Parcelas;
                        pagamento.valor = _solicitacaoPagamento.Valor;
                        pagamento.codSolicitacao = _solicitacao_documentoE.codSolicitacao;
                        pagamento.cupomCliente = "";
                        pagamento.cupomEstabelecimento = "";
                        pagamento.cupomReduzido = "";
                        repSolicitacaoPagamento.Inserir(pagamento);
                    }
                    repSolicitacaoPagamento.SaveChanges();
                    transaction.Complete();
                    return _solicitacao_documentoE.codSolicitacao;
                }
                catch (Exception e)
                {
                    throw new DadosException("Cupom", e.Message, e);
                }
                
            }
        }

        private void EhPossivelEnviarSolicitacao(List<SaidaPedido> listaSaidaPedido, DocumentoFiscal.TipoSolicitacao tipoSolicitacao, bool ehComplementar)
        {
            var repSolicitacaoSaida = new RepositorioGenerico<tb_solicitacao_saida>();
            List<long> listaCodSaidas = listaSaidaPedido.Select(s => s.CodSaida).ToList();

            var solicitacoes = repSolicitacaoSaida.Obter(ss => listaCodSaidas.Contains(ss.codSaida));
            if (solicitacoes.Count() > 0)
                throw new NegocioException("A solicitação já foi enviada. Favor aguardar processamento.");
            // Verifica se cupom fiscal já foi emitido em algumas das saidas
            if (tipoSolicitacao.Equals(DocumentoFiscal.TipoSolicitacao.ECF))
            {
                var repSaida = new RepositorioGenerico<tb_saida>();
                SaceEntities saceEntities = (SaceEntities)repSaida.ObterContexto();
                var query = from saida in saceEntities.tb_saida
                            where listaCodSaidas.Contains(saida.codSaida) && !String.IsNullOrEmpty(saida.pedidoGerado)
                            select saida;
                if (query.Count() > 0)
                    throw new NegocioException("Cumpom Fiscal já foi emitido para algum dos pedidos dessa solicitação.");
            }
            if (tipoSolicitacao.Equals(DocumentoFiscal.TipoSolicitacao.NFE) || tipoSolicitacao.Equals(DocumentoFiscal.TipoSolicitacao.NFCE))
            {
                var repSaida = new RepositorioGenerico<tb_nfe>();
                SaceEntities saceEntities = (SaceEntities) repSaida.ObterContexto();
                foreach (long codSaida in listaCodSaidas)
                {
                    // Verifica se existem notas emitidas
                    IEnumerable<NfeControle> nfeControles = GerenciadorNFe.GetInstance().ObterPorSaida(codSaida);

                    if (!ehComplementar && nfeControles.Where(nfeC => nfeC.SituacaoNfe.Equals(NfeControle.SITUACAO_AUTORIZADA)).Count() > 0)
                    {
                        throw new NegocioException("Uma NF-e já foi AUTORIZADA para esse pedido.");
                    }
                    if ((ehComplementar) && nfeControles.Where(nfeC => nfeC.SituacaoNfe.Equals(NfeControle.SITUACAO_AUTORIZADA)).Count() == 0)
                    {
                        throw new NegocioException("Uma NF-e Complementar só pode ser emitida quando existe uma NF-e enviada e Autorizada.");
                    }
                }
            }

        }

        public void AtualizarSolicitacaoDocumentoCartao(Cartao.ResultadoProcessamento resultado)
        {
            var repSolicitacao = new RepositorioGenerico<tb_solicitacao_documento>();

            var saceContext = (SaceEntities)repSolicitacao.ObterContexto();
            tb_solicitacao_documento documentoE = repSolicitacao.ObterEntidade(sd => sd.codSolicitacao == resultado.CodSolicitacao);
            documentoE.cartaoProcessado = true;
            documentoE.cartaoAutorizado = resultado.Aprovado;
            documentoE.emProcessamento = false;
            if (resultado.Aprovado)
            {
                foreach (Cartao.RespostaAprovada respostaAprovada in resultado.ListaRespostaAprovada)
                {
                    tb_solicitacao_pagamento solicitacaoPagamento = documentoE.tb_solicitacao_pagamento.Where(sp => sp.codSolicitacaoPagamento == respostaAprovada.CodSolicitacaoPagamento).FirstOrDefault();
                    solicitacaoPagamento.cupomCliente = respostaAprovada.CupomCliente;
                    solicitacaoPagamento.cupomEstabelecimento = respostaAprovada.CupomLojista;
                    solicitacaoPagamento.cupomReduzido = respostaAprovada.CupomReduzido;
                }
            }
            else
            {
                Cartao.RespostaRecusada recusada = resultado.RespostaRecusada;
                documentoE.codMotivoCartaoNegado = recusada.CodMotivo;
                documentoE.motivoCartaoNegado = recusada.Motivo;
            }
            repSolicitacao.SaveChanges();
        }

        public List<SolicitacaoPagamento> ObterSolicitacaoPagamentoCartao()
        {
            var repSolicitacoes = new RepositorioGenerico<tb_solicitacao_documento>();
            var saceEntities = (SaceEntities)repSolicitacoes.ObterContexto();
            var query = from solicitacao in saceEntities.tb_solicitacao_documento
                        where solicitacao.tipoSolicitacao.Equals("NFCE") && solicitacao.haPagamentoCartao == true &&
                            solicitacao.cartaoProcessado == false
                        orderby solicitacao.dataSolicitacao
                        select solicitacao;
            List<tb_solicitacao_documento> listaSolicitacoes = query.ToList();
            List<SolicitacaoPagamento> listaPagamentos = new List<SolicitacaoPagamento>();

            if (listaSolicitacoes.Count > 0)
            {
                tb_solicitacao_documento solicitacao = listaSolicitacoes.First();
                foreach (tb_solicitacao_pagamento pagamento in solicitacao.tb_solicitacao_pagamento)
                {
                    listaPagamentos.Add(
                        new SolicitacaoPagamento()
                        {
                            CodSolicitacao = pagamento.codSolicitacao,
                            CodSolicitacaoPagamento = (long)pagamento.codSolicitacaoPagamento,
                            CodCartaoCredito = pagamento.codCartao,
                            NomeCartaoCredito = pagamento.tb_cartao_credito.nome,
                            CodFormaPagamento = pagamento.codFormaPagamento,
                            QtdDiasPagar = (int)pagamento.tb_cartao_credito.diaBase,
                            Parcelas = (int)pagamento.parcelas,
                            Valor = pagamento.valor
                        }
                    );
                }

            }
            return listaPagamentos;
        }

        /// <summary>
        /// Atualiza dados do cupom
        /// </summary>
        /// <param name="cupom"></param>
        public void EnviarProximoECF()
        {
            try
            {
                var repSolicitacao = new RepositorioGenerico<tb_solicitacao_documento>();
                var repSolicitacao2 = new RepositorioGenerico<tb_solicitacao_documento>();
                DirectoryInfo pastaECF = new DirectoryInfo(Global.PASTA_COMUNICACAO_FRENTE_LOJA);
                if (pastaECF.Exists)
                {
                    FileInfo[] files = pastaECF.GetFiles("*.TXT", SearchOption.TopDirectoryOnly);
                    if (files.Length == 0)
                    {
                        var saceEntities = (SaceEntities)repSolicitacao.ObterContexto();
                        var query = from solicitacao in saceEntities.tb_solicitacao_documento
                                    where solicitacao.tipoSolicitacao.Equals("ECF")
                                    orderby solicitacao.dataSolicitacao
                                    select solicitacao;
                        List<tb_solicitacao_documento> solicitacoes = query.ToList();
                        if (solicitacoes.Count() > 0)
                        {
                            tb_solicitacao_documento solicitacaoE = solicitacoes.FirstOrDefault();
                            List<tb_solicitacao_saida> listaSolicitacaoSaida = solicitacaoE.tb_solicitacao_saida.ToList();
                            List<tb_solicitacao_pagamento> listaPagamentos = solicitacaoE.tb_solicitacao_pagamento.ToList();

                            repSolicitacao2.Remover(s => s.codSolicitacao == solicitacaoE.codSolicitacao);
                            repSolicitacao2.SaveChanges();
                            
                            
                            //repSolicitacoesRemover.Remover(solicitacaoE);
                            //repSolicitacoes.SaveChanges();
                            GerarDocumentoECF(listaSolicitacaoSaida, listaPagamentos);
                            //RemoverSolicitacaoDocumento(listaSolicitacaoSaida.FirstOrDefault().codSaida);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new DadosException("Cupom", e.Message, e);
            }
        }


        /// <summary>
        /// Remove dados do cupom
        /// </summary>
        /// <param name="codCupom"></param>
        public void RemoverSolicitacaoDocumento(long codSaida)
        {
            try
            {
                var repSolicitacao = new RepositorioGenerico<tb_solicitacao_documento>();
                var saceEntities = (SaceEntities)repSolicitacao.ObterContexto();
                var query = from solicitacaoSaida in saceEntities.tb_solicitacao_saida
                            where solicitacaoSaida.codSaida == codSaida
                            select solicitacaoSaida;
                tb_solicitacao_saida solicitacao_saidaE = query.ToList().FirstOrDefault();
                if (solicitacao_saidaE != null)
                {
                    if (solicitacao_saidaE.tb_solicitacao_documento.emProcessamento == true)
                    {
                        throw new NegocioException("Não é possível editar/remover esse pedido. Documento sendo autorizado/impresso. Favor aguardar até a conclusão do processamento.");
                    }

                    repSolicitacao.Remover(s => s.codSolicitacao == solicitacao_saidaE.codSolicitacao);
                    repSolicitacao.SaveChanges();
                }

            }
            catch (Exception e)
            {
                throw new DadosException("Documento Fiscal", e.Message, e);
            }
        }

        /// <summary>
        /// Consulta para retornar dados da entidade
        /// </summary>
        /// <returns></returns>
        public tb_solicitacao_documento ObterSolicitacaoDocumento(long codSolicitacao)
        {
            var repSolicitacao = new RepositorioGenerico<tb_solicitacao_documento>();
            var saceEntities = (SaceEntities)repSolicitacao.ObterContexto();
            var query = from documento in saceEntities.tb_solicitacao_documento
                        where documento.codSolicitacao == codSolicitacao
                        select documento;
            return query.FirstOrDefault();
        }


        /// <summary>
        /// Consulta para retornar dados da entidade
        /// </summary>
        /// <returns></returns>
        private IQueryable<tb_solicitacao_saida> ObterSolicitacaoSaida(long codSolicitacao)
        {
            var repSolicitacaoSaida = new RepositorioGenerico<tb_solicitacao_saida>();
            var saceEntities = (SaceEntities)repSolicitacaoSaida.ObterContexto();
            var query = from solicitacao_saida in saceEntities.tb_solicitacao_saida
                        where solicitacao_saida.codSolicitacao == codSolicitacao
                        select solicitacao_saida;
            return query;
        }

        /// <summary>
        /// Obtém lista de cupons emitidos
        /// </summary>
        /// <returns></returns>
        public List<DocumentoFiscal> ObterDocumentosFiscais()
        {
            var repCupom = new RepositorioGenerico<tb_saida>();
            var saceEntities = (SaceEntities)repCupom.ObterContexto();
            var query = from saida in saceEntities.tb_saida
                        where !saida.pedidoGerado.Trim().Equals("")
                        orderby saida.pedidoGerado
                        select new DocumentoFiscal
                        {
                            CodCliente = saida.codCliente,
                            CodSaida = saida.codSaida,
                            NumeroCupomFiscal = saida.pedidoGerado,
                            DataEmissaoCupomFiscal = (DateTime)saida.dataEmissaoDocFiscal,
                            NomeCliente = saida.tb_pessoa.nome
                        };
            return query.ToList();
        }

        /// <summary>
        /// Gera o cupom fiscal a partir das saídas e valores a vista de cada saía
        /// </summary>
        /// <param name="saidaPagamentos"></param>
        private void GerarDocumentoECF(List<tb_solicitacao_saida> listaSolicitacaoSaida, List<tb_solicitacao_pagamento> listaPagamentos)
        {
            try
            {
                List<Saida> saidas = new List<Saida>();
                decimal totalSolicitacaoSaidas = 0;
                foreach (tb_solicitacao_saida solicitacaoSaida in listaSolicitacaoSaida)
                {
                    Saida saida = GerenciadorSaida.GetInstance(null).Obter(solicitacaoSaida.codSaida);
                    if (!string.IsNullOrEmpty(saida.CupomFiscal))
                    {
                        throw new NegocioException("Cupom Fiscal referente a essa pré-venda já foi impresso.");
                    }
                    saidas.Add(saida);
                    totalSolicitacaoSaidas += solicitacaoSaida.valorTotal;
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
                                saidaProdutos = GerenciadorSaidaProduto.GetInstance(null).ObterPorSaida(saida.CodSaida);
                            else
                                saidaProdutos = GerenciadorSaidaProduto.GetInstance(null).ObterPorSaidaSemCST(saida.CodSaida, Cst.ST_OUTRAS);

                            decimal totalAVista = listaSolicitacaoSaida.Where(cs => cs.codSaida.Equals(saida.CodSaida)).Sum(cs => cs.valorTotal);
                            if (saidaProdutos.Count > 0)
                            {
                                // associa as saídas ao pedido que foi gerado para emissão do cupom fiscal
                                //GerenciadorSaidaPedido.GetInstance().RemoverPorSaida(saida.CodSaida, saceContext);
                                if (GerenciadorSaidaPedido.GetInstance().ObterPorSaida(saida.CodSaida).Count == 0)
                                {
                                    GerenciadorSaidaPedido.GetInstance().Inserir(new SaidaPedido() { CodSaida = saida.CodSaida, CodPedido = saidas[0].CodSaida, TotalAVista = totalAVista });
                                }
                                else
                                {
                                    GerenciadorSaidaPedido.GetInstance().Atualizar(new SaidaPedido() { CodSaida = saida.CodSaida, CodPedido = saidas[0].CodSaida, TotalAVista = totalAVista });
                                }
                                listaSaidaProdutos.AddRange(saidaProdutos);
                            }
                            else
                            {
                                GerenciadorSaida.GetInstance(null).AtualizarTipoPedidoGeradoPorSaida(Saida.TIPO_VENDA, "", totalAVista, saida.CodSaida);
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

                            // imprimir imposto na nota
                            decimal valorImposto = GerenciadorImposto.GetInstance().CalcularValorImpostoProdutos(listaSaidaProdutos).Sum(sp => sp.ValorImposto);
                            decimal valorImpostoPercentual = valorImposto / saidas.Sum(s => s.TotalAVista) * 100;
                            arquivo.WriteLine("<OBS>Val Aprox dos Tributos R$ " + valorImposto.ToString("N2") + " (" + valorImpostoPercentual.ToString("N2") + "%) " + "  Fonte: IBPT");


                            // Buscar pagamentos quando não foram passados por parâmetro
                            //List<SaidaPagamento> saidaPagamentos = (List<SaidaPagamento>)GerenciadorSaidaPagamento.GetInstance(null).ObterPorSaidas(listaSolicitacaoCupomSaida.Select(cs=>cs.codSaida).ToList());

                            // imprime desconto
                            decimal desconto = (precoTotalProdutosVendidos - listaSolicitacaoSaida.Sum(cs => cs.valorTotal));
                            if (desconto >= 0)
                            {
                                arquivo.WriteLine("<DESCONTO>" + desconto.ToString("N2"));
                            }
                            //arquivo.WriteLine("<OBS> Total de Impostos pagos:" + saida.
                            foreach (tb_solicitacao_pagamento pagamento in listaPagamentos)
                            {
                                if (pagamento.codFormaPagamento != FormaPagamento.CARTAO)
                                {
                                    arquivo.Write("<PGTO> 01;DINHEIRO;");
                                    arquivo.Write(pagamento.valor + ";");
                                    arquivo.WriteLine("N;"); //N ou V
                                }
                                else
                                {
                                    CartaoCredito cartaoCredito = GerenciadorCartaoCredito.GetInstance().Obter(pagamento.codCartao).ElementAtOrDefault(0);
                                    arquivo.Write("<PGTO>" + cartaoCredito.Mapeamento + ";");
                                    arquivo.Write(cartaoCredito.Nome + ";");
                                    arquivo.Write(pagamento.valor + ";");
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
            saidaProdutos = GerenciadorSaida.GetInstance(null).ExcluirProdutosDevolvidosMesmoPreco(saidaProdutos);
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
                    arquivo.Write(saidaProduto.ValorVenda.ToString() + ";");
                    arquivo.WriteLine(saidaProduto.Unidade + ";");

                    precoTotalProdutosVendidos += saidaProduto.Subtotal;
                    quantidadeProdutosImpressos++;
                }
            }

            return quantidadeProdutosImpressos;
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
                        GerenciadorSaidaPedido.GetInstance().RemoverPorPedido(codPedido);
                    }
                }
            }
            catch (Exception)
            {
                throw new NegocioException("Não é possível editar essa Pré-Venda. É provável que o Cupom Fiscal esteja sendo impresso.");
            }
        }


        public Boolean AtualizarPedidosComDocumentosFiscais(string nomeServidor)
        {
            Boolean atualizou = false;
            DirectoryInfo PastaRetorno = new DirectoryInfo(Global.PASTA_COMUNICACAO_FRENTE_LOJA_RETORNO);
            string nomeComputador = System.Windows.Forms.SystemInformation.ComputerName;
            if (nomeComputador.Equals(nomeServidor) && PastaRetorno.Exists)
            {
                // Busca automaticamente todos os arquivos em todos os subdiretórios
                FileInfo[] Files = PastaRetorno.GetFiles("*", SearchOption.TopDirectoryOnly);
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
                                    GerenciadorSaida.GetInstance(null).AtualizarTipoPedidoGeradoPorSaida(Saida.TIPO_VENDA, numeroCF, saidaPedido.TotalAVista, saidaPedido.CodSaida);
                                    RemoverSolicitacaoDocumento(saidaPedido.CodSaida);
                                    atualizou = true;
                                }
                            }
                            else
                            {
                                foreach (SaidaPedido saidaPedido in _listaSaidaPedido)
                                {
                                    bool temPagamentoCrediario = GerenciadorSaidaPagamento.GetInstance(null).ObterPorSaidaFormaPagamento(saidaPedido.CodSaida, FormaPagamento.CREDIARIO).ToList().Count > 0;
                                    if (!temPagamentoCrediario)
                                    {
                                        Saida saida = GerenciadorSaida.GetInstance(null).Obter(saidaPedido.CodSaida);
                                        if ((saida != null) && (saida.TipoSaida != Saida.TIPO_VENDA))
                                        {
                                            saida.TipoSaida = Saida.TIPO_PRE_VENDA;
                                            GerenciadorSaida.GetInstance(null).PrepararEdicaoSaida(saida);
                                        }
                                    }
                                }
                            }
                            GerenciadorSaidaPedido.GetInstance().RemoverPorPedido(codPedido);
                        }
                        catch (Exception)
                        {
                            // Se houver algum impossibilidade de trasnformar o pedido em pré-venda
                            // não tem problema. Pode acontecer quando cliente quita a conta gerada
                            // mas há algum problema na impressora para imprimir o cupom fiscal
                            // Nesses casos é só fazer a reimpressão do cupom. 
                        }
                        finally
                        {
                            DirectoryInfo PastaBackup = new DirectoryInfo(Global.PASTA_COMUNICACAO_FRENTE_LOJA_BACKUP);
                            if (PastaBackup.Exists)
                            {
                                file.CopyTo(Global.PASTA_COMUNICACAO_FRENTE_LOJA_BACKUP + file.Name, true);
                            }
                            if (file.Exists)
                            {
                                file.Delete();
                            }
                        }
                    }
                }
            }
            return atualizou;
        }

        public void InserirRespostaCartao(Cartao.ResultadoProcessamento resultado)
        {
            List<tb_solicitacao_saida> listaSolicitacaoSaida;

            if (resultado.Aprovado)
            {
                listaSolicitacaoSaida = ObterSolicitacaoSaida(resultado.CodSolicitacao).ToList();
                // Pode passar mais de um cartão de crédito
                if (listaSolicitacaoSaida.Count == 1)
                {
                    tb_solicitacao_saida solicitacaoSaida = listaSolicitacaoSaida.FirstOrDefault();
                    IEnumerable<Conta> listaContas = GerenciadorConta.GetInstance(null).ObterPorSaida(solicitacaoSaida.codSaida);
                    List<Cartao.RespostaAprovada> listaAprovadas = resultado.ListaRespostaAprovada;
                    foreach (Cartao.RespostaAprovada aprovada in listaAprovadas)
                    {
                        String tipoCartaoString = Enum.GetName(typeof(Cartao.TipoCartao), aprovada.TipoCartao);
                        CartaoCredito cartao = GerenciadorCartaoCredito.GetInstance().ObterPorMapeamentoCappta(aprovada.NomeBandeiraCartao).Where(c => c.TipoCartao.Equals(tipoCartaoString)).ElementAtOrDefault(0);
                        Conta conta = listaContas.Where(c => c.ValorPagar == (decimal)aprovada.Valor && String.IsNullOrWhiteSpace(c.NumeroDocumento)).FirstOrDefault();
                        GerenciadorSaidaPagamento.GetInstance(null).AtualizarPorAutorizacaoCartao(conta.CodSaida, cartao.CodCartao, aprovada.NumeroControle);

                        conta.CodPessoa = cartao.CodPessoa;
                        conta.NumeroDocumento = aprovada.NumeroControle;
                        conta.DataVencimento = DateTime.Now.AddDays(cartao.DiaBase);
                        GerenciadorConta.GetInstance(null).AtualizarDadosCartaoCredito(conta);
                    }
                }
                //else
                //{
                //    foreach (tb_solicitacao_saida solicitacaoSaida in listaSolicitacaoSaida)
                //    {
                //        IEnumerable<Conta> contas = GerenciadorConta.GetInstance(null).ObterPorSaida(solicitacaoSaida.codSaida);

                //    }
                //}
                InserirAutorizacaoCartao(resultado, listaSolicitacaoSaida);
            }

            AtualizarSolicitacaoDocumentoCartao(resultado);
        }

        public long InserirAutorizacaoCartao(Cartao.ResultadoProcessamento resultadoProcessamento, List<tb_solicitacao_saida> listaSolicitacaoSaida)
        {
            var repAutorizacao = new RepositorioGenerico<tb_autorizacao_cartao>();
            //var repSaida = new RepositorioGenerico<tb_saida>();
            tb_autorizacao_cartao _autorizacao_cartaoE;
            try
            {
                foreach (Cartao.RespostaAprovada respostaAprovada in resultadoProcessamento.ListaRespostaAprovada)
                {
                    _autorizacao_cartaoE = new tb_autorizacao_cartao();
                    _autorizacao_cartaoE.codigoAutorizacaoAdquirente = respostaAprovada.CodAutorizacaoAdquirente;
                    _autorizacao_cartaoE.dataHoraAutorizacao = respostaAprovada.DataHoraAutorizacao;
                    _autorizacao_cartaoE.nomeAdquirente = respostaAprovada.NomeAdquirente;
                    _autorizacao_cartaoE.nomeBandeiraCartao = respostaAprovada.NomeBandeiraCartao;
                    _autorizacao_cartaoE.nsuAdquirente = String.IsNullOrEmpty(respostaAprovada.NsuAdquirente) ? "" : respostaAprovada.NsuAdquirente;
                    _autorizacao_cartaoE.nsuTef = String.IsNullOrEmpty(respostaAprovada.NsuTef) ? "" : respostaAprovada.NsuTef;
                    _autorizacao_cartaoE.numeroControle = String.IsNullOrEmpty(respostaAprovada.NumeroControle) ? "" : respostaAprovada.NumeroControle;

                    repAutorizacao.Inserir(_autorizacao_cartaoE);
                    repAutorizacao.SaveChanges();
                    foreach (tb_solicitacao_saida solicitacaoSaida in listaSolicitacaoSaida)
                    {
                        var saceEntities = (SaceEntities)repAutorizacao.ObterContexto();
                        var query = from saida in saceEntities.tb_saida
                                    where saida.codSaida == solicitacaoSaida.codSaida
                                    select saida;

                        tb_saida saidaE = query.FirstOrDefault();

                        _autorizacao_cartaoE.tb_saida.Add(saidaE);
                    }

                    repAutorizacao.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new DadosException("Autorização Cartão", e.Message, e);
            }
            return 0;

        }
    }
}