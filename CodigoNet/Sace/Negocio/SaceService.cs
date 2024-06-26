using Dados;

namespace Negocio
{
    public class SaceService
    {
        private readonly SaceContext context;
        private GerenciadorBanco gerenciadorBanco;
        private GerenciadorCartaoCredito gerenciadorCartaoCredito;
        private GerenciadorCfop gerenciadorCfop;
        private GerenciadorConta gerenciadorConta;
        private GerenciadorContaBanco gerenciadorContaBanco;
        private GerenciadorCst gerenciadorCst;
        private GerenciadorEntrada gerenciadorEntrada;
        private GerenciadorEntradaProduto gerenciadorEntradaProduto;
        private GerenciadorFormaPagamento gerenciadorFormaPagamento;
        private GerenciadorGrupo gerenciadorGrupo;
        private GerenciadorGrupoConta gerenciadorGrupoConta;
        private GerenciadorImposto gerenciadorImposto;
        private GerenciadorImprimirDocumento gerenciadorImprimirDocumento;
        private GerenciadorLoja gerenciadorLoja;
        private GerenciadorMovimentacaoConta gerenciadorMovimentacaoConta;
        private GerenciadorMunicipio gerenciadorMunicipio;
        private GerenciadorNFe gerenciadorNFe;
        private GerenciadorPessoa gerenciadorPessoa;
        private GerenciadorPlanoConta gerenciadorPlanoConta;
        private GerenciadorPontaEstoque gerenciadorPontaEstoque;
        private GerenciadorProduto gerenciadorProduto;
        private GerenciadorProdutoLoja gerenciadorProdutoLoja;
        private GerenciadorSaida gerenciadorSaida;
        private GerenciadorSaidaPagamento gerenciadorSaidaPagamento;
        private GerenciadorSaidaPedido gerenciadorSaidaPedido;
        private GerenciadorSaidaProduto gerenciadorSaidaProduto;
        private GerenciadorSolicitacaoDocumento gerenciadorSolicitacaoDocumento;
        private GerenciadorSolicitacaoEvento gerenciadorSolicitacaoEvento;
        private GerenciadorSubgrupo gerenciadorSubgrupo;
        private GerenciadorTipoMovimentacaoConta gerenciadorTipoMovimentacaoConta;
        private GerenciadorUsuario gerenciadorUsuario;


