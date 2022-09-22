using System;
using System.Collections.Generic;

#nullable disable

namespace Dados
{
    public partial class TbSolicitacaoDocumento
    {
        public TbSolicitacaoDocumento()
        {
            TbSolicitacaoPagamentos = new HashSet<TbSolicitacaoPagamento>();
            TbSolicitacaoSaida = new HashSet<TbSolicitacaoSaidum>();
        }

        public long CodSolicitacao { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public string TipoSolicitacao { get; set; }
        public bool HaPagamentoCartao { get; set; }
        public bool EhEspelho { get; set; }
        public bool EhComplementar { get; set; }
        public bool CartaoProcessado { get; set; }
        public bool CartaoAutorizado { get; set; }
        public bool NfeProcessada { get; set; }
        public int CodMotivoCartaoNegado { get; set; }
        public string MotivoCartaoNegado { get; set; }
        public bool EmProcessamento { get; set; }
        public string HostSolicitante { get; set; }

        public virtual ICollection<TbSolicitacaoPagamento> TbSolicitacaoPagamentos { get; set; }
        public virtual ICollection<TbSolicitacaoSaidum> TbSolicitacaoSaida { get; set; }
    }
}
