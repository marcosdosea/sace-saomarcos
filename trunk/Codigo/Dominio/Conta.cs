using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Conta
    {
        public const Char CONTA_PAGAR = 'P';
        public const Char CONTA_RECEBER = 'R';
        public const Char SITUACAO_ABERTA = 'A';
        public const Char SITUACAO_QUITADA = 'Q';
        public const Char SITUACAO_PARCIALMENTE_QUITADA = 'P';
        public const char SITUACAO_CANCELADA = 'C';

        public long CodConta { get; set; }
        public long CodEntrada { get; set; }
        public long CodSaida { get; set; }
        public long CodDocumento { get; set; }
        public long CodPlanoConta { get; set; }
        public long CodPessoa { get; set; }
        public DateTime DataVencimento { get; set; }
        public decimal Valor { get; set; }
        public char CodSituacao { get; set; }
        public string Observacao { get; set; }
        public char TipoConta { get; set; }
        public long CodPagamento { get; set; }
        public decimal Desconto { get; set; }
    }
}