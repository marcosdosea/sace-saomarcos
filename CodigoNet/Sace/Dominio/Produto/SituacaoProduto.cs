﻿namespace Dominio
{
    public class SituacaoProduto
    {
        public const int DISPONIVEL = 1;
        public const int COMPRA_NECESSARIA = 2;
        public const int COMPRA_URGENTE = 3;
        public const int COMPRADO = 4;
        public const int NAO_COMPRAR = 5;

        public sbyte CodSituacaoProduto { get; set; }
        public string DescricaoSituacao { get; set; }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return this.CodSituacaoProduto == ((SituacaoProduto)obj).CodSituacaoProduto;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return this.CodSituacaoProduto.GetHashCode();
        }
    }
}
