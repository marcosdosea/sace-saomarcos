using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dominio;
using Dados.saceDataSetTableAdapters;
using Dados;
using Util;
using System.Data.Common;

namespace Negocio
{
    public class GerenciadorDocumentoPagamento 
    {
        private static GerenciadorDocumentoPagamento gDocumentoPagamento;
        private static tb_documento_pagamentoTableAdapter tb_documento_pagamentoTA;
        
        
        public static GerenciadorDocumentoPagamento getInstace()
        {
            if (gDocumentoPagamento == null)
            {
                gDocumentoPagamento = new GerenciadorDocumentoPagamento();
                tb_documento_pagamentoTA = new tb_documento_pagamentoTableAdapter();
            }
            return gDocumentoPagamento;
        }

        public Int64 inserir(DocumentoPagamento documento)
        {
            try
            {
                tb_documento_pagamentoTA.Insert(documento.CodPessoaResponsavel, documento.CodBanco,
                    documento.CodTipoDocumento, documento.NumeroDocumento, documento.DataDocumento,
                    documento.DataVencimento, documento.Valor, documento.Agencia, documento.Conta,
                    documento.Emitente, documento.Observacao);
                return 0;
            }
            catch (Exception e)
            {
                throw new DadosException("Documento de Pagamento", e.Message, e);
            }
        }

        public void atualizar(DocumentoPagamento documento)
        {
            try
            {
                tb_documento_pagamentoTA.Update(documento.CodPessoaResponsavel, documento.CodBanco,
                    documento.CodTipoDocumento, documento.NumeroDocumento, documento.DataDocumento,
                    documento.DataVencimento, documento.Valor, documento.Agencia, documento.Conta,
                    documento.Emitente, documento.Observacao, documento.CodDocumentoPagamento);
            }
            catch (Exception e)
            {
                throw new DadosException("Documento de Pagamento", e.Message, e);
            }
        }

        public void remover(Int64 codDocumentoPagamento)
        {
            if (codDocumentoPagamento == 1)
                throw new NegocioException("Esse documento não pode ser excluído para manter a consistência da base de dados");
            try
            {
                tb_documento_pagamentoTA.Delete(codDocumentoPagamento);
            }
            catch (Exception e)
            {
                throw new DadosException("Documento de Pagamento", e.Message, e);
            }
        }

        public DocumentoPagamento obterDocumentoPagamento(Int64 codDocumentoPagamento)
        {
            DocumentoPagamento documentoPagamento = new DocumentoPagamento();
            
            Dados.saceDataSetTableAdapters.tb_documento_pagamentoTableAdapter tb_documentoTA = new tb_documento_pagamentoTableAdapter();
            Dados.saceDataSet.tb_documento_pagamentoDataTable documentoDT = tb_documentoTA.GetDataByCodDocumento(codDocumentoPagamento);

            documentoPagamento.Agencia = documentoDT.Rows[0]["agencia"].ToString();
            documentoPagamento.CodBanco = Convert.ToInt32(documentoDT.Rows[0]["codBanco"].ToString());
            documentoPagamento.CodPessoaResponsavel = Convert.ToInt64(documentoDT.Rows[0]["codPessoaResponsavel"].ToString());
            documentoPagamento.CodTipoDocumento = Convert.ToByte(documentoDT.Rows[0]["codTipoDocumento"].ToString());
            documentoPagamento.Conta = documentoDT.Rows[0]["conta"].ToString();
            documentoPagamento.DataDocumento = Convert.ToDateTime(documentoDT.Rows[0]["dataDocumento"].ToString());
            documentoPagamento.DataVencimento = Convert.ToDateTime(documentoDT.Rows[0]["dataVencimento"].ToString());
            documentoPagamento.Emitente = documentoDT.Rows[0]["emitente"].ToString();
            documentoPagamento.NumeroDocumento = documentoDT.Rows[0]["numeroDocumento"].ToString();
            documentoPagamento.Observacao = documentoDT.Rows[0]["observacao"].ToString();
            documentoPagamento.Valor = Convert.ToDecimal(documentoDT.Rows[0]["valor"].ToString());

            return documentoPagamento;
        }

    }
}