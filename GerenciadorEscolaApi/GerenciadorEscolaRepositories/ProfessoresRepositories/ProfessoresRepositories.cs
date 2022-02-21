using Dapper;
using Microsoft.Extensions.Configuration;
using Models;
using Models.Professores;
using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorEscolaRepositories.ProfessoresRepositories
{
    public class ProfessoresRepositories
    {
        string pastaDados = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\GerenciadorEscola\";

        public async Task<bool> SaveProfessor(ProfessorSaveModel model)
        {
            var baseDados = "Data source = " + pastaDados + "dados.sdf; Password= 'tK&qVYM'";
            try
            {
                using (var conn = new SqlCeConnection(baseDados))
                {
                    var query = new StringBuilder();
                    query.Append(" INSERT INTO Professores ( ");
                    query.Append(" MateriaId ");
                    query.Append(" ,CPF ");
                    query.Append(" ,Nome ");
                    query.Append(" ,DataNascimento ");
                    query.Append(" ,Celular ");
                    query.Append(" ,Email ");
                    query.Append(" ,DataCadastro ");
                    query.Append(" ,Apagado ) ");
                    query.Append("VALUES ( ");
                    query.Append(" @MateriaId ");
                    query.Append(" ,@CPF ");
                    query.Append(" ,@Nome ");
                    query.Append(" ,@DataNascimento ");
                    query.Append(" ,@Celular ");
                    query.Append(" ,@Email ");
                    query.Append(" ,GetDate() ");
                    query.Append(" ,0 )");
                    await conn.ExecuteAsync(query.ToString(), model);
                    return true;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public async Task<List<ProfessorModel>> GetAllProfessores()
        {
            var baseDados = "Data source = " + pastaDados + "dados.sdf; Password= 'tK&qVYM'";
            try
            {
                using (var conn = new SqlCeConnection(baseDados))
                {
                    var query = new StringBuilder();
                    query.Append(" SELECT * FROM Professores WHERE Apagado = 0 ");
                    var result = await conn.QueryAsync<ProfessorModel>(query.ToString());
                    return result.ToList();
                }
            }

            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }

        }

        public async Task<bool> UpdateProfessor(ProfessorModel model)
        {
            var baseDados = "Data source = " + pastaDados + "dados.sdf; Password= 'tK&qVYM'";
            try
            {
                using (var conn = new SqlCeConnection(baseDados))
                {
                    var query = new StringBuilder();
                    query.Append("UPDATE Professores ");
                    query.Append(" SET MateriaId = @MateriaId ");
                    query.Append(" ,CPF = @CPF ");
                    query.Append(" ,Nome = @Nome ");
                    query.Append(" ,DataNascimento = @DataNascimento ");
                    query.Append(" ,Celular = @Celular ");
                    query.Append(" ,Email = @Email ");
                    query.Append(" WHERE ProfessorId = @ProfessorId");
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
