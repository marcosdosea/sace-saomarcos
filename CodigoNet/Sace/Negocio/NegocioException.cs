namespace Negocio
{
    public class NegocioException : SystemException
    {
        public NegocioException()
            : base("Erro no negócio da aplicação.")
        {

        }

        public NegocioException(String mensagem)
            : base(mensagem)
        {

        }

        public NegocioException(String mensagem, Exception inner)
            : base(mensagem, inner)
        {

        }
    }
}
