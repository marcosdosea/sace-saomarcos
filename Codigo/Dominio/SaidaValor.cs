using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class SaidaPedido
    {
        public long CodSaida { get; set; }
        // Utilizado para controlar o número do pedido que será enviado como arquivo texto.
        public long CodPedido { get; set; }
        public decimal TotalAVista { get; set; }
    }
}
