using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class JogosController : Controller
    {
        private IJogoRepository _JogoRepository { get; set; }

        public JogosController()
        {
            _JogoRepository = new JogoRepository();
        }

            [Authorize]
            [HttpGet]
            public IActionResult Get()
            {
               // try
               // {
                    List<JogoDomain> ListaJogos = _JogoRepository.ListarTodos();

                    return Ok(ListaJogos);
               // }
               // catch (Exception erro)
               // {
               //     return BadRequest(erro);
               // }
            }

            [Authorize]
            [HttpGet("{id}")]
            public IActionResult GetById(int id)
            {
                try
                {
                    JogoDomain jogoBuscado = _JogoRepository.BuscarPorId(id);

                    if (jogoBuscado != null)
                    {
                        return Ok(jogoBuscado);
                    }

                    return NotFound("jogo não encontrado");
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }

            [Authorize(Roles = "ADMINISTRADOR")]
            [HttpPost]
            public IActionResult Post(JogoDomain NovoJogo)
            {
                try
                {
                    _JogoRepository.Cadastrar(NovoJogo);
                    return StatusCode(201);
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }

            [Authorize(Roles = "ADMINISTRADOR")]
            [HttpDelete("{IdDeleta}")]
            public IActionResult Delete(int IdDeleta)
            {
                try
                {
                    _JogoRepository.Deletar(IdDeleta);
                    return StatusCode(204);
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }

            [Authorize(Roles = "ADMINISTRADOR")]
            [HttpPut]
            public IActionResult Put(JogoDomain JogoAtualizar)
            {
                JogoDomain JogoBuscado = _JogoRepository.BuscarPorId(JogoAtualizar.idJogo);

                if (JogoBuscado != null)
                {
                    try
                    {
                    _JogoRepository.Atualizar(JogoAtualizar);
                        return NoContent();
                    }
                    catch (Exception erro)
                    {
                        return BadRequest(erro);
                    }
                }

                return NotFound(new
                {
                    mensagem = "Jogo não encontrado",
                    Coderro = true
                });
            }
        }



}

