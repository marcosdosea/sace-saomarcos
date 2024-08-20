namespace Dominio
{
    public class SolicitacaoDocumento
    {
        public long CodSolicitacao { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public string? TipoSolicitacao { get; set; }
        public bool HaPagamentoCartao { get; set; }
        public bool EhEspelho { get; set; }
        public bool EhComplementar { get; set; }
        public bool CartaoProcessado { get; set; }
        public bool CartaoAutorizado { get; set; }
        public bool NfeProcessada { get; set; }
        public int CodMotivoCartaoNegado { get; set; }
        public string MotivoCartaoNegado { get; set; } = null!;
        public bool EmProcessamento { get; set; }
        public string HostSolicitante { get; set; } = null!;

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return CodSolicitacao.Equals(((SolicitacaoDocumento)obj).CodSolicitacao);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return CodSolicitacao.GetHashCode();
        }
    }
}
