using System;
using System.Collections.Generic;

#nullable disable

namespace Dados
{
    public partial class TbNfe
    {
        public TbNfe()
        {
            TbSaidaNves = new HashSet<TbSaidaNfe>();
        }

        public int CodNfe { get; set; }
        public int CodLoja { get; set; }
        public int NumeroSequenciaNfe { get; set; }
        public string Modelo { get; set; }
        public string Chave { get; set; }
        public string SituacaoNfe { get; set; }
        public string NumeroLoteEnvio { get; set; }
        public string NumeroRecibo { get; set; }
        public string SituacaoReciboEnvio { get; set; }
        public string MensagemSituacaoReciboEnvio { get; set; }
        public string NumeroProtocoloUso { get; set; }
        public string SituacaoProtocoloUso { get; set; }
        public string MensagemSituacaoProtocoloUso { get; set; }
        public string NumeroProtocoloCancelamento { get; set; }
        public string SituacaoProtocoloCancelamento { get; set; }
        public string MensagemSituacaoProtocoloCancelamento { get; set; }
        public string JustificativaCancelamento { get; set; }
        public DateTime? DataEmissao { get; set; }
        public DateTime? DataCancelamento { get; set; }
        public int SeqCartaCorrecao { get; set; }
        public string Correcao { get; set; }
        public string SituacaoProtocoloCartaCorrecao { get; set; }
        public string MensagemSitucaoCartaCorrecao { get; set; }
        public string NumeroProtocoloCartaCorrecao { get; set; }
        public DateTime? DataCartaCorrecao { get; set; }
        public long CodSolicitacao { get; set; }

        public virtual ICollection<TbSaidaNfe> TbSaidaNves { get; set; }
    }
}
