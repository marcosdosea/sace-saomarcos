using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Dominio;
using Dados.saceDataSetTableAdapters;
using Dados;
using Util;
using System.Data.Common;
using System.IO.Ports;


namespace Negocio
{
    public class GerenciadorSaida : IGerenciadorSaida
    {
        private static IGerenciadorSaida gSaida;
        private static tb_saidaTableAdapter tb_SaidaTA;

        public static IGerenciadorSaida getInstace()
        {
            if (gSaida == null)
            {
                gSaida = new GerenciadorSaida();
                tb_SaidaTA = new tb_saidaTableAdapter();
            }
            return gSaida;
        }

        public Int64 inserir(Saida saida)
        {
            try
            {
                saida.Desconto = (1 - Global.DESCONTO_PADRAO) * 100;

                tb_SaidaTA.Insert(saida.DataSaida, saida.CodCliente, saida.TipoSaida, saida.CodProfissional,
                    saida.NumeroCartaoVenda, saida.PedidoGerado, saida.Total, saida.TotalAVista, saida.Desconto,
                    saida.TotalPago, saida.TotalLucro, saida.CodSituacaoPagamentos, saida.Troco, saida.EntregaRealizada,
                    saida.Nfe, saida.CpfCnpj);


                return (Int64)tb_SaidaTA.getUltimoCodSaida();


            }
            catch (Exception e)
            {
                throw new DadosException("Saída", e.Message, e);
            }
        }

        public void atualizar(Saida saida)
        {
            try
            {
                tb_SaidaTA.Update(saida.DataSaida, saida.CodCliente, saida.TipoSaida, saida.CodProfissional,
                    saida.NumeroCartaoVenda, saida.PedidoGerado, saida.Total, saida.TotalAVista, saida.Desconto,
                    saida.TotalPago, saida.TotalLucro, saida.CodSituacaoPagamentos, saida.Troco, saida.EntregaRealizada,
                    saida.Nfe, saida.CpfCnpj, saida.CodSaida);


            }
            catch (Exception e)
            {
                throw new DadosException("Saída", e.Message, e);
            }
        }

        public void remover(Saida saida)
        {
            try
            {
                if (saida.TipoSaida == Saida.TIPO_ORCAMENTO)
                {
                    GerenciadorSaidaPagamento.getInstace().removerPagamentos(saida);
                    tb_SaidaTA.Delete(saida.CodSaida);
                }
                else if (saida.TipoSaida == Saida.TIPO_PRE_VENDA)
                {
                    excluirDocumentoFiscal(saida);
                    GerenciadorSaidaPagamento.getInstace().removerPagamentos(saida);
                    List<SaidaProduto> saidaProdutos = GerenciadorSaidaProduto.getInstace().obterSaidaProdutos(saida.CodSaida);
                    registrarEstornoEstoque(saidaProdutos);
                    tb_SaidaTA.Delete(saida.CodSaida);
                }
                else if (saida.TipoSaida == Saida.TIPO_VENDA)
                {
                    GerenciadorSaidaPagamento.getInstace().removerPagamentos(saida);
                    List<SaidaProduto> saidaProdutos = GerenciadorSaidaProduto.getInstace().obterSaidaProdutos(saida.CodSaida);
                    registrarEstornoEstoque(saidaProdutos);
                    saida.TipoSaida = Saida.TIPO_ORCAMENTO;
                    atualizar(saida);
                }
            }
            catch (Exception e)
            {
                throw new DadosException("Saída", e.Message, e);
            }
        }

        public Boolean dataVencimentoProdutoAceitavel(Produto produto, DateTime dataVencimento)
        {
            if (produto.TemVencimento)
            {
                DateTime dataMaisAntigo = GerenciadorEntradaProduto.getInstace().getDataProdutoMaisAntigoEstoque(produto);
                return (dataMaisAntigo >= dataVencimento);
            }
            return true;
        }

