using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using Dados;
using Dominio;
using Util;
using System.Globalization;

namespace Negocio
{
    public class GerenciadorEntrada 
    {
        private static GerenciadorEntrada gEntrada;
                
        public static GerenciadorEntrada GetInstance()
        {
            if (gEntrada == null)
            {
                gEntrada = new GerenciadorEntrada();
            }
            return gEntrada;
        }

        /// <summary>
        /// Inserir uma nova entrada
        /// </summary>
        /// <param name="entrada"></param>
        /// <returns></returns>
        public Int64 Inserir(Entrada entrada)
        {
            try
            {
                var repEntrada = new RepositorioGenerico<EntradaE>();

                EntradaE _entradaE = new EntradaE();
                if ((entrada.TotalBaseSubstituicao > 0) && (entrada.TotalProdutosST <= 0 ))
                  throw new NegocioException("Quando a entrada possui valor de substituição tributária é necessário informar o valor Total dos Produtos Substituição Tributária");
                else if ((entrada.TotalProdutos - entrada.Desconto) > entrada.TotalNota) 
                {
                    throw new NegocioException("O valor Total dos Produtos não pode ser maior que o valor total da Nota menos o desconto.");
                }
                else if (entrada.TotalProdutosST > entrada.TotalProdutos)
                {
                    throw new NegocioException("O valor Total dos Protudos ST não pode ser maior que o valor Total dos Produtos.");
                }

                Atribuir(entrada, _entradaE);

                repEntrada.Inserir(_entradaE);
                repEntrada.SaveChanges();
                
                return _entradaE.codEntrada;
            }
            catch (Exception e)
            {
                throw new DadosException("Entrada", e.Message, e);
            }
        }

        public long Importar(TNfeProc nfe)
        {
            try
            {
                string numeroNF = nfe.NFe.infNFe.ide.nNF;
                string cpf_cnpjFornecedor = nfe.NFe.infNFe.emit.Item;
                IEnumerable<Entrada> entradas = ObterPorNumeroNotaFiscalFornecedor(numeroNF, cpf_cnpjFornecedor);
                if (entradas.Count() > 0)
                {
                    Entrada entrada = entradas.ElementAtOrDefault(0);
                    RecuperarDadosEntrada(nfe, entrada);
                    GerenciadorEntrada.GetInstance().Atualizar(entrada);
                    return entrada.CodEntrada;
                }
                else
                {
                    Entrada entrada = new Entrada();
                    RecuperarDadosEntrada(nfe, entrada);
                    long codEntrada = GerenciadorEntrada.GetInstance().Inserir(entrada);
                    return codEntrada;
                }
            }
            catch (Exception e)
            {
                throw new NegocioException("Problema durante a importação dos dados da Entrada da NF-e. Favor contactar administrador.", e);
            }
        }

