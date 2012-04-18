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
                    saida.NumeroCartaoVenda, saida.PedidoGerado, saida.Total,saida.TotalAVista, saida.Desconto,
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
                } 
                else if (saida.TipoSaida == Saida.TIPO_PRE_VENDA)
                {
                    excluirDocumentoFiscal(saida);
                    GerenciadorSaidaPagamento.getInstace().removerPagamentos(saida);
                    List<SaidaProduto> saidaProdutos = GerenciadorSaidaProduto.getInstace().obterSaidaProdutos(saida.CodSaida);
                    registrarEstornoEstoque(saidaProdutos);
                }
                else if (saida.TipoSaida == Saida.TIPO_VENDA)
                {
                    GerenciadorSaidaPagamento.getInstace().removerPagamentos(saida);
                    List<SaidaProduto> saidaProdutos = GerenciadorSaidaProduto.getInstace().obterSaidaProdutos(saida.CodSaida);
                    registrarEstornoEstoque(saidaProdutos);
                }
                tb_SaidaTA.Delete(saida.CodSaida);
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
            Saida saida = new Saida();
            Dados.saceDataSetTableAdapters.tb_saidaTableAdapter tb_saidaTA = new tb_saidaTableAdapter();
            Dados.saceDataSet.tb_saidaDataTable saidaDT = tb_saidaTA.GetDataByCodSaida(codSaida);

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

            foreach(SaidaPagamento pagamento in pagamentos) {

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
                if ( pagamento.CodFormaPagamento == FormaPagamento.DINHEIRO)
                    conta.CodSituacao = Conta.SITUACAO_QUITADA;
                else
                    conta.CodSituacao = Conta.SITUACAO_ABERTA;

                if (pagamento.CodFormaPagamento == FormaPagamento.CARTAO)
                {
                    conta.CodPessoa = GerenciadorCartaoCredito.getInstace().obterCartaoCredito(pagamento.CodCartaoCredito).CodPessoa;
                }

                conta.CodDocumento = pagamento.CodDocumentoPagamento;
                conta.TipoConta = Conta.CONTA_RECEBER;

                if ( ((totalRegistrado + pagamento.Valor) > saida.TotalAVista) && (pagamento.CodFormaPagamento == FormaPagamento.DINHEIRO) )
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
                    else if ((pagamento.CodFormaPagamento == FormaPagamento.BOLETO) || (pagamento.CodFormaPagamento == FormaPagamento.CHEQUE) )
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
                    GerenciadorProdutoLoja.getInstace().adicionaQuantidade(0, saidaProduto.Quantidade  * (-1), Global.LOJA_PADRAO, saidaProduto.CodProduto);
                }

                somaPrecosCustoEstoque = GerenciadorEntradaProduto.getInstace().baixaItensVendidosEstoque(produto, saidaProduto.DataValidade, saidaProduto.Quantidade);
            }

            if ((somaPrecosCustoAtual* 8/10) > somaPrecosCustoEstoque) {
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
            List<SaidaPagamento> saidaPagamentos = GerenciadorSaidaPagamento.getInstace().obterSaidaPagamentos(saida.CodSaida);

            String nomeArquivo = Global.PASTA_COMUNICACAO_SERVIDOR + saida.CodSaida + ".txt";

            DirectoryInfo pastaECF = new DirectoryInfo(Global.PASTA_COMUNICACAO_SERVIDOR);
           
            if (!pastaECF.Exists)
            {
                throw new NegocioException("Não foi possível imprimir o cupom ECF. Verifique se a rede está acessível.");
            }
                
            
            StreamWriter arquivo = new StreamWriter(nomeArquivo, false, Encoding.ASCII); 
            
            
            foreach (SaidaProduto saidaProduto in saidaProdutos) {

                if (saidaProduto.CodCST != Produto.ST_OUTRAS)
                {
                    String situacaoFiscal = saidaProduto.CodCST.Equals(Produto.ST_TRIBUTADO_INTEGRAL) ? "01" : "FF";

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
                    arquivo.WriteLine("<CPF>"+saida.CpfCnpj);

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


        private void excluirDocumentoFiscal(Saida saida)
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
            catch (Exception)
            {
                // Essa exceção não precisa ser tratada. Apenas os cupons fiscais não são recuperados.
                //throw new NegocioException("Ocorreram problemas na recuperação dos dados dos cupons fiscais. Favor contactar o administrador");
            }
            return atualizou;
        }


        public void imprimirOrcamento(Saida saida)
        {
            try
            {
                SerialPort serial = null;
                serial = new SerialPort(Global.SERIAL_IMPRESSORA, 9600);
                serial.ReadTimeout = 1000;
                serial.WriteTimeout = 1000;
                serial.Encoding = Encoding.GetEncoding(1250);
                serial.Open();

                serial.WriteLine("^XA");
                serial.WriteLine("^FO10,15,^AO,25,25^SAO MARCOS MATERIAIS DE CONSTRUCAO LTDA^FS");
                serial.WriteLine("^FO0,40,^AO,12,12^FD================================================================^FS");
                serial.WriteLine("^FO10,70,^AO,12,12^FDCod/Matricula: " + saida.CodCliente + "^FS");

                GerenciadorSaidaProduto.getInstace().obterSaidaProdutos(saida.CodSaida);


                serial.Close();
            }
            catch (Exception)
            {
                throw new NegocioException("Problemas na impressão do orçamento.");
            }
        }

        public void imprimirPreVenda(Saida saida)
        {
                
            try
	        {	                
                //quem vai imprimir
	            Reporter mr = new Reporter();
	            //quem vai colocar em italico e talz
	            EpsonCodes me = new EpsonCodes();

                if (File.Exists(Global.PORTA_IMPRESSORA))   /// e.g. LPT1, PRN, \\Machine01\Printer1
	            {
                    File.Delete(Global.PORTA_IMPRESSORA);
	            }

                mr.Output = Global.PORTA_IMPRESSORA;
	 
	            mr.StartJob();
	            mr.PrintText(01, 01, "========================================");
	            //o \n serve como paper feed na impressora...
	            mr.PrintText(02, 01, "========================================\n");
	 
	            mr.EndJob();
	            //numero de copias
	            mr.Copies = 2;
	 
	            mr.PrintJob();
	        }
	        catch (ExceptioN)
	        {
                throw new NegocioException("Problema na impressao matricial");
	        }
        }
    }


}