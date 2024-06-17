namespace Telas
{
    public class TelaException: SystemException
    {
        public TelaException(string message)
            :base(message)
        {}

        public TelaException(string message, Exception exp)
            : base(message, exp)
        { }
    }
}
