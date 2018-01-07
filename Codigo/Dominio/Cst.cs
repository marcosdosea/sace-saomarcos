using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Cst
    {
        public const string ST_TRIBUTADO_INTEGRAL = "00";
        public const string ST_SUBSTITUICAO = "10";
        public const string ST_SUBSTITUICAO_ISENTA_NAO_TRIBUTADA = "30";
        public const string ST_SUBSTITUICAO_ICMS_COBRADO = "60";
        public const string ST_SUBSTITUICAO_ICMS_REDUCAO_BC = "70";
        public const string ST_OUTRAS = "90";
        public const string ST_NAO_TRIBUTADA = "41";

        public const string ST_SIMPLES_TRIBUTADA_PERM_CREDITO = "101";
        public const string ST_SIMPLES_TRIBUTADA_SEM_PERM_CREDITO = "102";
        public const string ST_SIMPLES_OUTRAS = "900";

        public const string ST_SIMPLES_SUBSTITUICAO_COM_PERM_CREDITO = "201";
        public const string ST_SIMPLES_SUBSTITUICAO_SEM_PERM_CREDITO = "202";
        public const string ST_SIMPLES_SUBSTITUICAO_ICMS_COBRADO = "500";
        public const string ST_SIMPLES_NAO_TRIBUTADA = "400";
        
        
        public string CodCST { get; set; }
        public string Descricao { get; set; }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return this.CodCST.Equals(((Cst)obj).CodCST);    
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return this.CodCST.GetHashCode();
        }

        public bool EhTributacaoSimples
        {
            get
            {
                if ((CodCST != null) && (CodCST.Trim().Length == 3))
                {
                    return (CodCST.Equals(ST_SIMPLES_SUBSTITUICAO_ICMS_COBRADO) ||
                        CodCST.Equals(ST_SIMPLES_SUBSTITUICAO_SEM_PERM_CREDITO) ||
                        CodCST.Equals(ST_SIMPLES_SUBSTITUICAO_COM_PERM_CREDITO) ||
                        CodCST.Equals(ST_SIMPLES_NAO_TRIBUTADA));
                }
                return false;
            }
        }
        
        
        public bool EhTributacaoIntegral
        {
            get
            {
                // acontece para os CST da tabela antiga de tributacao
                if ((CodCST != null) && (CodCST.Trim().Length == 3))
                {
                    CodCST = CodCST.Substring(1, 2);
                }

                if ((CodCST != null) && (CodCST.Trim().Length == 2))
                {
                    return !(CodCST.Equals(ST_SUBSTITUICAO) ||
                        CodCST.Equals(ST_SUBSTITUICAO_ICMS_COBRADO) ||
                        CodCST.Equals(ST_SUBSTITUICAO_ICMS_REDUCAO_BC) ||
                        CodCST.Equals(ST_SUBSTITUICAO_ISENTA_NAO_TRIBUTADA) ||
                        CodCST.Equals(ST_NAO_TRIBUTADA));
                }
                
                if ((CodCST != null) && (CodCST.Trim().Length == 4))
                {
                    CodCST = CodCST.Substring(1, 3);
                }
                if ((CodCST != null) && (CodCST.Trim().Length == 3))
                {
                    return !(CodCST.Equals(ST_SIMPLES_SUBSTITUICAO_ICMS_COBRADO) ||
                        CodCST.Equals(ST_SIMPLES_SUBSTITUICAO_SEM_PERM_CREDITO) ||
                        CodCST.Equals(ST_SIMPLES_SUBSTITUICAO_COM_PERM_CREDITO) ||
                        CodCST.Equals(ST_SIMPLES_NAO_TRIBUTADA));
                }

                return false;
            }
        }

    }
}
