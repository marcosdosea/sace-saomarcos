using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using Util;

namespace Negocio
{
    public static class GerenciadorEntrada
    {
        /// <summary>
        /// Inserir uma nova entrada
        /// </summary>
        /// <param name="entrada"></param>
        /// <returns></returns>
        public static long Inserir(Entrada entrada)
        {
            try
            {
                if ((entrada.TotalBaseSubstituicao > 0) && (entrada.TotalProdutosST <= 0))
                    throw new NegocioException("Quando a entrada possui valor de substituição tributária é necessário informar o valor Total dos Produtos Substituição Tributária");
                else if ((entrada.TotalProdutos - entrada.Desconto) > entrada.TotalNota)
                {
                    throw new NegocioException("O valor Total dos Produtos não pode ser maior que o valor total da Nota menos o desconto.");
                }

                //margem de erro de 0.05 centavos por conta de problemas de distribuição de valores  
                else if ((entrada.TotalProdutosST) > (entrada.TotalProdutos + new Decimal(0.05)))
                {
                    throw new NegocioException("O valor Total dos Protudos ST não pode ser maior que o valor Total dos Produtos.");
                }

                using (var context = new SaceContext())
                {
                    TbEntradum _entrada = new TbEntradum();
                    Atribuir(entrada, _entrada);

                    context.Add(_entrada);
                    context.SaveChanges();

                    return _entrada.CodEntrada;
                }
            }
            catch (Exception e)
            {
                throw new DadosException("Entrada", e.Message, e);
            }
        }

