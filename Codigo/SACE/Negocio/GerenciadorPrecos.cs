using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SACE.Negocio
{
    class GerenciadorPrecos
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

        public static decimal calculaPrecoCustoNormal(decimal precoCompra, decimal diferencialICMS, decimal simples, decimal ipi, decimal frete)
        {
            return precoCompra + (precoCompra * diferencialICMS / 100) + (precoCompra * simples / 100) +
                (precoCompra * ipi / 100) + (precoCompra * frete / 100);
        }

        public static decimal calculaPrecoCustoSubstituicao(decimal precoCompra, decimal ICMSSubstituicao, decimal simples, decimal ipi, decimal frete)
        {
            return precoCompra + (precoCompra * ICMSSubstituicao / 100) + (precoCompra * simples / 100) +
                (precoCompra * ipi / 100) + (precoCompra * frete / 100);
        }

        public static decimal calculaPrecoVenda(decimal precoCusto, decimal lucro)
        {
            return precoCusto + (precoCusto * lucro / 100);
        }


    }
}
