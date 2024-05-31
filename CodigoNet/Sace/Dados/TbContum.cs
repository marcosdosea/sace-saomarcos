using System;
using System.Collections.Generic;

namespace Dados
{
    public partial class TbContum
    {
        public TbContum()
        {
            TbMovimentacaoConta = new HashSet<TbMovimentacaoContum>();
        }

        public long CodConta { get; set; }
        public long CodPlanoConta { get; set; }
        public long CodPessoa { get; set; }
        public string CodSituacao { get; set; } = null!;
        public long? CodEntrada { get; set; }
        public long? CodSaida { get; set; }
        public DateTime DataVencimento { get; set; }
        public decimal Valor { get; set; }
        public string? Observacao { get; set; }
        public long? CodPagamento { get; set; }
        public decimal Desconto { get; set; }
        public string FormatoConta { get; set; } = null!;
        public string NumeroDocumento { get; set; } = null!;

        public virtual TbEntradum? CodEntradaNavigation { get; set; }
        public virtual TbPessoa CodPessoaNavigation { get; set; } = null!;
        public virtual TbPlanoContum CodPlanoContaNavigation { get; set; } = null!;
        public virtual TbSaidum? CodSaidaNavigation { get; set; }
        public virtual TbSituacaoContum CodSituacaoNavigation { get; set; } = null!;
        public virtual ICollection<TbMovimentacaoContum> TbMovimentacaoConta { get; set; }
    }
}
