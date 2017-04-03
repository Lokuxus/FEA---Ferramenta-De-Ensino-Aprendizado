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

        public static DataSet BuscaListaMateria()
        {
            var sql = @"Select * from Diciplina";
            var repositorio = new SqlServerRepositorio.SqlServerRepositorio();

            var retornoSQL = repositorio.ExecutarSqlComRetorno(sql);

            return retornoSQL;
        }

        

    }


}
