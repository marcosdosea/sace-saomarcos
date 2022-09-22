using Dados;
using MySql.Data.MySqlClient;
using System.Data.Entity.Core;

namespace Telas
{
    public class TratarException
    {
        public void TratarMySqlException(object sender, ThreadExceptionEventArgs t)
        {
            DialogResult result = DialogResult.Cancel;
            string erro = t.Exception.Message;
            
            // para exibir todo stacktrace completo quando difícil identificar o erro
            //if (true)
            //    MessageBox.Show(erro + t.Exception.StackTrace + t.Exception.InnerException + t.Exception.InnerException.StackTrace, "Erro da Aplicação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
           
            if (t.Exception is ApplicationException)
            {
                erro = "Erro fatal!/n Entre em contato com o administrador/nErro: " + t.Exception.Message;
            } 
            else if (t.Exception is SystemException)
            {

                if (t.Exception is ArgumentOutOfRangeException)
                    erro = "O valor está fora dos limites do indice " + t.Exception.TargetSite;
                else if (t.Exception is ArgumentNullException)
                    erro = "Objeto não pode ser nulo " + t.Exception.TargetSite;
                else if (t.Exception is ArgumentException)
                    erro = "Argumento inválido " + t.Exception.TargetSite;
                if (t.Exception is DuplicateWaitObjectException)
                    erro = "... " + t.Exception.TargetSite;
                else if (t.Exception is InvalidOperationException)
                    erro = "... " + t.Exception.TargetSite;
                if (t.Exception is AccessViolationException)
                    erro = "... " + t.Exception.TargetSite;
                else if (t.Exception is NullReferenceException)
                    erro = "Referencia ao objeto não encontrada ou nula" + t.Exception.TargetSite;
                else if (t.Exception is IndexOutOfRangeException)
                    erro = "Indice invalido " + t.Exception.TargetSite;
                if (t.Exception is DivideByZeroException)
                    erro = "Não é possivel divisão por zero ";
                else if (t.Exception is NullReferenceException)
                    erro = "Referência para um objeto não encontrado.";
                if (t.Exception is MySqlException)
                {
                    MySqlException exception = (MySqlException) t.Exception;
                    // Tratamento de banco de dados inacessível
                    if (exception.Number == 1042)
                    {
                        erro = "O banco de dados do sistema está inacessível. Favor verificar as conexões da rede. " ;
                    }
                }
                else if ((t.Exception is DadosException) || (t.Exception is EntityException))
                {

                    MySqlException exception = null;
                    if (t.Exception.InnerException is MySqlException ) {
                        exception = (MySqlException)t.Exception.InnerException; 
                    } else if (t.Exception.InnerException.InnerException is MySqlException ) {
                        exception = (MySqlException)t.Exception.InnerException.InnerException; 
                    }
                    
                    if (exception != null)
                    {
                        // Tratamento de chaves únicas
                        if (exception.Number == 1042)
                        {
                            erro = "O banco de dados do sistema está inacessível. Favor verificar as conexões da rede.";
                        }
                        // Tratamento de chaves únicas
                        else if (exception.Number == 1062)
                        {
                            if (t.Exception is DadosException)
                            {
                                DadosException de = (DadosException)t.Exception;
                                erro = "O " + de.Entidade + " já foi inserido na base de dados.";
                            }
                            else
                            {
                                erro = "A entidade já foi inserida na base de dados.";
                            }
                        }
                        // Tratamento de chaves estrangeiras
                        else if (exception.Number == 1451)
                        {
                            if (t.Exception is DadosException)
                            {
                                DadosException de = (DadosException)t.Exception;
                                erro = "O " + de.Entidade + " não pode ser excluído por estar associado a outro registro na base de dados.";
                            }
                            else
                            {
                                erro = "A entidade não pode ser excluída por estar associada a outro registro na base de dados.";
                            }
                        }
                        else
                        {
                            erro = "Erro da Base de Dados Número " + exception.Number + ": Favor contactar administrador do sistema.";
                        }
                    }

                    //erro += t.Exception.Message;// +"\n" + t.Exception.InnerException;

                }
               
            }

            string[] palavras = erro.Split(' ');
            string erroQuebraLinha = "";
            for (int i = 0; i < palavras.Length; i++)
            {
                if ((i> 0) && (i % 10 == 0))
                {
                    erroQuebraLinha += Environment.NewLine;
                }
                erroQuebraLinha += palavras[i] + " ";
            }
            result = MessageBox.Show(erroQuebraLinha, "Erro da Aplicação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (result == DialogResult.Abort)
                Application.Exit();
        }
    }
}