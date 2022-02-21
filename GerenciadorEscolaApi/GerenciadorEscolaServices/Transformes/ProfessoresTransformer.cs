using Models;
using Models.Professores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorEscolaServices
{
    public class ProfessoresTransformer
    {
        internal ProfessorModel Mapper(int professorId, ProfessorUpdateModel model)
        {
            return new ProfessorModel
            {
                ProfessorId = professorId,
                MateriaId = model.MateriaId,
                CPF = model.CPF,
                Nome = model.Nome,
                DataNascimento = model.DataNascimento,
                Celular = model.Celular,
                Email = model.Email
            };
        }
    }
}
