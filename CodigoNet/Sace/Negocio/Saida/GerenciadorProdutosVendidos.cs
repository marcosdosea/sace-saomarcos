using Dados;
using Dominio;

namespace Negocio
{
    public class GerenciadorProdutosVendidos
    {
        private readonly SaceContext context;

        public GerenciadorProdutosVendidos(SaceContext saceContext)
        {
            context = saceContext;
        }


        public List<ProdutoVendido> ObterProdutosVendidosDezoitoMeses(long codProduto)
        {
            
            string nomeProduto = context.TbProdutos.Find(new TbProduto { CodProduto = codProduto }).Nome;

            var query = from saidaProduto in context.TbSaidaProdutos
                        where (saidaProduto.CodSaidaNavigation.CodTipoSaida == Saida.TIPO_VENDA ||
                              saidaProduto.CodSaidaNavigation.CodTipoSaida == Saida.TIPO_PRE_VENDA ||
                              saidaProduto.CodSaidaNavigation.CodTipoSaida == Saida.TIPO_USO_INTERNO) &&
                              saidaProduto.CodSaidaNavigation.DataSaida.Year >= (DateTime.Now.Year - 2)
                        orderby saidaProduto.CodSaidaNavigation.DataSaida.Year descending, saidaProduto.CodSaidaNavigation.DataSaida.Month descending
                        group saidaProduto by
                            new { saidaProduto.CodSaidaNavigation.DataSaida.Year, saidaProduto.CodSaidaNavigation.DataSaida.Month } into gVendidos
                        select new ProdutoVendido
                        {
                            CodProduto = codProduto,
                            Nome = nomeProduto,
                            Ano = gVendidos.Key.Year,
                            Mes = gVendidos.Key.Month,
                            MesAno = String.Concat(gVendidos.Key.Month, "/", gVendidos.Key.Year),
                            QuantidadeVendida = (decimal)gVendidos.Sum(sp => sp.Quantidade)
                        };

            List<ProdutoVendido> listaProdutosVendidos = new List<ProdutoVendido>();

     
            // Insere zero nos meses sem vendas do produto
            DateTime dataAtual = DateTime.Now;
            for (int i = 0; i < 18 && i < listaProdutosVendidos.Count; i++)
            {
                ProdutoVendido produtoVendido = listaProdutosVendidos[i];
                if (produtoVendido.Mes != dataAtual.Month || produtoVendido.Ano != dataAtual.Year)
                {
                    ProdutoVendido _produtoVendido = new ProdutoVendido();
                    _produtoVendido.Ano = dataAtual.Year;
                    _produtoVendido.Mes = dataAtual.Month;
                    _produtoVendido.MesAno = dataAtual.Month + "/" + dataAtual.Year;
                    _produtoVendido.Nome = produtoVendido.Nome;
                    _produtoVendido.QuantidadeVendida = 0;
                    listaProdutosVendidos.Insert(i, _produtoVendido);
                }
                dataAtual = dataAtual.AddMonths(-1);
            }
            return listaProdutosVendidos;
        }

    }
}