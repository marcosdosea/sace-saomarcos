using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;

namespace Negocio
{
    public class GerenciadorUsuario 
    {
        private readonly SaceContext context;
        
        public GerenciadorUsuario(SaceContext context) { 
            this.context = context; 
        }

        /// <summary>
        /// Insere dados do usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public long Inserir(Usuario usuario)
        {
            TbUsuario _usuario = new TbUsuario();
            try
            {

                _usuario.CodPerfil = usuario.CodPerfil;
                _usuario.CodPessoa = usuario.CodPessoa;
                _usuario.Login = usuario.Login;
                _usuario.Senha = usuario.Senha;
                
                context.Add(_usuario);
                context.SaveChanges();

                return _usuario.CodPessoa;
            }
            catch (Exception e)
            {
                throw new DadosException("Usuario", e.Message, e);
            }

        }

        /// <summary>
        /// Atualiza dados do usuario
        /// </summary>
        /// <param name="usuario"></param>
        public void Atualizar(Usuario usuario)
        {
            try
            {
                var _usuario = context.TbUsuarios.Find(new TbUsuario() { CodPessoa = usuario.CodPessoa });
                if (_usuario != null)
                {
                    _usuario.CodPerfil = usuario.CodPerfil;
                    _usuario.CodPessoa = usuario.CodPessoa;
                    _usuario.Login = usuario.Login;
                    _usuario.Senha = usuario.Senha;

                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new DadosException("Usuario", e.Message, e);
            }
        }

        /// <summary>
        /// Remove dados do usuario
        /// </summary>
        /// <param name="codUsuario"></param>
        public void Remover(int codPessoa)
        {
            if (codPessoa == 1)
                throw new NegocioException("O usuario não pode ser removido.");
            try
            {
                context.Remove(new TbUsuario() { CodPessoa = codPessoa });
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DadosException("Usuario", e.Message, e);
            }
        }

        /// <summary>
        /// Consulta para retornar dados da entidade
        /// </summary>
        /// <returns></returns>
        private IQueryable<Usuario> GetQuery()
        {
            var query = from usuario in context.TbUsuarios
                        select new Usuario
                        {
                            CodPessoa = usuario.CodPessoa,
                            CodPerfil = (int) usuario.CodPerfil,
                            Login = usuario.Login,
                            NomePerfil = usuario.CodPerfilNavigation.Nome,
                            NomePessoa = usuario.CodPessoaNavigation.Nome,
                            Senha = usuario.Senha
                        };
            return query.AsNoTracking();
        }

        /// <summary>
        /// Obtém todos os usuario cadastrados
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Usuario> ObterTodos()
        {
            return GetQuery().ToList();
        }

        /// <summary>
        /// Obtém usuario com o código especificiado
        /// </summary>
        /// <param name="codUsuario"></param>
        /// <returns></returns>
        public IEnumerable<Usuario> Obter(int codPessoa)
        {
            return GetQuery().Where(usuario => usuario.CodPessoa == codPessoa).ToList();
        }

        /// <summary>
        /// Obtém usuarios que iniciam com o nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        public IEnumerable<Usuario> ObterPorLogin(string login)
        {
            return GetQuery().Where(usuario => usuario.Login.StartsWith(login)).ToList();
        }

        /// <summary>
        /// Obtém usuarios que iniciam com o nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        public IEnumerable<Perfil> ObterPerfis()
        {
            var query = from perfil in context.TbPerfils
                        select new Perfil
                        {
                            IdPerfil = perfil.CodPerfil,
                            NomePerfil = perfil.Nome
                        };
            return query.AsNoTracking().ToList();
        }
    }
}
