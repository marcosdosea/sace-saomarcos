using System;
using System.Collections.Generic;

namespace Dados
{
    public partial class TbContaBanco
    {
        public TbContaBanco()
        {
            TbCartaoCreditos = new HashSet<TbCartaoCredito>();
            TbMovimentacaoConta = new HashSet<TbMovimentacaoContum>();
            TbSaidaFormaPagamentos = new HashSet<TbSaidaFormaPagamento>();
        }

        public int CodContaBanco { get; set; }
        public string Numeroconta { get; set; } = null!;
        public string? Agencia { get; set; }
        public string? Descricao { get; set; }
        public decimal? Saldo { get; set; }
        public int? CodBanco { get; set; }

        public virtual TbBanco? CodBancoNavigation { get; set; }
        public virtual ICollection<TbCartaoCredito> TbCartaoCreditos { get; set; }
        public virtual ICollection<TbMovimentacaoContum> TbMovimentacaoConta { get; set; }
        public virtual ICollection<TbSaidaFormaPagamento> TbSaidaFormaPagamentos { get; set; }
    }
}
