using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class NfeStatusResposta
    {
        public const string NFE100_AUTORIZADO_USO_NFE = "100";
        public const string NFE101_CANCELAMENTO_NFE_HOMOLOGADO = "101";
        public const string NFE102_INUTILIZACAO_NUMERO_HOMOLOGADO = "102";
        public const string NFE103_LOTE_RECEBIDO_SUCESSO = "103";
        public const string NFE104_LOTE_PROCESSADO = "104";
        public const string NFE105_LOTE_EM_PROCESSAMENTO = "105";
        public const string NFE106_LOTE_NAO_LOCALIZADO = "106";
        public const string NFE107_SERVICO_EM_OPERACAO = "107";
        public const string NFE108_SERVICO_PARADO_CURTO_PRAZO = "108";
        public const string NFE109_SERVICO_PARADO_SEM_PREVISAO = "109";
        public const string NFE110_USO_DENEGADO = "110";
        public const string NFE128_LOTE_EVENTO_PROCESSADO = "128";
        public const string NFE135_EVENTO_REGISTRADO_VINCULADO_NFE = "135";
        public const string NFE136_EVENTO_REGISTRADO_NAO_VINCULADO_NFE = "136";
        public const string NFE217_NFE_INEXISTENTE = "217";
    }
}
