namespace Dominio
{
    public class SolicitacaoEventoNfe
    {
        public uint IdSolicitacaoEvento { get; set; }
        public string TipoSolicitacao { get; set; } = null!;
        public int CodNfe { get; set; }
    }
}
