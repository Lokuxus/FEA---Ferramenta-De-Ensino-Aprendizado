using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlServerRepositorio;
using System.Data;

namespace FEA.Usuario
{
    public class UsuarioModel
    {
        public string Login { get; set; }
        
        public bool IsLogado(string user, string psswd)
        {
            this.Login = user;

            var sql = @"Select * from Usuario";
            var repositorio = new SqlServerRepositorio.SqlServerRepositorio();

            var retorno = repositorio.ExecutarSqlComRetorno(sql);

            return true;
        }

        public static DataSet BuscarUsuario()
        {
            var sql = @"Select * from Usuario";
            var repositorio = new SqlServerRepositorio.SqlServerRepositorio();

            var retorno = repositorio.ExecutarSqlComRetorno(sql);

            return retorno;
        } 
        
    }
}
