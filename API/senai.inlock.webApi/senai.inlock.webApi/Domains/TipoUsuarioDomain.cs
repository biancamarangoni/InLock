using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Domains
{
    public class TipoUsuarioDomain
    {
        public int idTipoUsuario { get; set; }

        [Required(ErrorMessage = "Informe o tipo de usuario")]
        public string titulo { get; set; }
    }
}
