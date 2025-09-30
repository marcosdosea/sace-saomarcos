namespace Dominio
{
    public class SaidaPesquisa
    {
        public long CodSaida { get; set; }
        public long CodCliente { get; set; }
        public string NomeCliente { get; set; }
        public DateTime DataSaida { get; set; }
        public string CupomFiscal { get; set; }
        public decimal TotalAVista { get; set; }
        public int TipoSaida { get; set; }
        public string DescricaoTipoSaida { get; set; }
        public int CodSituacaoPagamentos { get; set; }

        //TODO: colocar número da ecf no banco de dados.
        public string NumeroECF { get { return "01"; } }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return this.CodSaida.Equals(((SaidaPesquisa)obj).CodSaida);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return this.CodSaida.GetHashCode();
        }

    }
}