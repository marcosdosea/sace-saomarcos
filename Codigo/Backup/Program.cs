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
            //Negocio.GerenciadorSeguranca.getInstance().Backup();


            try
            {
                // recupera o nome do computador
                String computerName = System.Windows.Forms.SystemInformation.ComputerName;
                if (computerName.Equals(Global.NOME_SERVIDOR) || computerName.Equals(Global.NOME_SERVIDOR_NFE))
                {
                    DirectoryInfo dir = new DirectoryInfo(Global.PASTA_BACKUP);
                    if (!dir.Exists)
                        dir.Create();

                    DateTime Time = DateTime.Now;
                    int year = Time.Year;
                    int month = Time.Month;
                    int day = Time.Day;
                    int hour = Time.Hour;
                    int minute = Time.Minute;
                    int second = Time.Second;
                    int millisecond = Time.Millisecond;

                    //Save file to C:\ with the current date as a filename
                    String path = Util.Global.PASTA_BACKUP + "MySqlBackup" + year + "-" + month + "-" + day +
                          "-" + hour + "-" + minute + "-" + second + "-" + millisecond + ".sql";

                    StreamWriter file = new StreamWriter(path);
                    ProcessStartInfo psi = new ProcessStartInfo();

                    psi.FileName = Global.PASTA_MYSQL_SERVER + "bin\\mysqldump";
                    psi.RedirectStandardInput = false;
                    psi.RedirectStandardOutput = true;
                    psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}", Global.SGBD_USUARIO, Global.SGBD_SENHA, Global.SGBD_IP, Global.SGBD_NOME);
                    psi.UseShellExecute = false;

                    Process process = Process.Start(psi);

                    string output = process.StandardOutput.ReadToEnd();

                    file.WriteLine(output);
                    process.WaitForExit();
                    file.Close();
                    using (ZipFile zip = new ZipFile())
                    {
                        // add this map file into the "images" directory in the zip archive
                        zip.AddFile(path);
                        // add the report into a different directory in the archive
                        zip.Save(path + ".zip");
                    }
                    File.Copy(path + ".zip", Global.PASTA_BACKUP2, true);
                    File.Delete(path);
                    process.Close();
                }
            }
            catch (IOException)
            {
                throw new NegocioException("Problemas na criação do backup.");
            }
        }
    }
}
