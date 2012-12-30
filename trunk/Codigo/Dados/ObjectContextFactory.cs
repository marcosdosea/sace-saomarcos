using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Objects;
using System.Data.Entity;

namespace Dados
{
    /// <summary>
    /// Implementada como Singleton esse DbContext evita que o garbage collector fique removendo
    /// da memória a cada chamada o contexto. Facilita também a reutilização de objetos que foram
    /// recuperados pelo DbContext podendo ser reaproveitados entre múltiplas requisições.
    /// </summary>
    /// <typeparam name="TDbContext"></typeparam>

    public sealed class ObjectContextFactory<TObjectContext> where TObjectContext : ObjectContext, new()
    {
        /// <summary>
        /// instância do singleton
        /// </summary>
        private static volatile ObjectContextFactory<TObjectContext> _singleton;

        /// <summary>
        /// semáfaro para sincronização
        /// </summary>
        private static readonly object syncRoot = new Object();

        /// <summary>
        /// aramazena instâncias dos contextos
        /// </summary>
        private readonly Dictionary<string, TObjectContext> _storage;

        /// <summary>
        /// Obter uma instância do Singleton
        /// </summary>
        public static ObjectContextFactory<TObjectContext> Singleton
        {
            get
            {
                if (_singleton == null)
                {
                    lock (syncRoot)
                    {
                        if (_singleton == null)
                        {
                            _singleton = new ObjectContextFactory<TObjectContext>();
                        }
                    }
                }
                return _singleton;
            }
        }

        /// <summary>
        /// Construtor privado para impedir criação de instâncias não controladas
        /// </summary>
        private ObjectContextFactory() { 
            _storage = new Dictionary<string, TObjectContext>(); 
        }

        /// <summary>
        /// Cria ou recupera contexto de acordo com a chave passada
        /// </summary>
        /// <param name="chave"> identifica os contextos criados </param>
        /// <returns>um contexto de acordo com a chave </returns>
        public TObjectContext GetOrCreateContext(string chave)
        {
            if (_storage.ContainsKey(chave))
            {
                return _storage[chave];
            }


            var dbContext = new TObjectContext();
            _storage.Add(chave, dbContext);
            return dbContext;
        }
    }
}