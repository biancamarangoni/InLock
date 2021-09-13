using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Domains
{
    public class JogoDomain
    {
        public int idJogo { get; set; }


        public EstudioDomain estudio { get; set; }


        [Required(ErrorMessage = "Informe o nome do jogo")]
        [StringLength(50, ErrorMessage = "O nome do jogo precisa ter  no máximo 50 caracteres")]
        public string nomeJogo { get; set; }


        [StringLength(250, ErrorMessage = "A descrição do jogo precisa ter no máximo 250 caracteres")]
        public string descricao { get; set; }


        [Required(ErrorMessage = "Informe a data do lançamento")]
        [DataType(DataType.Date)]
        public DateTime dataLancamento { get; set; }


        [Required(ErrorMessage = "Informe o preço do jogo")]
        public double valor { get; set; }

    }
}