        public SaceService(SaceContext context)
        {
            this.context = context;
        }
        public GerenciadorBanco GerenciadorBanco
        {
            get
            {
                gerenciadorBanco ??= new GerenciadorBanco(context);
                return gerenciadorBanco;
            }
        }
        public GerenciadorCartaoCredito GerenciadorCartaoCredito
        {
            get
            {
                gerenciadorCartaoCredito ??= new GerenciadorCartaoCredito(context);
                return gerenciadorCartaoCredito;
            }
        }
        public GerenciadorCfop GerenciadorCfop
        {
            get
            {
                gerenciadorCfop ??= new GerenciadorCfop(context);
                return gerenciadorCfop;
            }
        }
        public GerenciadorConta GerenciadorConta
        {
            get
            {
                gerenciadorConta ??= new GerenciadorConta(context);
                return gerenciadorConta;
            }
        }
        public GerenciadorContaBanco GerenciadorContaBanco
        {
            get
            {
                gerenciadorContaBanco ??= new GerenciadorContaBanco(context);
                return gerenciadorContaBanco;
            }
        }
        public GerenciadorCst GerenciadorCst
        {
            get
            {
                gerenciadorCst ??= new GerenciadorCst(context);
                return gerenciadorCst;
            }
        }
        public GerenciadorEntrada GerenciadorEntrada
        {
            get
            {
                gerenciadorEntrada ??= new GerenciadorEntrada(context);
                return gerenciadorEntrada;
            }
        }
        public GerenciadorEntradaProduto GerenciadorEntradaProduto
        {
            get
            {
                gerenciadorEntradaProduto ??= new GerenciadorEntradaProduto(context);
                return gerenciadorEntradaProduto;
            }
        }
        public GerenciadorFormaPagamento GerenciadorFormaPagamento
        {
            get
            {
                gerenciadorFormaPagamento ??= new GerenciadorFormaPagamento(context);
                return gerenciadorFormaPagamento;
            }
        }
        public GerenciadorGrupo GerenciadorGrupo
        {
            get
            {
                gerenciadorGrupo ??= new GerenciadorGrupo(context);
                return gerenciadorGrupo;
            }
        }
        public GerenciadorGrupoConta GerenciadorGrupoConta
        {
            get
            {
                gerenciadorGrupoConta ??= new GerenciadorGrupoConta(context);
                return gerenciadorGrupoConta;
            }
        }
        public GerenciadorImposto GerenciadorImposto
        {
            get
            {
                gerenciadorImposto ??= new GerenciadorImposto(context);
                return gerenciadorImposto;
            }
        }
        public GerenciadorImprimirDocumento GerenciadorImprimirDocumento
        {
            get
            {
                gerenciadorImprimirDocumento ??= new GerenciadorImprimirDocumento(context);
                return gerenciadorImprimirDocumento;
            }
        }
        public GerenciadorLoja GerenciadorLoja
        {
            get
            {
                gerenciadorLoja ??= new GerenciadorLoja(context);
                return gerenciadorLoja;
            }
        }
        public GerenciadorMovimentacaoConta GerenciadorMovimentacaoConta
        {
            get
            {
                gerenciadorMovimentacaoConta ??= new GerenciadorMovimentacaoConta(context);
                return gerenciadorMovimentacaoConta;
            }
        }
        public GerenciadorMunicipio GerenciadorMunicipio
        {
            get
            {
                gerenciadorMunicipio ??= new GerenciadorMunicipio(context);
                return gerenciadorMunicipio;
            }
        }
        public GerenciadorNFe GerenciadorNFe
        {
            get
            {
                gerenciadorNFe ??= new GerenciadorNFe(context);
                return gerenciadorNFe;
            }
        }
        public GerenciadorPessoa GerenciadorPessoa
        {
            get
            {
                gerenciadorPessoa ??= new GerenciadorPessoa(context);
                return gerenciadorPessoa;
            }
        }
        public GerenciadorPlanoConta GerenciadorPlanoConta
        {
            get
            {
                gerenciadorPlanoConta ??= new GerenciadorPlanoConta(context);
                return gerenciadorPlanoConta;
            }
        }
        public GerenciadorPontaEstoque GerenciadorPontaEstoque
        {
            get
            {
                gerenciadorPontaEstoque ??= new GerenciadorPontaEstoque(context);
                return gerenciadorPontaEstoque;
            }
        }
        public GerenciadorProduto GerenciadorProduto
        {
            get
            {
                gerenciadorProduto ??= new GerenciadorProduto(context);
                return gerenciadorProduto;
            }
        }
        public GerenciadorProdutoLoja GerenciadorProdutoLoja
        {
            get
            {
                gerenciadorProdutoLoja ??= new GerenciadorProdutoLoja(context);
                return gerenciadorProdutoLoja;
            }
        }
        public GerenciadorSaida GerenciadorSaida
        {
            get
            {
                gerenciadorSaida ??= new GerenciadorSaida(context);
                return gerenciadorSaida;
            }
        }
        public GerenciadorSaidaPagamento GerenciadorSaidaPagamento
        {
            get
            {
                gerenciadorSaidaPagamento ??= new GerenciadorSaidaPagamento(context);
                return gerenciadorSaidaPagamento;
            }
        }
        public GerenciadorSaidaPedido GerenciadorSaidaPedido
        {
            get
            {
                gerenciadorSaidaPedido ??= new GerenciadorSaidaPedido(context);
                return gerenciadorSaidaPedido;
            }
        }
        public GerenciadorSaidaProduto GerenciadorSaidaProduto
        {
            get
            {
                gerenciadorSaidaProduto ??= new GerenciadorSaidaProduto(context);
                return gerenciadorSaidaProduto;
            }
        }
        public GerenciadorSolicitacaoDocumento GerenciadorSolicitacaoDocumento
        {
            get
            {
                gerenciadorSolicitacaoDocumento ??= new GerenciadorSolicitacaoDocumento(context);
                return gerenciadorSolicitacaoDocumento;
            }
        }
        public GerenciadorSolicitacaoEvento GerenciadorSolicitacaoEvento
        {
            get
            {
                gerenciadorSolicitacaoEvento ??= new GerenciadorSolicitacaoEvento(context);
                return gerenciadorSolicitacaoEvento;
            }
        }
        public GerenciadorSubgrupo GerenciadorSubgrupo
        {
            get
            {
                gerenciadorSubgrupo ??= new GerenciadorSubgrupo(context);
                return gerenciadorSubgrupo;
            }
        }
        public GerenciadorTipoMovimentacaoConta GerenciadorTipoMovimentacaoConta
        {
            get
            {
                gerenciadorTipoMovimentacaoConta ??= new GerenciadorTipoMovimentacaoConta(context);
                return gerenciadorTipoMovimentacaoConta;
            }
        }
        public GerenciadorUsuario GerenciadorUsuario
        {
            get
            {
                gerenciadorUsuario ??= new GerenciadorUsuario(context);
                return gerenciadorUsuario;
            }
        }
    }
}
