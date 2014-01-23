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
        
        public long CodConta { get; set; }
        public long CodEntrada { get; set; }
        public long CodSaida { get; set; }
        public string Nfe { get; set; }
        public long CodPlanoConta { get; set; }
        public long CodPessoa { get; set; }
        public DateTime DataVencimento { get; set; }
        public decimal Valor { get; set; }
        public string CodSituacao { get; set; }
        public string DescricaoSituacao { get; set; }
        public string Observacao { get; set; }
        public string TipoConta { get; set; }
        public string CF { get; set; }
        public decimal ValorPagar
        {
            get { return Valor - Desconto; }
        }
      
        public long? CodPagamento { get; set; }
        public decimal Desconto { get; set; }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return this.CodConta == ((Conta)obj).CodConta;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return this.CodConta.GetHashCode();
        }
    }
}