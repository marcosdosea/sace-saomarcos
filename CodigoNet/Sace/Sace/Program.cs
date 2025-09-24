using Dados;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Windows.Forms;
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
            TratarException eh = new TratarException();

            ApplicationConfiguration.Initialize();
            Application.ThreadException += new ThreadExceptionEventHandler(eh.TratarMySqlException);

            // Pass options to Principal if needed (uncomment if Principal accepts options)
            Application.Run(new Sace());
        }
    }
}