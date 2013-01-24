using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class MovimentacaoConta
    {
        public const int RECEBIMENTO_CLIENTE = 1;
        public const int PAGAMENTO_FORNECEDOR = 2;
        public const int TROCO_CLIENTE = 3;
        public const int DEVOLUCAO_CLIENTE = 4;

        public long CodMovimentacao { get; set; }
        public int CodTipoMovimentacao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataHora { get; set; }
        public long CodResponsavel { get; set; }
        public int CodContaBanco { get; set; }
        public long CodConta  { get; set; }
        public Boolean SomaSaldo { get; set; }
        public string DescricaoTipoMovimentacao { get; set; }
        public string NomeResponsavel { get; set; }
    }
}