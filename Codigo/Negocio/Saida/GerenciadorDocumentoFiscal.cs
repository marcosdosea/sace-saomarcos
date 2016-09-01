using System;
using System.Collections.Generic;
using System.Linq;
using Dados;
using Dominio;
using Util;
using System.IO;
using System.Threading;
using System.Text;

namespace Negocio
{
    public class GerenciadorDocumentoFiscal
    {
        private const string TIPO_CUPOM_ECF = "ECF";
        private const string TIPO_CUPOM_NFCE = "NFCE";

        private static GerenciadorDocumentoFiscal gCupom;

        public static GerenciadorDocumentoFiscal GetInstance()
        {
            if (gCupom == null)
            {
                gCupom = new GerenciadorDocumentoFiscal();
            }
            return gCupom;
        }

        /// <summary>
        /// Insere dados do cupom
        /// </summary>
        /// <param name="cupom"></param>
        /// <returns></returns>
        public long InserirSolicitacaoDocumentoFiscal(List<SaidaPedido> listaSaidaPedido, List<SaidaPagamento> listaSaidaPagamento, int tipoSaida, bool ehComplementar, bool ehEspelho)
        {
            var repCupom = new RepositorioGenerico<tb_solicitacao_documento_fiscal>();
            tb_solicitacao_documento_fiscal _solicitacao_documento_fiscalE = new tb_solicitacao_documento_fiscal();
            try
            {
                _solicitacao_documento_fiscalE.dataSolicitacao = DateTime.Now;
                _solicitacao_documento_fiscalE.haPagamentoCartao = listaSaidaPagamento.Where(sp => sp.CodFormaPagamento.Equals(FormaPagamento.CARTAO)).Count() > 0;
                _solicitacao_documento_fiscalE.cartaoAprovado = false;
                _solicitacao_documento_fiscalE.ehComplementar = ehComplementar;
                _solicitacao_documento_fiscalE.ehEspelho = ehEspelho;
                
                if (tipoSaida.Equals(Saida.TIPO_PRE_VENDA))
                    _solicitacao_documento_fiscalE.tipoSolicitacao = TIPO_CUPOM_ECF;
                else
                    _solicitacao_documento_fiscalE.tipoSolicitacao = TIPO_CUPOM_NFCE;
                repCupom.Inserir(_solicitacao_documento_fiscalE);

                repCupom.SaveChanges();

                var repSolicitacaoSaida = new RepositorioGenerico<tb_solicitacao_saida>();
                foreach (SaidaPedido _saidaPedido in listaSaidaPedido) {
                    tb_solicitacao_saida _solicitacao_saida = new tb_solicitacao_saida();
                    _solicitacao_saida.codSaida = _saidaPedido.CodSaida;
                    _solicitacao_saida.codSolicitacao = _solicitacao_documento_fiscalE.codSolicitacao;
                    _solicitacao_saida.valorTotal = _saidaPedido.TotalAVista;
                    repSolicitacaoSaida.Inserir(_solicitacao_saida);
                }
                repSolicitacaoSaida.SaveChanges();


                foreach (SaidaPagamento _solicitacaoPagamento in listaSaidaPagamento) {
                    _solicitacao_documento_fiscalE.tb_solicitacao_pagamentos.Add(
                        new tb_solicitacao_pagamentos()
                        {
                            codCartao = _solicitacaoPagamento.CodCartaoCredito,
                            codFormaPagamento = _solicitacaoPagamento.CodFormaPagamento,
                            parcelas = _solicitacaoPagamento.Parcelas,
                            valor = _solicitacaoPagamento.Valor
                        }
                    );
                }

                repCupom.SaveChanges();

                return _solicitacao_documento_fiscalE.codSolicitacao;
            }
            catch (Exception)
            {
                // se ocorrer erro na inserção provavelmente é reenvio do cupom fiscal
                //throw new DadosException("Cupom", e.Message, e);
            }
            return 0;

        }

