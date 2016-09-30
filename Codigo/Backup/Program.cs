using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using Util;
using System.Diagnostics;
using Ionic.Zip;
using Negocio;

namespace Backup
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Negocio.GerenciadorSeguranca.getInstance().Backup();
        }
    }
}
