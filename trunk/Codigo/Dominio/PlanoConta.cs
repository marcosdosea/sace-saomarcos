using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class PlanoConta
    {
        public const int ENTRADA_PRODUTOS = 1;
        public const int SAIDA_PRODUTOS = 2;
        

        private long codPlanoConta;

        public long CodPlanoConta
        {
            get { return codPlanoConta; }
            set { codPlanoConta = value; }
        }

        private int codGrupoConta;

        public int CodGrupoConta
        {
            get { return codGrupoConta; }
            set { codGrupoConta = value; }
        }

        private string descricao;

        public string Descricao
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