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
using System.Xml.Linq;
using System.Runtime.CompilerServices;

namespace Negocio
{
    public class GerenciadorNFe
    {
        private static GerenciadorNFe gNFe;
        private static string nomeComputador;
        const string FORMATO_DATA_HORA = "yyyy-MM-ddTHH:mm:sszzz";

        public static GerenciadorNFe GetInstance()
        {
            if (gNFe == null)
            {
                gNFe = new GerenciadorNFe();
            }

            return gNFe;
        }

        private GerenciadorNFe()
        {
            nomeComputador = System.Windows.Forms.SystemInformation.ComputerName;
            //loja = GerenciadorLoja.GetInstance().ObterPorServidorNfe(nomeComputador).ElementAtOrDefault(0);
            //pastaNfeRetorno = loja != null ? loja.PastaNfeRetorno : "";
        }

        /// <summary>
        /// Insere os dados de uma conta bancária
        /// </summary>
        /// <param name="contaBanco"></param>
        /// <returns></returns>
        public int Inserir(NfeControle nfe, Saida saida, bool ehNfeComplementar, List<tb_solicitacao_saida> listaSolicitacaoSaida)
        {
            try
            {
                var repNfe = new RepositorioGenerico<tb_nfe>();
                var saceContext = (SaceEntities)repNfe.ObterContexto();

                var repSaida = new RepositorioGenerico<tb_saida>(saceContext);


                tb_nfe _nfeE = new tb_nfe();
                Atribuir(nfe, _nfeE);

                repNfe.Inserir(_nfeE);

                // Associa saídas as nova nfe
                if (listaSolicitacaoSaida.Count == 1)
                {
                    var query = from tb_saida in saceContext.tb_saida
                                where tb_saida.codSaida == saida.CodSaida
                                select tb_saida;
                    foreach (tb_saida _saida in query)
                    {
                        _nfeE.tb_saida.Add(_saida);
                    }
                }
                else
                {
                    List<long> listaCodSaidas = listaSolicitacaoSaida.Select(l => l.codSaida).ToList();
                    var query = from tb_saida in saceContext.tb_saida
                                where listaCodSaidas.Contains(tb_saida.codSaida)
                                select tb_saida;
                    foreach (tb_saida _saida in query)
                    {
                        _nfeE.tb_saida.Add(_saida);
                    }
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
                var repNfe = new RepositorioGenerico<tb_nfe>();
                SaceEntities saceContext = (SaceEntities) repNfe.ObterContexto();
                var query = from nfeE in saceContext.tb_nfe
                            where nfeE.codNFe == nfe.CodNfe
                            select nfeE;
                tb_nfe _nfeE = query.FirstOrDefault();
                if (_nfeE != null)
                {
                    Atribuir(nfe, _nfeE);
                }
                saceContext.SaveChanges();
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
                var repNfe = new RepositorioGenerico<tb_nfe>();

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
            var repNfe = new RepositorioGenerico<tb_nfe>();

            var saceEntities = (SaceEntities)repNfe.ObterContexto();

            var query = from nfe in saceEntities.tb_nfe
                        select new NfeControle
                        {
                            Chave = nfe.chave,
                            CodNfe = nfe.codNFe,
                            JustificativaCancelamento = nfe.justificativaCancelamento,
                            MensagemSituacaoReciboEnvio = nfe.mensagemSituacaoReciboEnvio,
                            MensagemSitucaoProtocoloCancelamento = nfe.mensagemSituacaoProtocoloCancelamento,
                            MensagemSitucaoProtocoloUso = nfe.mensagemSituacaoProtocoloUso,
                            NumeroLoteEnvio = nfe.numeroLoteEnvio,
                            NumeroProtocoloCancelamento = nfe.numeroProtocoloCancelamento,
                            NumeroProtocoloUso = nfe.numeroProtocoloUso,
                            NumeroRecibo = nfe.numeroRecibo,
                            SituacaoNfe = nfe.situacaoNfe,
                            SituacaoProtocoloCancelamento = nfe.situacaoProtocoloCancelamento,
                            SituacaoProtocoloUso = nfe.situacaoProtocoloUso,
                            SituacaoReciboEnvio = nfe.situacaoReciboEnvio,
                            DataEmissao = nfe.dataEmissao,
                            DataCancelamento = nfe.dataCancelamento,
                            Correcao = nfe.correcao,
                            DataCartaCorrecao = nfe.dataCartaCorrecao,
                            MensagemSitucaoCartaCorrecao = nfe.mensagemSitucaoCartaCorrecao,
                            NumeroProtocoloCartaCorrecao = nfe.numeroProtocoloCartaCorrecao,
                            SeqCartaCorrecao = nfe.seqCartaCorrecao,
                            SituacaoProtocoloCartaCorrecao = nfe.situacaoProtocoloCartaCorrecao,
                            NumeroSequenciaNfe = nfe.numeroSequenciaNFe,
                            Modelo = nfe.modelo,
                            CodLoja = nfe.codLoja,
                            CodSolicitacao = nfe.codSolicitacao
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
        /// Obter Nfes por recibo
        /// </summary>
        /// <returns></returns>
        public IEnumerable<NfeControle> ObterPorSolicitacao(long codSolicitacao)
        {
            return GetQuery().Where(nc => nc.CodSolicitacao == codSolicitacao).ToList();
        }

        /// <summary>
        /// Obtém todos as nfe relacioanadas a uma saída
        /// </summary>
        /// <returns></returns>
        public IEnumerable<NfeControle> ObterPorSaida(long codSaida)
        {
            var repNfeControle = new RepositorioGenerico<tb_nfe>();
            var saceEntities = (SaceEntities)repNfeControle.ObterContexto();

            var query = from nfe in saceEntities.tb_nfe
                        where nfe.tb_saida.Select(s => s.codSaida).Contains(codSaida)
                        select new NfeControle
                        {
                            Chave = nfe.chave,
                            CodNfe = nfe.codNFe,
                            CodSaida = codSaida,
                            JustificativaCancelamento = nfe.justificativaCancelamento,
                            MensagemSituacaoReciboEnvio = nfe.mensagemSituacaoReciboEnvio,
                            MensagemSitucaoProtocoloCancelamento = nfe.mensagemSituacaoProtocoloCancelamento,
                            MensagemSitucaoProtocoloUso = nfe.mensagemSituacaoProtocoloUso,
                            NumeroLoteEnvio = nfe.numeroLoteEnvio,
                            NumeroProtocoloCancelamento = nfe.numeroProtocoloCancelamento,
                            NumeroProtocoloUso = nfe.numeroProtocoloUso,
                            NumeroRecibo = nfe.numeroRecibo,
                            SituacaoNfe = nfe.situacaoNfe,
                            SituacaoProtocoloCancelamento = nfe.situacaoProtocoloCancelamento,
                            SituacaoProtocoloUso = nfe.situacaoProtocoloUso,
                            SituacaoReciboEnvio = nfe.situacaoReciboEnvio,
                            DataEmissao = nfe.dataEmissao,
                            DataCancelamento = nfe.dataCancelamento,
                            Correcao = nfe.correcao,
                            DataCartaCorrecao = nfe.dataCartaCorrecao,
                            MensagemSitucaoCartaCorrecao = nfe.mensagemSitucaoCartaCorrecao,
                            NumeroProtocoloCartaCorrecao = nfe.numeroProtocoloCartaCorrecao,
                            SeqCartaCorrecao = nfe.seqCartaCorrecao,
                            SituacaoProtocoloCartaCorrecao = nfe.situacaoProtocoloCartaCorrecao,
                            NumeroSequenciaNfe = nfe.numeroSequenciaNFe,
                            Modelo = nfe.modelo,
                            CodLoja = nfe.codLoja,
                            CodSolicitacao = nfe.codSolicitacao
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
            return GetQuery().Where(nfe => nfe.CodNfe == codNfe).ToList();
        }

        /// <summary>
        /// Obtém Nfe com o código especificiado
        /// </summary>
        /// <param name="codBanco"></param>
        /// <returns></returns>
        public IEnumerable<NfeControle> ObterPorSituacao(string situacao)
        {
            return GetQuery().Where(nfe => nfe.SituacaoNfe.Equals(situacao)).ToList();
        }

        /// <summary>
        /// Obtém pelo numero de Sequencia da nfe na Loja
        /// </summary>
        /// <param name="numeroSequenciaNfe">Número sequencial da nfe</param>
        /// <param name="codLoja">Código da loja</param>
        /// <returns></returns>
        public IEnumerable<NfeControle> ObterPorNumeroNfeLojaModelo(int numeroSequenciaNfe, int codLoja, string modelo)
        {
            return GetQuery().Where(nfe => nfe.NumeroSequenciaNfe == numeroSequenciaNfe && nfe.CodLoja == codLoja && nfe.Modelo.Equals(modelo)).ToList();
        }

        /// <summary>
        /// Ontém todas as Nfe de uma loja
        /// </summary>
        /// <param name="codLoja">Códiog da loja</param>
        /// <returns></returns>
        public object ObterPorLoja(int codLoja)
        {
            return GetQuery().Where(nfe => nfe.CodLoja == codLoja).ToList();
        }

        private NfeControle GerarChaveNFE(Saida saida, tb_solicitacao_documento solicitacao, string modelo, List<tb_solicitacao_saida> listaSolicitacaoSaida)
        {
            if (saida.CodCliente.Equals(Global.CLIENTE_PADRAO) && modelo.Equals(NfeControle.MODELO_NFE))
            {
                throw new NegocioException("Não existe cliente associado a esse pedido. É necessário associar um CLIENTE que esteja com todos os dados cadastrados.");
            }
            try
            {
                //Verifica se a saída já possui uma chave gerada e cuja nf-e não foi validada
                IEnumerable<NfeControle> nfeControles = ObterPorSaida(saida.CodSaida);
                IEnumerable<NfeControle> nfeControlesAutorizadas = nfeControles.Where(nfeC => nfeC.SituacaoNfe.Equals(NfeControle.SITUACAO_AUTORIZADA));
                NfeControle nfeControle;
                if (solicitacao.ehComplementar && nfeControlesAutorizadas.Count() == 0)
                {
                    throw new NegocioException("Não pode enviar NF-e complementar. Uma NF-e Complementar só pode ser emitida quando existe uma NF-e enviada e Autorizada.");
                }
                else if (nfeControlesAutorizadas.Count() == 2)
                {
                    throw new NegocioException("Não pode mais emitir NF-e ou NFC-e para esse pedido. Elas já foram Enviadas e Autorizadas.");
                }
                else if (nfeControlesAutorizadas.Count() == 1)
                {
                    nfeControle = nfeControlesAutorizadas.ElementAtOrDefault(0);
                    if (nfeControle.Modelo.Equals(modelo))
                        throw new NegocioException("Uma Nf-e desse mesmo modelo já foi Enviada e Autorizadas.");
                    else if (nfeControle.Modelo.Equals(NfeControle.MODELO_NFE) && modelo.Equals(NfeControle.MODELO_NFCE))
                        throw new NegocioException("Não é possível emitir a NFC-e. Uma NF-e já foi emitida para esse pedido.");
                }
                IEnumerable<NfeControle> nfeControlesTentativasFalhas = nfeControles.Where(nfeC => nfeC.SituacaoNfe.Equals(NfeControle.SITUACAO_NAO_VALIDADA)
                    || nfeC.SituacaoNfe.Equals(NfeControle.SITUACAO_SOLICITADA));


                Loja lojaOrigem = GerenciadorLoja.GetInstance().Obter(saida.CodLojaOrigem).ElementAtOrDefault(0);

                // Verifica se houve já alguma tentativa de gerar a chave
                if (nfeControlesTentativasFalhas.Count() > 0)
                {
                    nfeControle = nfeControlesTentativasFalhas.ElementAtOrDefault(0);
                    if (string.IsNullOrEmpty(nfeControle.Chave))
                    {
                        nfeControle.DataEmissao = DateTime.Now;
                    }
                }
                else
                {
                    nfeControle = new NfeControle();
                    nfeControle.SituacaoNfe = NfeControle.SITUACAO_SOLICITADA;
                    nfeControle.DataEmissao = DateTime.Now;
                    nfeControle.Correcao = "";
                    nfeControle.MensagemSitucaoCartaCorrecao = "";
                    nfeControle.SituacaoProtocoloCartaCorrecao = "";
                    nfeControle.NumeroProtocoloCartaCorrecao = "";
                    nfeControle.CodLoja = saida.CodLojaOrigem;
                    nfeControle.Modelo = modelo;
                    nfeControle.CodSolicitacao = solicitacao.codSolicitacao;
                    nfeControle.NumeroSequenciaNfe = ObterProximoNumeroSequenciaNfeLoja(lojaOrigem, modelo);
                    nfeControle.CodNfe = GerenciadorNFe.GetInstance().Inserir(nfeControle, saida, solicitacao.ehComplementar, listaSolicitacaoSaida);
                }


                // Verifica se chave já foi gerada
                RecuperarChaveGerada(nfeControle, lojaOrigem, 1);
                nfeControle.Modelo = modelo;
                nfeControle.CodSolicitacao = solicitacao.codSolicitacao;
                if (nfeControle.Chave.Equals(""))
                {
                    //define um documento XML e carrega o seu conteúdo 
                    XmlDocument xmldoc = new XmlDocument();

                    //Cria um novo elemento poemas  e define os elementos autor, titulo e conteudo
                    XmlElement novoGerarChave = xmldoc.CreateElement("gerarChave");
                    XmlElement xmlnNF = xmldoc.CreateElement("nNF");
                    XmlElement xmlserie = xmldoc.CreateElement("serie");
                    XmlElement xmlAAMM = xmldoc.CreateElement("AAMM");
                    XmlElement xmlcnpj = xmldoc.CreateElement("CNPJ");
                    XmlElement xmlMod = xmldoc.CreateElement("mod");

                    xmlnNF.InnerText = nfeControle.NumeroSequenciaNfe.ToString().PadLeft(8, '0');
                    xmlserie.InnerText = "1";
                    xmlAAMM.InnerText = DateTime.Now.Year.ToString().Substring(2, 2) + DateTime.Now.Month.ToString().PadLeft(2, '0');
                    xmlcnpj.InnerText = GerenciadorPessoa.GetInstance().Obter(lojaOrigem.CodPessoa).ElementAt(0).CpfCnpj;
                    xmlMod.InnerText = modelo; //55-NF-e 65-NFC-e

                    //inclui os novos elementos no elemento poemas
                    novoGerarChave.AppendChild(xmlnNF);
                    novoGerarChave.AppendChild(xmlserie);
                    novoGerarChave.AppendChild(xmlMod);
                    novoGerarChave.AppendChild(xmlAAMM);
                    novoGerarChave.AppendChild(xmlcnpj);

                    //inclui o novo elemento no XML
                    xmldoc.AppendChild(novoGerarChave);

                    //Salva a inclusão no arquivo XML
                    xmldoc.Save(lojaOrigem.PastaNfeEnvio + saida.Nfe + "-gerar-chave.xml");

                    RecuperarChaveGerada(nfeControle, lojaOrigem, 10);
                }
                return nfeControle;
            }
            catch (NegocioException nex)
            {
                throw nex;
            }

        }
        /// <summary>
        /// Obtém o próximo número sequencial da nfe válido que ainda não tenha sido usado
        /// </summary>
        /// <param name="codLoja">Identificação da loja</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public int ObterProximoNumeroSequenciaNfeLoja(Loja loja, string modelo)
        {
            try
            {
                if (modelo.Equals(NfeControle.MODELO_NFE))
                    return GerenciadorLoja.GetInstance().IncrementarNumeroNFe(loja.CodLoja, NfeControle.MODELO_NFE);
                return GerenciadorLoja.GetInstance().IncrementarNumeroNFe(loja.CodLoja, NfeControle.MODELO_NFCE);
            }
            catch (Exception e)
            {
                throw new DadosException("Nota Fiscal Eletrônica", e.Message, e);
            }

        }

        private void RecuperarChave(FileInfo[] files)
        {
            IEnumerable<FileInfo> filesChave = files.Where(f => f.FullName.Contains("-ret-gerar-chave.xml"));
            if (filesChave.Count() > 0)
            {
                XmlDocument xmldocRetorno = new XmlDocument();
                xmldocRetorno.Load(filesChave.ElementAt(0).FullName);
                Global.chaveNFe = xmldocRetorno.DocumentElement.InnerText;
                files[0].Delete();
            }
        }

        /// <summary>
        /// Primeiro passo para emissão da nota fiscal é a emissão da chave.
        /// Enquanto a chave não for gerada não pode seguir os próximos passos. 
        /// </summary>
        /// <param name="saida"></param>
        /// <param name="numeroTentativasGerarChave"></param>
        /// <returns></returns>
        private void RecuperarChaveGerada(NfeControle nfeControle, Loja lojaOrigem, int numeroTentativasGerarChave)
        {
            Global.chaveNFe = "";
            int tentativas = 0;

            while (Global.chaveNFe.Equals("") && tentativas < numeroTentativasGerarChave)
            {
                if (string.IsNullOrWhiteSpace(Global.chaveNFe) && numeroTentativasGerarChave > 1)
                    Thread.Sleep(500);
                tentativas++;
            }

            if (tentativas > 1 && tentativas >= numeroTentativasGerarChave && string.IsNullOrEmpty(Global.chaveNFe))
                throw new NegocioException("Ocorreram problemas/lentidão na geração da chave da NF-e. Verifique se o certificado está conectado e a internet disponível. Favor tentar novamente em alguns minutos.");
            nfeControle.Chave = Global.chaveNFe;
            nfeControle.DataEmissao = DateTime.Now;
            nfeControle.SituacaoNfe = NfeControle.SITUACAO_SOLICITADA;
            Atualizar(nfeControle);
        }

        /// <summary>
        /// Após o envio da Nf-e o Unidanfe gera um número de lote automático para
        /// controlar na aplicação.
        /// </summary>
        /// <param name="nfeControle"></param>
        /// <returns></returns>
        public string RecuperarLoteEnvio(Loja loja)
        {
            DirectoryInfo Dir = new DirectoryInfo(loja.PastaNfeRetorno);
            string numeroLote = "";
            if (Dir.Exists)
            {
                // Busca automaticamente todos os arquivos em todos os subdiretórios
                string arquivoRetornoLote = "*.*";
                FileInfo[] files = Dir.GetFiles(arquivoRetornoLote, SearchOption.TopDirectoryOnly);
                for (int i = 0; i < files.Length; i++)
                {
                    if (files[i].Name.Length > 45)
                    {
                        string chave = files[i].Name.Substring(0, 44);
                        NfeControle nfeControle = ObterPorChave(chave).ElementAtOrDefault(0);

                        if (nfeControle != null)
                        {
                            if (files[i].Name.Contains("-sit.err"))
                            {
                                files[i].CopyTo(loja.PastaNfeErro + files[i].Name, true);
                                files[i].Delete();
                            }
                            if (files[i].Name.Contains("nfe-ret.xml"))
                            {
                                files[i].CopyTo(loja.PastaNfeErro + files[i].Name, true);
                                nfeControle.SituacaoNfe = NfeControle.SITUACAO_CONTINGENCIA_OFFLINE;
                                files[i].Delete();
                            }
                            if (files[i].Name.Contains("nfe.err"))
                            {
                                files[i].CopyTo(loja.PastaNfeErro + files[i].Name, true);
                                nfeControle.SituacaoNfe = NfeControle.SITUACAO_NAO_VALIDADA;
                                files[i].Delete();
                            }
                            else if (files[i].Name.Contains("-num-lot."))
                            {
                                XmlDocument xmldocRetorno = new XmlDocument();
                                xmldocRetorno.Load(loja.PastaNfeRetorno + files[i].Name);

                                numeroLote = xmldocRetorno.DocumentElement.InnerText;
                                nfeControle.NumeroLoteEnvio = numeroLote.PadLeft(15, '0');
                                files[i].Delete();
                            }
                            GerenciadorNFe.GetInstance().Atualizar(nfeControle);
                            if (nfeControle.SituacaoNfe.Equals(NfeControle.SITUACAO_NAO_VALIDADA))
                                GerenciadorSaida.GetInstance(null).AtualizarSaidasPorNfeSituacao(nfeControle);
                        }
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
        public string RecuperarReciboEnvioNfe(string pastaNfeRetorno)
        {
            DirectoryInfo Dir = new DirectoryInfo(pastaNfeRetorno);
            string numeroRecibo = "";
            if (Dir.Exists)
            {
                // Busca automaticamente todos os arquivos em todos os subdiretórios
                string arquivoRetornoEnvioNfe = "*-rec.*";
                FileInfo[] files = Dir.GetFiles(arquivoRetornoEnvioNfe, SearchOption.TopDirectoryOnly);
                for (int i = 0; i < files.Length; i++)
                {
                    // nesse momento deve enviar nfce em ambiente de contigencia 
                    if (files[i].Name.Contains("-rec.err"))
                    {
                        string numeroLote = files[i].Name.Substring(0, 15);
                        NfeControle nfeControle = ObterPorLote(numeroLote).LastOrDefault();

                        Loja loja = GerenciadorLoja.GetInstance().Obter(Global.LOJA_PADRAO).FirstOrDefault();
                        if (loja != null)
                            files[i].CopyTo(loja.PastaNfeErro + files[i].Name, true);
                        files[i].Delete();
                        if (nfeControle != null)
                            EmitirNfeContigencia(nfeControle, loja);
                    }
                    else if (files[i].Name.Contains("-pro-rec."))
                    {
                        // não processa nesse método
                    }
                    else if (files[i].Name.Contains("-rec.txt"))
                    {
                        files[i].Delete();
                    }
                    else
                    {
                        XmlDocument xmldocRetorno = new XmlDocument();
                        xmldocRetorno.Load(pastaNfeRetorno + files[i].Name);
                        XmlNodeReader xmlReaderRetorno = new XmlNodeReader(xmldocRetorno.DocumentElement);

                        string numeroLote = files[i].Name.Substring(0, 15);
                        NfeControle nfeControle = ObterPorLote(numeroLote).LastOrDefault();

                        if (nfeControle != null)
                        {
                            //MemoryStream memStream = new MemoryStream(
                            XmlSerializer serializer = new XmlSerializer(typeof(TRetEnviNFe));
                            TRetEnviNFe retornoEnvioNfe = (TRetEnviNFe)serializer.Deserialize(xmlReaderRetorno);


                            if (retornoEnvioNfe.cStat.Equals(NfeStatusResposta.NFE103_LOTE_RECEBIDO_SUCESSO))
                            {
                                if (retornoEnvioNfe.Item != null)
                                {
                                    numeroRecibo = ((TRetEnviNFeInfRec)retornoEnvioNfe.Item).nRec;
                                    nfeControle.NumeroRecibo = numeroRecibo;
                                }
                            }
                            nfeControle.SituacaoReciboEnvio = retornoEnvioNfe.cStat;
                            nfeControle.MensagemSituacaoReciboEnvio = retornoEnvioNfe.xMotivo;
                            GerenciadorNFe.GetInstance().Atualizar(nfeControle);
                            files[0].Delete();
                        }
                    }
                }
            }
            return numeroRecibo;
        }

        private void EmitirNfeContigencia(NfeControle nfeControle, Loja loja)
        {
            XmlDocument xmldocRetorno = new XmlDocument();
            xmldocRetorno.Load(loja.PastaNfeEnviado + nfeControle.Chave + "-nfe.xml");
            XmlNodeReader xmlReaderRetorno = new XmlNodeReader(xmldocRetorno.DocumentElement);
            XmlSerializer serializer = new XmlSerializer(typeof(TNFe));
            TNFe nfe = (TNFe)serializer.Deserialize(xmlReaderRetorno);

            nfe.infNFe.ide.tpEmis = TNFeInfNFeIdeTpEmis.Item9; // contingencia
            nfe.infNFe.ide.dhCont = ((DateTime)nfeControle.DataEmissao).ToString(FORMATO_DATA_HORA);
            nfe.infNFe.ide.xJust = "Falha de comunicacao com a SEFAZ";

            MemoryStream memStream = new MemoryStream();
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "http://www.portalfiscal.inf.br/nfe");
            serializer.Serialize(memStream, nfe, ns);

            memStream.Position = 0;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(memStream);
            xmlDoc.Save(loja.PastaNfeValidar + nfeControle.Chave + "-nfe.xml");

        }

        private static bool alterouConfiguracaoSucesso(Loja loja)
        {
            bool alterouConfiguracaoComSucesso = false;
            DirectoryInfo pastaRetorno = new DirectoryInfo(loja.PastaNfeRetorno);
            if (pastaRetorno.Exists)
            {
                // Busca automaticamente todos os arquivos em todos os subdiretórios
                FileInfo[] Files = pastaRetorno.GetFiles("uninfe-ret-alt-con.txt", SearchOption.TopDirectoryOnly);
                foreach (FileInfo file in Files)
                {
                    try
                    {
                        string linha;
                        StreamReader reader = new StreamReader(file.FullName);
                        if ((linha = reader.ReadLine()) != null)
                        {
                            alterouConfiguracaoComSucesso = linha.EndsWith("cStat|1");
                        }
                        reader.Close();
                        file.Delete();
                    }
                    catch (Exception e)
                    {
                    }
                }
            }
            return alterouConfiguracaoComSucesso;
        }

        public string RecuperarResultadoProcessamentoNfe(string pastaNfeRetorno)
        {
            DirectoryInfo Dir = new DirectoryInfo(pastaNfeRetorno);
            string numeroProtocolo = "";
            if (Dir.Exists)
            {
                // Busca automaticamente todos os arquivos em todos os subdiretórios


                string arquivoRetornoReciboNfe = "*-pro-rec.*";
                FileInfo[] files = Dir.GetFiles(arquivoRetornoReciboNfe, SearchOption.TopDirectoryOnly);
                for (int i = 0; i < files.Length; i++)
                {
                    if (files[i].Name.Contains("-pro-rec.err"))
                    {
                        Loja loja = GerenciadorLoja.GetInstance().Obter(Global.LOJA_PADRAO).FirstOrDefault();
                        if (loja != null)
                            files[i].CopyTo(loja.PastaNfeErro + files[i].Name, true);
                        files[i].Delete();
                    }
                    else if (files[i].Name.Contains("-pro-rec.txt"))
                    {
                        files[i].Delete(); // não precisa do arquivo texto
                    }
                    else
                    {
                        XmlDocument xmldocRetorno = new XmlDocument();
                        xmldocRetorno.Load(pastaNfeRetorno + files[i].Name);
                        XmlNodeReader xmlReaderRetorno = new XmlNodeReader(xmldocRetorno.DocumentElement);

                        string numero = files[i].Name.Substring(0, 15);  // pode ser o número do lote ou do recibo
                        NfeControle nfeControle = ObterPorLote(numero).LastOrDefault();
                        // Retorno no caso de envio assíncrono
                        if (nfeControle == null)
                        {
                            nfeControle = ObterPorRecibo(numero).LastOrDefault();
                            if (nfeControle != null)
                            {
                                XmlSerializer serializer = new XmlSerializer(typeof(TRetConsReciNFe));
                                TRetConsReciNFe retornoConsReciboNfe = (TRetConsReciNFe)serializer.Deserialize(xmlReaderRetorno);
                                if (retornoConsReciboNfe.cStat.Equals(NfeStatusResposta.NFE104_LOTE_PROCESSADO))
                                {
                                    TProtNFeInfProt protocoloNfe = retornoConsReciboNfe.protNFe[0].infProt;
                                    if (protocoloNfe.chNFe.Equals(nfeControle.Chave))
                                    {
                                        if (protocoloNfe.cStat.Equals(NfeStatusResposta.NFE100_AUTORIZADO_USO_NFE))
                                        {
                                            numeroProtocolo = protocoloNfe.nProt;
                                            nfeControle.NumeroProtocoloUso = protocoloNfe.nProt;
                                            nfeControle.SituacaoNfe = NfeControle.SITUACAO_AUTORIZADA;
                                        }
                                        else if (protocoloNfe.cStat.Equals(NfeStatusResposta.NFE110_USO_DENEGADO))
                                        {
                                            nfeControle.SituacaoNfe = NfeControle.SITUACAO_DENEGADA;
                                        }
                                        else
                                        {
                                            nfeControle.SituacaoNfe = NfeControle.SITUACAO_REJEITADA;
                                        }
                                        nfeControle.SituacaoProtocoloUso = protocoloNfe.cStat;
                                        nfeControle.MensagemSitucaoProtocoloUso = protocoloNfe.xMotivo;

                                    }
                                }
                                nfeControle.SituacaoReciboEnvio = retornoConsReciboNfe.cStat;
                                nfeControle.MensagemSituacaoReciboEnvio = retornoConsReciboNfe.xMotivo;
                                GerenciadorNFe.GetInstance().Atualizar(nfeControle);
                            }
                            files[i].Delete();
                        }
                        // Retorno no caso de envio síncrono
                        else
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(TRetEnviNFe));
                            TRetEnviNFe retornoEnvioNfe = (TRetEnviNFe)serializer.Deserialize(xmlReaderRetorno);
                            if (retornoEnvioNfe.cStat.Equals(NfeStatusResposta.NFE104_LOTE_PROCESSADO))
                            {
                                TProtNFeInfProt protocoloNfe = ((TProtNFe)retornoEnvioNfe.Item).infProt;
                                nfeControle = ObterPorChave(protocoloNfe.chNFe).OrderBy(nfe => nfe.CodNfe).ToList().LastOrDefault();
                                
                                if (protocoloNfe.cStat.Equals(NfeStatusResposta.NFE100_AUTORIZADO_USO_NFE))
                                {
                                    numeroProtocolo = protocoloNfe.nProt;
                                    nfeControle.NumeroProtocoloUso = protocoloNfe.nProt;
                                    nfeControle.SituacaoNfe = NfeControle.SITUACAO_AUTORIZADA;
                                }
                                else if (protocoloNfe.cStat.Equals(NfeStatusResposta.NFE110_USO_DENEGADO))
                                {
                                    nfeControle.SituacaoNfe = NfeControle.SITUACAO_DENEGADA;
                                }
                                else
                                {
                                    nfeControle.SituacaoNfe = NfeControle.SITUACAO_REJEITADA;
                                }
                                nfeControle.SituacaoProtocoloUso = protocoloNfe.cStat;
                                nfeControle.MensagemSitucaoProtocoloUso = protocoloNfe.xMotivo;

                                //}
                                files[0].Delete();
                            }
                            nfeControle.SituacaoReciboEnvio = retornoEnvioNfe.cStat;
                            nfeControle.MensagemSituacaoReciboEnvio = retornoEnvioNfe.xMotivo;
                            GerenciadorNFe.GetInstance().Atualizar(nfeControle);

                        }
                        if (nfeControle != null)
                            GerenciadorSaida.GetInstance(null).AtualizarSaidasPorNfeSituacao(nfeControle);
                    }
                }
            }
            return numeroProtocolo;
        }

        public TNfeProc LerNFE(string arquivo)
        {
            XmlDocument xmldocRetorno = new XmlDocument();
            StreamReader reader = new StreamReader(arquivo);
            xmldocRetorno.Load(reader);
            reader.Close();
                  
            XmlNodeReader xmlReaderRetorno = new XmlNodeReader(xmldocRetorno.DocumentElement);
            XmlSerializer serializer = new XmlSerializer(typeof(TNfeProc));
            TNfeProc nfe = (TNfeProc)serializer.Deserialize(xmlReaderRetorno);

            return nfe;
        }

        public void EnviarNFE(List<tb_solicitacao_saida> listaSolicitacaoSaida, List<tb_solicitacao_pagamento> listaSaidaPagamentos, DocumentoFiscal.TipoSolicitacao modelo, tb_solicitacao_documento solicitacao)
        {
            Saida saida = GerenciadorSaida.GetInstance(null).Obter(listaSolicitacaoSaida.FirstOrDefault().codSaida);

            // Clientes que não pode ser impresso CFe
            Loja loja = GerenciadorLoja.GetInstance().Obter(saida.CodLojaOrigem).ElementAtOrDefault(0);
            Pessoa pessoaloja = GerenciadorPessoa.GetInstance().Obter(loja.CodPessoa).ElementAtOrDefault(0);
            Pessoa destinatario;
            if (saida.TipoSaida.Equals(Saida.TIPO_BAIXA_ESTOQUE_PERDA) || saida.TipoSaida.Equals(Saida.TIPO_USO_INTERNO))
                destinatario = pessoaloja;
            else
                destinatario = GerenciadorPessoa.GetInstance().Obter(saida.CodCliente).ElementAtOrDefault(0);
            
            if ((destinatario.ImprimirCF) || (destinatario.CodMunicipioIBGE != pessoaloja.CodMunicipioIBGE))
                modelo = DocumentoFiscal.TipoSolicitacao.NFE;


            NfeControle nfeControle;
            if (modelo.Equals(DocumentoFiscal.TipoSolicitacao.NFE))
                nfeControle = GerarChaveNFE(saida, solicitacao, NfeControle.MODELO_NFE, listaSolicitacaoSaida);
            else
                nfeControle = GerarChaveNFE(saida, solicitacao, NfeControle.MODELO_NFCE, listaSolicitacaoSaida);

            if (string.IsNullOrEmpty(nfeControle.Chave))
                return;
            //bool haPagamentoCartao = listaSaidaPagamentos.Where(s => s.codFormaPagamento.Equals(FormaPagamento.CARTAO)).Count() > 0;
            //if (haPagamentoCartao)
            //{
            // GerenciadorSolicitacaoDocumento gSolicitacaoDocumento = new GerenciadorSolicitacaoDocumento();
            //gSolicitacaoDocumento.SolicitarAutorizacaoCartao(nfeControle.CodNfe, listaSaidaPagamentos, listaSolicitacaoSaida.FirstOrDefault().codSolicitacao);
            //}


            try
            {
                nfeControle = Obter(nfeControle.CodNfe).ElementAtOrDefault(0);


                // utilizado como padrão quando não especificado pelos produtos
                string cfopPadrao = GerenciadorSaida.GetInstance(null).ObterCfopTipoSaida(saida.TipoSaida).ToString();
               

                TNFe nfe = new TNFe();

                //Informacoes NFe
                TNFeInfNFe infNFe = new TNFeInfNFe();
                infNFe.versao = "4.00";
                infNFe.Id = "NFe" + nfeControle.Chave;
                nfe.infNFe = infNFe;


                //Ide
                TNFeInfNFeIde infNFeIde = new TNFeInfNFeIde();
                infNFeIde.cNF = nfeControle.Chave.Substring(35, 8); // código composto por 8 dígitos sequenciais
                infNFeIde.cDV = nfeControle.Chave.Substring(43, 1);


                infNFeIde.cMunFG = loja.CodMunicipioIBGE.ToString();
                infNFeIde.cUF = (TCodUfIBGE)Enum.Parse(typeof(TCodUfIBGE), "Item" + loja.CodMunicipioIBGE.ToString().Substring(0, 2));
                infNFeIde.mod = (nfeControle.Modelo.Equals(NfeControle.MODELO_NFE)) ? TMod.Item55 : TMod.Item65;

                infNFeIde.dhEmi = ((DateTime)nfeControle.DataEmissao).ToString(FORMATO_DATA_HORA);
                if (nfeControle.Modelo.Equals(NfeControle.MODELO_NFE))
                    infNFeIde.dhSaiEnt = ((DateTime)nfeControle.DataEmissao).ToString(FORMATO_DATA_HORA);

                if (solicitacao.ehComplementar)
                    infNFeIde.finNFe = TFinNFe.Item2; //1 - Normal / 2 NF-e complementar / 3 - Nf-e Ajuste / 4 - devolução
                if ((saida.TipoSaida == Saida.TIPO_DEVOLUCAO_FORNECEDOR) || (saida.TipoSaida == Saida.TIPO_DEVOLUCAO_CONSUMIDOR) ||
                    (saida.TipoSaida == Saida.TIPO_RETORNO_FORNECEDOR))
                    infNFeIde.finNFe = TFinNFe.Item4;
                else
                    infNFeIde.finNFe = TFinNFe.Item1;
                infNFeIde.natOp = GerenciadorCfop.GetInstance().Obter(Convert.ToInt32(cfopPadrao)).ElementAtOrDefault(0).Descricao;
                infNFeIde.nNF = nfeControle.NumeroSequenciaNfe.ToString(); // número do Documento Fiscal
                infNFeIde.procEmi = TProcEmi.Item0; //0 - Emissão do aplicativo do contribuinte
                infNFeIde.serie = "1";
                infNFeIde.tpAmb = (TAmb)Enum.Parse(typeof(TAmb), "Item" + Global.AMBIENTE_NFE); // 1-produção / 2-homologação
                infNFeIde.tpEmis = TNFeInfNFeIdeTpEmis.Item1; // 1-emissão Normal 9-emissao off-line
                infNFeIde.tpImp = (nfeControle.Modelo.Equals(NfeControle.MODELO_NFE)) ? TNFeInfNFeIdeTpImp.Item1 : TNFeInfNFeIdeTpImp.Item4; // 1-Retratro / 2-Paisagem 3-Simplificado 4-Danfe NFCE
                if ((saida.TipoSaida == Saida.TIPO_DEVOLUCAO_CONSUMIDOR) || (saida.TipoSaida == Saida.TIPO_RETORNO_FORNECEDOR))
                    infNFeIde.tpNF = TNFeInfNFeIdeTpNF.Item0; // 0 - entrada / 1 - saída de produtos
                else
                    infNFeIde.tpNF = TNFeInfNFeIdeTpNF.Item1; // 0 - entrada / 1 - saída de produtos
                infNFeIde.verProc = "SACE 4.0"; //versão do aplicativo de emissão de nf-e   

                // adicionar referencia para cupom fiscal, nfc-e ou nfe autorizado.
                NfeControle nfeControleAutorizada = AdicionarReferenciaNFCupomAutorizado(saida, destinatario, infNFeIde);

                NfeControle nfeControleAutorizadaComp = null;
                if (solicitacao.ehComplementar)
                {
                    TNFeInfNFeIdeNFref refNfe = new TNFeInfNFeIdeNFref();
                    refNfe.ItemElementName = ItemChoiceType1.refNFe;
                    nfeControleAutorizadaComp = GerenciadorNFe.GetInstance().ObterPorSaida(saida.CodSaida).Where(nfeC => nfeC.SituacaoNfe == NfeControle.SITUACAO_AUTORIZADA).ElementAtOrDefault(0);
                    if (nfeControleAutorizadaComp == null)
                        throw new NegocioException("Não é possível emitir uma NF-e Complementar de imposto quando não houve Nf-e Autorizadas.");
                    else
                        refNfe.Item = nfeControleAutorizadaComp.Chave;
                    infNFeIde.NFref = new TNFeInfNFeIdeNFref[1];
                    infNFeIde.NFref[0] = refNfe;
                }


                // Versão 3.1 da nf-e
                if (pessoaloja.Uf.Equals(destinatario.Uf) || String.IsNullOrEmpty(destinatario.Uf))
                    infNFeIde.idDest = TNFeInfNFeIdeIdDest.Item1; //1- interna; 2-interestadual; 3-exterior
                else
                    infNFeIde.idDest = TNFeInfNFeIdeIdDest.Item2;

                infNFeIde.indFinal = TNFeInfNFeIdeIndFinal.Item1; // 0 - normal; 1-consumidor final
                if (Saida.LISTA_TIPOS_DEVOLUCAO_FORNECEDOR.Contains(saida.TipoSaida) ||
                        Saida.LISTA_TIPOS_RETORNO_FORNECEDOR.Contains(saida.TipoSaida))
                    infNFeIde.indFinal = TNFeInfNFeIdeIndFinal.Item0;
                if (saida.TipoSaida.Equals(Saida.TIPO_PRE_VENDA) || saida.TipoSaida.Equals(Saida.TIPO_VENDA))
                    infNFeIde.indPres = TNFeInfNFeIdeIndPres.Item1; //1- presencial; 2-internet; 3-teleatendimento; 4-nfc-e com entrega domicilio 
                else
                    infNFeIde.indPres = TNFeInfNFeIdeIndPres.Item0; // 0 - não se aplica; 

                nfe.infNFe.ide = infNFeIde;

                ////Endereco Emitente
                TEnderEmi enderEmit = new TEnderEmi();

                enderEmit.CEP = pessoaloja.Cep;
                enderEmit.cMun = pessoaloja.CodMunicipioIBGE.ToString();
                enderEmit.cPais = TEnderEmiCPais.Item1058;
                enderEmit.fone = pessoaloja.Fone1;
                enderEmit.nro = pessoaloja.Numero;
                enderEmit.UF = (TUfEmi)Enum.Parse(typeof(TUfEmi), pessoaloja.Uf);
                enderEmit.xBairro = pessoaloja.Bairro.Trim();
                if (!string.IsNullOrEmpty(pessoaloja.Complemento))
                    enderEmit.xCpl = pessoaloja.Complemento.Trim();
                enderEmit.xLgr = pessoaloja.Endereco.Trim();
                enderEmit.xMun = Util.StringUtil.RemoverAcentos(pessoaloja.NomeMunicipioIBGE);
                enderEmit.xPais = TEnderEmiXPais.BRASIL;

				////Emitente
				TNFeInfNFeEmit emit = new TNFeInfNFeEmit
				{
					CRT = TNFeInfNFeEmitCRT.Item1,   // 1- Simples Nacional
					IE = pessoaloja.Ie.Trim(),
					enderEmit = enderEmit,
					xFant = pessoaloja.NomeFantasia.Trim(),
					xNome = pessoaloja.Nome.Trim(),
					Item = pessoaloja.CpfCnpj.Trim()
				};

				nfe.infNFe.emit = emit;


                ////Destinatario
                if (!destinatario.CodPessoa.Equals(Global.CLIENTE_PADRAO) && !String.IsNullOrWhiteSpace(destinatario.Nome)
                    && !String.IsNullOrWhiteSpace(destinatario.CpfCnpj) && nfeControle.Modelo.Equals(NfeControle.MODELO_NFE))
                {

                    TNFeInfNFeDest dest = new TNFeInfNFeDest();
                    if (Global.AMBIENTE_NFE.Equals("1")) //produção
                        dest.xNome = destinatario.Nome.Trim();
                    else
                        dest.xNome = "NF-E EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL";
                    dest.Item = destinatario.CpfCnpj;
                    dest.ItemElementName = ItemChoiceType3.CPF;
                    if ((destinatario.CpfCnpj.Length > 11) && !String.IsNullOrWhiteSpace(destinatario.Ie) && !destinatario.Ie.StartsWith("I"))
                    {
                        dest.ItemElementName = ItemChoiceType3.CNPJ;
                        dest.IE = destinatario.Ie;
                        dest.indIEDest = TNFeInfNFeDestIndIEDest.Item1; // 1-Contribuinte ICMS
                        

                    }
                    else if (destinatario.CpfCnpj.Length > 11 && (String.IsNullOrWhiteSpace(destinatario.Ie) || destinatario.Ie.StartsWith("I")))
                    {
                        dest.ItemElementName = ItemChoiceType3.CNPJ;
                        //dest.IE = "ISENTO";
                        dest.indIEDest = TNFeInfNFeDestIndIEDest.Item9; // 2-Contribuinte ISENTO (não existe) Agora é sempre 9
                    }
                    else
                    {
                        dest.indIEDest = TNFeInfNFeDestIndIEDest.Item9; // 9-Não contribuinte, que pode ou não possui ie
                    }
                    if (!String.IsNullOrWhiteSpace(destinatario.Email))
                        dest.email = destinatario.Email.Trim();
                    nfe.infNFe.dest = dest;

                    ////Endereco destinatario
                    TEndereco enderDest = new TEndereco();
                    enderDest.CEP = destinatario.Cep.Trim();
                    enderDest.cMun = destinatario.CodMunicipioIBGE.ToString();
                    enderDest.cPais = "1058"; //Brasil
                    enderDest.xPais = "Brasil";
                    enderDest.fone = destinatario.Fone1;
                    enderDest.nro = destinatario.Numero.Trim();
                    enderDest.UF = (TUf)Enum.Parse(typeof(TUf), destinatario.Uf);
                    enderDest.xBairro = destinatario.Bairro.Trim();
                    if (!string.IsNullOrEmpty(destinatario.Complemento))
                        enderDest.xCpl = destinatario.Complemento.Trim();
                    enderDest.xLgr = destinatario.Endereco.Trim();
                    enderDest.xMun = Util.StringUtil.RemoverAcentos(destinatario.NomeMunicipioIBGE);
                    dest.enderDest = enderDest;
                }
                else if (!String.IsNullOrWhiteSpace(saida.CpfCnpj))
                {
                    TNFeInfNFeDest dest = new TNFeInfNFeDest();
                    if (Global.AMBIENTE_NFE.Equals("1")) //produção
                        dest.xNome = destinatario.Nome.Trim();
                    else
                        dest.xNome = "NF-E EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL";
                    dest.Item = saida.CpfCnpj;
                    dest.ItemElementName = ItemChoiceType3.CPF;
                    dest.indIEDest = TNFeInfNFeDestIndIEDest.Item9; // 9-Não contribuinte, que pode ou não possui ie
                    if (saida.CpfCnpj.Length > 11)
                    {
                        dest.ItemElementName = ItemChoiceType3.CNPJ;
                    }
                    nfe.infNFe.dest = dest;
                }

                //totais da nota
                List<TNFeInfNFeDet> listaNFeDet = new List<TNFeInfNFeDet>();
                List<SaidaProduto> saidaProdutos = new List<SaidaProduto>();
                List<SaidaPesquisa> listaSaidas = new List<SaidaPesquisa>();
                //decimal totalProdutos = 0;
                decimal totalSaidas = 0;
                decimal totalTributos = 0;
                decimal valorTotalDesconto = 0;
                decimal totalVProd = 0;
                decimal totalVDesc = 0;
                CultureInfo culturePonto = new CultureInfo("en-US");
                    
                if (solicitacao.ehComplementar)
                {
                    PreencherProdutoNFEComplementar(saida, nfeControleAutorizadaComp, listaNFeDet);
                }
                else
                {
                    if (saida.TipoSaida == Saida.TIPO_VENDA)
                    {
                        if (nfeControleAutorizada != null)
                            saidaProdutos = GerenciadorSaidaProduto.GetInstance(null).ObterPorNfeControle(nfeControleAutorizada.CodNfe);
                        else
                            saidaProdutos = GerenciadorSaidaProduto.GetInstance(null).ObterPorPedido(saida.CupomFiscal);
                    }
                    else if (saida.TipoSaida == Saida.TIPO_PRE_VENDA)
                    {
                        saidaProdutos = GerenciadorSaidaProduto.GetInstance(null).ObterPorSolicitacaoSaidas(listaSolicitacaoSaida);
                    }
                    else
                    {
                        saidaProdutos = GerenciadorSaidaProduto.GetInstance(null).ObterPorSaida(saida.CodSaida);
                    }
                    saidaProdutos = GerenciadorSaida.GetInstance(null).ExcluirProdutosDevolvidosMesmoPreco(saidaProdutos);

                    if (saidaProdutos.Count == 0)
                    {
                        List<long> listaCodSaidas = (List<long>)listaSolicitacaoSaida.Select(s => s.codSaida).ToList();
                        foreach (long codSaida in listaCodSaidas)
                            GerenciadorSaidaPedido.GetInstance().Atualizar(new SaidaPedido() { CodSaida = codSaida, CodPedido = codSaida, TotalAVista = totalSaidas });
                        return;
                    }

                    int nItem = 1; // número do item processado

                    if (saida.TipoSaida.Equals(Saida.TIPO_VENDA))
                    {
                        //totalProdutos = saidaProdutos.Where(sp => sp.Quantidade > 0).Sum(sp => sp.Subtotal);
                        listaSaidas = GerenciadorSaida.GetInstance(null).ObterPorCupomFiscal(saida.CupomFiscal);

                        totalSaidas = listaSaidas.Where(s => s.TipoSaida == Saida.TIPO_VENDA).Sum(s => s.TotalAVista);
                    }
                    else if (saida.TipoSaida.Equals(Saida.TIPO_PRE_VENDA))
                    {
                        //totalProdutos = saidaProdutos.Where(sp => sp.Quantidade > 0).Sum(sp => sp.Subtotal);
                        listaSaidas = GerenciadorSaida.GetInstance(null).ObterPorSolicitacaoSaida(listaSolicitacaoSaida);

                        totalSaidas = listaSaidas.Where(s => s.TipoSaida == Saida.TIPO_PRE_VENDA).Sum(s => s.TotalAVista);
                    }
                    else if (saida.TipoSaida.Equals(Saida.TIPO_DEVOLUCAO_FORNECEDOR))
                    {
                        totalSaidas = saidaProdutos.Where(sp => sp.Quantidade > 0).Sum(sp => sp.SubtotalAVista) - saida.Desconto;
                    }
                    else
                    {
                        totalSaidas = saidaProdutos.Where(sp => sp.Quantidade > 0).Sum(sp => sp.SubtotalAVista);
                        //totalSaidas = saidaProdutos.Where(sp => sp.Quantidade > 0).Sum(sp => sp.SubtotalAVista) - saida.Desconto;
                    }

                    List<SaidaProduto> listaSaidaProdutosNfe = new List<SaidaProduto>();
                    foreach (SaidaProduto saidaProduto in saidaProdutos)
                    {
                        if ((!destinatario.ImprimirCF) && (saidaProduto.CodCST.Contains(Cst.ST_OUTRAS)))
                        {
                            totalSaidas -= saidaProduto.SubtotalAVista;
                        }
                        else
                        {
                            listaSaidaProdutosNfe.Add(saidaProduto);
                        }
                    }
                    saidaProdutos = listaSaidaProdutosNfe;


                    // distribui desconto entre todos os produtos da nota
                    saidaProdutos = DistribuirDescontoProdutos(saidaProdutos, totalSaidas);

                    // Atualiza os produtos com os valores de impostos
                    saidaProdutos = GerenciadorImposto.GetInstance().CalcularValorImpostoProdutos(saidaProdutos);
                    totalTributos = saidaProdutos.Sum(sp => sp.ValorImposto);

                    foreach (SaidaProduto saidaProduto in saidaProdutos)
                    {
                        if (saidaProduto.Quantidade > 0)
                        {
                            TNFeInfNFeDetProd prod = new TNFeInfNFeDetProd();
                            prod.cProd = saidaProduto.CodProduto.ToString();
                            ProdutoPesquisa produto = GerenciadorProduto.GetInstance().Obter(saidaProduto.CodProduto).ElementAtOrDefault(0);


                            if (Validacoes.ValidarEAN13(produto.CodigoBarra))
                            {
                                prod.cEANTrib = produto.CodigoBarra;
                                prod.cEAN = produto.CodigoBarra;
                            }
                            else
                            {
                                prod.cEANTrib = "SEM GTIN";
                                prod.cEAN = "SEM GTIN";
                            }

                            

                            if (infNFeIde.idDest.Equals(TNFeInfNFeIdeIdDest.Item2) && (saidaProduto.CodCfop <= 6000) && (saidaProduto.CodCfop >= 5000))
                                saidaProduto.CodCfop += 1000; // cfop vira interestadual 5405 => 6405

                            // devolução de consumidor interestadual
                            if (infNFeIde.idDest.Equals(TNFeInfNFeIdeIdDest.Item2) && (saidaProduto.CodCfop == 1202)) 
                                saidaProduto.CodCfop = 2202;

                            // devolução de consumidor interestadual mercadoria substituicao
                            if (infNFeIde.idDest.Equals(TNFeInfNFeIdeIdDest.Item2) && (saidaProduto.CodCfop == 1411))
                                saidaProduto.CodCfop = 2411;
                         
                            //if (saida.TipoSaida.Equals(Saida.TIPO_BAIXA_ESTOQUE))
                            prod.CFOP = cfopPadrao;
                            if (saidaProduto.CodCfop != 0)
                                prod.CFOP = saidaProduto.CodCfop.ToString();
                            if (saida.TipoSaida.Equals(Saida.TIPO_RETORNO_FORNECEDOR))
                                prod.CFOP = "2209";

                            //bool EhEmissaoNfeNfceVenda = (nfeControleAutorizada == null) && String.IsNullOrWhiteSpace(saida.CupomFiscal) && (Saida.LISTA_TIPOS_VENDA.Contains(saida.TipoSaida));
                            bool naoHaNfeAutorizada = (nfeControleAutorizada == null);
                            if (naoHaNfeAutorizada && Saida.LISTA_TIPOS_VENDA.Contains(saida.TipoSaida))
                            {
                                if (infNFeIde.idDest.Equals(TNFeInfNFeIdeIdDest.Item1)) //1- interna; 2-interestadual; 3-exterior
                                {
                                    if (saidaProduto.EhTributacaoIntegral)
                                        prod.CFOP = "5102";
                                    else
                                        prod.CFOP = "5405";
                                }
                                else
                                {
                                    if (saidaProduto.EhTributacaoIntegral)
                                        prod.CFOP = "6102";
                                    else
                                        prod.CFOP = "6404";
                                }
                            }

                            if ((saida.TipoSaida == Saida.TIPO_DEVOLUCAO_FORNECEDOR) || (saida.TipoSaida == Saida.TIPO_REMESSA_CONSERTO) ||
                                (saida.TipoSaida == Saida.TIPO_RETORNO_FORNECEDOR))
                                prod.xProd = produto.NomeProdutoFabricante.Trim();
                            else
                            {
                                if (Global.AMBIENTE_NFE.Equals("2"))
                                {//homologação
                                    prod.xProd = "NOTA FISCAL EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL";
                                    if (!prod.CFOP.StartsWith("1")) // em homologação não aceita cfop 5102
                                        prod.CFOP = "5102";
                                }
                                else
                                    prod.xProd = produto.Nome.Trim();
                            }
                            prod.NCM = produto.Ncmsh;
                            prod.uCom = produto.Unidade;
                            prod.qCom = formataValorNFe(saidaProduto.Quantidade);


                            if ((saida.TipoSaida == Saida.TIPO_PRE_VENDA) || (saida.TipoSaida == Saida.TIPO_VENDA) || (saida.TipoSaida == Saida.TIPO_DEVOLUCAO_CONSUMIDOR))
                            {
                                prod.vUnCom = formataValorNFe(saidaProduto.ValorProdutoNota, 3);
                                //CultureInfo culturePonto = new CultureInfo("en-US");
                                //decimal valorUnComTruncada = Convert.ToDecimal(prod.vUnCom, culturePonto);
                                //decimal valorMultiplicacao = Math.Round(valorUnComTruncada * saidaProduto.Quantidade, 2);
                                prod.vProd = formataValorNFe(Math.Round(saidaProduto.ValorProdutoNota * saidaProduto.Quantidade, 2));
                                prod.vUnTrib = formataValorNFe(saidaProduto.ValorProdutoNota, 3);
                            }
                            else
                            {
                                prod.vUnCom = formataValorNFe(saidaProduto.ValorVendaAVista, 3);
                                prod.vProd = formataValorNFe(saidaProduto.SubtotalAVista);
                                prod.vUnTrib = formataValorNFe(saidaProduto.ValorVendaAVista, 3);
                            }
                            totalVProd += Convert.ToDecimal(prod.vProd, culturePonto);
                            if (Decimal.Parse(formataValorNFe(saidaProduto.ValorDesconto), CultureInfo.InvariantCulture) > 0)
                            {
                                prod.vDesc = formataValorNFe(saidaProduto.ValorDesconto);
                                totalVDesc += Convert.ToDecimal(prod.vDesc, culturePonto);
                                valorTotalDesconto += Decimal.Parse(formataValorNFe(saidaProduto.ValorDesconto), CultureInfo.InvariantCulture);
                            }


                            prod.uTrib = produto.Unidade;

                            prod.qTrib = formataQtdNFe(saidaProduto.Quantidade);
                            prod.indTot = (TNFeInfNFeDetProdIndTot)1; // Valor = 1 deve entrar no valor total da nota

                            if (saida.ValorFrete > 0)
                                prod.vFrete = formataValorNFe(saida.ValorFrete / saida.TotalAVista * saidaProduto.SubtotalAVista);
                            TNFeInfNFeDetImpostoICMS icms = new TNFeInfNFeDetImpostoICMS();
                            if ((saida.TipoSaida == Saida.TIPO_DEVOLUCAO_FORNECEDOR) ||
                                (saida.TipoSaida == Saida.TIPO_RETORNO_FORNECEDOR))
                            {
                                //TNFeInfNFeDetImpostoICMSICMSSN400 icms900 = new TNFeInfNFeDetImpostoICMSICMSSN400();
                                TNFeInfNFeDetImpostoICMSICMSSN900 icms900 = new TNFeInfNFeDetImpostoICMSICMSSN900();
                                icms900.CSOSN = TNFeInfNFeDetImpostoICMSICMSSN900CSOSN.Item900;
                                icms900.orig = Torig.Item0;

                                icms900.vBC = formataValorNFe(saidaProduto.BaseCalculoICMS);
                                icms900.vICMS = formataValorNFe(saidaProduto.ValorICMS);
                                icms900.pICMS = formataValorNFe(0);
                                if (saidaProduto.BaseCalculoICMS > 0)
                                    icms900.pICMS = formataValorNFe(saidaProduto.ValorICMS / saidaProduto.BaseCalculoICMS * 100);
                                icms900.vBCST = formataValorNFe(saidaProduto.BaseCalculoICMSSubst);
                                icms900.vICMSST = formataValorNFe(saidaProduto.ValorICMSSubst);
                                icms900.pICMSST = formataValorNFe(0);
                                if (saidaProduto.BaseCalculoICMSSubst > 0)
                                    icms900.pICMSST = formataValorNFe(saidaProduto.ValorICMSSubst / saidaProduto.BaseCalculoICMSSubst * 100);
                                icms900.pRedBC = formataValorNFe(0);
                                icms.Item = icms900;
                            }
                            //else if (saidaProduto.CodCfop.Equals(Cfop.CUPOM_FISCAL_EMITIDO))
                            //{
                            //    TNFeInfNFeDetImpostoICMSICMSSN102 icms102 = new TNFeInfNFeDetImpostoICMSICMSSN102();
                            //    icms102.CSOSN = TNFeInfNFeDetImpostoICMSICMSSN102CSOSN.Item400;
                            //    icms102.orig = Torig.Item0;
                            //    icms.Item = icms102;
                            //}
                            else if ((saidaProduto.EhTributacaoIntegral) || Global.AMBIENTE_NFE.Equals("2")) //homologação
                            {
                                TNFeInfNFeDetImpostoICMSICMSSN102 icms102 = new TNFeInfNFeDetImpostoICMSICMSSN102();
                                icms102.CSOSN = TNFeInfNFeDetImpostoICMSICMSSN102CSOSN.Item102;
                                icms102.orig = Torig.Item0;
                                icms.Item = icms102;
                            }
                            else
                            {
                                TNFeInfNFeDetImpostoICMSICMSSN500 icms500 = new TNFeInfNFeDetImpostoICMSICMSSN500();
                                icms500.CSOSN = TNFeInfNFeDetImpostoICMSICMSSN500CSOSN.Item500;
                                icms500.orig = Torig.Item0;
                                icms.Item = icms500;
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
                            //imp.vTotTrib = formataValorNFe(saidaProduto.ValorImposto);


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
                            nfeDet.nItem = nItem.ToString();
                            if ((saida.OutrasDespesas > 0 || saida.ValorIPI > 0) && (saida.TipoSaida.Equals(Saida.TIPO_DEVOLUCAO_FORNECEDOR) || saida.TipoSaida.Equals(Saida.TIPO_RETORNO_FORNECEDOR)))
                            {
                                if (saida.OutrasDespesas > 0)
                                {
                                    var valorOutros = saida.OutrasDespesas * (saidaProduto.SubtotalAVista / saida.TotalAVista);
                                    prod.vOutro = formataValorNFe(saidaProduto.ValorIPI + valorOutros);
                                }
                                else
                                {
                                    prod.vOutro = formataValorNFe(saidaProduto.ValorIPI);
                                }
                            }
                            nItem++; // número do item na nf-e
                            listaNFeDet.Add(nfeDet);
                        }
                    }
                }
                nfe.infNFe.det = listaNFeDet.ToArray();

                // Totalizadores de tributos
                TNFeInfNFeTotalICMSTot icmsTot = new TNFeInfNFeTotalICMSTot();
                decimal valorTotalNota = totalSaidas + saida.ValorFrete + saida.OutrasDespesas;

                icmsTot.vFCP = formataValorNFe(0);
                icmsTot.vFCPST = formataValorNFe(0);
                icmsTot.vFCPSTRet = formataValorNFe(0);
                icmsTot.vBC = formataValorNFe(0); // o valor da base de cálculo deve ser a dos produtos.
                icmsTot.vICMS = formataValorNFe(0);
                icmsTot.vBCST = formataValorNFe(0);
                icmsTot.vST = formataValorNFe(0);
                icmsTot.vProd = formataValorNFe(totalVProd);
                icmsTot.vFrete = formataValorNFe(saida.ValorFrete);
                icmsTot.vSeg = formataValorNFe(saida.ValorSeguro);
                //icmsTot.vTotTrib = formataValorNFe(totalTributos);
                icmsTot.vII = formataValorNFe(0);
                icmsTot.vIPI = formataValorNFe(0);
                icmsTot.vIPIDevol = formataValorNFe(0);
                icmsTot.vPIS = formataValorNFe(0);
                icmsTot.vCOFINS = formataValorNFe(0);
                icmsTot.vICMSDeson = formataValorNFe(0);
                icmsTot.vOutro = formataValorNFe(saida.OutrasDespesas);



                if ((saida.TipoSaida == Saida.TIPO_DEVOLUCAO_FORNECEDOR) || (saida.TipoSaida == Saida.TIPO_RETORNO_FORNECEDOR))
                {
                    icmsTot.vBC = formataValorNFe(saida.BaseCalculoICMS); // o valor da base de cálculo deve ser a dos produtos.
                    icmsTot.vICMS = formataValorNFe(saida.ValorICMS);
                    icmsTot.vBCST = formataValorNFe(saida.BaseCalculoICMSSubst);
                    icmsTot.vST = formataValorNFe(saida.ValorICMSSubst);
                    if (saida.ValorIPI > 0)
                    {
                        //icmsTot.vIPI = formataValorNFe(saida.ValorIPI);
                        saida.OutrasDespesas += saida.ValorIPI;
                        icmsTot.vOutro = formataValorNFe(saida.OutrasDespesas);
                    }
                    else
                    {
                        icmsTot.vIPI = formataValorNFe(0); // não pode destacar o total do ipi na nota de devolução
                    }
                    decimal totalProdutos = saidaProdutos.Where(sp => sp.Quantidade > 0).Sum(sp => sp.SubtotalAVista);
                    valorTotalNota = totalProdutos + saida.ValorICMSSubst - saida.Desconto + saida.OutrasDespesas; // +saida.ValorIPI;
                }


                //CultureInfo culturePonto = new CultureInfo("en-US");
                //decimal valorTotalProdutos = Convert.ToDecimal(icmsTot.vProd, culturePonto);


                //decimal somatorioItens = saidaProdutos.Sum(sp => sp.Subtotal);


                //valorTotalDesconto = valorTotalProdutos - valorTotalNota;

                if (totalVDesc >= 0)
                {
                    icmsTot.vDesc = formataValorNFe( totalVDesc );
                }
                else
                {
                    // desconto fica negativo quand tirar cf de um item que não deveria entrar
                    icmsTot.vDesc = formataValorNFe(0);
                }

                if (solicitacao.ehComplementar)
                    icmsTot.vNF = formataValorNFe(saida.OutrasDespesas);
                else
                    icmsTot.vNF = formataValorNFe(valorTotalNota);

                TNFeInfNFeTotal total = new TNFeInfNFeTotal();
                total.ICMSTot = icmsTot;
                nfe.infNFe.total = total;

                TNFeInfNFeTranspTransporta transporta = new TNFeInfNFeTranspTransporta();
                TNFeInfNFeTransp transp = new TNFeInfNFeTransp();
                if ((saida.CodEmpresaFrete == saida.CodCliente) || (saida.CodEmpresaFrete == Global.CLIENTE_PADRAO) || solicitacao.ehComplementar)
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
                    transporta.UFSpecified = true;
                    transporta.xEnder = transportadora.Endereco.Trim();
                    transporta.xMun = Util.StringUtil.RemoverAcentos(transportadora.Cidade);
                    transporta.xNome = transportadora.Nome.Trim();
                    transp.vol = new TNFeInfNFeTranspVol[1];
                    TNFeInfNFeTranspVol volumes = new TNFeInfNFeTranspVol();
                    volumes.esp = saida.EspecieVolumes;
                    volumes.marca = saida.Marca.Trim();
                    volumes.nVol = formataValorNFe(saida.Numero);
                    volumes.pesoB = formataPesoNFe(saida.PesoBruto);
                    volumes.pesoL = formataPesoNFe(saida.PesoLiquido);
                    volumes.qVol = saida.QuantidadeVolumes.ToString("N0");

                    transp.vol[0] = volumes;
                    transp.transporta = transporta;
                    TNFeInfNFeTranspRetTransp retTransp = new TNFeInfNFeTranspRetTransp();
                    retTransp.CFOP = "6352";
                    retTransp.cMunFG = transportadora.CodMunicipioIBGE.ToString();
                    retTransp.vServ = formataValorNFe(saida.ValorFrete);
                    retTransp.vBCRet = "0";
                    retTransp.pICMSRet = "0";
                    retTransp.vICMSRet = "0";

                    transp.retTransp = retTransp;

                }

                nfe.infNFe.transp = transp;

                // Quando existe produtos com cst outros precisa extrair
                if (listaSaidaPagamentos.Sum(sp => sp.valor) > totalSaidas)
                {
                    decimal valorSubtrairPagamentos = listaSaidaPagamentos.Sum(sp => sp.valor) - totalSaidas;
                    decimal percentualSubtrair = valorSubtrairPagamentos / listaSaidaPagamentos.Sum(sp => sp.valor);
                    foreach (tb_solicitacao_pagamento sp in listaSaidaPagamentos)
                    {
                        if (valorSubtrairPagamentos > 0)
                        {
                            if (sp.valor > valorSubtrairPagamentos)
                            {
                                sp.valor -= valorSubtrairPagamentos;
                                valorSubtrairPagamentos = 0;
                            }
                            else
                            {
                                decimal valorindividual = sp.valor * percentualSubtrair;
                                sp.valor -= valorindividual;
                                valorSubtrairPagamentos -= valorindividual;
                            }
                        }
                    }
                }

                // Informações de pagamento da NFE. Obrigatória para NFCE
                if (listaSaidaPagamentos.Count > 0)
                {
                    nfe.infNFe.pag = new TNFeInfNFePag();
                    nfe.infNFe.pag.detPag = new TNFeInfNFePagDetPag[listaSaidaPagamentos.Count];

                    int countPag = 0;
                    foreach (tb_solicitacao_pagamento pagamento in listaSaidaPagamentos)
                    {
                        TNFeInfNFePagDetPag infNfePag = new TNFeInfNFePagDetPag();
                        //infNfePag.card = new TNFeInfNFePagCard() { cAut = "XX", CNPJ = "xxx", tBand = TNFeInfNFePagCardTBand.Item99 }; //01-Visa 02-Master 03-American 04-Sorocred 99-Outros
                        if (pagamento.codFormaPagamento == FormaPagamento.DINHEIRO)
                        {
                            infNfePag.tPag = TNFeInfNFePagDetPagTPag.Item01; //01-DINHEIRO 02-cheque 03-Cartao Credito 04-Cartao DEbito 05-Credito Loja 99-Outros
                            infNfePag.vPag = formataValorNFe(pagamento.valor);
                        }
                        else if (pagamento.codFormaPagamento == FormaPagamento.CARTAO)
                        {
                            infNfePag.tPag = TNFeInfNFePagDetPagTPag.Item03; //01-DINHEIRO 02-cheque 03-Cartao Credito 04-Cartao DEbito 05-Credito Loja 99-Outros
                            infNfePag.vPag = formataValorNFe(pagamento.valor);
                        }
                        else
                        {
                            infNfePag.tPag = TNFeInfNFePagDetPagTPag.Item04; //01-DINHEIRO 02-cheque 03-Cartao Credito 04-Cartao DEbito 05-Credito Loja 99-Outros
                            infNfePag.vPag = formataValorNFe(pagamento.valor);
                        }

                        nfe.infNFe.pag.detPag[countPag] = infNfePag;
                        countPag++;
                    }
                }
                else
                {
                    nfe.infNFe.pag = new TNFeInfNFePag();
                    nfe.infNFe.pag.detPag = new TNFeInfNFePagDetPag[1];

                    TNFeInfNFePagDetPag infNfePag = new TNFeInfNFePagDetPag();
                    infNfePag.tPag = TNFeInfNFePagDetPagTPag.Item90; //01-DINHEIRO 02-cheque 03-Cartao Credito 04-Cartao DEbito 05-Credito Loja 90-Sem pagamento
                    infNfePag.vPag = formataValorNFe(0);
                    nfe.infNFe.pag.detPag[0] = infNfePag;
                }

                ////Informacoes Adicionais
                TNFeInfNFeInfAdic infAdic = new TNFeInfNFeInfAdic();
                //infAdic.infAdFisco = nfeSelected.informacoesAddFisco;
                decimal valorImpostoPercentual = totalTributos / totalSaidas * 100;
                string mensagemTributos = "Valor Aproximado dos Tributos R$ " + totalTributos.ToString("N2") + " (" + valorImpostoPercentual.ToString("N2") + "%)  Fonte: IBPT. ";

                infAdic.infCpl += mensagemTributos;

                if (string.IsNullOrEmpty(saida.CupomFiscal))
                    infAdic.infCpl = Global.NFE_MENSAGEM_PADRAO + mensagemTributos + saida.Observacao;
                else
                    infAdic.infCpl = Global.NFE_MENSAGEM_PADRAO + mensagemTributos + saida.Observacao + ". ICMS RECOLHIDO NO";

                infAdic.infCpl = infAdic.infCpl.Trim();

                if (listaSaidas.Count() > 0)
                {
                    infAdic.infCpl += " Lista Pedido-Data: ";
                    int count = 0;
                    foreach (SaidaPesquisa saidaPesquisa in listaSaidas)
                    {
                        infAdic.infCpl += saidaPesquisa.CodSaida + "-" + saidaPesquisa.DataSaida.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
                        count++;
                        if (listaSaidas.Count > count)
                            infAdic.infCpl += ", ";
                    }
                }
                infAdic.infCpl = infAdic.infCpl.Trim();

                nfe.infNFe.infAdic = infAdic;

                MemoryStream memStream = new MemoryStream();
                XmlSerializer serializer = new XmlSerializer(typeof(TNFe));
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();

                ns.Add("", "http://www.portalfiscal.inf.br/nfe");
                serializer.Serialize(memStream, nfe, ns);


                memStream.Position = 0;
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(memStream);
                if (solicitacao.ehEspelho)
                {
                    xmlDoc.Save(loja.PastaNfeEspelho + nfeControle.Chave + "-nfe.xml");
                }
                else
                {
                    xmlDoc.Save(loja.PastaNfeEnvio + nfeControle.Chave + "-nfe.xml");
                    xmlDoc.Save(loja.PastaNfeEnviado + nfeControle.Chave + "-nfe.xml");
                    nfeControle.SituacaoNfe = NfeControle.SITUACAO_SOLICITADA;
                    Atualizar(nfeControle);
                }
            }
            catch (Exception ex)
            {
                throw new NegocioException("Problemas na geração do arquivo da Nota Fiscal Eletrônica. Favor consultar administrador do sistema.", ex);
            }
        }

        private void PreencherProdutoNFEComplementar(Saida saida, NfeControle nfeControleAutorizadaComp, List<TNFeInfNFeDet> listaNFeDet)
        {
            TNFeInfNFeDetProd prod = new TNFeInfNFeDetProd();
            prod.cProd = "CFOP9999";
            prod.xProd = "Nota Fiscal Complementar da NF-e " + nfeControleAutorizadaComp.NumeroSequenciaNfe + " de " + nfeControleAutorizadaComp.DataEmissao;
            prod.cEAN = "";
            prod.cEANTrib = "";
            prod.CFOP = "6411";
            prod.NCM = "00";
            prod.uCom = "UN";
            prod.qCom = formataValorNFe(0);
            prod.vUnCom = formataValorNFe(0);
            prod.vProd = formataValorNFe(0);
            prod.vUnTrib = formataValorNFe(0);
            prod.vOutro = formataValorNFe(saida.OutrasDespesas);
            //prod.vDesc = formataValorNFe(0);
            prod.uTrib = "UN";
            prod.qTrib = formataValorNFe(0);
            prod.indTot = (TNFeInfNFeDetProdIndTot)0; // Valor = 1 deve entrar no valor total da nota
            //prod.vFrete = formataValorNFe(0);
            TNFeInfNFeDetImpostoICMS icms = new TNFeInfNFeDetImpostoICMS();
            TNFeInfNFeDetImpostoICMSICMSSN102 icms102 = new TNFeInfNFeDetImpostoICMSICMSSN102();
            icms102.CSOSN = TNFeInfNFeDetImpostoICMSICMSSN102CSOSN.Item400;
            icms102.orig = Torig.Item0;

            icms.Item = icms102;

			TNFeInfNFeDetImposto imp = new TNFeInfNFeDetImposto
			{
				Items = new object[] { icms }
			};

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
            nfeDet.nItem = "1"; // número de itens da nota
            listaNFeDet.Add(nfeDet);
        }

        private static NfeControle AdicionarReferenciaNFCupomAutorizado(Saida saida, Pessoa destinatario, TNFeInfNFeIde infNFeIde)
        {
            NfeControle nfeControleAutorizada = GerenciadorNFe.GetInstance().ObterPorSaida(saida.CodSaida).Where(nfeC => nfeC.SituacaoNfe == NfeControle.SITUACAO_AUTORIZADA).ElementAtOrDefault(0);

            if (saida.TipoSaida.Equals(Saida.TIPO_VENDA) || saida.TipoSaida.Equals(Saida.TIPO_PRE_VENDA) ||
                saida.TipoSaida.Equals(Saida.TIPO_DEVOLUCAO_CONSUMIDOR))
            {
                TNFeInfNFeIdeNFref nfeRefNfe = null;
                if (saida.TipoSaida.Equals(Saida.TIPO_DEVOLUCAO_CONSUMIDOR))
                {
                    SaidaPesquisa saidaVendaCupom = GerenciadorSaida.GetInstance(null).ObterPorCupomFiscal(saida.Nfe).ElementAtOrDefault(0);
                    nfeControleAutorizada = GerenciadorNFe.GetInstance().ObterPorSaida(saidaVendaCupom.CodSaida).Where(nfeC => nfeC.SituacaoNfe == NfeControle.SITUACAO_AUTORIZADA).ElementAtOrDefault(0);
                }
                if (nfeControleAutorizada != null)
                {
                    nfeRefNfe = new TNFeInfNFeIdeNFref();
                    nfeRefNfe.ItemElementName = ItemChoiceType1.refNFe;
                    nfeRefNfe.Item = nfeControleAutorizada.Chave;
                    infNFeIde.NFref = new TNFeInfNFeIdeNFref[1];
                    infNFeIde.NFref[0] = nfeRefNfe;
                }

            }
            else if (saida.TipoSaida.Equals(Saida.TIPO_RETORNO_FORNECEDOR))
            {
                TNFeInfNFeIdeNFref nfeRefNfe = null;
                SaidaPesquisa saidaDevolucao = GerenciadorSaida.GetInstance(null).ObterPorCupomFiscal(saida.Marca).ElementAtOrDefault(0);
                nfeControleAutorizada = GerenciadorNFe.GetInstance().ObterPorSaida(saidaDevolucao.CodSaida).Where(nfeC => nfeC.SituacaoNfe == NfeControle.SITUACAO_AUTORIZADA).ElementAtOrDefault(0);
                saida.Marca = "DIVERSAS";
                GerenciadorSaida.GetInstance(null).Atualizar(saida);
                if (nfeControleAutorizada != null)
                {
                    nfeRefNfe = new TNFeInfNFeIdeNFref();
                    nfeRefNfe.ItemElementName = ItemChoiceType1.refNFe;
                    nfeRefNfe.Item = nfeControleAutorizada.Chave;
                    infNFeIde.NFref = new TNFeInfNFeIdeNFref[1];
                    infNFeIde.NFref[0] = nfeRefNfe;
                }

            }
            else if (saida.TipoSaida.Equals(Saida.TIPO_DEVOLUCAO_FORNECEDOR))
            {
                Entrada entrada = GerenciadorEntrada.GetInstance().Obter(saida.CodEntrada).ElementAtOrDefault(0);

                if (String.IsNullOrEmpty(entrada.Chave))
                {
                    TNFeInfNFeIdeNFrefRefNF refNF = new TNFeInfNFeIdeNFrefRefNF();
                    refNF.nNF = entrada.NumeroNotaFiscal;
                    refNF.CNPJ = destinatario.CpfCnpj.Trim();
                    refNF.AAMM = entrada.DataEmissao.ToString("yyMM");
                    refNF.mod = TNFeInfNFeIdeNFrefRefNFMod.Item01;
                    refNF.serie = entrada.Serie;
                    refNF.cUF = (TCodUfIBGE)Enum.Parse(typeof(TCodUfIBGE), "Item" + destinatario.CodMunicipioIBGE.ToString().Substring(0, 2));
                    TNFeInfNFeIdeNFref nfRef = new TNFeInfNFeIdeNFref();
                    nfRef.ItemElementName = ItemChoiceType1.refNF;
                    nfRef.Item = refNF;
                    infNFeIde.NFref = new TNFeInfNFeIdeNFref[1];
                    infNFeIde.NFref[0] = nfRef;
                }
                else
                {
                    TNFeInfNFeIdeNFref nfRef = new TNFeInfNFeIdeNFref();
                    nfRef.ItemElementName = ItemChoiceType1.refNFe;
                    nfRef.Item = entrada.Chave;
                    infNFeIde.NFref = new TNFeInfNFeIdeNFref[1];
                    infNFeIde.NFref[0] = nfRef;
                }
            }
            return nfeControleAutorizada;
        }

        public List<SaidaProduto> DistribuirDescontoProdutos(List<SaidaProduto> saidaProdutos, decimal totalSaidas)
        {
            saidaProdutos = AgruparSaidaProdutos(saidaProdutos);
            foreach (SaidaProduto saidaProduto in saidaProdutos)
            {
                saidaProduto.ValorVendaAVista = Math.Truncate(saidaProduto.ValorVendaAVista * 1000) / 1000;
            }

            // calcula descontos
            decimal percentualDesconto = totalSaidas / saidaProdutos.Sum(sp => sp.Subtotal);
            decimal totalDescontoDevolucoes = Math.Round(Math.Abs(saidaProdutos.Where(sp => sp.Quantidade < 0).Sum(sp => sp.Subtotal) * percentualDesconto), 2);

            decimal totalSaidaProdutosPositivo = Math.Round(saidaProdutos.Where(sp => sp.Quantidade > 0).Sum(sp => sp.Subtotal), 2);
            decimal totalAVistaSaidaProdutosPositivo = Math.Round(saidaProdutos.Where(sp => sp.Quantidade > 0).Sum(sp => sp.SubtotalAVista), 2);


            decimal totalDescontoDistribuirPreco = totalSaidaProdutosPositivo - totalSaidas;
            decimal totalDescontoCalculado = totalSaidaProdutosPositivo - totalAVistaSaidaProdutosPositivo + totalDescontoDevolucoes;
            if ((totalDescontoCalculado == totalDescontoDistribuirPreco) && (totalDescontoDevolucoes == 0))
            {
                foreach (SaidaProduto saidaProduto in saidaProdutos)
                {
                    saidaProduto.ValorProdutoNota = saidaProduto.ValorVendaAVista;
                    saidaProduto.ValorDesconto = 0;
                }
            }
            else if ((totalDescontoDistribuirPreco <= 0) && (totalDescontoDevolucoes == 0))
            {
                foreach (SaidaProduto saidaProduto in saidaProdutos)
                {
                    saidaProduto.ValorProdutoNota = saidaProduto.ValorVenda;
                    saidaProduto.ValorDesconto = 0;
                }
            }
            else if (saidaProdutos.Sum(sp => sp.SubtotalAVista) == totalSaidas)
            {
                foreach (SaidaProduto sp in saidaProdutos)
                    sp.ValorProdutoNota = sp.ValorVendaAVista;
                totalDescontoDistribuirPreco = Math.Abs(saidaProdutos.Where(sp => sp.Quantidade < 0).Sum(sp => sp.SubtotalAVista));
                decimal fatorDesconto = totalDescontoDistribuirPreco / Math.Abs(saidaProdutos.Where(sp => sp.Quantidade > 0).Sum(sp => sp.SubtotalAVista));
                saidaProdutos = DistribuirDescontoFator(saidaProdutos, totalDescontoDistribuirPreco, fatorDesconto);
            }
            else if (totalDescontoDistribuirPreco > totalDescontoCalculado)
            {
                foreach (SaidaProduto saidaProduto in saidaProdutos)
                    saidaProduto.ValorProdutoNota = saidaProduto.ValorVendaAVista;

                //totalDescontoDistribuirPreco = totalDescontoDistribuirPreco - totalDescontoCalculado; //+ totalDescontoDevolucoes;
                totalDescontoDistribuirPreco = totalAVistaSaidaProdutosPositivo - totalSaidas;
                decimal fatorDesconto = totalDescontoDistribuirPreco / totalAVistaSaidaProdutosPositivo;
                saidaProdutos = DistribuirDescontoFator(saidaProdutos, totalDescontoDistribuirPreco, fatorDesconto);
            }
            else if (saidaProdutos.Sum(sp => sp.Subtotal) == totalSaidas)
            {
                foreach (SaidaProduto sp in saidaProdutos)
                    sp.ValorProdutoNota = sp.ValorVenda;
                totalDescontoDistribuirPreco = Math.Abs(saidaProdutos.Where(sp => sp.Quantidade < 0).Sum(sp => sp.Subtotal));
                decimal fatorDesconto = totalDescontoDistribuirPreco / totalSaidas;
                saidaProdutos = DistribuirDescontoFator(saidaProdutos, totalDescontoDistribuirPreco, fatorDesconto);
            }
            else
            {
                // distribui descontos calculado um novo fator
                decimal fatorDesconto = totalDescontoDistribuirPreco / totalSaidas;
                foreach (SaidaProduto sp in saidaProdutos)
                    sp.ValorProdutoNota = sp.ValorVenda;

                saidaProdutos = DistribuirDescontoFator(saidaProdutos, totalDescontoDistribuirPreco, fatorDesconto);
            }

            return saidaProdutos;
        }

        private static List<SaidaProduto> DistribuirDescontoFator(List<SaidaProduto> saidaProdutos, decimal totalDescontoDistribuirPreco, decimal fatorDesconto)
        {
            saidaProdutos = saidaProdutos.OrderBy(sp => sp.Subtotal).ToList();
            decimal totalDescontoDistribuido = 0;
            foreach (SaidaProduto saidaProduto in saidaProdutos)
            {
                if (saidaProduto.Quantidade > 0)
                {
                    decimal valorDescontoProduto = Math.Round((saidaProduto.ValorProdutoNota * saidaProduto.Quantidade) * fatorDesconto, 2, MidpointRounding.AwayFromZero);

                    if ((valorDescontoProduto + totalDescontoDistribuido) <= totalDescontoDistribuirPreco)
                    {
                        saidaProduto.ValorDesconto = valorDescontoProduto;
                    }
                    else
                    {
                        saidaProduto.ValorDesconto = totalDescontoDistribuirPreco - totalDescontoDistribuido;
                    }
                }
                else
                {
                    saidaProduto.ValorDesconto = 0;
                }
                totalDescontoDistribuido += saidaProduto.ValorDesconto;
            }

            if (totalDescontoDistribuido < totalDescontoDistribuirPreco)
            {
                decimal descontoRestante = totalDescontoDistribuirPreco - totalDescontoDistribuido;
                foreach (SaidaProduto saidaProduto in saidaProdutos)
                {
                    if (((saidaProduto.ValorProdutoNota * saidaProduto.Quantidade) - saidaProduto.ValorDesconto - descontoRestante) > 0)
                    {
                        saidaProduto.ValorDesconto += descontoRestante;
                        break;
                    }
                }
            }
            return saidaProdutos;
        }

        private static List<SaidaProduto> AgruparSaidaProdutos(List<SaidaProduto> saidaProdutos)
        {
            // Agrupa produtos iguais
            saidaProdutos = saidaProdutos.OrderBy(sp => sp.CodProduto).ToList();
            SaidaProduto saidaProdutoAnterior = null;
            SaidaProduto saidaProdutoAtual = null;

            int cont = 0;
            while (cont < saidaProdutos.Count)
            {
                saidaProdutoAtual = saidaProdutos.ElementAt(cont);
                if (cont == 0)
                {
                    saidaProdutoAnterior = saidaProdutoAtual;
                    cont++;
                }
                else
                {
                    if (saidaProdutoAtual.CodProduto.Equals(saidaProdutoAnterior.CodProduto))
                    {
                        if (saidaProdutoAtual.ValorVendaAVista > 0 && saidaProdutoAtual.Quantidade > 0)
                        {
                            saidaProdutoAnterior.BaseCalculoICMS += saidaProdutoAtual.BaseCalculoICMS;
                            saidaProdutoAnterior.BaseCalculoICMSSubst += saidaProdutoAtual.BaseCalculoICMSSubst;
                            saidaProdutoAnterior.ValorDesconto += saidaProdutoAtual.ValorDesconto;
                            saidaProdutoAnterior.ValorICMS += saidaProdutoAtual.ValorICMS;
                            saidaProdutoAnterior.ValorICMSSubst += saidaProdutoAtual.ValorICMSSubst;
                            saidaProdutoAnterior.ValorImposto += saidaProdutoAtual.ValorImposto;
                            saidaProdutoAnterior.ValorIPI += saidaProdutoAtual.ValorIPI;
                            saidaProdutoAnterior.ValorVendaAVista = ((saidaProdutoAtual.ValorVendaAVista * saidaProdutoAtual.Quantidade) +
                                (saidaProdutoAnterior.ValorVendaAVista * saidaProdutoAnterior.Quantidade)) / (saidaProdutoAtual.Quantidade + saidaProdutoAnterior.Quantidade);
                            saidaProdutoAnterior.Quantidade += saidaProdutoAtual.Quantidade;
                            saidaProdutos.Remove(saidaProdutoAtual);
                        }
                        else
                        {
                            saidaProdutos.Remove(saidaProdutoAtual);
                        }
                    }
                    else
                    {
                        saidaProdutoAnterior = saidaProdutoAtual;
                        cont++;
                    }
                }
            }
            return saidaProdutos;
        }


        /// <summary>
        /// Envia solicitação de cancelamanto usando Eventos.
        /// </summary>
        /// <param name="nfeControle"></param>
        public void EnviarSolicitacaoCancelamento(NfeControle nfeControle)
        {
            try
            {
                if (nfeControle != null)
                {
                    if (!nfeControle.SituacaoNfe.Equals(NfeControle.SITUACAO_AUTORIZADA))
                        throw new NegocioException("Não é possível solicitar cancelamento dessa nota. Apenas NFe AUTORIZADAS podem ser canceladas.");
                    else if (string.IsNullOrEmpty(nfeControle.JustificativaCancelamento) || (nfeControle.JustificativaCancelamento.Trim().Length < 15))
                        throw new NegocioException("É necessário adicionar uma justificativa para realizar o cancelamento da NF-e com pelo menos 15 caracteres.");

                    tb_solicitacao_evento_nfe solicitaEvento = new tb_solicitacao_evento_nfe();
                    solicitaEvento.codNFe = nfeControle.CodNfe;
                    solicitaEvento.tipoSolicitacao = EventoNfe.TIPO_CANCELAMENTO;
                    GerenciadorSolicitacaoEvento.GetInstance().Inserir(solicitaEvento);
                }
            }
            catch (NegocioException ne)
            {
                throw ne;
            }
            catch (Exception ex)
            {
                throw new NegocioException("Problemas na geração do arquivo de cancelamento da Nota Fiscal Eletrônica. Favor consultar administrador do sistema.", ex);
            }

        }

        /// <summary>
        /// Envia solicitação de cancelamanto usando Eventos.
        /// </summary>
        /// <param name="nfeControle"></param>
        public void ProcessarSolicitacoesCancelamento()
        {
            try
            {
                List<tb_solicitacao_evento_nfe> listaSolicitacaoEvento = GerenciadorSolicitacaoEvento.GetInstance().ObterPorTiposolicitacaoEvento(EventoNfe.TIPO_CANCELAMENTO).ToList();

                foreach (tb_solicitacao_evento_nfe eventoNfe in listaSolicitacaoEvento)
                {
                    NfeControle nfeControle = GerenciadorNFe.GetInstance().Obter(eventoNfe.codNFe).FirstOrDefault();
                    GerenciadorSolicitacaoEvento.GetInstance().Remover(eventoNfe.idSolicitacaoEvento);
                    if (nfeControle == null)
                        return;
                    Dominio.NFE2.TEnvEvento envEvento = new Dominio.NFE2.TEnvEvento();
                    envEvento.idLote = nfeControle.NumeroSequenciaNfe.ToString().PadLeft(15, '0');
                    envEvento.versao = "1.00";

                    Dominio.NFE2.TEvento evento = new Dominio.NFE2.TEvento();
                    evento.versao = Dominio.NFE2.TVerEvento.Item100;

                    Dominio.NFE2.TEventoInfEvento infEvento = new Dominio.NFE2.TEventoInfEvento();
                    infEvento.chNFe = nfeControle.Chave;
                    infEvento.cOrgao = (Dominio.NFE2.TCOrgaoIBGE)Enum.Parse(typeof(Dominio.NFE2.TCOrgaoIBGE), "Item" + Global.C_ORGAO_IBGE_SERGIPE);
                    infEvento.tpAmb = (Dominio.NFE2.TAmb)Enum.Parse(typeof(Dominio.NFE2.TAmb), "Item" + Global.AMBIENTE_NFE); // 1-produção / 2-homologação
                    //Saida saida = GerenciadorSaida.GetInstance(null).Obter(nfeControle.CodSaida);
                    Loja loja = GerenciadorLoja.GetInstance().Obter(nfeControle.CodLoja).ElementAtOrDefault(0);
                    Pessoa pessoa = GerenciadorPessoa.GetInstance().Obter(loja.CodPessoa).ElementAtOrDefault(0);

                    if (pessoa.Tipo.Equals(Pessoa.PESSOA_FISICA))
                        infEvento.ItemElementName = Dominio.NFE2.ItemChoiceType7.CPF;
                    else
                        infEvento.ItemElementName = Dominio.NFE2.ItemChoiceType7.CNPJ;
                    infEvento.Item = pessoa.CpfCnpj;
                    infEvento.dhEvento = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszzz");
                    infEvento.tpEvento = "110111";
                    infEvento.nSeqEvento = "1"; // carta correção pode haver mais de uma
                    infEvento.verEvento = "1.00";
                    infEvento.Id = "ID" + infEvento.tpEvento + infEvento.chNFe + infEvento.nSeqEvento.PadLeft(2, '0');

                    Dominio.NFE2.TEventoInfEventoDetEvento detEvento = new Dominio.NFE2.TEventoInfEventoDetEvento();

                    XmlDocument xmlDoc = new XmlDocument();
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();

                    ns.Add("", "http://www.portalfiscal.inf.br/nfe");

                    XmlAttribute[] atributos = new XmlAttribute[1];
                    atributos[0] = xmlDoc.CreateAttribute("versao");
                    atributos[0].Value = "1.00";
                    detEvento.AnyAttr = atributos;

                    XmlElement[] elementos = new XmlElement[3];
                    elementos[0] = xmlDoc.CreateElement("descEvento", "http://www.portalfiscal.inf.br/nfe");
                    elementos[0].InnerText = "Cancelamento";
                    elementos[1] = xmlDoc.CreateElement("nProt", "http://www.portalfiscal.inf.br/nfe");
                    elementos[1].InnerText = nfeControle.NumeroProtocoloUso;
                    elementos[2] = xmlDoc.CreateElement("xJust", "http://www.portalfiscal.inf.br/nfe");



                    nfeControle.JustificativaCancelamento = nfeControle.JustificativaCancelamento.Replace("\n", " ");
                    nfeControle.JustificativaCancelamento = nfeControle.JustificativaCancelamento.Replace("\r", " ");
                    nfeControle.JustificativaCancelamento = nfeControle.JustificativaCancelamento.Replace("\t", String.Empty);

                    
                    elementos[2].InnerText = nfeControle.JustificativaCancelamento.Trim();
                    detEvento.Any = elementos;

                    infEvento.detEvento = detEvento;
                    evento.infEvento = infEvento;
                    envEvento.evento = new Dominio.NFE2.TEvento[1] { evento };

                    MemoryStream memStream = new MemoryStream();
                    XmlSerializer serializer = new XmlSerializer(typeof(Dominio.NFE2.TEnvEvento));
                    serializer.Serialize(memStream, envEvento, ns);
                    memStream.Position = 0;
                    xmlDoc.Load(memStream);

                    xmlDoc.Save(loja.PastaNfeEnvio + nfeControle.Chave + "-env-canc.xml");
                    xmlDoc.Save(loja.PastaNfeEnviado + nfeControle.Chave + "-env-canc.xml");

                    Atualizar(nfeControle);

                }
            }
            catch (NegocioException ne)
            {
                throw ne;
            }
            catch (Exception ex)
            {
                throw new NegocioException("Problemas na geração do arquivo de cancelamento da Nota Fiscal Eletrônica. Favor consultar administrador do sistema.", ex);
            }

        }

        /// <summary>
        /// REtorna o resultado do pedido de cancelamento da NF-e
        /// </summary>
        /// <returns></returns>
        public string RecuperarResultadoCancelamentoNfe(string pastaNfeRetorno)
        {
            DirectoryInfo Dir = new DirectoryInfo(pastaNfeRetorno);
            string numeroProtocolo = "";
            if (Dir.Exists)
            {
                // Busca automaticamente todos os arquivos em todos os subdiretórios
                string arquivoRetornoReciboNfe = "*-ret-env-canc.*";
                FileInfo[] files = Dir.GetFiles(arquivoRetornoReciboNfe, SearchOption.TopDirectoryOnly);
                for (int i = 0; i < files.Length; i++)
                {
                    // apenas exclui o arquivo texto que não será utilizado  
                    if (files[i].Name.Contains("-ret-env-canc.txt"))
                    {
                        files[i].Delete();
                    }
                    else if (files[i].Name.Contains("-ret-env-canc.err"))
                    {
                        files[i].Delete();
                        string chave = files[i].Name.Substring(0, 44);
                        NfeControle nfeControle = ObterPorChave(chave).ElementAtOrDefault(0);
                        nfeControle.MensagemSitucaoProtocoloCancelamento = "Cancelamento NÃO REALIZADO";
                        Atualizar(nfeControle);
                    }
                    else
                    {
                        XmlDocument xmldocRetorno = new XmlDocument();
                        xmldocRetorno.Load(pastaNfeRetorno + files[i].Name);
                        XmlNodeReader xmlReaderRetorno = new XmlNodeReader(xmldocRetorno.DocumentElement);

                        string chave = files[i].Name.Substring(0, 44);
                        NfeControle nfeControle = ObterPorChave(chave).ElementAtOrDefault(0);
                        if (nfeControle != null)
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(Dominio.NFE2.TRetEnvEvento));
                            Dominio.NFE2.TRetEnvEvento retEventoCancelamento = (Dominio.NFE2.TRetEnvEvento)serializer.Deserialize(xmlReaderRetorno);
                            if (retEventoCancelamento.cStat.Equals(NfeStatusResposta.NFE128_LOTE_EVENTO_PROCESSADO))
                            {
                                Dominio.NFE2.TRetEventoInfEvento retornoEvento = retEventoCancelamento.retEvento[0].infEvento;
                                if (retornoEvento.cStat.Equals(NfeStatusResposta.NFE135_EVENTO_REGISTRADO_VINCULADO_NFE) ||
                                    retornoEvento.cStat.Equals(NfeStatusResposta.NFE136_EVENTO_REGISTRADO_NAO_VINCULADO_NFE))
                                {
                                    nfeControle.NumeroProtocoloCancelamento = retornoEvento.nProt;
                                    nfeControle.DataCancelamento = Convert.ToDateTime(retornoEvento.dhRegEvento);
                                    nfeControle.SituacaoNfe = NfeControle.SITUACAO_CANCELADA;
                                }
                                nfeControle.SituacaoProtocoloCancelamento = retornoEvento.cStat;
                                nfeControle.MensagemSitucaoProtocoloCancelamento = retornoEvento.xMotivo;
                                GerenciadorNFe.GetInstance().Atualizar(nfeControle);
                                files[i].Delete();
                            }
                            GerenciadorSaida.GetInstance(null).AtualizarSaidasPorNfeSituacao(nfeControle);
                        }
                    }
                }
            }
            return numeroProtocolo;
        }

        /// <summary>
        /// Envia solicitação de inutilização de numeração de nf-e
        /// </summary>
        /// <param name="nfeControle"></param>
        public void EnviarSolicitacaoInutilizacao(NfeControle nfeControle)
        {

            try
            {
                if (string.IsNullOrEmpty(nfeControle.JustificativaCancelamento) || (nfeControle.JustificativaCancelamento.Length < 15))
                {
                    throw new NegocioException("É necessário adicionar uma justificativa para realizar a inutilização da NF-e com pelo menos 15 caracteres.");
                }

                TInutNFe inutilizacaoNfe = new TInutNFe();
                inutilizacaoNfe.versao = "2.00";
                Saida saida = GerenciadorSaida.GetInstance(null).Obter(nfeControle.CodSaida);
                Loja loja = GerenciadorLoja.GetInstance().Obter(saida.CodLojaOrigem).ElementAtOrDefault(0);
                Pessoa pessoa = GerenciadorPessoa.GetInstance().Obter(loja.CodPessoa).ElementAtOrDefault(0);

                TInutNFeInfInut infInutilizacaoNfe = new TInutNFeInfInut();
                infInutilizacaoNfe.ano = DateTime.Now.Year.ToString();
                infInutilizacaoNfe.CNPJ = pessoa.CpfCnpj;
                infInutilizacaoNfe.cUF = (TCodUfIBGE)Enum.Parse(typeof(TCodUfIBGE), "Item" + Global.C_ORGAO_IBGE_SERGIPE);
                infInutilizacaoNfe.mod = TMod.Item55;
                infInutilizacaoNfe.nNFFin = nfeControle.NumeroSequenciaNfe.ToString();
                infInutilizacaoNfe.nNFIni = nfeControle.NumeroSequenciaNfe.ToString();
                infInutilizacaoNfe.serie = "1";
                infInutilizacaoNfe.tpAmb = (TAmb)Enum.Parse(typeof(TAmb), "Item" + Global.AMBIENTE_NFE); // 1-produção / 2-homologação
                infInutilizacaoNfe.xJust = nfeControle.JustificativaCancelamento;
                infInutilizacaoNfe.xServ = TInutNFeInfInutXServ.INUTILIZAR;
                infInutilizacaoNfe.Id = "ID" + Global.C_ORGAO_IBGE_SERGIPE + infInutilizacaoNfe.ano.Substring(2, 2) +
                    infInutilizacaoNfe.CNPJ + "55" + "001" + infInutilizacaoNfe.nNFIni.PadLeft(9, '0') + infInutilizacaoNfe.nNFFin.PadLeft(9, '0');

                inutilizacaoNfe.infInut = infInutilizacaoNfe;

                XmlDocument xmlDoc = new XmlDocument();
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();

                ns.Add("", "http://www.portalfiscal.inf.br/nfe");

                MemoryStream memStream = new MemoryStream();
                XmlSerializer serializer = new XmlSerializer(typeof(TInutNFe));
                serializer.Serialize(memStream, inutilizacaoNfe, ns);
                memStream.Position = 0;
                xmlDoc.Load(memStream);

                xmlDoc.Save(loja.PastaNfeEnvio + infInutilizacaoNfe.Id.Substring(2) + "-ped-inu.xml");
                xmlDoc.Save(loja.PastaNfeEnviado + infInutilizacaoNfe.Id.Substring(2) + "-ped-inu.xml");

                Atualizar(nfeControle);
            }
            catch (NegocioException ne)
            {
                throw ne;
            }
            catch (Exception ex)
            {
                throw new NegocioException("Problemas na geração do arquivo de cancelamento da Nota Fiscal Eletrônica. Favor consultar administrador do sistema.", ex);
            }
        }

        /// <summary>
        /// REtorna o resultado do pedido de cancelamento da NF-e
        /// </summary>
        /// <returns></returns>
        public string RecuperarResultadoInutilizacaoNfe(string pastaNfeRetorno)
        {
            DirectoryInfo Dir = new DirectoryInfo(pastaNfeRetorno);
            string numeroProtocolo = "";
            if (Dir.Exists)
            {
                // Busca automaticamente todos os arquivos em todos os subdiretórios
                string arquivoRetornoReciboNfe = "*-inu.*";
                FileInfo[] files = Dir.GetFiles(arquivoRetornoReciboNfe, SearchOption.TopDirectoryOnly);
                for (int i = 0; i < files.Length; i++)
                {
                    // apenas exclui o arquivo texto que não será utilizado  
                    if (files[i].Name.Contains("-inu.txt"))
                    {
                        files[i].Delete();
                    }
                    else if (files[i].Name.Contains("-inu.err"))
                    {
                        files[i].Delete();
                        string chave = files[i].Name.Substring(0, 44);
                        NfeControle nfeControle = ObterPorChave(chave).ElementAtOrDefault(0);
                        nfeControle.MensagemSitucaoProtocoloCancelamento = "Cancelamento NÃO REALIZADO";
                        Atualizar(nfeControle);
                    }
                    else
                    {
                        XmlDocument xmldocRetorno = new XmlDocument();
                        xmldocRetorno.Load(pastaNfeRetorno + files[i].Name);
                        XmlNodeReader xmlReaderRetorno = new XmlNodeReader(xmldocRetorno.DocumentElement);

                        string chave = files[i].Name.Substring(0, 44);
                        NfeControle nfeControle = ObterPorChave(chave).ElementAtOrDefault(0);
                        if (nfeControle != null)
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(Dominio.NFE2.TRetEnvEvento));
                            Dominio.NFE2.TRetEnvEvento retEventoCancelamento = (Dominio.NFE2.TRetEnvEvento)serializer.Deserialize(xmlReaderRetorno);
                            if (retEventoCancelamento.cStat.Equals(NfeStatusResposta.NFE128_LOTE_EVENTO_PROCESSADO))
                            {
                                Dominio.NFE2.TRetEventoInfEvento retornoEvento = retEventoCancelamento.retEvento[0].infEvento;
                                if (retornoEvento.cStat.Equals(NfeStatusResposta.NFE135_EVENTO_REGISTRADO_VINCULADO_NFE) ||
                                    retornoEvento.cStat.Equals(NfeStatusResposta.NFE136_EVENTO_REGISTRADO_NAO_VINCULADO_NFE))
                                {
                                    nfeControle.NumeroProtocoloCancelamento = retornoEvento.nProt;
                                    nfeControle.DataCancelamento = Convert.ToDateTime(retornoEvento.dhRegEvento);
                                    nfeControle.SituacaoNfe = NfeControle.SITUACAO_CANCELADA;
                                }
                                nfeControle.SituacaoProtocoloCancelamento = retornoEvento.cStat;
                                nfeControle.MensagemSitucaoProtocoloCancelamento = retornoEvento.xMotivo;
                                GerenciadorNFe.GetInstance().Atualizar(nfeControle);
                                files[i].Delete();
                            }
                            GerenciadorSaida.GetInstance(null).AtualizarSaidasPorNfeSituacao(nfeControle);
                        }
                    }
                }
            }
            return numeroProtocolo;
        }

        /// <summary>
        /// Envia solicitação de consulta a uma nf-e
        /// </summary>
        /// <param name="nfeControle"></param>
        public void EnviarConsultaNfe(NfeControle nfeControle)
        {
            try
            {
                if (nfeControle != null)
                {
                    tb_solicitacao_evento_nfe solicitaEvento = new tb_solicitacao_evento_nfe();
                    solicitaEvento.codNFe = nfeControle.CodNfe;
                    solicitaEvento.tipoSolicitacao = EventoNfe.TIPO_CONSULTA;
                    GerenciadorSolicitacaoEvento.GetInstance().Inserir(solicitaEvento);
                }
            }
            catch (NegocioException ne)
            {
                throw ne;
            }
            catch (Exception ex)
            {
                throw new NegocioException("Problemas na geração do arquivo de consulta da situação da Nota Fiscal Eletrônica. Favor consultar administrador do sistema.", ex);
            }
        }



        public void ProcessaSolicitacaoConsultaNfe()
        {

            try
            {

                List<tb_solicitacao_evento_nfe> listaSolicitacaoEvento = GerenciadorSolicitacaoEvento.GetInstance().ObterPorTiposolicitacaoEvento(EventoNfe.TIPO_CONSULTA).ToList();

                foreach (tb_solicitacao_evento_nfe eventoNfe in listaSolicitacaoEvento)
                {
                    NfeControle nfeControle = GerenciadorNFe.GetInstance().Obter(eventoNfe.codNFe).FirstOrDefault();
                    GerenciadorSolicitacaoEvento.GetInstance().Remover(eventoNfe.idSolicitacaoEvento);
                    if (nfeControle == null)
                        return;

                    TConsSitNFe consultaNfe = new TConsSitNFe();

                    consultaNfe.chNFe = nfeControle.Chave;
                    consultaNfe.tpAmb = (TAmb)Enum.Parse(typeof(TAmb), "Item" + Global.AMBIENTE_NFE); // 1-produção / 2-homologação
                    consultaNfe.versao = TVerConsSitNFe.Item400;
                    consultaNfe.xServ = TConsSitNFeXServ.CONSULTAR;

                    XmlDocument xmlDoc = new XmlDocument();
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();

                    ns.Add("", "http://www.portalfiscal.inf.br/nfe");

                    MemoryStream memStream = new MemoryStream();
                    XmlSerializer serializer = new XmlSerializer(typeof(TConsSitNFe));
                    serializer.Serialize(memStream, consultaNfe, ns);
                    memStream.Position = 0;
                    xmlDoc.Load(memStream);

                    Loja loja = GerenciadorLoja.GetInstance().Obter(nfeControle.CodLoja).ElementAtOrDefault(0);
                    xmlDoc.Save(loja.PastaNfeEnvio + nfeControle.Chave + "-ped-sit.xml");
                    xmlDoc.Save(loja.PastaNfeEnviado + nfeControle.Chave + "-ped-sit.xml");
                }
            }
            catch (NegocioException ne)
            {
                throw ne;
            }
            catch (Exception ex)
            {
                throw new NegocioException("Problemas na geração do arquivo de consulta da situação da Nota Fiscal Eletrônica. Favor consultar administrador do sistema.", ex);
            }
        }


        /// <summary>
        /// REtorna o resultado do pedido de cancelamento da NF-e
        /// </summary>
        /// <returns></returns>
        public void RecuperarResultadoConsultaNfe(string pastaNfeRetorno)
        {
            DirectoryInfo Dir = new DirectoryInfo(pastaNfeRetorno);
            if (Dir.Exists)
            {
                // Busca automaticamente todos os arquivos em todos os subdiretórios
                string arquivoRetornoConsultaNfe = "*-sit.*";
                FileInfo[] files = Dir.GetFiles(arquivoRetornoConsultaNfe, SearchOption.TopDirectoryOnly);
                for (int i = 0; i < files.Length; i++)
                {
                    // apenas exclui o arquivo texto que não será utilizado  
                    if (files[i].Name.Contains("-sit.txt"))
                    {
                        files[i].Delete();
                    }
                    else if (files[i].Name.Contains("-sit.err"))
                    {
                        Loja loja = GerenciadorLoja.GetInstance().Obter(Global.LOJA_PADRAO).FirstOrDefault();
                        if (loja != null)
                            files[i].CopyTo(loja.PastaNfeErro + files[i].Name, true);
                        files[i].Delete();
                    }
                    else
                    {
                        XmlDocument xmldocRetorno = new XmlDocument();
                        xmldocRetorno.Load(pastaNfeRetorno + files[i].Name);
                        XmlNodeReader xmlReaderRetorno = new XmlNodeReader(xmldocRetorno.DocumentElement);

                        string chave = files[i].Name.Substring(0, 44);
                        NfeControle nfeControle = ObterPorChave(chave).ElementAtOrDefault(0);
                        if (nfeControle != null)
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(TRetConsSitNFe));
                            TRetConsSitNFe retConsulta = (TRetConsSitNFe)serializer.Deserialize(xmlReaderRetorno);

                            if (retConsulta.cStat.Equals(NfeStatusResposta.NFE217_NFE_INEXISTENTE))
                            {
                                nfeControle.SituacaoProtocoloUso = retConsulta.cStat;
                                nfeControle.MensagemSitucaoProtocoloUso = retConsulta.xMotivo;
                            }
                            else if (retConsulta.cStat.Equals(NfeStatusResposta.NFE101_CANCELAMENTO_NFE_HOMOLOGADO))
                            {
                                nfeControle.SituacaoProtocoloUso = retConsulta.cStat;
                                nfeControle.SituacaoNfe = NfeControle.SITUACAO_CANCELADA;
                            }
                            else
                            {
                                TProtNFeInfProt protocoloNfe = retConsulta.protNFe.infProt;
                                if (protocoloNfe.chNFe.Equals(nfeControle.Chave))
                                {
                                    if (protocoloNfe.cStat.Equals(NfeStatusResposta.NFE100_AUTORIZADO_USO_NFE))
                                    {
                                        //numeroProtocolo = protocoloNfe.nProt;
                                        nfeControle.NumeroProtocoloUso = protocoloNfe.nProt;
                                        nfeControle.SituacaoNfe = NfeControle.SITUACAO_AUTORIZADA;
                                    }
                                    else if (protocoloNfe.cStat.Equals(NfeStatusResposta.NFE110_USO_DENEGADO))
                                    {
                                        nfeControle.SituacaoNfe = NfeControle.SITUACAO_DENEGADA;
                                    }
                                    else
                                    {
                                        nfeControle.SituacaoNfe = NfeControle.SITUACAO_REJEITADA;
                                    }
                                    nfeControle.SituacaoProtocoloUso = protocoloNfe.cStat;
                                    nfeControle.MensagemSitucaoProtocoloUso = protocoloNfe.xMotivo;
                                }
                            }
                            GerenciadorNFe.GetInstance().Atualizar(nfeControle);
                            GerenciadorSaida.GetInstance(null).AtualizarSaidasPorNfeSituacao(nfeControle);
                            files[0].Delete();

                        }
                    }
                }
            }
        }

