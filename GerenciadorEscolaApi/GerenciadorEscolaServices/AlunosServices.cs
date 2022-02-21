using GerenciadorEscolaRepositories.Alunos;
using GerenciadorEscolaServices.Transformes;
using Models.Alunos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorEscolaServices
{
    public class AlunosServices
    {
        public async Task<List<AlunoModel>> GetAllAlunos()
        {
            return await new AlunosRepositories().GetAllAlunos();
        }

        public async Task<bool> SaveAluno(AlunoSaveModel model)
        {
            return await new AlunosRepositories().SaveAluno(model);
        }

        public async Task<bool> UpdateAluno(int alunoId, AlunoUpdateModel model)
        {
            return await new AlunosRepositories().UpdateAluno(new AlunosTransformer().Mapper(alunoId, model));
        }
    }
}
