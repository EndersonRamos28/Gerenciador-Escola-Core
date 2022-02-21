using GerenciadorEscolaRepositories.ProfessoresRepositories;
using Microsoft.Extensions.Configuration;
using Models;
using Models.Professores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorEscolaServices
{
    public class ProfessoresServices
    {
        public async Task<List<ProfessorModel>> GetAllProfessores()
        {
            return await new ProfessoresRepositories().GetAllProfessores();
        }

        public async Task<bool> SaveProfessor(ProfessorSaveModel model)
        {
            return await new ProfessoresRepositories().SaveProfessor(model);
        }

        public async Task<bool> UpdateProfessor(int professorId, ProfessorUpdateModel model)
        {
            return await new ProfessoresRepositories().UpdateProfessor(new ProfessoresTransformer().Mapper(professorId, model));
        }
    }
}
