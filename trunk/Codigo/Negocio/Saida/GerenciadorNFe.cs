using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dados;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using Dominio;
using Util;
using System.Diagnostics;
using System.Threading;
using System.Globalization;
using System.Data.Objects.DataClasses;

namespace Negocio
{
    public class GerenciadorNFe
    {
        private static GerenciadorNFe gNFe;

        public static GerenciadorNFe GetInstance()
        {
            if (gNFe == null)
            {
                gNFe = new GerenciadorNFe();
            }

            return gNFe;
        }

        /// <summary>
        /// Insere os dados de uma conta bancária
        /// </summary>
        /// <param name="contaBanco"></param>
        /// <returns></returns>
        public int Inserir(NfeControle nfe, Saida saida)
        {
            try
            {
                var repNfe = new RepositorioGenerico<NfeE>();
                var repSaida = new RepositorioGenerico<SaidaE>(repNfe.ObterContexto());

                NfeE _nfeE = new NfeE();
                Atribuir(nfe, _nfeE);

                repNfe.Inserir(_nfeE);
                

                IEnumerable<SaidaE> saidas;
                if (string.IsNullOrEmpty(saida.CupomFiscal))
                {
                     saidas = repSaida.Obter(s => s.codSaida == saida.CodSaida);
                }
                else
                {
                    saidas = repSaida.Obter(s => s.pedidoGerado == saida.CupomFiscal);
                }
                foreach (SaidaE _saidaE in saidas)
                {
                    _nfeE.tb_saida.Add(_saidaE);
                }
                
                repNfe.SaveChanges();

                return _nfeE.codNFe;
            }
            catch (Exception e)
            {
                throw new DadosException("Nota Fiscal Eletrônica", e.Message, e);
            }
        }

        /// <summary>
        /// Atualiza os dados de uma Nfe
        /// </summary>
        /// <param name="contaBanco"></param>
        public void Atualizar(NfeControle nfe)
        {
            try
            {
                var repNfe = new RepositorioGenerico<NfeE>();

                NfeE _nfe = repNfe.ObterEntidade(n => n.codNFe == nfe.CodNfe);
                Atribuir(nfe, _nfe);

                repNfe.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DadosException("Nota Fiscal Eletrônica", e.Message, e);
            }
        }

        /// <summary>
        /// Remove os dados de uma conta bancária
        /// </summary>
        /// <param name="codcontaBanco"></param>
        public void Remover(Int32 codNfe)
        {
            try
            {
                var repNfe = new RepositorioGenerico<NfeE>();

                repNfe.Remover(n => n.codNFe == codNfe);
                repNfe.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DadosException("Nota Fiscal Eletrônica", e.Message, e);
            }
        }

        /// <summary>
        /// Query Geral para obter dados das nfes
        /// </summary>
        /// <returns></returns>
        private IQueryable<NfeControle> GetQuery()
        {
            var repNfe = new RepositorioGenerico<NfeE>();

            var saceEntities = (SaceEntities)repNfe.ObterContexto();
            var query = from nfe in saceEntities.NfeSet
                        select new NfeControle
                        {
                            Chave = nfe.chave,
                            CodNfe = nfe.codNFe,
                            JustificativaCancelamento = nfe.justificativaCancelamento,
                            NumeroLoteEnvio = nfe.loteEnvio,
                            ProtocoloAutorizacao = nfe.protocoloAutorizacao,
                            ProtocoloCancelamento = nfe.protocoloCancelamento,
                            Situacao = Convert.ToChar(nfe.situacao)
                        };
            return query;
        }


        /// <summary>
        /// Obtém todos as nfe
        /// </summary>
        /// <returns></returns>
        public IEnumerable<NfeControle> ObterTodos()
        {
            return GetQuery().ToList();
        }

        /// <summary>
        /// Obter Nfes por Chave
        /// </summary>
        /// <returns></returns>
        public IEnumerable<NfeControle> ObterPorChave(string chave)
        {
            return GetQuery().Where(nc => nc.Chave.Equals(chave)).ToList();
        }

        /// <summary>
        /// Obter Nfes por Lote
        /// </summary>
        /// <returns></returns>
        public IEnumerable<NfeControle> ObterPorLote(string numeroLote)
        {
            return GetQuery().Where(nc => nc.NumeroLoteEnvio.Equals(numeroLote)).ToList();
        }

