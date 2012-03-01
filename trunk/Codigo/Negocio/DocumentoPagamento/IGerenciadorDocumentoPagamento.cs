using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;


namespace Negocio
{
    public interface IGerenciadorDocumentoPagamento: IGerenciadorNegocio<DocumentoPagamento, Int64>
    {
        DocumentoPagamento obterDocumentoPagamento(Int64 codDocumentoPagamento);
    }
}
