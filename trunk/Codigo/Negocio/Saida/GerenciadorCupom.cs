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
    public class GerenciadorCupom
    {

        private static GerenciadorCupom gCupom;

        public static GerenciadorCupom GetInstance()
        {
            if (gCupom == null)
            {
                gCupom = new GerenciadorCupom();
            }
            return gCupom;
        }

        /// <summary>
        /// Insere dados do cupom
        /// </summary>
        /// <param name="cupom"></param>
        /// <returns></returns>
        public long InserirSolicitacaoCupom(long codSaida, decimal total)
        {
            var repCupom = new RepositorioGenerico<tb_solicitacao_cupom>();
            tb_solicitacao_cupom _cupomE = new tb_solicitacao_cupom();
            try
            {
                _cupomE.codSaida = codSaida;
                _cupomE.dataSolicitacao = DateTime.Now;
                _cupomE.enviada = false;
                _cupomE.total = total;

                repCupom.Inserir(_cupomE);
                repCupom.SaveChanges();

                return _cupomE.codSaida;
            }
            catch (Exception)
            {
                // se ocorrer erro na inserção provavelmente é reenvio do cupom fiscal
                //throw new DadosException("Cupom", e.Message, e);
            }
            return 0;

        }

        /// <summary>
        /// Atualiza dados do cupom
        /// </summary>
        /// <param name="cupom"></param>
        public void EnviarProximoCupom()
        {
            try
            {
               string nomeComputador = System.Windows.Forms.SystemInformation.ComputerName;
               if (nomeComputador.Equals(Global.NOME_SERVIDOR))
               {
                   var repCupom = new RepositorioGenerico<tb_solicitacao_cupom>();
                   DirectoryInfo pastaECF = new DirectoryInfo(Global.PASTA_COMUNICACAO_FRENTE_LOJA);
                   if (pastaECF.Exists)
                   {
                       FileInfo[] files = pastaECF.GetFiles("*.TXT", SearchOption.TopDirectoryOnly);
                       if (files.Length == 0)
                       {
                           IQueryable<tb_solicitacao_cupom> solicitacoes = GetQuery().OrderBy(s => s.dataSolicitacao);
                           if (solicitacoes.Count() > 0)
                           {
                               Thread.Sleep(1000); // Aguarda 1 segundo para enviar o próximo cupum e evitar junção.
                               SortedList<long, decimal> saidaTotalAVista = new SortedList<long, decimal>();
                               tb_solicitacao_cupom solicitacaoE = solicitacoes.FirstOrDefault();
                               saidaTotalAVista.Add(solicitacaoE.codSaida, solicitacaoE.total);
                               RemoverSolicitacaoCupom(solicitacaoE.codSaida);
                               GerenciadorCupom.GetInstance().GerarDocumentoFiscal(saidaTotalAVista, null);
                           }
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
        public void RemoverSolicitacaoCupom(long codSaida)
        {
            try
            {
                var repCupom = new RepositorioGenerico<tb_solicitacao_cupom>();
                repCupom.Remover(s => s.codSaida == codSaida);
                repCupom.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DadosException("Cupom", e.Message, e);
            }
        }

        /// <summary>
        /// Consulta para retornar dados da entidade
        /// </summary>
        /// <returns></returns>
        private IQueryable<tb_solicitacao_cupom> GetQuery()
        {
            var repCupom = new RepositorioGenerico<tb_solicitacao_cupom>();
            var saceEntities = (SaceEntities)repCupom.ObterContexto();
            var query = from cupom in saceEntities.tb_solicitacao_cupom
                            select cupom;
            return query;
        }

        /// <summary>
        /// Gera o cupom fiscal a partir das saídas e valores a vista de cada saía
        /// </summary>
        /// <param name="saidaValorComDesconto"> Contém a saída e o valor com desconto de cada saída</param>
        /// <param name="saidaPagamentos"></param>
        public void GerarDocumentoFiscal(SortedList<long, decimal> saidaValorComDesconto, List<SaidaPagamento> saidaPagamentos)
        {
            try
            {
                List<Saida> saidas = new List<Saida>();
                foreach (long codSaida in saidaValorComDesconto.Keys)
                {
                    Saida saida = GerenciadorSaida.GetInstance(null).Obter(codSaida);
                    if (!string.IsNullOrEmpty(saida.CupomFiscal))// == Saida.TIPO_VENDA)
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
                                saidaProdutos = GerenciadorSaidaProduto.GetInstance(null).ObterPorSaida(saida.CodSaida);
                            else
                                saidaProdutos = GerenciadorSaidaProduto.GetInstance(null).ObterPorSaidaSemCST(saida.CodSaida, Cst.ST_OUTRAS);

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
                                else
                                {
                                    GerenciadorSaidaPedido.GetInstance().Atualizar(new SaidaPedido() { CodSaida = saida.CodSaida, CodPedido = saidas[0].CodSaida, TotalAVista = totalAVista });
                                    //throw new NegocioException("Cupom fiscal já foi enviado para impressão. Favor aguardar a impressora fiscal");
                                }
                                listaSaidaProdutos.AddRange(saidaProdutos);
                            }
                            else
                            {
                                decimal totalAVista;
                                saidaValorComDesconto.TryGetValue(saida.CodSaida, out totalAVista);
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

                            // Buscar pagamentos quando não foram passados por parâmetro
                            if ((saidaPagamentos == null) || (saidaPagamentos.Count == 0))
                            {
                                saidaPagamentos = (List<SaidaPagamento>)GerenciadorSaidaPagamento.GetInstance(null).ObterPorSaidas(saidaValorComDesconto.Keys.ToList());
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
                                    GerenciadorSaida.GetInstance(null).AtualizarTipoPedidoGeradoPorSaida(Saida.TIPO_VENDA, numeroCF, saidaPedido.TotalAVista, saidaPedido.CodSaida);
                                    RemoverSolicitacaoCupom(saidaPedido.CodSaida);
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
                                        if (saida != null)
                                        {
                                            saida.TipoSaida = Saida.TIPO_PRE_VENDA;
                                            GerenciadorSaida.GetInstance(null).PrepararEdicaoSaida(saida);
                                        }
                                    }
                                }
                            }
                            GerenciadorSaidaPedido.GetInstance().RemoverPorPedido(codPedido);
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
    }
}