        /// <summary>
        /// Obter Nfes por recibo
        /// </summary>
        /// <returns></returns>
        public IEnumerable<NfeControle> ObterPorRecibo(string numeroRecibo)
        {
            return GetQuery().Where(nc => nc.NumeroRecibo.Equals(numeroRecibo)).ToList();
        }
        /// <summary>
        /// Obtém todos as nfe relacioanadas a uma saída
        /// </summary>
        /// <returns></returns>
        public IEnumerable<NfeControle> ObterPorSaida(long codSaida)
        {
            var repSaida = new RepositorioGenerico<SaidaE>();

            var saceEntities = (SaceEntities)repSaida.ObterContexto();
            SaidaE _saidaE = repSaida.ObterPrimeiro(s => s.codSaida == codSaida);
            
            var query = from nfe in _saidaE.tb_nfe
                        select new NfeControle
                        {
                            Chave = nfe.chave,
                            CodNfe = nfe.codNFe,
                            JustificativaCancelamento = nfe.justificativaCancelamento,
                            NumeroLoteEnvio = nfe.loteEnvio,
                            ProtocoloAutorizacao = nfe.protocoloAutorizacao,
                            ProtocoloCancelamento = nfe.protocoloCancelamento,
                            Situacao = Convert.ToChar(nfe.situacao)
                        };
            return query.ToList();
        }

        /// <summary>
        /// Obtém Nfe com o código especificiado
        /// </summary>
        /// <param name="codBanco"></param>
        /// <returns></returns>
        public IEnumerable<NfeControle> Obter(int codNfe)
        {
            return GetQuery().Where(nfe=> nfe.CodNfe == codNfe).ToList();
        }

        public string GerarChaveNFE(Saida saida, NfeControle nfe)
        {
            try
            {
                string chaveNFe = ObterChaveGerada(saida, 1);
                if (!chaveNFe.Equals(""))
                    return chaveNFe;

                //define um documento XML e carrega o seu conteúdo 
                XmlDocument xmldoc = new XmlDocument();
                //xmldoc.Load(Global.PASTA_COMUNICACAO_NFE_ENVIO + saida.Nfe + "-gerar-chave.xml");

                //Cria um novo elemento poemas  e define os elementos autor, titulo e conteudo
                XmlElement novoGerarChave = xmldoc.CreateElement("gerarChave");
                XmlElement xmlnNF = xmldoc.CreateElement("nNF");
                XmlElement xmlserie = xmldoc.CreateElement("serie");
                XmlElement xmlAAMM = xmldoc.CreateElement("AAMM");
                XmlElement xmlcnpj = xmldoc.CreateElement("CNPJ");
                
                //atribui o conteúdo das caixa de texto aos elementos xml
                xmlnNF.InnerText = nfe.CodNfe.ToString().PadLeft(8, '0');
                xmlserie.InnerText = "1";
                xmlAAMM.InnerText = DateTime.Now.Year.ToString().Substring(2, 2) + DateTime.Now.Month.ToString().PadLeft(2, '0');
                long codPessoaLoja = GerenciadorLoja.GetInstance().Obter(Global.LOJA_PADRAO)[0].CodPessoa;
                xmlcnpj.InnerText = GerenciadorPessoa.GetInstance().Obter(codPessoaLoja).ElementAt(0).CpfCnpj;

                //inclui os novos elementos no elemento poemas
                novoGerarChave.AppendChild(xmlnNF);
                novoGerarChave.AppendChild(xmlserie);
                novoGerarChave.AppendChild(xmlAAMM);
                novoGerarChave.AppendChild(xmlcnpj);
                
                //inclui o novo elemento no XML
                xmldoc.AppendChild(novoGerarChave);

                //Salva a inclusão no arquivo XML
                xmldoc.Save(Global.PASTA_COMUNICACAO_NFE_ENVIO + saida.Nfe + "-gerar-chave.xml");

                chaveNFe = ObterChaveGerada(saida, 10);
                return chaveNFe;
            }
            catch (NegocioException nex)
            {
                throw nex;
            }
            
        }

        /// <summary>
        /// Primeiro passo para emissão da nota fiscal é a emissão da chave.
        /// Enquanto a chave não for gerada não pode seguir os próximos passos. 
        /// </summary>
        /// <param name="saida"></param>
        /// <param name="numeroTentativasGerarChave"></param>
        /// <returns></returns>
        private static string ObterChaveGerada(Saida saida, int numeroTentativasGerarChave)
        {
            string chaveNFe = "";
            int tentativas = 0;
            while (chaveNFe.Equals("") && tentativas < numeroTentativasGerarChave)
            {
                
                DirectoryInfo Dir = new DirectoryInfo(Global.PASTA_COMUNICACAO_NFE_RETORNO);
                if (Dir.Exists)
                {
                    // Busca automaticamente todos os arquivos em todos os subdiretórios
                    string arquivoRetornoChave = saida.Nfe + "-ret-gerar-chave.xml";
                    FileInfo[] files = Dir.GetFiles(arquivoRetornoChave, SearchOption.TopDirectoryOnly);
                    if (files.Length > 0)
                    {
                        XmlDocument xmldocRetorno = new XmlDocument();
                        xmldocRetorno.Load(Global.PASTA_COMUNICACAO_NFE_RETORNO + saida.Nfe + "-ret-gerar-chave.xml");
                        chaveNFe = xmldocRetorno.DocumentElement.InnerText;
                        files[0].Delete();
                    }
                    else
                    {
                        Thread.Sleep(1000);
                    }
                }
                tentativas++;
            }

            if (tentativas > 1 && tentativas >= numeroTentativasGerarChave && string.IsNullOrEmpty(chaveNFe) )
                throw new NegocioException("Ocorreram problemas/lentidão na geração da chave da NF-e. Favor tentar novamente em alguns minutos.");
            return chaveNFe;
        }