        private void RecuperarDadosEntrada(TNfeProc nfe, Entrada entrada)
        {
            CultureInfo ci = new CultureInfo("en-US"); // usado para connversão dos números do xml
            entrada.CodEmpresaFrete = ObterInserirEmpresaFrete(nfe.NFe);
            entrada.CodFornecedor = ObterInserirFornecedor(nfe.NFe);
            entrada.CodSituacaoPagamentos = SituacaoPagamentos.ABERTA;
            entrada.CodTipoEntrada = Entrada.TIPO_ENTRADA;
            entrada.DataEmissao = Convert.ToDateTime(nfe.NFe.infNFe.ide.dhEmi);
            entrada.DataEntrada = DateTime.Now;
            entrada.Desconto = Convert.ToDecimal(nfe.NFe.infNFe.total.ICMSTot.vDesc, ci);
            entrada.FretePagoEmitente = nfe.NFe.infNFe.transp.modFrete == TNFeInfNFeTranspModFrete.Item0; // Frete pago emitente
            entrada.NumeroNotaFiscal = nfe.NFe.infNFe.ide.nNF;
            entrada.OutrasDespesas = Convert.ToDecimal(nfe.NFe.infNFe.total.ICMSTot.vOutro, ci);
            entrada.TotalBaseCalculo = Convert.ToDecimal(nfe.NFe.infNFe.total.ICMSTot.vBC, ci);
            entrada.TotalBaseSubstituicao = Convert.ToDecimal(nfe.NFe.infNFe.total.ICMSTot.vBCST, ci);
            entrada.TotalICMS = Convert.ToDecimal(nfe.NFe.infNFe.total.ICMSTot.vICMS, ci);
            entrada.TotalIPI = Convert.ToDecimal(nfe.NFe.infNFe.total.ICMSTot.vIPI, ci);
            entrada.TotalNota = Convert.ToDecimal(nfe.NFe.infNFe.total.ICMSTot.vNF, ci);
            entrada.TotalProdutos = Convert.ToDecimal(nfe.NFe.infNFe.total.ICMSTot.vProd, ci);
            entrada.Serie = nfe.NFe.infNFe.ide.serie;
            // precisa calcular
            entrada.TotalProdutosST = 0;
            foreach(TNFeInfNFeDet produto in nfe.NFe.infNFe.det) {
                for(int i = 0; i < produto.imposto.Items.Length; i++) {
                    if (produto.imposto.Items[i] is TNFeInfNFeDetImpostoICMS)
                    {
                        var icms = ((TNFeInfNFeDetImpostoICMS)produto.imposto.Items[i]).Item;
                        if ((icms is TNFeInfNFeDetImpostoICMSICMS10) || (icms is TNFeInfNFeDetImpostoICMSICMS30) ||
                            (icms is TNFeInfNFeDetImpostoICMSICMS60) || (icms is TNFeInfNFeDetImpostoICMSICMS70) ||
                            (icms is TNFeInfNFeDetImpostoICMSICMSSN202) || (icms is TNFeInfNFeDetImpostoICMSICMSSN500))  
                        {
                            entrada.TotalProdutosST += Convert.ToDecimal(produto.prod.vProd, ci);
                        }
                    }
                }
            }

            entrada.TotalSubstituicao = Convert.ToDecimal(nfe.NFe.infNFe.total.ICMSTot.vST, ci);
            entrada.ValorFrete = Convert.ToDecimal(nfe.NFe.infNFe.total.ICMSTot.vFrete, ci);
            entrada.ValorSeguro = Convert.ToDecimal(nfe.NFe.infNFe.total.ICMSTot.vSeg, ci);
        }

        private long ObterInserirEmpresaFrete(TNFe nfe)
        {
            if (nfe.infNFe.transp != null && nfe.infNFe.transp.transporta != null && !string.IsNullOrEmpty(nfe.infNFe.transp.transporta.Item))
            {
                Pessoa empresaFrete = GerenciadorPessoa.GetInstance().ObterPorCpfCnpj(nfe.infNFe.transp.transporta.Item).ElementAtOrDefault(0);
                if (empresaFrete == null)
                    empresaFrete = GerenciadorPessoa.GetInstance().ObterPorNome(nfe.infNFe.transp.transporta.xNome).ElementAtOrDefault(0);
                
                if (empresaFrete == null)
                {
                    empresaFrete = new Pessoa();
                    empresaFrete.CpfCnpj = nfe.infNFe.transp.transporta.Item;
                    empresaFrete.Nome = nfe.infNFe.transp.transporta.xNome.ToUpper();
                    empresaFrete.NomeFantasia = nfe.infNFe.transp.transporta.xNome.ToUpper();
                    empresaFrete.Ie = nfe.infNFe.transp.transporta.IE;
                    empresaFrete.Endereco = nfe.infNFe.transp.transporta.xEnder.ToUpper();
                    empresaFrete.Uf = nfe.infNFe.transp.transporta.UF.ToString().ToUpper();
                    empresaFrete.Cidade = nfe.infNFe.transp.transporta.xMun.ToUpper();

                    empresaFrete.CodMunicipioIBGE = GerenciadorMunicipio.GetInstance().ObterPorCidadeEstado(empresaFrete.Cidade, empresaFrete.Uf).Codigo;
                    empresaFrete.Tipo = empresaFrete.CpfCnpj.Length == 11 ? Pessoa.PESSOA_FISICA : Pessoa.PESSOA_JURIDICA;
                    return GerenciadorPessoa.GetInstance().Inserir(empresaFrete);
                }
                else
                {
                    return empresaFrete.CodPessoa;
                }
            }
            else
            {
                return 1;
            }
        }

