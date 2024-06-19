namespace Dominio
{
    public class SolicitacaoSaida
    {
        public long CodSolicitacao { get; set; }
        public long CodSaida { get; set; }
        public decimal ValorTotal { get; set; }
        public int CodLojaOrigem { get; set; }
    }
}
