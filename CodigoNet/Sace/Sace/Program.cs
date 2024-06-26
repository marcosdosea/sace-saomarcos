using Dados;
using Microsoft.EntityFrameworkCore;
using Util;

namespace Sace
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            
            // configuração da string de conexão
            var builder = new DbContextOptionsBuilder<SaceContext>();
            
            builder.UseMySQL(UtilConfig.Default.SaceConnection);
            var options = builder.Options;
            
            TratarException eh = new TratarException();

            ApplicationConfiguration.Initialize();
            Application.ThreadException += new ThreadExceptionEventHandler(eh.TratarMySqlException);
            Application.Run(new Principal(options));
        }
    }
}