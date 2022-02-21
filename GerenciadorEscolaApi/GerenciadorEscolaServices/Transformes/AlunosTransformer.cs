using Models.Alunos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorEscolaServices.Transformes
{
    public class AlunosTransformer
    {
        internal AlunoModel Mapper(int alunoId, AlunoUpdateModel model)
        {
            return new AlunoModel
            {
                AlunoId = alunoId,
                CPF = model.CPF,
                Nome = model.Nome,
                DataNascimento = model.DataNascimento,
                Celular = model.Celular,
                Email = model.Email
            };
        }
    }
}
