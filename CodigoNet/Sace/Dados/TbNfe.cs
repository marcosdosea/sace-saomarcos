using System;
using System.Collections.Generic;

namespace Dados
{
    public partial class TbNfe
    {
        public TbNfe()
        {
            TbSolicitacaoEventoNves = new HashSet<TbSolicitacaoEventoNfe>();
            CodSaida = new HashSet<TbSaidum>();
        }

        public int CodNfe { get; set; }
        public int CodLoja { get; set; }
        public int NumeroSequenciaNfe { get; set; }
        public string Modelo { get; set; } = null!;
        public string Chave { get; set; } = null!;
        public string SituacaoNfe { get; set; } = null!;
        public string NumeroLoteEnvio { get; set; } = null!;
        public string NumeroRecibo { get; set; } = null!;
        public string SituacaoReciboEnvio { get; set; } = null!;
        public string MensagemSituacaoReciboEnvio { get; set; } = null!;
        public string NumeroProtocoloUso { get; set; } = null!;
        public string SituacaoProtocoloUso { get; set; } = null!;
        public string MensagemSituacaoProtocoloUso { get; set; } = null!;
        public string NumeroProtocoloCancelamento { get; set; } = null!;
        public string SituacaoProtocoloCancelamento { get; set; } = null!;
        public string MensagemSituacaoProtocoloCancelamento { get; set; } = null!;
        public string JustificativaCancelamento { get; set; } = null!;
        public DateTime? DataEmissao { get; set; }
        public DateTime? DataCancelamento { get; set; }
        public int SeqCartaCorrecao { get; set; }
        public string Correcao { get; set; } = null!;
        public string SituacaoProtocoloCartaCorrecao { get; set; } = null!;
        public string MensagemSitucaoCartaCorrecao { get; set; } = null!;
        public string NumeroProtocoloCartaCorrecao { get; set; } = null!;
        public DateTime? DataCartaCorrecao { get; set; }
        public long CodSolicitacao { get; set; }

        public virtual TbLoja CodLojaNavigation { get; set; } = null!;
        public virtual ICollection<TbSolicitacaoEventoNfe> TbSolicitacaoEventoNves { get; set; }

        public virtual ICollection<TbSaidum> CodSaida { get; set; }
    }
}
