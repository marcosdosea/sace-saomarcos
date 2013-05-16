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
        
        public string NumeroLoteEnvio { get; set; }
        public string NumeroRecibo { get; set; }
        public string SituacaoReciboEnvio { get; set; }
        public string MensagemSituacaoReciboEnvio { get; set; }

        public string NumeroProtocoloUso { get; set; }
        public string SituacaoProtocoloUso { get; set; }
        public string MensagemSitucaoProtocoloUso { get; set; }
        
        public string NumeroProtocoloCancelamento { get; set; }
        public string SituacaoProtocoloCancelamento { get; set; }
        public string MensagemSitucaoProtocoloCancelamento { get; set; }
        public string JustificativaCancelamento { get; set; }
    }
}