        /// <summary>
        /// Após o envio da Nf-e o Unidanfe gera um número de lote automático para
        /// controlar na aplicação.
        /// </summary>
        /// <param name="nfeControle"></param>
        /// <returns></returns>
        public static string ObterLoteEnvio()
        {
              DirectoryInfo Dir = new DirectoryInfo(Global.PASTA_COMUNICACAO_NFE_RETORNO);
              string numeroLote = "";
              if (Dir.Exists)
              {
                  // Busca automaticamente todos os arquivos em todos os subdiretórios
                  
                  string arquivoRetornoLote = "*-num-lot.*";
                  FileInfo[] files = Dir.GetFiles(arquivoRetornoLote, SearchOption.TopDirectoryOnly);
                  for(int i = 0; i < files.Length; i++)
                  {
                      XmlDocument xmldocRetorno = new XmlDocument();
                      xmldocRetorno.Load(Global.PASTA_COMUNICACAO_NFE_RETORNO + files[i].Name);

                      string chave = files[0].Name.Substring(0, 44);
                      NfeControle nfeControle = GerenciadorNFe.GetInstance().ObterPorChave(chave).ElementAtOrDefault(0);

                      if (nfeControle != null)
                      {
                          if (files[i].Name.Contains("nfe.err"))
                          {
                              files[i].Delete();
                              nfeControle.Situacao = NfeControle.SITUACAO_NAO_VALIDADA;
                          }
                          else
                          {
                              numeroLote = xmldocRetorno.DocumentElement.InnerText;
                              nfeControle.NumeroLoteEnvio = numeroLote.PadLeft(15, '0');
                              files[i].Delete();
                          }
                          GerenciadorNFe.GetInstance().Atualizar(nfeControle);
                      }
                  }
              }
              return numeroLote;
        }

        /// <summary>
        /// Obtém o resultado do envio de um lote pela receita.
        /// </summary>
        /// <param name="nfeControle"></param>
        /// <returns></returns>
        public static string ObterRetornoEnvioNfe()
        {
            DirectoryInfo Dir = new DirectoryInfo(Global.PASTA_COMUNICACAO_NFE_RETORNO);
            string numeroRecibo = "";
            if (Dir.Exists)
            {
                // Busca automaticamente todos os arquivos em todos os subdiretórios
                string arquivoRetornoEnvioNfe = "-rec.*";
                FileInfo[] files = Dir.GetFiles(arquivoRetornoEnvioNfe, SearchOption.TopDirectoryOnly);
                for (int i = 0; i < files.Length; i++)
                {
                    // apenas exclui o arquivo texto que não será utilizado  
                    if (files[i].Name.Contains("-rec.txt"))
                    {
                        files[i].Delete();
                    }
                    else
                    {
                        XmlDocument xmldocRetorno = new XmlDocument();
                        xmldocRetorno.Load(Global.PASTA_COMUNICACAO_NFE_RETORNO + files[i].Name);

                        string numeroLote = files[i].Name.Substring(0, 15);
                        NfeControle nfeControle = GerenciadorNFe.GetInstance().ObterPorLote(numeroLote).ElementAtOrDefault(0);

                        if (nfeControle != null)
                        {
                            MemoryStream memStream = new MemoryStream();
                            XmlSerializer serializer = new XmlSerializer(typeof(TRetEnviNFe));
                            TRetEnviNFe retornoEnvioNfe = (TRetEnviNFe)serializer.Deserialize(memStream);
                            if (retornoEnvioNfe.cStat.Equals(NfeStatusResposta.NFE103_LOTE_RECEBIDO_SUCESSO))
                            {
                                numeroRecibo = retornoEnvioNfe.infRec.nRec;
                                nfeControle.NumeroRecibo = numeroRecibo;
                            }
                            nfeControle.StatusEnvio = retornoEnvioNfe.cStat;
                            nfeControle.MensagemStatusEnvio = retornoEnvioNfe.xMotivo;
                            GerenciadorNFe.GetInstance().Atualizar(nfeControle);
                            files[0].Delete();
                        }
                    }
                }
            }
            return numeroRecibo;
        }