        public Saida obterSaida(Int64 codSaida)
        {
            Saida saida = null;
            Dados.saceDataSetTableAdapters.tb_saidaTableAdapter tb_saidaTA = new tb_saidaTableAdapter();
            Dados.saceDataSet.tb_saidaDataTable saidaDT = tb_saidaTA.GetDataByCodSaida(codSaida);

            if (saidaDT.Count > 0)
            {
                saida = new Saida();
                saida.CodSaida = codSaida;
                saida.DataSaida = DateTime.Parse(saidaDT.Rows[0]["dataSaida"].ToString());
                saida.TipoSaida = int.Parse(saidaDT.Rows[0]["codTipoSaida"].ToString());
                saida.CodCliente = long.Parse(saidaDT.Rows[0]["codCliente"].ToString());
                saida.CodProfissional = long.Parse(saidaDT.Rows[0]["codProfissional"].ToString());
                saida.NumeroCartaoVenda = int.Parse(saidaDT.Rows[0]["numeroCartaoVenda"].ToString());
                saida.PedidoGerado = saidaDT.Rows[0]["pedidoGerado"].ToString();
                saida.Desconto = decimal.Parse(saidaDT.Rows[0]["desconto"].ToString());
                saida.Total = decimal.Parse(saidaDT.Rows[0]["total"].ToString());
                saida.TotalAVista = decimal.Parse(saidaDT.Rows[0]["totalAVista"].ToString());
                saida.TotalLucro = decimal.Parse(saidaDT.Rows[0]["totalLucro"].ToString());
                saida.TotalPago = decimal.Parse(saidaDT.Rows[0]["totalPago"].ToString());
                saida.CodSituacaoPagamentos = Convert.ToInt32(saidaDT.Rows[0]["codSituacaoPagamentos"].ToString());
                saida.EntregaRealizada = Convert.ToBoolean(saidaDT.Rows[0]["entregaRealizada"].ToString());
                saida.Nfe = saidaDT.Rows[0]["nfe"].ToString();
                saida.Troco = Convert.ToDecimal(saidaDT.Rows[0]["troco"].ToString());
                saida.CpfCnpj = saidaDT.Rows[0]["cpf_cnpj"].ToString();
            }
            return saida;
        }

        public void encerrar(Saida saida)
        {
            if (saida.TipoSaida == Saida.TIPO_ORCAMENTO)
            {
                saida.TipoSaida = Saida.TIPO_PRE_VENDA;

                saida.CodSituacaoPagamentos = SituacaoPagamentos.LANCADOS;

                List<SaidaPagamento> saidaPagamentos = GerenciadorSaidaPagamento.getInstace().obterSaidaPagamentos(saida.CodSaida);
                registrarPagamentosSaida(saidaPagamentos, saida);

                List<SaidaProduto> saidaProdutos = GerenciadorSaidaProduto.getInstace().obterSaidaProdutos(saida.CodSaida);
                Decimal somaPrecosCusto = registrarBaixaEstoque(saidaProdutos);

                saida.TotalLucro = saida.TotalAVista - somaPrecosCusto;
                atualizar(saida);
            }

        }

