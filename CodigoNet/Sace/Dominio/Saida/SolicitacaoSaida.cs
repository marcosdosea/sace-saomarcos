namespace Dominio
{
    public class SolicitacaoSaida
    {
        public long CodSolicitacao { get; set; }
        public long CodSaida { get; set; }
        public decimal ValorTotal { get; set; }
        public int CodLojaOrigem { get; set; }
        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return CodSolicitacao.Equals(((SolicitacaoSaida)obj).CodSolicitacao);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return CodSolicitacao.GetHashCode();
        }
    }
}
