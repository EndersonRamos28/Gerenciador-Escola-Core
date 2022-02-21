using GerenciadorEscolaRepositories.GeradorBase;
using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorEscolaApi
{
    public static class  IniciarBase
    {
        public static void Iniciar()
        {
            var pastaDados = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\GerenciadorEscola\";

            //VERIFICA SE A PASTA EXISTE, SE NÃO EXISTIR CRIA
            if (!Directory.Exists(pastaDados))
                Directory.CreateDirectory(pastaDados);

            //VERIFICA SE A BASE DE DADOS EXISTE
            var baseDados = pastaDados + "dados.sdf; Password= 'tK&qVYM'";
            if (!File.Exists(pastaDados + "dados.sdf"))
                //CHAMA O METEDO PRA CRIAR A BASE DE DADOS
                new GeradorBase().CriarBaseDados("Data source = " + baseDados);
        }

    }
}
