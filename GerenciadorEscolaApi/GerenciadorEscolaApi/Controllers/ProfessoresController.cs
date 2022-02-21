using GerenciadorEscolaServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Models;
using Models.Professores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorEscolaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessoresController : ControllerBase
    {
        private readonly ILogger<ProfessoresController> _logger;

        public ProfessoresController(ILogger<ProfessoresController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Método para trazer todos os professores cadastrados
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllProfessores")]
        public async Task<IActionResult> GetAllProfessores()
        {
            var response = await new ProfessoresServices().GetAllProfessores();
            return StatusCode(StatusCodes.Status200OK, response);
        }

        /// <summary>
        /// Método para salvar novo registro de professor
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("SaveProfessor")]
        public async Task<IActionResult> SaveProfessor([FromBody] ProfessorSaveModel model)
        {
            var response = await new ProfessoresServices().SaveProfessor(model);
            return StatusCode(StatusCodes.Status200OK, response);
        }
        /// <summary>
        /// Método responsavel pela atualização dos dados do professor
        /// </summary>
        /// <param name="professorId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("UpdateProfessor")]
        public async Task<IActionResult> UpdateProfessor([FromRoute] int professorId, [FromBody] ProfessorUpdateModel model)
        {
            var response = await new ProfessoresServices().UpdateProfessor(professorId, model);
            return StatusCode(StatusCodes.Status200OK, response);
        }
    }
}