        /// <summary>
        /// Envia solicitação de correção de uma nf-e
        /// </summary>
        /// <param name="nfeControle"></param>
        public void EnviarCartaCorrecaoNfe(NfeControle nfeControle)
        {
            try
            {
                NfeControle nfeControleSeq = GerenciadorNFe.GetInstance().Obter(nfeControle.CodNfe).FirstOrDefault();
                nfeControle.SeqCartaCorrecao = nfeControleSeq.SeqCartaCorrecao;
                if (nfeControle.SituacaoNfe != NfeControle.SITUACAO_AUTORIZADA)
                {
                    throw new NegocioException("Só é possível enviar cartas de correção de NF-e AUTORIZADAS.");
                }
                if (string.IsNullOrEmpty(nfeControle.Correcao))
                {
                    throw new NegocioException("É necessário adicionar uma texto de correção para enviar uma Carta de Correção da NF-e.");
                }



                Dominio.NFE2.TEnvEvento envEvento = new Dominio.NFE2.TEnvEvento();
                envEvento.idLote = nfeControle.NumeroSequenciaNfe.ToString().PadLeft(15, '0');
                envEvento.versao = "1.00";


                Dominio.NFE2.TEvento evento = new Dominio.NFE2.TEvento();
                evento.versao = Dominio.NFE2.TVerEvento.Item100;

                Dominio.NFE2.TEventoInfEvento infEvento = new Dominio.NFE2.TEventoInfEvento();
                infEvento.chNFe = nfeControle.Chave;
                infEvento.cOrgao = (Dominio.NFE2.TCOrgaoIBGE)Enum.Parse(typeof(Dominio.NFE2.TCOrgaoIBGE), "Item" + Global.C_ORGAO_IBGE_SERGIPE);
                infEvento.tpAmb = (Dominio.NFE2.TAmb)Enum.Parse(typeof(Dominio.NFE2.TAmb), "Item" + Global.AMBIENTE_NFE); // 1-produção / 2-homologação

                Saida saida = GerenciadorSaida.GetInstance(null).Obter(nfeControle.CodSaida);
                Loja loja = GerenciadorLoja.GetInstance().Obter(saida.CodLojaOrigem).ElementAtOrDefault(0);
                Pessoa pessoa = GerenciadorPessoa.GetInstance().Obter(loja.CodPessoa).ElementAtOrDefault(0);

                if (pessoa.Tipo.Equals(Pessoa.PESSOA_FISICA))
                    infEvento.ItemElementName = Dominio.NFE2.ItemChoiceType7.CPF;
                else
                    infEvento.ItemElementName = Dominio.NFE2.ItemChoiceType7.CNPJ;
                infEvento.Item = pessoa.CpfCnpj;
                infEvento.chNFe = nfeControle.Chave;
                infEvento.dhEvento = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszzz");
                infEvento.tpEvento = "110110";
                infEvento.nSeqEvento = (nfeControle.SeqCartaCorrecao + 1).ToString(); // carta correção pode haver mais de uma
                infEvento.verEvento = "1.00";
                infEvento.Id = "ID" + infEvento.tpEvento + infEvento.chNFe + infEvento.nSeqEvento.PadLeft(2, '0');

                Dominio.NFE2.TEventoInfEventoDetEvento detEvento = new Dominio.NFE2.TEventoInfEventoDetEvento();

                XmlDocument xmlDoc = new XmlDocument();
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();

                ns.Add("", "http://www.portalfiscal.inf.br/nfe");

                XmlAttribute[] atributos = new XmlAttribute[1];
                atributos[0] = xmlDoc.CreateAttribute("versao");
                atributos[0].Value = "1.00";
                detEvento.AnyAttr = atributos;

                XmlElement[] elementos = new XmlElement[3];
                elementos[0] = xmlDoc.CreateElement("descEvento", "http://www.portalfiscal.inf.br/nfe");
                elementos[0].InnerText = "Carta de Correcao";
                elementos[1] = xmlDoc.CreateElement("xCorrecao", "http://www.portalfiscal.inf.br/nfe");


                nfeControle.Correcao = nfeControle.Correcao.Replace("\n", " ");
                nfeControle.Correcao = nfeControle.Correcao.Replace("\r", " ");
                //nfeControle.Correcao = nfeControle.Correcao.Replace("\"", String.Empty);
                //nfeControle.Correcao = nfeControle.Correcao.Replace("\'", String.Empty);
                nfeControle.Correcao = nfeControle.Correcao.Replace("”", "'");
                nfeControle.Correcao = nfeControle.Correcao.Replace("’", "'");
                nfeControle.Correcao = nfeControle.Correcao.Replace("\t", String.Empty);
                
                elementos[1].InnerText = nfeControle.Correcao.Trim();
                elementos[2] = xmlDoc.CreateElement("xCondUso", "http://www.portalfiscal.inf.br/nfe");
                elementos[2].InnerText = ("A Carta de Correcao e disciplinada pelo paragrafo 1o-A do art. 7o do Convenio S/N, de 15 de dezembro de 1970 e pode ser utilizada para regularizacao de erro ocorrido na emissao de documento fiscal, desde que o erro nao esteja relacionado com: I - as variaveis que determinam o valor do imposto tais como: base de calculo, aliquota, diferenca de preco, quantidade, valor da operacao ou da prestacao; II - a correcao de dados cadastrais que implique mudanca do remetente ou do destinatario; III - a data de emissao ou de saida.");
                detEvento.Any = elementos;

                infEvento.detEvento = detEvento;
                evento.infEvento = infEvento;
                envEvento.evento = new Dominio.NFE2.TEvento[1] { evento };

                MemoryStream memStream = new MemoryStream();
                XmlSerializer serializer = new XmlSerializer(typeof(Dominio.NFE2.TEnvEvento));
                serializer.Serialize(memStream, envEvento, ns);
                memStream.Position = 0;
                xmlDoc.Load(memStream);

                xmlDoc.Save(loja.PastaNfeEnvio + nfeControle.Chave + "-" + nfeControle.SeqCartaCorrecao.ToString().PadLeft(2, '0') + "-env-cce.xml");
                xmlDoc.Save(loja.PastaNfeEnviado + nfeControle.Chave + "-" + nfeControle.SeqCartaCorrecao.ToString().PadLeft(2, '0') + "-env-cce.xml");

                Atualizar(nfeControle);
            }
            catch (NegocioException ne)
            {
                throw ne;
            }
            catch (Exception ex)
            {
                throw new NegocioException("Problemas na geração do arquivo de cancelamento da Nota Fiscal Eletrônica. Favor consultar administrador do sistema.", ex);
            }
        }

