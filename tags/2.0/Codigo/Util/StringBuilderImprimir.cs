using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Util
{
    public class StringBuilderImprimir
    {
        StringBuilder texto;
        int tamanhoLinha;

        public StringBuilderImprimir()
        {
            texto = new StringBuilder();
            tamanhoLinha = 0;
        }

        public StringBuilder Append(string linha)
        {
            tamanhoLinha += linha.Length;
            return texto.Append(linha);
        }

        public StringBuilder AppendLine(string linha) {
            tamanhoLinha = 0;
            return texto.AppendLine(linha);
        }

        public StringBuilder AppendLineCenter(int numeroColunas, string linha)
        {
            int inicioCentro = Convert.ToInt32((numeroColunas - linha.Length) / 2);
            texto.Append(' ', inicioCentro);
            texto.AppendLine(linha);
            
            tamanhoLinha = 0;
            return texto;
        }
        
        public StringBuilder AppendEsquerda(int colunaInicial, string linha)
        {
            texto.Append(' ', colunaInicial-tamanhoLinha);
            texto.Append(linha);
            tamanhoLinha += linha.Length + (colunaInicial - tamanhoLinha);
            return texto;
        }

        public StringBuilder AppendLineEsquerda(int colunaInicial, string linha)
        {
            AppendEsquerda(colunaInicial, linha);
            texto.AppendLine("");
            tamanhoLinha += 0;
            return texto;
        }

        public StringBuilder AppendDireita(int colunaInicial, int colunaFinal, string linha)
        {
            texto.Append(' ', colunaFinal + 1 - colunaInicial - linha.Length + (colunaInicial-tamanhoLinha));
            texto.Append(linha);
            tamanhoLinha += linha.Length + (colunaFinal + 1 - colunaInicial - linha.Length + (colunaInicial - tamanhoLinha));
            return texto;
        }

        public StringBuilder AppendLineDireita(int colunaInicial, int colunaFinal, string linha)
        {
            AppendDireita(colunaInicial, colunaFinal, linha);
            texto.AppendLine("");
            tamanhoLinha += 0;
            return texto;
        }
        
        public string ToString()
        {
            return texto.ToString();
        }
    }
}
