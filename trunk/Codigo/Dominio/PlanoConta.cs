using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class PlanoConta
    {
        // usando char o compilador fica gerando erros
        public const String CONTA_PAGAR = "P";
        public const String CONTA_RECEBER = "R";

        private Int64 codPlanoConta;

        public Int64 CodPlanoConta
        {
            get { return codPlanoConta; }
            set { codPlanoConta = value; }
        }

        private Int32 codGrupoConta;

        public Int32 CodGrupoConta
        {
            get { return codGrupoConta; }
            set { codGrupoConta = value; }
        }

        private String descricao;

        public String Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }
        private String tipoConta;

        public String TipoConta
        {
            get { return tipoConta; }
            set { tipoConta = value; }
        }
        private Int16 diaBase;

        public Int16 DiaBase
        {
            get { return diaBase; }
            set { diaBase = value; }
        }

    }
}