        private long ObterInserirFornecedor(TNFe nfe)
        {
            if (nfe.infNFe.emit != null)
            {
                Pessoa fornecedor = GerenciadorPessoa.GetInstance().ObterPorCpfCnpj(nfe.infNFe.emit.Item).ElementAtOrDefault(0);
                if (fornecedor == null)
                   fornecedor = GerenciadorPessoa.GetInstance().ObterPorNome(nfe.infNFe.emit.xNome).ElementAtOrDefault(0);
                if (fornecedor == null)
                {
                    fornecedor = new Pessoa();
                    fornecedor.CpfCnpj = nfe.infNFe.emit.Item;
                    fornecedor.Nome = nfe.infNFe.emit.xNome.Length > 50 ? nfe.infNFe.emit.xNome.ToUpper().Substring(0, 50) : nfe.infNFe.emit.xNome.ToUpper();
                    if (nfe.infNFe.emit.xFant != null)
                        fornecedor.NomeFantasia = nfe.infNFe.emit.xFant.Length > 50 ? nfe.infNFe.emit.xFant.ToUpper().Substring(0, 50) : nfe.infNFe.emit.xFant.ToUpper();
                    else
                        fornecedor.NomeFantasia = fornecedor.Nome;
                    fornecedor.Ie = nfe.infNFe.emit.IE;
                    fornecedor.Endereco = nfe.infNFe.emit.enderEmit.xLgr.ToUpper();
                    fornecedor.Cep = nfe.infNFe.emit.enderEmit.CEP;
                    fornecedor.Cidade = nfe.infNFe.emit.enderEmit.xMun.ToUpper();
                    fornecedor.CodMunicipioIBGE = Convert.ToInt32(nfe.infNFe.emit.enderEmit.cMun);
                    fornecedor.Complemento = (nfe.infNFe.emit.enderEmit.xCpl != null) ? nfe.infNFe.emit.enderEmit.xCpl.ToUpper() : "";
                    if (string.IsNullOrEmpty(nfe.infNFe.emit.enderEmit.fone))
                        fornecedor.Fone1 = "";
                    else
                        fornecedor.Fone1 = nfe.infNFe.emit.enderEmit.fone.Length <= 12 ? nfe.infNFe.emit.enderEmit.fone : nfe.infNFe.emit.enderEmit.fone.Substring(0, 12);
                    fornecedor.Bairro = nfe.infNFe.emit.enderEmit.xBairro.ToUpper();
                    fornecedor.Ie = nfe.infNFe.emit.IE;
                    if (nfe.infNFe.emit.IEST != null)
                        fornecedor.IeSubstituto = nfe.infNFe.emit.IEST;
                    fornecedor.Numero = nfe.infNFe.emit.enderEmit.nro.Length > 10 ? nfe.infNFe.emit.enderEmit.nro.Substring(0, 10):nfe.infNFe.emit.enderEmit.nro;
                    fornecedor.Uf = nfe.infNFe.emit.enderEmit.UF.ToString();
                    fornecedor.Tipo = fornecedor.CpfCnpj.Length == 11 ? Pessoa.PESSOA_FISICA : Pessoa.PESSOA_JURIDICA;
                    return GerenciadorPessoa.GetInstance().Inserir(fornecedor);
                }
                else
                {
                    fornecedor.CpfCnpj = nfe.infNFe.emit.Item;
                    fornecedor.Nome = nfe.infNFe.emit.xNome.Length > 50 ? nfe.infNFe.emit.xNome.ToUpper().Substring(0, 50) : nfe.infNFe.emit.xNome.ToUpper();
                    fornecedor.Ie = nfe.infNFe.emit.IE;
                    fornecedor.Endereco = nfe.infNFe.emit.enderEmit.xLgr.ToUpper();
                    fornecedor.Cep = nfe.infNFe.emit.enderEmit.CEP;
                    fornecedor.Cidade = nfe.infNFe.emit.enderEmit.xMun.ToUpper();
                    fornecedor.CodMunicipioIBGE = Convert.ToInt32(nfe.infNFe.emit.enderEmit.cMun);
                    fornecedor.Complemento = (nfe.infNFe.emit.enderEmit.xCpl != null) ? nfe.infNFe.emit.enderEmit.xCpl.ToUpper() : "";
                    if (string.IsNullOrEmpty(nfe.infNFe.emit.enderEmit.fone))
                        fornecedor.Fone1 = "";
                    else
                        fornecedor.Fone1 = nfe.infNFe.emit.enderEmit.fone.Length <= 12 ? nfe.infNFe.emit.enderEmit.fone : nfe.infNFe.emit.enderEmit.fone.Substring(0, 12);
                    fornecedor.Bairro = nfe.infNFe.emit.enderEmit.xBairro.ToUpper();
                    fornecedor.Ie = nfe.infNFe.emit.IE;
                    fornecedor.IeSubstituto = nfe.infNFe.emit.IEST;
                    fornecedor.Numero = nfe.infNFe.emit.enderEmit.nro.Length > 10 ? nfe.infNFe.emit.enderEmit.nro.Substring(0, 10) : nfe.infNFe.emit.enderEmit.nro;
                    fornecedor.Uf = nfe.infNFe.emit.enderEmit.UF.ToString();
                    fornecedor.Tipo = fornecedor.CpfCnpj.Length == 11 ? Pessoa.PESSOA_FISICA : Pessoa.PESSOA_JURIDICA;
                    GerenciadorPessoa.GetInstance().Atualizar(fornecedor);
                    return fornecedor.CodPessoa;
                }
            }
            else
            {
                return 1; // quando por algum motivo não conseguir recuperar o fornecedor
            }
        }

