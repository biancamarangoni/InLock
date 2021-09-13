using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private string stringConexao = "Data Source=NOTE0113G2\\SQLEXPRESS; initial catalog=InLock_Games_Manha; user id=sa; pwd=Senai@132";

        public void Atualizar(JogoDomain jogoAtualizado)
        {
            JogoDomain jogoAntigo = BuscarPorId(jogoAtualizado.idJogo);


            if (jogoAtualizado.estudio.idEstudio > 0)
            {
                jogoAtualizado.estudio.idEstudio = jogoAntigo.estudio.idEstudio;
            }

            if (jogoAtualizado.nomeJogo != null)
            {
                jogoAtualizado.nomeJogo = jogoAntigo.nomeJogo;
            }

            if (jogoAtualizado.descricao != null)
            {
                jogoAtualizado.descricao = jogoAntigo.descricao;
            }

            if (jogoAtualizado.dataLancamento != null)
            {
                jogoAtualizado.dataLancamento = jogoAntigo.dataLancamento;
            }

            if (jogoAtualizado.valor > 0)
            {
                jogoAtualizado.valor = jogoAntigo.valor;
            }

            using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string queryUpdateBody = "UPDATE JOGO SET nomeJogo = @nomeJogo WHERE idJogo = @idJogo";

                    using (SqlCommand cmd = new SqlCommand(queryUpdateBody, con))
                    {
                    cmd.Parameters.AddWithValue("@idJogo", jogoAtualizado.idJogo);
                    cmd.Parameters.AddWithValue("@idEstudio", jogoAtualizado.estudio.idEstudio);
                    cmd.Parameters.AddWithValue("@nomeJogo", jogoAtualizado.nomeJogo);
                    cmd.Parameters.AddWithValue("@descricao", jogoAtualizado.descricao);
                    cmd.Parameters.AddWithValue("@dataLancamento", jogoAtualizado.dataLancamento);
                    cmd.Parameters.AddWithValue("@valor", jogoAtualizado.valor);
                    con.Open();

                        cmd.ExecuteNonQuery();
                    }
                }
        }

        public JogoDomain BuscarPorId(int idJogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idJogo, nomeEstudio, nomeJogo, descricao, dataLancamento, valor FROM JOGOS jogo LEFT JOIN ESTUDIO estudio ON estudio.idEstudio = jogo.idEstudio WHERE idJogo = @idJogo;";

                con.Open();

                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idJogo", idJogo);

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        JogoDomain jogoBuscado = new JogoDomain
                        {
                            idJogo = Convert.ToInt32(reader["idJogo"]),

                            estudio = new EstudioDomain()
                            {
                                nomeEstudio = reader["nomeEstudio"].ToString()
                            },

                            nomeJogo = reader["nomeJogo"].ToString(),

                            descricao = reader["descricao"].ToString(),

                            dataLancamento = Convert.ToDateTime(reader["dataLancamento"]),

                            valor = Convert.ToDouble(reader["valor"])

                        };

                        return jogoBuscado;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(JogoDomain novoJogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryInsert = "INSERT INTO JOGO (idEstudio, nomeJogo, descricao, dataLancamento, valor) VALUES (@idEstudio, @nomeJogo, @descricao, @dataLancamento, @valor)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@idEstudio", novoJogo.estudio.idEstudio);
                    cmd.Parameters.AddWithValue("@nomeJogo", novoJogo.nomeJogo);
                    cmd.Parameters.AddWithValue("@descricao", novoJogo.descricao);
                    cmd.Parameters.AddWithValue("@dataLancamento", novoJogo.dataLancamento);
                    cmd.Parameters.AddWithValue("@valor", novoJogo.valor);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idJogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM JOGO WHERE idJogo = @id";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@id", idJogo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<JogoDomain> ListarTodos()
        {
            List<JogoDomain> listaJogo = new List<JogoDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectALL = "SELECT idJogo, nomeJogo, nomeEstudio FROM JOGOS jogo LEFT JOIN ESTUDIO estudio ON jogo.idEstudio = estudio.idEstudio; ";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectALL, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        JogoDomain jogo = new JogoDomain()
                        {
                            idJogo = Convert.ToInt32(rdr[0]),

                            nomeJogo = rdr[1].ToString(),

                            estudio = new EstudioDomain()
                            {
                                nomeEstudio = rdr[2].ToString()
                            }
                        };

                        listaJogo.Add(jogo);
                    }
                }
            }

            return listaJogo;
        }
    }
}