        public void registrarPagamentosSaida(List<SaidaPagamento> pagamentos, Saida saida)
        {
            decimal totalRegistrado = 0;

            foreach (SaidaPagamento pagamento in pagamentos)
            {

                List<Conta> contas = GerenciadorConta.getInstace().obterContasSaidaPorCodPagamento(saida.CodSaida, pagamento.CodSaidaPagamento);

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
                conta.CodEntrada = 1; // entrada não válida
                conta.CodPessoa = saida.CodCliente;
                conta.CodPagamento = pagamento.CodSaidaPagamento;

                // Quando o pagamento é realizado em dinheiro a conta já é inserida quitada
                if (pagamento.CodFormaPagamento == FormaPagamento.DINHEIRO)
                    conta.CodSituacao = Conta.SITUACAO_QUITADA;
                else
                    conta.CodSituacao = Conta.SITUACAO_ABERTA;

                if (pagamento.CodFormaPagamento == FormaPagamento.CARTAO)
                {
                    conta.CodPessoa = GerenciadorCartaoCredito.getInstace().obterCartaoCredito(pagamento.CodCartaoCredito).CodPessoa;
                }

                conta.CodDocumento = pagamento.CodDocumentoPagamento;
                conta.TipoConta = Conta.CONTA_RECEBER;

                if (((totalRegistrado + pagamento.Valor) > saida.TotalAVista) && (pagamento.CodFormaPagamento == FormaPagamento.DINHEIRO))
                {
                    conta.Valor = (saida.TotalAVista - totalRegistrado) / pagamento.Parcelas;
                }
                else
                {
                    conta.Valor = pagamento.Valor / pagamento.Parcelas;
                }

                Int64 codConta = -1;

                for (int i = 0; i < pagamento.Parcelas; i++)
                {
                    if (pagamento.CodFormaPagamento == (FormaPagamento.CARTAO))
                    {
                        CartaoCredito cartaoCredito = GerenciadorCartaoCredito.getInstace().obterCartaoCredito(pagamento.CodCartaoCredito);
                        pagamento.Data = pagamento.Data.AddDays(cartaoCredito.DiaBase);
                        conta.DataVencimento = pagamento.Data;
                    }
                    else if ((pagamento.CodFormaPagamento == FormaPagamento.BOLETO) || (pagamento.CodFormaPagamento == FormaPagamento.CHEQUE))
                    {
                        DocumentoPagamento documento = GerenciadorDocumentoPagamento.getInstace().obterDocumentoPagamento(pagamento.CodDocumentoPagamento);
                        conta.DataVencimento = documento.DataVencimento;
                        conta.Valor = documento.Valor;
                    }
                    else if ((pagamento.CodFormaPagamento == FormaPagamento.CREDIARIO) || (pagamento.CodFormaPagamento == FormaPagamento.DEPOSITO) ||
                      (pagamento.CodFormaPagamento == FormaPagamento.PROMISSORIA))
                    {
                        pagamento.Data = pagamento.Data.AddDays(pagamento.IntervaloDias);
                        conta.DataVencimento = pagamento.Data;
                    }
                    else
                    {
                        conta.DataVencimento = pagamento.Data;
                    }

                    codConta = GerenciadorConta.getInstace().inserir(conta);
                }

                totalRegistrado += pagamento.Valor;



                if (pagamento.CodFormaPagamento == FormaPagamento.DINHEIRO)
                {
                    MovimentacaoConta movimentacao = new MovimentacaoConta();
                    movimentacao.CodContaBanco = pagamento.CodContaBanco;
                    movimentacao.CodConta = codConta;
                    movimentacao.CodResponsavel = saida.CodCliente;
                    movimentacao.CodTipoMovimentacao = MovimentacaoConta.RECEBIMENTO_CLIENTE;
                    movimentacao.DataHora = DateTime.Now;
                    if (totalRegistrado > saida.TotalAVista)
                    {
                        movimentacao.Valor = pagamento.Valor - saida.Troco;
                    }
                    else
                    {
                        movimentacao.Valor = pagamento.Valor;
                    }
                    GerenciadorMovimentacaoConta.getInstace().inserir(movimentacao);
                }
            }
        }

        private void registrarEstornoEstoque(List<SaidaProduto> saidaProdutos)
        {
            foreach (SaidaProduto saidaProduto in saidaProdutos)
            {
                Produto produto = GerenciadorProduto.getInstace().obterProduto(saidaProduto.CodProduto);

                if (produto.CodCST != Produto.ST_OUTRAS)
                {
                    GerenciadorProdutoLoja.getInstace().adicionaQuantidade(saidaProduto.Quantidade, 0, Global.LOJA_PADRAO, saidaProduto.CodProduto);
                }
                else
                {
                    GerenciadorProdutoLoja.getInstace().adicionaQuantidade(0, saidaProduto.Quantidade, Global.LOJA_PADRAO, saidaProduto.CodProduto);
                }

                GerenciadorEntradaProduto.getInstace().estornarItensVendidosEstoque(produto, saidaProduto.DataValidade, saidaProduto.Quantidade);
            }
        }

        private Decimal registrarBaixaEstoque(List<SaidaProduto> saidaProdutos)
        {
            Decimal somaPrecosCustoEstoque = 0;
            Decimal somaPrecosCustoAtual = 0;
            foreach (SaidaProduto saidaProduto in saidaProdutos)
            {
                Produto produto = GerenciadorProduto.getInstace().obterProduto(saidaProduto.CodProduto);
                somaPrecosCustoAtual += GerenciadorProduto.getInstace().calculaPrecoCusto(produto) * saidaProduto.Quantidade;

                if (produto.CodCST != Produto.ST_OUTRAS)
                {
                    GerenciadorProdutoLoja.getInstace().adicionaQuantidade(saidaProduto.Quantidade * (-1), 0, Global.LOJA_PADRAO, saidaProduto.CodProduto);
                }
                else
                {
                    GerenciadorProdutoLoja.getInstace().adicionaQuantidade(0, saidaProduto.Quantidade * (-1), Global.LOJA_PADRAO, saidaProduto.CodProduto);
                }

                somaPrecosCustoEstoque = GerenciadorEntradaProduto.getInstace().baixaItensVendidosEstoque(produto, saidaProduto.DataValidade, saidaProduto.Quantidade);
            }

            if ((somaPrecosCustoAtual * 8 / 10) > somaPrecosCustoEstoque)
            {
                return somaPrecosCustoAtual;
            }
            return somaPrecosCustoEstoque;
        }