        /// <summary>
        /// Atualizar dados da entrada
        /// </summary>
        /// <param name="entrada"></param>
        public void Atualizar(Entrada entrada)
        {
            if ((entrada.TotalBaseSubstituicao > 0) && (entrada.TotalProdutosST <= 0))
                throw new NegocioException("Quando a entrada possui valor de substituição tributária é necessário informar o valor Total dos Produtos Substituição Tributária");
            else if (entrada.TotalProdutos > (entrada.TotalNota+entrada.Desconto))
            {
                throw new NegocioException("O valor Total dos Produtos não pode ser maior que o valor total da Nota.");
            }
            else if (entrada.TotalProdutosST > entrada.TotalProdutos)
            {
                throw new NegocioException("O valor Total dos Protudos ST não pode ser maior que o valor Total dos Produtos.");
            }
            var repEntrada = new RepositorioGenerico<EntradaE>();
            Atualizar(entrada, (SaceEntities) repEntrada.ObterContexto());
        }

        /// <summary>
        /// Atualizar dados da entrada
        /// </summary>
        /// <param name="entrada"></param>
        public void Atualizar(Entrada entrada, SaceEntities saceContext)
        {
            try
            {
                if ((entrada.TotalBaseSubstituicao > 0) && (entrada.TotalProdutosST <= 0))
                    throw new NegocioException("Quando a entrada possui valor de substituição tributária é necessário informar o valor Total dos Produtos Substituição Tributária");
                
                var query = from entradaSet in saceContext.EntradaSet
                            where entradaSet.codEntrada == entrada.CodEntrada
                            select entradaSet;
                EntradaE _entradaE = query.ToList().ElementAtOrDefault(0);    
                Atribuir(entrada, _entradaE);
                saceContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DadosException("Entrada", e.Message, e);
            }
        }

