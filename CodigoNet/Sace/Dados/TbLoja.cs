using System;
using System.Collections.Generic;

namespace Dados
{
    public partial class TbLoja
    {
        public TbLoja()
        {
            TbNves = new HashSet<TbNfe>();
            TbProdutoLojas = new HashSet<TbProdutoLoja>();
            TbSaida = new HashSet<TbSaidum>();
        }

        public int CodLoja { get; set; }
        public string Nome { get; set; } = null!;
        public long CodPessoa { get; set; }
        public string NomeServidorNfe { get; set; } = null!;
        public string EnderecoServidorNfe { get; set; } = null!;
        public string PastaNfeEnvio { get; set; } = null!;
        public string PastaNfeEnviado { get; set; } = null!;
        public string PastaNfeRetorno { get; set; } = null!;
        public string PastaNfeErro { get; set; } = null!;
        public string PastaNfeAutorizados { get; set; } = null!;
        public string PastaNfeEspelho { get; set; } = null!;
        public int NumeroSequenciaNfeAtual { get; set; }
        public int NumeroSequencialNfceAtual { get; set; }
        public string PastaNfeValidar { get; set; } = null!;
        public string PastaNfeValidado { get; set; } = null!;

        public virtual TbPessoa CodPessoaNavigation { get; set; } = null!;
        public virtual ICollection<TbNfe> TbNves { get; set; }
        public virtual ICollection<TbProdutoLoja> TbProdutoLojas { get; set; }
        public virtual ICollection<TbSaidum> TbSaida { get; set; }
    }
}
