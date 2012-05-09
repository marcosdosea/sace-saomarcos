using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;


namespace Negocio
{
    public interface IGerenciadorSaida
    {

        Int64 inserir(Saida saida);

        /// <summary>
        /// Remover dados do meio persistente buscando pela chave
        /// </summary>
        /// <param name="c"></param>
        void remover(Saida saida);

        /// <summary>
        /// Atualizar dados do meio persistente
        /// </summary>
        /// <param name="t"></param>
        void atualizar(Saida saida);
        
        Saida obterSaida(Int64 codSaida);

        void encerrar(Saida saida);

        Boolean dataVencimentoProdutoAceitavel(Produto produto, DateTime dataVencimento);

        void gerarDocumentoFiscal(Saida saida);

        Boolean atualizarPedidosComDocumentosFiscais();
        void registrarPagamentosSaida(List<SaidaPagamento> pagamentos, Saida saida);

        void imprimirDAV(Saida saida, bool comprimido);

        void imprimirNotaFiscal(Saida saida);

        void removerPreVenda(Saida saida);
    }
}