        public void gerarDocumentoFiscal(Saida saida)
        {
            if (GerenciadorSaida.getInstace().atualizarPedidosComDocumentosFiscais())
            {
                saida = obterSaida(saida.CodSaida);
            }

            if (saida.TipoSaida == Saida.TIPO_VENDA)
            {
                throw new NegocioException("Cupom Fiscal referente a essa pré-venda já foi impresso.");
            }

            List<SaidaProduto> saidaProdutos = GerenciadorSaidaProduto.getInstace().obterSaidaProdutosSemCST(saida.CodSaida, Produto.ST_OUTRAS);

            if (saidaProdutos.Count > 0)
            {
                List<SaidaPagamento> saidaPagamentos = GerenciadorSaidaPagamento.getInstace().obterSaidaPagamentos(saida.CodSaida);

                String nomeArquivo = Global.PASTA_COMUNICACAO_SERVIDOR + saida.CodSaida + ".txt";

                DirectoryInfo pastaECF = new DirectoryInfo(Global.PASTA_COMUNICACAO_SERVIDOR);

                if (!pastaECF.Exists)
                {
                    throw new NegocioException("Não foi possível imprimir o cupom ECF. Verifique se a rede está acessível.");
                }


                StreamWriter arquivo = new StreamWriter(nomeArquivo, false, Encoding.ASCII);


                foreach (SaidaProduto saidaProduto in saidaProdutos)
                {

                    if (saidaProduto.CodCST != Produto.ST_OUTRAS)
                    {
                        String situacaoFiscal = "01";
                        if (saidaProduto.CodCST.Equals(Produto.ST_SUBSTITUICAO) || saidaProduto.CodCST.Equals(Produto.ST_SUBSTITUICAO_ICMS_COBRADO) ||
                            saidaProduto.CodCST.Equals(Produto.ST_SUBSTITUICAO_ICMS_REDUCAO_BC) || saidaProduto.CodCST.Equals(Produto.ST_SUBSTITUICAO_ISENTA_NAO_TRIBUTADA))
                        {
                             situacaoFiscal = "FF";
                        }

                        arquivo.Write(saidaProduto.CodProduto + ";");
                        arquivo.Write(saidaProduto.Nome + ";");
                        arquivo.Write(saidaProduto.Quantidade.ToString() + ";");
                        arquivo.Write(saidaProduto.ValorVenda.ToString() + ";");
                        arquivo.Write(situacaoFiscal + ";");
                        arquivo.Write("0;");
                        arquivo.Write(saidaProduto.ValorVenda + ";");
                        arquivo.WriteLine(saidaProduto.Unidade + ";");
                    }
                }

                if (!saida.CpfCnpj.Trim().Equals(""))
                    arquivo.WriteLine("<CPF>" + saida.CpfCnpj);

                if (saida.Desconto > 0)
                    arquivo.WriteLine("<DESCONTO>" + (saida.Total - saida.TotalPago));

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
        }


        public void excluirDocumentoFiscal(Saida saida)
        {

            String nomeArquivo = Global.PASTA_COMUNICACAO_SERVIDOR + saida.CodSaida + ".txt";

            DirectoryInfo pastaECF = new DirectoryInfo(Global.PASTA_COMUNICACAO_SERVIDOR);

            FileInfo cupomFiscal = new FileInfo(pastaECF + nomeArquivo);

            try
            {
                if (cupomFiscal.Exists)
                {
                    cupomFiscal.Delete();
                }
            }
            catch (Exception)
            {

                throw new NegocioException("Problemas na exclusão do Cupom Fiscal. É provável que ele esteja sendo impresso.");
            }

        }


        public Boolean atualizarPedidosComDocumentosFiscais()
        {
            Boolean atualizou = false;
            try
            {
                DirectoryInfo Dir = new DirectoryInfo(Global.PASTA_COMUNICACAO_SERVIDOR_RETORNO);
                // Busca automaticamente todos os arquivos em todos os subdiretórios
                FileInfo[] Files = Dir.GetFiles("*", SearchOption.TopDirectoryOnly);
                foreach (FileInfo file in Files)
                {
                    bool sucesso = false;
                    String numeroCF = null;
                    String linha = null;
                    StreamReader reader = new StreamReader(file.FullName);

                    if ((linha = reader.ReadLine()) != null)
                    {
                        sucesso = linha.Equals("OK");
                        if (sucesso && ((linha = reader.ReadLine()) != null))
                        {
                            numeroCF = linha;
                        }
                    }
                    reader.Close();
                    if (sucesso)
                    {
                        Saida saida = obterSaida(Convert.ToInt64(file.Name.Replace(".TXT", "")));
                        if (saida != null)
                        {
                            saida.PedidoGerado = numeroCF;
                            saida.TipoSaida = Saida.TIPO_VENDA;
                            atualizar(saida);
                            atualizou = true;
                        }
                    }
                    file.CopyTo(Global.PASTA_COMUNICACAO_SERVIDOR_BACKUP + file.Name, true);
                    file.Delete();
                }
            }
            catch (Exception e)
            {
                // Essa exceção não precisa ser tratada. Apenas os cupons fiscais não são recuperados.
                //throw new NegocioException("Ocorreram problemas na recuperação dos dados dos cupons fiscais. Favor contactar o administrador informando o erro " + e.Message);
            }
            return atualizou;
        }

        public void imprimirDAV(Saida saida, bool comprimido)
        {
            if (comprimido)
                imprimirDAVComprimido(saida);
            else
                imprimirDAVNormal(saida);
        }

        private void imprimirDAVComprimido(Saida saida)
        {
            try
            {
                Loja loja = GerenciadorLoja.getInstace().obter(Global.LOJA_PADRAO);
                Pessoa pessoaLoja = GerenciadorPessoa.getInstace().obterPessoa(loja.CodPessoa);

                ImprimeTexto imp = new ImprimeTexto();

                imp.Inicio(Global.PORTA_IMPRESSORA);

                imp.ImpLF(Global.LINHA_COMPRIMIDA);
                if (saida.TipoSaida == Saida.TIPO_ORCAMENTO)
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

                Pessoa cliente = GerenciadorPessoa.getInstace().obterPessoa(saida.CodCliente);
                if (cliente.Nome.Length > 29)
                {
                    imp.Imp("Cliente: " + cliente.Nome.Substring(1, 29));
                }
                else
                {
                    imp.Imp("Cliente: " + cliente.Nome);
                }
                imp.ImpColLF(39, "CPF/CNPF: " + cliente.CpfCnpj);
                imp.Imp("No do Documento: " + saida.CodSaida);
                imp.ImpColLF(30, "No do Documento Fiscal: " + saida.PedidoGerado);
                imp.ImpLF(Global.LINHA_COMPRIMIDA);
                imp.ImpLF("Cod  Produto                                   Qtdade    UN ");
                imp.ImpLF("                                      Preco(R$) Subtotal(R$)");


                List<SaidaProduto> saidaProdutos = GerenciadorSaidaProduto.getInstace().obterSaidaProdutos(saida.CodSaida);
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
                    imp.ImpColDireita(38, 46, produto.ValorVenda.ToString());
                    imp.ImpColLFDireita(48, 59, produto.Subtotal.ToString("N2"));
                }
                imp.ImpLF(Global.LINHA_COMPRIMIDA);
                imp.ImpLF("Total Venda: " + saida.Total + "     Desconto: " + saida.Desconto + "%");
                imp.ImpColLFDireita(30, 59, imp.NegritoOn + "Total Pagar:" + saida.TotalAVista + imp.NegritoOff);
                imp.ImpLF(Global.LINHA_COMPRIMIDA);
                imp.ImpColLFCentralizado(0, 59, "E vedada a autenticacao deste documento");
                imp.ImpLF(Global.LINHA_COMPRIMIDA);

                imp.Pula(2);
                imp.Fim();
            }
            catch (Exception)
            {
                throw new NegocioException("Não foi possível realizar a impressão. Por Favor Verifique se a impressora MATRICIAL está LIGADA.");
            }
        }