        public static string ObterRetornoConsultaReciboNfe()
        {
            DirectoryInfo Dir = new DirectoryInfo(Global.PASTA_COMUNICACAO_NFE_RETORNO);
            string numeroProtocolo = "";
            if (Dir.Exists)
            {
                // Busca automaticamente todos os arquivos em todos os subdiretórios
                string arquivoRetornoReciboNfe = "*-pro-rec.*";
                FileInfo[] files = Dir.GetFiles(arquivoRetornoReciboNfe, SearchOption.TopDirectoryOnly);
                for (int i = 0; i < files.Length; i++)
                {
                    // apenas exclui o arquivo texto que não será utilizado  
                    if (files[i].Name.Contains("-pro-rec.txt"))
                    {
                        files[i].Delete();
                    }
                    else
                    {
                        XmlDocument xmldocRetorno = new XmlDocument();
                        xmldocRetorno.Load(Global.PASTA_COMUNICACAO_NFE_RETORNO + files[i].Name);

                        string numeroRecibo = files[i].Name.Substring(0, 15);
                        NfeControle nfeControle = GerenciadorNFe.GetInstance().ObterPorRecibo(numeroRecibo).ElementAtOrDefault(0);
                        if (nfeControle != null)
                        {
                            MemoryStream memStream = new MemoryStream();
                            XmlSerializer serializer = new XmlSerializer(typeof(TRetConsReciNFe));
                            TRetConsReciNFe retornoConsReciboNfe = (TRetConsReciNFe)serializer.Deserialize(memStream);
                            if (retornoConsReciboNfe.cStat.Equals(NfeStatusResposta.NFE104_LOTE_PROCESSADO))
                            {
                                TProtNFeInfProt protocoloNfe = retornoConsReciboNfe.protNFe[0].infProt;
                                if (protocoloNfe.chNFe.Equals(nfeControle.Chave))
                                {
                                    if (protocoloNfe.cStat.Equals(NfeStatusResposta.NFE100_AUTORIZADO_USO_NFE))
                                    {
                                        numeroProtocolo = protocoloNfe.nProt;
                                        nfeControle.ProtocoloAutorizacao = protocoloNfe.nProt;
                                        nfeControle.Situacao = NfeControle.SITUACAO_AUTORIZADA;
                                    }
                                    else if (protocoloNfe.cStat.Equals(NfeStatusResposta.NFE110_USO_DENEGADO))
                                    {
                                        nfeControle.Situacao = NfeControle.SITUACAO_DENEGADA;
                                    }
                                    else
                                    {
                                        nfeControle.Situacao = NfeControle.SITUACAO_REJEITADA;
                                    }
                                    nfeControle.StatusProtocolo = protocoloNfe.cStat;
                                    nfeControle.MensagemStatusProtocolo = protocoloNfe.xMotivo;

                                }
                            }
                            nfeControle.StatusEnvio = retornoConsReciboNfe.cStat;
                            nfeControle.MensagemStatusEnvio = retornoConsReciboNfe.xMotivo;
                            GerenciadorNFe.GetInstance().Atualizar(nfeControle);
                            files[0].Delete();
                        }
                    }
                }
            }
            return numeroProtocolo;
        }

