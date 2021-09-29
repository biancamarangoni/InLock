using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string stringConexao = "Data Source=NOTE0113G2\\SQLEXPRESS; initial catalog=InLock_Games_Manha; user id=sa; pwd=Senai@132";

        public UsuarioDomain BuscarPorEmailSenha(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = "SELECT idUsuario, email, U.idTipoUsuario, titulo FROM Usuario U INNER JOIN Tipo_Usuario T ON T.idTipoUsuario = U.idTipoUsuario WHERE email = @email AND senha = @senha;";

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuarioDomain usuarioBuscado = new UsuarioDomain()
                        {
                            idUsuario = Convert.ToInt32(rdr[0]),
                            email = rdr[1].ToString(),
                            TipoUsuario = new TipoUsuarioDomain()
                            {
                                idTipoUsuario = Convert.ToInt32(rdr[2]),
                                titulo = rdr[3].ToString()
                            }
                        };

                        return usuarioBuscado;
                    }

                    return null;
                }
            }


        }

    }
}