        private void imprimirDAVNormal(Saida saida)
        {
            try
            {
                Loja loja = GerenciadorLoja.getInstace().obter(Global.LOJA_PADRAO);
                Pessoa pessoaLoja = GerenciadorPessoa.getInstace().obterPessoa(loja.CodPessoa);

                ImprimeTexto imp = new ImprimeTexto();

                imp.Inicio(Global.PORTA_IMPRESSORA);

                imp.ImpLF(Global.LINHA);
                if (saida.TipoSaida == Saida.TIPO_ORCAMENTO)
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

                Pessoa cliente = GerenciadorPessoa.getInstace().obterPessoa(saida.CodCliente);
                imp.Imp("Cliente: " + cliente.Nome);
                imp.ImpColLF(50, "CPF/CNPF: " + cliente.CpfCnpj);
                imp.Imp("No do Documento: " + saida.CodSaida);
                imp.ImpColLF(50, "No do Documento Fiscal: " + saida.PedidoGerado);
                imp.ImpLF(Global.LINHA);
                imp.ImpLF("Cod  Produto                                   Qtdade  UN Preco(R$) Subtotal(R$)");


                List<SaidaProduto> saidaProdutos = GerenciadorSaidaProduto.getInstace().obterSaidaProdutos(saida.CodSaida);
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
                    imp.ImpColDireita(58, 66, produto.ValorVenda.ToString());
                    imp.ImpColLFDireita(68, 79, produto.Subtotal.ToString("N2"));
                }
                imp.ImpLF(Global.LINHA);
                imp.Imp("Total Venda: " + saida.Total + "            Desconto: " + saida.Desconto + "%");
                imp.ImpColLFDireita(55, 80, imp.NegritoOn + "Total Pagar:" + saida.TotalAVista + imp.NegritoOff);
                imp.ImpLF(Global.LINHA);
                imp.ImpColLFCentralizado(0, 79, "E vedada a autenticacao deste documento");
                imp.ImpLF(Global.LINHA);

                imp.Pula(2);
                imp.Fim();
            }
            catch (Exception)
            {
                throw new NegocioException("Não foi possível realizar a impressão. Por Favor Verifique se a impressora MATRICIAL está LIGADA.");
            }
        }

