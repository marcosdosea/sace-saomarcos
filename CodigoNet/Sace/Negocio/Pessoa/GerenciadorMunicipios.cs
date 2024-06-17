using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;

namespace Negocio
{
    public class GerenciadorMunicipio
    {
        private readonly SaceContext context;

        public GerenciadorMunicipio(SaceContext saceContext)
        {
            context = saceContext;
        }

        /// <summary>
        /// Insere uma Municipio no banco de dados
        /// </summary>
        /// <param name="Municipio"></param>
        /// <returns></returns>
        public int Inserir(MunicipiosIBGE municipio)
        {
            try
            {
                var _municipio = new TbMunicipiosIbge(); 
                Atribuir(municipio, _municipio);

                context.Add(_municipio);
                context.SaveChanges();
                return _municipio.Codigo;
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
        public void Atualizar(MunicipiosIBGE municipio)
        {
            try
            {
                var _municipio = new TbMunicipiosIbge();
                _municipio.Codigo = municipio.Codigo;
                _municipio = context.TbMunicipiosIbges.Find(_municipio);
                if (_municipio != null)
                {
                    Atribuir(municipio, _municipio);
                    context.SaveChanges();
                }
                else
                {
                    throw new NegocioException("Município para atualização não encontrado.");
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
        public void Remover(int codMunicipio)
        {
            try
            {
                var municipio = new TbMunicipiosIbge();
                municipio.Codigo = codMunicipio;

                context.Remove(municipio);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DadosException("Municipio", e.Message, e);
            }
        }

        private IQueryable<MunicipiosIBGE> GetQuery()
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
        private TbMunicipiosIbge Atribuir(MunicipiosIBGE municipio, TbMunicipiosIbge _municipio)
        {
            _municipio.Codigo = municipio.Codigo;
            _municipio.Municipio = municipio.Municipio;
            _municipio.Uf = municipio.Uf;
            return _municipio;
        }
    }
}