        public void EnviarNFE(Saida saida, NfeControle nfeControle)
        {
            
            try
            {
                // utilizado como padrão quando não especificado pelos produtos
                string cfopPadrao = GerenciadorSaida.GetInstance(null).ObterCfopTipoSaida(saida.TipoSaida).ToString();
                
                string FORMATO_DATA = "yyyy-MM-dd";
                TNFe nfe = new TNFe();
                
                //Informacoes NFe
                TNFeInfNFe infNFe = new TNFeInfNFe();
                infNFe.versao = "2.00";
                infNFe.Id = "NFe" + nfeControle.Chave;
                nfe.infNFe = infNFe;
                

                //Ide
                TNFeInfNFeIde infNFeIde = new TNFeInfNFeIde();
                infNFeIde.cNF = nfeControle.Chave.Substring(35, 8); // código composto por 8 dígitos sequenciais
                infNFeIde.cDV = nfeControle.Chave.Substring(43, 1);
                
                Loja lojaPadrao = GerenciadorLoja.GetInstance().Obter(Global.LOJA_PADRAO).ElementAtOrDefault(0);
                infNFeIde.cMunFG = lojaPadrao.CodMunicipioIBGE.ToString();
                infNFeIde.cUF = (TCodUfIBGE)Enum.Parse(typeof(TCodUfIBGE), "Item" + lojaPadrao.CodMunicipioIBGE.ToString().Substring(0, 2));

                infNFeIde.dEmi = saida.DataEmissaoCupomFiscal.ToString(FORMATO_DATA);
                infNFeIde.dSaiEnt = saida.CupomFiscal.Equals("") ? saida.DataSaida.ToString(FORMATO_DATA) : saida.DataEmissaoCupomFiscal.ToString(FORMATO_DATA);
                infNFeIde.finNFe = TFinNFe.Item1; //1 - Normal / 2 NF-e complementar / 3 - Nf-e Ajuste
                infNFeIde.indPag = (TNFeInfNFeIdeIndPag)0; // 0 - à Vista  1 - a prazo  2 - outros
                infNFeIde.mod = TMod.Item55;
                infNFeIde.natOp = GerenciadorCfop.GetInstance().Obter(Convert.ToInt32(cfopPadrao)).ElementAtOrDefault(0).Descricao;
                infNFeIde.nNF = nfeControle.CodNfe.ToString(); // número do Documento Fiscal
                infNFeIde.procEmi = TProcEmi.Item0; //0 - Emissão do aplicativo do contribuinte
                infNFeIde.serie = "1";
                infNFeIde.tpAmb = (TAmb)Enum.Parse(typeof(TAmb), "Item" + Global.AMBIENTE_NFE); // 1-produção / 2-homologação
                infNFeIde.tpEmis = TNFeInfNFeIdeTpEmis.Item1; // emissão Normal
                infNFeIde.tpImp = TNFeInfNFeIdeTpImp.Item1; // 1-Retratro / 2-Paisagem
                infNFeIde.tpNF = TNFeInfNFeIdeTpNF.Item1; // 0 - entrada / 1 - saída de produtos
                infNFeIde.verProc = "SACE 2.0.1"; //versão do aplicativo de emissão de nf-e   
                TNFeInfNFeIdeNFrefRefECF refEcf = new TNFeInfNFeIdeNFrefRefECF();
                refEcf.mod = TNFeInfNFeIdeNFrefRefECFMod.Item2D;
                refEcf.nCOO = saida.CupomFiscal;
                refEcf.nECF = saida.NumeroECF;
                TNFeInfNFeIdeNFref nfRef = new TNFeInfNFeIdeNFref();
                nfRef.ItemElementName = ItemChoiceType1.refECF;
                nfRef.Item = refEcf;
                infNFeIde.NFref = new TNFeInfNFeIdeNFref[1];
                infNFeIde.NFref[0] = nfRef;

                nfe.infNFe.ide = infNFeIde;

                ////Endereco Emitente
                TEnderEmi enderEmit = new TEnderEmi();

                Loja loja = GerenciadorLoja.GetInstance().Obter(Global.LOJA_PADRAO).ElementAtOrDefault(0);
                Pessoa pessoaloja = GerenciadorPessoa.GetInstance().Obter(loja.CodPessoa).ElementAtOrDefault(0);
                enderEmit.CEP = pessoaloja.Cep;
                enderEmit.cMun = pessoaloja.CodMunicipioIBGE.ToString();
                enderEmit.cPais = TEnderEmiCPais.Item1058;
                enderEmit.fone = pessoaloja.Fone1;
                enderEmit.nro = pessoaloja.Numero;
                enderEmit.UF = (TUfEmi)Enum.Parse(typeof(TUfEmi), pessoaloja.Uf);
                enderEmit.xBairro = pessoaloja.Bairro;
                if (!string.IsNullOrEmpty(pessoaloja.Complemento))
                    enderEmit.xCpl = pessoaloja.Complemento;
                enderEmit.xLgr = pessoaloja.Endereco;
                enderEmit.xMun = pessoaloja.NomeMunicipioIBGE;
                enderEmit.xPais = TEnderEmiXPais.BRASIL;
               
                ////Emitente
                TNFeInfNFeEmit emit = new TNFeInfNFeEmit();
                emit.CRT = TNFeInfNFeEmitCRT.Item1;   // 1- Simples Nacional
                emit.IE = pessoaloja.Ie;
                emit.enderEmit = enderEmit;
                emit.xFant = pessoaloja.NomeFantasia;
                emit.xNome = pessoaloja.Nome;
                emit.Item = pessoaloja.CpfCnpj;
                nfe.infNFe.emit = emit;

                ////Endereco destinatario
                TEndereco enderDest = new TEndereco();
                Pessoa destinatario = GerenciadorPessoa.GetInstance().Obter(saida.CodCliente).ElementAtOrDefault(0);
                enderDest.CEP = destinatario.Cep;
                enderDest.cMun = destinatario.CodMunicipioIBGE.ToString();
                enderDest.cPais = Tpais.Item1058;
                enderDest.fone = destinatario.Fone1;
                enderDest.nro = destinatario.Numero;
                enderDest.UF = (TUf)Enum.Parse(typeof(TUf), destinatario.Uf);
                enderDest.xBairro = destinatario.Bairro;
                if (!string.IsNullOrEmpty(destinatario.Complemento))
                    enderDest.xCpl = destinatario.Complemento;
                enderDest.xLgr = destinatario.Endereco;
                enderDest.xMun = destinatario.NomeMunicipioIBGE;
                enderDest.xPais = "Brasil";
                
                ////Destinatario
                TNFeInfNFeDest dest = new TNFeInfNFeDest();
                if (Global.AMBIENTE_NFE.Equals("1")) //produção
                    dest.xNome = destinatario.Nome;
                else
                    dest.xNome = "NF-E EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL";
                dest.Item = destinatario.CpfCnpj;
                dest.ItemElementName = ItemChoiceType3.CPF;
                if (destinatario.CpfCnpj.Length > 11)
                {
                    dest.ItemElementName = ItemChoiceType3.CNPJ;
                    dest.IE = destinatario.Ie;
                }
                nfe.infNFe.dest = dest;
                dest.enderDest = enderDest;

                ////Informacoes Adicionais
                TNFeInfNFeInfAdic infAdic = new TNFeInfNFeInfAdic();
                //infAdic.infAdFisco = nfeSelected.informacoesAddFisco;

                saida.Observacao = Global.NFE_MENSAGEM_PADRAO + saida.Observacao;
                if (string.IsNullOrEmpty(saida.CupomFiscal))
                    infAdic.infCpl = saida.Observacao;
                else
                    infAdic.infCpl = saida.Observacao + ". ICMS RECOLHIDO NO C.F.: " + saida.CupomFiscal;    
                nfe.infNFe.infAdic = infAdic;

                //detalhes
                List<TNFeInfNFeDet> listaNFeDet = new List<TNFeInfNFeDet>();
                List<SaidaProduto> saidaProdutos;
                if (saida.TipoSaida == Saida.TIPO_VENDA)
                {
                    saidaProdutos = GerenciadorSaidaProduto.GetInstance(null).ObterPorPedido(saida.CupomFiscal);
                }
                else
                {
                    saidaProdutos = GerenciadorSaidaProduto.GetInstance(null).ObterPorSaida(saida.CodSaida);
                }
                saidaProdutos = GerenciadorSaida.GetInstance(null).ExcluirProdutosDevolvidosMesmoPreco(saidaProdutos);

                int nItem = 1; // número do item processado
                
                decimal totalProdutos = 0;
                decimal descontoDevolucoes = 0;

                foreach (SaidaProduto saidaProduto in saidaProdutos)
                {
                    if (saidaProduto.Quantidade < 0)
                    {
                        descontoDevolucoes += saidaProduto.Subtotal;
                    }
                    else
                    {
                        TNFeInfNFeDetProd prod = new TNFeInfNFeDetProd();
                        prod.cProd = saidaProduto.CodProduto.ToString();
                        ProdutoPesquisa produto = GerenciadorProduto.GetInstance().Obter(saidaProduto.CodProduto).ElementAtOrDefault(0);
                        prod.cEAN = produto.CodigoBarra;
                        prod.cEANTrib = produto.CodigoBarra;
                        prod.CFOP = (TCfop)Enum.Parse(typeof(TCfop), "Item" + saidaProduto.CodCfop);
                        if (saida.TipoSaida == Saida.TIPO_DEVOLUCAO_FORNECEDOR)
                            prod.xProd = produto.NomeProdutoFabricante;
                        else
                            prod.xProd = produto.Nome;
                        prod.NCM = produto.Ncmsh;
                        prod.uCom = produto.Unidade;
                        prod.qCom = formataValorNFe(saidaProduto.Quantidade);
                        prod.vUnCom = formataValorNFe(saidaProduto.ValorVenda);
                        prod.vProd = formataValorNFe(saidaProduto.Subtotal);
                        prod.uTrib = produto.Unidade;
                        prod.qTrib = formataQtdNFe(saidaProduto.Quantidade);
                        prod.vUnTrib = formataValorNFe(saidaProduto.ValorVenda);
                        prod.indTot = (TNFeInfNFeDetProdIndTot)1; // Valor = 1 deve entrar no valor total da nota

                        TNFeInfNFeDetImpostoICMS icms = new TNFeInfNFeDetImpostoICMS();

                        if ((saida.TipoSaida == Saida.TIPO_PRE_VENDA) || (saida.TipoSaida == Saida.TIPO_VENDA))
                        {
                            TNFeInfNFeDetImpostoICMSICMSSN102 icms102 = new TNFeInfNFeDetImpostoICMSICMSSN102();
                            icms102.CSOSN = TNFeInfNFeDetImpostoICMSICMSSN102CSOSN.Item400  ;
                            icms102.orig = Torig.Item0;
                            
                            icms.Item = icms102;
                        }
                        
                        TNFeInfNFeDetImposto imp = new TNFeInfNFeDetImposto();
                        imp.Items = new object[] { icms };

                        TNFeInfNFeDetImpostoPISPISOutr pisOutr = new TNFeInfNFeDetImpostoPISPISOutr();
                        pisOutr.CST = TNFeInfNFeDetImpostoPISPISOutrCST.Item99;
                        pisOutr.vPIS = formataValorNFe(0);
                        pisOutr.Items = new string[2];
                        pisOutr.Items[0] = formataValorNFe(0);
                        pisOutr.Items[1] = formataValorNFe(0);
                        pisOutr.ItemsElementName = new ItemsChoiceType1[2];
                        pisOutr.ItemsElementName[0] = ItemsChoiceType1.vBC;
                        pisOutr.ItemsElementName[1] = ItemsChoiceType1.pPIS;
                        

                        TNFeInfNFeDetImpostoPIS pis = new TNFeInfNFeDetImpostoPIS();
                        pis.Item = pisOutr;
                        imp.PIS = pis;



                        TNFeInfNFeDetImpostoCOFINSCOFINSOutr cofinsOutr = new TNFeInfNFeDetImpostoCOFINSCOFINSOutr();
                        cofinsOutr.CST = TNFeInfNFeDetImpostoCOFINSCOFINSOutrCST.Item99;
                        cofinsOutr.vCOFINS = formataValorNFe(0);
                        cofinsOutr.Items = new string[2];
                        cofinsOutr.Items[0] = formataValorNFe(0);
                        cofinsOutr.Items[1] = formataValorNFe(0);
                        cofinsOutr.ItemsElementName = new ItemsChoiceType3[2];
                        cofinsOutr.ItemsElementName[0] = ItemsChoiceType3.vBC;
                        cofinsOutr.ItemsElementName[1] = ItemsChoiceType3.pCOFINS;
                        

                        TNFeInfNFeDetImpostoCOFINS cofins = new TNFeInfNFeDetImpostoCOFINS();
                        cofins.Item = cofinsOutr;
                        imp.COFINS = cofins;

                        TNFeInfNFeDet nfeDet = new TNFeInfNFeDet();
                        nfeDet.imposto = imp;
                        nfeDet.prod = prod;
                        //nfeDet.infAdProd = detalhe.informacoesAdicionais;
                        nfeDet.nItem = nItem.ToString();
                        nItem++; // número do item na nf-e

                        listaNFeDet.Add(nfeDet);
                        totalProdutos += saidaProduto.Subtotal;
                    }
                }
                nfe.infNFe.det = listaNFeDet.ToArray();

                decimal totalAVista = totalProdutos;
                if (saida.TipoSaida == Saida.TIPO_VENDA)
                {
                    List<Saida> listaSaidas = GerenciadorSaida.GetInstance(null).ObterPorPedido(saida.CupomFiscal);
                    totalAVista = listaSaidas.Where(s => s.TotalAVista > 0).Sum(s => s.TotalAVista);
                }

                TNFeInfNFeTotalICMSTot icmsTot = new TNFeInfNFeTotalICMSTot();
                if (saida.TipoSaida == Saida.TIPO_VENDA)
                {
                    icmsTot.vBC = formataValorNFe(0); // o valor da base de cálculo deve ser a dos produtos.
                    icmsTot.vICMS = formataValorNFe(0);
                    icmsTot.vBCST = formataValorNFe(0);
                    icmsTot.vST = formataValorNFe(0);
                    icmsTot.vProd = formataValorNFe(totalProdutos);
                    icmsTot.vFrete = formataValorNFe(saida.ValorFrete);
                    icmsTot.vSeg = formataValorNFe(saida.ValorSeguro);
                    icmsTot.vDesc = formataValorNFe(totalProdutos - totalAVista - descontoDevolucoes);
                    icmsTot.vII = formataValorNFe(0);
                    icmsTot.vIPI = formataValorNFe(0);
                    icmsTot.vPIS = formataValorNFe(0);
                    icmsTot.vCOFINS = formataValorNFe(0);
                    icmsTot.vOutro = formataValorNFe(saida.OutrasDespesas);
                    icmsTot.vNF = formataValorNFe(totalAVista + descontoDevolucoes);
                }
                else
                {
                    icmsTot.vBC = formataValorNFe(saida.BaseCalculoICMS);
                    icmsTot.vICMS = formataValorNFe(saida.ValorICMS);
                    icmsTot.vBCST = formataValorNFe(saida.BaseCalculoICMSSubst);
                    icmsTot.vST = formataValorNFe(saida.ValorICMSSubst);
                    icmsTot.vProd = formataValorNFe(totalAVista + descontoDevolucoes);
                    icmsTot.vFrete = formataValorNFe(saida.ValorFrete);
                    icmsTot.vSeg = formataValorNFe(saida.ValorSeguro);
                    icmsTot.vDesc = formataValorNFe(saida.Desconto);
                    icmsTot.vII = formataValorNFe(0);
                    icmsTot.vIPI = formataValorNFe(saida.ValorIPI);
                    icmsTot.vPIS = formataValorNFe(0);
                    icmsTot.vCOFINS = formataValorNFe(0);
                    icmsTot.vOutro = formataValorNFe(saida.OutrasDespesas);
                    icmsTot.vNF = formataValorNFe(saida.TotalNotaFiscal);
                }

                TNFeInfNFeTotal total = new TNFeInfNFeTotal();
                total.ICMSTot = icmsTot;
                nfe.infNFe.total = total;

                TNFeInfNFeTranspTransporta transporta = new TNFeInfNFeTranspTransporta();
                TNFeInfNFeTransp transp = new TNFeInfNFeTransp();
                if ((saida.CodEmpresaFrete == saida.CodCliente) || (saida.CodEmpresaFrete == Global.CLIENTE_PADRAO))
                {
                    transp.modFrete = TNFeInfNFeTranspModFrete.Item9; // 9-Sem frete
                }
                else
                {
                    transp.modFrete = TNFeInfNFeTranspModFrete.Item1; // 1-Por conta do destinatário
                    transp.transporta = new TNFeInfNFeTranspTransporta();
                    Pessoa transportadora = GerenciadorPessoa.GetInstance().Obter(saida.CodEmpresaFrete).ElementAtOrDefault(0);
                    transporta.IE = transportadora.Ie;
                    transporta.UF = (TUf)Enum.Parse(typeof(TUf), transportadora.Uf);
                    transporta.xEnder = transportadora.Endereco;
                    transporta.xMun = transportadora.Cidade;
                    transporta.xNome = transportadora.Nome;
                    transp.vol = new TNFeInfNFeTranspVol[1];
                    TNFeInfNFeTranspVol volumes = new TNFeInfNFeTranspVol();
                    volumes.esp = saida.EspecieVolumes;
                    volumes.marca = saida.Marca;
                    volumes.nVol = formataValorNFe(saida.Numero);
                    volumes.pesoB = formataValorNFe(saida.PesoBruto);
                    volumes.pesoL = formataValorNFe(saida.PesoLiquido);
                    volumes.qVol = formataValorNFe(saida.QuantidadeVolumes);
                    
                    transp.vol[0] = volumes;
                    transp.transporta = transporta;
                    transp.retTransp = new TNFeInfNFeTranspRetTransp();
                    
                }

                nfe.infNFe.transp = transp;

                MemoryStream memStream = new MemoryStream();
                XmlSerializer serializer = new XmlSerializer(typeof(TNFe));
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();

                ns.Add("", "http://www.portalfiscal.inf.br/nfe");
                serializer.Serialize(memStream, nfe, ns);
                
                
                memStream.Position = 0;
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(memStream);
                xmlDoc.Save(Global.PASTA_COMUNICACAO_NFE_ENVIO + nfeControle.Chave + "-nfe.xml");

                nfeControle.Situacao = NfeControle.SITUACAO_SOLICITADA;
                Atualizar(nfeControle);
                
            }
            catch (Exception ex)
            {
                throw new NegocioException("Problemas na geração do arquivo da Nota Fiscal Eletrônica. Favor consultar administrador do sistema.", ex);
            }
        }

