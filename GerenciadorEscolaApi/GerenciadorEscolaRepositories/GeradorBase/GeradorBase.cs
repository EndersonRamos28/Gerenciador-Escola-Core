using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorEscolaRepositories.GeradorBase
{
    public class GeradorBase
    {

        public void CriarBaseDados(string baseDados)
        {
            //CRIAÇAO DA BASE DE DADOS
            var create = new SqlCeEngine(baseDados);
            create.CreateDatabase();
            try
            {
                using (var conn = new SqlCeConnection(baseDados))
                {
                    CreateTableMaterias(conn);
                    CreateTableProfessores(conn);
                    CreateTableAlunos(conn);
                    CreateTableNotas(conn);
                }
            }

            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }

        }

        private static void CreateTableAlunos(SqlCeConnection conn)
        {
            var query = new StringBuilder();
            query.Append(" CREATE TABLE [Alunos] ( ");
            query.Append(" [AlunoId] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY ");
            query.Append(" ,[CPF] [nvarchar] (25) NULL ");
            query.Append(" ,[Nome] [nvarchar] (255) NOT NULL ");
            query.Append(" ,[DataNascimento] [DateTime] NOT NULL ");
            query.Append(" ,[Celular] [nvarchar] (30) NULL ");
            query.Append(" ,[Email] [nvarchar] (50) NULL ");
            query.Append(" ,[DataCadastro] [DateTime]  NULL ");
            query.Append(" ,[Apagado] [bit]  NULL );");
            conn.Execute(query.ToString());
        }

        private static void CreateTableNotas(SqlCeConnection conn)
        {
            var query = new StringBuilder();
            query.Append(" CREATE TABLE [Notas]( ");
            query.Append(" [NotaId] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY ");
            query.Append(" ,[MateriaId] [int] NOT NULL ");
            query.Append(" ,[AlunoId] [int] NOT NULL ");
            query.Append(" ,[PrimeiroSemestre] [Decimal]  NULL ");
            query.Append(" ,[SegundoSemestre] [Decimal]  NULL ");
            query.Append(" ,[TerceiroSemestre] [Decimal]  NULL ");
            query.Append(" ,[QuartoSemestre] [Decimal]  NULL ");
            query.Append(" ,[Apagado] [bit]  NULL );");
            conn.Execute(query.ToString());

            var query2 = new StringBuilder();
            query2.Append(" ALTER TABLE [Notas] ADD CONSTRAINT [FK_Notas_Materias] ");
            query2.Append(" FOREIGN KEY ([MateriaId]) REFERENCES [Materias]([MateriaId]); ");
            conn.Execute(query2.ToString());
        }

        private static void CreateTableMaterias(SqlCeConnection conn)
        {
            var query = new StringBuilder();
            query.Append(" CREATE TABLE [Materias] ( ");
            query.Append(" [MateriaId] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY ");
            query.Append(" ,[Nome] [nvarchar] (255) NOT NULL ");
            query.Append(" ,[Apagado] [bit]  NULL ); ");
            conn.Execute(query.ToString());
        }

        private static void CreateTableProfessores(SqlCeConnection conn)
        {
            var query = new StringBuilder();
            query.Append(" CREATE TABLE [Professores] ( ");
            query.Append(" [ProfessorId] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY ");
            query.Append(" ,[MateriaId] [int] NOT NULL ");
            query.Append(" ,[CPF] [nvarchar] (25) NOT NULL ");
            query.Append(" ,[Nome] [nvarchar] (255) NOT NULL ");
            query.Append(" ,[DataNascimento] [DateTime] NOT NULL ");
            query.Append(" ,[Celular] [nvarchar] (30) NULL ");
            query.Append(" ,[Email] [nvarchar] (50) NULL ");
            query.Append(" ,[DataCadastro] [DateTime]  NULL ");
            query.Append(" ,[Apagado] [bit]  NULL );");
            conn.Execute(query.ToString());

            var query2 = new StringBuilder();
            query2.Append(" ALTER TABLE [Professores] ADD CONSTRAINT [FK_Professores_Materias] ");
            query2.Append(" FOREIGN KEY ([MateriaId]) REFERENCES [Materias]([MateriaId]); ");
            conn.Execute(query2.ToString());
        }
    }
}


