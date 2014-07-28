﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Cfop
    {
        public const int DEVOLUCAO_NORMAL_ESTADO = 5202;
        public const int DEVOUCAO_ST_ESTADO = 5411;

        public const int DEVOLUCAO_NORMAL_FORA_ESTADO = 6202;
        public const int DEVOUCAO_ST_FORA_ESTADO = 6411;

        
        public int CodCfop { get; set; }
        public string Descricao { get; set; }
        public decimal Icms { get; set; }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return this.CodCfop.Equals(((Cfop)obj).CodCfop);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return this.CodCfop.GetHashCode();
        }
    }
}