namespace Dominio
{
    public class PlanoConta
    {
        public const int ENTRADA_PRODUTOS = 1;
        public const int SAIDA_PRODUTOS = 2;
        public const int RECEBIMENTO_CREDIARIO = 3;
        

        public long CodPlanoConta { get; set; }
        public int CodGrupoConta { get; set; }
        public string Descricao { get; set; }
        public string TipoConta { get; set; }
        public string DescricaoTipoConta { get; set; }
        public short DiaBase { get; set; }
    }
}