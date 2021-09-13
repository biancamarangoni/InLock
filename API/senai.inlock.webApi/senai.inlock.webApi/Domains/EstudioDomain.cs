using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Domains
{
    public class EstudioDomain
    {
        public int idEstudio { get; set; }


        //[Required(ErrorMessage = "Informe o nome do estudio")]
        //[StringLength(50, ErrorMessage = "O nome do estudio precisa ter no máximo 50 caracteres")]
        public string nomeEstudio { get; set; }
    }
}
