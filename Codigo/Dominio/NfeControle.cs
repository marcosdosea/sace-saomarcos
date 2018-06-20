using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class NfeControle
    {
        public const string SITUACAO_SOLICITADA = "S";
        public const string SITUACAO_AUTORIZADA = "A";
        public const string SITUACAO_CANCELADA = "C";
        public const string SITUACAO_DENEGADA = "D"; // Quando há alguma irregularidade com o emitente
        public const string SITUACAO_INUTILIZADA = "I";
        public const string SITUACAO_NAO_VALIDADA = "N";
        public const string SITUACAO_REJEITADA = "R";
        public const string SITUACAO_COMPLEMENTAR_IMPOSTO = "O";

        public const string MODELO_NFE = "55";
        public const string MODELO_NFCE = "65";

        public NfeControle()
        {
            Chave = "";
            SituacaoNfe = "";
            NumeroLoteEnvio = "";
            NumeroRecibo = "";
            SituacaoReciboEnvio = "";
            MensagemSituacaoReciboEnvio = "";
            NumeroProtocoloUso = "";
            SituacaoProtocoloUso = "";
            MensagemSitucaoProtocoloUso = "";
            NumeroProtocoloCancelamento = "";
            SituacaoProtocoloCancelamento = "";
            MensagemSitucaoProtocoloCancelamento = "";
            JustificativaCancelamento = "";
        }

        public int CodNfe { get; set; }
        public long CodSaida { get; set; }
        public string Chave { get; set; }
        public string SituacaoNfe { get; set; }
        public int NumeroSequenciaNfe { get; set; }
        public int CodLoja { get; set; }
        public string Modelo { get; set; }

        public string DescricaoModelo
        {
            get
            {
                if (Modelo.Equals(MODELO_NFE))
                    return "NFe";
                else
                    return "NFCe";
            }
        }


        public string DescricaoSituacaoNfe
        {
            get
            {
                if (SituacaoNfe.Equals(SITUACAO_AUTORIZADA))
                    return "AUTORIZADA";
                else if (SituacaoNfe.Equals(SITUACAO_CANCELADA))
                    return "CANCELADA";
                else if (SituacaoNfe.Equals(SITUACAO_DENEGADA))
                    return "DENEGADA";
                else if (SituacaoNfe.Equals(SITUACAO_INUTILIZADA))
                    return "INUTILIZADA";
                else if (SituacaoNfe.Equals(SITUACAO_NAO_VALIDADA))
                    return "NÃO VALIDADA";
                else if (SituacaoNfe.Equals(SITUACAO_REJEITADA))
                    return "REJEITADA";
                else 
                    return "SOLICITADA";
            }
        }

        // Autorização
        public string NumeroLoteEnvio { get; set; }
        public string NumeroRecibo { get; set; }
        public string SituacaoReciboEnvio { get; set; }
        public string MensagemSituacaoReciboEnvio { get; set; }
        public string NumeroProtocoloUso { get; set; }
        public string SituacaoProtocoloUso { get; set; }
        public string MensagemSitucaoProtocoloUso { get; set; }
        public DateTime? DataEmissao { get; set; }

        // Cancelamento
        public string NumeroProtocoloCancelamento { get; set; }
        public string SituacaoProtocoloCancelamento { get; set; }
        public string MensagemSitucaoProtocoloCancelamento { get; set; }
        public string JustificativaCancelamento { get; set; }
        public DateTime? DataCancelamento { get; set; }

        // Correcao
        public int SeqCartaCorrecao { get; set; }
        public string Correcao { get; set; }
        public string SituacaoProtocoloCartaCorrecao { get; set; }
        public string MensagemSitucaoCartaCorrecao { get; set; }
        public string NumeroProtocoloCartaCorrecao { get; set; }
        public DateTime? DataCartaCorrecao { get; set; }
    }
}
