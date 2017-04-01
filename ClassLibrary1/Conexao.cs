using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Configuration;

namespace SqlServerRepositorio
{
    public class SqlServerRepositorio
    {
        private string _ConnectionStringKey;
        /// <summary>
        /// A chave utilizada para pegar a string de conexão das AppSettings do aplicativo
        /// que referencia a DLL que contém essa classe
        /// </summary>
        public string ConnectionStringKey
        {
            get
            {
                if (String.IsNullOrEmpty(this._ConnectionStringKey))
                {
                    this._ConnectionStringKey = "SqlServerRepositorio_StringConexao";
                }

                return _ConnectionStringKey;
            }
            set { _ConnectionStringKey = value; }
        }

        private string _StringConexao;
        /// <summary>
        /// A string de conexão para acesso ao banco de dados
        /// </summary>
        public string StringConexao
        {
            get
            {
                if (String.IsNullOrEmpty(this._StringConexao))
                {
                    var tempStrCon = string.Empty;
                    ///Primeiro busca a string de conexão na secção correção
                    var strConSettings =  System.Configuration.ConfigurationManager.ConnectionStrings[this.ConnectionStringKey];

                    ///Se não encontrar, busca nas AppSetings
                    if (strConSettings == null || String.IsNullOrEmpty(strConSettings.ConnectionString))
                    {
                        tempStrCon = System.Configuration.ConfigurationManager.AppSettings[this.ConnectionStringKey];
                    }
                    else
                    {
                        tempStrCon = strConSettings.ConnectionString;
                    }

                    if (String.IsNullOrEmpty(tempStrCon))
                    {
                        //Se a string de conexão não foi definida, usando o construtor ou o método set da propriedade
                        //e não existe nenhuma string de conexão com o nome especificado na propriedade AppSettingsKey
                        //desta classe, lança uma exceção devida a falta de uma string válida para a conexão com o banco de dados
                        throw new ArgumentNullException("A string de conexão não pode ser vazia/nula. Defina a String de Conexão usando o construtor parametrizado, definindo um valor para a propriedade 'StringConexao' ou adicionando uma configuração na seção 'ConnectionStrings' com o valor de Name='" + this.ConnectionStringKey + "' nas configuações do aplicativo!");
                    }

                    this._StringConexao = tempStrCon;
                }

                return this._StringConexao;
            }
            set { this._StringConexao = value; }
        }

        /// <summary>
        /// A última exceção ocorrida no repositório
        /// </summary>
        public Exception UltimaExcecao { get; set; }
        /// <summary>
        /// A lista completa de erros da última execução
        /// </summary>
        public List<Exception> Erros { get; set; }

        /// <summary>
        /// Contrutor sem parâmetros
        /// </summary>
        public SqlServerRepositorio() { }
        /// <summary>
        /// Construtor parametrizado
        /// </summary>
        /// <param name="strConexao">A string de conexão com o banco de dados</param>
        public SqlServerRepositorio(string strConexao)
        {
            this.StringConexao = strConexao;
        }

        /// <summary>
        /// Método responsável por criar uma instância válida para a conexão com o banco de dados
        /// </summary>
        /// <returns>A conexão válida e aberta do banco de dados</returns>
        private SqlConnection _IniciarConexao()
        {
            ///Limpa as variáveis de erro
            this.UltimaExcecao = null;
            this.Erros = new List<Exception>();

            SqlConnection conexao = null;

            try
            {
                conexao = new SqlConnection(this.StringConexao);

                conexao.Open();
            }
            catch (Exception ex)
            {
                this.UltimaExcecao = ex;
                this.Erros.Add(ex);
            }

            return conexao;
        }

        /// <summary>
        /// Executa o comando SQL passado como parametro e retorna um booleno indicando o sucesso da operação
        /// </summary>
        /// <param name="sql">O comando SQL a ser executado</param>
        /// <returns>Se o número total de linhas afetadas dor 0 ou se ocorrer alguma exceção retorna FALSE, caso contrário retorna TRUE</returns>
        public bool ExecutarSql(string sql)
        {
            var sucesso = true;

            try
            {
                using (var conexao = this._IniciarConexao())
                using (var comando = new SqlCommand(sql, conexao))
                {
                    //Somente retorna sucesso = true se o número de linhas afetadas for maior que 0
                    sucesso = comando.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                sucesso = false;
                this.UltimaExcecao = ex;
                this.Erros.Add(ex);
            }

            return sucesso;
        }

        /// <summary>
        /// Executa o comando SQL passado substituindo os parâmetros passados no comando SQL
        /// e retorna um booleno indicando o sucesso da operação
        /// </summary>
        /// <param name="sql">O comando SQL a ser executado</param>
        /// <param name="parametros">Os parâmetros para serem substituídos no comando SQL</param>
        /// <returns>Se o número total de linhas afetadas dor 0 ou se ocorrer alguma exceção retorna FALSE, caso contrário retorna TRUE</returns>
        public bool ExecutarSql(string sql, Dictionary<string, string> parametros)
        {
            var sucesso = true;

            try
            {
                using (var conexao = this._IniciarConexao())
                using (var comando = new SqlCommand(sql, conexao))
                {
                    //Se exisirem parâmetros para esa query, realiza a inserção dos parâmetros
                    //no comando para ser executado
                    if (parametros != null)
                    {
                        foreach (var parametro in parametros)
                        {
                            //Adiciona os parâmetros para o comando
                            comando.Parameters.AddWithValue(parametro.Key, parametro.Value);
                        }
                    }

                    //Somente retorna sucesso = true se o número de linhas afetadas for maior que 0
                    sucesso = comando.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                sucesso = false;
                this.UltimaExcecao = ex;
                this.Erros.Add(ex);
            }

            return sucesso;
        }

        /// <summary>
        /// Executa o comando SQL passado e retorna um DataSet com o resultado
        /// </summary>
        /// <param name="sql">O comando SQL a ser utilizado</param>
        /// <returns>O DataSet com os resultados da consulta</returns>
        public DataSet ExecutarSqlComRetorno(string sql)
        {
            DataSet resultado = new DataSet();

            try
            {
                using (var conexao = this._IniciarConexao())
                using (var adapter = new SqlDataAdapter(sql, conexao))
                {
                    adapter.Fill(resultado);
                }
            }
            catch (Exception ex)
            {
                resultado = null;
                this.UltimaExcecao = ex;
                this.Erros.Add(ex);
            }

            return resultado;
        }

        /// <summary>
        /// Executa o comando SQL passado e retorna um DataSet com o resultado
        /// </summary>
        /// <param name="sql">O comando SQL a ser utilizado</param>
        /// <param name="parametros">Os parâmetros para serem substituídos no comando SQL</param>
        /// <returns>O DataSet com os resultados da consulta</returns>
        public DataSet ExecutarSqlComRetorno(string sql, Dictionary<string, string> parametros)
        {
            DataSet resultado = new DataSet();

            try
            {
                using (var conexao = this._IniciarConexao())
                using (var adapter = new SqlDataAdapter(sql, conexao))
                {
                    //Se exisirem parâmetros para esa query, realiza a inserção dos parâmetros
                    //no comando para ser executado
                    if (parametros != null)
                    {
                        foreach (var parametro in parametros)
                        {
                            //Adiciona os parâmetros para o comando
                            adapter.SelectCommand.Parameters.AddWithValue(parametro.Key, parametro.Value);
                        }
                    }

                    adapter.Fill(resultado);
                }
            }
            catch (Exception ex)
            {
                resultado = null;
                this.UltimaExcecao = ex;
                this.Erros.Add(ex);
            }

            return resultado;
        }

    }
}
