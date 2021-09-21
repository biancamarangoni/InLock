using senai.inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Interfaces
{
    interface IUsuarioRepository
    {

        /// <summary>
        /// Valida o usuário
        /// </summary>
        /// <param name="email"></param>
        /// <param name="senha"></param>
        /// <returns>Um objeto do tipo UsuarioDomain que foi buscado</returns>
        UsuarioDomain BuscarPorEmailSenha(string email, string senha);

    }
}
