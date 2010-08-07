using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio
{
    public class GerenciadorPrecos : Negocio.IGerenciadorPrecos
    {
        static GerenciadorPrecos gerenciadorPrecos = null;
        
        private GerenciadorPrecos()
        {
        }

        public static GerenciadorPrecos getInstance()
        {
            if (gerenciadorPrecos == null)
                gerenciadorPrecos = new GerenciadorPrecos();
            return gerenciadorPrecos;
        }

        public decimal calculaPrecoCustoNormal(decimal precoCompra, decimal diferencialICMS, decimal simples, decimal ipi, decimal frete, decimal manutencao)
        {
            return precoCompra + (precoCompra *  (1 / ((100-diferencialICMS) / 100)) ) + (precoCompra  * (1 / ((100-simples) / 100)) ) +
                (precoCompra * ipi / 100) + (precoCompra * frete / 100) + (precoCompra * manutencao / 100);
        }

        public decimal calculaPrecoCustoSubstituicao(decimal precoCompra, decimal ICMSSubstituicao, decimal simples, decimal ipi, decimal frete, decimal manutencao)
        {
            return precoCompra + (precoCompra * (1 / ((100 - ICMSSubstituicao) / 100))) + (precoCompra * (1 / ((100 - simples) / 100))) +
                (precoCompra * ipi / 100) + (precoCompra * frete / 100) + (precoCompra * manutencao / 100);
        }

        public decimal calculaPrecoVenda(decimal precoCusto, decimal lucro)
        {
            return precoCusto + (precoCusto * lucro / 100);
        }
    }
}
