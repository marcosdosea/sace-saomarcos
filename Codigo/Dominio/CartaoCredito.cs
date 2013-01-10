using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class CartaoCredito
    {
        public int CodCartao { get; set; }
        public string Nome { get; set; }
        public int DiaBase { get; set; }
        public int CodContaBanco { get; set; }
        public string DescricaoContaBanco { get; set; }
        public long CodPessoa { get; set; }
        public string NomePessoa { get; set; }
        public string Mapeamento { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return this.CodCartao == ((CartaoCredito)obj).CodCartao;    
        }

       
        // override object.GetHashCode
        public override int GetHashCode()
        {
            return this.CodCartao.GetHashCode();
        }
    }
}
