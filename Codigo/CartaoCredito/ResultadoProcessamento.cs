using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cartao
{
    public class RespostaRecusada
    {
        public int CodMotivo { get; set; }
        public string Motivo { get; set; }

    }

    public class RespostaAprovada 
    {
        public string CodAutorizacaoAdquirente { get; set; }
        public string CupomCliente { get; set; }
        public string CupomLojista { get; set; }
        public string CupomReduzido { get; set; }
        public DateTime DataHoraAutorizacao { get; set; }
        public string NomeAdquirente { get; set; }
        public string NomeBandeiraCartao { get; set; }
        public string NsuAdquirente { get; set; }
        public string NsuTef { get; set; }
        public string NumeroControle { get; set; }
        public double Valor { get; set; }
        public TipoCartao TipoCartao { get; set; }
        public long CodSolicitacaoPagamento { get; set; }
    }
    
    public class ResultadoProcessamento
    {
        public ResultadoProcessamento()
        {
            ListaRespostaAprovada = new List<RespostaAprovada>();
        }
        public bool Aprovado { get; set; }
        public long CodSolicitacao { get; set; }
        public RespostaRecusada RespostaRecusada { get; set; }
        public List<RespostaAprovada> ListaRespostaAprovada { get; set; }
    }
}
