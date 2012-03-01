using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Negocio
{
    /// <summary>
    /// Gerenciador Genérico das Classes de Negócio.
    /// Necessário para fazer operações de atualização no meio persistente.
    /// </summary>
    /// <typeparam name="T">Tipo do objeto que será inserido</typeparam>
    /// <typeparam name="C">Atributos Chave do objeto</typeparam>
    public interface IGerenciadorNegocio<T, C>    
    {
        /// <summary>
        /// Inserir dados no meio persistente
        /// </summary>
        /// <param name="t"></param>
        Int64 inserir(T t);

        /// <summary>
        /// Remover dados do meio persistente buscando pela chave
        /// </summary>
        /// <param name="c"></param>
        void remover(C c);

        /// <summary>
        /// Atualizar dados do meio persistente
        /// </summary>
        /// <param name="t"></param>
        void atualizar(T t);

    }
}
