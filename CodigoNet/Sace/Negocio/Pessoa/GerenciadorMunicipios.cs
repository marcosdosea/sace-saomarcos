using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;

namespace Negocio
{
    public static class GerenciadorMunicipio
    {

        /// <summary>
        /// Insere uma Municipio no banco de dados
        /// </summary>
        /// <param name="Municipio"></param>
        /// <returns></returns>
        public static int Inserir(MunicipiosIBGE municipio)
        {
            try
            {
                var _municipio = new TbMunicipiosIbge();
                Atribuir(municipio, _municipio);
                using (var context = new SaceContext())
                {
                    context.Add(_municipio);
                    context.SaveChanges();
                    return _municipio.Codigo;
                }
            }
            catch (Exception e)
            {
                throw new DadosException("Municipio", e.Message, e);
            }
        }

        /// <summary>
        /// Atualiza os dados de um Municipio
        /// </summary>
        /// <param name="Municipio"></param>
        public static void Atualizar(MunicipiosIBGE municipio)
        {
            try
            {
                using (var context = new SaceContext())
                {
                    var _municipio = context.TbMunicipiosIbges.FirstOrDefault(m => m.Codigo == municipio.Codigo);
                    if (_municipio != null)
                    {
                        Atribuir(municipio, _municipio);
                        context.Update(_municipio);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new NegocioException("Município não encontrado para atualização.");
                    }
                }
            }
            catch (Exception e)
            {
                throw new DadosException("Municipio", e.Message, e);
            }
        }

        /// <summary>
        /// Remove os dados de uma Municipio
        /// </summary>
        /// <param name="codMunicipio"></param>
        public static void Remover(int codMunicipio)
        {
            try
            {
                using (var context = new SaceContext())
                {
                    var _municipio = context.TbMunicipiosIbges.FirstOrDefault(m => m.Codigo == codMunicipio);
                    if (_municipio != null)
                    {
                        context.Remove(_municipio);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new NegocioException("Município não encontrado para remoção.");
                    }
                }
            }
            catch (Exception e)
            {
                throw new DadosException("Municipio", e.Message, e);
            }
        }

        private static IQueryable<MunicipiosIBGE> GetQuery(SaceContext context)
        {
            var query = from municipios in context.TbMunicipiosIbges
                        select new MunicipiosIBGE
                        {
                            Codigo = municipios.Codigo,
                            Municipio = municipios.Municipio,
                            Uf = municipios.Uf
                        };
            return query.AsNoTracking();
        }

        /// <summary>
        /// Obtém todos as Municipios cadastradas
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<MunicipiosIBGE> ObterTodos()
        {
            using (var context = new SaceContext())
            {
                return GetQuery(context).OrderBy(m => m.Municipio).ToList();
            }
        }

        /// <summary>
        /// Obtém todos as Municipios cadastradas
        /// </summary>
        /// <returns></returns>
        public static MunicipiosIBGE ObterPorCidadeEstado(string municipio, string siglaEstado)
        {
            using (var context = new SaceContext())
            {
                return GetQuery(context).OrderBy(m => m.Municipio.Equals(municipio) && m.Uf.Equals(siglaEstado)).ToList().ElementAtOrDefault(0);
            }
        }

        /// <summary>
        /// Atribui os dados de Municipio à entidade Municipio
        /// </summary>
        /// <param name="Municipio"></param>
        /// <param name="_Municipio"></param>
        /// <returns></returns>
        private static void Atribuir(MunicipiosIBGE municipio, TbMunicipiosIbge _municipio)
        {
            _municipio.Codigo = municipio.Codigo;
            _municipio.Municipio = municipio.Municipio;
            _municipio.Uf = municipio.Uf;
        }
    }
}
