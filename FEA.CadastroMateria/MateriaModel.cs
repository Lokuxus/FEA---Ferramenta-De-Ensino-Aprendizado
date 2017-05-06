using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlServerRepositorio;
using System.Data;


namespace FEA.CadastroMateriaModel
{
    public class MateriaModel
    {

        public bool Cadastra_Materia(string materia, string turma)
        {
            var parametros = new Dictionary<string, string>();
            parametros.Add("@Materia", materia);
            parametros.Add("@Turma", turma);

            var sql = @"INSERT INTO Diciplina (diciplina, turma) 
                        VALUES (@Materia, @Turma)";
            var conexao = new SqlServerRepositorio.SqlServerRepositorio();

            var retorno = conexao.ExecutarSql(sql, parametros);

            return retorno;
        }

        public bool Cadastra_Nodo(string arvore, string nome, string questao, string respostaA, string respostaB, string respostaC)
        {
            var parametros = new Dictionary<string, string>();
            parametros.Add("@Arvore", arvore);
            parametros.Add("@Nome", nome);
            parametros.Add("@Questao", questao);
            parametros.Add("@RespostaA", respostaA);
            parametros.Add("@RespostaB", respostaB);
            parametros.Add("@RespostaC", respostaC);

            //TODO Rever os parametros Modal
            var sql = @"INSERT INTO nivel_do_conhecimento (id_arvore, nome, questao, respostaA, respotaB, respotaC) 
                        VALUES (@Arvore, @Nome, @Questao ,@RespostaA, @RespostaB, @RespostaC)";
            var conexao = new SqlServerRepositorio.SqlServerRepositorio();

            var retorno = conexao.ExecutarSql(sql, parametros);

            return retorno;
        }

        public static DataSet BuscaListaMateria()
        {
            var sql = @"Select * from Diciplina";
            var repositorio = new SqlServerRepositorio.SqlServerRepositorio();

            var retornoSQL = repositorio.ExecutarSqlComRetorno(sql);

            if (retornoSQL != null)
            {

                return retornoSQL;
            }
            else
            {
                DataTable table1 = new DataTable("Retorno");

                DataSet set = new DataSet("Retorno");
                set.Tables.Add(table1);
                return set;
            }
        }

        public static DataSet BuscaListaNodo(string arvore)
        {
            var parametros = new Dictionary<string, string>();
            parametros.Add("@Arvore", arvore);

            var sql = @"Select * from nivel_do_conhecimento where (id_arvore = @Arvore)";
            var repositorio = new SqlServerRepositorio.SqlServerRepositorio();

            var retornoSQL = repositorio.ExecutarSqlComRetorno(sql);

            if (retornoSQL != null)
            {

                return retornoSQL;
            }
            else
            {
                DataTable table1 = new DataTable("Retorno");

                DataSet set = new DataSet("Retorno");
                set.Tables.Add(table1);
                return set;
            }
        }

        public static DataSet NumeroMateria()
        {
            var sql = @"Select COUNT(*) as numero from Diciplina";
            var repositorio = new SqlServerRepositorio.SqlServerRepositorio();

            var retornoSQL = repositorio.ExecutarSqlComRetorno(sql);
            if (retornoSQL != null)
            {

                return retornoSQL;
            }
            else {
                DataTable table1 = new DataTable("Retorno");
                table1.Columns.Add("numero");
                table1.Rows.Add(0);
                DataSet set = new DataSet("Retorno");
                set.Tables.Add(table1);
                return set;
            }
        }

        public bool Deleta_Materia(string id)
        {
            var parametros = new Dictionary<string, string>();
            parametros.Add("@IdMateria", id);

            var repositorio = new SqlServerRepositorio.SqlServerRepositorio();

            var sql = "Delete from Diciplina where id = @IdMateria";

            var retorno = repositorio.ExecutarSql(sql, parametros);
            
            return retorno;
        }

        public bool Deleta_Nodo(string id)
        {
            var parametros = new Dictionary<string, string>();
            parametros.Add("@IdMateria", id);

            var repositorio = new SqlServerRepositorio.SqlServerRepositorio();

            var sql = "Delete from nivel_do_conhecimento where id = @IdMateria";

            var retorno = repositorio.ExecutarSql(sql, parametros);

            return retorno;
        }

    }


}
