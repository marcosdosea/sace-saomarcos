using System;
using System.Collections.Generic;
using System.Linq;
using Dados;
using Dominio;

namespace Negocio
{
    public class GerenciadorUsuario 
    {
        private static GerenciadorUsuario gUsuario;

        public static GerenciadorUsuario GetInstace()
        {
            if (gUsuario == null)
            {
                gUsuario = new GerenciadorUsuario();
            }
            return gUsuario;
        }

        /// <summary>
        /// Insere dados do usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public Int64 Inserir(Usuario usuario)
        {
            var repUsuario = new RepositorioGenerico<UsuarioE>();
            UsuarioE _usuarioE = new UsuarioE();
            try
            {

                _usuarioE.codPerfil = usuario.CodPerfil;
                _usuarioE.codPessoa = usuario.CodPessoa;
                _usuarioE.login = usuario.Login;
                _usuarioE.senha = usuario.Senha;
                
                repUsuario.Inserir(_usuarioE);
                repUsuario.SaveChanges();

                return _usuarioE.codPessoa;
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
                var repUsuario = new RepositorioGenerico<UsuarioE>();
                UsuarioE _usuarioE = repUsuario.ObterEntidade(b => b.codPessoa == usuario.CodPessoa);
                _usuarioE.codPerfil = usuario.CodPerfil;
                _usuarioE.codPessoa = usuario.CodPessoa;
                _usuarioE.login = usuario.Login;
                _usuarioE.senha = usuario.Senha;

                repUsuario.SaveChanges();
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
        public void remover(Int32 codPessoa)
        {
            if (codPessoa == 1)
                throw new NegocioException("O usuario não pode ser removido.");
            try
            {
                var repUsuario = new RepositorioGenerico<UsuarioE>();
                repUsuario.Remover(b => b.codPessoa == codPessoa);
                repUsuario.SaveChanges();
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
            var repUsuario = new RepositorioGenerico<UsuarioE>();
            var saceEntities = (SaceEntities)repUsuario.ObterContexto();
            var query = from usuario in saceEntities.UsuarioSet
                        join pessoa in saceEntities.PessoaSet on usuario.codPessoa equals pessoa.codPessoa
                        join perfil in saceEntities.PerfilSet on usuario.codPerfil equals perfil.codPerfil
                        select new Usuario
                        {
                            CodPessoa = usuario.codPessoa,
                            CodPerfil = (int) usuario.codPerfil,
                            Login = usuario.login,
                            NomePerfil = perfil.nome,
                            NomePessoa = pessoa.nome,
                            Senha = usuario.senha
                        };
            return query;
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
            var repPerfil = new RepositorioGenerico<PerfilE>();
            var saceEntities = (SaceEntities)repPerfil.ObterContexto();
            var query = from perfil in saceEntities.PerfilSet
                        select new Perfil
                        {
                            IdPerfil = perfil.codPerfil,
                            NomePerfil = perfil.nome
                        };
            return query.ToList();
        }
    }
}
