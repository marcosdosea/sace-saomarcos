using System;
using System.Collections.Generic;

namespace Dados
{
    public partial class TbCartaoCredito
    {
        public TbCartaoCredito()
        {
            TbSaidaFormaPagamentos = new HashSet<TbSaidaFormaPagamento>();
            TbSolicitacaoPagamentos = new HashSet<TbSolicitacaoPagamento>();
        }

        public int CodCartao { get; set; }
        public string Nome { get; set; } = null!;
        public int? DiaBase { get; set; }
        public int CodContaBanco { get; set; }
        public string? Mapeamento { get; set; }
        public long CodPessoa { get; set; }
        public decimal Desconto { get; set; }
        public string MapeamentoCappta { get; set; } = null!;
        public string TipoCartao { get; set; } = null!;

        public virtual TbContaBanco CodContaBancoNavigation { get; set; } = null!;
        public virtual TbPessoa CodPessoaNavigation { get; set; } = null!;
        public virtual ICollection<TbSaidaFormaPagamento> TbSaidaFormaPagamentos { get; set; }
        public virtual ICollection<TbSolicitacaoPagamento> TbSolicitacaoPagamentos { get; set; }
    }
}
