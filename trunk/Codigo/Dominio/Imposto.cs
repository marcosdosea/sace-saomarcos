// -----------------------------------------------------------------------
// <copyright file="Imposto.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Dominio
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Imposto
    {
        public long Ncmsh { get; set; }
        public decimal AliqNac { get; set; }
        public decimal AliqImp { get; set; }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return this.Ncmsh.GetHashCode();
        }

    }
}
