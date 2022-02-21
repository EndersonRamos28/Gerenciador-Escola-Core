using Dapper;
using Models.Materias;
using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorEscolaRepositories.Materias
{
    public class MateriasRepositories
    {
        string pastaDados = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\GerenciadorEscola\";

        public async Task<List<MateriaModel>> GetAllMaterias()
        {
            var baseDados = "Data source = " + pastaDados + "dados.sdf; Password= 'tK&qVYM'";
            try
            {
                using (var conn = new SqlCeConnection(baseDados))
                {
                    var query = new StringBuilder();
                    query.Append(" SELECT * FROM Materias WHERE Apagado = 0 ");
                    var result = await conn.QueryAsync<MateriaModel>(query.ToString());
                    return result.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public async Task<bool> SaveMateria(string nome)
        {
            var baseDados = "Data source = " + pastaDados + "dados.sdf; Password= 'tK&qVYM'";
            try
            {
                using (var conn = new SqlCeConnection(baseDados))
                {
                    var query = new StringBuilder();
                    query.Append(" INSERT INTO Materias ( ");
                    query.Append(" Nome ");
                    query.Append(" ,Apagado ) ");
                    query.Append("VALUES ( ");
                    query.Append(" @nome ");
                    query.Append(" ,0 )");
                    await conn.ExecuteAsync(query.ToString(), new { nome });
                    return true;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public async Task<bool> UpdateMateria(MateriaModel model)
        {
            var baseDados = "Data source = " + pastaDados + "dados.sdf; Password= 'tK&qVYM'";
            try
            {
                using (var conn = new SqlCeConnection(baseDados))
                {
                    var query = new StringBuilder();
                    query.Append(" UPDATE Materias  ");
                    query.Append(" SET Nome = @Nome ");
                    query.Append(" WHERE MateriaId = MateriaId ");
                    await conn.ExecuteAsync(query.ToString(), model);
                    return true;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }
    }
}
