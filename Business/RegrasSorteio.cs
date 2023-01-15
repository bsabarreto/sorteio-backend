using DocumentFormat.OpenXml.Drawing.Charts;
using Domain.Entities;
using Domain.Enum;
using Domain.Interface;
using Repository;
using Repository.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class RegrasSorteio : IRegrasSorteio
    {
        public ListaDeGanhadores SelecionarVencedor(ListaDePessoas listaPessoas)
        {
            ListaDeGanhadores listaDeGanhadores = new ListaDeGanhadores();
            listaDeGanhadores.GeralGanhador = SelecionarVencedores(listaPessoas.Geral);
            listaDeGanhadores.IdososGanhador = SelecionarVencedor(listaPessoas.Idosos);
            listaDeGanhadores.DeficienteFisicoGanhador = SelecionarVencedor(listaPessoas.DeficienteFisico);

            return listaDeGanhadores; 
        }

        private Pessoa SelecionarVencedor(List<Pessoa> listaPessoas)
        {
            var rnd = new Random();
            Pessoa pessoaSelecionada = listaPessoas[rnd.Next(listaPessoas.Count)];
            return pessoaSelecionada;
        }
        private List<Pessoa> SelecionarVencedores(List<Pessoa> listaPessoas)
        {
            if (listaPessoas.Count <= 3) { return listaPessoas; }

            List<Pessoa> listaGanhadoresGeral = new List<Pessoa>();
            int numero;
            int[] num = new int[3];
            Random r = new Random();

            for (int i = 0; i < 3; i++)
            {
                numero = r.Next(listaPessoas.Count);
                for (int j = 0; j < 3; j++)
                {
                    if (numero == num[j] && j != i)
                    {
                        numero = r.Next(listaPessoas.Count) ;
                    }
                    else
                    {
                        num[i] = numero;
                    }
                }
            }
            Pessoa ganhadorUm = listaPessoas.ElementAt(num[0]);
            Pessoa ganhadorDois = listaPessoas.ElementAt(num[1]);
            Pessoa ganhadorTres = listaPessoas.ElementAt(num[2]);

            listaGanhadoresGeral.Add(ganhadorUm);
            listaGanhadoresGeral.Add(ganhadorDois);
            listaGanhadoresGeral.Add(ganhadorTres);

            return listaGanhadoresGeral;

        }

       

    public bool ValidarCPF(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }
        public bool ValidarIdade(DateTime dataNascimento)
        {
            int idade = DateTime.Now.Year - dataNascimento.Year;
            if (DateTime.Now.DayOfYear < dataNascimento.DayOfYear)
                idade = idade - 1;

            return idade > 15;
        }

        public List<Pessoa> ValidarListaDePessoa(List<Pessoa> listPessoas)
        {
            List < Pessoa > listaAux = new List <Pessoa>();
            foreach (Pessoa pessoa in listPessoas)
            {
                if(ValidarIdade(pessoa.DataNascimento) && ValidarRenda(pessoa.Renda) && ValidarCPF(pessoa.CPF))
                    listaAux.Add(pessoa);
            }
            return listaAux;
        }

        public bool ValidarRenda(decimal renda)
        {
            Decimal minimo = 1045.00m;
            Decimal maximo = 5225.00m;

            return renda >= minimo && renda <= maximo;
               
        }
    }
}