        /// <summary>
        /// REmover uma entrada
        /// </summary>
        /// <param name="codEntrada"></param>
        public void Remover(long codEntrada)
        {
            try
            {
                var repEntrada = new RepositorioGenerico<EntradaE>();

                repEntrada.Remover(e => e.codEntrada == codEntrada);
                repEntrada.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DadosException("Entrada", e.Message, e);
            }
        }

        /// <summary>
        /// Encerra o cadastramento da entrada lançando todas as contas a pagar
        /// </summary>
        /// <param name="entrada"></param>
        public void Encerrar(Entrada entrada)
        {
            var repEntrada = new RepositorioGenerico<EntradaE>();
            SaceEntities saceContext = (SaceEntities) repEntrada.ObterContexto();
            DbTransaction transaction = null;
            try
            {
                if (saceContext.Connection.State == System.Data.ConnectionState.Closed)
                    saceContext.Connection.Open();
                transaction = saceContext.Connection.BeginTransaction();
                if (GerenciadorConta.GetInstance(saceContext).ObterPorEntrada(entrada.CodEntrada).ToList().Count == 0)
                {
                    List<EntradaPagamento> entradaPagamentos = (List<EntradaPagamento>)GerenciadorEntradaPagamento.GetInstance().ObterPorEntrada(entrada.CodEntrada);
                    RegistrarPagamentosEntrada(entradaPagamentos, entrada, saceContext);
                }
                else
                {
                    throw new NegocioException("Existem contas associadas a essa entrada. Ela não pode ser encerrada novamente.");
                }
                entrada.CodSituacaoPagamentos = SituacaoPagamentos.LANCADOS;
                Atualizar(entrada, saceContext);
                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw e;
            }
            finally
            {
                saceContext.Connection.Close();
            }
        }

        /// <summary>
        /// REgistra os pagamentos associando para cada um dele uma conta a pagar
        /// </summary>
        /// <param name="pagamentos"></param>
        /// <param name="entrada"></param>
        private void RegistrarPagamentosEntrada(List<EntradaPagamento> pagamentos, Entrada entrada, SaceEntities saceContext)
        {

            foreach (EntradaPagamento pagamento in pagamentos)
            {
                // Para cada pagamento é criada uma nova conta
                Conta conta = new Conta();
                if (pagamento.PagamentoDoFrete)
                    conta.CodPessoa = entrada.CodEmpresaFrete;
                else
                    conta.CodPessoa = entrada.CodFornecedor;

                conta.CodPlanoConta = PlanoConta.ENTRADA_PRODUTOS;
                conta.CodEntrada = entrada.CodEntrada;
                conta.CodSaida = Global.SAIDA_PADRAO; // saída não válida
                conta.CodPagamento = pagamento.CodEntradaFormaPagamento;
                conta.Desconto = 0;
                
                // Quando o pagamento é realizado em dinheiro a conta já é inserido quitada
                if (pagamento.CodFormaPagamento == FormaPagamento.DINHEIRO)
                    conta.CodSituacao = SituacaoConta.SITUACAO_QUITADA.ToString();
                else
                    conta.CodSituacao = SituacaoConta.SITUACAO_ABERTA.ToString();

                conta.TipoConta = Conta.CONTA_PAGAR.ToString();

                
                conta.Valor = pagamento.Valor;

                if (pagamento.CodFormaPagamento == FormaPagamento.BOLETO) 
                {
                    conta.FormatoConta = Conta.FORMATO_CONTA_BOLETO;
                } else {
                    conta.FormatoConta = Conta.FORMATO_CONTA_FICHA;
                }
                conta.DataVencimento = pagamento.Data;
            
                conta.CodConta = GerenciadorConta.GetInstance(saceContext).Inserir(conta);
                
                if (pagamento.CodFormaPagamento == FormaPagamento.DINHEIRO)
                {
                    MovimentacaoConta movimentacao = new MovimentacaoConta();
                    movimentacao.CodContaBanco = pagamento.CodContaBanco;
                    movimentacao.CodConta = conta.CodConta;
                    movimentacao.CodResponsavel = GerenciadorLoja.GetInstance().Obter(Global.LOJA_PADRAO).ElementAt(0).CodPessoa;

                    movimentacao.CodTipoMovimentacao = MovimentacaoConta.PAGAMENTO_FORNECEDOR;
                    movimentacao.DataHora = DateTime.Now;
                    movimentacao.Valor = pagamento.Valor;

                    GerenciadorMovimentacaoConta.GetInstance(saceContext).Inserir(movimentacao);
                }
            }
        }