        public void imprimirNotaFiscal(Saida saida)
        {

            if (saida.TipoSaida == Saida.TIPO_ORCAMENTO)
            {
                throw new NegocioException("O Documento Fiscal não pode ser impresso a partir de um ORÇAMENTO. É necessário transformá-lo numa PRÉ-VENDA.");
            }
                
            try
            {
                if (saida.TipoSaida == Saida.TIPO_PRE_VENDA)
                {
                    GerenciadorSaida.getInstace().gerarDocumentoFiscal(saida);
                }
                else if (saida.TipoSaida == Saida.TIPO_VENDA)
                {
                    ImprimeTexto imp = new ImprimeTexto();

                    imp.Inicio(Global.PORTA_IMPRESSORA);

                    Pessoa cliente = GerenciadorPessoa.getInstace().obterPessoa(saida.CodCliente);

                    imprimirNotaFiscalCabecalho(saida, cliente, imp);

                    //linha 23 
                    List<SaidaProduto> saidaProdutos = GerenciadorSaidaProduto.getInstace().obterSaidaProdutos(saida.CodSaida);
                    int numeroProdutosImpressos = 0;
                    int numeroPaginas = 1;
                    decimal subtotal = 0;

                    imp.Imp(imp.Comprimido);
                    foreach (SaidaProduto produto in saidaProdutos)
                     {
                        if (numeroProdutosImpressos >= 20)
                        {
                            numeroProdutosImpressos = 0;
                            numeroPaginas++;

                            imprimirNotaFiscalRodape(saida, cliente, imp, numeroPaginas, subtotal, false);
                            imp.Eject();
                            imprimirNotaFiscalCabecalho(saida, cliente, imp);
                        }

                        if (numeroProdutosImpressos == 0)
                        {
                            if (numeroPaginas > 1)
                            {
                                imp.ImpCol(13, "VALOR TRANSPORTADO DA PAG    " + numeroPaginas + " ->");
                                imp.ImpColDireita(100, 116, subtotal.ToString("N2"));
                                imp.Pula(2);
                            }
                            else
                            {
                                imp.Pula(3);
                            }
                        }
                        
                        imp.ImpColDireita(3, 7, produto.CodProduto.ToString());
                        imp.ImpCol(13, produto.Nome);
                        imp.ImpCol(68, produto.CodCST);
                        imp.ImpCol(75, produto.Unidade);
                        imp.ImpColDireita(80, 86, produto.Quantidade.ToString());
                        imp.ImpColDireita(80, 103, produto.ValorVenda.ToString());
                        imp.ImpColDireita(115, 130, produto.Subtotal.ToString("N2"));
                        if (produto.CodCST == Produto.ST_TRIBUTADO_INTEGRAL)
                            imp.ImpCol(133, "17%");
                        else
                            imp.ImpCol(120, "0%");
                        imp.Pula(1);

                        subtotal += produto.Subtotal;
                        numeroProdutosImpressos++;
                        
                    }

                    imp.Pula(20 - numeroProdutosImpressos);


                    imprimirNotaFiscalRodape(saida, cliente, imp, numeroPaginas, subtotal, true);

                    imp.Eject();
                    imp.Fim();
                }
            }
            catch (Exception)
            {
                throw new NegocioException("Não foi possível realizar a impressão. Por Favor Verifique se a impressora MATRICIAL está LIGADA.");
            }
        }