        public void EnviarProximoCartao()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Atualiza dados do cupom
        /// </summary>
        /// <param name="cupom"></param>
        public void EnviarProximoECF()
        {
            try
            {
                var repCupom = new RepositorioGenerico<tb_solicitacao_documento_fiscal>();
                DirectoryInfo pastaECF = new DirectoryInfo(Global.PASTA_COMUNICACAO_FRENTE_LOJA);
                if (pastaECF.Exists)
                {
                    FileInfo[] files = pastaECF.GetFiles("*.TXT", SearchOption.TopDirectoryOnly);
                    if (files.Length == 0)
                    {
                        IQueryable<tb_solicitacao_documento_fiscal> solicitacoes = GetQuery().Where(C => C.tipoSolicitacao.Equals(TIPO_CUPOM_ECF)).OrderBy(s => s.dataSolicitacao);
                        if (solicitacoes.Count() > 0)
                        {
                            Thread.Sleep(500); // Aguarda 1 segundo para enviar o próximo cupum e evitar junção.
                            tb_solicitacao_documento_fiscal solicitacaoE = solicitacoes.FirstOrDefault();
                            List<tb_solicitacao_saida> listaSolicitacaoSaida = solicitacaoE.tb_solicitacao_saida.ToList();
                            RemoverSolicitacaoDocumentoFiscal(solicitacaoE.codSolicitacao);
                            GerarDocumentoECF(listaSolicitacaoSaida);
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
        /// Atualiza dados do cupom
        /// </summary>
        /// <param name="cupom"></param>
        public void EnviarProximoNFCe()
        {
            try
            {
                IQueryable<tb_solicitacao_documento_fiscal> solicitacoes = GetQuery().Where(C => C.tipoSolicitacao.Equals(TIPO_CUPOM_NFCE)).OrderBy(s => s.dataSolicitacao);
                if (solicitacoes.Count() > 0)
                {
                    tb_solicitacao_documento_fiscal solicitacaoE = solicitacoes.FirstOrDefault();
                    List<tb_solicitacao_saida> listaSolicitacaoSaida = solicitacaoE.tb_solicitacao_saida.ToList();
                    List<tb_solicitacao_pagamentos> listaSolicitacaoPagamentos = solicitacaoE.tb_solicitacao_pagamentos.ToList();
                    RemoverSolicitacaoDocumentoFiscal(solicitacaoE.codSolicitacao);
                    GerenciadorNFe.GetInstance().EnviarNFE(listaSolicitacaoSaida, listaSolicitacaoPagamentos, Saida.TIPO_PRE_VENDA_NFCE,  false, false);
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
        public void RemoverSolicitacaoDocumentoFiscal(long codSolicitacao)
        {
            try
            {
                var repCupom = new RepositorioGenerico<tb_solicitacao_documento_fiscal>();
                repCupom.Remover(s => s.codSolicitacao == codSolicitacao);
                repCupom.SaveChanges();
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
        private IQueryable<tb_solicitacao_documento_fiscal> GetQuery()
        {
            var repCupom = new RepositorioGenerico<tb_solicitacao_documento_fiscal>();
            var saceEntities = (SaceEntities)repCupom.ObterContexto();
            var query = from documento in saceEntities.tb_solicitacao_documento_fiscal
                        select documento;
            return query;
        }

        /// <summary>
        /// Obtém lista de cupons emitidos
        /// </summary>
        /// <returns></returns>
        public List<CupomFiscal> ObterTodos()
        {
            var repCupom = new RepositorioGenerico<tb_saida>();
            var saceEntities = (SaceEntities)repCupom.ObterContexto();
            var query = from saida in saceEntities.tb_saida
                        where !saida.pedidoGerado.Trim().Equals("")
                        orderby saida.pedidoGerado
                        select new CupomFiscal
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
        private void GerarDocumentoECF(List<tb_solicitacao_saida> listaSolicitacaoCupomSaida)
        {
            try
            {
                List<Saida> saidas = new List<Saida>();
                decimal totalSolicitacaoSaidas = 0;
                foreach (tb_solicitacao_saida solicitacaoSaida in listaSolicitacaoCupomSaida)
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

                            decimal totalAVista = listaSolicitacaoCupomSaida.Where(cs => cs.codSaida.Equals(saida.CodSaida)).Sum(cs => cs.valorTotal);
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
                            List<SaidaPagamento> saidaPagamentos = (List<SaidaPagamento>)GerenciadorSaidaPagamento.GetInstance(null).ObterPorSaidas(listaSolicitacaoCupomSaida.Select(cs=>cs.codSaida).ToList());
                            
                            // imprime desconto
                            decimal desconto = (precoTotalProdutosVendidos - listaSolicitacaoCupomSaida.Sum(cs=>cs.valorTotal));
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


        public Boolean AtualizarPedidosComDocumentosFiscais()
        {
            Boolean atualizou = false;
            DirectoryInfo PastaRetorno = new DirectoryInfo(Global.PASTA_COMUNICACAO_FRENTE_LOJA_RETORNO);
            string nomeComputador = System.Windows.Forms.SystemInformation.ComputerName;
            if (nomeComputador.Equals(Global.NOME_SERVIDOR) && PastaRetorno.Exists)
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
                                    RemoverSolicitacaoDocumentoFiscal(saidaPedido.CodSaida);
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
    }
}