        public static long Importar(TNfeProc nfe)
        {
            using (var context = new SaceContext())
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
                        Atualizar(entrada);
                        return entrada.CodEntrada;
                    }
                    else
                    {
                        Entrada entrada = new Entrada();
                        RecuperarDadosEntrada(nfe, entrada);
                        long codEntrada = Inserir(entrada);
                        return codEntrada;
                    }
                }
                catch (Exception e)
                {
                    throw new NegocioException("Problema durante a importação dos dados da Entrada da NF-e. Favor contactar administrador.", e);
                }
            }
        }

        private static void RecuperarDadosEntrada(TNfeProc nfe, Entrada entrada)
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
            entrada.Chave = nfe.NFe.infNFe.Id.Substring(3); // retira o inicio nfe            // precisa calcular
            entrada.TotalProdutosST = 0;
            foreach (TNFeInfNFeDet produto in nfe.NFe.infNFe.det)
            {
                for (int i = 0; i < produto.imposto.Items.Length; i++)
                {
                    if (produto.imposto.Items[i] is TNFeInfNFeDetImpostoICMS)
                    {
                        var icms = ((TNFeInfNFeDetImpostoICMS)produto.imposto.Items[i]).Item;
                        if ((icms is TNFeInfNFeDetImpostoICMSICMS10) || (icms is TNFeInfNFeDetImpostoICMSICMS30) ||
                            (icms is TNFeInfNFeDetImpostoICMSICMS60) || (icms is TNFeInfNFeDetImpostoICMSICMS70) ||
                            (icms is TNFeInfNFeDetImpostoICMSICMSSN202) || (icms is TNFeInfNFeDetImpostoICMSICMSSN201) ||
                            (icms is TNFeInfNFeDetImpostoICMSICMSSN500))
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

        private static long ObterInserirEmpresaFrete(TNFe nfe)
        {
            if (nfe.infNFe.transp != null && nfe.infNFe.transp.transporta != null && !string.IsNullOrEmpty(nfe.infNFe.transp.transporta.Item))
            {
                Pessoa empresaFrete = GerenciadorPessoa.ObterPorCpfCnpj(nfe.infNFe.transp.transporta.Item).ElementAtOrDefault(0);
                if (empresaFrete == null)
                    empresaFrete = GerenciadorPessoa.ObterPorNome(nfe.infNFe.transp.transporta.xNome).ElementAtOrDefault(0);

                if (empresaFrete == null)
                {
                    empresaFrete = new Pessoa();
                    empresaFrete.CpfCnpj = nfe.infNFe.transp.transporta.Item;
                    empresaFrete.Nome = (nfe.infNFe.transp.transporta.xNome.Length > 50) ? nfe.infNFe.transp.transporta.xNome.Substring(0, 50).ToUpper() : nfe.infNFe.transp.transporta.xNome.ToUpper();
                    empresaFrete.NomeFantasia = (nfe.infNFe.transp.transporta.xNome.Length > 50) ? nfe.infNFe.transp.transporta.xNome.Substring(0, 50).ToUpper() : nfe.infNFe.transp.transporta.xNome.ToUpper();
                    empresaFrete.Ie = nfe.infNFe.transp.transporta.IE;
                    if (nfe.infNFe.transp.transporta.xEnder != null)
                        empresaFrete.Endereco = nfe.infNFe.transp.transporta.xEnder.ToUpper();
                    if (nfe.infNFe.transp.transporta.UF != null)
                        empresaFrete.Uf = nfe.infNFe.transp.transporta.UF.ToString().ToUpper();
                    if (nfe.infNFe.transp.transporta.xMun != null)
                        empresaFrete.Cidade = nfe.infNFe.transp.transporta.xMun.ToUpper();

                    empresaFrete.CodMunicipioIBGE = GerenciadorMunicipio.ObterPorCidadeEstado(empresaFrete.Cidade, empresaFrete.Uf).Codigo;
                    empresaFrete.Tipo = empresaFrete.CpfCnpj.Length == 11 ? Pessoa.PESSOA_FISICA : Pessoa.PESSOA_JURIDICA;
                    return GerenciadorPessoa.Inserir(empresaFrete);
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

        private static long ObterInserirFornecedor(TNFe nfe)
        {
            if (nfe.infNFe.emit != null)
            {
                Pessoa fornecedor = GerenciadorPessoa.ObterPorCpfCnpj(nfe.infNFe.emit.Item).ElementAtOrDefault(0);
                if (fornecedor == null)
                {
                    if (nfe.infNFe.emit.xNome.Length > 50)
                        fornecedor = GerenciadorPessoa.ObterPorNome(nfe.infNFe.emit.xNome.ToUpper().Substring(0, 50)).ElementAtOrDefault(0);
                    else
                        fornecedor = GerenciadorPessoa.ObterPorNome(nfe.infNFe.emit.xNome.ToUpper()).ElementAtOrDefault(0);
                }
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
                    fornecedor.Numero = nfe.infNFe.emit.enderEmit.nro.Length > 10 ? nfe.infNFe.emit.enderEmit.nro.Substring(0, 10) : nfe.infNFe.emit.enderEmit.nro;
                    fornecedor.Uf = nfe.infNFe.emit.enderEmit.UF.ToString();
                    fornecedor.Tipo = fornecedor.CpfCnpj.Length == 11 ? Pessoa.PESSOA_FISICA : Pessoa.PESSOA_JURIDICA;
                    return GerenciadorPessoa.Inserir(fornecedor);
                }
                else
                {
                    if (fornecedor.CpfCnpj.Equals(nfe.infNFe.emit.Item))
                    {
                        fornecedor.CpfCnpj = nfe.infNFe.emit.Item;
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
                        GerenciadorPessoa.Atualizar(fornecedor);
                        return fornecedor.CodPessoa;
                    }
                    else
                    {
                        // fornecedor com mesmo nome mas com cnpjs distintos.
                        fornecedor = new Pessoa();
                        fornecedor.CpfCnpj = nfe.infNFe.emit.Item;
                        fornecedor.Nome = nfe.infNFe.emit.xNome.Length > 36 ? nfe.infNFe.emit.xNome.ToUpper().Substring(0, 36) + nfe.infNFe.emit.Item : nfe.infNFe.emit.xNome.ToUpper() + nfe.infNFe.emit.Item;
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
                        fornecedor.Numero = nfe.infNFe.emit.enderEmit.nro.Length > 10 ? nfe.infNFe.emit.enderEmit.nro.Substring(0, 10) : nfe.infNFe.emit.enderEmit.nro;
                        fornecedor.Uf = nfe.infNFe.emit.enderEmit.UF.ToString();
                        fornecedor.Tipo = fornecedor.CpfCnpj.Length == 11 ? Pessoa.PESSOA_FISICA : Pessoa.PESSOA_JURIDICA;
                        return GerenciadorPessoa.Inserir(fornecedor);

                    }
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
        public static void Atualizar(Entrada entrada)
        {
            if ((entrada.TotalBaseSubstituicao > 0) && (entrada.TotalProdutosST <= 0))
                throw new NegocioException("Quando a entrada possui valor de substituição tributária é necessário informar o valor Total dos Produtos Substituição Tributária");
            else if (entrada.TotalProdutos > (entrada.TotalNota + entrada.Desconto))
            {
                throw new NegocioException("O valor Total dos Produtos não pode ser maior que o valor total da Nota.");
            }
            else if (entrada.TotalProdutosST > entrada.TotalProdutos)
            {
                throw new NegocioException("O valor Total dos Protudos ST não pode ser maior que o valor Total dos Produtos.");
            }
            using (var context = new SaceContext())
            {
                var _entrada = context.TbEntrada.FirstOrDefault(e => e.CodEntrada == entrada.CodEntrada);
                Atribuir(entrada, _entrada);

                context.Update(_entrada);
                context.SaveChanges();
            }
        }

        

        /// <summary>
        /// REmover uma entrada
        /// </summary>
        /// <param name="codEntrada"></param>
        public static void Remover(long codEntrada)
        {
            try
            {
                using (var context = new SaceContext())
                {
                    var entrada = context.TbEntrada.FirstOrDefault(e => e.CodEntrada == codEntrada);
                    if (entrada != null)
                    {
                        context.Remove(entrada);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new NegocioException("Entrada não encontrada para exclusão.");
                    }
                }
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
        public static void Encerrar(Entrada entrada)
        {
            using (var context = new SaceContext())
            {
                var transaction = context.Database.BeginTransaction();
                try
                {
                    if (context.TbConta.Where(conta => conta.CodEntrada == entrada.CodEntrada).Count() == 0)
                    {
                        var entradaPagamentos = context.TbEntradaFormaPagamentos.Where(pagamento => pagamento.CodEntrada == entrada.CodEntrada).ToList();
                        RegistrarPagamentosEntrada(entradaPagamentos, entrada, context);
                    }
                    else
                    {
                        throw new NegocioException("Existem contas associadas a essa entrada. Ela não pode ser encerrada novamente.");
                    }
                    entrada.CodSituacaoPagamentos = SituacaoPagamentos.LANCADOS;
                    Atualizar(entrada);
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw e;
                }
            }
        }

        /// <summary>
        /// REgistra os pagamentos associando para cada um dele uma conta a pagar
        /// </summary>
        /// <param name="pagamentos"></param>
        /// <param name="entrada"></param>
        private static void RegistrarPagamentosEntrada(List<TbEntradaFormaPagamento> pagamentos, Entrada entrada, SaceContext context)
        {
            foreach (TbEntradaFormaPagamento pagamento in pagamentos)
            {
                // Para cada pagamento é criada uma nova conta
                Conta conta = new Conta();
                if (pagamento.PagamentoDoFrete == true)
                    conta.CodPessoa = entrada.CodEmpresaFrete;
                else
                    conta.CodPessoa = entrada.CodFornecedor;

                conta.CodPlanoConta = PlanoConta.ENTRADA_PRODUTOS;
                conta.CodEntrada = entrada.CodEntrada;
                conta.CodSaida = UtilConfig.Default.SAIDA_PADRAO; // saída não válida
                conta.CodPagamento = pagamento.CodEntradaFormaPagamento;
                conta.Desconto = 0;

                // Quando o pagamento é realizado em dinheiro a conta já é inserido quitada
                if (pagamento.CodFormaPagamento == FormaPagamento.DINHEIRO)
                    conta.CodSituacao = SituacaoConta.SITUACAO_QUITADA.ToString();
                else
                    conta.CodSituacao = SituacaoConta.SITUACAO_ABERTA.ToString();

                conta.TipoConta = Conta.CONTA_PAGAR.ToString();


                conta.Valor = (decimal) pagamento.Valor;

                if (pagamento.CodFormaPagamento == FormaPagamento.BOLETO)
                {
                    conta.FormatoConta = Conta.FORMATO_CONTA_BOLETO;
                }
                else
                {
                    conta.FormatoConta = Conta.FORMATO_CONTA_FICHA;
                }
                conta.DataVencimento = (DateTime) pagamento.Data;

                conta.CodConta = GerenciadorConta.Inserir(conta, context);

                if (pagamento.CodFormaPagamento == FormaPagamento.DINHEIRO)
                {
                    MovimentacaoConta movimentacao = new MovimentacaoConta();
                    movimentacao.CodContaBanco = pagamento.CodContaBanco;
                    movimentacao.CodConta = conta.CodConta;
                    movimentacao.CodResponsavel = GerenciadorLoja.Obter(UtilConfig.Default.LOJA_PADRAO).First().CodPessoa;

                    movimentacao.CodTipoMovimentacao = MovimentacaoConta.PAGAMENTO_FORNECEDOR;
                    movimentacao.DataHora = DateTime.Now;
                    movimentacao.Valor = (decimal) pagamento.Valor;

                    GerenciadorMovimentacaoConta.Inserir(movimentacao, context);
                }

            }
        }

        /// <summary>
        /// Consulta para retornar dados da entidade
        /// </summary>
        /// <returns></returns>
        private static IQueryable<Entrada> GetQuery()
        {
            using (var context = new SaceContext())
            {
                var query = from entrada in context.TbEntrada
                            select new Entrada
                            {
                                CodEmpresaFrete = entrada.CodEmpresaFrete,
                                CodEntrada = entrada.CodEntrada,
                                CodFornecedor = entrada.CodFornecedor,
                                CodSituacaoPagamentos = entrada.CodSituacaoPagamentos,
                                CodTipoEntrada = entrada.CodTipoEntrada,
                                DataEmissao = (DateTime)entrada.DataEmissao,
                                DataEntrada = (DateTime)entrada.DataEntrada,
                                Desconto = (decimal)entrada.Desconto,
                                FretePagoEmitente = entrada.FretePagoEmitente,
                                NomeEmpresaFrete = entrada.CodEmpresaFreteNavigation.Nome,
                                NomeFornecedor = entrada.CodFornecedorNavigation.Nome,
                                Cpf_CnpjFornecedor = entrada.CodFornecedorNavigation.CpfCnpj,
                                FornecedorEhFabricante = entrada.CodFornecedorNavigation.EhFabricante,
                                NumeroNotaFiscal = entrada.NumeroNotaFiscal,
                                OutrasDespesas = (decimal)entrada.OutrasDespesas,
                                TotalBaseCalculo = (decimal)entrada.TotalBaseCalculo,
                                TotalBaseSubstituicao = (decimal)entrada.TotalBaseSubstituicao,
                                TotalICMS = (decimal)entrada.TotalIcms,
                                TotalIPI = (decimal)entrada.TotalIpi,
                                TotalNota = (decimal)entrada.TotalNota,
                                TotalProdutos = (decimal)entrada.TotalProdutos,
                                TotalProdutosST = (decimal)entrada.TotalProdutosSt,
                                TotalSubstituicao = (decimal)entrada.TotalSubstituicao,
                                ValorFrete = (decimal)entrada.ValorFrete,
                                ValorSeguro = (decimal)entrada.ValorSeguro,
                                Serie = entrada.Serie,
                                Chave = entrada.Chave
                            };
                return query.AsNoTracking();
            }
        }

        /// <summary>
        /// Obtém todos os banco cadastrados
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Entrada> ObterTodos()
        {
            return GetQuery().ToList();
        }

        /// <summary>
        /// Obtém banco com o código especificiado
        /// </summary>
        /// <param name="codBanco"></param>
        /// <returns></returns>
        public static IEnumerable<Entrada> Obter(long codEntrada)
        {
            return GetQuery().Where(entrada => entrada.CodEntrada == codEntrada).ToList();
        }

        /// <summary>
        /// Obtém banco com o código especificiado
        /// </summary>
        /// <param name="codBanco"></param>
        /// <returns></returns>
        public static IEnumerable<Entrada> ObterPorTipoEntrada(int codTipoEntrada)
        {
            return GetQuery().Where(entrada => entrada.CodTipoEntrada == codTipoEntrada).ToList();
        }

        /// <summary>
        /// Obtém entradas pelo número da nota fiscal
        /// </summary>
        /// <param name="codBanco"></param>
        /// <returns></returns>
        public static IEnumerable<Entrada> ObterPorNumeroNotaFiscal(string numeroNotaFiscal)
        {
            return GetQuery().Where(entrada => entrada.NumeroNotaFiscal.StartsWith(numeroNotaFiscal)).ToList();
        }

        /// <summary>
        /// Obtém entradas pelo número da nota fiscal e Fornecedor
        /// </summary>
        /// <param name="codBanco"></param>
        /// <returns></returns>
        public static IEnumerable<Entrada> ObterPorNumeroNotaFiscalFornecedor(string numeroNotaFiscal, string cpf_CnpjFornecedor)
        {
            return GetQuery().Where(entrada => entrada.NumeroNotaFiscal.Equals(numeroNotaFiscal) && entrada.Cpf_CnpjFornecedor.Equals(cpf_CnpjFornecedor)).ToList();
        }

        /// <summary>
        /// Obtém entradas pelo nome do fornecedor
        /// </summary>
        /// <param name="codBanco"></param>
        /// <returns></returns>
        public static IEnumerable<Entrada> ObterPorNomeFornecedor(string nomeFornecedor)
        {
            return GetQuery().Where(entrada => entrada.NomeFornecedor.StartsWith(nomeFornecedor)).ToList();
        }


        /// <summary>
        /// Obtém situacoes Pagamentos
        /// </summary>
        /// <param name="codBanco"></param>
        /// <returns></returns>
        public static IEnumerable<SituacaoPagamentos> ObterTodosSituacoesPagamentos()
        {
            using (var context = new SaceContext())
            {
                var query = from situacaoPagamentos in context.TbSituacaoPagamentos
                            select new SituacaoPagamentos
                            {
                                CodSituacaoPagamentos = situacaoPagamentos.CodSituacaoPagamentos,
                                DescricaoSituacaoPagamentos = situacaoPagamentos.DescricaoSituacaoPagamentos
                            };
                return query.ToList();
            }
        }


        /// <summary>
        /// Atribui os dados da entidade para entidade persistente
        /// </summary>
        /// <param name="entrada"></param>
        /// <param name="_entrada"></param>
        private static void Atribuir(Entrada entrada, TbEntradum _entrada)
        {
            _entrada.CodEmpresaFrete = entrada.CodEmpresaFrete;
            _entrada.CodFornecedor = entrada.CodFornecedor;
            _entrada.CodSituacaoPagamentos = entrada.CodSituacaoPagamentos;
            _entrada.CodTipoEntrada = entrada.CodTipoEntrada;
            _entrada.DataEmissao = entrada.DataEmissao;
            _entrada.DataEntrada = entrada.DataEntrada;
            _entrada.Desconto = entrada.Desconto;
            _entrada.FretePagoEmitente = entrada.FretePagoEmitente;
            _entrada.NumeroNotaFiscal = entrada.NumeroNotaFiscal;
            _entrada.OutrasDespesas = entrada.OutrasDespesas;
            _entrada.TotalBaseCalculo = entrada.TotalBaseCalculo;
            _entrada.TotalBaseSubstituicao = entrada.TotalBaseSubstituicao;
            _entrada.TotalIcms = entrada.TotalICMS;
            _entrada.TotalIpi = entrada.TotalIPI;
            _entrada.TotalNota = entrada.TotalNota;
            _entrada.TotalProdutos = entrada.TotalProdutos;
            _entrada.TotalProdutosSt = entrada.TotalProdutosST;
            _entrada.TotalSubstituicao = entrada.TotalSubstituicao;
            _entrada.ValorFrete = entrada.ValorFrete;
            _entrada.ValorSeguro = entrada.ValorSeguro;
            _entrada.Serie = entrada.Serie;
            _entrada.Chave = entrada.Chave != null ? entrada.Chave : "";
        }
    }
}