        /// <summary>
        /// REtorna o resultado do pedido de cancelamento da NF-e
        /// </summary>
        /// <returns></returns>
        public string RecuperarResultadoCartaCorrecaoNfe(string pastaNfeRetorno)
        {
            DirectoryInfo Dir = new DirectoryInfo(pastaNfeRetorno);
            string numeroProtocolo = "";
            if (Dir.Exists)
            {
                // Busca automaticamente todos os arquivos em todos os subdiretórios
                string arquivoRetornoReciboNfe = "*-ret-env-cce.*";
                FileInfo[] files = Dir.GetFiles(arquivoRetornoReciboNfe, SearchOption.TopDirectoryOnly);
                for (int i = 0; i < files.Length; i++)
                {
                    // apenas exclui o arquivo texto que não será utilizado  
                    if (files[i].Name.Contains("-ret-env-cce.txt"))
                    {
                        files[i].Delete();
                    }
                    else if (files[i].Name.Contains("-ret-env-cce.err"))
                    {
                        files[i].Delete();
                        string chave = files[i].Name.Substring(0, 44);
                        NfeControle nfeControle = ObterPorChave(chave).ElementAtOrDefault(0);
                        nfeControle.MensagemSitucaoCartaCorrecao = "Carta de Correção com erros no layout.";
                        Atualizar(nfeControle);
                    }
                    else
                    {
                        XmlDocument xmldocRetorno = new XmlDocument();
                        xmldocRetorno.Load(pastaNfeRetorno + files[i].Name);
                        XmlNodeReader xmlReaderRetorno = new XmlNodeReader(xmldocRetorno.DocumentElement);

                        string chave = files[i].Name.Substring(0, 44);
                        NfeControle nfeControle = ObterPorChave(chave).ElementAtOrDefault(0);
                        if (nfeControle != null)
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(Dominio.NFE2.TRetEnvEvento));
                            Dominio.NFE2.TRetEnvEvento retEventoCartaCorrecao = (Dominio.NFE2.TRetEnvEvento)serializer.Deserialize(xmlReaderRetorno);
                            if (retEventoCartaCorrecao.cStat.Equals(NfeStatusResposta.NFE128_LOTE_EVENTO_PROCESSADO))
                            {
                                //retEventoCartaCorrecao.
                                Dominio.NFE2.TRetEventoInfEvento retornoEvento = retEventoCartaCorrecao.retEvento[0].infEvento;
                                if (retornoEvento.cStat.Equals(NfeStatusResposta.NFE135_EVENTO_REGISTRADO_VINCULADO_NFE) ||
                                    retornoEvento.cStat.Equals(NfeStatusResposta.NFE136_EVENTO_REGISTRADO_NAO_VINCULADO_NFE))
                                {
                                    nfeControle.NumeroProtocoloCartaCorrecao = retornoEvento.nProt;
                                    nfeControle.DataCartaCorrecao = Convert.ToDateTime(retornoEvento.dhRegEvento);
                                    nfeControle.SeqCartaCorrecao = Convert.ToInt32(retornoEvento.nSeqEvento);
                                    
                                    
                                    DateTime dataEmissao = (DateTime)nfeControle.DataEmissao;
                                    Loja loja = GerenciadorLoja.GetInstance().Obter(Global.LOJA_PADRAO).ElementAtOrDefault(0);
                                    string pastaNfe = loja.PastaNfeAutorizados + dataEmissao.Year
                                        + dataEmissao.Month.ToString("00")
                                        + dataEmissao.Day.ToString("00") + "\\";
                                    DirectoryInfo DirCCe = new DirectoryInfo(pastaNfe);
                                    if (DirCCe.Exists)
                                    {
                                        Process unidanfe = new Process();
                                        unidanfe.StartInfo.FileName = @"C:\Unimake\UniNFe\unidanfe.exe";
                                        unidanfe.StartInfo.Arguments = " arquivo=\"" + pastaNfe +
                                            nfeControle.Chave + "_" + nfeControle.SeqCartaCorrecao.ToString("00") + "-procEventoNFe.xml\""; ;
                                        unidanfe.StartInfo.Arguments += " t=cce ee=1 v=1 m=1 i=\"selecionar\"";
                                        unidanfe.Start();
                                    }
                                }
                                nfeControle.SituacaoProtocoloCartaCorrecao = retornoEvento.cStat;
                                nfeControle.MensagemSitucaoCartaCorrecao = retornoEvento.xMotivo;
                                GerenciadorNFe.GetInstance().Atualizar(nfeControle);
                                files[i].Delete();
                            }
                        }
                    }
                }
            }
            return numeroProtocolo;
        }
        /// <summary>
        /// Recupera os vários retornos do processamento de Nfes
        /// </summary>

        public void RecuperarRetornosNfe(Loja loja)
        {
            try
            {
                if (loja != null)
                {
                    DirectoryInfo Dir = new DirectoryInfo(loja.PastaNfeRetorno);
                    // Busca automaticamente todos os arquivos em todos os subdiretórios
                    if (Dir.Exists)
                    {
                        FileInfo[] files = Dir.GetFiles("*", SearchOption.TopDirectoryOnly);
                        if (files.Length > 0)
                        {
                            RecuperarChave(files);
                            RecuperarLoteEnvio(loja);
                            RecuperarReciboEnvioNfe(loja.PastaNfeRetorno);
                            RecuperarResultadoProcessamentoNfe(loja.PastaNfeRetorno);
                            RecuperarResultadoCancelamentoNfe(loja.PastaNfeRetorno);
                            RecuperarResultadoConsultaNfe(loja.PastaNfeRetorno);
                            RecuperarResultadoCartaCorrecaoNfe(loja.PastaNfeRetorno);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                //throw e;
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

        private string formataValorNFe(decimal? valor, int quantidadeDecimais)
        {
            try
            {
                if (valor == null)
                    valor = 0;
                if (quantidadeDecimais <= 2)
                    return ((decimal)valor).ToString("0.00", CultureInfo.InvariantCulture);
                else
                    return ((decimal)valor).ToString("0.000", CultureInfo.InvariantCulture);


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
        private string formataPesoNFe(decimal? quantidade)
        {
            try
            {
                if (quantidade == null)
                    quantidade = 0;

                return ((decimal)quantidade).ToString("0.000", CultureInfo.InvariantCulture);
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
        private void Atribuir(NfeControle nfe, tb_nfe _nfe)
        {
            _nfe.chave = string.IsNullOrEmpty(nfe.Chave) ? "" : nfe.Chave;
            _nfe.codNFe = nfe.CodNfe;
            _nfe.codLoja = nfe.CodLoja;
            _nfe.numeroSequenciaNFe = nfe.NumeroSequenciaNfe;
            _nfe.justificativaCancelamento = truncate(nfe.JustificativaCancelamento, 200);
            _nfe.mensagemSituacaoProtocoloCancelamento = truncate(nfe.MensagemSitucaoProtocoloCancelamento, 100);
            _nfe.mensagemSituacaoProtocoloUso = truncate(nfe.MensagemSitucaoProtocoloUso, 100);
            _nfe.mensagemSituacaoReciboEnvio = truncate(nfe.MensagemSituacaoReciboEnvio, 100);
            _nfe.modelo = nfe.Modelo;
            _nfe.numeroLoteEnvio = nfe.NumeroLoteEnvio;
            _nfe.numeroProtocoloCancelamento = nfe.NumeroProtocoloCancelamento;
            _nfe.numeroProtocoloUso = nfe.NumeroProtocoloUso;
            _nfe.numeroRecibo = nfe.NumeroRecibo;
            _nfe.situacaoNfe = nfe.SituacaoNfe;
            _nfe.situacaoProtocoloCancelamento = nfe.SituacaoProtocoloCancelamento;
            _nfe.situacaoProtocoloUso = nfe.SituacaoProtocoloUso;
            _nfe.situacaoReciboEnvio = nfe.SituacaoReciboEnvio;
            _nfe.dataEmissao = nfe.DataEmissao;
            _nfe.dataCancelamento = nfe.DataCancelamento;
            _nfe.codSolicitacao = nfe.CodSolicitacao;

            _nfe.correcao = truncate(string.IsNullOrEmpty(nfe.Correcao) ? "" : nfe.Correcao, 1000);
            _nfe.dataCartaCorrecao = nfe.DataCartaCorrecao;
            _nfe.mensagemSitucaoCartaCorrecao = truncate(string.IsNullOrEmpty(nfe.MensagemSitucaoCartaCorrecao) ? "" : nfe.MensagemSitucaoCartaCorrecao, 100);
            _nfe.numeroProtocoloCartaCorrecao = string.IsNullOrEmpty(nfe.NumeroProtocoloCartaCorrecao) ? "" : nfe.NumeroProtocoloCartaCorrecao;
            _nfe.seqCartaCorrecao = nfe.SeqCartaCorrecao;
            _nfe.situacaoProtocoloCartaCorrecao = string.IsNullOrEmpty(nfe.SituacaoProtocoloCartaCorrecao) ? "" : nfe.SituacaoProtocoloCartaCorrecao;

        }

        private string truncate(string texto, int tamanho)
        {
            if (texto.Length > tamanho)
                return texto.Substring(0, tamanho);
            return texto;
        }

        public void imprimirDANFE(NfeControle nfeControle, string servidorImprimirNFCe)
        {
            if (nfeControle != null)
            {
                tb_imprimir_documento imprimir = new tb_imprimir_documento();
                imprimir.codDocumento = nfeControle.CodNfe;
                if (nfeControle.Modelo.Equals(NfeControle.MODELO_NFCE))
                    imprimir.tipoDocumento = "NFCE";
                else
                    imprimir.tipoDocumento = "NFE";
                imprimir.hostSolicitante = nomeComputador;

                FileInfo fileUnidanfeInfo = new FileInfo("C:\\Unimake\\UniNFe\\unidanfe.exe");
                bool sucessoImprimirLocal = false;
                if (imprimir.tipoDocumento.Equals("NFE") && fileUnidanfeInfo.Exists) {
                    SaidaPesquisa saidaPesquisa = GerenciadorSaida.GetInstance(null).ObterSaidaPorNfe(nfeControle.CodNfe).FirstOrDefault();
                    Saida saida = GerenciadorSaida.GetInstance(null).Obter(saidaPesquisa.CodSaida);
                    Loja loja = GerenciadorLoja.GetInstance().Obter(saida.CodLojaOrigem).ElementAtOrDefault(0);
                    sucessoImprimirLocal = ImprimirUnidanfe(nfeControle, loja); 
                }
                if (!sucessoImprimirLocal)
                    GerenciadorImprimirDocumento.GetInstance().Inserir(imprimir);
            }
            else
            {
                List<tb_imprimir_documento> listaImprimirNfe = GerenciadorImprimirDocumento.GetInstance().ObterPorTipoDocumentoHost("NFE", nomeComputador).ToList();
                List<tb_imprimir_documento> listaImprimirNfce = new List<tb_imprimir_documento>();
                if (nomeComputador.Equals(servidorImprimirNFCe))
                    listaImprimirNfce = GerenciadorImprimirDocumento.GetInstance().ObterPorTipoDocumento("NFCE").ToList();
                IEnumerable<tb_imprimir_documento> listaImprimir = listaImprimirNfce.Union(listaImprimirNfe);
                if (listaImprimir != null && listaImprimir.Count() > 0)
                {
                    foreach (tb_imprimir_documento documento in listaImprimir)
                    {
                        GerenciadorImprimirDocumento.GetInstance().Remover(documento.codImprimir);
                        nfeControle = Obter((int)documento.codDocumento).FirstOrDefault();

                        if ((nfeControle != null) && (nfeControle.SituacaoNfe.Equals(NfeControle.SITUACAO_AUTORIZADA) || nfeControle.SituacaoNfe.Equals(NfeControle.SITUACAO_CONTINGENCIA_OFFLINE)))
                        {
                            //Saida saida = GerenciadorSaida.GetInstance(null).Obter(nfeControle.CodSaida);
                            Loja loja;
                            if (nfeControle.Modelo.Equals(NfeControle.MODELO_NFCE))
                                loja = GerenciadorLoja.GetInstance().Obter(Global.LOJA_PADRAO).ElementAtOrDefault(0);
                            else
                            {
                                SaidaPesquisa saidaPesquisa = GerenciadorSaida.GetInstance(null).ObterSaidaPorNfe(nfeControle.CodNfe).FirstOrDefault();
                                Saida saida = GerenciadorSaida.GetInstance(null).Obter(saidaPesquisa.CodSaida);
                                loja = GerenciadorLoja.GetInstance().Obter(saida.CodLojaOrigem).ElementAtOrDefault(0);
                            }
                            if (!ImprimirUnidanfe(nfeControle, loja))
                            {
                                throw new NegocioException("Não foi possível realizar a impressão do DANFE. Favor contactar administrador.");
                            }
                        }
                    }
                }
            }
        }

        private static bool ImprimirUnidanfe(NfeControle nfeControle, Loja loja)
        {
            bool sucessoImprimirUnidanfeLocal = false;
            try
            {
                DateTime dataEmissao = (DateTime)nfeControle.DataEmissao;
                string pastaNfe = loja.PastaNfeAutorizados + dataEmissao.Year
                    + dataEmissao.Month.ToString("00")
                    + dataEmissao.Day.ToString("00") + "\\";
                if (nfeControle.SituacaoNfe.Equals(NfeControle.SITUACAO_CONTINGENCIA_OFFLINE))
                    pastaNfe = loja.PastaNfeValidado;

                
                DirectoryInfo Dir = new DirectoryInfo(pastaNfe);
                if (Dir.Exists)
                {
                    string arquivoRetornoEnvioNfe = nfeControle.Chave + "-nfe.xml";
                    FileInfo[] files = Dir.GetFiles(arquivoRetornoEnvioNfe, SearchOption.TopDirectoryOnly);
                    int tentativas = 0;
                    while ((files.Count() == 0) && (tentativas < 6))
                    {
                        Thread.Sleep(1000);
                        files = Dir.GetFiles(arquivoRetornoEnvioNfe, SearchOption.TopDirectoryOnly);
                        if (files.Count() > 0)
                            break;
                        tentativas++;
                    }
                    if (files.Count() > 0)
                    {
                        Process unidanfe = new Process();
                        unidanfe.StartInfo.FileName = @"C:\Unimake\UniNFe\unidanfe.exe";
                        unidanfe.StartInfo.Arguments = " arquivo=\"" + pastaNfe
                            + nfeControle.Chave + "-nfe.xml\"";
                        if (nfeControle.Modelo.Equals(NfeControle.MODELO_NFE))
                            unidanfe.StartInfo.Arguments += " t=danfe ee=1 v=1 m=1 i=\"selecionar\"";
                        else
                            unidanfe.StartInfo.Arguments += " t=nfce ee=1 v=0 m=1 i=padrao";
                        //unidanfe.StartInfo.Arguments += " t=nfce ee=1 v=0 m=1 i=\\PC-BANESE\\mp-4200 th";  // ou colocar o nome da impressora de rede i=\\servidor\\lasesrjet
                        //unidanfe.StartInfo.Arguments += " t=nfce ee=1 v=0 m=1 i=\"selecionar\"";  // ou colocar o nome da impressora de rede i=\\servidor\\lasesrjet
                        unidanfe.Start();
                        sucessoImprimirUnidanfeLocal = true;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            return sucessoImprimirUnidanfeLocal;
        }


        public void EnviarNFEsOffLine()
        {
            Loja loja = GerenciadorLoja.GetInstance().Obter(Global.LOJA_PADRAO).FirstOrDefault();
            if (loja != null)
            {
                List<NfeControle> listaNfe = ObterPorSituacao(NfeControle.SITUACAO_CONTINGENCIA_OFFLINE).ToList();
                foreach (NfeControle nfe in listaNfe)
                {
                    DirectoryInfo Dir = new DirectoryInfo(loja.PastaNfeValidado);
                    if (Dir.Exists)
                    {
                        FileInfo[] files = Dir.GetFiles(nfe.Chave + "-nfe.xml", SearchOption.TopDirectoryOnly);
                        for (int i = 0; i < files.Length; i++)
                            files[i].CopyTo(loja.PastaNfeEnvio + files[i].Name, true);
                    }
                }
            }
        }

        public void CalcularTotaisNFCe(String pasta)
        {
            DirectoryInfo Dir = new DirectoryInfo(pasta);
            if (Dir.Exists)
            {
                // Busca automaticamente todos os arquivos em todos os subdiretórios
                string arquivosNf = "*procNFe.xml";
                FileInfo[] filesNf = Dir.GetFiles(arquivosNf, SearchOption.TopDirectoryOnly);
                string arquivosCancelado = "*procEventoNFe.xml";
                FileInfo[] filesCancelado = Dir.GetFiles(arquivosCancelado, SearchOption.TopDirectoryOnly);

                //N_28180732799603000191650010000061911061363420_SE_279054513_procEventoNFe

                Dictionary<string, decimal> mapValores = new Dictionary<string, decimal>();
                Dictionary<string, decimal> mapDesconto = new Dictionary<string, decimal>();


                for (int i = 0; i < filesNf.Length; i++)
                {
                    bool notaCancelada = false;
                    string chave = filesNf[i].Name.Substring(0, 50);
                    for (int j = 0; j < filesCancelado.Length; j++)
                    {
                        if (filesCancelado[j].Name.StartsWith(chave))
                        {
                            notaCancelada = true;
                            break;
                        }
                    }
                    if (!notaCancelada)
                    {
                        XmlDocument xmldocRetorno = new XmlDocument();
                        xmldocRetorno.Load(filesNf[i].FullName);
                        XmlNodeReader xmlReaderRetorno = new XmlNodeReader(xmldocRetorno.DocumentElement);
                        XmlSerializer serializer = new XmlSerializer(typeof(TNfeProc));
                        TNfeProc nfe = (TNfeProc)serializer.Deserialize(xmlReaderRetorno);
                        TNFeInfNFeDet[] produtos = nfe.NFe.infNFe.det;
                        foreach (TNFeInfNFeDet produto in produtos)
                        {
                            decimal valor = 0;
                            decimal valorDesconto = 0;
                            if (mapValores.TryGetValue(produto.prod.CFOP, out valor))
                            {
                                valor += Decimal.Parse(produto.prod.vProd, CultureInfo.InvariantCulture);
                                mapValores[produto.prod.CFOP] = valor;
                            }
                            else
                            {
                                valor = Decimal.Parse(produto.prod.vProd, CultureInfo.InvariantCulture);
                                mapValores.Add(produto.prod.CFOP, valor);
                            }

                            if (mapDesconto.TryGetValue(produto.prod.CFOP, out valorDesconto))
                            {
                                if (produto.prod.vDesc != null)
                                    valorDesconto += Decimal.Parse(produto.prod.vDesc, CultureInfo.InvariantCulture);
                                mapDesconto[produto.prod.CFOP] = valorDesconto;
                            }
                            else
                            {
                                if (produto.prod.vDesc != null)
                                    valorDesconto = Decimal.Parse(produto.prod.vDesc, CultureInfo.InvariantCulture);
                                mapDesconto.Add(produto.prod.CFOP, valorDesconto);
                            }
                        }
                    }
                }
                String resultado = "";
                foreach (string cfop in mapValores.Keys)
                {
                    decimal somaValores;
                    decimal somaDescontos;
                    mapValores.TryGetValue(cfop, out somaValores);
                    mapDesconto.TryGetValue(cfop, out somaDescontos);
                    string resultadoIndividual = "CFOP=" + cfop + ",valor=" + somaValores + ",desconto=" + somaDescontos + ";";
                    resultado += resultadoIndividual;
                }
                throw new Negocio.NegocioException(resultado);

            }

        }
    }
}