        private string formataValorNFe(decimal? valor)
        {
            try
            {
                if (valor == null)
                    valor = 0;

                return ((decimal)valor).ToString("0.00", CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private string formataQtdNFe(decimal? quantidade)
        {
            try
            {
                if (quantidade == null)
                    quantidade = 0;

                return ((decimal)quantidade).ToString("0.0000", CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Atribui a classe Nfe às entidade persistente correpondente
        /// </summary>
        /// <param name="nfe"></param>
        /// <param name="_nfe"></param>
        private void Atribuir(NfeControle nfe, NfeE _nfe)
        {
            _nfe.chave = string.IsNullOrEmpty(nfe.Chave)?"":nfe.Chave;
            _nfe.codNFe = nfe.CodNfe;
            _nfe.justificativaCancelamento = nfe.JustificativaCancelamento;
            _nfe.loteEnvio = nfe.NumeroLoteEnvio;
            _nfe.protocoloAutorizacao = nfe.ProtocoloAutorizacao;
            _nfe.protocoloCancelamento = nfe.ProtocoloCancelamento;
            _nfe.situacao = nfe.Situacao.ToString();
        }
        
        public void imprimirDANFE()
        {
            try
            {
                Process unidanfe = new Process();
                unidanfe.StartInfo.FileName = @"C:\Unimake\UniNFe\unidanfe.exe";
                //unidanfe.StartInfo.Arguments = " arquivo=\"" + Empresa.Configuracoes[0].PastaEnviado + "\\Autorizados\\"
                //    + nfeSelected.dataEmissao.Value.Year
                //    + nfeSelected.dataEmissao.Value.Month.ToString("00") + "\\"
                //    + nfeSelected.chaveAcesso + nfeSelected.digitoChaveAcesso + "-nfe.xml\" ";
                //unidanfe.Start();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
