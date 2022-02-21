using Dapper;
using Models.Alunos;
using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorEscolaRepositories.Alunos
{
    public class AlunosRepositories
    {
        string pastaDados = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\GerenciadorEscola\";

        public async Task<List<AlunoModel>> GetAllAlunos()
        {
            var baseDados = "Data source = " + pastaDados + "dados.sdf; Password= 'tK&qVYM'";
            try
            {
                using (var conn = new SqlCeConnection(baseDados))
                {
                    var query = new StringBuilder();
                    query.Append(" SELECT * FROM Alunos WHERE Apagado = 0 ");
                    var result = await conn.QueryAsync<AlunoModel>(query.ToString());
                    return result.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public async Task<bool> SaveAluno(AlunoSaveModel model)
        {
            var baseDados = "Data source = " + pastaDados + "dados.sdf; Password= 'tK&qVYM'";
            try
            {
                using (var conn = new SqlCeConnection(baseDados))
                {
                    var query = new StringBuilder();
                    query.Append(" INSERT INTO Alunos ( ");
                    query.Append(" CPF ");
                    query.Append(" ,Nome ");
                    query.Append(" ,DataNascimento ");
                    query.Append(" ,Celular ");
                    query.Append(" ,Email ");
                    query.Append(" ,DataCadastro ");
                    query.Append(" ,Apagado ) ");
                    query.Append("VALUES ( ");
                    query.Append(" @CPF ");
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

        public async Task<bool> UpdateAluno(AlunoModel model)
        {
            var baseDados = "Data source = " + pastaDados + "dados.sdf; Password= 'tK&qVYM'";
            try
            {
                using (var conn = new SqlCeConnection(baseDados))
                {
                    var query = new StringBuilder();
                    query.Append("UPDATE Alunos ");
                    query.Append(" SET CPF = @CPF ");
                    query.Append(" ,Nome = @Nome ");
                    query.Append(" ,DataNascimento = @DataNascimento ");
                    query.Append(" ,Celular = @Celular ");
                    query.Append(" ,Email = @Email ");
                    query.Append(" WHERE AlunoId = @AlunoId");
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
