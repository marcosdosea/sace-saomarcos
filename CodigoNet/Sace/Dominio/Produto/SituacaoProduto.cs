namespace Dominio
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
    }
}
