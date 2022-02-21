using GerenciadorEscolaRepositories.Materias;
using Models.Materias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorEscolaServices
{
    public class MateriasServices
    {
        public async Task<List<MateriaModel>> GetAllMaterias()
        {
            return await new MateriasRepositories().GetAllMaterias();
        }

        public async Task<bool> SaveMateria(string nome)
        {
            return await new MateriasRepositories().SaveMateria(nome);
        }

        public async Task<bool> UpdateMateria(MateriaModel model)
        {
            return await new MateriasRepositories().UpdateMateria(model);
        }
    }
}
