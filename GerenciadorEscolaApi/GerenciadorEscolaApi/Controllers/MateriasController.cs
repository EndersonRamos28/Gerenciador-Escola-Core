using GerenciadorEscolaServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Materias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorEscolaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriasController : ControllerBase
    {
        private readonly ILogger<MateriasController> _logger;

        public MateriasController(ILogger<MateriasController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Método para trazer todos as Matérias cadastrados
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllMaterias")]
        public async Task<IActionResult> GetAllMaterias()
        {
            var response = await new MateriasServices().GetAllMaterias();
            return StatusCode(StatusCodes.Status200OK, response);
        }

        /// <summary>
        /// Método para salvar novo registro de Matéria
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        [HttpPost("SaveMateria/{nome}")]
        public async Task<IActionResult> SaveMateria([FromRoute] string nome)
        {
            var response = await new MateriasServices().SaveMateria(nome);
            return StatusCode(StatusCodes.Status200OK, response);
        }
        /// <summary>
        /// Método responsavel pela atualização dos dados da Matéria
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("UpdateMateria")]
        public async Task<IActionResult> UpdateProfessor( [FromBody] MateriaModel model)
        {
            var response = await new MateriasServices().UpdateMateria(model);
            return StatusCode(StatusCodes.Status200OK, response);
        }
    }
}
