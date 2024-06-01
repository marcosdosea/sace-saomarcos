namespace Util
{
    public class UtilException : SystemException
    {
        
        public UtilException(): base()
        { }

        public UtilException(string msg):base(msg)
        { }

        public UtilException(string msg, Exception ex): base(msg,ex)
        { }

    }
}
