using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing.Printing;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace Negocio
{
    internal class GerenciadorImprimir
    {

        private static GerenciadorImprimir gImprimir;
        PrintDialog printDialog;
        PrintDocument printDocument;
        StringReader leitor;
        
        private GerenciadorImprimir()
        {
            printDialog = new PrintDialog();
            printDocument = new PrintDocument();
        }

        public static GerenciadorImprimir GetInstance()
        {
            if (gImprimir == null) 
                gImprimir = new GerenciadorImprimir();
            return gImprimir;
        }
        
        public void Imprimir(String texto)
        {
            printDialog.Document = printDocument;
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PrintDocumentPrintPage);
            leitor = new StringReader(texto);

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                //int numero = printDialog.PrinterSettings.DefaultPageSettings.PaperSize.RawKind;
                this.printDocument.Print();
            }
        }

        void PrintDocumentPrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //variaveis usadas para definir as configurações da impressão
            float linhasPorPagina = 0;
            float yPosicao = 0;
            int contador = 0;
            float margemEsquerda = e.MarginBounds.Left;
            float margemSuperior = e.MarginBounds.Top;
            string linha = null;
            Font fonteImpressao = new Font(FontFamily.GenericMonospace, 10.0F);
            SolidBrush mCaneta = new SolidBrush(Color.Black);

            // Define o numero de linhas por pagina, usando MarginBounds.
            linhasPorPagina = e.MarginBounds.Height / fonteImpressao.GetHeight(e.Graphics);

            // Itera sobre a string usando StringReader, imprimindo cada linha
            while (contador < linhasPorPagina && ((linha = leitor.ReadLine()) != null))
            {
                // calcula a posicao da proxima linha baseada
                // na altura da fonte de acordo com o dispositivo de impressão
                yPosicao = margemSuperior + (contador * fonteImpressao.GetHeight(e.Graphics));

                // desenha a proxima linha no controle RichTextBox
                e.Graphics.DrawString(linha, fonteImpressao, mCaneta, margemEsquerda, yPosicao, new StringFormat());
                contador++;
            }
            // Verifica se existe mais linhas para imprimir
            if ((linha != null) || (contador >= linhasPorPagina))
                e.HasMorePages = true;
            else
                e.HasMorePages = false;

            //libera recursos		
            mCaneta.Dispose();
        }

    }
}
