using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class SituacaoConta
    {
        public const string SITUACAO_ABERTA = "A";
        public const string SITUACAO_QUITADA = "Q";
        
        public string CodSituacao { get; set; }
        public string Descricao { get; set; }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return this.CodSituacao == ((SituacaoConta)obj).CodSituacao;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return this.CodSituacao.GetHashCode();
        }
    }
}
