using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Util
{
    public class MP2032
    {
        /*
		 ===============================================================================
			********************************************************************************

								DECLARAÇÃO DAS FUNÇÕES DA MP2032.DLL
  
			********************************************************************************
		 ===============================================================================
		*/
        #region Funções Gerais
                
                /// <summary>
                /// Aciona a guilhotina, cortando o papel em modo parcial ou total.
                /// </summary>
                /// <param name="parcial_full">INTEIRA 0 = acionamento parcial, 1 = acionamento total.</param>
                /// <returns>INTEIRO - Indica se a função conseguiu enviar o comando para impressora.</returns>
                [DllImport("MP2032.dll")]public static extern int AcionaGuilhotina(int parcial_full);
                
                /// <summary>
                /// Seleciona  largura da bitola do papel da impressora.
                /// </summary>
                /// <param name="iWidth">INTEIRO bitola do papel em milímetros. Podendo ser: 48, 58, 76, 80 ou 112.</param>
                /// <returns>INTEIRO - Indica se a função conseguiu enviar o comando para impressora.</returns>
                [DllImport("MP2032.dll")]public static extern int AjustaLarguraPapel(int iWidth);


                /// <summary>
                /// Autentica DOC. Informar o texto que desejaregistrar e o tempo de espera, definido em milissegundos.
                /// </summary>
                /// <param name="texto">STRING Texto a ser impresso</param>
                /// <param name="tempo">INTEIRO Tempo de espera para a impressão. Ex: 5000 = 5 segundos de espera para a inserção do documento.</param>
                /// <returns>INTEIRO - Indica se a função conseguiu enviar o comando para impressora.</returns>
                [DllImport("MP2032.dll")]public static extern int AutenticaDoc(String texto, int tempo);

                /// <summary>
                /// Impressão de textos, enviando um conjunto com várias linhas.
                /// </summary>
                /// <param name="texto">STRING Texto a ser impresso</param>
                /// <returns>INTEIRO - Indica se a função conseguiu enviar o comando para impressora.</returns>
                [DllImport("MP2032.dll")]public static extern int BematechTX(String texto);

                /// <summary>
                /// Envio de comandos para a impressora, como por exemplo: comandos de Autenticação, comando para Acionamento de Gaveta, etc.
                /// </summary>
                /// <param name="comando">STRING comando que deseja executar</param>
                /// <param name="tComando">INTEIRO tamanho do comando que será enviado</param>
                /// <returns>INTEIRO - Indica se a função conseguiu enviar o comando para impressora.</returns>
                [DllImport("MP2032.dll")]public static extern int ComandoTX(String comando, int tComando);

                /// <summary>
                /// Configurar o modelo da impressora não fiscal em uso. IMPORTANTE: Esta função deve ser usada antes da função IniciaPorta
                /// </summary>
                /// <param name="model">INTEIRO 0 = MP-20 TH, MP-2000 CI ou MP-2000 TH, 1 = MP-20 MI, MP-20 CI ou MP-20 S, 2 = Blocos térmicos (com comunicacao serial DTR/DSR), 3 = Bloco 112 mm, 4 = ThermalKiosk, 5 = MP-4000 TH, 7 = MP-4200 TH, 8 = MP-2500 TH 0 = Default</param>
                /// <returns>INTEIRO - Indica se a função conseguiu enviar o comando para impressora.</returns>
                [DllImport("MP2032.dll")]public static extern int ConfiguraModeloImpressora(int model);

                /// <summary>
                /// Configura a quantidade de linhas impressas no extrato, antes de começar a espulsá-lo (eject). A quantidade de linhas pode variar de 1 a 150 linhas. O Default é 90 linhas. OBS: SOMENTE UTILIZADA PARA OS BLOCOS IMPRESSORES
                /// </summary>
                /// <param name="tamanho">INTEIRO tamanho do extrato</param>
                /// <returns>INTEIRO - Indica se a função conseguiu enviar o comando para impressora.</returns>
                [DllImport("MP2032.dll")]public static extern int ConfiguraTamanhoExtrato(int tamanho);

                /// <summary>
                /// Configura o taxa de transmissão para a porta serial.
                /// </summary>
                /// <param name="taxa">INTEIRO taxa em bps (bits por segundo). Esta taxa pode ser 9600 ou 115200.</param>
                /// <returns>INTEIRO - Indica se a função conseguiu enviar o comando para impressora.</returns>
                [DllImport("MP2032.dll")]public static extern int ConfiguraTaxaSerial(int taxa);

                /// <summary>
                /// Objetivo de verificar a presença de documento antes da autenticação.
                /// </summary>
                /// <returns>INTEIRO - Indica se a função conseguiu enviar o comando para impressora.</returns>
                [DllImport("MP2032.dll")]public static extern int DocumentInserted();

                /// <summary>
                /// Esta função segura a execução do Aplicativo, até que todo o texto enviado seja impresso.
                /// </summary>
                /// <param name="modo">INTEIRO modo de espera.</param>
                /// <returns>INTEIRO - Indica se a função conseguiu enviar o comando para impressora.</returns>
                [DllImport("MP2032.dll")]public static extern int EsperaImpressao(int modo);

                /// <summary>
                /// Esta função tem por objetivo fechar a porta de comunicação, liberando a porta para outras atividades.
                /// </summary>
                /// <returns>INTEIRO - Indica se a função conseguiu enviar o comando para impressora.</returns>
                [DllImport("MP2032.dll")]public static extern int FechaPorta();

                /// <summary>
                /// Esta função tem por objetivo enviar textos para a impressora, com formatações, informadas pelos parâmetros.
                /// </summary>
                /// <param name="texto">STRING texto a ser impresso.</param>
                /// <param name="TipoLetra">INTEIRO sendo 1 = comprimido, 2 = normal, 3 = elite</param>
                /// <param name="italico">INTEIRO  0 = desativa modo, 1 = ativa modo.</param>
                /// <param name="sublinhado">INTEIRO 0 = desativa modo, 1 = ativa modo.</param>
                /// <param name="expandido">INTEIRO 0 = desativa modo, 1 = ativa modo.</param>
                /// <param name="enfatizado">INTEIRO 0 = desativa modo, 1 = ativa modo.</param>
                /// <returns>INTEIRO - Indica se a função conseguiu enviar o comando para impressora.</returns>
                [DllImport("MP2032.dll")]public static extern int FormataTX(String texto, int TipoLetra, int italico, int sublinhado, int expandido, int enfatizado);

                /// <summary>
                /// Esta função habilita ou desabilita o envio do caracter ETX (03h), que mantém a impressora ocupada até o término da impressão de todo o texto (string).
                /// </summary>
                /// <param name="espera">INTEIRO 0 = desabilitado, 1 = habilitado</param>
                /// <returns>INTEIRO - Indica se a função conseguiu enviar o comando para impressora.</returns>
                [DllImport("MP2032.dll")]public static extern int HabilitaEsperaImpressao(int espera);

                /// <summary>
                /// Esta função habilita ou desabilita a quantidade de linhas, configurada na função ConfiguraTamanhoExtrato. Caso esta função não for executada, a quantidade de linhas não será a Default (90 linhas), será a quantidade que for enviada. OBS: SOMENTE UTILIZADA PARA BLOCOS IMPRESSORES
                /// </summary>
                /// <param name="Exlongo">INTEIRO 0 = desabilitado, 1 = habilitado</param>
                /// <returns>INTEIRO - Indica se a função conseguiu enviar o comando para impressora.</returns>
                [DllImport("MP2032.dll")]public static extern int HabilitaExtratoLongo(int ExLongo);

                /// <summary>
                /// Habilita ou Desabilita a função retrátil do Presenter.
                /// </summary>
                /// <param name="iFlag">INTEIRO 0 = desabilitado, 1 = habilitado</param>
                /// <returns>INTEIRO - Indica se a função conseguiu enviar o comando para impressora.</returns>
                [DllImport("MP2032.dll")]public static extern int HabilitaPresenterRetratil(int iFlag);

                /// <summary>
                /// Esta função tem por objetivo abrir a porta de comunicação, onde a impressora está conectada
                /// </summary>
                /// <param name="porta">STRING nome da porta de comunicação</param>
                /// <returns>INTEIRO - Indica se a função conseguiu enviar o comando para impressora.</returns>
                [DllImport("MP2032.dll")]public static extern int IniciaPorta(String porta);

                /// <summary>
                ///Esta função tem por objetivo retornar o estado da impressora.
                /// </summary>
                /// <returns>INTEIRO - Indica se a função conseguiu enviar o comando para impressora.</returns>
                [DllImport("MP2032.dll")]public static extern int Le_Status();

                /// <summary>
                /// Esta função retorna o estado da gaveta de dinheiro.
                /// </summary>
                /// <returns>INTEIRO - Indica se a função conseguiu enviar o comando para impressora.</returns>
                [DllImport("MP2032.dll")]public static extern int Le_Status_gaveta();

                /// <summary>
                /// Reset da impressora
                /// </summary>
                /// <returns>INTEIRO - Indica se a função conseguiu enviar o comando para impressora.</returns>
                [DllImport("MP2032.dll")]public static extern int PrinterReset();

                /// <summary>
                /// Programa o tempo de espera para retração do papel, caso o mesmo não seja retirado do bocal do Presenter.
                /// </summary>
                /// <param name="iTempo">INTEIRO tempo de espera</param>
                /// <returns>INTEIRO - Indica se a função conseguiu enviar o comando para impressora.</returns>
                [DllImport("MP2032.dll")]public static extern int ProgramaPresenterRetratil(int iTempo);

                /// <summary>
                /// Seleciona a qualidade de impressão, somente disponível para as impressora não fiscais térmicas e para os blocos térmicos.
                /// </summary>
                /// <param name="TipoQualidade">INTEIRO onde: 0 = baixa, 1 = Média, 2 = Normal, 3 = Alta, 4 = Altíssima</param>
                /// <returns>INTEIRO - Indica se a função conseguiu enviar o comando para impressora.</returns>
                [DllImport("MP2032.dll")]public static extern int SelecionaQualidadeImpressao(int TipoQualidade);

                /// <summary>
                /// Atualiza o firmware do dispositivo.
                /// </summary>
                /// <param name="Local">STRING com nome do arquivo e o local contendo o binário do novo firmware.</param>
                /// <returns>INTEIRO - Indica se a função conseguiu enviar o comando para impressora.</returns>
                [DllImport("MP2032.dll")]public static extern int AtualizaFirmware(string Local);

                /// <summary>
                /// Verifica se há papel posicionado no Presenter.
                /// </summary>
                /// <returns>INTEIRO - Indica se a função conseguiu enviar o comando para impressora.</returns>
                [DllImport("MP2032.dll")]public static extern int VerificaPapelPresenter();

        #endregion

        #region Código de Barras

                /// <summary>
                /// Esta função configura os códigos de barras, definindo Altura, Largura e Posição dos caracteres.
                /// </summary>
                /// <param name="Altura">INTEIRO Altura de 1 à 255. Default: 162</param>
                /// <param name="Largura">INTEIRO Largura 0 = barras finas, 1 = barras médias, 2 = barras grossas</param>
                /// <param name="Posicao">INTEIRO Posição 0 = não imprime os caracteres do código, 1 = caracter acima do código, 2 = caracter abaixo do código,  3 = caracter acima e abaixo do código</param>
                /// <param name="Fonte">INTEIRO Fonte 0 = normal, 1 = condensado</param>
                /// <param name="Margem">INTEIRO Margem </param>
                /// <returns>INTEIRO - Indica se a função conseguiu enviar o comando para impressora.</returns>
                [DllImport("MP2032.dll")]public static extern int ConfiguraCodigoBarras(int Altura, int Largura, int Posicao, int Fonte, int Margem);

                /// <summary>
                /// Esta função faz a impressão do código de barras CODABAR.
                /// </summary>
                /// <param name="texto">STRING texto do código que será gerado</param>
                /// <returns>INTEIRO - Indica se a função conseguiu enviar o comando para impressora.</returns>
                [DllImport("MP2032.dll")]public static extern int ImprimeCodigoBarrasCODABAR(String texto);

                /// <summary>
                /// Esta função faz a impressão do código de barras CODE128.
                /// </summary>
                /// <param name="texto">STRING texto do código que será gerado</param>
                /// <returns>INTEIRO - Indica se a função conseguiu enviar o comando para impressora.</returns>
                [DllImport("MP2032.dll")]public static extern int ImprimeCodigoBarrasCODE128(String texto);

                /// <summary>
                /// Esta função faz a impressão do código de barras CODE39.
                /// </summary>
                /// <param name="texto">STRING texto do código que será gerado</param>
                /// <returns>INTEIRO - Indica se a função conseguiu enviar o comando para impressora.</returns>
                [DllImport("MP2032.dll")]public static extern int ImprimeCodigoBarrasCODE39(String texto);

                /// <summary>
                /// Esta função faz a impressão do código de barras CODE93.
                /// </summary>
                /// <param name="texto">STRING texto do código que será gerado</param>
                /// <returns>INTEIRO - Indica se a função conseguiu enviar o comando para impressora.</returns>
                [DllImport("MP2032.dll")]public static extern int ImprimeCodigoBarrasCODE93(String texto);

                /// <summary>
                /// Esta função faz a impressão do código de barras EAN13.
                /// </summary>
                /// <param name="texto">STRING texto do código que será gerado</param>
                /// <returns>INTEIRO - Indica se a função conseguiu enviar o comando para impressora.</returns>
                [DllImport("MP2032.dll")]public static extern int ImprimeCodigoBarrasEAN13(String texto);

                /// <summary>
                /// Esta função faz a impressão do código de barras EAN8.
                /// </summary>
                /// <param name="texto">STRING texto do código que será gerado</param>
                /// <returns>INTEIRO - Indica se a função conseguiu enviar o comando para impressora.</returns>
                [DllImport("MP2032.dll")]public static extern int ImprimeCodigoBarrasEAN8(String texto);

                /// <summary>
                /// Esta função faz a impressão do código de barras ISBN.
                /// </summary>
                /// <param name="texto">STRING texto do código que será gerado</param>
                /// <returns>INTEIRO - Indica se a função conseguiu enviar o comando para impressora.</returns>
                [DllImport("MP2032.dll")]public static extern int ImprimeCodigoBarrasISBN(String texto);

                /// <summary>
                /// Esta função faz a impressão do código de barras ITF.
                /// </summary>
                /// <param name="texto">STRING texto do código que será gerado</param>
                /// <returns>INTEIRO - Indica se a função conseguiu enviar o comando para impressora.</returns>
                [DllImport("MP2032.dll")]public static extern int ImprimeCodigoBarrasITF(String texto);

                /// <summary>
                /// Esta função faz a impressão do código de barras MSI.
                /// </summary>
                /// <param name="texto">STRING texto do código que será gerado</param>
                /// <returns>INTEIRO - Indica se a função conseguiu enviar o comando para impressora.</returns>
                [DllImport("MP2032.dll")]public static extern int ImprimeCodigoBarrasMSI(String texto);

                /// <summary>
                /// Esta função faz a impressão do código de barras PDF417.
                /// </summary>
                /// <param name="nCorrecaoErros"> INTEIRO Nível de Correção de Erros - Inteiro entre 0 à 8.
                /// <param name="altura">INTEIRO  entre 1 à 8. Altura do caracter do código (pitch). 1 pitch = altura de 0,125 mm.
                /// <param name="largura">INTEIRO entre 1 à 4. Largura do caracter do código (pitch). 1 pitch = altura de 0,125 mm.
                /// <param name="nColunasImpressas">INTEIRO entre 0 à 30. "0" (zero) utiliza o máximo de colunas. Caso não caiba na linha a impressora ajusta, automaticamente, para o máximo de colunas permitido na linha.
                /// <param name="texto">STRING texto do código que será gerado</param>
                /// <returns>INTEIRO - Indica se a função conseguiu enviar o comando para impressora.</returns>
                [DllImport("MP2032.dll")]public static extern int ImprimeCodigoBarrasPDF417(int nCorrecaoErros, int altura, int Largura, int nColunasImpressas, String texto);

                /// <summary>
                /// Esta função faz a impressão do código de barras PLESSEY.
                /// </summary>
                /// <param name="texto">STRING texto do código que será gerado</param>
                /// <returns>INTEIRO - Indica se a função conseguiu enviar o comando para impressora.</returns>
                [DllImport("MP2032.dll")]public static extern int ImprimeCodigoBarrasPLESSEY(String texto);

                /// <summary>
                /// Esta função faz a impressão do código de barras UPCA.
                /// </summary>
                /// <param name="texto">STRING texto do código que será gerado</param>
                /// <returns>INTEIRO - Indica se a função conseguiu enviar o comando para impressora.</returns>
                [DllImport("MP2032.dll")]public static extern int ImprimeCodigoBarrasUPCA(String texto);

                /// <summary>
                /// Esta função faz a impressão do código de barras UPCE.
                /// </summary>
                /// <param name="texto">STRING texto do código que será gerado</param>
                /// <returns>INTEIRO - Indica se a função conseguiu enviar o comando para impressora.</returns>
                [DllImport("MP2032.dll")]public static extern int ImprimeCodigoBarrasUPCE(String texto);

        #endregion
        
        #region Bitmap
                /// <summary>
                /// Seleciona qual algoritmo de dithering (halftoning), a ser utilizado na impressão do bitmap.
                /// </summary>
                /// <param name="iType">INTEIRO indicando o algoritmo. Podendo ser: 0 (Bayer) ou 1 (Floyd-Steinberg).</param>
                /// <returns>INTEIRO - Indica se a função conseguiu enviar o comando para impressora.</returns>
                [DllImport("MP2032.dll")]
                public static extern int SelectDithering(int iType);

                /// <summary>
                /// Imprime uma imagem bitmap na impressora não fiscal.
                /// </summary>
                /// <param name="sFileName">STRING com o caminho completo do arquivo contendo o bitmap</param>
                /// <param name="iMode">INTEIRO 0 = indicando orientação RETRATO, 1 = indicando orientação PAISAGEM</param>
                /// <returns>INTEIRO - Indica se a função conseguiu enviar o comando para impressora.</returns>
                [DllImport("MP2032.dll")]
                public static extern int ImprimeBitmap(string sFileName, int iMode);

                /// <summary>
                /// Imprime uma imagem bitmap na impressora não fiscal com atributos especiais de impressão.
                /// </summary>
                /// <param name="sFileName">STRING com o caminho completo do arquivo contendo o bitmap</param>
                /// <param name="xScale">INTEIRO indicando o escalonamento da imagem na horizontal em porcentagem. Ex: 100 (%) indica largura atual; 200 (%) indica largura 2 vezes maior; -1 (menos um) indica ajuste da largura na página.</param>
                /// <param name="yScale">INTEIRO indicando o escalonamento da imagem na vertical em porcentagem. Ex: 100 (%) indica altura atual; 50 (%) indica metade da altura. Ignorado se parâmetro xScale seja &endash;1 (menos um).</param>
                /// <param name="iAngle">INTEIRO usada para girar o bitmap na impressão. Ex: 0 (°) indica sem rotacionamento da imagem; 45 (°) indica rotacionar a imagem em 45 graus</param>
                /// <returns>INTEIRO - Indica se a função conseguiu enviar o comando para impressora.</returns>
                [DllImport("MP2032.dll")]
                public static extern int ImprimeBmpEspecial(String sFileName, int xScale, int yScale, int iAngle);

                /// <summary>
                /// Armazena na memória não volátil da impressora até 7 imagens diferentes.
                /// </summary>
                /// <param name="iQtde">INTEIRO número de imagens a serem gravadas</param>
                /// <param name="cImagem">STRING com caminho+nome do arquivo, de acordo com a quantidade definida</param>
                /// <returns>INTEIRO - Indica se a função conseguiu enviar o comando para impressora.</returns>
                [DllImport("MP2032.dll")]
                public static extern int DefineNVBitmap(int iQtde, string cImagem);

                /// <summary>
                /// Imprime a imagem da memória não volátil da impressora.
                /// </summary>
                /// <param name="iIndice">INTEIRO índice da imagem que se deseja imprimir</param>
                /// <param name="iModo">INTEIRO modo de impressão da imagem, onde: 0 = normal, 1 = altura dupla, 2 = largura dupla, 3 = ambos</param>
                /// <returns>INTEIRO - Indica se a função conseguiu enviar o comando para impressora.</returns>
                [DllImport("MP2032.dll")]
                public static extern int PrintNVBitmap(int iIndice, string iModo);

                /// <summary>
                /// Armazena na memória não volátil da impressora apenas 1 (uma) imagem.
                /// </summary>
                /// <param name="cImagem">STRING caminho+nome do arquivo bitmap</param>
                /// <returns>INTEIRO - Indica se a função conseguiu enviar o comando para impressora.</returns>
                [DllImport("MP2032.dll")]
                public static extern int Define1NVBitmap(string cImagem);

                /// <summary>
                /// Armazena na memória volátil da impressora apenas 1 (uma) imagem.
                /// </summary>
                /// <param name="cImagem">STRING caminho+nome do arquivo bitmap</param>
                /// <returns>INTEIRO - Indica se a função conseguiu enviar o comando para impressora.</returns>
                [DllImport("MP2032.dll")]
                public static extern int DefineDLBitmap(string cImagem);

                /// <summary>
                /// Imprime a imagem da memória volátil da impressora.
                /// </summary>
                /// <param name="iModo">INTEIRO com o modo de impressão da imagem, onde: 0 = normal, 1 = altura dupla, 2 = largura dupla, 3 = ambos</param>
                /// <returns>INTEIRO - Indica se a função conseguiu enviar o comando para impressora.</returns>
                [DllImport("MP2032.dll")]
                public static extern int PrintDLBitmap(int iModo);

        #endregion
    }
}
