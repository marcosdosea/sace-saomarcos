using System;
using System.Collections.Generic;

#nullable disable

namespace Dados
{
    public partial class TbLoja
    {
        public TbLoja()
        {
            TbSaida = new HashSet<TbSaidum>();
        }

        public int CodLoja { get; set; }
        public string Nome { get; set; }
        public long CodPessoa { get; set; }
        public string NomeServidorNfe { get; set; }
        public string EnderecoServidorNfe { get; set; }
        public string PastaNfeEnvio { get; set; }
        public string PastaNfeEnviado { get; set; }
        public string PastaNfeRetorno { get; set; }
        public string PastaNfeErro { get; set; }
        public string PastaNfeAutorizados { get; set; }
        public string PastaNfeEspelho { get; set; }
        public int NumeroSequenciaNfeAtual { get; set; }
        public int NumeroSequencialNfceAtual { get; set; }
        public string PastaNfeValidar { get; set; }
        public string PastaNfeValidado { get; set; }

        public virtual ICollection<TbSaidum> TbSaida { get; set; }
    }
}