        /// <summary>
        /// Consulta para retornar dados da entidade
        /// </summary>
        /// <returns></returns>
        private IQueryable<Entrada> GetQuery()
        {
            var repEntrada = new RepositorioGenerico<EntradaE>();

            var saceEntities = (SaceEntities)repEntrada.ObterContexto();
            var query = from entrada in saceEntities.EntradaSet
                        join fornecedor in saceEntities.PessoaSet on entrada.codFornecedor equals fornecedor.codPessoa
                        join transportadora in saceEntities.PessoaSet on entrada.codEmpresaFrete equals transportadora.codPessoa
                        select new Entrada
                        {
                            CodEmpresaFrete = entrada.codEmpresaFrete,
                            CodEntrada = entrada.codEntrada,
                            CodFornecedor = entrada.codFornecedor,
                            CodSituacaoPagamentos = entrada.codSituacaoPagamentos,
                            CodTipoEntrada = entrada.codTipoEntrada,
                            DataEmissao = (DateTime) entrada.dataEmissao,
                            DataEntrada = (DateTime) entrada.dataEntrada,
                            Desconto = (decimal) entrada.desconto,
                            FretePagoEmitente = entrada.fretePagoEmitente,
                            NomeEmpresaFrete = transportadora.nome,
                            NomeFornecedor = fornecedor.nome,
                            Cpf_CnpjFornecedor = fornecedor.cpf_Cnpj,
                            FornecedorEhFabricante = fornecedor.ehFabricante,
                            NumeroNotaFiscal = entrada.numeroNotaFiscal,
                            OutrasDespesas = (decimal) entrada.outrasDespesas,
                            TotalBaseCalculo = (decimal) entrada.totalBaseCalculo,
                            TotalBaseSubstituicao = (decimal) entrada.totalBaseSubstituicao,
                            TotalICMS = (decimal) entrada.totalICMS,
                            TotalIPI = (decimal) entrada.totalIPI,
                            TotalNota = (decimal) entrada.totalNota,
                            TotalProdutos = (decimal) entrada.totalProdutos,
                            TotalProdutosST = (decimal) entrada.totalProdutosST,
                            TotalSubstituicao = (decimal) entrada.totalSubstituicao,
                            ValorFrete = (decimal) entrada.valorFrete,
                            ValorSeguro = (decimal) entrada.valorSeguro,
                            Serie = entrada.serie
                        };
            return query;
        }

        /// <summary>
        /// Obtém todos os banco cadastrados
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Entrada> ObterTodos()
        {
            return GetQuery().ToList();
        }

        /// <summary>
        /// Obtém banco com o código especificiado
        /// </summary>
        /// <param name="codBanco"></param>
        /// <returns></returns>
        public IEnumerable<Entrada> Obter(long codEntrada)
        {
            return GetQuery().Where(entrada => entrada.CodEntrada == codEntrada).ToList();
        }

        /// <summary>
        /// Obtém banco com o código especificiado
        /// </summary>
        /// <param name="codBanco"></param>
        /// <returns></returns>
        public IEnumerable<Entrada> ObterPorTipoEntrada(int codTipoEntrada)
        {
            return GetQuery().Where(entrada => entrada.CodTipoEntrada == codTipoEntrada).ToList();
        }

