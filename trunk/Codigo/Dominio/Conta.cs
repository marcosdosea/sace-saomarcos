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
        public const Char SITUACAO_CANCELADA = 'C';

        private Int64 CodConta { get; set; }
        public Int64 CodEntrada { get; set; }
        public Int64 CodSaida { get; set; }
        public Int64 CodDocumento { get; set; }
        public Int64 CodPlanoConta { get; set; }
        public Int64 CodPessoa { get; set; }
        public DateTime DataVencimento { get; set; }
        public decimal Valor { get; set; }
        public Char CodSituacao { get; set; }
        public String Observacao { get; set; }
        public Char TipoConta { get; set; }
        public decimal Desconto { get; set; }
    }
}