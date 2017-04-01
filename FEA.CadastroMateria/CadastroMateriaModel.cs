using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlServerRepositorio;

namespace FEA.CadastroMateriaModel
{
    public class CadastroMateriaModel
    {
        public bool Cadastra_Materia(string materia, string turma)
        {

            var sql = @"INSERT INTO Diciplina(diciplina, turma) VALUES (@materia, @turma)";
            var conexao = new SqlServerRepositorio.SqlServerRepositorio();

            var retorno = conexao.ExecutarSql(sql);

            return retorno;
        }

    }


}
