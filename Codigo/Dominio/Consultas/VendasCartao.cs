// -----------------------------------------------------------------------
// <copyright file="TotaisCartao.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Dominio.Consultas
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class VendasCartao
    {
        public int CodCartao { get; set; }
        public long CodSaida { get; set; }
        public string DescricaoCartao { get; set; }
        public int Parcelas { get; set; }
        public decimal TotalCartao { get; set; }
        public string NumeroControle { get; set; }
    }
}
