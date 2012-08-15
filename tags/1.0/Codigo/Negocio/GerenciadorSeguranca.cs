using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dados.saceDataSetTableAdapters;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using Util;

namespace Negocio
{
    public class GerenciadorSeguranca
    {
        private static GerenciadorSeguranca seguranca;

        public static GerenciadorSeguranca getInstance()
        {
            if(seguranca == null)
            {
                seguranca = new GerenciadorSeguranca();
            }
            return seguranca;
        }

        public bool verificaPermissao(Form sender, int funcao, int codUsuario)
        {
            tb_perfil_funcionalidadeTableAdapter ta = new tb_perfil_funcionalidadeTableAdapter();
            //TODO

            //DataTable dt = ta.FillByPerfilFuncionalidade(ta, funcao,             if (dt.Rows.Count > 0)
            //{
            //    return true;
            //}
            //else
            //{
            //    sender.Close();
            //    throw new TelaException("Funcionalidade não autorizada!");
            //}
            return true;
        }

        public void Backup()
        {
            try
            {
                // recupera o nome do computador
                String computerName = System.Windows.Forms.SystemInformation.ComputerName;
                if (computerName.Equals(Util.Global.NOME_SERVIDOR))
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
                    process.Close();
                }
            }
            catch (IOException)
            {
                throw new NegocioException("Problemas na criação do backup.");
            }
        }

        public void Restore()
        {
            try
            {
                //Read file from C:\
                string path;
                path = "C:\\Backup\\MySqlBackup.sql";
                StreamReader file = new StreamReader(path);
                string input = file.ReadToEnd();
                file.Close();

                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "C:\\Program Files\\MySQL\\MySQL Server 5.5\\bin\\mysql";
                psi.RedirectStandardInput = true;
                psi.RedirectStandardOutput = false;
                psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}",
                    "sace", "sace", "localhost", "sace");
                psi.UseShellExecute = false;


                Process process = Process.Start(psi);
                process.StandardInput.WriteLine(input);
                process.StandardInput.Close();
                process.WaitForExit();
                process.Close();
            }
            catch (IOException)
            {
                throw new NegocioException("Problemas na restauração do backup.");
            }
        }
    }
}
