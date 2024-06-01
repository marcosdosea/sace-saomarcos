namespace Dominio
{
    public class SituacaoConta
    {
        public const string SITUACAO_ABERTA = "A";
        public const string SITUACAO_QUITADA = "Q";
        public const string SITUACAO_SUBTITUIDA = "S";

        public string CodSituacao { get; set; }
        public string Descricao { get; set; }
    }
}
