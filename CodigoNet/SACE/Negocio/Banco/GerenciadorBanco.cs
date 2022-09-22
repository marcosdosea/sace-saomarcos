using Dados;
using Dominio;


namespace Negocio
{
	public class GerenciadorBanco
	{

		private static GerenciadorBanco gBanco;

		public static GerenciadorBanco GetInstace()
		{
			if (gBanco == null)
			{
				gBanco = new GerenciadorBanco();
			}
			return gBanco;
		}

		/// <summary>
		/// Insere dados do banco
		/// </summary>
		/// <param name="banco"></param>
		/// <returns></returns>
		public Int64 Inserir(Banco banco)
		{
			using (var _context = new SaceContext())
			{
				TbBanco _banco = new TbBanco();
				try
				{
					_banco.CodBanco = banco.CodBanco;
					_banco.Nome = banco.Nome;

					_context.Add(_banco);
					_context.SaveChanges();

					return _banco.CodBanco;
				}
				catch (Exception e)
				{
					throw new DadosException("Banco", e.Message, e);
				}
			}

		}

		/// <summary>
		/// Atualiza dados do banco
		/// </summary>
		/// <param name="banco"></param>
		public void atualizar(Banco banco)
		{
			using (var _context = new SaceContext())
			{
				TbBanco _banco = new TbBanco();
				try
				{
					_banco.CodBanco = banco.CodBanco;
					_banco.Nome = banco.Nome;

					_context.Update(_banco);
					_context.SaveChanges();
				}
				catch (Exception e)
				{
					throw new DadosException("Banco", e.Message, e);
				}
			}
		}

		/// <summary>
		/// Remove dados do banco
		/// </summary>
		/// <param name="codBanco"></param>
		public void remover(Int32 codBanco)
		{
			if (codBanco == 1)
				throw new NegocioException("O banco não pode ser removido.");

			using (var _context = new SaceContext())
			{
				TbBanco _banco = new TbBanco();
				try
				{
					_banco.CodBanco = codBanco;
					_context.Remove(_banco);
					_context.SaveChanges();
				}
				catch (Exception e)
				{
					throw new DadosException("Banco", e.Message, e);
				}
			}
		}

		/// <summary>
		/// Obtém todos os banco cadastrados
		/// </summary>
		/// <returns></returns>
		public IEnumerable<Banco> ObterTodos()
		{
			using (var _context = new SaceContext())
			{
				var query = from banco in _context.TbBancos
							select new Banco
							{
								CodBanco = banco.CodBanco,
								Nome = banco.Nome
							};
				return query.ToList();
			}
		}

		/// <summary>
		/// Obtém banco com o código especificiado
		/// </summary>
		/// <param name="codBanco"></param>
		/// <returns></returns>
		public IEnumerable<Banco> Obter(int codBanco)
		{
			using (var _context = new SaceContext())
			{
				try
				{
					var query = from banco in _context.TbBancos
								where banco.CodBanco == codBanco
								select new Banco
								{
									CodBanco = banco.CodBanco,
									Nome = banco.Nome
								};
					return query.ToList();
				}
				catch (Exception e)
				{
					throw new DadosException("Banco", e.Message, e);
				}
			}
		}

		/// <summary>
		/// Obtém bancos que iniciam com o nome
		/// </summary>
		/// <param name="nome"></param>
		/// <returns></returns>
		public IEnumerable<Banco> ObterPorNome(string nome)
		{
			using (var _context = new SaceContext())
			{
				try
				{
					var query = from banco in _context.TbBancos
								where banco.Nome.StartsWith(nome)
								select new Banco
								{
									CodBanco = banco.CodBanco,
									Nome = banco.Nome
								};
					return query.ToList();
				}
				catch (Exception e)
				{
					throw new DadosException("Banco", e.Message, e);
				}
			}
		}
	}
}