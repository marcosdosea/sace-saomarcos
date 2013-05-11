using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class NfeControle
    {
        public const char SITUACAO_SOLICITADA = 'S';
        public const char SITUACAO_AUTORIZADA = 'A';
        public const char SITUACAO_CANCELADA = 'C';
        public const char SITUACAO_DENEGADA = 'D'; // Quando há alguma irregularidade com o emitente
        public const char SITUACAO_INUTILIZADA = 'I';
        public const char SITUACAO_REJEITADA = 'R';

        public int CodNfe { get; set; }
        public string Chave { get; set; }
        public string LoteEnvio { get; set; }
        public char Situacao { get; set; }
        public string ProtocoloAutorizacao { get; set; }
        public string JustificativaCancelamento { get; set; }
        public string ProtocoloCancelamento { get; set; }
        public long CodSaida { get; set; }
    }
}
