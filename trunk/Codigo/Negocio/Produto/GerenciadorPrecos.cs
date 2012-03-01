using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Util;

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

        public decimal calculaPrecoCustoNormal(decimal precoCompra, decimal creditoICMS, decimal simples, decimal ipi, decimal frete, decimal manutencao)
        {
            // return precoCompra + (precoCompra * (1 / (100 - (Global.ICMS_LOCAL - creditoICMS))) * 10) + (precoCompra * (1 / (100 - simples)) * 10) +
            //    (precoCompra * ipi / 100) + (precoCompra * frete / 100) + (precoCompra * manutencao / 100);
            
            decimal precoCalculado = precoCompra + (precoCompra * (Global.ICMS_LOCAL - creditoICMS) / 100);
            precoCalculado = precoCalculado + (precoCalculado * simples / 100);
            precoCalculado = precoCalculado + (precoCalculado * ipi / 100);
            precoCalculado = precoCalculado + (precoCalculado * frete / 100);
            precoCalculado = precoCalculado + (precoCalculado * manutencao / 100);
            
            return precoCalculado;
        }

        public decimal calculaPrecoCustoSubstituicao(decimal precoCompra, decimal ICMSSubstituicao, decimal simples, decimal ipi, decimal frete, decimal manutencao)
        {
            // return precoCompra + (precoCompra * (1 / (100 - ICMSSubstituicao)) *10) + (precoCompra * (1 / (100 - simples))*10) +
            //    (precoCompra * ipi / 100) + (precoCompra * frete / 100) + (precoCompra * manutencao / 100);
            
            decimal precoCalculado = precoCompra + (precoCompra * ICMSSubstituicao / 100);
            precoCalculado = precoCalculado + (precoCalculado * simples / 100);
            precoCalculado = precoCalculado + (precoCalculado * ipi / 100);
            precoCalculado = precoCalculado + (precoCalculado * frete / 100);
            precoCalculado = precoCalculado + (precoCalculado * manutencao / 100);

            return precoCalculado;
        }

        public decimal calculaPrecoVenda(decimal precoCusto, decimal lucro)
        {
            return precoCusto + (precoCusto * lucro / 100);
        }
    }
}
