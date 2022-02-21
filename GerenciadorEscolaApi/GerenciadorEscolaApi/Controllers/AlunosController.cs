using GerenciadorEscolaServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Alunos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorEscolaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly ILogger<AlunosController> _logger;

        public AlunosController(ILogger<AlunosController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Método para trazer todos os Alunos cadastrados
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllAlunos")]
        public async Task<IActionResult> GetAllMaterias()
        {
            var response = await new AlunosServices().GetAllAlunos();
            return StatusCode(StatusCodes.Status200OK, response);
        }

        /// <summary>
        /// Método para salvar novo registro de Aluno
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("SaveAluno")]
        public async Task<IActionResult> SaveAluno([FromBody] AlunoSaveModel model)
        {
            var response = await new AlunosServices().SaveAluno(model);
            return StatusCode(StatusCodes.Status200OK, response);
        }
        /// <summary>
        /// Método responsavel pela atualização dos dados do Aluno
        /// </summary>
        /// <param name="alunoId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("UpdateAluno/{alunoId}")]
        public async Task<IActionResult> UpdateAluno([FromRoute] int alunoId , [FromBody] AlunoUpdateModel model)
        {
            var response = await new AlunosServices().UpdateAluno(alunoId, model);
            return StatusCode(StatusCodes.Status200OK, response);
        }
    }
}
