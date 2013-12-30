using System;
using System.Collections.Generic;
using System.Linq;
using Dados;
using Dominio;

namespace Negocio
{
    public class GerenciadorMunicipio
    {
        private static GerenciadorMunicipio gMunicipio;
        
        public static GerenciadorMunicipio GetInstance()
        {
            if (gMunicipio == null)
            {
                gMunicipio = new GerenciadorMunicipio();
            }
            return gMunicipio;
        }

        /// <summary>
        /// Insere uma Municipio no banco de dados
        /// </summary>
        /// <param name="Municipio"></param>
        /// <returns></returns>
        public Int64 Inserir(MunicipiosIBGE Municipio)
        {
            try
            {
                var repMunicipio = new RepositorioGenerico<MunicipiosIbgeE>();

                MunicipiosIbgeE _Municipio = new MunicipiosIbgeE(); 
                Atribuir(Municipio, _Municipio);
               
                repMunicipio.Inserir(_Municipio);
                repMunicipio.SaveChanges();
                return _Municipio.codigo;
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
        public void Atualizar(MunicipiosIBGE Municipio)
        {
            var repMunicipio = new RepositorioGenerico<MunicipiosIbgeE>();

            try
            {
                MunicipiosIbgeE _Municipio = repMunicipio.ObterEntidade(p => p.codigo == Municipio.Codigo);

                Atribuir(Municipio, _Municipio);
                repMunicipio.SaveChanges();
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
        public void Remover(Int64 codMunicipio)
        {
            var repMunicipio = new RepositorioGenerico<MunicipiosIbgeE>();

            try
            {
                repMunicipio.Remover(Municipio => Municipio.codigo == codMunicipio);
                repMunicipio.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DadosException("Municipio", e.Message, e);
            }
        }

        private IQueryable<MunicipiosIBGE> GetQuery()
        {
            var repMunicipios = new RepositorioGenerico<MunicipiosIbgeE>();

            var saceEntities = (SaceEntities)repMunicipios.ObterContexto();
            var query = from municipios in saceEntities.MunicipiosIbgeSet
                        select new MunicipiosIBGE
                        {
                            Codigo = municipios.codigo,
                            Municipio = municipios.municipio,
                            Uf = municipios.uf
                        };
            return query;
        }

        /// <summary>
        /// Obtém todos as Municipios cadastradas
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MunicipiosIBGE> ObterTodos()
        {
            return GetQuery().OrderBy(m=> m.Municipio).ToList();
        }

        /// <summary>
        /// Obtém todos as Municipios cadastradas
        /// </summary>
        /// <returns></returns>
        public MunicipiosIBGE ObterPorCidadeEstado(string municipio, string siglaEstado)
        {
            return GetQuery().OrderBy(m => m.Municipio.Equals(municipio) && m.Uf.Equals(siglaEstado)).ToList().ElementAtOrDefault(0);
        }
        
        /// <summary>
        /// Atribui os dados de Municipio à entidade Municipio
        /// </summary>
        /// <param name="Municipio"></param>
        /// <param name="_Municipio"></param>
        /// <returns></returns>
        private MunicipiosIbgeE Atribuir(MunicipiosIBGE Municipio, MunicipiosIbgeE _Municipio)
        {
            _Municipio.codigo = Municipio.Codigo;
            _Municipio.municipio = Municipio.Municipio;
            _Municipio.uf = Municipio.Uf;
            return _Municipio;
        }
    }
}
