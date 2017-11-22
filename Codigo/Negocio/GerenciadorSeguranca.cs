using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Ionic.Zip;
using Util;
using MySql.Data.MySqlClient;
using System.Threading;

namespace Negocio
{
    public class GerenciadorSeguranca
    {
        private static GerenciadorSeguranca seguranca;
        static string PASTA_BACKUP = Properties.Settings.Default.PASTA_BACKUP.ToUpper();
        static string PASTA_MYSQL_SERVER = Properties.Settings.Default.PASTA_MYSQL_SERVER.ToUpper();
        static string SGBD_NOME = Properties.Settings.Default.SGBD_NOME.ToUpper();
        static string SGBD_USUARIO = Properties.Settings.Default.SGBD_USUARIO.ToUpper();
        static string SGBD_SENHA = Properties.Settings.Default.SGBD_SENHA.ToUpper();
        static string SGBD_IP = Properties.Settings.Default.SGBD_IP.ToUpper();
     
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
            //tb_perfil_funcionalidadeTableAdapter ta = new tb_perfil_funcionalidadeTableAdapter();
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

        public void Backup2(string nomeServidor)
        {
            string constring = Dados.Properties.Settings.Default.saceConnectionString;
            try
            {
                // recupera o nome do computador
                String computerName = System.Windows.Forms.SystemInformation.ComputerName;
                if (computerName.Equals(nomeServidor))
                {
                    DirectoryInfo dir = new DirectoryInfo(PASTA_BACKUP);
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
                    String file = PASTA_BACKUP + "\\MySqlBackup" + year + "-" + month + "-" + day +
                          "-" + hour + "-" + minute + "-" + second + "-" + millisecond + ".sql";



                    // Important Additional Connection Options

                    using (MySqlConnection conn = new MySqlConnection(constring))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            //using (MySqlBackup mb = new MySqlBackup(cmd))
                            //{
                            //    cmd.Connection = conn;
                            //    conn.Open();
                            //    mb.ExportToFile(file);
                            //    conn.Close();
                            //}
                        }
                    }

                    using (ZipFile zip = new ZipFile())
                    {
                        // add this map file into the "images" directory in the zip archive
                        zip.AddFile(file);
                        // add the report into a different directory in the archive
                        zip.Save(file + ".zip");
                    }
                    //File.Copy(path + ".zip", Global.PASTA_BACKUP2, true);
                    File.Delete(file);
                }
            }
            catch (Exception e)
            {
                throw new NegocioException("Problemas na criação do backup. Descrição do erro: " + e.InnerException);
            }
        }


        public void Backup(string nomeServidor)
        {
            try
            {
                // recupera o nome do computador
                String computerName = System.Windows.Forms.SystemInformation.ComputerName;
                if (computerName.Equals(nomeServidor))
                {
                    DirectoryInfo dir = new DirectoryInfo(PASTA_BACKUP);
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
                    String path = PASTA_BACKUP + "\\MySqlBackup" + year + "-" + month + "-" + day +
                          "-" + hour + "-" + minute + "-" + second + "-" + millisecond + ".sql";
                
                    StreamWriter file = new StreamWriter(path);
                    ProcessStartInfo psi = new ProcessStartInfo();

                    psi.FileName = PASTA_MYSQL_SERVER + "\\bin\\mysqldump";
                    psi.RedirectStandardInput = false;
                    psi.RedirectStandardOutput = true;
                    //psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}", SGBD_USUARIO, SGBD_SENHA, SGBD_IP, SGBD_NOME);
                    psi.Arguments = string.Format(@" -u {0} -p{1} --host={2} --protocol=tcp --port=3306 --default-character-set=utf8 --single-transaction=TRUE --routines --events {3}", SGBD_USUARIO, SGBD_SENHA, "127.0.0.1", SGBD_NOME);
                    psi.UseShellExecute = false;

                    //psi.ErrorDialog = true;
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
                    //File.Copy(path + ".zip", Global.PASTA_BACKUP2, true);
                    File.Delete(path);
                    process.Close();
                }
            }
            catch (Exception e)
            {
                throw new NegocioException("Problemas na criação do backup. Descrição do erro: " + e.InnerException);
            }
        }

        public void Restore(string pathZip)
        {
            try
            {
                using (ZipFile zip = new ZipFile())
                {
                    // add this map file into the "images" directory in the zip archive
                    zip.ExtractAll(pathZip);
                }

                StreamReader file = new StreamReader(pathZip);
                string input = file.ReadToEnd();
                file.Close();

                string constring = Dados.Properties.Settings.Default.saceConnectionString;
            
                using (MySqlConnection conn = new MySqlConnection(constring))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        //using (MySqlBackup mb = new MySqlBackup(cmd))
                        //{
                        //    cmd.Connection = conn;
                        //    conn.Open();
                        //    mb.ImportFromFile(input);
                        //    conn.Close();
                        //}
                    }
                }

            }
            catch (IOException)
            {
                throw new NegocioException("Problemas na restauração do backup.");
            }
        }
    }
}