        /// <summary>
        /// Obtém entradas pelo número da nota fiscal
        /// </summary>
        /// <param name="codBanco"></param>
        /// <returns></returns>
        public IEnumerable<Entrada> ObterPorNumeroNotaFiscal(string numeroNotaFiscal)
        {
            return GetQuery().Where(entrada => entrada.NumeroNotaFiscal.StartsWith(numeroNotaFiscal)).ToList();
        }

        /// <summary>
        /// Obtém entradas pelo número da nota fiscal e Fornecedor
        /// </summary>
        /// <param name="codBanco"></param>
        /// <returns></returns>
        public IEnumerable<Entrada> ObterPorNumeroNotaFiscalFornecedor(string numeroNotaFiscal, string cpf_CnpjFornecedor)
        {
            return GetQuery().Where(entrada => entrada.NumeroNotaFiscal.Equals(numeroNotaFiscal) && entrada.Cpf_CnpjFornecedor.Equals(cpf_CnpjFornecedor)).ToList();
        }

        /// <summary>
        /// Obtém entradas pelo nome do fornecedor
        /// </summary>
        /// <param name="codBanco"></param>
        /// <returns></returns>
        public IEnumerable<Entrada> ObterPorNomeFornecedor(string nomeFornecedor)
        {
            return GetQuery().Where(entrada => entrada.NomeFornecedor.StartsWith(nomeFornecedor)).ToList();
        }
        
        
        /// <summary>
        /// Obtém situacoes Pagamentos
        /// </summary>
        /// <param name="codBanco"></param>
        /// <returns></returns>
        public IEnumerable<SituacaoPagamentos> ObterTodosSituacoesPagamentos()
        {
            var repEntrada = new RepositorioGenerico<EntradaE>();

            var saceEntities = (SaceEntities)repEntrada.ObterContexto();
            var query = from situacaoPagamentos in saceEntities.SituacaoPagamentosSet
                        select new SituacaoPagamentos
                        {
                            CodSituacaoPagamentos = situacaoPagamentos.codSituacaoPagamentos,
                            DescricaoSituacaoPagamentos = situacaoPagamentos.descricaoSituacaoPagamentos
                        };
            return query.ToList();
        }


        /// <summary>
        /// Atribui os dados da entidade para entidade persistente
        /// </summary>
        /// <param name="entrada"></param>
        /// <param name="_entradaE"></param>
        private static void Atribuir(Entrada entrada, EntradaE _entradaE)
        {
            _entradaE.codEmpresaFrete = entrada.CodEmpresaFrete;
            _entradaE.codFornecedor = entrada.CodFornecedor;
            _entradaE.codSituacaoPagamentos = entrada.CodSituacaoPagamentos;
            _entradaE.codTipoEntrada = entrada.CodTipoEntrada;
            _entradaE.dataEmissao = entrada.DataEmissao;
            _entradaE.dataEntrada = entrada.DataEntrada;
            _entradaE.desconto = entrada.Desconto;
            _entradaE.fretePagoEmitente = entrada.FretePagoEmitente;
            _entradaE.numeroNotaFiscal = entrada.NumeroNotaFiscal;
            _entradaE.outrasDespesas = entrada.OutrasDespesas;
            _entradaE.totalBaseCalculo = entrada.TotalBaseCalculo;
            _entradaE.totalBaseSubstituicao = entrada.TotalBaseSubstituicao;
            _entradaE.totalICMS = entrada.TotalICMS;
            _entradaE.totalIPI = entrada.TotalIPI;
            _entradaE.totalNota = entrada.TotalNota;
            _entradaE.totalProdutos = entrada.TotalProdutos;
            _entradaE.totalProdutosST = entrada.TotalProdutosST;
            _entradaE.totalSubstituicao = entrada.TotalSubstituicao;
            _entradaE.valorFrete = entrada.ValorFrete;
            _entradaE.valorSeguro = entrada.ValorSeguro;
            _entradaE.serie = entrada.Serie;
        }

    }
}