        private void imprimirNotaFiscalCabecalho(Saida saida, Pessoa cliente, ImprimeTexto imp)
        {
            imp.Imp(imp.Normal);
            imp.Pula(3);
            // linha 4
            imp.ImpCol(52, "XX");
            imp.ImpCol(75, saida.Nfe);
            imp.Pula(5);

            // linha 8
            imp.ImpCol(2, "VENDA TRIBUTADA PELA ECF");
            imp.ImpCol(26, "5.929");
            imp.Pula(2);

            
            // linha 10
            imp.ImpCol(2, cliente.Nome);
            imp.ImpCol(52, cliente.CpfCnpj);
            imp.ImpCol(71, DateTime.Now.ToShortDateString());
            imp.Pula(1);

            // linha 12
            imp.ImpCol(2, cliente.Endereco + ", " + cliente.Numero);
            imp.ImpCol(35, cliente.Bairro);
            imp.ImpCol(60, cliente.Cep);
            imp.ImpCol(71, saida.DataSaida.ToShortDateString());
            imp.Pula(1);

            // linha 14
            imp.ImpCol(2, cliente.Cidade);
            imp.ImpCol(35, cliente.Fone1);
            imp.ImpCol(45, cliente.Uf);
            imp.ImpCol(54, cliente.Ie);
            imp.ImpCol(74, saida.DataSaida.ToShortTimeString());
            imp.Pula(5);
        }

        private void imprimirNotaFiscalRodape(Saida saida, Pessoa cliente, ImprimeTexto imp, int numeroPagina, decimal subtotal, bool ultimaPagina)
        {
            if (ultimaPagina)
            {
                imp.Imp(imp.Comprimido);
                imp.ImpCol(13, "DESCONTO PROMOCIONAL ---------> R$" + (saida.Total - saida.TotalAVista).ToString("N2"));

                imp.Pula(2);
                imp.Imp(imp.Normal);
                imp.ImpCol(13, "***  REF. AO CUMPOM FISCAL NUMERO " + saida.PedidoGerado + "/001   ***");

                imp.Pula(5);
                // linha 45
                imp.ImpColLFDireita(65, 78, saida.TotalAVista.ToString("N2"));

                // linha 46
                imp.ImpColDireita(10, 15, "0.00");
                imp.ImpColDireita(50, 62, "0.00");
                imp.ImpColDireita(65, 78, saida.TotalAVista.ToString("N2"));
                imp.Pula(3);
                
                // linha 49
                imp.ImpCol(2, cliente.Nome);
                imp.ImpCol(47, "1");
                imp.ImpCol(63, cliente.CpfCnpj);
                imp.Pula(1);

                // linha 51
                imp.ImpCol(2, cliente.Endereco + ", " + cliente.Numero);
                imp.ImpCol(40, cliente.Cidade);
                imp.ImpCol(61, cliente.Uf);
                imp.ImpCol(65, cliente.Ie);
                imp.Pula(5);

                // linha 56
                imp.ImpCol(3, "VEND:   0   CLI: " + cliente.CodPessoa);
            }
            else
            {
                imp.Imp(imp.Comprimido);
                imp.ImpCol(13, "VALOR A TRASNPORTAR P/PAG    " + numeroPagina + " -->" );
                imp.ImpColDireita(100, 116, subtotal.ToString("N2"));
            }
            imp.Imp(imp.Normal);
        }

        public void removerPreVenda(Saida saida)
        {
            if (saida.TipoSaida == Saida.TIPO_PRE_VENDA)
            {
                excluirDocumentoFiscal(saida);
            }
        }
    }


}