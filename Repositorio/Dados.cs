using ClosedXML.Excel;
using Domain.Entities;
using Domain.Enum;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Repository
{
    public class Dados : IDados
    {
        public List<string> LerArquivoDeDados()
        {
            List<string> dadosSemFormatacao = new List<string>();    
            var fullPath = Path.GetFullPath("lista_pessoas.xlsx");

            var xls = new XLWorkbook(fullPath);
            var planilha = xls.Worksheets.First(w => w.Name == "lista_pessoas");
            var totalLinhas = planilha.Rows().Count();

            for (int l = 2; l <= totalLinhas; l++)
            {
                var codigo = planilha.Cell($"A{l}").Value.ToString();
                dadosSemFormatacao.Add(codigo);
            }
            return dadosSemFormatacao;
        }

        private int PopularIdade(int ano, int mes, int dia)
        {
            DateTime dataNascimento = new DateTime(ano, mes, dia);
            int idade = DateTime.Now.Year - dataNascimento.Year;
            if (DateTime.Now.DayOfYear < dataNascimento.DayOfYear)
                idade = idade - 1;

            return idade;
        }

        public List<Pessoa> FormatarObjetoPessoa(List<string> dadosSemFormatacao)
        {
            List<Pessoa> listaDePessoas = new List<Pessoa>();

            foreach (var item in dadosSemFormatacao)
            {
                if (!String.IsNullOrEmpty(item))
                {
                    var dadosPessoa = item.Split(",");
                    var dataNascimento = dadosPessoa[2].Split('/');

                    var pessoa = new Pessoa
                    {
                        Nome = dadosPessoa[0],
                        CPF = dadosPessoa[1],
                        DataNascimento = new DateTime(int.Parse(dataNascimento[2]), int.Parse(dataNascimento[1]), int.Parse(dataNascimento[0])),
                        Renda = decimal.Parse(dadosPessoa[3], new CultureInfo("en-US")),
                        Cota = dadosPessoa[4].ToUpper().Equals("GERAL") ? Domain.Enum.EnumCota.GERAL : (dadosPessoa[4].ToUpper().Equals("IDOSO") ? Domain.Enum.EnumCota.IDOSO : Domain.Enum.EnumCota.DEFICIENTE_FISICO),
                        CID = dadosPessoa[5],
                        Idade = PopularIdade(int.Parse(dataNascimento[2]), int.Parse(dataNascimento[1]), int.Parse(dataNascimento[0]))

                    };

                    listaDePessoas.Add(pessoa);
                }


            }
            return listaDePessoas;
        }

   
    }
}
