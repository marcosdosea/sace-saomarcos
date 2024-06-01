using Util;

namespace Dominio
{
    public class Produto : ProdutoPesquisa
    {
        public long CodGrupo { get; set; }
        public int CodSubgrupo { get; set; }
        public string? NomeFabricante { get; set; }
        
        public decimal PrecoCusto
        {
            get 
            {
                decimal _precoCalculado = CalculaPreco(); 
                if (QuantidadeEmbalagem > 1)
                    return _precoCalculado / QuantidadeEmbalagem;
                return Math.Round(_precoCalculado, 2, MidpointRounding.AwayFromZero);
            }
        }

        public decimal PrecoVendaVarejoSugestao
        {
            get 
            {
                decimal _precoCalculado = CalculaPreco();
                _precoCalculado = _precoCalculado + (_precoCalculado * LucroPrecoVendaVarejo / 100);
                if (QuantidadeEmbalagem > 1)
                    return _precoCalculado / QuantidadeEmbalagem;
                return Math.Round(_precoCalculado, 3, MidpointRounding.AwayFromZero); 
            }
        }
        public decimal PrecoVendaAtacadoSugestao
        {
            get
            {
                decimal _precoCalculado = CalculaPreco();
                _precoCalculado = _precoCalculado + (_precoCalculado * LucroPrecoVendaAtacado / 100);
                if (QuantidadeEmbalagem > 1)
                    return _precoCalculado / QuantidadeEmbalagem;
                return Math.Round(_precoCalculado, 3, MidpointRounding.AwayFromZero);
            }
        }

        public decimal PrecoRevendaSugestao
        {
            get
            {
                decimal _precoCalculado = CalculaPreco();
                _precoCalculado = _precoCalculado + (_precoCalculado * LucroPrecoRevenda / 100);
                if (QuantidadeEmbalagem > 1)
                    return _precoCalculado / QuantidadeEmbalagem;
                return Math.Round(_precoCalculado, 3, MidpointRounding.AwayFromZero);
            }
        }

        public DateTime? DataUltimoPedido { get; set; }
        
        private decimal CalculaPreco()
        {
            decimal _precoCalculado = 0;
            if (EhTributacaoIntegral)
            {
                _precoCalculado = CalculaPrecoCustoNormal(UltimoPrecoCompra, Icms,
                    Simples, Ipi, Frete, 0, Desconto);
            }
            else
            {
                _precoCalculado = CalculaPrecoCustoSubstituicao(UltimoPrecoCompra, IcmsSubstituto,
                    Simples, Ipi, Frete, 0, Desconto);
            }
            return _precoCalculado;
        }
        
        private decimal CalculaPrecoCustoNormal(decimal precoCompra, decimal creditoICMS, decimal simples, decimal ipi, decimal frete, decimal manutencao, decimal desconto)
        {
            decimal precoCalculado = precoCompra + (precoCompra * (UtilConfig.Default.ICMS_LOCAL - creditoICMS) / 100);
            precoCalculado = precoCalculado + (precoCalculado * simples / 100);
            precoCalculado = precoCalculado + (precoCalculado * ipi / 100);
            precoCalculado = precoCalculado + (precoCalculado * frete / 100);
            precoCalculado = precoCalculado + (precoCalculado * manutencao / 100);
            precoCalculado = precoCalculado - (precoCalculado * desconto / 100);
            return precoCalculado;
        }

        private decimal CalculaPrecoCustoSubstituicao(decimal precoCompra, decimal ICMSSubstituicao, decimal simples, decimal ipi, decimal frete, decimal manutencao, decimal desconto)
        {
            decimal precoCalculado = precoCompra + (precoCompra * ICMSSubstituicao / 100);
            precoCalculado = precoCalculado + (precoCalculado * simples / 100);
            precoCalculado = precoCalculado + (precoCalculado * ipi / 100);
            precoCalculado = precoCalculado + (precoCalculado * frete / 100);
            precoCalculado = precoCalculado + (precoCalculado * manutencao / 100);
            precoCalculado = precoCalculado - (precoCalculado * desconto / 100);
            return precoCalculado;
        }


    }
}