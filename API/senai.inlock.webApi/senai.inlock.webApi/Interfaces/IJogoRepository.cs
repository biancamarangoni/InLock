using senai.inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Interfaces
{
    interface IJogoRepository
    {

        /// <summary>
        /// Retorna todos os jogos
        /// </summary>
        /// <returns>Uma lista de jogos</returns>
        List<JogoDomain> ListarTodos();

        /// <summary>
        /// Busca um jogo através do seu id
        /// </summary>
        /// <param name="idJogo">id do jogo que será buscado</param>
        /// <returns>Um objeto do tipo JogoDomain que foi buscado</returns>
        JogoDomain BuscarPorId(int idJogo);

        /// <summary>
        /// Cadastra um novo jogo
        /// </summary>
        /// <param name="novoJogo">Objeto novoJogo com os dados que serão cadastrados</param>
        void Cadastrar(JogoDomain novoJogo);

        /// <summary>
        /// Atualiza um jogo existente passando o id pelo corpo da requisição
        /// </summary>
        /// <param name="jogoAtualizado">Objeto jogoAtualizado com os novos dados</param>
        /// ex: http://localhost:5000/api/jogos
        void Atualizar(JogoDomain jogoAtualizado);


        /// <summary>
        /// Deleta um jogo
        /// </summary>
        /// <param name="idJogo">id do jogo que será deletado</param>
        void Deletar(int idJogo);
    }
}
